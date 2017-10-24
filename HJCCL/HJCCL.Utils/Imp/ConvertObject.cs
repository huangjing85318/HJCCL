using HJCCL.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HJCCL.Utils
{
    public class ConvertObject :IConvertObject
    {
        private IConvertObjectRepository _convertObjectRepsoitory;

        public ConvertObject(IConvertObjectRepository convertObjectRepsoitory) {
            _convertObjectRepsoitory = convertObjectRepsoitory;
        }
        /// <summary>
        /// 对象转换成整型
        /// </summary>
        /// <param name="value">对象</param>
        /// <returns></returns>
        public int ToInt(object value)
        {
            return _convertObjectRepsoitory.ToInt(value);
        }
        /// <summary>
        /// 对象转换成字符串
        /// </summary>
        /// <param name="value">对象</param>
        /// <returns></returns>
        public  string ToString(object value)
        {
            return _convertObjectRepsoitory.ToString(value);
        }

        /// <summary>
        /// 对象转换成日期
        /// </summary>
        /// <param name="value">对象</param>
        /// <returns></returns>
        public  DateTime ToDateTime(object value)
        {
            return _convertObjectRepsoitory.ToDateTime(value);
        }

        /// <summary>
        /// 表格分页显示
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="beginPage">表示开始的页</param>
        /// <param name="endPage">endIndex</param>
        /// <param name="pageSize">表格分页记录数</param>
        /// <returns></returns>
        public  DataTable GetPagedTable(DataTable dt, int beginPage, int endPage, int pageSize)
        {
            return _convertObjectRepsoitory.GetPagedTable(dt,beginPage,endPage,pageSize);
        }

        /// <summary>
        /// 替换单引号
        /// </summary>
        /// <param name="value">对象</param>
        /// <returns></returns>
        public  string SafeStringModel(object value)
        {
            return _convertObjectRepsoitory.SafeStringModel(value);
        }

        /// <summary>
        /// 数字格式化
        /// 保留两位小数
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public  string AccountFormat(object value)
        {
            return _convertObjectRepsoitory.AccountFormat(value);
        }
        /// <summary>
        /// 转换成decimal
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public  decimal ToDecimal(object value)
        {
            return _convertObjectRepsoitory.ToDecimal(value);
        }

        /// <summary>
        /// 转换成double
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public  double ToDouble(object value)
        {
            return _convertObjectRepsoitory.ToDouble(value);
        }
        /// <summary>
        /// 转成Excel时间格式
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public  DateTime ToExcelDate(object value)
        {
            return _convertObjectRepsoitory.ToExcelDate(value);
        }
        /// <summary>
        /// 日期格式化
        /// dd/MM/yyyy(国外格式)
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public  string ToDateStringEn(object value)
        {
            return _convertObjectRepsoitory.ToDateStringEn(value);
        }
        /// <summary>
        /// 日期格式化
        /// yyyy-MM-dd(国内格式)
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public  string ToDateStringZh(object value)
        {
            return _convertObjectRepsoitory.ToDateStringZh(value);
        }
        /// <summary>
        /// 具体时间格式化
        /// dd/MM/yyyy HH:mm:ss
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public  string ToDateTimeStringEn(object value)
        {
            return _convertObjectRepsoitory.ToDateTimeStringEn(value);
        }
        /// <summary>
        /// 具体时间格式化
        /// yyyy-MM-dd HH:mm:ss
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public  string ToDateTimeStringZh(object value)
        {
            return _convertObjectRepsoitory.ToDateTimeStringZh(value);
        }
        /// <summary>
        /// 获取时分格式
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public  string ToTimeStr(object value)
        {
            return _convertObjectRepsoitory.ToTimeStr(value);
        }

    }
}
