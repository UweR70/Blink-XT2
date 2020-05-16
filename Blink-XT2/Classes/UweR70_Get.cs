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

        public async Task<CameraStatus> CameraStatusAsync(MinimumData minData)
        {
            //  @GET("https://rest-{tier}.immedia-semi.com/network/{network}/camera/{camera}") 
            //  Observable<CameraStatus> cameraCommandStatus(@Path("tier") String paramString, @Path("network") long paramLong1, @Path("camera") long paramLong2);
            var uri = $"https://rest-{minData.RegionTier}.immedia-semi.com/network/{minData.NetworkId}/camera/{minData.CameraId}";
            var retString = await FireGetCallAsync(uri, minData.AuthToken);
            var ret = JsonConvert.DeserializeObject<CameraStatus>(retString);
            return ret;
        }

        public async Task<SignalStrength> SignalStrengthAsync(MinimumData minData)
        {
            //  @GET("https://rest-{tier}.immedia-semi.com/network/{network}/camera/{camera}/signals")
            //  Observable<SignalStrength> loadCameraStatus(@Path("tier") String paramString, @Path("network") long paramLong1, @Path("camera") long paramLong2);
            var uri = $"https://rest-{minData.RegionTier}.immedia-semi.com/network/{minData.NetworkId}/camera/{minData.CameraId}/signals";
            var retString = await FireGetCallAsync(uri, minData.AuthToken);
            var ret = JsonConvert.DeserializeObject<SignalStrength>(retString);
            return ret;
        }

        public async Task<BlinkEvents> EventsAsync(MinimumData minData)
        {
            // ToDo: API NOT FOUND! ######################################################################################################################
            var uri = $"https://rest-{minData.RegionTier}.immedia-semi.com/events/network/{minData.NetworkId}";
            var retString = await FireGetCallAsync(uri, minData.AuthToken);
            // Special case!
            // The from the api call returned property name "event" is in C# protected.
            // That is why the "Edit" -> "Paste Special" -> "Paste JSON as Classes" prefixes the property "event" with a "_".
            // Solution / workaround as follows:
            retString = retString.Replace("event", "_event");
            var ret = JsonConvert.DeserializeObject<BlinkEvents>(retString);
            return ret;
        }

        public async Task<HomescreenV3> HomescreenV3Async(BaseData baseData)
        {
            //  @GET("https://rest-{tier}.immedia-semi.com/api/v3/accounts/{account}/homescreen")
            //  Observable<HomescreenV3> homescreenV3(@Path("tier") String paramString, @Path("account") long paramLong);
            var uri = $"https://rest-{baseData.RegionTier}.immedia-semi.com/api/v3/accounts/{baseData.AccountId}/homescreen";
            var retString = await FireGetCallAsync(uri, baseData.AuthToken);
            var ret = JsonConvert.DeserializeObject<HomescreenV3>(retString);
            return ret;
        }

        public async Task<LoginResponse> LoginAsync(BaseData baseData, LoginBody loginBody)
        {
            //  @POST("https://rest-{tier}.immedia-semi.com/api/v4/account/login")
            //   Observable<LoginResponse> login(@Body LoginBody paramLoginBody, @Path("tier") String paramString);
            //
            //  @POST("https://rest-{tier}.immedia-semi.com/api/v4/account/login")
            //  Call<LoginResponse> loginCall(@Body LoginBody paramLoginBody, @Path("tier") String paramString);
            var uri = $"https://rest-{baseData.LoginTier}.immedia-semi.com/api/v4/account/login";
            var retString = await FirePostCallAsync(uri, loginBody);
            var ret = JsonConvert.DeserializeObject<LoginResponse>(retString);
            return ret;
        }

        public async Task<QuickRegionInfo> QuickRegionInfoAsync(BaseData baseData)
        {
            // @GET("https://rest-{tier}.immedia-semi.com/regions")
            // Observable<QuickRegionInfo> getRegions(@Path("tier") String paramString1, @Query("locale") String paramString2);
            var uri = $"https://rest-{baseData.RegionTier}.immedia-semi.com/regions";
            var retString = await FireGetCallAsync(uri, baseData.AuthToken);
            var ret = JsonConvert.DeserializeObject<QuickRegionInfo>(retString);
            return ret;
        }

        public async Task<BlinkSyncModules> SyncModulesAsync(MinimumData minData)
        {
            // ToDo: API NOT FOUND! ######################################################################################################################
            var uri = $"https://rest-{minData.RegionTier}.immedia-semi.com/network/{minData.NetworkId}/syncmodules";
            var retString = await FireGetCallAsync(uri, minData.AuthToken);
            var ret = JsonConvert.DeserializeObject<BlinkSyncModules>(retString);
            return ret;
        }
        
        public async Task<BatteryUsage> BatteryUssageAsync(BaseData baseData)
        {
            //  @GET("https://rest-{tier}.immedia-semi.com/api/v1/camera/usage")
            //  Observable<BatteryUsage> batteryUsage(@Path("tier") String paramString);
            var uri = $"https://rest-{baseData.RegionTier}.immedia-semi.com/api/v1/camera/usage";
            var retString = await FireGetCallAsync(uri, baseData.AuthToken);
            var ret = JsonConvert.DeserializeObject<BatteryUsage>(retString);
            return ret;
        }

        public async Task<ChangedMedia> ChangedMediaAsync(BaseData baseData, int pageNumber)
        {
            //  @GET("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{accountId}/media/changed")
            //  Call<ChangedMedia> getChangedMedia(@Path("tier") String paramString, @Path("accountId") long paramLong, @Query("since") OffsetDateTime paramOffsetDateTime, @Query("page") int paramInt);
            var uri = $"https://rest-{baseData.RegionTier}.immedia-semi.com/api/v1/accounts/{baseData.AccountId}/media/changed?since=2015-04-19T23:11:20+0000&page={pageNumber}";
            var retString = await FireGetCallAsync(uri, baseData.AuthToken);
            var ret = JsonConvert.DeserializeObject<ChangedMedia>(retString);
            return ret;
        }



        public async Task<byte[]> ThumbnailImageAsync(MinimumData minData, string thumbnailPart)
        {
            var uri = $"https://rest-{minData.RegionTier}.immedia-semi.com/{thumbnailPart}.jpg";
            var ret = await FireGetBytesCallAsync(uri, minData.AuthToken);
            return ret;
        }

        public async Task<byte[]> VideoAsync(BaseData baseData, string mediaPart)
        {
            var uri = $"https://rest-{baseData.RegionTier}.immedia-semi.com/{mediaPart}";
            var ret = await FireGetBytesCallAsync(uri, baseData.AuthToken);
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

        public async Task<string> FireGetCallAsync(string url, string authToken)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("TOKEN_AUTH", authToken);

                var response = client.GetAsync(url);
                response.Result.EnsureSuccessStatusCode();      // When, then this command raises the error.
                return await response.Result.Content.ReadAsStringAsync();
            }
        }

        public async Task<byte[]> FireGetBytesCallAsync(string url, string authToken)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("TOKEN_AUTH", authToken);

                var response = client.GetAsync(url);
                response.Result.EnsureSuccessStatusCode();
                return await response.Result.Content.ReadAsByteArrayAsync();
            }
        }
    }
}
