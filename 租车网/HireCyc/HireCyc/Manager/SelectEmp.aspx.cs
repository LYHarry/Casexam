using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_SelectEmp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Repeater1.DataSource = BLL.EmployeeInfoBusiness.EmployeeInfoLookALLEmp();
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
            if (seCon.Equals("部门"))
            {
                Repeater1.DataSource = BLL.EmployeeInfoBusiness.EmployeeInfoLookDept(con);
            }
            else if (seCon.Equals("账号"))
            {
                Repeater1.DataSource = BLL.EmployeeInfoBusiness.EmployeeInfoLookByAcc(con);
            }
            else if (seCon.Equals("进公司年限"))
            {
                int time = Convert.ToInt32(con);
                Repeater1.DataSource = BLL.EmployeeInfoBusiness.employeeInfo(time);
            }

            Repeater1.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}