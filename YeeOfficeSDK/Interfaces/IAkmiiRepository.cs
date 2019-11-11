using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YeeOfficeSDK.Tools;

namespace YeeOfficeSDK.Interfaces
{
    public partial interface IAkmiiRepository
    {
        Task<HttpHelper.HttpResult> GetResponseAsync(AkmiiApiUrl apiUrl, string content);
        Task<T> GetResponseAsync<T>(AkmiiApiUrl apiUrl, string content);
        Task<string> PostFileAsync(string url, Stream fileStream, string fileName, string fileKeyName, Dictionary<string, string> contentDic, Dictionary<string, string> headers);
    }
}
