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
        public void TestAddFileToDoc()
        {
            try
            {
                var context = AkmiiContext.GetAkmiiContext(Util.DomainUrl, Util.Secret);
                var path = @"E:\Workspace\xxxxxx.pptx";
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
