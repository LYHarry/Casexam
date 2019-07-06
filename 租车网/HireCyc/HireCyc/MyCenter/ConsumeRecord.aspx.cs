using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MyCenter_ConsumeRecord : System.Web.UI.Page
{
    public float sumMoney;  //用于保存消费租金总计

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string UserName =  Session["username"].ToString();  //获取保存在session中的用户账号
            Repeater1.DataSource = BLL.CycBorrowBusiness.CycBorrowLookBycode(UserName);
            Repeater1.DataBind();

            //计算实际消费租金总和
            List<Model.CycBorrow> listCb = BLL.CycBorrowBusiness.CycBorrowLookBycode(UserName);
            foreach (Model.CycBorrow cb in listCb)
            {
                sumMoney += cb.CycBorrowRealMoney;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}