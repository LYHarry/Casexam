using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home_PayMode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //支付按钮
    protected void Unnamed_ServerClick(object sender, EventArgs e)
    {
        string payMode = string.Empty;  //用于支付账号类型 

        if (pay1.Checked)
            payMode = "支付宝";
        else if (bank1.Checked || bank2.Checked || bank3.Checked || bank4.Checked)
        {
            payMode = "银行卡";
        }
        Session["cardType"] = payMode;  //保存到session

        Response.Redirect("Payment.aspx", true);
    }
}