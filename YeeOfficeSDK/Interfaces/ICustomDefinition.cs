using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YeeOfficeSDK.Models;

namespace YeeOfficeSDK.Interfaces
{
    public partial interface IAkmiiRepository
    {
        Task<ResponseMessage<List<ListDefinitionModel>>> GetListDefByListIDAsync(int appID, long listID);
    }
}
