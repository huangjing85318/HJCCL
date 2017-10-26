using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

        #region 文件下载类
        /// <summary>
        /// 文件下载类
        /// </summary>
        /// <param name="url">文件地址</param>
        /// <param name="filePath">文件保存的路径</param>
        /// <param name="fileName">文件名</param>
        public static bool Download(string url, string filePath,string fileName)
        {
            string loadFile = filePath + fileName;
            string tempPath = System.IO.Path.GetDirectoryName(loadFile) +@"\temp";
            System.IO.Directory.CreateDirectory(tempPath); //创建临时文件目录
            string tempFile = tempPath + @"\" + System.IO.Path.GetFileName(fileName) + ".temp"; //临时文件
            if (System.IO.File.Exists(tempFile))
            {
                System.IO.File.Delete(tempFile); //存在则删除
            }
            try
            {
                FileStream fs = new FileStream(tempFile, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                // 设置参数
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                //发送请求并获取相应回应数据
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //直到request.GetResponse()程序才开始向目标网页发送Post请求
                Stream responseStream = response.GetResponseStream();
                //创建本地文件写入流
                //Stream stream = new FileStream(tempFile, FileMode.Create);
                byte[] bArr = new byte[1024];
                int size = responseStream.Read(bArr, 0, (int)bArr.Length);
                while (size > 0)
                {
                    //stream.Write(bArr, 0, size);
                    fs.Write(bArr, 0, size);
                    size = responseStream.Read(bArr, 0, (int)bArr.Length);
                }
                //stream.Close();
                fs.Close();
                responseStream.Close();
                System.IO.File.Move(tempFile, filePath);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion
    }
}
