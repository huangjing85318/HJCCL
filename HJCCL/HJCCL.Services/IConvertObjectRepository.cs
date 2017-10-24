using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HJCCL.Services
{
    public interface IConvertObjectRepository
    {
        /// <summary>
        /// 对象转换成整型
        /// </summary>
        /// <param name="value">对象</param>
        /// <returns></returns>
         int ToInt(object value);
        /// <summary>
        /// 对象转换成字符串
        /// </summary>
        /// <param name="value">对象</param>
        /// <returns></returns>
        string ToString(object value);

        /// <summary>
        /// 对象转换成日期
        /// </summary>
        /// <param name="value">对象</param>
        /// <returns></returns>
        DateTime ToDateTime(object value);

        /// <summary>
        /// 表格分页显示
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="beginPage">表示开始的页</param>
        /// <param name="endPage">endIndex</param>
        /// <param name="pageSize">表格分页记录数</param>
        /// <returns></returns>
        DataTable GetPagedTable(DataTable dt, int beginPage, int endPage, int pageSize);
        /// <summary>
        /// 替换单引号
        /// </summary>
        /// <param name="value">对象</param>
        /// <returns></returns>
        string SafeStringModel(object value);

        /// <summary>
        /// 数字格式化
        /// 保留两位小数
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        string AccountFormat(object value);
        
        /// <summary>
        /// 转换成decimal
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        decimal ToDecimal(object value);

        /// <summary>
        /// 转换成double
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
       double ToDouble(object value);
        /// <summary>
        /// 转成Excel时间格式
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        DateTime ToExcelDate(object value);
        /// <summary>
        /// 日期格式化
        /// dd/MM/yyyy(国外格式)
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        string ToDateStringEn(object value);
        /// <summary>
        /// 日期格式化
        /// yyyy-MM-dd(国内格式)
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        string ToDateStringZh(object value);
        /// <summary>
        /// 具体时间格式化
        /// dd/MM/yyyy HH:mm:ss
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        string ToDateTimeStringEn(object value);
        /// <summary>
        /// 具体时间格式化
        /// yyyy-MM-dd HH:mm:ss
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        string ToDateTimeStringZh(object value);
        /// <summary>
        /// 获取时分格式
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        string ToTimeStr(object value);
    }
}
