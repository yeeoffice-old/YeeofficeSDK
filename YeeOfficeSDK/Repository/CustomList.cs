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
        public Task<ResponseMessage<CustomListModel>> ListGetByListIDAsync(int appID, long listID)
        {
            var apiUrl = new AkmiiApiUrl
            {
                Method = "GET",
                Url = _context.DomainUrl + "/YeeOfficeSettings/_API/Ver(3.0)/api/crafts/list?appID=" + appID + "&listID=" + listID
            };
            return GetResponseAsync<ResponseMessage<CustomListModel>>(apiUrl, null);
        }

    }
}
