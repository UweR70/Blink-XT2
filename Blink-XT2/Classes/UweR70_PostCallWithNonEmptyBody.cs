using Blink.Classes.Blink;
using Blink.Classes.Blink.Bodies;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Blink.Classes
{
    public class UweR70_PostCallWithNonEmptyBody
    {
        public async Task<LoginResponse> LoginAsync(BaseData baseData, LoginBody loginBody)
        {
            //  @POST("https://rest-{tier}.immedia-semi.com/api/v4/account/login")
            //  Observable<LoginResponse> login(@Body LoginBody paramLoginBody, @Path("tier") String paramString);
            //
            //  @POST("https://rest-{tier}.immedia-semi.com/api/v4/account/login")
            //  Call<LoginResponse> loginCall(@Body LoginBody paramLoginBody, @Path("tier") String paramString);
            var uri = $"https://rest-{baseData.LoginTier}.immedia-semi.com/api/v4/account/login";
            var retString = await FirePostCallAsync(uri, loginBody, null);
            var ret = JsonConvert.DeserializeObject<LoginResponse>(retString);
            return ret;
        }

        public async Task<Message> DeleteMediaCall(BaseData baseData, MediaIdListBody mediaIdListBody)
        {
            //  @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{accountId}/media/delete")
            //  Single<Object> deleteMedia(@Body MediaIdListBody paramMediaIdListBody, @Path("accountId") long paramLong, @Path("tier") String paramString);

            //  @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{accountId}/media/delete")
            //  Call<Object> deleteMediaCall(@Body MediaIdListBody paramMediaIdListBody, @Path("accountId") long paramLong, @Path("tier") String paramString);
            var uri = $"https://rest-{baseData.RegionTier}.immedia-semi.com/api/v1/accounts/{baseData.AccountId}/media/delete";
            var retString = await FirePostCallAsync(uri, mediaIdListBody, baseData.AuthToken);
            var ret = JsonConvert.DeserializeObject<Message>(retString);
            return ret;
        }

        public async Task<PinVerificationResponse> VerifyClientPIN(BaseData baseData, VerifyPinBody verifyPinBody)
        {
            //  @POST("https://rest-{tier}.immedia-semi.com/api/v4/account/{account}/client/{client}/pin/verify/")
            //  Observable<PinVerificationResponse> verifyClientPIN(@Path("tier") String paramString, @Path("account") long paramLong1, @Path("client") long paramLong2, @Body VerifyPinBody paramVerifyPinBody);
            var uri = $"https://rest-{baseData.RegionTier}.immedia-semi.com/api/v4/account/{baseData.AccountId}/client/{baseData.ClientId}/pin/verify";
            var retString = await FirePostCallAsync(uri, verifyPinBody, baseData.AuthToken);
            var ret = JsonConvert.DeserializeObject<PinVerificationResponse>(retString);
            return ret;

        }
        
        public async Task<LiveVideoResponse> LiveView(MinimumData minData, VideoLiveViewBody verifyPinBody)
        {
            //  @POST("https://rest-{tier}.immedia-semi.com/api/v3/networks/{network}/cameras/{camera}/liveview")
            //  Observable<LiveVideoResponse> liveView(@Body VideoLiveViewBody paramVideoLiveViewBody, @Path("tier") String paramString, @Path("network") long paramLong1, @Path("camera") long paramLong2);
            var uri = $"https://rest-{minData.RegionTier}.immedia-semi.com/api/v3/networks/{minData.NetworkId}/cameras/{minData.CameraId}/liveview";
            var retString = await FirePostCallAsync(uri, verifyPinBody, minData.AuthToken);
            var ret = JsonConvert.DeserializeObject<LiveVideoResponse>(retString);
            return ret;

        }







        public async Task<string> FirePostCallAsync(string uri, object body, string authToken)
        {
            using (var client = new HttpClient())
            {
                if (!string.IsNullOrEmpty(authToken))
                {
                    client.DefaultRequestHeaders.Add("TOKEN_AUTH", authToken);
                }

                var json = JsonConvert.SerializeObject(body);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = client.PostAsync(uri, content);
                response.Result.EnsureSuccessStatusCode();
                return await response.Result.Content.ReadAsStringAsync();
            }
        }
    }
}
