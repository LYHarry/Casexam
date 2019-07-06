using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UploadingFile
{
    public partial class index3 : System.Web.UI.Page
    {
        private string resultStr = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "text/html";
            Response.HeaderEncoding = Encoding.UTF8;

            string mod = Request.QueryString["action"] ?? "";
            mod = mod == "" ? (Request.Form["action"] ?? "") : mod;

            if (IsPostBack) { return; }

            if (mod == "upimg")
            {
                try
                {
                    //图片名称 base64表示方式
                    string imgname0 = Request.QueryString["imgbits"] ?? "";
                    imgname0 = imgname0 == "" ? (Request.Form["imgbits"] ?? "") : imgname0;
                    //保存路径
                    string savepath = Request.QueryString["path"] ?? "";
                    savepath = savepath == "" ? (Request.Form["path"] ?? "comment") : savepath;

                    List<UploadFileImg> upImgs = JsonHelper.FromJSON<List<UploadFileImg>>(imgname0);

                    if (upImgs != null && upImgs.Count > 0)
                    {
                        for (int j = 0; j < upImgs.Count; j++)
                        {
                            if (upImgs[j].base64.Length < 10)
                            {
                                resultStr += ("{\"status\":-2,\"message\":\"上传过程中发生了意外\",\"remark\":\"图片错误\"},");
                            }

                            resultStr += UploadFiles(upImgs[j].base64, savepath);
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

            return ("{\"status\":1,\"message\":\"" + string.Format(@"/UploadFiles/{1}/{0}", newFileName, savepath) + "\",\"remark\":\"\"},");
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


    /// <summary>
    /// 上传图片帮助类
    /// </summary>
    public class UploadFileImg
    {
        /// <summary>
        /// 图片名称
        /// </summary>
        public string base64 { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }

}