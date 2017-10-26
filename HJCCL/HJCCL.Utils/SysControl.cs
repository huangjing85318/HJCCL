using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using HJCCL.Utils.Common;

namespace HJCCL.Utils
{
    public class SysControl
    {
        #region GetAppSettings(获取AppSettings)
        /// <summary>
        /// 获取AppSettings
        /// </summary>
        /// <param name="key">键名</param>
        /// <returns></returns>
        public static string GetAppSettings(string key)
        {
            key.CheckNotNull("key");
            return ConfigurationManager.AppSettings[key];
        }
        #endregion

        #region GetType(获取类型)
        /// <summary>
        /// 获取类型,对可空类型进行处理
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <returns></returns>
        public static Type GetType<T>()
        {
            return Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);
        }
        #endregion
        /// <summary>
        /// 获取本地磁盘的目录的路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetPhysicalPath(string path)
        {
            string rootPath = Directory.GetParent(HttpContext.Current.Server.MapPath("")).FullName;
            if (path.Length != 0)
            {
                string[] pathList = path.Split('/');
                if (pathList.Length > 0)
                {
                    for (int i = 0; i < pathList.Length; i++)
                    {
                        rootPath = rootPath + Path.Combine(pathList[i]);
                    }
                }
            }
            return rootPath;
        }
    }
}
