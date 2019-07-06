using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_AddCycType : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //添加车辆类型，提交按钮
    protected void butSub_ServerClick(object sender, EventArgs e)
    {
        try
        {
            Model.CycType ct = new Model.CycType();

            ct.CycTypeName = TextBox7.Text.Trim();   //得到类型名称
            ct.CycTypeStock = Convert.ToInt32(TextBox1.Text.Trim());  //库存
            ct.CycTypeHire = Convert.ToInt32(TextBox2.Text.Trim());  //押金
            ct.CycTypeLagHrMoney = Convert.ToInt32(TextBox3.Text.Trim());  //租金—小时
            ct.CycTypeLagDayMoney = Convert.ToInt32(TextBox4.Text.Trim()); //租金—天
            ct.CycTypeLateHrMoney = Convert.ToInt32(TextBox5.Text.Trim());  //迟还租金—小时
            ct.CycTypeLateDayMoney = Convert.ToInt32(TextBox6.Text.Trim());  //迟还租金－天

            if (BLL.CycTypeBusiness.CycTypeAdd(ct))
            {
                Common.MessageBox.Show(this.Page, "添加成功");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //删除
    protected void del_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("CycTypeManager.aspx", true);
    }

    //查询
    protected void select_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("CycTypeManager.aspx", true);
    }
    //修改
    protected void alter_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("CycTypeManager.aspx", true);
    }
}