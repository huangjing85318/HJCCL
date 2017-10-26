using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Reflection;

namespace HJCCL.Utils.Common
{
   public static class EnumUtil
    {
        #region GetName(获取成员名)
        /// <summary>
        /// 获取成员名
        /// </summary>
        /// <typeparam name="T">枚举</typeparam>
        /// <param name="member">成员名、值、实例均可,范例:Enum1枚举有成员A=0,则传入Enum1.A或0,获取成员名"A"</param>
        /// <returns></returns>
        public static string GetName<T>(object member)
        {
            return GetName(SysControl.GetType<T>(), member);
        }
        /// <summary>
        /// 获取成员名
        /// </summary>
        /// <param name="type">枚举类型</param>
        /// <param name="member">成员名、值、实例均可</param>
        /// <returns></returns>
        public static string GetName(Type type, object member)
        {
            if (type == null)
            {
                return string.Empty;
            }
            if (member == null)
            {
                return string.Empty;
            }
            if (member is string)
            {
                return member.ToString();
            }
            if (type.IsEnum == false)
            {
                return string.Empty;
            }
            return EnumUtil.GetName(type, member);
        }

        #endregion
        #region GetDescription(获取描述)
        /// <summary>
        /// 获取描述
        /// </summary>
        /// <typeparam name="T">枚举</typeparam>
        /// <param name="member"></param>
        /// <returns></returns>
        public static string GetDescription<T>(object member)
        {
            return Reflection.GetDescription<T>(GetName<T>(member));
        }
        /// <summary>
        /// 获取描述
        /// </summary>
        /// <param name="type">枚举类型</param>
        /// <param name="member"></param>
        /// <returns></returns>
        public static string GetDescription(Type type, object member)
        {
            return Reflection.GetDescription(type, GetName(type, member));
        }
        #endregion
    }
}
