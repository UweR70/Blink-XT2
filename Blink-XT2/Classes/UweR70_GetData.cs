using System.Net.Http;
using System.Threading.Tasks;

namespace Blink.Classes
{
    public class UweR70_GetData
    {
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
