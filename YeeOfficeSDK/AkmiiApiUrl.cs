namespace YeeOfficeSDK
{
	public class AkmiiApiUrl
	{
		public string Method { get; set; }
		public string Url { get; set; }
		public string Version { get; set; }
		public static AkmiiApiUrl SelectByListID(string domainUrl)
		{
			return new AkmiiApiUrl
			{
				Method = "POST",
				Url = domainUrl + "/YeeOfficeSettings/_API/Ver(3.0)/api/crafts/datas/listid"
			};
		}

		public static AkmiiApiUrl SelectByListIDs(string domainUrl)
		{
			return new AkmiiApiUrl
			{
				Method = "POST",
				Url = domainUrl + "/YeeOfficeSettings/_API/Ver(3.0)/api/crafts/datas/listids"
			};
		}

		public static AkmiiApiUrl SelectByTitle(string domainUrl)
		{
			return new AkmiiApiUrl
			{
				Method = "POST",
				Url = domainUrl + "/YeeOfficeSettings/_API/Ver(3.0)/api/crafts/datas/title"
			};
		}

		public static AkmiiApiUrl SelectByTitleSorts(string domainUrl)
		{
			return new AkmiiApiUrl
			{
				Method = "POST",
				Url = domainUrl + "/YeeOfficeSettings/_API/Ver(3.0)/api/crafts/datas/titlesorts"
			};
		}

		public static AkmiiApiUrl SelectByListIDFirst(string domainUrl)
		{
			return new AkmiiApiUrl
			{
				Method = "POST",
				Url = domainUrl + "/YeeOfficeSettings/_API/Ver(3.0)/api/crafts/datas/default"
			};
		}

		public static AkmiiApiUrl SelectByIDs(string domainUrl)
		{
			return new AkmiiApiUrl
			{
				Method = "POST",
				Url = domainUrl + "/YeeOfficeSettings/_API/Ver(3.0)/api/crafts/datas/ids"
			};
		}

		public static AkmiiApiUrl RemoveByID(string domainUrl)
		{
			return new AkmiiApiUrl
			{
				Method = "DELETE",
				Url = domainUrl + "/YeeOfficeSettings/_API/Ver(3.0)/api/crafts/datas/id"
			};
		}

		public static AkmiiApiUrl SelectByID(string domainUrl)
		{
			return new AkmiiApiUrl
			{
				Method = "POST",
				Url = domainUrl + "/YeeOfficeSettings/_API/Ver(3.0)/api/crafts/datas/id"
			};
		}

		public static AkmiiApiUrl SelectJoinListTitleByID(string domainUrl)
		{
			return new AkmiiApiUrl
			{
				Method = "POST",
				Url = domainUrl + "/YeeOfficeSettings/_API/Ver(3.0)/api/crafts/datas/iteminfo"
			};
		}

		public static AkmiiApiUrl RemoveBatchByIDs(string domainUrl)
		{
			return new AkmiiApiUrl
			{
				Method = "PUT",
				Url = domainUrl + "/YeeOfficeSettings/_API/Ver(3.0)/api/crafts/datas/removeids"
			};
		}

		public static AkmiiApiUrl Add(string domainUrl)
		{
			return new AkmiiApiUrl
			{
				Method = "POST",
				Url = domainUrl + "/YeeOfficeSettings/_API/Ver(3.0)/api/crafts/datas"
			};
		}

		public static AkmiiApiUrl Edit(string domainUrl)
		{
			return new AkmiiApiUrl
			{
				Method = "PUT",
				Url = domainUrl + "/YeeOfficeSettings/_API/Ver(3.0)/api/crafts/datas"
			};
		}

		public static AkmiiApiUrl AddBatch(string domainUrl)
		{
			return new AkmiiApiUrl
			{
				Method = "POST",
				Url = domainUrl + "/YeeOfficeSettings/_API/Ver(3.0)/api/crafts/datas/addbatch"
			};
		}

		public static AkmiiApiUrl EditBatch(string domainUrl)
		{
			return new AkmiiApiUrl
			{
				Method = "PUT",
				Url = domainUrl + "/YeeOfficeSettings/_API/Ver(3.0)/api/crafts/datas/editbatch"
			};
		}

		public static AkmiiApiUrl AddBatchNoTrans(string domainUrl)
		{
			return new AkmiiApiUrl
			{
				Method = "POST",
				Url = domainUrl + "/YeeOfficeSettings/_API/Ver(3.0)/api/crafts/datas/adds"
			};
		}

		public static AkmiiApiUrl AddByTitle(string domainUrl)
		{
			return new AkmiiApiUrl
			{
				Method = "POST",
				Url = domainUrl + "/YeeOfficeSettings/_API/Ver(3.0)/api/crafts/datas/title/add"
			};
		}

		public static AkmiiApiUrl AddBatchByTitle(string domainUrl)
		{
			return new AkmiiApiUrl
			{
				Method = "POST",
				Url = domainUrl + "/YeeOfficeSettings/_API/Ver(3.0)/api/crafts/datas/title/addbatch"
			};
		}

		public static AkmiiApiUrl EditByIDTitle(string domainUrl)
		{
			return new AkmiiApiUrl
			{
				Method = "PUT",
				Url = domainUrl + "/YeeOfficeSettings/_API/Ver(3.0)/api/crafts/datas/title/edit/id"
			};
		}

		public static AkmiiApiUrl EditBatchByIDTitle(string domainUrl)
		{
			return new AkmiiApiUrl
			{
				Method = "PUT",
				Url = domainUrl + "/YeeOfficeSettings/_API/Ver(3.0)/api/crafts/datas/title/editbatch/id"
			};
		}

		public static AkmiiApiUrl EditByTitle(string domainUrl)
		{
			return new AkmiiApiUrl
			{
				Method = "PUT",
				Url = domainUrl + "/YeeOfficeSettings/_API/Ver(3.0)/api/crafts/datas/title/edit"
			};
		}

		public static AkmiiApiUrl RemoveByTitleID(string domainUrl)
		{
			return new AkmiiApiUrl
			{
				Method = "DELETE",
				Url = domainUrl + "/YeeOfficeSettings/_API/Ver(3.0)/api/crafts/datas/title/id"
			};
		}

		public static AkmiiApiUrl SelectByTitleID(string domainUrl)
		{
			return new AkmiiApiUrl
			{
				Method = "POST",
				Url = domainUrl + "/YeeOfficeSettings/_API/Ver(3.0)/api/crafts/datas/title/id"
			};
		}

		public static AkmiiApiUrl RemoveBatchByTitleID(string domainUrl)
		{
			return new AkmiiApiUrl
			{
				Method = "PUT",
				Url = domainUrl + "/YeeOfficeSettings/_API/Ver(3.0)/api/crafts/datas/title/removeids"
			};
		}

		public static AkmiiApiUrl ListBatchEdit(string domainUrl)
		{
			return new AkmiiApiUrl
			{
				Method = "PUT",
				Url = domainUrl + "/YeeOfficeSettings/_API/Ver(3.0)/api/crafts/datas/batch"
			};
		}

		public static AkmiiApiUrl GetListDefByListID(string domainUrl, int appID, long listID)
		{
			return new AkmiiApiUrl
			{
				Method = "GET",
				Url = domainUrl + $"/YeeOfficeSettings/_API/Ver(3.0)/api/crafts/defs/listid?appid={appID}&listid={listID}"
			};
		}
	}
}
