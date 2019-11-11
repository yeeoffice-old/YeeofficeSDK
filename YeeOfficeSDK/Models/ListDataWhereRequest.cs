using YeeOfficeSDK.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YeeOfficeSDK.Models
{
    public class ListDataWhereRequest
    {
        public string WhereName { get; set; }
        public string Value { get; set; }
        public OperateEnum Type { get; set; }
        public string Pre { get; set; }
        public List<ListDataWhereRequest> Child { get; set; }
    }
}
