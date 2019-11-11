using System.Collections.Generic;

namespace YeeOfficeSDK.Models
{
	public class CustomDataGetListRequest : BaseModel
	{
		public long ListID { get; set; }
		public int AppID { get; set; }
		public List<string> Columns { get; set; }

		public List<ListDataWhereRequest> Wheres { get; set; }

		public List<ListDataSortRequest> SortsList { get; set; }

		public string FilterValue { get; set; }

		public int PageIndex { get; set; } = 1;

		public int PageSize { get; set; } = 20;

		public bool Verification { get; set; } = true;
	}
	public class CustomDataGetByIDRequest
	{
		public long ListID { get; set; }
		public int AppID { get; set; }
		public long ListDataID { get; set; }

		public List<string> Columns { get; set; }

		public bool DefaultColumns { get; set; } = false;

		public bool Verification { get; set; } = true;
	}
	public class CustomDataGetTitleRequest
	{
		public string Title { get; set; }
		public int AppID { get; set; }
		public List<string> Columns { get; set; }

		public List<ListDataWhereRequest> Wheres { get; set; }

		public ListDataSortRequest Sorts { get; set; }

		public string FilterValue { get; set; }

		public int PageIndex { get; set; } = 1;

		public int PageSize { get; set; } = 20;

		public bool Verification { get; set; } = true;
	}

	public class CustomDataGetTitleSortRequest
	{
		public string Title { get; set; }
		public int AppID { get; set; }
		public List<string> Columns { get; set; }

		public List<ListDataWhereRequest> Wheres { get; set; }

		public List<ListDataSortRequest> Sorts { get; set; }

		public string FilterValue { get; set; }

		public int PageIndex { get; set; } = 1;

		public int PageSize { get; set; } = 20;

		public bool Verification { get; set; } = true;
	}
	public class CustomDataGetByIDsRequest
	{
		public long ListID { get; set; }
		public int AppID { get; set; }
		public List<long> ListDataIDs { get; set; }

		public List<string> Columns { get; set; }

		public bool Verification { get; set; } = true;
	}
	public class CustomDataRemvoeRequest
	{
		public long ListID { get; set; }
		public int AppID { get; set; }
		public long ListDataID { get; set; }
	}
	public class CustomDataRemvoeBatchRequest
	{
		public long ListID { get; set; }
		public int AppID { get; set; }
		public List<long> ListDataIDs { get; set; }
	}
	public class CustomDataAddRequest
	{
		public long ListID { get; set; }
		public int AppID { get; set; }
		public Dictionary<string, string> Dic { get; set; }
	}
	public class CustomDataEditRequest
	{
		public int AppID { get; set; }
		public long ListID { get; set; }
		public long ListDataID { get; set; }

		public int RowVersion { get; set; }

		public Dictionary<string, string> Dic { get; set; }
	}
	public class CustomDataAddBatchRequest
	{
		public long ListID { get; set; }
		public int AppID { get; set; }
		public List<Dictionary<string, string>> DicList { get; set; }
		public bool Verification { get; set; } = true;
	}
	public class CustomDataEditBatchRequest
	{
		public long ListID { get; set; }
		public int AppID { get; set; }
		public List<ListDataEditRequest> Data { get; set; }
	}
	public class CustomDataAddByTitleRequest
	{
		public string Title { get; set; }
		public int AppID { get; set; }
		public Dictionary<string, string> Dic { get; set; }
	}
	public class CustomDataAddBatchByTitleRequest
	{
		public string Title { get; set; }
		public int AppID { get; set; }
		public List<Dictionary<string, string>> DicList { get; set; }
	}
	public class CustomDataEditByTitleRequest
	{
		public int AppID { get; set; }
		public string Title { get; set; }
		public long ListDataID { get; set; }

		public int RowVersion { get; set; }

		public Dictionary<string, string> Dic { get; set; }
	}
	public class CustomDataGetListDefaultRequest
	{
		public long ListID { get; set; }
		public int AppID { get; set; }
		public string Column { get; set; }

		public List<ListDataWhereRequest> Wheres { get; set; }
	}
	public class CustomDataEditParameter
	{
		public long ListDataID { get; set; }

		public int RowVersion { get; set; }

		public Dictionary<string, string> Dic { get; set; }
	}
	public class CustomDataEditBatchByTitleRequest
	{
		public int AppID { get; set; }
		public string Title { get; set; }

		public List<CustomDataEditParameter> ParList { get; set; }
	}
	public class CustomDataEditByTitleWhereRequest
	{
		public int AppID { get; set; }
		public string Title { get; set; }
		public List<ListDataWhereRequest> Wheres { get; set; }
		public List<ListDataUpdateFieldRequest> UpdateValues { get; set; }
		public bool HasVersion { get; set; }
	}
	public class CustomDataRemvoeByTitleRequest
	{
		public string Title { get; set; }
		public int AppID { get; set; }
		public long ListDataID { get; set; }
	}
	public class CustomDataRemvoeBatchByTitleRequest
	{
		public string Title { get; set; }
		public int AppID { get; set; }
		public List<long> ListDataIDs { get; set; }
	}
	public class CustomDataGetByIDTitleRequest
	{
		public string Title { get; set; }
		public int AppID { get; set; }
		public long ListDataID { get; set; }

		public List<string> Columns { get; set; }
	}
	public class ListDataBatchEditRequest
	{
		public int AppID { get; set; }
		public string Title { get; set; }
		public long listID { get; set; }
		public List<ListDataWhereRequest> Wheres { get; set; }

		public Dictionary<string, string> Dic { get; set; }
	}

	public class CustomListItemResponse
	{
		public string ListTitle { get; set; }
		public Dictionary<string, string> ItemInfo { get; set; }
	}
}
