using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HJCCL.Services.SqlBuilder
{
    public enum SqlOperator
    {
        /// <summary>
        /// 范围
        /// </summary>
        [Description("范围")]
        Between,

        /// <summary>
        /// 
        /// </summary>
        [Description("等于")]
        Equal,


        /// <summary>
        /// 等于
        /// </summary>
        [Description("不等于")]
        NotEqual,

        /// <summary>
        /// 不等于
        /// </summary>
        [Description("大于")]
        GreaterThan,

        /// <summary>
        /// 不等于
        /// </summary>
        [Description("大于等于")]
        GreaterThanEqual,

        /// <summary>
        /// 包含
        /// </summary>
        [Description("包含")]
        In,

        /// <summary>
        /// 小于
        /// </summary>
        [Description("小于")]
        LessThan,

        /// <summary>
        /// 小于等于
        /// </summary>
        [Description("小于等于")]
        LessThanEqual,

        /// <summary>
        /// 模糊查找
        /// </summary>
        [Description("模糊查找")]
        Like,

        /// <summary>
        /// 左边模糊查找
        /// </summary>
        [Description("左边模糊查找")]
        LikeLeft,

        /// <summary>
        /// 右边模糊查找
        /// </summary>
        [Description("右边模糊查找")]
        LikeRight,

    }
}
