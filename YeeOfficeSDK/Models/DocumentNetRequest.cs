using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YeeOfficeSDK.Models
{
    public class DocumentNetRequest
    {
    }
    public class DocumentLibraryGetByCodeRequest
    {
        public int AppID { get; set; }

        public string Code { get; set; }
    }
    public class DocumentLibraryResponse
    {
        /// <summary>
        /// 应用ID
        /// </summary>
        public int AppID { get; set; }
        /// <summary>
        /// 文档库ID
        /// </summary>
        public long LibraryID { get; set; }
        /// <summary>
        /// 用作各个模块的附件库，其他的文档库都为空
        /// </summary>
        public string Code { get; set; } = string.Empty;
    }
    public class DocumentAddRequest
    {
        public int AppID { get; set; }

        public string LibraryID { get; set; }

        public string ParentID { get; set; } = "0";

        public long ContentLength { get; set; }

        public string Name { get; set; }

        public string Extension { get; set; }

        public string MD5 { get; set; }

        public int Type { get; set; } = 1;

        public bool OverWrite { get; set; }
    }

    public class BeginUploadRequest
    {
        public int AppID { get; set; }

        public string MD5 { get; set; }

        public string FileName { get; set; }

        public string FileExtension { get; set; }

        public long Length { get; set; }

        public long ChunkSize { get; set; }
    }
    public class BeginUploadResponse
    {
        public string FileID { get; set; }
        // ready | success
        public string Progress { get; set; }
    }
    public class ChunkUploadRequest
    {
        public long FileID { get; set; }
    }
}
