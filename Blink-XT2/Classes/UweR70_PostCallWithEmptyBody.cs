using Blink.Classes.Blink;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Blink.Classes
{
    public class UweR70_PostCallWithEmptyBody
    {
        public enum MotionDetection
        {
            enable = 0,     // Do NOT change it to uppercase letter!
            disable
        }

        public enum ArmDisarm
        {
            arm = 0,        // Do NOT change it to uppercase letter!
            disarm
        }

        public async Task<CommandArmDisarm> CommandArmDisarmAsync(MinimumData minData, ArmDisarm armDisarm)
        {
            // @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{accountId}/networks/{networkId}/state/{type}")
            // Observable<Command> armDisarmNetwork(@Path("tier") String paramString1, @Path("accountId") long paramLong1, @Path("networkId") long paramLong2, @Path("type") String paramString2);
            var uri = $"https://rest-{minData.RegionTier}.immedia-semi.com/network/{minData.NetworkId}/{armDisarm}";
            var retString = await FirePostCallWithEmptyBodyAsync(uri, minData.AuthToken);
            var ret = JsonConvert.DeserializeObject<CommandArmDisarm>(retString);
            return ret;
        }

        public async Task<CommandMotionDetection> CommandMotionDetectionAsync(MinimumData minData, MotionDetection blinkMotionDetection)
        {
            var uri = $"https://rest-{minData.RegionTier}.immedia-semi.com/network/{minData.NetworkId}/camera/{minData.CameraId}/{blinkMotionDetection}";
            var retString = await FirePostCallWithEmptyBodyAsync(uri, minData.AuthToken);
            var ret = JsonConvert.DeserializeObject<CommandMotionDetection>(retString);
            return ret;
        }

        /* "CommandClip.cs" and "CommandThumbnail.cs" are only different in "target" and "target_id".
         * The two classes can not be merged due "null can not be mapped to a specific type" error. 
         * -> In my opinion is returning "null" for both "CommandClip" properties a design error made by Blink!
        */
        public async Task<CommandClip> CommandClipAsync(MinimumData minData)
        {
            var uri = $"https://rest-{minData.RegionTier}.immedia-semi.com/network/{minData.NetworkId}/camera/{minData.CameraId}/clip";
            var retString = await FirePostCallWithEmptyBodyAsync(uri, minData.AuthToken);
            var ret = JsonConvert.DeserializeObject<CommandClip>(retString);
            return ret;
        }

        public async Task<CommandThumbnail> CommandThumbnailAsync(MinimumData minData)
        {
            //  @POST("https://rest-{tier}.immedia-semi.com/network/{network}/camera/{camera}/thumbnail")
            //  Observable<Command> takeThumbnail(@Path("tier") String paramString, @Path("network") long paramLong1, @Path("camera") long paramLong2);
            var uri = $"https://rest-{minData.RegionTier}.immedia-semi.com/network/{minData.NetworkId}/camera/{minData.CameraId}/thumbnail";
            var retString = await FirePostCallWithEmptyBodyAsync(uri, minData.AuthToken);
            var ret = JsonConvert.DeserializeObject<CommandThumbnail>(retString);
            return ret;
        }



        public async Task<string> FirePostCallWithEmptyBodyAsync(string uri, string authToken)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("TOKEN_AUTH", authToken);

                var response = client.PostAsync(uri, null);
                response.Result.EnsureSuccessStatusCode();      // When, then this command raises the error.
                return await response.Result.Content.ReadAsStringAsync();
            }
        }
    }
}
