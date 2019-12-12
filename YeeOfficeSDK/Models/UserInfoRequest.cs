using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YeeOfficeSDK.Models
{
    public class UserInfoSearchRequest
    {
        public int PageIndex { get; set; } = 1;

        public int PageSize { get; set; } = 20;

        public string SearchKey { get; set; }

        public long OrgID { get; set; }

        public string SortName { get; set; }

        public bool SortByDesc { get; set; }
        public int? Status { get; set; }
    }
    public class UserInfoSearchByWhereRequest : UserInfoSearchRequest
    {
        public List<ListDataWhereRequest> Wheres { get; set; }
    }

    public class UserInfoAddRequest
    {
        public string Password { get; set; }
        public int AccountType { get; set; }
        public bool FirstLogin { get; set; }
        public Dictionary<string, string> Attrs { get; set; }
    }
    public class UserInfoChangeRequest
    {
        public long AccountID { get; set; }
        public int Version { get; set; }
        public long OldDepartmentID { get; set; }
        public long DepartmentID { get; set; }
        public Dictionary<string, string> Attrs { get; set; }
    }
    internal class UserInfoRemovesRequest
    {
        public Dictionary<long, long> IDMappings { get; set; }
        public UserInfoRemovesRequest(List<UserInfoRemoveRequest> list)
        {
            if (list == null || list.Count == 0)
            {
                return;
            }
            IDMappings = list.ToDictionary(x => x.AccountID, y => y.OrgID);
        }
    }
    public class UserInfoRemoveRequest
    {
        public long AccountID { get; set; }
        public long OrgID { get; set; }
    }
    public class UserInfoAccountIDsRequest
    {
        public List<long> AccountIDs { get; set; }
    }

    internal class UserInfoMoveRequest
    {
        public long DestOrgID { get; set; }
        /// <summary>
        /// Key为accountID value为用户原来的OrgID
        /// </summary>
        public Dictionary<long, long> IDMappings { get; set; }

        public UserInfoMoveRequest(UserInfoMoveOrgRequest model)
        {
            if (model == null || model.TargetOrgID == 0
                || model.UserIDs == null || model.UserIDs.Count == 0)
            {
                return;
            }
            DestOrgID = model.TargetOrgID;
            IDMappings = model.UserIDs.ToDictionary(x => x.AccountID, y => y.OrgID);
        }
    }
    public class UserInfoMoveOrgRequest
    {
        public long TargetOrgID { get; set; }

        public List<UserInfoRemoveRequest> UserIDs { get; set; }
    }
}
