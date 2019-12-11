using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YeeOfficeSDK;
using YeeOfficeSDK.Models;

namespace YeeOfficeSDKUnitTest
{
    [TestClass]
    public class IdentityUnitTest1
    {
        [TestMethod]
        public void UserInfoGetByEmail()
        {
            try
            {
                var context = AkmiiContext.GetAkmiiContext(Util.DomainUrl, Util.Secret);
                var response = context.Repository.UserInfoGetByEmailAsync("terry.tan@akmii.com").Result;
                //895927078568988673 ,001
                response = context.Repository.UserInfoGetByAccountIDAsync(895927078568988673).Result;
                response = context.Repository.UserInfoGetByEmployeeNoAsync("001").Result;
                response = context.Repository.UserInfoGetByspAccountAsync("terry.tan@akmii.com").Result;
            }
            catch (Exception ex)
            {

            }
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void UserInfoSearch()
        {
            try
            {
                var context = AkmiiContext.GetAkmiiContext(Util.DomainUrl, Util.Secret);
                var response = context.Repository.UserInfoSearchAsync(new UserInfoSearchRequest { Status = (int)UserStatusEnum.Enabled }).Result;
                var count = response.Data;
            }
            catch (Exception ex)
            {

            }
            Assert.IsTrue(true);
        }
    }
}
