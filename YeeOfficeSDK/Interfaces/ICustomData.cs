using YeeOfficeSDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YeeOfficeSDK.Interfaces
{
    public partial interface IAkmiiRepository
    {
        Task<ResponseMessage<List<Dictionary<string, string>>>> SelectByListIDAsync(CustomDataGetListRequest request);

		Task<ResponseMessage<Dictionary<long, List<Dictionary<string, string>>>>> SelectByListIDsAsync(List<CustomDataGetListRequest> request);

		Task<ResponseMessage<List<Dictionary<string, string>>>> SelectByTitleAsync(CustomDataGetTitleRequest request);

		Task<ResponseMessage<List<Dictionary<string, string>>>> SelectByTitleSortsAsync(CustomDataGetTitleSortRequest request);

		Task<ResponseMessage<string>> SelectByListIDFirstAsync(CustomDataGetListDefaultRequest request);

		Task<ResponseMessage<List<Dictionary<string, string>>>> SelectByIDsAsync(CustomDataGetByIDsRequest request);

		Task<ResponseMessage<string>> RemoveByIDAsync(CustomDataRemvoeRequest request);

		Task<ResponseMessage<Dictionary<string, string>>> SelectByIDAsync(CustomDataGetByIDRequest request);

		Task<ResponseMessage<CustomListItemResponse>> SelectJoinListTitleByIDAsync(CustomDataGetByIDRequest request);

		Task<ResponseMessage<string>> RemoveBatchByIDsAsync(CustomDataRemvoeBatchRequest request);

		Task<ResponseMessage<string>> AddAsync(CustomDataAddRequest request);

		Task<ResponseMessage<string>> EditAsync(CustomDataEditRequest request);

		Task<ResponseMessage<string>> AddBatchAsync(CustomDataAddBatchRequest request);

		Task<ResponseMessage<string>> EditBatchAsync(CustomDataEditBatchRequest request);

		Task<ResponseMessage<List<ResponseMessage<string>>>> AddBatchNoTransAsync(CustomDataAddBatchRequest request);

		Task<ResponseMessage<string>> AddByTitleAsync(CustomDataAddByTitleRequest request);

		Task<ResponseMessage<string>> AddBatchByTitleAsync(CustomDataAddBatchByTitleRequest request);

		Task<ResponseMessage<string>> EditByIDTitleAsync(CustomDataEditByTitleRequest request);

		Task<ResponseMessage<string>> EditBatchByIDTitleAsync(CustomDataEditBatchByTitleRequest request);

		Task<ResponseMessage<string>> EditByTitleAsync(CustomDataEditByTitleWhereRequest request);

		Task<ResponseMessage<string>> RemoveByTitleIDAsync(CustomDataRemvoeByTitleRequest request);

		Task<ResponseMessage<Dictionary<string, string>>> SelectByTitleIDAsync(CustomDataGetByIDTitleRequest request);

		Task<ResponseMessage<string>> RemoveBatchByTitleIDAsync(CustomDataRemvoeBatchByTitleRequest request);

		Task<ResponseMessage<string>> ListBatchEditAsync(ListDataBatchEditRequest request);
	}
}
