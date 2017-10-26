using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HJCCL.Utils
{
    public class FileControl
    {
        #region GetContentType(根据扩展名获取文件内容类型)
        /// <summary>
        /// 根据扩展名获取文件内容类型
        /// </summary>
        /// <param name="extension">扩展名</param>
        /// <returns></returns>
        public static string GetContentType(string extension)
        {
            string contentType = "";
            var dict = Const.FileExtensionDict;
            extension = extension.ToLower();
            if (!extension.StartsWith("."))
            {
                extension = "." + extension;
            }
            dict.TryGetValue(extension, out contentType);
            return contentType;
        }
        #endregion
    }
}
