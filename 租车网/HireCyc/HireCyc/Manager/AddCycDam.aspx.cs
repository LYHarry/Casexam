using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_AddCycDam : System.Web.UI.Page
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
            Common.MessageBox.Show(this.Page, "罚金要为数字!");
            return;
        }

        Model.CycDamage cd = new Model.CycDamage();

        cd.CycDamageSituation = TextBox1.Text.Trim();   //车辆毁坏情况
        cd.CycDamageCycType = cycType.Items[cycType.SelectedIndex].ToString();  //车辆类型
        cd.CycDamageMoney = Convert.ToSingle(TextBox3.Text.Trim());  //车价

        try
        {
            if (BLL.CycDamageBusiness.CycDamageAdd(cd))
            {
                Common.MessageBox.Show(this.Page, "添加成功");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //修改
    protected void alter_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("CycDamManager.aspx", true);
    }

    //删除
    protected void del_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("CycDamManager.aspx", true);
    }

    //查询
    protected void select_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("SelectCycDam.aspx", true);
    }
}