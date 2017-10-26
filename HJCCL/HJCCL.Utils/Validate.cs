using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HJCCL.Utils
{
   public  class Validate
    {
        /// <summary>
        /// 验证手机号码
        /// 移动:139,138,137,136,135,134,147,150,151,152,157,158,159,178,182,183,184,187,188  
        /// 联通:130,131,132,155,156,185,186,145,176  
        /// 电信:133,153,177,173,180,181,189 
        /// 虚拟运营商:170,171
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsMobileNumber(string value)
        {
            bool res = false;
            string reg = @"^(0|86|17951)?(13[0-9]|15[012356789]|17[013678]|18[0-9]|14[57])[0-9]{8}$";
            Regex rx = new Regex(reg);
            if (rx.IsMatch(value))
            {
                res = true;
            }
            return res;
        }
        /// <summary>
        /// 验证固话
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsTelephone(string value)
        {
            bool res = false;
            string reg = @"/^0?(13[0-9]|15[012356789]|17[013678]|18[0-9]|14[57])[0-9]{8}$/";
            Regex rx = new Regex(reg);
            if (rx.IsMatch(value))
            {
                res = true;
            }
            return res;
        }
        /// <summary>
        /// 验证邮箱
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsEmail(string value)
        {
            bool res = false;
            string reg = @"^\\s*([A-Za-z0-9_-]+(\\.\\w+)*@(\\w+\\.)+\\w{2,5})\\s*$";
            Regex rx = new Regex(reg);
            if (rx.IsMatch(value))
            {
                res = true;
            }
            return res;
        }

        /// <summary>
        /// 验证邮政编码
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsZipCode(string value)
        {
            bool res = false;
            string reg = @"^\d{6}$";
            Regex rx = new Regex(reg);
            if (rx.IsMatch(value))
            {
                res = true;
            }
            return res;
        }
        /// <summary>
        /// 是否是图片文件名
        /// </summary>
        /// <returns> </returns>
        public static bool IsImgFileName(string value)
        {
            if (value.IndexOf(".") == -1)
                return false;

            string tempFileName = value.Trim().ToLower();
            string extension = tempFileName.Substring(tempFileName.LastIndexOf("."));
            return extension == ".png" || extension == ".bmp" || extension == ".jpg" || extension == ".jpeg" || extension == ".gif";
        }

        /// <summary>
        /// 判断两个对象是否相等
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        public static bool IsEqual(object value1, object value2)
        {
            bool res = false;
            if (ConvertObject.ToDecimal(value1) > 0 && ConvertObject.ToDecimal(value2) > 0)
            {
                if (ConvertObject.ToDecimal(value1) == ConvertObject.ToDecimal(value2))
                    res = true;
            }
            else if (ConvertObject.ToString(value1).Length > 0 && ConvertObject.ToString(value2).Length > 0)
            {
                if (ConvertObject.ToString(value1).Equals(ConvertObject.ToString(value2)))
                    res = true;
            }
            return res;
        }


    }
}
