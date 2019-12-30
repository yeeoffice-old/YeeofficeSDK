using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YeeOfficeSDK.Tools;

namespace YeeOfficeSDK.Models
{
    class ListLayoutRequest
    {
    }
    public class ListLayoutGetRequest : BaseModel
    {
        public int AppID { get; set; }
        public long LayoutID { get; set; }
        public long ListID { get; set; }
    }
    public class ListLayoutResponse
    {
        /// <summary>
        /// 租户ID Index
        /// </summary>		
        [JsonConverter(typeof(Long2StringConverter))]
        public long TenantID { get; set; }
        /// <summary>
        /// LayoutID
        /// </summary>		
        [JsonConverter(typeof(Long2StringConverter))]
        public long LayoutID { get; set; }

        /// <summary>
        /// ListID
        /// </summary>		
        [JsonConverter(typeof(Long2StringConverter))]
        public long ListID { get; set; }

        /// <summary>
        /// 0:列表布局  1:表单布局
        /// </summary>		
        public int Type { get; set; }

        /// <summary>
        /// GroupNameJson
        /// </summary>		
        public string Title { get; set; }

        /// <summary>
        /// 将分割线也当作字段存储，使用字段类型区分(标准字段/自定义字段/分隔符字段)
        /// </summary>		
        public string LayoutView { get; set; }

        /// <summary>
        /// AppID
        /// </summary>		
        public int AppID { get; set; }

        /// <summary>
        /// Ext1
        /// </summary>		
        public string Ext1 { get; set; }

        /// <summary>
        /// Ext2
        /// </summary>		
        public string Ext2 { get; set; }

        /// <summary>
        /// Ext3
        /// </summary>		
        public string Ext3 { get; set; }

        public bool IsDefault { get; set; }

        public bool IsItemPerm { get; set; }
    }
}
