using YeeOfficeSDK.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YeeOfficeSDK.Models
{
	public class ListDataEditRequest
	{
		public ListDataEditRequest() { }

		public long ListDataID { get; set; }
		public int RowVersion { get; set; }
		public Dictionary<string, string> Dic { get; set; }
	}
}
