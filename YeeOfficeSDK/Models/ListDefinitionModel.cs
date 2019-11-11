using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YeeOfficeSDK.Tools;

namespace YeeOfficeSDK.Models
{
    public class ListDefinitionModel : BaseModel
    {
        /// <summary>
        /// FieldID
        /// </summary>		
        [JsonConverter(typeof(Long2StringConverter))]
        public long FieldID { get; set; }

        /// <summary>
        /// ListID
        /// </summary>		
        [JsonConverter(typeof(Long2StringConverter))]
        public long ListID { get; set; }

        /// <summary>
        /// FieldName
        /// </summary>		
        public string FieldName { get; set; }

        public string FieldType { get; set; }

        public int FieldIndex { get; set; }

        /// <summary>
        /// DisplayName
        /// </summary>		
        public string DisplayName { get; set; }
        /// <summary>
        /// 内部名
        /// </summary>
        public string InternalName { get; set; }

        /// <summary>
        /// 短文本 | 长文本 |  数字 |  时间 |  Metadata  |  Lookup  | User  |  Choice | Currency | YesNo |  hyperlink | Picture
        /// </summary>		
        public string Type { get; set; }

        /// <summary>
        /// 状态 
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 0:标准字段  1:自定义字段 
        /// </summary>		
        public int Category { get; set; }

        /// <summary>
        /// DefaultValue
        /// </summary>		
        public string DefaultValue { get; set; }

        /// <summary>
        /// 根据字段类型使用Json存储规则
        /// </summary>		
        public string Rules { get; set; }

        /// <summary>
        /// TenantID
        /// </summary>		
        [JsonConverter(typeof(Long2StringConverter))]
        public long TenantID { get; set; }

        /// <summary>
        /// AppID
        /// </summary>		
        public int AppID { get; set; }

        /// <summary>
        /// 是否允许排序
        /// </summary>		
        public bool IsSort { get; set; }

        /// <summary>
        /// 是否可以搜索
        /// </summary>		
        public bool IsIndex { get; set; }

        /// <summary>
        /// 是否过滤
        /// </summary>		
        public bool IsFilter { get; set; }

        /// <summary>
        /// 是否创建索引
        /// </summary>		
        public bool IsIndexCreated { get; set; }

        /// <summary>
        /// 是否为基本字段
        /// </summary>
        public bool IsSystem { get; set; }

        public bool IsUnique { get; set; }

        /// <summary>
        /// Created
        /// </summary>		
        public DateTime Created { get; set; }

        /// <summary>
        /// on update CURRENT_TIMESTAMP(3)
        /// </summary>		
        public DateTime Modified { get; set; }

        /// <summary>
        /// CreatedBy
        /// </summary>		
        public long CreatedBy { get; set; }

        /// <summary>
        /// ModifiedBy
        /// </summary>		
        public long ModifiedBy { get; set; }

        /// <summary>
        /// Ext1  用于内容启动流程存放defkey
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

        #region rules resovle
        private Dictionary<string, object> _rulesDic;
        [JsonIgnore]
        public Dictionary<string, object> RulesDic
        {
            get
            {
                if (_rulesDic == null)
                {
                    if (string.IsNullOrWhiteSpace(Rules))
                    {
                        _rulesDic = new Dictionary<string, object>();
                    }
                    else
                    {
                        try
                        {
                            _rulesDic = JsonHelper.DeserializeJsonTo<Dictionary<string, object>>(Rules);
                        }
                        catch (Exception)
                        {
                            _rulesDic = new Dictionary<string, object>();
                        }
                    }
                }
                return _rulesDic;
            }
        }
        private bool? _isRequired = null;
        [JsonIgnore]
        public bool IsRequired
        {
            get
            {
                if (_isRequired == null)
                {
                    _isRequired = RulesDic.ContainsKey("required") && RulesDic["required"].Convert2Boolean();
                }

                return _isRequired.Value;
            }
        }
        private bool? _isMultiple = null;
        [JsonIgnore]
        public bool IsMultiple
        {
            get
            {
                if (_isMultiple == null)
                {
                    _isMultiple = RulesDic.ContainsKey("multiple") && RulesDic["multiple"].Convert2Boolean();
                }

                return _isMultiple.Value;
            }
        }
        #endregion
    }
}
