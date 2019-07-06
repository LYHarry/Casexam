using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_RegisterSuccess : System.Web.UI.Page
{
    public List<Model.EmployeeInfo> list;  //用于保存员工信息
    public string acc = string.Empty;  //用于保存员工账号

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            acc = Session["ManagerAcc"].ToString();
            list = BLL.EmployeeInfoBusiness.EmployeeInfoLookByAcc(acc);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}