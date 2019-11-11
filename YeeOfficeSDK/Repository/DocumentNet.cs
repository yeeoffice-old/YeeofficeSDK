using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using YeeOfficeSDK.Models;
using YeeOfficeSDK.Tools;

namespace YeeOfficeSDK.Repository
{
    public partial class AkmiiRepository
    {
        public async Task<ResponseMessage<string>> UploadFileToDocAsync(int appID, string code, string filePath)
        {
            var result = await GetResponseAsync<ResponseMessage<DocumentLibraryResponse>>(new AkmiiApiUrl
            {
                Method = "GET",
                Url = _context.DomainUrl + $"/YeeOfficeDocument_Net/_API/Ver(3.0)/api/Library/code?Code={code}&AppID={appID}"
            }, null);
            if (result.Status != 0 || result.Data == null)
            {
                throw new Exception($"begin upload Status:{result.Status},message:{result.Message},data:{result.Data}");
            }
            return await UploadFileToDocAsync(appID, result.Data.LibraryID, filePath);
        }
        public async Task<ResponseMessage<string>> UploadFileToDocAsync(int appID, long libraryID, string filePath)
        {
            var headers = GetHeaders();
            var fileName = System.IO.Path.GetFileName(filePath) + "";
            var fileNameWithoutExt = System.IO.Path.GetFileNameWithoutExtension(filePath) + "";
            var fileBytes = File.ReadAllBytes(filePath);
            var md5 = AkmiiHelper.GetMD5HashFromByte(fileBytes);
            var fileKey = Guid.NewGuid().ToString("N");
            //1.begin
            #region begin upload
            var beginReq = new BeginUploadRequest
            {
                MD5 = md5,
                FileName = fileName,
                Length = fileBytes.Length,
                FileExtension = (System.IO.Path.GetExtension(filePath) + "").ToLower().Substring(1),
                ChunkSize = 1,
                AppID = appID,
            };
            var beginResult = await GetResponseAsync<ResponseMessage<BeginUploadResponse>>(new AkmiiApiUrl
            {
                Method = "POST",
                Url = _context.DomainUrl + "/YeeOfficeDocument_Net/_API/Ver(3.0)/api/file/upload/begin"
            }, beginReq.Convert2Json());
            if (beginResult.Data == null)
            {
                throw new Exception($"begin upload Status:{beginResult.Status},message:{beginResult.Message},data:{beginResult.Data}");
            }
            #endregion
            //2.upload file,Ready 、Success
            #region upload file
            if (beginResult.Data.Progress == "Ready")
            {
                var fileId = beginResult.Data.FileID;
                //YeeOfficeDocument_Net/_API/Ver(3.0)//api/Library/code?Code=flowcraft-file&AppID=41
                var uploadUrl = _context.DomainUrl + "/YeeOfficeDocument_Net/_API/Ver(3.0)/api/file/upload/small?fileID=" + fileId;
                var fileList = new List<HttpHelper.UploadFileModel>
                {
                    new HttpHelper.UploadFileModel
                    {
                        FileName = fileName,
                        Bytes = fileBytes,
                        FileKeyName = fileKey
                    }
                };

                var uploadResponse = await HttpHelper.PostMultiFileAsync(uploadUrl, fileList, headers);
                var uploadResult = JsonHelper.DeserializeJsonTo<ResponseMessage<string>>(uploadResponse);
                if (uploadResult.Status != 0)
                {
                    throw new Exception($"upload small Status:{uploadResult.Status},message:{uploadResult.Message},data:{uploadResult.Data}");
                }
            }
            #endregion

            #region doc add
            var docAddRequest = new DocumentAddRequest
            {
                AppID = appID,
                LibraryID = libraryID + "",
                Name = fileKey,
                MD5 = md5,
                ContentLength = beginReq.Length,
                Extension = beginReq.FileExtension,
                OverWrite = true,
            };
            var docAddResult = await GetResponseAsync<ResponseMessage<string>>(new AkmiiApiUrl
            {
                Method = "POST",
                Url = _context.DomainUrl + "/YeeOfficeDocument_Net/_API/Ver(3.0)//api/document",
            }, docAddRequest.Convert2Json());
            #endregion
            if (docAddResult.Status != 0)
            {
                throw new Exception($"upload small Status:{docAddResult.Status},message:{docAddResult.Message},data:{docAddResult.Data}");
            }
            var fileUrl = _context.DomainUrl + "/YeeOfficeDocument_Net/_API/Ver(3.0)/" + docAddResult.Data + "&name=" + HttpUtility.UrlEncode(fileNameWithoutExt);
            var akFileInfo = AkmiiFileInfo.GetAkmiiFileInfo(fileKey, fileName, beginReq.Length, fileUrl);

            docAddResult.Data = akFileInfo.ToString();

            return docAddResult;
        }
    }
}
