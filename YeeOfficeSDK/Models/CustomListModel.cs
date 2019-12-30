using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YeeOfficeSDK.Tools;

namespace YeeOfficeSDK.Models
{
    public class CustomListModel
    {
        /// <summary>
        /// 租户ID Index
        /// </summary>		
        [JsonConverter(typeof(Long2StringConverter))]
        public long TenantID { get; set; }
        /// <summary>
        /// ListID
        /// </summary>		
        [JsonConverter(typeof(Long2StringConverter))]
        public long ListID { get; set; }

        /// <summary>
        /// Title
        /// </summary>		
        public string Title { get; set; }

        /// <summary>
        /// Description
        /// </summary>		
        public string Description { get; set; }

        /// <summary>
        /// 1:启用 / 0:禁用
        /// </summary>		
        public int Status { get; set; }

        /// <summary>
        /// AppID
        /// </summary>		
        public int AppID { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string IconUrl { get; set; }

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
        public int MaxRole { get; set; }

        public int Flags { get; set; }
        public int Type { get; set; }

        public string CustomType { get; set; }

        public string LayoutView { get; set; }
        /// <summary>
        /// 开启版本记录
        /// </summary>
        public bool IsVerRecord { get; set; }
        /// <summary>
        /// 开启评论
        /// </summary>
        public bool HasComment { get; set; }
        public bool IsItemPerm { get; set; }
        public string WorkspaceID { get; set; }
        /// <summary>
        /// 是否断开继承
        /// </summary>
        public bool IsBreakInherit { get; set; }
        #region Advance 
        public List<ListAdvancePermModel> AdvanceList { get; set; } = new List<ListAdvancePermModel>();
        #endregion
    }
    public class ListAdvancePermModel
    {

        [JsonConverter(typeof(Long2StringConverter))]
        public long TenantID { get; set; }
        [JsonConverter(typeof(Long2StringConverter))]
        public long ListID { get; set; }
        public string PermObjID { get; set; }
        public int PermType { get; set; }
        public int Perm { get; set; }
        [JsonConverter(typeof(DateTime2IOSStringConverter))]
        public DateTime Created { get; set; }
        [JsonConverter(typeof(DateTime2IOSStringConverter))]
        public DateTime Modified { get; set; }
        [JsonConverter(typeof(Long2StringConverter))]
        public long CreatedBy { get; set; }
        [JsonConverter(typeof(Long2StringConverter))]
        public long ModifiedBy { get; set; }
        public string PermObjName { get; set; }
    }
}
