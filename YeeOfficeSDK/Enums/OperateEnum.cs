using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YeeOfficeSDK.Enums
{
    public enum OperateEnum
    {
        /// <summary>
        /// =0
        /// </summary>
        [Description("Eq")]
        Eq = 0,
        /// <summary>
        /// <=1
        /// </summary>
        [Description("Leq")]
        Leq = 1,
        /// <summary>
        /// >=2
        /// </summary>
        [Description("Geq")]
        Geq = 2,
        /// <summary>
        /// >3
        /// </summary>
        [Description("Gt")]
        Gt = 3,
        /// <summary>
        /// <4
        /// </summary>
        [Description("Lt")]
        Lt = 4,
        /// <summary>
        /// <> !=5
        /// </summary>
        [Description("Neq")]
        Neq = 5,
        /// <summary>
        /// IS NULL 6
        /// </summary>
        [Description("IsNull")]
        IsNull = 6,
        /// <summary>
        /// IS NOT NULL 7
        /// </summary>
        [Description("IsNotNull")]
        IsNotNull = 7,
        /// <summary>
        /// 8 like last
        /// </summary>
        [Description("StartsWith")]
        StartsWith = 8,
        /// <summary>
        /// 9
        /// </summary>
        [Description("In")]
        In = 9,
        /// <summary>
        /// 10
        /// </summary>
        [Description("Contains")]
        Contains = 10,
        /// <summary>
        /// 11 取当前用户
        /// </summary>
        [Description("Me")]
        Me = 11,
        /// <summary>
        /// 12 包含当前用户
        /// </summary>
        [Description("ContainsMe")]
        ContainsMe = 12,
        /// <summary>
        /// 13 模糊查询
        /// </summary>
        [Description("Like")]
        Like = 13,
        /// <summary>
        /// 14 匹配
        /// </summary>
        [Description("EndsWith")]
        EndsWith = 14,

        /// <summary>
        /// 15 in 关联
        /// </summary>
        [Description("InRelation")]
        InRelation = 15,
    }
}
