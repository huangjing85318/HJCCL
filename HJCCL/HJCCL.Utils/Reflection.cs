using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HJCCL.Utils
{
    /// <summary>
    /// 反射操作帮助类
    /// </summary>
    public static partial class Reflection
    {
        #region GetAssembly(获取程序集)
        /// <summary>
        /// 获取程序集
        /// </summary>
        /// <param name="assemblyName">程序集名称</param>
        /// <returns></returns>
        public static Assembly GetAssembly(string assemblyName)
        {
            return Assembly.Load(assemblyName);
        }
        #endregion

        #region GetDescription(获取描述)
        /// <summary>
        /// 获取描述
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="memberName">成员名称</param>
        /// <returns></returns>
        public static string GetDescription<T>(string memberName)
        {
            return GetDescription(SysControl.GetType<T>(), memberName);
        }
        /// <summary>
        /// 获取描述
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="memberName">成员名称</param>
        /// <returns></returns>
        public static string GetDescription(Type type, string memberName)
        {
            if (type == null)
            {
                return string.Empty;
            }
            if (string.IsNullOrWhiteSpace(memberName))
            {
                return string.Empty;
            }
            return GetDescription(type.GetMember(memberName).FirstOrDefault());
        }
        /// <summary>
        /// 获取描述
        /// </summary>
        /// <param name="member">成员</param>
        /// <returns></returns>
        public static string GetDescription(MemberInfo member)
        {
            if (member == null)
            {
                return string.Empty;
            }
            var attribute =
                member.GetCustomAttributes(typeof(DescriptionAttribute), true).FirstOrDefault() as DescriptionAttribute;
            return attribute == null ? member.Name : attribute.Description;
        }
        #endregion

        #region IsBool(是否布尔类型)
        /// <summary>
        /// 是否布尔类型
        /// </summary>
        /// <param name="member">成员</param>
        /// <returns></returns>
        public static bool IsBool(MemberInfo member)
        {
            if (member == null)
            {
                return false;
            }
            switch (member.MemberType)
            {
                case MemberTypes.TypeInfo:
                    return member.ToString() == "System.Boolean";
                case MemberTypes.Property:
                    return IsBool((PropertyInfo)member);
            }
            return false;
        }
        /// <summary>
        /// 是否布尔类型
        /// </summary>
        /// <param name="property">属性</param>
        /// <returns></returns>
        public static bool IsBool(PropertyInfo property)
        {
            if (property.PropertyType == typeof(bool))
            {
                return true;
            }
            if (property.PropertyType == typeof(bool?))
            {
                return true;
            }
            return false;
        }

        #endregion

        #region IsEnum(是否枚举类型)
        /// <summary>
        /// 是否枚举类型
        /// </summary>
        /// <param name="member">成员</param>
        /// <returns></returns>
        public static bool IsEnum(MemberInfo member)
        {
            if (member == null)
            {
                return false;
            }
            switch (member.MemberType)
            {
                case MemberTypes.TypeInfo:
                    return ((TypeInfo)member).IsEnum;
                case MemberTypes.Property:
                    return IsEnum((PropertyInfo)member);
            }
            return false;
        }
        /// <summary>
        /// 是否枚举类型
        /// </summary>
        /// <param name="property">属性</param>
        /// <returns></returns>
        public static bool IsEnum(PropertyInfo property)
        {
            if (property.PropertyType.IsEnum)
            {
                return true;
            }
            var value = Nullable.GetUnderlyingType(property.PropertyType);
            if (value == null)
            {
                return false;
            }
            return value.IsEnum;
        }
        #endregion

        #region IsDate(是否日期类型)
        /// <summary>
        /// 是否日期类型
        /// </summary>
        /// <param name="member">成员</param>
        /// <returns></returns>
        public static bool IsDate(MemberInfo member)
        {
            if (member == null)
            {
                return false;
            }
            switch (member.MemberType)
            {
                case MemberTypes.TypeInfo:
                    return member.ToString() == "System.DateTime";
                case MemberTypes.Property:
                    return IsDate((PropertyInfo)member);
            }
            return false;
        }
        /// <summary>
        /// 是否日期类型
        /// </summary>
        /// <param name="property">属性</param>
        /// <returns></returns>
        public static bool IsDate(PropertyInfo property)
        {
            if (property.PropertyType == typeof(DateTime))
            {
                return true;
            }
            if (property.PropertyType == typeof(DateTime?))
            {
                return true;
            }
            return false;
        }
        #endregion

        #region IsInt(是否整型)
        /// <summary>
        /// 是否整型
        /// </summary>
        /// <param name="member">成员</param>
        /// <returns></returns>
        public static bool IsInt(MemberInfo member)
        {
            if (member == null)
            {
                return false;
            }
            switch (member.MemberType)
            {
                case MemberTypes.TypeInfo:
                    return member.ToString() == "System.Int32" || member.ToString() == "System.Int16" ||
                           member.ToString() == "System.Int64";
                case MemberTypes.Property:
                    return IsInt((PropertyInfo)member);
            }
            return false;
        }
        /// <summary>
        /// 是否整型
        /// </summary>
        /// <param name="property">属性</param>
        /// <returns></returns>
        private static bool IsInt(PropertyInfo property)
        {
            if (property.PropertyType == typeof(int))
            {
                return true;
            }
            if (property.PropertyType == typeof(int?))
            {
                return true;
            }
            if (property.PropertyType == typeof(short))
            {
                return true;
            }
            if (property.PropertyType == typeof(short?))
            {
                return true;
            }
            if (property.PropertyType == typeof(long))
            {
                return true;
            }
            if (property.PropertyType == typeof(long?))
            {
                return true;
            }
            return false;
        }
        #endregion

        #region IsNumber(是否数值类型)
        /// <summary>
        /// 是否数值类型
        /// </summary>
        /// <param name="member">成员</param>
        /// <returns></returns>
        public static bool IsNumber(MemberInfo member)
        {
            if (member == null)
            {
                return false;
            }
            switch (member.MemberType)
            {
                case MemberTypes.TypeInfo:
                    return member.ToString() == "System.Double" || member.ToString() == "System.Decimal" ||
                           member.ToString() == "System.Single";
                case MemberTypes.Property:
                    return IsNumber((PropertyInfo)member);
            }
            return false;
        }
        /// <summary>
        /// 是否数值类型
        /// </summary>
        /// <param name="property">属性</param>
        /// <returns></returns>
        private static bool IsNumber(PropertyInfo property)
        {
            if (property.PropertyType == typeof(double))
            {
                return true;
            }
            if (property.PropertyType == typeof(double?))
            {
                return true;
            }
            if (property.PropertyType == typeof(decimal))
            {
                return true;
            }
            if (property.PropertyType == typeof(decimal?))
            {
                return true;
            }
            if (property.PropertyType == typeof(float))
            {
                return true;
            }
            if (property.PropertyType == typeof(float?))
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
