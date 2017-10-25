using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HJCCL.Services
{
    public class SysControlRepository:ISysControlRepository
    {
        /// <summary>
        /// 获取本地磁盘的目录的路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string GetPhysicalPath(string path)
        {
            string rootPath = Directory.GetParent(HttpContext.Current.Server.MapPath("")).FullName;
            if (path.Length != 0)
            {
                string[] pathList = path.Split('/');
                if (pathList.Length > 0)
                {
                    for (int i = 0; i < pathList.Length; i++)
                    {
                        rootPath =rootPath+ Path.Combine(pathList[i]);
                    }
                }
            }
            return rootPath;
        }
    }
}
