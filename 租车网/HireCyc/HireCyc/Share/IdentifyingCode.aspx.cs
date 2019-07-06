using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Share_IdentifyingCode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string CodeStr = BasicOperate.SecurityCode(4);

        Session["code"] = CodeStr;  //把验证码保存到session，用于比较用户输入的验证码

        byte[] data = BasicOperate.CheckCodeImage(ref CodeStr, 100, 40);

        Response.OutputStream.Write(data, 0, data.Length);
    }
}