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
}
