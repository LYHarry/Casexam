using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
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
    public partial class index4 : System.Web.UI.Page
    {
        private string resultStr = "";
        private long maxattachsize = (1024 * 1024 * 2);  // 最大上传大小，默认是2M  2097152
        private string upext = ".jpg,.jpeg,.gif,.png,.bmp"; // 充许上传的扩展名
        private HttpPostedFile files = null;

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

                    files = Request.Files[0];
                    if (files == null || files.ContentLength < 1) //没有获取到File文件上传控件对象
                    {
                        WriteResult(-4, "上传过程中发生了意外,没有获取File上传控件对象");
                    }

                    //验证文件大小
                    if (files.ContentLength > maxattachsize)
                    {
                        WriteResult(-2, "您上传的文件过大,允许最大文件为2M");
                    }

                    //开始上传
                    UpLoadImage(files.FileName, _folder);
                }
                catch (ThreadAbortException) { }
                catch (Exception ex)
                {
                    WriteResult(-4, "上传过程中发生了意外", ex.Message);
                }
                Response.End();
            }
            else if (mod == "upimg")
            {
                try
                {
                    //图片名称 base64表示方式
                    string imgname0 = Request.QueryString["imgbit0"] ?? "";
                    imgname0 = imgname0 == "" ? (Request.Form["imgbit0"] ?? "") : imgname0;
                    //保存路径
                    string savepath = Request.QueryString["path"] ?? "";
                    savepath = savepath == "" ? (Request.Form["path"] ?? "comment") : savepath;

                    if (imgname0.Length > 10)
                    {
                        resultStr = UploadFiles(imgname0, savepath);
                    }
                }
                catch (ThreadAbortException) { }
                catch (Exception ex)
                {
                    resultStr = ("{\"status\":-1,\"message\":\"上传过程中发生了意外\",\"remark\":\"" + ex.Message + "\"}");
                }
                Response.Write(resultStr);
                Response.End();
            }
        }


        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="base64">图片名称</param>
        /// <param name="savepath">保存路径</param>
        /// <returns></returns>
        private string UploadFiles(string base64, string savepath)
        {
            byte[] bt = Convert.FromBase64String(base64.Substring(base64.IndexOf(',') + 1));
            MemoryStream stream = new MemoryStream(bt);
            Bitmap bitmap = new Bitmap(stream);

            //得到保存文件夹的的磁盘路径
            string serverPath = HttpContext.Current.Server.MapPath(Path.Combine(@"/UploadFiles/", savepath));

            //判断存放文件夹是否存在，不存在则创建
            if (!Directory.Exists(serverPath))
            {
                Directory.CreateDirectory(serverPath);
            }
            //得到新的文件名
            string newFileName = GetNewImageName() + ".jpeg";
            //得到要保存的完整文件路径
            string serverFileName = Path.Combine(serverPath, newFileName);

            bitmap.Save(serverFileName, ImageFormat.Jpeg);

            return ("{\"status\":1,\"message\":\"" + string.Format(@"/UploadFiles/{1}/{0}", newFileName, savepath) + "\",\"remark\":\"\"}");
        }

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="fileName">图片名称</param>
        /// <param name="savePath">保存路径</param>
        /// <returns>服务器上该图片的路径</returns>
        private void UpLoadImage(string fileName, string savePath)
        {
            //得到保存文件夹的的磁盘路径
            string serverPath = HttpContext.Current.Server.MapPath(Path.Combine(@"/UploadFiles/", savePath));

            //判断存放文件夹是否存在，不存在则创建
            if (!Directory.Exists(serverPath))
            {
                Directory.CreateDirectory(serverPath);
            }

            //获取要保存的文件信息
            FileInfo file = new FileInfo(fileName);
            //获得文件扩展名
            string fileNameExt = file.Extension;
            //验证合法的文件
            if (CheckImageExt(fileNameExt.ToLower()))
            {
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
                string relativePath = string.Format(@"/UploadFiles/{1}/{0}", newFileName, savePath);

                WriteResult(1, relativePath);

            }//上传的图片格式不合法
            else
            {
                WriteResult(-3, string.Format("文件格式非法，请上传{0}格式的文件", upext));
            }
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

        /// <summary>
        /// 返回结果
        /// </summary>
        /// <param name="state">状态</param>
        /// <param name="message">返回信息</param>
        /// <param name="remark">备注</param>
        private void WriteResult(int state, string message, string remark = "")
        {
            string resultStr = ("{status:" + state + ",message:'" + message + "',remark:'" + remark + "'}");
            HttpContext.Current.Response.Write(resultStr);
            //HttpContext.Current.Response.End();
        }


    }
}