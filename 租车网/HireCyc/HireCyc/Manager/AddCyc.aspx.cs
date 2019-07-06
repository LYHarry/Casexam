using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_AddCyc : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            List<string> CycTypeName = BLL.CycTypeBusiness.CycTypeLookAllName();
            foreach (string name in CycTypeName)
            {
                cycType.Items.Add(name);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //添加车辆信息，提交按钮
    protected void butSub_ServerClick(object sender, EventArgs e)
    {
        if (!BasicOperate.isNum(TextBox3.Text))
        {
            Common.MessageBox.Show(this.Page, "价格要为数字!");
            return;
        }

        Model.CycInfo ci = new Model.CycInfo();
        ci.CycBowrrowSun = 1;
        ci.CycName = TextBox1.Text.Trim();   //车辆名称
        ci.CycRepair = 0;
        ci.CycType = cycType.Items[cycType.SelectedIndex].ToString();  //车辆类型
        ci.CycMoney = Convert.ToSingle(TextBox3.Text.Trim());  //车价

        try
        {
            if (BLL.CycInfoBusiness.CycInfoAdd(ci))
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
        Response.Redirect("CycManager.aspx", true);
    }

    //修改
    protected void alter_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("CycManager.aspx", true);
    }
    //查询
    protected void select_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("SelectCyc.aspx", true);
    }
}