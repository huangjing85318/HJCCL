using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HJCCL.Services;

namespace HJCCL.Utils.Impl
{
    public class SysControl:ISysControl
    {
        private ISysControlRepository _sysControlRepository;

        public SysControl(ISysControlRepository sysControlRepository)
        {
            _sysControlRepository = sysControlRepository;
        }
        /// <summary>
        /// 获取本地磁盘的目录的路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string GetPhysicalPath(string path)
        {
            return _sysControlRepository.GetPhysicalPath(path);
        }
    }
}
