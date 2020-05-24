using System;
using System.IO;
using System.Linq;
using System.Timers;

namespace Blink.Classes
{
    public class Snapshot
    {
        private Form1 Form;
        private Common Common;

        private bool IsActive;

        private Timer IntervalTimer;
        public string BaseStoragePathSnapshot;
        private long SnapshotCounter;

        public void StartTakingSnapshots(Form1 form, BaseData baseData, int intervalInseconds, int networkId, int cameraId)
        {
            Form = form;
            Common = new Common();
            IsActive = false;

            BaseStoragePathSnapshot = string.Empty;
            SnapshotCounter = 0;

            Form.SetP2TxtBoxInfoText("Started!");
            Form.SetP2TxtBoxInfoText(string.Empty);

            TakeSnapshots(baseData, networkId, cameraId); // Call it once immediately

            Action action = () => Wrapper(form, baseData, networkId, cameraId);
            IntervalTimer = new Common().SetInterval(action, intervalInseconds * 1000);
            IntervalTimer.Start();
        }

        public void StopTakingSnapshots()
        {
            if (IntervalTimer != null)
            {
                IntervalTimer.Stop();
                IntervalTimer.Dispose();
            }
            if (Form != null)
            {
                Form.SetP2TxtBoxInfoText("Stopped.");
            }
        }

        private void Wrapper(Form1 form, BaseData baseData, int networkId, int cameraId)
        {
            if(IsActive)
            {
                return;
            }
            IsActive = true;

            const int maxErrorsBeforeLeaving = 5;
            const int WaitTimeInSeconds = 10;
            try
            {
                IntervalTimer.Stop();

                var errorCounter = 0;
                do
                {
                    try
                    {
                        TakeSnapshots(baseData, networkId, cameraId);
                        break;
                    }
                    catch (Exception ex)
                    {
                        var errorMessage = ex.Message;
                        if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
                        {
                            errorMessage = ex.InnerException.Message;
                        }
                        errorCounter++;
                        Form.SetP2TxtBoxInfoText($"Error #{errorCounter} of max {maxErrorsBeforeLeaving}:");
                        Form.SetP2TxtBoxInfoText(errorMessage);
                        Form.SetP2TxtBoxInfoText($"-> Going to wait now {WaitTimeInSeconds} seconds!");
                        System.Threading.Thread.Sleep(WaitTimeInSeconds * 1000);
                        if (errorCounter < maxErrorsBeforeLeaving)
                        {
                            Form.SetP2TxtBoxInfoText("Retrying!");
                        }
                        else
                        {
                            Form.SetP2TxtBoxInfoText("Too many errors! Abort making snapshots!");
                        }
                    }
                } while (errorCounter < maxErrorsBeforeLeaving);

                IntervalTimer.Start();
            }
            catch
            {
                // Fetching access try on already disposed "IntervalTimer".
            }

            IsActive = false;
        }

        public void TakeSnapshots(BaseData baseData, int networkId, int cameraId)
        {
            var uweR70_Get = new UweR70_Get();
            var uweR70_GetData = new UweR70_GetData();
            var uweR70_PostCallWithEmptyBody = new UweR70_PostCallWithEmptyBody();

            var minData = new MinimumData
            {
                AuthToken = baseData.AuthToken,
                RegionTier = baseData.RegionTier,
                NetworkId = networkId,
                CameraId = cameraId
            };

            #region Comment
            // It does NOT matter whether the camera is active (active := "disable" / "enable") nor whether it is armed or not (armed := true / false)!
            // Just fire ".ThumbnailAsync(..)" to take a thumbnail.
            // Firing this command does NOT change any of these two properties.
            //
            //var magicValueCameraName = "Garten";
            //var beforeHomescreen = uweR70_Get.HomescreenV3Async(baseData).Result;
            //// Eleminate first the sync modul, than search the correct device in the remaining items!
            //var beforeDataList = beforeHomescreen.cameras.Where(x => !string.IsNullOrEmpty(x.name)).Where(x => x.name.Equals(magicValueCameraName, StringComparison.InvariantCultureIgnoreCase)).ToList();
            //if (beforeDataList == null || beforeDataList.Count != 1)
            //{
            //    throw new Exception("'Snapshot.cs', 'TakeSnapshots(...)': Something went wrong!");
            //}
            //var beforeData = beforeDataList[0];
            #endregion

            // Take the snapshot
            var commandThumbnail_Test = uweR70_PostCallWithEmptyBody.CommandThumbnailAsync(minData).Result;
            
            var cameraStatus = uweR70_Get.CameraStatusAsync(minData).Result;

            var cameraThumbnail = cameraStatus.camera_status.thumbnail;
            if (string.IsNullOrEmpty(BaseStoragePathSnapshot))
            {
                BaseStoragePathSnapshot = GetStoragePath(baseData, networkId, cameraId);
                Form.SetP2TxtBoxInfoText("Base storage path:");
                Form.SetP2TxtBoxInfoText($"\t{BaseStoragePathSnapshot}");
                Form.SetP2TxtBoxInfoText(string.Empty);
            }

            var timestampFormatter = Common.GetTimestampFormatter();
            var timestamp = DateTime.Now.ToString(timestampFormatter);
            var cameraThumbnailFileName = $"{++SnapshotCounter:D6}_{timestamp}.jpg";
            Form.SetP2TxtBoxInfoText($"Snapshot #{SnapshotCounter:D6}");
            Form.SetP2TxtBoxInfoText($"\tFile name {cameraThumbnailFileName}");
            Form.SetP2TxtBoxInfoText(string.Empty);

            var cameraThumbnailPathAndFileName = $"{BaseStoragePathSnapshot}\\{cameraThumbnailFileName}";
            var cameraThumbnailByteArray = uweR70_GetData.ThumbnailImageAsync(minData, cameraThumbnail).Result;
            File.WriteAllBytes(cameraThumbnailPathAndFileName, cameraThumbnailByteArray);
        }

        public string GetStoragePath(BaseData baseData, int networkId, int cameraId)
        {
            var networkObject = baseData.Networks.Where(x => x.Id == networkId).ToList();
            if (networkObject == null || networkObject.Count() != 1)
            {
                throw new Exception($"Could not find network base on network id {networkId}.");
            }
             
            var cameraObject = networkObject[0].Cameras.Where(x => x.Id == cameraId).ToList();
            if (cameraObject == null || cameraObject.Count() != 1)
            {
                throw new Exception($"Could not find camera base on camera id {cameraId}.");
            }

            var timestampFormatter = Common.GetTimestampFormatter();
            var timestamp = DateTime.Now.ToString(timestampFormatter);

            var cameraNameAndId = Common.CombineNameAndId(cameraObject[0].Name, cameraObject[0].Id);
            var storagePath = Path.Combine(baseData.StoragePathNetwork, $"{Config.StoragePartSnapshotsMain}\\{Config.StoragePartSnapshotsImages}\\{cameraNameAndId}\\{timestamp}");
            if (!Directory.Exists(storagePath))
            {
                Directory.CreateDirectory(storagePath);
            }
            if (string.IsNullOrEmpty(baseData.StoragePathSnapshots))
            {
                baseData.StoragePathSnapshots = $"{baseData.StoragePathNetwork}\\{Config.StoragePartSnapshotsMain}";
                baseData.StoragePathSnapshotsImages = $"{baseData.StoragePathSnapshots}\\{Config.StoragePartSnapshotsImages}";
            }
            return storagePath;
        }
    }
}
