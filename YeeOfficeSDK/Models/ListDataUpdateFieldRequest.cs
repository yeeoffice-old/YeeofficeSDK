using YeeOfficeSDK.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YeeOfficeSDK.Models
{
	public class ListDataUpdateFieldRequest
	{
		public ListDataUpdateFieldRequest() { }

		public string Columns { get; set; }
		public string Data { get; set; }
		public OperateDataEnum Per { get; set; }
	}
}
