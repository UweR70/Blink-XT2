//  #####################################################################
//  #####################################################################
//  #####                                                           #####
//  #####   URIs are taken form here                                #####
//  #####       Matt Weinecke                                       #####
//  #####       MattTW                                              #####
//  #####       https://github.com/MattTW                           #####
//  #####                                                           #####
//  #####       Blink Monitor Protocol                              #####
//  #####       https://github.com/MattTW/BlinkMonitorProtocol      #####
//  #####                                                           #####
//  #####   but adjusted by                                         #####
//  #####       UweR70                                              #####
//  #####       https://github.com/UweR70                           #####
//  #####                                                           #####
//  #####################################################################
//  #####################################################################

using Blink.Classes.Blink;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Blink.Classes
{
    public class UweR70_Get
    {
        public class LoginBody
        {
            public string email;
            public string password;
        }

        public async Task<BlinkCamera> CameraInfoAsync(MinimumData minData)
        {
            var uri = $"https://rest.{minData.RegionPropertyName}.immedia-semi.com/network/{minData.NetworkId}/camera/{minData.CameraId}";
            var retString = await FireGetCallAsync(uri, minData.AuthToken, minData.ApiServer);
            var ret = JsonConvert.DeserializeObject<BlinkCamera>(retString);
            return ret;
        }

        public async Task<BlinkCameraSignals> CameraSignalsAsync(MinimumData minData)
        {
            var uri = $"https://rest.{minData.RegionPropertyName}.immedia-semi.com/network/{minData.NetworkId}/camera/{minData.CameraId}/signals";
            var retString = await FireGetCallAsync(uri, minData.AuthToken, minData.ApiServer);
            var ret = JsonConvert.DeserializeObject<BlinkCameraSignals>(retString);
            return ret;
        }

        public async Task<BlinkEvents> EventsAsync(MinimumData minData)
        {
            var uri = $"https://rest.{minData.RegionPropertyName}.immedia-semi.com/events/network/{minData.NetworkId}";
            var retString = await FireGetCallAsync(uri, minData.AuthToken, minData.ApiServer);
            // Special case!
            // The from the api call returned property name "event" is in C# protected.
            // That is why the "Edit" -> "Paste Special" -> "Paste JSON as Classes" prefixes the property "event" with a "_".
            // Solution / workaround as follows:
            retString = retString.Replace("event", "_event");
            var ret = JsonConvert.DeserializeObject<BlinkEvents>(retString);
            return ret;
        }

        public async Task<BlinkHomescreen> HomeScreenAsync(MinimumData minData)
        {
            var uri = $"https://rest.{minData.RegionPropertyName}.immedia-semi.com/homescreen";
            var retString = await FireGetCallAsync(uri, minData.AuthToken, minData.ApiServer);
            var ret = JsonConvert.DeserializeObject<BlinkHomescreen>(retString);
            return ret;
        }
        public async Task<BlinkLogin> LoginAsync(BaseData baseData, LoginBody loginBody)
        {
            var uri = $"https://rest-{baseData.ApiServer}/api/v4/account/login";
            var retString = await FirePostCallAsync(uri, loginBody);
            var ret = JsonConvert.DeserializeObject<BlinkLogin>(retString);
            return ret;
        }
        public async Task<BlinkRegions> RegionsAsync(BaseData baseData)
        {
            var uri = $"https://rest.{baseData.RegionPropertyName}.immedia-semi.com/regions";
            var retString = await FireGetCallAsync(uri, baseData.AuthToken, baseData.ApiServer);
            var ret = JsonConvert.DeserializeObject<BlinkRegions>(retString);
            return ret;
        }

        public async Task<BlinkSyncModules> SyncModulesAsync(MinimumData minData)
        {
            var uri = $"https://rest.{minData.RegionPropertyName}.immedia-semi.com/network/{minData.NetworkId}/syncmodules";
            var retString = await FireGetCallAsync(uri, minData.AuthToken, minData.ApiServer);
            var ret = JsonConvert.DeserializeObject<BlinkSyncModules>(retString);
            return ret;
        }
        
        public async Task<BlinkNetwork> NetworkAsync(BaseData baseData)
        {
            var uri = $"https://rest.{baseData.RegionPropertyName}.immedia-semi.com/api/v1/camera/usage";
            var retString = await FireGetCallAsync(uri, baseData.AuthToken, baseData.ApiServer);
            var ret = JsonConvert.DeserializeObject<BlinkNetwork>(retString);
            return ret;
        }

        public async Task<byte[]> ThumbnailImageAsync(MinimumData minData, string thumbnailPart)
        {
            var uri = $"https://rest.{minData.RegionPropertyName}.immedia-semi.com/{thumbnailPart}.jpg";
            var ret = await FireGetBytesCallAsync(uri, minData.AuthToken, minData.ApiServer);
            return ret;
        }

        public async Task<byte[]> VideoAsync(BaseData baseData, string mediaPart)
        {
            var uri = $"https://rest.{baseData.RegionPropertyName}.immedia-semi.com/{mediaPart}";
            var ret = await FireGetBytesCallAsync(uri, baseData.AuthToken, baseData.ApiServer);
            return ret;
        }

        public async Task<BlinkMedia> MediaAsync(BaseData baseData, int pageNumber)
        {
            var uri = $"https://rest.{baseData.RegionPropertyName}.immedia-semi.com/api/v1/accounts/{baseData.AccountId}/media/changed?since=2015-04-19T23:11:20+0000&page={pageNumber}";
            var retString = await FireGetCallAsync(uri, baseData.AuthToken, baseData.ApiServer);
            var ret = JsonConvert.DeserializeObject<BlinkMedia>(retString);
            return ret;
        }
        
        public async Task<string> FirePostCallAsync(string uri, LoginBody body)
        {
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(body);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = client.PostAsync(uri, content);
                response.Result.EnsureSuccessStatusCode();
                return await response.Result.Content.ReadAsStringAsync();
            }
        }

        public async Task<string> FireGetCallAsync(string url, string authToken, string blinkApiServer)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Host", blinkApiServer);
                client.DefaultRequestHeaders.Add("TOKEN_AUTH", authToken);

                var response = client.GetAsync(url);
                response.Result.EnsureSuccessStatusCode();      // When, then this command raises the error.
                return await response.Result.Content.ReadAsStringAsync();
            }
        }

        public async Task<byte[]> FireGetBytesCallAsync(string url, string authToken, string blinkApiServer)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Host", blinkApiServer);
                client.DefaultRequestHeaders.Add("TOKEN_AUTH", authToken);

                var response = client.GetAsync(url);
                response.Result.EnsureSuccessStatusCode();
                return await response.Result.Content.ReadAsByteArrayAsync();
            }
        }
    }
}
