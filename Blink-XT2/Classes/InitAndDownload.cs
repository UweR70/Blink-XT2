using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Blink.Classes
{
    public class InitAndDownload
    {
        public BaseData Start(Form1 form, string email, string password, string saveDirectory, bool isGerman)
        {
            try
            {
                form.SetLog("Started.");
                form.SetLog(string.Empty);

                var common = new Common();
                var uweR70_FireCommand = new UweR70_FireCommand();
                var uweR70_Get = new UweR70_Get();

                var baseData = new BaseData
                {
                    Email = email,
                    ApiServer = isGerman
                                    ? "prde.immedia-semi.com"
                                    : "prod.immedia-semi.com"
                };

                #region Comment
                /* This will be a little bit longer ... but it is worth to read it! Otherwise you will not fully undersatnd what is going on here.
                 *
                 *  There is a ".../regions" API call.
                 *  This API call returned in Germany mid April 2020:
                 *  regions :=   preferred = "e002"
                 *
                 *              regions.e002.display_order = 1                      // "e002":{"dns":"e002","friendly_name":"Europe","registration":true,"display_order":1},
                 *              regions.e002.dns           = "e002"
                 *              regions.e002.friendly_name = "Europe"
                 *              regions.e002.registration  = true
                 *
                 *              regions.sg.display_order = 4                        // "sg":{"dns":"prsg","friendly_name":"Southeast Asia","registration":true,"display_order":4},
                 *              regions.sg.dns           = "prsg"
                 *              regions.sg.friendly_name = "Southeast Asia"
                 *              regions.sg.registration  = true
                 *
                 *              regions.usu012.display_order = 5                    // "usu012":{"dns":"u012","friendly_name":"United States - WEST","registration":true,"display_order":5}}}
                 *              regions.usu012.dns           = "u012"
                 *              regions.usu012.friendly_name = "United States - WEST"
                 *              regions.usu012.registration  = true
                 *
                 *              regions.usu013.display_order = 3                    // "usu013":{"dns":"u013","friendly_name":"United States - CENTRAL","registration":true,"display_order":3},
                 *              regions.usu013.dns           = "u013"
                 *              regions.usu013.friendly_name = "United States - CENTRAL"
                 *              regions.usu013.registration  = true
                 *
                 *              regions.usu017.display_order = 2                    // "usu017":{"dns":"u017","friendly_name":"United States - EAST","registration":true,"display_order":2},
                 *              regions.usu017.dns           = "u017"
                 *              regions.usu017.friendly_name = "United States - EAST"
                 *              regions.usu017.registration  = true
                 *
                 *  In my opinion are there these issues:
                 *      - Issue 1:
                 *        The region instances "e002", "sg", "usu012", "usu013" and "usu017" are hardcoded instead added as a list of "region".
                 *        See my class "BlinkRegionsAdjustedByUweR70" to see how it should be implemented!
                 *
                 *      - Issue 2:
                 *        The regions are named as                             "sg"  , "usu012", "usu013" and "usu017" 
                 *        while the value of the "dns" property are containing "prsg", "u012"  , "u013"   and "u017".
                 *        
                 *      - Issue 3:
                 *        The region "e001" does not appear here while it does in the ".../login" API call.
                 * 
                 *  To come these issues over I
                 *      1.) made the ".../regions" API call, 
                 *      2.) assigned the returned "preferred" value to "baseData.RegionPropertyName" for later API call use,
                 *      3.) converted the returned "regions" to the class "BlinkRegionsAdjustedByUweR70",
                 *      4.) searched in the "converted" object "regionsAdjusted" (which is type of "BlinkRegionsAdjustedByUweR70") 
                 *          the correct region. In my case was "dns" equal to "e002". Notice the "2" at the end!
                 *      and
                 *      5.) used the value of the property "Dns" of the found region object.
                 *    Means finally that "baseData.RegionValue" contained in my case "e002".
                 *    
                 *  Surprise, surprise:
                 *  
                 *      Surprise A)
                 *      The next made API call is the ".../login" call.
                 *      To my surprise returned this a property(!) called "e001". 
                 *      Note that it was/is "e001" and not "e002" as returned from the ".../regions" API call (which is there named as "preferred"!)
                 *
                 *      Surprise B)
                 *      To my understanding it is a good advise to take always the "preferred".
                 *      So I took it (= "e002") and ran in an "not authentificated" error for the next (".../camera/...") API call!
                 *      
                 *  Finally:
                 *      Make the ".../login" API call and use the NAME of the returned property. 
                 *      Which was/is in my case "e001".
                 * 
                 * CODE to verify:
                 */
                //// Getting the region code (aka "dns") like 'e002' from a regions call and NOT from the property name(!) of the later made authentification api call!
                //var regions = uweR70_Get.RegionsAsync(baseData).Result;
                //baseData.RegionPropertyName = regions.preferred;

                //var regionsAdjusted = common.ConvertBlinkRegions(regions);
                //var regionObject = regionsAdjusted.Regions.Where(x => x.Dns.Equals(regions.preferred, StringComparison.InvariantCultureIgnoreCase)).ToList();
                //if (regionObject == null || regionObject.Count != 1)
                //{
                //    throw new Exception("Could not determine region code (like'e002', 'prsg', 'u017', etc.)!");
                //}
                //baseData.RegionValue = regionObject[0].Dns;
                #endregion

                // Authentification api call
                var login = uweR70_Get.LoginAsync(baseData, new UweR70_Get.LoginBody
                {
                    email = email,
                    password = password
                }).Result;

                baseData.RegionPropertyName = nameof(login.region.e001);         // Change to that "login.region.xxx" value that is in your case not equal to null!
                baseData.RegionValue = login.region.e001;
                baseData.AuthToken = login.authtoken.authtoken;
                baseData.AccountId = login.account.id;
                baseData.Networks = new List<BaseData.Network>();

                var blinkNetwork = uweR70_Get.NetworkAsync(baseData).Result;//

                for (var i = 0; i < blinkNetwork.networks.Length; i++)
                {
                    baseData.Networks.Add(new BaseData.Network
                    {
                        Id = blinkNetwork.networks[i].network_id,
                        Name = blinkNetwork.networks[i].name,
                        Cameras = new List<BaseData.Camera>()
                    });

                    var minData = new MinimumData
                    {
                        ApiServer = baseData.ApiServer,
                        AuthToken = baseData.AuthToken,
                        RegionPropertyName = baseData.RegionPropertyName,
                        NetworkId = baseData.Networks[i].Id
                    };

                    form.SetLog($"Network id >{baseData.Networks[i].Id}<");
                    form.SetLog($"Network name >{baseData.Networks[i].Name}<");
                    form.SetLog($"camera count >{blinkNetwork.networks[i].cameras.Length}<");

                    for (var n = 0; n < blinkNetwork.networks[i].cameras.Length; n++)
                    {
                        form.SetLog(string.Empty);
                        form.SetLog($"camera #{n + 1:D2}");

                        baseData.Networks[i].Cameras.Add(new BaseData.Camera
                        {
                            Id = blinkNetwork.networks[i].cameras[n].id,
                            Name = blinkNetwork.networks[i].cameras[n].name,
                            Media = new BaseData.Media()
                        });

                        minData.CameraId = baseData.Networks[i].Cameras[n].Id;

                        form.SetLog($"camera id >{baseData.Networks[i].Cameras[n].Id}<");
                        form.SetLog($"camera name >{baseData.Networks[i].Cameras[n].Name}<");

                        var blinkCamera = uweR70_Get.CameraInfoAsync(minData).Result;

                        var cameraThumbnail = blinkCamera.camera_status.thumbnail;

                        var storagePath = GetStoragePath(saveDirectory, baseData.Networks[i].Name, blinkNetwork.networks[i].cameras[n].name);
                        if (string.IsNullOrEmpty(baseData.RootStoragePath))
                        {
                            baseData.RootStoragePath = Path.Combine(saveDirectory, $"{Config.StoragePart}\\{baseData.Networks[i].Name}");
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

                var timestampFormatter = CultureInfo.CurrentCulture.Name.ToUpperInvariant().Equals("DE-DE")
                                                            ? "yyyy.MM.dd__hh_mm_ss"
                                                            : "yyyy.MM.dd__HH_mm_ss_tt";
                var pageCounter = 0;
                form.SetLog(string.Empty);
                form.SetLog($"Try to download videos.");
                do
                {
                    pageCounter++;

                    var media = uweR70_Get.MediaAsync(baseData, pageCounter).Result;
                    if (media.media == null || media.media.Length == 0)
                    {
                        break;
                    }

                    form.SetLog(string.Empty);
                    form.SetLog($"Page #{pageCounter} contains {media.media.Length} videos.");

                    var counterMarkedAsDeleted = 0;
                    var counterAlreadyBeforeDownloaded = 0;
                    var counterDownloaded = 0;

                    form.SetLog($"\tMarked as deleted #{counterMarkedAsDeleted}.");
                    form.SetLog($"\tAlready before downloaded #{counterAlreadyBeforeDownloaded}.");
                    form.SetLog($"\tDownloaded #{counterDownloaded}.");

                    for (var i = 0; i < media.media.Length; i++)
                    {
                        if (media.media[i].deleted)
                        {
                            counterMarkedAsDeleted++;
                            AdjustInfo(form, common, $"\tMarked as deleted #{counterMarkedAsDeleted - 1}.", $"\tMarked as deleted #{counterMarkedAsDeleted}.");
                            continue;
                        }
                        
                        var networkObject = baseData.Networks.Where(x => x.Id == media.media[i].network_id).ToList();
                        if (networkObject == null || networkObject.Count() != 1)
                        {
                            // Should never be true!
                            continue;
                        }
                        var cameraObject = networkObject[0].Cameras.Where(x => x.Id == media.media[i].device_id).ToList();
                        if (cameraObject == null || cameraObject.Count() != 1)
                        {
                            // Should never be true!
                            continue;
                        }

                        var storagePath = GetStoragePath(saveDirectory, media.media[i].network_name, media.media[i].device_name);
                        var videoFileName = media.media[i].created_at.ToString(timestampFormatter) + ".mp4";
                        var videoPathAndFileName = $"{storagePath}\\{videoFileName}";
                        cameraObject[0].Media.PathAndFileNameVideos.Add(videoPathAndFileName);
                        if (!File.Exists(videoPathAndFileName))
                        {
                            var videoByteArray = uweR70_Get.VideoAsync(baseData, media.media[i].media).Result;
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
                } while (true);
                
                form.SetLog(string.Empty);
                form.SetLog("Done!");
                return baseData;
            }
            catch (Exception ex)
            {
                form.SetLog(string.Empty);
                form.SetLog($"### ERROR ###");
                var errorMessage = ex.Message;
                if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
                {
                    errorMessage = ex.InnerException.Message;
                }
                form.SetLog($"\t{errorMessage}");
                return null;
            }
        }

        private string GetStoragePath(string baseStoragePath, string networkName, string cameraName)
        {
            var storagePath = Path.Combine(baseStoragePath, $"{Config.StoragePart}\\{networkName}\\{cameraName}");
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
            form.SetLog(result, false);
        }
    }
}
