using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YeeOfficeSDK.Models;

namespace YeeOfficeSDK.Repository
{
    public partial class AkmiiRepository
    {
        public Task<ResponseMessage<List<ListDefinitionModel>>> GetListDefByListIDAsync(int appID, long listID)
        {
            var apiUrl = AkmiiApiUrl.GetListDefByListID(_context.DomainUrl, appID, listID);
            return GetResponseAsync<ResponseMessage<List<ListDefinitionModel>>>(apiUrl, null);
        }
    }
}
