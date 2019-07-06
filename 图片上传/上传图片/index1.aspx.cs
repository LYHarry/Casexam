using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UploadingFile
{
    public partial class index1 : System.Web.UI.Page
    {
        private string resultStr = "", relativePath = "";
        private long maxattachsize = (1024 * 1024 * 2);  // 最大上传大小，默认是2M  2097152
        private string upext = ".jpg,.jpeg,.gif,.png,.bmp"; // 充许上传的扩展名
        private HttpPostedFile files = null;
        private FileInfo file = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "text/html";
            Response.HeaderEncoding = Encoding.UTF8;

            string mod = Request.QueryString["action"] ?? "";
            mod = mod == "" ? (Request.Form["action"] ?? "") : mod;

            if (IsPostBack) { return; }

            if (mod == "uploadimg")
            {
                try
                {
                    //文件的保存路径
                    string _folder = Request.QueryString["folder"] ?? "comment";

                    if (Request.Files != null && Request.Files.Count > 0)
                    {
                        for (int i = 0; i < Request.Files.Count; i++)
                        {
                            files = Request.Files[i];
                            if (files == null || files.ContentLength < 1) //没有获取到File文件上传控件对象
                            {
                                resultStr += ("{status:-4,message:'上传过程中发生了意外',remark:'没有获取File上传控件对象'},");
                                continue;
                            }

                            //验证文件大小
                            if (files.ContentLength > maxattachsize)
                            {
                                resultStr += ("{status:-2,message:'上传过程中发生了意外',remark:'您上传的文件过大,允许最大文件为2M'},");
                                continue;
                            }

                            //获取要保存的文件信息
                            file = new FileInfo(files.FileName);
                            //获得文件扩展名，判断扩展名是否合法
                            if (!CheckImageExt(file.Extension.ToLower()))
                            {
                                resultStr += ("{status:-3,message:'上传过程中发生了意外',remark:'文件格式非法，请上传" + upext + "格式的文件'},");
                                continue;
                            }
                            //开始上传
                            relativePath = UpLoadImage(file.Extension, _folder);
                            resultStr += ("{status:1,message:'" + relativePath + "',remark:''},");
                        }
                    }
                    resultStr = "[" + resultStr.TrimEnd(',') + "]";
                }
                catch (ThreadAbortException) { }
                catch (Exception)
                {
                    resultStr = "[]";
                }
                Response.Write(resultStr);
                Response.End();
            }
        }


        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="fileName">图片的扩展名</param>
        /// <param name="savePath">保存路径</param>
        /// <returns>服务器上该图片的路径</returns>
        private string UpLoadImage(string fileNameExt, string savePath)
        {
            //得到保存文件夹的的磁盘路径
            string serverPath = HttpContext.Current.Server.MapPath(Path.Combine(@"/UploadFiles/", savePath));

            //判断存放文件夹是否存在，不存在则创建
            if (!Directory.Exists(serverPath))
            {
                Directory.CreateDirectory(serverPath);
            }

            //随机生成新的文件名
            string newFileName = GetNewImageName() + fileNameExt;
            //得到要保存的完整文件路径
            string serverFileName = Path.Combine(serverPath, newFileName);

            ///创建WebClient实例       
            WebClient myWebClient = new WebClient();
            //设定windows网络安全认证
            myWebClient.Credentials = CredentialCache.DefaultCredentials;

            //保存文件
            //files.SaveAs(serverFileName);

            //通过写入字节流的方式保存文件
            byte[] uploadFileBytes = new byte[files.ContentLength];
            files.InputStream.Read(uploadFileBytes, 0, files.ContentLength);
            File.WriteAllBytes(serverFileName, uploadFileBytes);

            //返回图片在服务器的存放路径
            return string.Format(@"/UploadFiles/{1}/{0}", newFileName, savePath);
        }


        /// <summary>
        /// 检查是否为合法的上传图片
        /// </summary>
        /// <param name="_fileExt">图片格式</param>
        /// <returns></returns>
        private bool CheckImageExt(string _ImageExt)
        {
            string[] allowExt = upext.Split(',');
            for (int i = 0; i < allowExt.Length; i++)
            {
                if (allowExt[i] == _ImageExt) { return true; }
            }
            return false;
        }

        /// <summary>
        /// 得到图片的新名称
        /// </summary>
        /// <returns></returns>
        private string GetNewImageName()
        {
            Random rd = new Random();
            StringBuilder serial = new StringBuilder();
            serial.Append(DateTime.Now.ToString("yyyyMMddHHmmssff"));
            serial.Append(rd.Next(0, 999999).ToString());
            return serial.ToString();
        }


    }
}