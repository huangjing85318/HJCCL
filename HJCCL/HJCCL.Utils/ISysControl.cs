using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HJCCL.Utils
{
    public interface ISysControl
    {
        /// <summary>
        /// 获取本地磁盘的目录的路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        string GetPhysicalPath(string path);
    }
}

