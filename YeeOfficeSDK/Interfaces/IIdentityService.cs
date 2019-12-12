using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YeeOfficeSDK.Models;

namespace YeeOfficeSDK.Interfaces
{
    public partial interface IAkmiiRepository
    {
        Task<ResponseMessage<string>> UserInfoAddAsync(UserInfoAddRequest request);
        Task<ResponseMessage<string>> UserInfoChangeAsync(UserInfoChangeRequest request);
        Task<ResponseMessage<string>> UserInfoRemoveAsync(List<UserInfoRemoveRequest> list);
        Task<ResponseMessage<bool>> UserInfoEnableAsync(UserInfoAccountIDsRequest request);
        Task<ResponseMessage<bool>> UserInfoDisableAsync(UserInfoAccountIDsRequest request);
        Task<ResponseMessage<string>> UserInfoMoveOrgAsync(UserInfoMoveOrgRequest data);

        Task<ResponseMessage<List<UserInfo>>> UserInfoSearchAsync(UserInfoSearchRequest request);
        Task<ResponseMessage<List<UserInfo>>> UserInfoSearchByWhereAsync(UserInfoSearchByWhereRequest request);
        Task<ResponseMessage<UserInfo>> UserInfoGetByAccountIDAsync(long accountID);
        Task<ResponseMessage<UserInfo>> UserInfoGetByEmployeeNoAsync(string employeeNo);
        Task<ResponseMessage<UserInfo>> UserInfoGetByspAccountAsync(string spAccount);
        Task<ResponseMessage<UserInfo>> UserInfoGetByEmailAsync(string email);
    }
}
