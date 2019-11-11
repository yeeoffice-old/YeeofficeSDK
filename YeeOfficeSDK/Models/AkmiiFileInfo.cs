using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using YeeOfficeSDK.Tools;

namespace YeeOfficeSDK.Models
{
    [DataContract]
    public class AkmiiFileInfo : BaseModel
    {
        [DataMember(Name = "fileKey")]
        public string FileKey { get; set; }

        [DataMember(Name = "fileSize")]
        public long FileSize { get; set; }

        [DataMember(Name = "fileName")]
        public string FileName { get; set; }

        [DataMember(Name = "uid")]
        public string UID { get; set; }

        [DataMember(Name = "fileInfo")]
        public FileData FileInfo { get; set; }

        public class FileData
        {
            [DataMember(Name = "FileKey")]
            public string FileKey { get; set; }
            [DataMember(Name = "Url")]
            public string Url { get; set; }
        }

        public static AkmiiFileInfo GetAkmiiFileInfo(string fileKey, string fileName, long fileSize,
            string url)
        {
            return new AkmiiFileInfo
            {
                FileKey = fileKey,
                FileName = fileName,
                FileSize = fileSize,
                UID = fileKey,
                FileInfo = new FileData
                {
                    FileKey = fileKey,
                    Url = url
                }
            };
        }

        public string GetExtension()
        {
            string ext = "";
            if (string.IsNullOrWhiteSpace(FileName))
            {
                return ext;
            }
            ext = (System.IO.Path.GetExtension(FileName) + "").ToLower();
            if (ext.StartsWith("."))
            {
                ext = ext.Substring(1);
            }
            return ext;
        }
        public string GetFileNameOutExt()
        {
            return System.IO.Path.GetFileNameWithoutExtension(FileName);
        }

        public string GetUrl()
        {
            if (FileInfo == null || string.IsNullOrWhiteSpace(FileInfo.Url))
            {
                return "";
            }
            return FileInfo.Url;
        }
        public void SetFileName(string name, string ext)
        {
            var tempUrlParams = HttpUtility.ParseQueryString(this.FileInfo.Url);
            var tmpName = HttpUtility.UrlEncode(tempUrlParams["name"], Encoding.UTF8);
            this.FileInfo.Url = this.FileInfo.Url.ReplaceNoCase("name=" + tmpName, "name=" + HttpUtility.UrlEncode(name, Encoding.UTF8));
            this.FileName = name + "." + ext;
        }
        public static AkmiiFileInfo GetJsonToModel(string docInfo)
        {
            if (string.IsNullOrWhiteSpace(docInfo))
            {
                return null;
            }
            return JsonHelper.DeserializeJsonTo<AkmiiFileInfo>(docInfo);
        }
        public static List<AkmiiFileInfo> GetJsonToModels(string docInfo)
        {
            if (string.IsNullOrWhiteSpace(docInfo))
            {
                return null;
            }
            return JsonHelper.DeserializeJsonTo<List<AkmiiFileInfo>>(docInfo);
        }
    }
}
