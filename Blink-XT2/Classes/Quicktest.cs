using Blink.Classes.Blink.Bodies;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blink.Classes
{
    public class Quicktest
    {
        /// <summary>
        /// Demo implementation to show which data the api calls are requiering and how the api calls are made.
        /// </summary>
        /// <param name="form">Reference to the 'form1' instance.</param>
        /// <param name="baseData">The data recieved while the login/authentification were made.</param>
        /// <returns></returns>
        public void Test(Form1 form, BaseData baseData)
        {
            var uweR70_Get = new UweR70_Get();
            var uweR70_GetData = new UweR70_GetData();
            var uweR70_PostCallWithEmptyBody = new UweR70_PostCallWithEmptyBody();
            var uweR70_PostCallWithNonEmptyBody = new UweR70_PostCallWithNonEmptyBody();

            var networkObject = baseData.Networks[0];
            /*
            var cameraList = baseData.Networks[0].Cameras.Where(x => x.Name.Equals("Garage", StringComparison.InvariantCultureIgnoreCase)).ToList();
            if (cameraList == null || cameraList.Count != 1)
            {
                throw new Exception("'Quicktest.cs', 'TestAsync(...)': Something went wrong!");
            }
            var cameraObject = cameraList[0];
            */
            var cameraObject = baseData.Networks[0].Cameras[1];

            var minData = new MinimumData
            {
                AuthToken = baseData.AuthToken,
                RegionTier = baseData.RegionTier,
                NetworkId = networkObject.Id,
                CameraId = cameraObject.Id
            };


            /*           
            var videoLiveViewBody = new VideoLiveViewBody
            {
                 id = minData.CameraId,
                 network = minData.NetworkId,
                 type = 4
            };
            try
            {
                var liveVideoResponse = new UweR70_PostCallWithNonEmptyBody().LiveView(minData, videoLiveViewBody).Result;

                // liveVideoResponse.server = "immis://18.196.123.157:443/jb2dzOlaeVLqLO5C__IMDS_811177681?client_id=146"
                // iMMis != iMis, but found olny this ...
                //http://help.imis.com/sdk/index.htm#!exampleusingc2.htm
 
                var dummy = 1;
            }
            catch (Exception ex)
            {
                var errorMessage = ex.Message;
                if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
                {
                    errorMessage = ex.InnerException.Message;
                }
                var xx = errorMessage;
            }
            */




            /*
            var network = uweR70_Get.BatteryUssageAsync(baseData).Result;
            var changedMedia = uweR70_Get.ChangedMediaAsync(baseData, 0).Result;
            var cameraStatus = uweR70_Get.CameraStatusAsync(minData).Result;
            var signalStrength = uweR70_Get.SignalStrengthAsync(minData).Result;
            var homescreenV3 = uweR70_Get.HomescreenV3Async(baseData).Result;
            var quickRegionInfo = uweR70_Get.QuickRegionInfoAsync(baseData).Result;
            var syncModules = uweR70_Get.SyncModulesAsync(minData).Result;
            var regions = uweR70_Get.GetRegionsAsync(baseData, "US").Result;

            var events = uweR70_Get.EventsAsync(minData).Result;
            var typeList = new[] { "first_boot", "battery", "armed", "disarmed", "scheduled_arm", "scheduled_disarm", "heartbeat", "sm_offline" };
            var blinkEvents = events._event;
            var count = blinkEvents.Length;
            for (int i = 0; i < typeList.Length; i++)
            {
                blinkEvents = blinkEvents.Where(x => !x.type.Equals(typeList[i], StringComparison.InvariantCultureIgnoreCase)).ToArray();
                count = blinkEvents.Length;
            }


            var thumbnailImage = uweR70_GetData.ThumbnailImageAsync(minData, "<enter valid data here>").Result;
            var video = uweR70_GetData.VideoAsync(baseData, "<enter valid data here>").Result;


            var commandArm = uweR70_PostCallWithEmptyBody.CommandArmDisarmAsync(minData, UweR70_PostCallWithEmptyBody.ArmDisarm.arm).Result;
            var commandDisarm = uweR70_PostCallWithEmptyBody.CommandArmDisarmAsync(minData, UweR70_PostCallWithEmptyBody.ArmDisarm.disarm).Result;
            var commandMotionDetectionEnable = uweR70_PostCallWithEmptyBody.CommandMotionDetectionAsync(minData, UweR70_PostCallWithEmptyBody.MotionDetection.enable).Result;
            var commandMotionDetectionDisable = uweR70_PostCallWithEmptyBody.CommandMotionDetectionAsync(minData, UweR70_PostCallWithEmptyBody.MotionDetection.disable).Result;
            var commandClip = uweR70_PostCallWithEmptyBody.CommandClipAsync(minData).Result;
            var commandThumbnail = uweR70_PostCallWithEmptyBody.CommandThumbnailAsync(minData).Result;

            var login = uweR70_PostCallWithNonEmptyBody.LoginAsync(baseData, new LoginBody
            {
                email = "<your blink email address>",
                password = "<your blink password>"
            }).Result;

            var mediaIdLIstBody = new MediaIdListBody
            {
                media_list = new List<long>(new long[] { 12345678, 23456789 })  // Example values
            };
            var test = uweR70_PostCallWithNonEmptyBody.DeleteMediaCall(baseData, mediaIdLIstBody);
            
            // The here called API calls are available since Blink apk version 6.2.6, release January, 14th 2021.
            // But it seems that they currently not working, on the BLINK side not fully implemented or they are related to another, newer camera generation.
            var syncmodules = uweR70_Get.SyncModulesAsync(minData).Result;
            var bulkDownloadClips = uweR70_PostCallWithEmptyBody.BulkDownloadClips(baseData, minData, syncmodules).Result;

            var clipListManifestCommandId = uweR70_PostCallWithEmptyBody.GetClipListManifestCommandId(baseData, minData, syncmodules).Result;
            var clipCommandId = uweR70_PostCallWithEmptyBody.GetClipCommandId(baseData, minData, syncmodules, clipListManifestCommandId, 4711).Result;

            var test_B = uweR70_Get.GetClipListManifest_B(baseData, minData, syncmodules, bulkDownloadClips).Result;
            var test = uweR70_Get.GetClipListManifest(baseData, minData, syncmodules, clipListManifestCommandId).Result;
            */
        }
    }
}
