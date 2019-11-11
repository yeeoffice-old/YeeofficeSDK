using System.Collections.Generic;
using System.Threading.Tasks;
using YeeOfficeSDK.Models;
using YeeOfficeSDK.Tools;

namespace YeeOfficeSDK.Repository
{
	public partial class AkmiiRepository
	{
		public Task<ResponseMessage<List<Dictionary<string, string>>>> SelectByListIDAsync(CustomDataGetListRequest request)
		{
			var apiUrl = AkmiiApiUrl.SelectByListID(_context.DomainUrl);
			return GetResponseAsync<ResponseMessage<List<Dictionary<string, string>>>>(apiUrl, request.Convert2Json());
		}

		public Task<ResponseMessage<Dictionary<long, List<Dictionary<string, string>>>>> SelectByListIDsAsync(List<CustomDataGetListRequest> request)
		{
			var apiUrl = AkmiiApiUrl.SelectByListIDs(_context.DomainUrl);
			return GetResponseAsync<ResponseMessage<Dictionary<long, List<Dictionary<string, string>>>>>(apiUrl, request.Convert2Json());
		}

		public Task<ResponseMessage<List<Dictionary<string, string>>>> SelectByTitleAsync(CustomDataGetTitleRequest request)
		{
			var apiUrl = AkmiiApiUrl.SelectByTitle(_context.DomainUrl);
			return GetResponseAsync<ResponseMessage<List<Dictionary<string, string>>>>(apiUrl, request.Convert2Json());
		}

		public Task<ResponseMessage<List<Dictionary<string, string>>>> SelectByTitleSortsAsync(CustomDataGetTitleSortRequest request)
		{
			var apiUrl = AkmiiApiUrl.SelectByTitleSorts(_context.DomainUrl);
			return GetResponseAsync<ResponseMessage<List<Dictionary<string, string>>>>(apiUrl, request.Convert2Json());
		}

		public Task<ResponseMessage<string>> SelectByListIDFirstAsync(CustomDataGetListDefaultRequest request)
		{
			var apiUrl = AkmiiApiUrl.SelectByListIDFirst(_context.DomainUrl);
			return GetResponseAsync<ResponseMessage<string>>(apiUrl, request.Convert2Json());
		}

		public Task<ResponseMessage<List<Dictionary<string, string>>>> SelectByIDsAsync(CustomDataGetByIDsRequest request)
		{
			var apiUrl = AkmiiApiUrl.SelectByIDs(_context.DomainUrl);
			return GetResponseAsync<ResponseMessage<List<Dictionary<string, string>>>>(apiUrl, request.Convert2Json());
		}

		public Task<ResponseMessage<string>> RemoveByIDAsync(CustomDataRemvoeRequest request)
		{
			var apiUrl = AkmiiApiUrl.RemoveByID(_context.DomainUrl);
			return GetResponseAsync<ResponseMessage<string>>(apiUrl, request.Convert2Json());
		}

		public Task<ResponseMessage<Dictionary<string, string>>> SelectByIDAsync(CustomDataGetByIDRequest request)
		{
			var apiUrl = AkmiiApiUrl.SelectByID(_context.DomainUrl);
			return GetResponseAsync<ResponseMessage<Dictionary<string, string>>>(apiUrl, request.Convert2Json());
		}

		public Task<ResponseMessage<CustomListItemResponse>> SelectJoinListTitleByIDAsync(CustomDataGetByIDRequest request)
		{
			var apiUrl = AkmiiApiUrl.SelectJoinListTitleByID(_context.DomainUrl);
			return GetResponseAsync<ResponseMessage<CustomListItemResponse>>(apiUrl, request.Convert2Json());
		}

		public Task<ResponseMessage<string>> RemoveBatchByIDsAsync(CustomDataRemvoeBatchRequest request)
		{
			var apiUrl = AkmiiApiUrl.RemoveBatchByIDs(_context.DomainUrl);
			return GetResponseAsync<ResponseMessage<string>>(apiUrl, request.Convert2Json());
		}

		public Task<ResponseMessage<string>> AddAsync(CustomDataAddRequest request)
		{
			var apiUrl = AkmiiApiUrl.Add(_context.DomainUrl);
			return GetResponseAsync<ResponseMessage<string>>(apiUrl, request.Convert2Json());
		}

		public Task<ResponseMessage<string>> EditAsync(CustomDataEditRequest request)
		{
			var apiUrl = AkmiiApiUrl.Edit(_context.DomainUrl);
			return GetResponseAsync<ResponseMessage<string>>(apiUrl, request.Convert2Json());
		}

		public Task<ResponseMessage<string>> AddBatchAsync(CustomDataAddBatchRequest request)
		{
			var apiUrl = AkmiiApiUrl.AddBatch(_context.DomainUrl);
			return GetResponseAsync<ResponseMessage<string>>(apiUrl, request.Convert2Json());
		}

		public Task<ResponseMessage<string>> EditBatchAsync(CustomDataEditBatchRequest request)
		{
			var apiUrl = AkmiiApiUrl.EditBatch(_context.DomainUrl);
			return GetResponseAsync<ResponseMessage<string>>(apiUrl, request.Convert2Json());
		}

		public Task<ResponseMessage<List<ResponseMessage<string>>>> AddBatchNoTransAsync(CustomDataAddBatchRequest request)
		{
			var apiUrl = AkmiiApiUrl.AddBatchNoTrans(_context.DomainUrl);
			return GetResponseAsync<ResponseMessage<List<ResponseMessage<string>>>>(apiUrl, request.Convert2Json());
		}

		public Task<ResponseMessage<string>> AddByTitleAsync(CustomDataAddByTitleRequest request)
		{
			var apiUrl = AkmiiApiUrl.AddByTitle(_context.DomainUrl);
			return GetResponseAsync<ResponseMessage<string>>(apiUrl, request.Convert2Json());
		}

		public Task<ResponseMessage<string>> AddBatchByTitleAsync(CustomDataAddBatchByTitleRequest request)
		{
			var apiUrl = AkmiiApiUrl.AddBatchByTitle(_context.DomainUrl);
			return GetResponseAsync<ResponseMessage<string>>(apiUrl, request.Convert2Json());
		}

		public Task<ResponseMessage<string>> EditByIDTitleAsync(CustomDataEditByTitleRequest request)
		{
			var apiUrl = AkmiiApiUrl.EditByIDTitle(_context.DomainUrl);
			return GetResponseAsync<ResponseMessage<string>>(apiUrl, request.Convert2Json());
		}

		public Task<ResponseMessage<string>> EditBatchByIDTitleAsync(CustomDataEditBatchByTitleRequest request)
		{
			var apiUrl = AkmiiApiUrl.EditBatchByIDTitle(_context.DomainUrl);
			return GetResponseAsync<ResponseMessage<string>>(apiUrl, request.Convert2Json());
		}

		public Task<ResponseMessage<string>> EditByTitleAsync(CustomDataEditByTitleWhereRequest request)
		{
			var apiUrl = AkmiiApiUrl.EditByTitle(_context.DomainUrl);
			return GetResponseAsync<ResponseMessage<string>>(apiUrl, request.Convert2Json());
		}

		public Task<ResponseMessage<string>> RemoveByTitleIDAsync(CustomDataRemvoeByTitleRequest request)
		{
			var apiUrl = AkmiiApiUrl.RemoveByTitleID(_context.DomainUrl);
			return GetResponseAsync<ResponseMessage<string>>(apiUrl, request.Convert2Json());
		}

		public Task<ResponseMessage<Dictionary<string, string>>> SelectByTitleIDAsync(CustomDataGetByIDTitleRequest request)
		{
			var apiUrl = AkmiiApiUrl.SelectByTitleID(_context.DomainUrl);
			return GetResponseAsync<ResponseMessage<Dictionary<string, string>>>(apiUrl, request.Convert2Json());
		}

		public Task<ResponseMessage<string>> RemoveBatchByTitleIDAsync(CustomDataRemvoeBatchByTitleRequest request)
		{
			var apiUrl = AkmiiApiUrl.RemoveBatchByTitleID(_context.DomainUrl);
			return GetResponseAsync<ResponseMessage<string>>(apiUrl, request.Convert2Json());
		}

		public Task<ResponseMessage<string>> ListBatchEditAsync(ListDataBatchEditRequest request)
		{
			var apiUrl = AkmiiApiUrl.ListBatchEdit(_context.DomainUrl);
			return GetResponseAsync<ResponseMessage<string>>(apiUrl, request.Convert2Json());
		}
	}
}