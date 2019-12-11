using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YeeOfficeSDK.Interfaces;
using YeeOfficeSDK.Models;
using YeeOfficeSDK.Tools;

namespace YeeOfficeSDK.Repository
{
    public partial class AkmiiRepository : IAkmiiRepository
    {
        public Task<ResponseMessage<List<UserInfo>>> UserInfoSearchAsync(UserInfoSearchRequest request)
        {
            var apiUrl = new AkmiiApiUrl
            {
                Method = "GET",
                Url = _context.DomainUrl + "/YeeOfficeSettings/_api/ver(3.0)/userinfo/V4/search"
            };
            return GetResponseAsync<ResponseMessage<List<UserInfo>>>(apiUrl, request.Convert2Json());
        }

        public Task<ResponseMessage<List<UserInfo>>> UserInfoSearchByWhereAsync(UserInfoSearchByWhereRequest request)
        {
            var apiUrl = new AkmiiApiUrl
            {
                Method = "POST",
                Url = _context.DomainUrl + "/YeeOfficeSettings/_api/ver(3.0)/userinfo/V4/search"
            };
            return GetResponseAsync<ResponseMessage<List<UserInfo>>>(apiUrl, request.Convert2Json());
        }

        public Task<ResponseMessage<UserInfo>> UserInfoGetByAccountIDAsync(long accountID)
        {
            var apiUrl = new AkmiiApiUrl
            {
                Method = "GET",
                Url = _context.DomainUrl + "/YeeOfficeSettings/_api/ver(3.0)/userinfo/V4?accountID=" + accountID
            };
            return GetResponseAsync<ResponseMessage<UserInfo>>(apiUrl, null);
        }
        public Task<ResponseMessage<UserInfo>> UserInfoGetByEmployeeNoAsync(string employeeNo)
        {
            var apiUrl = new AkmiiApiUrl
            {
                Method = "GET",
                Url = _context.DomainUrl + "/YeeOfficeSettings/_api/ver(3.0)/userinfo/V4/employeeno?employeeno=" + employeeNo
            };
            return GetResponseAsync<ResponseMessage<UserInfo>>(apiUrl, null);
        }
        public Task<ResponseMessage<UserInfo>> UserInfoGetByspAccountAsync(string spAccount)
        {
            var apiUrl = new AkmiiApiUrl
            {
                Method = "GET",
                Url = _context.DomainUrl + "/YeeOfficeSettings/_api/ver(3.0)/userinfo/V4/spAccount?spAccount=" + spAccount
            };
            return GetResponseAsync<ResponseMessage<UserInfo>>(apiUrl, null);
        }
        public Task<ResponseMessage<UserInfo>> UserInfoGetByEmailAsync(string email)
        {
            var apiUrl = new AkmiiApiUrl
            {
                Method = "GET",
                Url = _context.DomainUrl + "/YeeOfficeSettings/_api/ver(3.0)/userinfo/V4/email?email=" + email
            };
            return GetResponseAsync<ResponseMessage<UserInfo>>(apiUrl, null);
        }
    }
}
