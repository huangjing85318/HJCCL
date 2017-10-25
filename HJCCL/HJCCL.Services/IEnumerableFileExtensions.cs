using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HJCCL.Services
{
    /// <summary>
    /// 
    /// </summary>
    public static class IEnumerableFileExtensions
    {
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
    }
}
