using Blink.Classes.Blink;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Blink.Classes
{
    public class UweR70_FireCommand
    {
        public enum BlinkMotionDetection
        {
            enable = 0,
            disable
        }

        public async Task<BlinkCommandArm> ArmAsync(MinimumData minData)
        {
            var uri = $"https://rest-{minData.RegionPropertyName}.immedia-semi.com/network/{minData.NetworkId}/arm";
            var retString = await FirePostCallWithEmptyBodyAsync(uri, minData);
            var ret = JsonConvert.DeserializeObject<BlinkCommandArm>(retString);
            return ret;
        }

        public async Task<BlinkCommandDisarm> DisarmAsync(MinimumData minData)
        {
            var uri = $"https://rest-{minData.RegionPropertyName}.immedia-semi.com/network/{minData.NetworkId}/disarm";
            var retString = await FirePostCallWithEmptyBodyAsync(uri, minData);
            var ret = JsonConvert.DeserializeObject<BlinkCommandDisarm>(retString);
            return ret;
        }

        public async Task<BlinkCommandMotionDetection> MotionDetectionAsync(MinimumData minData, BlinkMotionDetection blinkMotionDetection)
        {
            var uri = $"https://rest-{minData.RegionPropertyName}.immedia-semi.com/network/{minData.NetworkId}/camera/{minData.CameraId}/{blinkMotionDetection}";
            var retString = await FirePostCallWithEmptyBodyAsync(uri, minData);
            var ret = JsonConvert.DeserializeObject<BlinkCommandMotionDetection>(retString);
            return ret;
        }

        public async Task<BlinkCommandClip> ClipAsync(MinimumData minData)
        {
            var uri = $"https://rest-{minData.RegionPropertyName}.immedia-semi.com/network/{minData.NetworkId}/camera/{minData.CameraId}/clip";
            var retString = await FirePostCallWithEmptyBodyAsync(uri, minData);
            var ret = JsonConvert.DeserializeObject<BlinkCommandClip>(retString);
            return ret;
        }

        public async Task<BlinkCommandThumbnail> ThumbnailAsync(MinimumData minData)
        {
            var uri = $"https://rest-{minData.RegionPropertyName}.immedia-semi.com/network/{minData.NetworkId}/camera/{minData.CameraId}/thumbnail";
            var retString = await FirePostCallWithEmptyBodyAsync(uri, minData);
            var ret = JsonConvert.DeserializeObject<BlinkCommandThumbnail>(retString);
            return ret;
        }

        public async Task<string> FirePostCallWithEmptyBodyAsync(string uri, MinimumData minData)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Host", minData.ApiServer);
                client.DefaultRequestHeaders.Add("TOKEN_AUTH", minData.AuthToken);

                var response = client.PostAsync(uri, null);
                response.Result.EnsureSuccessStatusCode();      // When, then this command raises the error.
                return await response.Result.Content.ReadAsStringAsync();
            }
        }
    }
}
