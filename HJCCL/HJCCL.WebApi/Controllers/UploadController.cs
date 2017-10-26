using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using HJCCL.Domain;
using HJCCL.Domain.Response;
using HJCCL.Utils;
using HJCCL.Utils.Impl;

namespace HJCCL.WebApi.Controllers
{
    public class UploadController : ApiController
    {
        /// <summary>
        /// 上传富文本框内容图片
        /// </summary>
        /// <returns></returns>
        [Upload]
        [HttpPost]
        public Task<UploadResult> UploadRichTextImg()
        {
            return Upload(Const.ImgPath.RichTextImg, "gif,jpg,jpeg,png,bmp");
        }

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <returns></returns>
        [Upload]
        [HttpPost]
        public Task<UploadResult> UploadImg()
        {
            return Upload(Const.ImgPath.Temp, "gif,jpg,jpeg,png,bmp");
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <returns></returns>
        [Upload]
        [HttpPost]
        public Task<UploadResult> UploadFile()
        {
            return Upload(Const.FilePath.Temp, ".xls");
        }
        /// <summary>
        /// 上传操作
        /// </summary>
        /// <param name="dirPath">目录路径</param>
        /// <param name="fileTypes">文件类型</param>
        /// <param name="maxFileSize">最大文件大小，默认10M</param>
        /// <returns></returns>
        protected Task<UploadResult> Upload(string dirPath, string fileTypes, long maxFileSize = 10000000)
        {
            if (!Request.Content.IsMimeMultipartContent("form-data"))
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
            string dirTempPath = SysControl.GetPhysicalPath(dirPath);
            if (!Directory.Exists(dirTempPath))
            {
                Directory.CreateDirectory(dirTempPath);
            }
            // 设置上传目录
            var provider = new MultipartFormDataStreamProvider(dirTempPath);
            var task = Request.Content.ReadAsMultipartAsync(provider).ContinueWith<UploadResult>(o =>
            {
                FileInfo fileInfo = null;
                try
                {
                    UploadResult result = new UploadResult();
                    // 判断文件数据
                    if (!(provider.FileData.Count > 0))
                    {
                        throw new Exception("上传失败，文件数据不存在!");
                    }
                    if (o.IsFaulted || o.IsCanceled)
                    {
                        throw new Exception("上传失败！");
                    }

                    var file = provider.FileData[0];
                    string oldFileName = file.Headers.ContentDisposition.FileName.TrimStart('"').TrimEnd('"');
                    fileInfo = new FileInfo(file.LocalFileName);
                    result.Length = fileInfo.Length;

                    if (fileInfo.Length <= 0)
                    {
                        throw new Exception("请选择上传文件！");
                    }
                    if (fileInfo.Length > maxFileSize)
                    {
                        throw new Exception("上传文件大小超过限制！");
                    }

                    var fileExt = oldFileName.Substring(oldFileName.LastIndexOf('.'));
                    if (fileExt==null ||
                        Array.IndexOf(fileTypes.Split(','), fileExt.Substring(1).ToLower()) == -1)
                    {
                        throw new Exception("不支持上传文件类型！");
                    }

                    string newFileName = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo);
                    string filePath = Path.Combine(dirPath, newFileName + fileExt);

                    fileInfo.CopyTo(Path.Combine(dirTempPath, newFileName + fileExt), true);

                    result.FileName = newFileName;
                    result.FilePath = filePath;
                    result.FileId = newFileName;
                    result.Type = FileControl.GetContentType(fileExt);
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception("上传失败！");
                }
                finally
                {
                    if (fileInfo != null)
                    {
                        fileInfo.Delete();
                    }
                }
            });
            return task;
        }
    }
}