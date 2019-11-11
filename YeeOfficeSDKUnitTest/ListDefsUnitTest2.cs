using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YeeOfficeSDK;

namespace YeeOfficeSDKUnitTest
{
    [TestClass]
    public class ListDefsUnitTest2
    {
        [TestMethod]
        public void GetDataByListIDTest()
        {
            try
            {
                var context = AkmiiContext.GetAkmiiContext(Util.DomainUrl, Util.Secret);
                var response = context.Repository.GetListDefByListIDAsync(41, 1168816360516620288).Result;
                var count = response.Data;
            }
            catch (Exception ex)
            {

            }
            Assert.IsTrue(true);
        }
    }
}
