using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HJCCL.Domain.Response
{
    /// <summary>
    /// 
    /// </summary>
    public class UploadResult
    {
        /// <summary>
        /// 文件ID
        /// </summary>
        public string FileId { get; set; }

        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 文件路径
        /// </summary>
        public string FilePath { get; set; }
        /// <summary>
        /// 文件长度
        /// </summary>
        public long Length { get; set; }
        /// <summary>
        /// 文件类型
        /// </summary>
        public string Type { get; set; }
    }
}
