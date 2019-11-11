using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using YeeOfficeSDK;
using YeeOfficeSDK.Models;

namespace YeeOfficeSDKUnitTest
{
    [TestClass]
    public class ListDataUnitTest
    {
        [TestMethod]
        public void GetDataByListIDTest()
        {
            try
            {
                var context = AkmiiContext.GetAkmiiContext(Util.DomainUrl, Util.Secret);
                var response = context.Repository.SelectByListIDAsync(new CustomDataGetListRequest
                {
                    AppID = 41,
                    ListID = 1153194374738350080
                }).Result;
                var count = response.Data;
            }
            catch (Exception ex)
            {

            }
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void ListDataRemoveTest()
        {
            try
            {
                var context = AkmiiContext.GetAkmiiContext(Util.DomainUrl, Util.Secret);
                var response = context.Repository.RemoveByIDAsync(new CustomDataRemvoeRequest
                {
                    AppID = 41,
                    ListID = 1006831681275039744,
                    ListDataID = 1034648312172646400
                }).Result;
                var count = response.Data;
            }
            catch (Exception ex)
            {

            }
            Assert.IsTrue(true);
        }
    }
}
