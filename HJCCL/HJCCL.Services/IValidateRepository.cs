using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HJCCL.Services
{
   public interface IValidateRepository
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
        bool IsMobileNumber(string value);
        /// <summary>
        /// 验证固话
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        bool IsTelephone(string value);
        /// <summary>
        /// 验证邮箱
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        bool IsEmail(string value);

        /// <summary>
        /// 验证邮政编码
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        bool IsZipCode(string value);
        /// <summary>
        /// 是否是图片文件名
        /// </summary>
        /// <returns> </returns>
        bool IsImgFileName(string value);

        /// <summary>
        /// 判断两个对象是否相等
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        bool IsEqual(object value1, object value2);
    }
}
