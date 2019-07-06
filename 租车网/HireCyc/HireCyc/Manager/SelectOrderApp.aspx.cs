using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_SelectOrderApp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Repeater1.DataSource = BLL.OrderAppraiseBusiness.OrderAppraiseLookAll();
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
            if (seCon.Equals("订单编号"))
            {
                int id = Convert.ToInt32(con);

                if (BLL.OrderAppraiseBusiness.OrderAppLookId(id))
                {
                    Repeater1.DataSource = BLL.OrderAppraiseBusiness.orderAppraise(id);
                    Repeater1.DataBind();
                }
                else
                {
                    Common.MessageBox.Show(this.Page, "订单编号不存在!");
                    return;
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}