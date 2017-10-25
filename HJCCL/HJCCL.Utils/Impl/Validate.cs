using HJCCL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HJCCL.Utils
{
   public  class Validate: IValidate
    {
        public IValidateRepository _validateRepository;

        public Validate(IValidateRepository validateRepository) {
            _validateRepository = validateRepository;
        }
        /// <summary>
        /// 验证手机号码
        /// 移动:139,138,137,136,135,134,147,150,151,152,157,158,159,178,182,183,184,187,188  
        /// 联通:130,131,132,155,156,185,186,145,176  
        /// 电信:133,153,177,173,180,181,189 
        /// 虚拟运营商:170,171
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public  bool IsMobileNumber(string value)
        {
            return _validateRepository.IsMobileNumber(value);
        }
        /// <summary>
        /// 验证固话
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public  bool IsTelephone(string value)
        {
            return _validateRepository.IsTelephone(value);
        }
        /// <summary>
        /// 验证邮箱
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public  bool IsEmail(string value)
        {
            return _validateRepository.IsEmail(value);
        }

        /// <summary>
        /// 验证邮政编码
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public  bool IsZipCode(string value)
        {
            return _validateRepository.IsZipCode(value);
        }
        /// <summary>
        /// 是否是图片文件名
        /// </summary>
        /// <returns> </returns>
        public  bool IsImgFileName(string value)
        {
            return _validateRepository.IsImgFileName(value);
        }

        /// <summary>
        /// 判断两个对象是否相等
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        public  bool IsEqual(object value1,object value2)
        {
            return _validateRepository.IsEqual(value1, value2); 
        }


    }
}
