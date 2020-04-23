using System;
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
            var uweR70_FireCommand = new UweR70_FireCommand();
            var uweR70_Get = new UweR70_Get();

            var networkObject = baseData.Networks[0];
            /*
            var cameraList = baseData.Networks[0].Cameras.Where(x => x.Name.Equals("Garage", StringComparison.InvariantCultureIgnoreCase)).ToList();
            if (cameraList == null || cameraList.Count != 1)
            {
                throw new Exception("'Quicktest.cs', 'TestAsync(...)': Something went wrong!");
            }
            var cameraObject = cameraList[0];
            */
            var cameraObject = baseData.Networks[0].Cameras[0];

            var minData = new MinimumData
            {
                ApiServer = baseData.ApiServer,
                AuthToken = baseData.AuthToken,
                RegionPropertyName = baseData.RegionPropertyName,
                NetworkId = networkObject.Id,
                CameraId = cameraObject.Id
            };

            /*
            var commandArm = uweR70_FireCommand.ArmAsync(minData).Result;
            var commandDisarm = uweR70_FireCommand.DisarmAsync(minData).Result;
            
            var commandMotionDetectionDisable = uweR70_FireCommand.MotionDetectionAsync(minData, UweR70_FireCommand.BlinkMotionDetection.disable).Result;
            var commandMotionDetectionEnable = uweR70_FireCommand.MotionDetectionAsync(minData, UweR70_FireCommand.BlinkMotionDetection.enable).Result;

            var commandClip = uweR70_FireCommand.ClipAsync(minData).Result;
            var commandThumbnail = uweR70_FireCommand.ThumbnailAsync(minData).Result;

            // var commandLv_relay = uweR70_FireCommand.Lv_relayAsync(minData).Result;


            var login = uweR70_Get.LoginAsync(baseData, new UweR70_Get.LoginBody
            {
                email = "<your blink email address>",
                password = "<your blink password>"
            }).Result;

            var network = uweR70_Get.NetworkAsync(baseData).Result;
            var thumbnailImage = uweR70_Get.ThumbnailImageAsync(minData, "<enter valid data here>").Result;
            var video = uweR70_Get.VideoAsync(baseData, "<enter valid data here>").Result;
            var media = uweR70_Get.MediaAsync(baseData, 0).Result;
            
            var cameraInfo = uweR70_Get.CameraInfoAsync(minData).Result;
            var cameraSignals = uweR70_Get.CameraSignalsAsync(minData).Result;

            var events = uweR70_Get.EventsAsync(minData).Result;
            var typeList = new[] { "first_boot", "battery", "armed", "disarmed", "scheduled_arm", "scheduled_disarm", "heartbeat" };
            var blinkEvents = events._event;
            var count = blinkEvents.Length;
            for (int i = 0; i < typeList.Length; i++)
            {
                blinkEvents = blinkEvents.Where(x => !x.type.Equals(typeList[i], StringComparison.InvariantCultureIgnoreCase)).ToArray();
                count = blinkEvents.Length;
            }

            var homescreen = uweR70_Get.HomeScreenAsync(minData).Result;
            var regions = uweR70_Get.RegionsAsync(baseData).Result;
            var syncModules = uweR70_Get.SyncModulesAsync(minData).Result;
            */
        }
    }
}
