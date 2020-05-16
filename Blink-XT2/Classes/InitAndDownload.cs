using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static Blink.Classes.StoreIt;

namespace Blink.Classes
{
    public class InitAndDownload
    {
        private const int MagicNumberVideosPerPage = 25;

        public BaseData Start(Form1 form, string email, string password, string saveDirectory, bool isGerman)
        {
            try
            {
                form.SetP0TxtBoxInfoText("Started.");
                form.SetP0TxtBoxInfoText(string.Empty);

                var common = new Common();
                var uweR70_Command = new UweR70_Command();
                var uweR70_Get = new UweR70_Get();
                var storeIt = new StoreIt();

                var baseData = new BaseData
                {
                    Email = email,
                    LoginTier = isGerman ? "prde" : "prod",
                    Networks = new List<BaseData.Network>()
                };

                Blink.BatteryUsage batteryUssage = null;

                var alreadyStoredAuthTokens = storeIt.ReadAuthToken();
                var alreadyStoredMainData = storeIt.ReadMainData();
                var oldAuthTokenWorked = false;
                if (alreadyStoredAuthTokens != null && alreadyStoredAuthTokens.Count != 0 && alreadyStoredMainData != null)
                {
                    try
                    {
                        baseData.RegionTier = alreadyStoredMainData.RegionTier;
                        baseData.RegionDescription = alreadyStoredMainData.RegionDescription;
                        baseData.AuthToken = alreadyStoredAuthTokens[alreadyStoredAuthTokens.Count - 1].Token;
                        baseData.AccountId = alreadyStoredMainData.AccountId;

                        batteryUssage = uweR70_Get.BatteryUssageAsync(baseData).Result;

                        oldAuthTokenWorked = true;
                    }
                    catch {}
                }
                if (!oldAuthTokenWorked)
                { 
                    // Authentification api call
                    var login = uweR70_Get.LoginAsync(baseData, new UweR70_Get.LoginBody
                    {
                        email = email,
                        password = password
                    }).Result;

                    baseData.RegionTier = login.region.tier;
                    baseData.RegionDescription = login.region.description;
                    baseData.AuthToken = login.authtoken.authtoken;
                    baseData.AccountId = login.account.id;

                    batteryUssage = uweR70_Get.BatteryUssageAsync(baseData).Result;
                    storeIt.StoreData(baseData, batteryUssage);
                }
               
                for (var i = 0; i < batteryUssage.networks.Length; i++)
                {
                    baseData.Networks.Add(new BaseData.Network
                    {
                        Id = batteryUssage.networks[i].network_id,
                        Name = batteryUssage.networks[i].name,
                        Cameras = new List<BaseData.Camera>()
                    });

                    var minData = new MinimumData
                    {
                        AuthToken = baseData.AuthToken,
                        RegionTier = baseData.RegionTier,
                        NetworkId = baseData.Networks[i].Id
                    };

                    form.SetP0TxtBoxInfoText($"Network id >{baseData.Networks[i].Id}<");
                    form.SetP0TxtBoxInfoText($"Network name >{baseData.Networks[i].Name}<");
                    form.SetP0TxtBoxInfoText($"camera count >{batteryUssage.networks[i].cameras.Length}<");

                    for (var n = 0; n < batteryUssage.networks[i].cameras.Length; n++)
                    {
                        form.SetP0TxtBoxInfoText(string.Empty);
                        form.SetP0TxtBoxInfoText($"camera #{n + 1:D2}");

                        baseData.Networks[i].Cameras.Add(new BaseData.Camera
                        {
                            Id = batteryUssage.networks[i].cameras[n].id,
                            Name = batteryUssage.networks[i].cameras[n].name,
                            Media = new BaseData.Media()
                        });

                        minData.CameraId = baseData.Networks[i].Cameras[n].Id;

                        form.SetP0TxtBoxInfoText($"camera id >{baseData.Networks[i].Cameras[n].Id}<");
                        form.SetP0TxtBoxInfoText($"camera name >{baseData.Networks[i].Cameras[n].Name}<");

                        var cameraStatus = uweR70_Get.CameraStatusAsync(minData).Result;

                        var cameraThumbnail = cameraStatus.camera_status.thumbnail;

                        var networkNameAndId = common.CombineNameAndId(baseData.Networks[i].Name, baseData.Networks[i].Id);
                        var cameraNameAndId = common.CombineNameAndId(batteryUssage.networks[i].cameras[n].name, batteryUssage.networks[i].cameras[n].id);
                        var storagePath = GetStoragePath(saveDirectory, networkNameAndId, cameraNameAndId);
                        if (string.IsNullOrEmpty(baseData.StoragePathNetwork))
                        {   /* Both folligng directories where created while  "GetStoragePath(...)" worked out!
                               because the there combined path contains all parts of the following two combined directories.
                            */
                            baseData.StoragePathNetwork = Path.Combine(saveDirectory, $"{Config.StoragePartBase}\\{networkNameAndId}");
                            baseData.StoragePathMain = $"{baseData.StoragePathNetwork}\\{Config.StoragePartMain}";
                        }
                        var cameraThumbnailFileName = GetAdjustedCameraThumbnailFileName(Path.GetFileName(cameraThumbnail));
                        var cameraThumbnailPathAndFileName = $"{storagePath}\\{cameraThumbnailFileName}";
                        baseData.Networks[i].Cameras[n].Media.PathAndFileNameThumbnail = cameraThumbnailPathAndFileName;
                        baseData.Networks[i].Cameras[n].Media.PathAndFileNameVideos = new List<string>();
                        if (!File.Exists(cameraThumbnailPathAndFileName))
                        {
                            var cameraThumbnailByteArray = uweR70_Get.ThumbnailImageAsync(minData, cameraThumbnail).Result;
                            File.WriteAllBytes(cameraThumbnailPathAndFileName, cameraThumbnailByteArray);
                        }
                    }
                }

                var timestampFormatter = common.GetTimestampFormatter();

                var pageCounter = 0;
                var aborted = false;
                form.SetP0TxtBoxInfoText(string.Empty);
                form.SetP0TxtBoxInfoText($"Try to download videos.");
                do
                {
                    pageCounter++;

                    var changedMedia = uweR70_Get.ChangedMediaAsync(baseData, pageCounter).Result;
                    if (changedMedia.media == null || changedMedia.media.Length == 0)
                    {
                        break;
                    }

                    form.SetP0TxtBoxInfoText(string.Empty);
                    form.SetP0TxtBoxInfoText($"Page #{pageCounter} contains {changedMedia.media.Length} videos.");

                    var counterMarkedAsDeleted = 0;
                    var counterAlreadyBeforeDownloaded = 0;
                    var counterDownloaded = 0;

                    form.SetP0TxtBoxInfoText($"\tMarked as deleted #{counterMarkedAsDeleted}.");
                    form.SetP0TxtBoxInfoText($"\tAlready before downloaded #{counterAlreadyBeforeDownloaded}.");
                    form.SetP0TxtBoxInfoText($"\tDownloaded #{counterDownloaded}.");

                    for (var i = 0; i < changedMedia.media.Length; i++)
                    {
                        if (changedMedia.media[i].deleted)
                        {
                            counterMarkedAsDeleted++;
                            AdjustInfo(form, common, $"\tMarked as deleted #{counterMarkedAsDeleted - 1}.", $"\tMarked as deleted #{counterMarkedAsDeleted}.");

                            if (counterMarkedAsDeleted == MagicNumberVideosPerPage)
                            {
                                form.SetP0TxtBoxInfoText($"Download aborted becasue current page cantains {MagicNumberVideosPerPage} as deleted marked videos!");
                                aborted = true;
                                break;
                            }
                            continue;
                        }
                        
                        var networkObject = baseData.Networks.Where(x => x.Id == changedMedia.media[i].network_id).ToList();
                        if (networkObject == null || networkObject.Count() != 1)
                        {
                            // Should never be true!
                            continue;
                        }
                        var cameraObject = networkObject[0].Cameras.Where(x => x.Id == changedMedia.media[i].device_id).ToList();
                        if (cameraObject == null || cameraObject.Count() != 1)
                        {
                            // Should never be true!
                            continue;
                        }

                        // Method called and not just path combined because called method creates directory if it does not exist.
                        var networkNameAndId = common.CombineNameAndId(changedMedia.media[i].network_name, changedMedia.media[i].network_id);
                        var cameraNameAndId = common.CombineNameAndId(changedMedia.media[i].device_name, changedMedia.media[i].device_id);
                        var storagePath = GetStoragePath(saveDirectory, networkNameAndId, cameraNameAndId);
                        var videoFileName = changedMedia.media[i].created_at.ToString(timestampFormatter) + ".mp4";
                        var videoPathAndFileName = $"{storagePath}\\{videoFileName}";
                        cameraObject[0].Media.PathAndFileNameVideos.Add(videoPathAndFileName);
                        if (!File.Exists(videoPathAndFileName))
                        {
                            var videoByteArray = uweR70_Get.VideoAsync(baseData, changedMedia.media[i].media).Result;
                            File.WriteAllBytes(videoPathAndFileName, videoByteArray);
                            counterDownloaded++;
                            AdjustInfo(form, common, $"\tDownloaded #{counterDownloaded - 1}.", $"\tDownloaded #{counterDownloaded}.");
                        }
                        else
                        {
                            counterAlreadyBeforeDownloaded++;
                            AdjustInfo(form, common, $"\tAlready before downloaded #{counterAlreadyBeforeDownloaded - 1}.", $"\tAlready before downloaded #{counterAlreadyBeforeDownloaded}.");
                        }
                    }
                } while (!aborted);
                
                form.SetP0TxtBoxInfoText(string.Empty);
                form.SetP0TxtBoxInfoText("Done!");
                return baseData;
            }
            catch (Exception ex)
            {
                form.SetP0TxtBoxInfoText(string.Empty);
                form.SetP0TxtBoxInfoText($"### ERROR ###");
                var errorMessage = ex.Message;
                if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
                {
                    errorMessage = ex.InnerException.Message;
                }
                form.SetP0TxtBoxInfoText($"\t{errorMessage}");
                return null;
            }
        }

        private string GetStoragePath(string baseStoragePath, string networkNameAndId, string cameraNameAndId)
        {
            var storagePath = Path.Combine(baseStoragePath, $"{Config.StoragePartBase}\\{networkNameAndId}\\{Config.StoragePartMain}\\{cameraNameAndId}");
            if (!Directory.Exists(storagePath))
            {
                Directory.CreateDirectory(storagePath);
            }
            return storagePath;
        }

        private string GetAdjustedCameraThumbnailFileName(string originalFileName)
        {
            if (string.IsNullOrEmpty(originalFileName))
            {
                throw new ArgumentNullException();
            }
            // Notice that the Blink thumbnail filename does not contains any extention like ".jpg".
            // "fw_7.96__ABCDEFGH_2020_04_19__22_17PM"  -> "2020_04_19__22_17PM___fw_7.96__ABCDEFGH.jpg"
            var year = DateTime.Now.Year;
            while (!originalFileName.Contains($"_{year}_"))
            {
                year--;
                if (year < 1970)
                {
                    return originalFileName;
                }
            }

            var index = originalFileName.IndexOf($"_{year}_");
            var timestampPart = originalFileName.Substring(index);
            var firstPart = originalFileName.Replace(timestampPart, string.Empty);
            var ret = $"{timestampPart.Substring(1)}___{firstPart}.jpg";
            return ret;
        }

        private void AdjustInfo(Form1 form, Common common, string toBeReplaced, string replacement)
        {
            var completeMessage = form.GetLog();
            var result = common.ReplaceParts(completeMessage, toBeReplaced, replacement);
            form.SetP0TxtBoxInfoText(result, false);
        }
    }
}
