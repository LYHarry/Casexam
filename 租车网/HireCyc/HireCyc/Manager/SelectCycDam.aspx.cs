using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_SelectCycDam : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
        string con = "";
        try
        {
            if (Session["damCon"] != null)
                con = Session["damCon"].ToString();

            if (string.IsNullOrEmpty(con))
                Repeater1.DataSource = BLL.CycDamageBusiness.CycDamageLookALL();
            else
                Repeater1.DataSource = BLL.CycDamageBusiness.CycDamageLookByType(con);

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

        try
        {
            if (seCon.Equals("车辆类型"))
            {
                Repeater1.DataSource = BLL.CycDamageBusiness.CycDamageLookByType(con);
            }
            else if (seCon.Equals("毁坏情况"))
            {
                Repeater1.DataSource = BLL.CycDamageBusiness.CycDamageLookBySituation(con);
            }
            Repeater1.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

}