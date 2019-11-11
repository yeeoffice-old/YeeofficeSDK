using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YeeOfficeSDK.Interfaces
{
    public partial interface IAkmiiRepository
    {
        Task<ResponseMessage<string>> UploadFileToDocAsync(int appID, string code, string filePath);
        Task<ResponseMessage<string>> UploadFileToDocAsync(int appID, long libraryID, string filePath);
    }
}
