
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HJCCL.Utils
{
    public class ConvertObject
    {

        /// <summary>
        /// 对象转换成整型
        /// </summary>
        /// <param name="value">对象</param>
        /// <returns></returns>
        public static int ToInt(object value)
        {
            int res = 0;
            res = value == null ? 0 : Convert.ToInt32(value);
            return res;
        }
        /// <summary>
        /// 对象转换成字符串
        /// </summary>
        /// <param name="value">对象</param>
        /// <returns></returns>
        public static string ToString(object value)
        {
            string res = "";
            res = value == null ? String.Empty : value.ToString();
            return res;
        }

        /// <summary>
        /// 对象转换成日期
        /// </summary>
        /// <param name="value">对象</param>
        /// <returns></returns>
        public static DateTime ToDateTime(object value)
        {
            DateTime res = DateTime.Now;
            try
            {
                if (value != null)
                {
                    res = DateTime.ParseExact(value.ToString(), "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
                }
            }
            catch (Exception e)
            {
                throw new Exception("格式不正确");
            }

            return res;
        }

        /// <summary>
        /// 表格分页显示
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="beginPage">表示开始的页</param>
        /// <param name="endPage">endIndex</param>
        /// <param name="pageSize">表格分页记录数</param>
        /// <returns></returns>
        public static DataTable GetPagedTable(DataTable dt, int beginPage, int endPage, int pageSize)
        {
            if (beginPage == 0)
                return dt;//0页代表每页数据，直接返回

            DataTable newTab = dt.Copy();
            newTab.Clear();//copy dt的框架

            int rowBegin = beginPage * pageSize;
            int rowEnd = endPage * pageSize;

            if (rowBegin >= dt.Rows.Count)
                return newTab;//源数据记录数小于等于要显示的记录，直接返回dt

            if (rowEnd > dt.Rows.Count)
                rowEnd = dt.Rows.Count;
            for (int i = rowBegin; i <= rowEnd - 1; i++)
            {
                DataRow newRow = newTab.NewRow();
                DataRow dr = dt.Rows[i];
                foreach (DataColumn column in dt.Columns)
                {
                    newRow[column.ColumnName] = dr[column.ColumnName];
                }
                newTab.Rows.Add(newRow);
            }
            return newTab;
        }

        /// <summary>
        /// 替换单引号
        /// </summary>
        /// <param name="value">对象</param>
        /// <returns></returns>
        public static string SafeStringModel(object value)
        {
            string res = "";
            try
            {
                res = value.ToString();
                res = res.Replace("'", " ");
            }
            catch
            {
                res = String.Empty;
            }
            if (res.Length == 0)
                res = " ";
            return res;
        }

        /// <summary>
        /// 数字格式化
        /// 保留两位小数
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string AccountFormat(object value)
        {
            decimal d = ToDecimal(value);
            if (d == 1)
                return "";
            string v = string.Format("{0:#,##0.00}", d);
            return v;
        }
        /// <summary>
        /// 转换成decimal
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static decimal ToDecimal(object value)
        {
            decimal dec = 0;
            try
            {
                dec = Convert.ToDecimal(value);
            }
            catch
            {
                dec = 0;
            }
            return dec;
        }

        /// <summary>
        /// 转换成double
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static double ToDouble(object value)
        {
            double dec = 0;
            try
            {
                dec = Convert.ToDouble(value);
            }
            catch
            {
                dec = 0;
            }
            return dec;
        }
        /// <summary>
        /// 转成Excel时间格式
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static DateTime ToExcelDate(object value)
        {
            TimeSpan res = new TimeSpan(Convert.ToInt32(value) - 2, 0, 0, 0);
            DateTime d = new DateTime(1900, 1, 1).Add(res);
            return d;
        }
        /// <summary>
        /// 日期格式化
        /// dd/MM/yyyy(国外格式)
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string ToDateStringEn(object value)
        {
            string res = "";
            try
            {
                DateTime dt = Convert.ToDateTime(value);
                if (dt > new DateTime(2000, 1, 1))
                    res = string.Format("{0:dd/MM/yyyy}", dt);
            }
            catch { }

            return res;
        }
        /// <summary>
        /// 日期格式化
        /// yyyy-MM-dd(国内格式)
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string ToDateStringZh(object value)
        {
            string res = "";
            try
            {
                DateTime dt = Convert.ToDateTime(value);
                if (dt > new DateTime(2000, 1, 1))
                    res = string.Format("{0:yyyy-MM-dd}", dt);
            }
            catch { }

            return res;
        }
        /// <summary>
        /// 具体时间格式化
        /// dd/MM/yyyy HH:mm:ss
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string ToDateTimeStringEn(object value)
        {
            string res = "";
            try
            {
                DateTime dt = Convert.ToDateTime(value);
                if (dt > new DateTime(2000, 1, 1))
                    res = string.Format("{0:dd/MM/yyyy HH:mm:ss}", dt);
            }
            catch { }

            return res;
        }
        /// <summary>
        /// 具体时间格式化
        /// yyyy-MM-dd HH:mm:ss
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string ToDateTimeStringZh(object value)
        {
            string res = "";
            try
            {
                DateTime dt = Convert.ToDateTime(value);
                if (dt > new DateTime(2000, 1, 1))
                    res = string.Format("{0:yyyy-MM-dd HH:mm:ss}", dt);
            }
            catch { }

            return res;
        }
        /// <summary>
        /// 获取时分格式
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToTimeStr(object value)
        {
            string s = "";
            try
            {
                DateTime exDate = Convert.ToDateTime(value);
                if (exDate > new DateTime(2000, 1, 1))
                    s = string.Format("{0:HH:mm}", exDate);
            }
            catch { }

            return s;
        }
    }
}
