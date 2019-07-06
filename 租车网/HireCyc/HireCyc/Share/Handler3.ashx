<%@ WebHandler Language="C#" Class="Handler3" %>

using System;
using System.Web;
using System.IO;

public class Handler3 : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/html";

        string path = context.Request.Files["file"].FileName;

        ShowUploadImg(context, path); //调用上传图片的方法
        SaveData(context);  //调用图片保存数据库方法
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

    /// <summary>
    /// 上传图片到服务器
    /// </summary>
    /// <param name="context">图片的对象</param>
    /// <param name="path">图片名称</param>
    private void ShowUploadImg(HttpContext context, string path)
    {
        string toFilePath = HttpContext.Current.Server.MapPath(@"~/Images/Upload/");
        // 如果没有该目录则创建该上传目录
        if (!Directory.Exists(toFilePath))
        {
            Directory.CreateDirectory(toFilePath);
        }
        string exten = Path.GetExtension(path);  //得到文件扩展名
        string newName = Guid.NewGuid().ToString();  //得到新文件名
        string newFullName = newName + exten;  //得到完整文件名
        string newFileFullPath = toFilePath + newFullName;  //得到文件的物理路径
        context.Request.Files["file"].SaveAs(newFileFullPath);

        string src = "Images/Upload/" + newFullName;
        context.Response.Write(src);
    }


    /// <summary>
    /// 图片保存数据库
    /// </summary>
    /// <param name="content">图片对象</param>
    private void SaveData(HttpContext content)
    {
        try
        {
            string username = content.Session["username"].ToString();
            int fileLength = content.Request.Files["file"].ContentLength;
            byte[] fileContent = new byte[fileLength];
            Stream s = content.Request.Files["file"].InputStream;
            s.Read(fileContent, 0, fileLength);
            BLL.UserInfoBusiness.UpdatePhoto(username, s);
        }
        catch (Exception)
        {
            throw;
        }
    }

}