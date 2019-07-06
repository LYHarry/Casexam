using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MyCenter_OrderAppraise : System.Web.UI.Page
{
    public int id;  //用于保存订单ID
    public int count; //用于保存订车数辆
    public string time;  //用于保存订单的生成时间
    public string cycType;  //用于保存租用的车辆类型

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            id = Convert.ToInt32(Request.QueryString["id"]);
            count = Convert.ToInt32(Request.QueryString["count"]);
            time = Convert.ToString(Request.QueryString["time"]);

            Repeater1.DataSource = BLL.CycRentBusiness.CycRentLookByBowId(id);
            Repeater1.DataBind();
        }
        catch (Exception ex)
        {
            if (ex.Message == "")
                Response.Redirect("../Share/Error.aspx");
        }
    }

    //提交按钮
    protected void Unnamed_ServerClick(object sender, EventArgs e)
    {
        Model.OrderAppraise oa = new Model.OrderAppraise();
        oa.OrderappraiseBowId = id;
        oa.OrderappraiseCycPf = Convert.ToInt32(Request.Form["hid2"]);  //得到商品评分
        oa.OrderappraiseCycContent = TextBox1.Text.Trim();  //得到商品评价内容
        oa.OrderappraiseEmpPf = Convert.ToInt32(Request.Form["hid1"]);  //得到员工评分
        oa.OrderappraiseEmpCont = TextBox2.Text.Trim();  //得到员工评价内容

        if (BLL.OrderAppraiseBusiness.OrderAppraiseAdd(oa))
        {
            Common.MessageBox.ShowAndRedirect(this.Page, "评价成功", "MyCenter.aspx");
        }

    }
}