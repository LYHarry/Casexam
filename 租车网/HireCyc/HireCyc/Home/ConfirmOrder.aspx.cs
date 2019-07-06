using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home_ConfirmOrder : System.Web.UI.Page
{
    public Model.CycType ct;  //用于保存读取的车辆类型信息
    public string cycTypeName = string.Empty;   //得到车辆类型名称
    private DateTime time = DateTime.Now;  //用于保存取车时间
    private DateTime backtime = DateTime.Now;  //用于保存还车时间

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            cycTypeName = Session["cycTypeName"].ToString();
            ct = BLL.CycTypeBusiness.CycTypeLookByName(cycTypeName);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        //给小时赋值
        for (int i = 5; i < 22; i++)
        {
            hour1.Items.Add(i.ToString());
            hour2.Items.Add(i.ToString());
        }
        //给分钟赋值
        for (int i = 0; i < 60; i++)
        {
            minute1.Items.Add(i.ToString());
            minute2.Items.Add(i.ToString());
        }
    }

    //提交订单按钮
    protected void Unnamed_ServerClick(object sender, EventArgs e)
    {
        if (Session["username"] == null)  //判断是否登录
        {
            Common.MessageBox.ShowAndRedirect(this.Page, "亲，你还没登录哦!", "../Account/Login.aspx");
            return;
        }

        #region 判断取车，还车时间是否选择

        if (TextBox3.Text.Equals("请选择") || hour1.Items[hour1.SelectedIndex].ToString().Equals("请选择") || minute1.Items[minute1.SelectedIndex].ToString().Equals("请选择"))
        {
            Common.MessageBox.Show(this.Page, "请选择取车时间!");
            return;
        }
        if (TextBox4.Text.Equals("请选择") || hour2.Items[hour2.SelectedIndex].ToString().Equals("请选择") || minute2.Items[minute2.SelectedIndex].ToString().Equals("请选择"))
        {
            Common.MessageBox.Show(this.Page, "请选择取车时间!");
            return;
        }
        #endregion

        Model.CycBorrow cb = new Model.CycBorrow();
        cb.CycBorrowBowCode = Session["username"].ToString();  //得到用户账号
        cb.CycBorrowCount = Convert.ToInt32(textNum.Value);  //得到租用数辆
        cb.CycBorrowEmpcode = "JyEVqzb83924";
        cb.CycBorrowStatus = "已预定";
        Session["Cycnum"] = textNum.Value;  //把租用辆数保存到Session中

        string cycName = Session["cycName"].ToString();  //得到用户租用的车辆名称
        Session["money"] = Convert.ToSingle(moneyFont.InnerHtml) * 0.4;  //把订单保存在session中

        computeTime();

        if (this.time < DateTime.Now)  //判断选择的时间是否小于系统当前时间
        {
            Common.MessageBox.Show(this.Page, "预定时间选择不正确，请重新选择！");
            TextBox3.Text = "请选择";
            return;
        }

        if (this.backtime < DateTime.Now && this.backtime < this.time)  //判断选择的时间是否小于系统当前时间
        {
            Common.MessageBox.Show(this.Page, "还车时间选择不正确，请重新选择！");
            TextBox4.Text = "请选择";
            return;
        }

        try
        {
            if (BLL.UserInfoBusiness.UserInfoLookCer(cb.CycBorrowBowCode))  //判断是否完善信息
            {
                //写入数据库 事务提交
                using (TransactionScope trans = new TransactionScope())
                {
                    BLL.CycBorrowBusiness.CycBorrowAdd(cb);  //增加订单信息
                    int id = BLL.CycBorrowBusiness.CycBorrowLookIdBycode(cb.CycBorrowBowCode);  //得到订单编号

                    //读取所有的车辆信息
                    List<Model.CycInfo> listCyc = BLL.CycInfoBusiness.CycInfoLookByBspx();

                    bool f = false;  //用于保存结果

                    for (int i = 0; i < cb.CycBorrowCount; i++)
                    {
                        Model.CycRent cr = new Model.CycRent();
                        cr.CycRentCycName = listCyc[i].CycName;
                        cr.CycRentCycType = cycTypeName;
                        cr.CycRentBorrowId = id;
                        cr.CycRentTime = this.time;
                        cr.CycRentReturnTime = this.backtime;
                        f = BLL.CycRentBusiness.CycRentAdd(cr);//添加订单租用信息
                        if (!f) { break; throw new Exception(); }
                    }
                    trans.Complete();
                    Response.Redirect("PayMode.aspx", true);
                }
            }
            else
            {
                Common.MessageBox.ShowAndRedirect(this.Page, "对不起，您资料信息未完善，请先完善信息！", "../MyCenter/PersonData.aspx");
                return;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //数量减少按钮
    protected void minus_ServerClick(object sender, EventArgs e)
    {
        textNum.Value = (Convert.ToInt32(textNum.Value) - 1).ToString();
        if (Convert.ToInt32(textNum.Value) < 1)
            minus.Disabled = true;

        float time = computeTime();
        if (time != 0)
        {
            moneyFont.InnerHtml = (ct.CycTypeLagHrMoney * Convert.ToSingle(textNum.Value) * time).ToString("f2");
        }
        if (BasicOperate.strIsEqual(textNum.Value, "0"))
        {
            moneyFont.InnerHtml = "0.00";
        }
    }


    //数量增加按钮
    protected void plus_ServerClick(object sender, EventArgs e)
    {
        textNum.Value = (Convert.ToInt32(textNum.Value) + 1).ToString();

        if (Convert.ToInt32(textNum.Value) > Convert.ToInt32(ct.CycTypeStock))
        {
            Common.MessageBox.Show(this.Page, "库存不足!");
            textNum.Value = stock.InnerHtml;
        }
        if (Convert.ToInt32(textNum.Value) > 0)
            minus.Disabled = false;

        float time = computeTime();
        if (time != 0)
        {
            //显示租用金额    
            moneyFont.InnerHtml = (ct.CycTypeLagHrMoney * Convert.ToInt32(textNum.Value) * time).ToString("f2");
        }
        if (BasicOperate.strIsEqual(textNum.Value, "0"))
        {
            moneyFont.InnerHtml = "0.00";
        }
    }
    protected void minute2_SelectedIndexChanged(object sender, EventArgs e)
    {
        float time = computeTime();

        //显示租用金额    
        moneyFont.InnerHtml = (ct.CycTypeLagHrMoney * Convert.ToInt32(textNum.Value) * time).ToString("f2");
    }

    /// <summary>
    /// 计算租用时间
    /// </summary>
    private float computeTime()
    {
        string retime = string.Empty, backtime = string.Empty;

        //得到取车时间
        if (!TextBox3.Text.Equals("请选择") && !hour1.Items[hour1.SelectedIndex].ToString().Equals("请选择") && !minute1.Items[minute1.SelectedIndex].ToString().Equals("请选择"))
            retime = TextBox3.Text.Trim() + " " + hour1.Items[hour1.SelectedIndex] + ":" + minute1.Items[minute1.SelectedIndex];
        //得到还车时间
        if (!TextBox4.Text.Equals("请选择") && !hour2.Items[hour2.SelectedIndex].ToString().Equals("请选择") && !minute2.Items[minute2.SelectedIndex].ToString().Equals("请选择"))
            backtime = TextBox4.Text.Trim() + " " + hour2.Items[hour2.SelectedIndex] + ":" + minute2.Items[minute2.SelectedIndex];

        if (!string.IsNullOrEmpty(retime))
            this.time = Convert.ToDateTime(retime);

        if (!string.IsNullOrEmpty(backtime))
            this.backtime = Convert.ToDateTime(backtime);

        System.TimeSpan ts = this.backtime - this.time;   //计算时间间隔
        float time = (ts.Days * 24) + ts.Hours + (ts.Minutes / 60); //得到一共租用多久时间

        return time;
    }


}