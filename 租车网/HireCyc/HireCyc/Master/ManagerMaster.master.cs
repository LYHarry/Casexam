using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Master_ManagerMaster : System.Web.UI.MasterPage
{
    public string rolePower = string.Empty;  //用于保存角色权限
    public List<Model.EmployeeInfo> list;

    protected void Page_Load(object sender, EventArgs e)
    {
        string ManUserName = "JyEVqzb83924";  // Session["ManaAcc"].ToString();  //获取管理员账号

        try
        {
            list = BLL.EmployeeInfoBusiness.EmployeeInfoLookByAcc(ManUserName);
            rolePower = BLL.EmployeeInfoBusiness.EmployeeInfoLookPowByAcc(ManUserName);
        }
        catch (Exception)
        {
            throw;
        }
    }

    //显示当前系统时间
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        Label1.Text = DateTime.Now.ToString("yyyy年MM月dd日 hh:mm:ss");
    }
}
