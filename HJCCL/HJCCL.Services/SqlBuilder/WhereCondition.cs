using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HJCCL.Services.SqlBuilder
{
    public class WhereCondition
    {
        public WhereCondition()
        {
            
        }

        private string whereStr;

        public string WhereStr
        {
            set { whereStr = value; }
        }

        #region AddCondition(where条件语句判断)
        /// <summary>
        /// where条件语句判断
        /// </summary>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <param name="sqlOperator"></param>
        /// <param name="condition"></param>
        public void AddCondition(string field, object value, SqlOperator sqlOperator, bool condition = true)
        {
            if (field.Length > 0)
            {
                if (value != null)
                {
                    #region 逻辑判断
                    if (sqlOperator.Equals(SqlOperator.Between))//两者之间
                    {
                        whereStr = field + " between " + value;
                    }
                    else if (sqlOperator.Equals(SqlOperator.Equal))//等于
                    {
                        whereStr = field + " = " + value;
                    }
                    else if (sqlOperator.Equals(SqlOperator.NotEqual))//不等于
                    {
                        whereStr = field + " != " + value;
                    }
                    else if (sqlOperator.Equals(SqlOperator.GreaterThan))//大于
                    {
                        whereStr = field + " > " + value;
                    }
                    else if (sqlOperator.Equals(SqlOperator.GreaterThanEqual))//大于等于
                    {
                        whereStr = field + " >= " + value;
                    }
                    else if (sqlOperator.Equals(SqlOperator.LessThan))//小于
                    {
                        whereStr = field + " < " + value;
                    }
                    else if (sqlOperator.Equals(SqlOperator.LessThanEqual))//小于等于
                    {
                        whereStr = field + " <= " + value;
                    }
                    else if (sqlOperator.Equals(SqlOperator.Like))//模糊查询
                    {
                        whereStr = field + " like '%" + value + "%'";
                    }
                    else if (sqlOperator.Equals(SqlOperator.LikeLeft))//左侧模糊
                    {
                        whereStr = field + " like '%" + value + "'";
                    }
                    else if (sqlOperator.Equals(SqlOperator.LikeRight))//右侧模糊
                    {
                        whereStr = field + " like '" + value+"%'";
                    }
                    else if (sqlOperator.Equals(SqlOperator.In))//包含
                    {
                        whereStr = field + " in (" + value+")";
                    }
                    #endregion
                }
            }
        }
        #endregion
    }
}
