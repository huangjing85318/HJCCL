using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HJCCL.Services.SqlBuilder
{
    public class WhereCondition
    {
        public void AddCondition(string field, object value, SqlOperator sqlOperator, bool condition = true)
        {
            if (field.Length > 0)
            {
                if (value != null)
                {
                    if (sqlOperator == SqlOperator.Between)
                    {

                    }
                }
            }
        }
    }
}
