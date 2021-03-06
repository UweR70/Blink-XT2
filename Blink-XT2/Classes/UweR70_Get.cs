﻿using Blink.Classes.Blink;
using Classes.Blink;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Blink.Classes
{
    public class UweR70_Get
    {
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
            // #################################################################################################################  ######################################################
            // #####     This API call is not part of the "BlinkWebServiceClass.cs" taken from the original Blink apk!     #####  ######################################################
            // #####     But luckily I found it.                                                                           #####  ######################################################
            // #####     Because in the meanwhile is the returned (sync-module) ID very important!                         #####  ######################################################
            // #################################################################################################################  ######################################################
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

        public async Task<GetRegions> GetRegionsAsync(BaseData baseData, string locale)
        {
            /* The original URI implies to use the attribute "locale" which is implemented as shown below.
             * On the other hand, it looks like that it does not matter whether its added or which attribute value is finally used.
             * Means also these URIs are working fine:
             *      https://rest-e001.immedia-semi.com/regions?local=Cheesecake
             *      https://rest-e001.immedia-semi.com/regions
             */
            // @GET("https://rest-{tier}.immedia-semi.com/regions")
            // Observable getRegions(@Path("tier") String paramString1, @Query("locale") String paramString2);
            var uri = $"https://rest-{baseData.RegionTier}.immedia-semi.com/regions?local={locale}";
            var retString = await FireGetCallAsync(uri, baseData.AuthToken);
            var ret = JsonConvert.DeserializeObject<GetRegions>(retString);
            return ret;
        }

        public async Task<Message> GetClipListManifest(BaseData baseData, MinimumData minData, BlinkSyncModules syncModules, CommandClipListManifestId commandClipListManifestId)
        {
            // @GET("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account_id}/networks/{network}/sync_modules/{sync_module_id}/local_storage/manifest/request/{command}")
            // Single<ClipsResponse> getClipListManifest(@Path("tier") String paramString, @Path("account_id") long paramLong1, @Path("network") long paramLong2, @Path("sync_module_id") long paramLong3, @Path("command") long paramLong4);
            var uri = $"https://rest-{baseData.RegionTier}.immedia-semi.com/api/v1/accounts/{baseData.AccountId}/networks/{minData.NetworkId}/sync_modules/{syncModules.syncmodule.id}/local_storage/manifest/request/{commandClipListManifestId.id}";
            //          https://rest-{tier}               .immedia-semi.com/api/v1/accounts/{account_id}        /networks/{network}          /sync_modules/{sync_module_id}           /local_storage/manifest/request/{command}
            var retString = await FireGetCallAsync(uri, baseData.AuthToken);
            var ret = JsonConvert.DeserializeObject<Message>(retString);
            return ret;
            // ###########  ATTENTION!    Currently is the WRONG CLASS (= "Message") used due the fact that the uri is wrong and so the returned json string is type of error = "message"!   ##########################
        }

        public async Task<Message> GetClipListManifest_B(BaseData baseData, MinimumData minData, BlinkSyncModules syncModules, BulkDownloadClips bulkDownloadClips)
        {
            // @GET("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account_id}/networks/{network}/sync_modules/{sync_module_id}/local_storage/manifest/request/{command}")
            // Single<ClipsResponse> getClipListManifest(@Path("tier") String paramString, @Path("account_id") long paramLong1, @Path("network") long paramLong2, @Path("sync_module_id") long paramLong3, @Path("command") long paramLong4);
            var uri = $"https://rest-{baseData.RegionTier}.immedia-semi.com/api/v1/accounts/{baseData.AccountId}/networks/{minData.NetworkId}/sync_modules/{syncModules.syncmodule.id}/local_storage/manifest/request/{bulkDownloadClips.id}";
            //          https://rest-{tier}               .immedia-semi.com/api/v1/accounts/{account_id}        /networks/{network}          /sync_modules/{sync_module_id}           /local_storage/manifest/request/{command}
            var retString = await FireGetCallAsync(uri, baseData.AuthToken);
            var ret = JsonConvert.DeserializeObject<Message>(retString);
            return ret;
            // ###########  ATTENTION!    Currently is the WRONG CLASS (= "Message") used due the fact that the uri is wrong and so the returned json string is type of error = "message"!   ##########################
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
    }
}
