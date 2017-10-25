using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HJCCL.Utils
{
    /// <summary>
    /// 
    /// </summary>
    public static class IEnumerableNpoiExtensions
    {

        #region 实体类 数据源
        /// <summary>
        /// 导出Excel文件
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="source">数据源</param>
        /// <param name="excelFile">文件路径</param>
        /// <param name="sheetName">工作表名</param>
        public static void ToExcel<T>(this IEnumerable<T> source, string excelFile, string sheetName = "sheet0")
            where T : class
        {

        }
        #endregion

        #region DataTable 数据源
        /// <summary>
        /// 导出Excel文件
        /// </summary>
        /// <typeparam name="dt">数据源</typeparam>
        /// <param name="excelFile">文件路径</param>
        /// <param name="sheetName">工作表名</param>
        public static void ToExcel(this DataTable dt, string excelFile, string sheetName = "sheet0")
        {

        }
        #endregion

    }
}
