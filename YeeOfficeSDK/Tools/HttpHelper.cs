using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace YeeOfficeSDK.Tools
{
    public class HttpHelper
    {
        public class HttpResult
        {
            public int StatusCode { get; set; }
            public string Data { get; set; }
        }


        public class UploadFileModel
        {
            public string FileKeyName { get; set; }
            public string FileName { get; set; }
            public byte[] Bytes { get; set; }
        }

        public static void SetSecurityProtocol()
        {
            var securityProtocol = ConfigurationManager.AppSettings["SecurityProtocol"].Convert2Int32();
            SecurityProtocolType security = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            if (securityProtocol > 0)
            {
                security = (SecurityProtocolType)securityProtocol;
            }
            ServicePointManager.SecurityProtocol = security;
        }
        public async static Task<HttpResult> GetHttpResponseAsync(string url, string method, string content, Dictionary<string, string> headers = null,
           string contentType = "application/json",
           ICredentials credentials = null,
           int timeout = 20)
        {
            if ((string.Compare(method, "GET", true) == 0
                || string.Compare(method, "DELETE", true) == 0)
                && !string.IsNullOrEmpty(content))
            {
                try
                {
                    var contentDic = JsonHelper.DeserializeJsonTo<Dictionary<string, object>>(content);
                    if (contentDic != null && contentDic.Count > 0)
                    {
                        if (url.IndexOf("?") == -1)
                        {
                            url += "?";
                        }
                        else
                        {
                            url += "&";
                        }
                        url += string.Join("&", contentDic.Select(x => { return $"{x.Key}={x.Value + ""}"; }));
                    }
                }
                catch (Exception ex)
                {

                }
            }

            var webRequest = WebRequest.CreateHttp(url);
            webRequest.Method = method;
            webRequest.Timeout = timeout * 1000;
            if (headers != null && headers.Count > 0)
            {
                foreach (var header in headers)
                {
                    webRequest.Headers.Add(header.Key, header.Value);
                }
            }

            webRequest.CookieContainer = new CookieContainer();

            webRequest.Credentials = credentials;
            webRequest.ContentType = contentType;
            if (!string.IsNullOrWhiteSpace(content) && string.Compare(method, "get", true) != 0
                && string.Compare(method, "DELETE", true) != 0)
            {
                byte[] buffer = Encoding.UTF8.GetBytes(content);
                webRequest.ContentLength = buffer.Length;
                using (var reqStream = webRequest.GetRequestStream())
                {
                    reqStream.Write(buffer, 0, buffer.Length);
                }
            }
            var responseContent = "";
            int statusCode;
            using (var response = await webRequest.GetResponseAsync() as HttpWebResponse)
            {
                using (var stream = response.GetResponseStream())
                {
                    using (var reader = new StreamReader(stream, Encoding.UTF8))
                    {
                        responseContent = reader.ReadToEnd();
                        statusCode = (int)response.StatusCode;
                    }
                }
            }

            return new HttpResult { StatusCode = statusCode, Data = responseContent };
        }

        public static Task<HttpResult> GetAsync(string url, string content = null, Dictionary<string, string> headers = null)
        {
            return GetHttpResponseAsync(url, "GET", content, headers);
        }

        public static Task<HttpResult> PostAsync(string url, string content, Dictionary<string, string> headers = null)
        {
            return GetHttpResponseAsync(url, "POST", content, headers);
        }
        public static Task<HttpResult> PutAsync(string url, string content, Dictionary<string, string> headers = null)
        {
            return GetHttpResponseAsync(url, "PUT", content, headers);
        }
        public static Task<HttpResult> DeleteAsync(string url, string content = null, Dictionary<string, string> headers = null)
        {
            return GetHttpResponseAsync(url, "DELETE", content, headers);
        }

        public async static Task<string> PostFileAsync(string url, Stream fileStream, string fileName, string fileKeyName, Dictionary<string, string> contentDic,
            Dictionary<string, string> headers = null, ICredentials credentials = null, int timeOut = 300000)
        {
            var result = string.Empty;
            var request = (HttpWebRequest)WebRequest.Create(url);
            var boundary = "----------" + DateTime.Now.Ticks.ToString("x");
            request.ContentType = "multipart/form-data; boundary=" + boundary;
            request.Method = "POST";
            request.Timeout = timeOut;
            if (headers != null && headers.Count > 0)
            {
                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }
            request.Credentials = credentials;

            using (Stream requestStream = request.GetRequestStream())
            {
                byte[] boundarybytes = Encoding.UTF8.GetBytes("--" + boundary + "\r\n");
                byte[] trailer = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");

                byte[] bArr = new byte[fileStream.Length];
                fileStream.Read(bArr, 0, bArr.Length);
                //begin
                requestStream.Write(boundarybytes, 0, boundarybytes.Length);
                var header = $"Content-Disposition:form-data;name=\"{fileKeyName}\";filename=\"{fileName}\"\r\nfilelength=\"{fileStream.Length}\"\r\nContent-Type:application/octet-stream\r\n\r\n";
                byte[] postHeaderBytes = Encoding.UTF8.GetBytes(header.ToString());
                requestStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);
                fileStream.Close();
                requestStream.Write(bArr, 0, bArr.Length);

                // 写入字符串的Key  
                if (contentDic != null && contentDic.Count > 0)
                {
                    var stringKeyHeader = "\r\n--" + boundary +
                                           "\r\nContent-Disposition: form-data; name=\"{0}\"" +
                                           "\r\n\r\n{1}\r\n";
                    foreach (byte[] formitembytes in from string key in contentDic.Keys
                                                     select string.Format(stringKeyHeader, key, contentDic[key])
                                                         into formitem
                                                     select Encoding.UTF8.GetBytes(formitem))
                    {
                        requestStream.Write(formitembytes, 0, formitembytes.Length);
                    }
                }
                //end
                requestStream.Write(trailer, 0, trailer.Length);
            }
            var response = (HttpWebResponse)(await request.GetResponseAsync());
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                result = await streamReader.ReadToEndAsync();
            }
            return result;
        }

        public async static Task<string> PostMultiFileAsync(string url, List<UploadFileModel> fileBytes, Dictionary<string, string> headers = null, Dictionary<string, string> formData = null, int timeOut = 300000)
        {
            using (var client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromMilliseconds(timeOut);
                using (var content = new MultipartFormDataContent())
                {
                    //add headers
                    if (headers != null && headers.Count > 0)
                    {
                        foreach (var header in headers)
                        {
                            content.Headers.Add(header.Key, header.Value);
                        }
                    }
                    // Add file 
                    foreach (var item in fileBytes)
                    {
                        var fileContent = new ByteArrayContent(item.Bytes);
                        fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                        {
                            FileName = item.FileName
                        };
                        content.Add(fileContent, item.FileKeyName, item.FileName);
                    }
                    // add form data
                    if (formData != null && formData.Count > 0)
                    {
                        foreach (var item in formData)
                        {
                            content.Add(new StringContent(item.Value, Encoding.UTF8), item.Key);
                        }
                    }

                    // Make a call to Web API
                    var result = await client.PostAsync(url, content);
                    return await result.Content.ReadAsStringAsync();
                }
            }

        }


    }
}
