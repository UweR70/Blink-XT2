using Blink.Classes.Blink;
using Classes.Blink;
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

        public async Task<BlinkData> LogoutAsync(BaseData baseData)
        {
            if (baseData == null || baseData.AccountId == 0)
            {
                return null;
            }
            //  @POST("https://rest-{tier}.immedia-semi.com/api/v4/account/{accountId}/client/{clientId}/logout/")
            //  Observable<BlinkData> logout(@Path("tier") String paramString, @Path("accountId") Long paramLong1, @Path("clientId") Long paramLong2);
            var uri = $"https://rest-{baseData.RegionTier}.immedia-semi.com/api/v4/account/{baseData.AccountId}/client/{baseData.ClientId}/logout/";
            var retString = await FirePostCallWithEmptyBodyAsync(uri, baseData.AuthToken);
            var ret = JsonConvert.DeserializeObject<BlinkData>(retString);
            return ret;
        }

        public async Task<CommandClipListManifestId> GetClipListManifestCommandId(BaseData baseData, MinimumData minData, BlinkSyncModules syncModules)
        {
            //  @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account_id}/networks/{network}/sync_modules/{sync_module_id}/local_storage/manifest/request")
            //  Single<Command> getClipListManifestCommandId(@Path("tier") String paramString, @Path("account_id") long paramLong1, @Path("network") long paramLong2, @Path("sync_module_id") long paramLong3);
            var uri = $"https://rest-{baseData.RegionTier}.immedia-semi.com/api/v1/accounts/{baseData.AccountId}/networks/{minData.NetworkId}/sync_modules/{syncModules.syncmodule.id}/local_storage/manifest/request";
            //          https://rest-{tier}               .immedia-semi.com/api/v1/accounts/{account_id}        /networks/{network}          /sync_modules/{sync_module_id}           /local_storage/manifest/request
            var retString = await FirePostCallWithEmptyBodyAsync(uri, baseData.AuthToken);
            var ret = JsonConvert.DeserializeObject<CommandClipListManifestId>(retString);
            return ret;
        }

        public async Task<CommandClipId> GetClipCommandId(BaseData baseData, MinimumData minData, BlinkSyncModules syncModules, CommandClipListManifestId commandClipListManifestId, long clipId)
        {
            //  @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account_id}/networks/{network}/sync_modules/{sync_module_id}/local_storage/manifest/{manifest_id}/clip/request/{clip_id}")
            //  Single<Command> getClipCommandId(@Path("tier") String paramString, @Path("account_id") long paramLong1, @Path("network") long paramLong2, @Path("sync_module_id") long paramLong3, @Path("clip_id") long paramLong4, @Path("manifest_id") long paramLong5);
            var uri = $"https://rest-{baseData.RegionTier}.immedia-semi.com/api/v1/accounts/{baseData.AccountId}/networks/{minData.NetworkId}/sync_modules/{syncModules.syncmodule.id}/local_storage/manifest/{commandClipListManifestId.id}/clip/request/{clipId}";
            var retString = await FirePostCallWithEmptyBodyAsync(uri, baseData.AuthToken);
            var ret = JsonConvert.DeserializeObject<CommandClipId>(retString);
            return ret;
        }

        public async Task<BulkDownloadClips> BulkDownloadClips(BaseData baseData, MinimumData minData, BlinkSyncModules syncModules)
        {
            //  @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account_id}/networks/{network}/sync_modules/{sync_module_id}/local_storage/bulk_download")
            //  Single<Command> bulkDownloadClips(@Path("tier") String paramString, @Path("account_id") long paramLong1, @Path("network") long paramLong2, @Path("sync_module_id") long paramLong3);
            var uri = $"https://rest-{baseData.RegionTier}.immedia-semi.com/api/v1/accounts/{baseData.AccountId}/networks/{minData.NetworkId}/sync_modules/{syncModules.syncmodule.id}/local_storage/bulk_download";
            //          https://rest-{tier}               .immedia-semi.com/api/v1/accounts/{account_id        }/networks/{network}          /sync_modules/{sync_module_id}           /local_storage/bulk_download
            var retString = await FirePostCallWithEmptyBodyAsync(uri, baseData.AuthToken);
            var ret = JsonConvert.DeserializeObject<BulkDownloadClips>(retString);
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
