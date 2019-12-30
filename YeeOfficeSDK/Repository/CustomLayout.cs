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
        public Task<ResponseMessage<ListLayoutResponse>> GetListLayoutAsync(ListLayoutGetRequest request)
        {
            var apiUrl = new AkmiiApiUrl
            {
                Method = "GET",
                Url = _context.DomainUrl + "/YeeOfficeSettings/_API/Ver(3.0)/api/crafts/layouts"
            };
            return GetResponseAsync<ResponseMessage<ListLayoutResponse>>(apiUrl, request.ToString());
        }

    }
}
