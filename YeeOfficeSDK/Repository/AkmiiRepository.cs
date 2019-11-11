using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YeeOfficeSDK.Interfaces;
using YeeOfficeSDK.Models;
using YeeOfficeSDK.Tools;
using System.IO;

namespace YeeOfficeSDK.Repository
{
    public partial class AkmiiRepository : IAkmiiRepository
    {
        internal static readonly LogHelper log = LogHelper.GetLogger(typeof(AkmiiRepository));
        private AkmiiContext _context;
        internal AkmiiRepository(AkmiiContext akmiiContext)
        {
            _context = akmiiContext;
        }

        public Dictionary<string, string> GetHeaders()
        {
            var headers = new Dictionary<string, string>
            {
                [AkmiiConstants.AkmiiSecret] = _context.AkmiiSecret,
            };
            return headers;
        }

        public Task<HttpHelper.HttpResult> GetResponseAsync(AkmiiApiUrl apiUrl, string content)
        {
            var headers = GetHeaders();
            return HttpHelper.GetHttpResponseAsync(apiUrl.Url, apiUrl.Method, content, headers);
        }
        public async Task<T> GetResponseAsync<T>(AkmiiApiUrl apiUrl, string content)
        {
            var response = await GetResponseAsync(apiUrl, content);
            T t;
            if (response != null && !string.IsNullOrWhiteSpace(response.Data))
            {
                t = JsonHelper.DeserializeJsonTo<T>(response.Data);
            }
            else
            {
                t = default(T);
            }
            return t;
        }
        public Task<string> PostFileAsync(string url, Stream fileStream, string fileName, string fileKeyName, Dictionary<string, string> contentDic, Dictionary<string, string> headers)
        {
            if (headers == null)
            {
                headers = new Dictionary<string, string>();
            }
            headers[AkmiiConstants.AkmiiSecret] = _context.AkmiiSecret;

            return HttpHelper.PostFileAsync(url, fileStream, fileName, fileKeyName, contentDic, headers);
        }
    }
}
