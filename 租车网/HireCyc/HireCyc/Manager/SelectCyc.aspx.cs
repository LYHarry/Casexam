using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_SelectCyc : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Repeater1.DataSource = BLL.CycInfoBusiness.CycInfoLookByBspx();
            Repeater1.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //查询按钮
    protected void select_ServerClick(object sender, EventArgs e)
    {
        string con = text.Value;  //得到查询内容
        string seCon = DropDownList1.SelectedValue;  //得到查询条件

        if (string.IsNullOrEmpty(con))
        {
            Common.MessageBox.Show(this.Page, "请输入查询条件!");
            return;
        }

        if (seCon.Equals("购买时间"))
        {
            if (TextBox3.Text.Trim().Equals("请选择"))
            {
                Common.MessageBox.Show(this.Page, "请输入开始时间!");
                return;
            }
            if (TextBox4.Text.Trim().Equals("请选择"))
            {
                Common.MessageBox.Show(this.Page, "请输入开始时间!");
                return;
            }
        }

        try
        {
            if (seCon.Equals("毁坏情况"))
            {
                Session["damCon"] = con;
                Response.Redirect("SelectCycDam.aspx", true);
            }
            else if (seCon.Equals("车辆类型"))
            {
                Repeater1.DataSource = BLL.CycInfoBusiness.CycInfoLookByType(con);
            }
            else if (seCon.Equals("车辆名称"))
            {
                Repeater1.DataSource = BLL.CycInfoBusiness.CycInfoLookByName(con);
            }
            else if (seCon.Equals("购买时间"))
            {
                DateTime time1 = Convert.ToDateTime(TextBox3.Text.Trim());  //得到开始时间
                DateTime time2 = Convert.ToDateTime(TextBox4.Text.Trim());  //得到结束时间

                if (time1 < DateTime.Now)  //判断选择的时间是否小于系统当前时间
                {
                    Common.MessageBox.Show(this.Page, "开始时间选择不正确，请重新选择！");
                    TextBox3.Text = "请选择";
                    return;
                }

                if (time2 < DateTime.Now && time2 < time1)  //判断选择的时间是否小于系统当前时间
                {
                    Common.MessageBox.Show(this.Page, "结束时间选择不正确，请重新选择！");
                    TextBox4.Text = "请选择";
                    return;
                }
                Repeater1.DataSource = BLL.CycInfoBusiness.CycInfoLookByTime(time1, time2);
            }

            Repeater1.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //选择购买时间查询时，显示时间文本框
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedValue.Equals("购买时间"))
        {
            text.Visible = false;
            Label1.CssClass = "label Show";
            Label2.CssClass = "label Show";
            TextBox3.CssClass = "inputFrame Show grayCol";
            TextBox4.CssClass = "inputFrame Show grayCol";
        }
        else
        {
            text.Visible = true;
            Label1.CssClass = "label disShow";
            Label2.CssClass = "label disShow";
            TextBox3.Visible = false;
            TextBox4.Visible = false;
        }
    }
}