using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YeeOfficeSDK;
using YeeOfficeSDK.Models;
using YeeOfficeSDK.Tools;

namespace YeeOfficeSDKUnitTest
{
    [TestClass]
    public class DocumentNetUnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                HttpHelper.SetSecurityProtocol();

                string libraryId = "920492503495479296";
                var _headers = new Dictionary<string, string>
                {
                    ["AkmiiSecret"] = Util.Secret
                };
                var codeUrl = Util.DomainUrl + "/YeeOfficeDocument_Net/_API/Ver(3.0)/api/Library/code?Code=flowcraft-file&AppID=41";
                var codeResponse = HttpHelper.GetHttpResponseAsync(codeUrl, "GET", null, headers: _headers).Result;

                var path = @"E:\Workspace\Yeeflow\YeeFlow邮件模板\YeeFlow邮件通知模板0419中文版(1).pptx";
                var fileName = System.IO.Path.GetFileName(path) + "";
                var fileNameWithoutExt = System.IO.Path.GetFileNameWithoutExtension(path) + "";
                var fileBytes = File.ReadAllBytes(path);
                var md5 = AkmiiHelper.GetMD5HashFromByte(fileBytes);
                //begin
                var beginUrl = Util.DomainUrl + "/YeeOfficeDocument_Net/_API/Ver(3.0)/api/file/upload/begin";
                var beginReq = new BeginUploadRequest
                {
                    MD5 = md5,
                    FileName = fileName,
                    FileExtension = (System.IO.Path.GetExtension(path) + "").ToLower().Substring(1),
                    Length = fileBytes.Length,
                    ChunkSize = 1,
                    AppID = 41,
                };
                var beginContent = beginReq.Convert2Json();
                var beginResult = HttpHelper.GetHttpResponseAsync(beginUrl, "POST", beginContent, headers: _headers).Result;
                var beginData = JsonHelper.DeserializeJsonTo<ResponseMessage<BeginUploadResponse>>(beginResult.Data);
                var fileId = beginData.Data.FileID;
                //upload
                //YeeOfficeDocument_Net/_API/Ver(3.0)//api/Library/code?Code=flowcraft-file&AppID=41
                var uploadUrl = Util.DomainUrl + "/YeeOfficeDocument_Net/_API/Ver(3.0)/api/file/upload/small?fileID=" + fileId;
                var fileList = new List<HttpHelper.UploadFileModel>();
                fileList.Add(new HttpHelper.UploadFileModel
                {
                    FileName = fileName,
                    Bytes = fileBytes,
                    FileKeyName = fileName
                });

                var uploadResult = HttpHelper.PostMultiFileAsync(uploadUrl, fileList, _headers).Result;

                string documentAddUrl = Util.DomainUrl + "/YeeOfficeDocument_Net/_API/Ver(3.0)//api/document";
                var postdata = new DocumentAddRequest
                {
                    AppID = 41,
                    LibraryID = libraryId,
                    Name = fileNameWithoutExt,
                    MD5 = md5,
                    ContentLength = beginReq.Length,
                    Extension = beginReq.FileExtension,
                    OverWrite = true,
                };
                var docAddResult = HttpHelper.GetHttpResponseAsync(documentAddUrl, "POST", postdata.Convert2Json(), headers: _headers).Result;

            }
            catch (Exception ex)
            {

            }
        }

        [TestMethod]
        public void TestAddFileToDoc()
        {
            try
            {
                var context = AkmiiContext.GetAkmiiContext(Util.DomainUrl, Util.Secret);
                var path = @"E:\Workspace\Yeeflow\YeeFlow邮件模板\YeeFlow邮件通知模板0419中文版(1).pptx";
                string code = "flowcraft-file";
                var result = context.Repository.UploadFileToDocAsync(41, code, path).Result;
            }
            catch (Exception ex)
            {

            }
            Assert.IsTrue(true);
        }
    }
}
