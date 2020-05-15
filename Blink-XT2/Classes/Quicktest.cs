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
            var uweR70_Command = new UweR70_Command();
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
            var cameraObject = baseData.Networks[0].Cameras[1];

            var minData = new MinimumData
            {
                AuthToken = baseData.AuthToken,
                RegionTier = baseData.RegionTier,
                NetworkId = networkObject.Id,
                CameraId = cameraObject.Id
            };

            
            var commandArm = uweR70_Command.CommandArmDisarmAsync(minData, UweR70_Command.ArmDisarm.arm).Result;
            var commandDisarm = uweR70_Command.CommandArmDisarmAsync(minData, UweR70_Command.ArmDisarm.disarm).Result;

            var commandMotionDetectionEnable = uweR70_Command.CommandMotionDetectionAsync(minData, UweR70_Command.MotionDetection.enable).Result;
            var commandMotionDetectionDisable = uweR70_Command.CommandMotionDetectionAsync(minData, UweR70_Command.MotionDetection.disable).Result;
            
            var commandClip = uweR70_Command.CommandClipAsync(minData).Result;
            var commandThumbnail = uweR70_Command.CommandThumbnailAsync(minData).Result;


            var login = uweR70_Get.LoginAsync(baseData, new UweR70_Get.LoginBody
            {
                email = "<your blink email address>",
                password = "<your blink password>"
            }).Result;

            var network = uweR70_Get.BatteryUssageAsync(baseData).Result;
            var thumbnailImage = uweR70_Get.ThumbnailImageAsync(minData, "<enter valid data here>").Result;
            var video = uweR70_Get.VideoAsync(baseData, "<enter valid data here>").Result;
            var changedMedia = uweR70_Get.ChangedMediaAsync(baseData, 0).Result;
            
            var cameraStatus = uweR70_Get.CameraStatusAsync(minData).Result;
            var signalStrength = uweR70_Get.SignalStrengthAsync(minData).Result;

            var events = uweR70_Get.EventsAsync(minData).Result;
            var typeList = new[] { "first_boot", "battery", "armed", "disarmed", "scheduled_arm", "scheduled_disarm", "heartbeat", "sm_offline" };
            var blinkEvents = events._event;
            var count = blinkEvents.Length;
            for (int i = 0; i < typeList.Length; i++)
            {
                blinkEvents = blinkEvents.Where(x => !x.type.Equals(typeList[i], StringComparison.InvariantCultureIgnoreCase)).ToArray();
                count = blinkEvents.Length;
            }

            var homescreenV3 = uweR70_Get.HomescreenV3Async(baseData).Result;
            var quickRegionInfo = uweR70_Get.QuickRegionInfoAsync(baseData).Result;
            var syncModules = uweR70_Get.SyncModulesAsync(minData).Result;
            
        }
    }
}
