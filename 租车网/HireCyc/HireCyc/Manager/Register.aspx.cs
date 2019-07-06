using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_Register : System.Web.UI.Page
{
    List<string> EmpNameList = null;  //用于保存所有的员工账号
    List<string> keytList = null;   //用于保存所有的密钥

    //保存每个月的天数
    string[] MonHead = new string[] { "31", " 28", " 31", "30", "31", "30", "31", "31", "30", "31", "30", "31" };

    protected void Page_Load(object sender, EventArgs e)
    {
        //先给年下拉框赋内容
        int y = DateTime.Now.Year;
        for (var i = y; i >= 1890; i--)
        {
            year.Items.Add(i.ToString());
        }
    }

    //注册按钮
    protected void Button2_Click(object sender, EventArgs e)
    {
        Model.EmployeeInfo ef = new Model.EmployeeInfo();

        ef.EmployeeAccount = GetEmpAcc();  //得到员工账号
        Session["ManagerAcc"] = ef.EmployeeAccount;
        ef.EmployeeName = TextBox9.Text.Trim();  //得到员工姓名

        if (male.Checked)   //用于保存性别
            ef.EmployeerSex = "男";
        else if (female.Checked)
            ef.EmployeerSex = "女";

        ef.EmployeeTel = TextBox10.Text.Trim();  //得到电话号码
        ef.EmployeeEmail = TextBox4.Text.Trim();   //得到电子邮箱
        ef.EmployeeCertificate = TextBox2.Text.Trim();  //得到身份证
        ef.EmployeeDepartment = "业务部";
        ef.EmployeePosition = "前台";
        ef.EmployeePower = 1;
        string birth = year.SelectedValue + "-" + month.SelectedValue + "-" + day.SelectedValue;
        ef.EmployeeBirth = Convert.ToDateTime(birth);
        string address = Request.Form["GetAdd"];  //得到选择的地址
        ef.EmployeeAddress = address + TextBox1.Text.Trim();
        string paw = TextBox3.Text.Trim();   //得到密码
        string repaw = TextBox5.Text.Trim();  //得到确认密码

        #region 判断文本框是否为空

        if (TextBox5.Text.Trim().Equals("详细地址"))
        {
            Common.MessageBox.Show(this.Page, "详细地址不能为空!");
            return;
        }

        if (string.IsNullOrEmpty(ef.EmployeeName))
        {
            Common.MessageBox.Show(this.Page, "姓名不能为空!");
            return;
        }
        if (ef.EmployeeTel.Equals("只能是11位手机号码"))
        {
            Common.MessageBox.Show(this.Page, "电话号码不能为空!");
            return;
        }
        if (string.IsNullOrEmpty(ef.EmployeeEmail))
        {
            Common.MessageBox.Show(this.Page, "邮箱不能为空!");
            return;
        }
        if (string.IsNullOrEmpty(ef.EmployeeCertificate))
        {
            Common.MessageBox.Show(this.Page, "身份证不能为空!");
            return;
        }
        if (paw.Equals("字母，数字,最长16位"))
        {
            Common.MessageBox.Show(this.Page, "密码不能为空!");
            return;
        }
        if (string.IsNullOrEmpty(repaw))
        {
            Common.MessageBox.Show(this.Page, "确认密码不能为空!");
            return;
        }
        #endregion

        if (!CheckBox1.Checked)
        {
            Common.MessageBox.Show(this.Page, "请勾选同意服务条款!");
            return;
        }

        if (!BasicOperate.EmailIsLegal(ef.EmployeeEmail))
        {
            Common.MessageBox.Show(this.Page, "邮箱格式不正确!");
            return;
        }
        if (!BasicOperate.PhoneIsLegal(ef.EmployeeTel))
        {
            Common.MessageBox.Show(this.Page, "电话号码格式不正确!");
            return;
        }

        if (BasicOperate.strIsEqual(paw, repaw))
        {
            keytList = BLL.PasswordBusiness.PasswordLookALLPaw();  //读取产生的所有密钥

            //判断随机产生的密钥是否唯一
            while (true)
            {
                string keyt = BasicOperate.SecurityCode(4);  //随机产生四位密钥

                bool isAdd = BasicOperate.strIsExistList(keyt, keytList);//判断密钥是否存在

                if (!isAdd)
                {
                    //密钥唯一，保存数据库
                    int index = paw.Length / 2;  //把密钥插入到密码字符串的下标
                    paw = BasicOperate.InsertStr(index, paw, keyt);  //把密钥插入到密码中，形成新密码字符串
                    paw = FormsAuthentication.HashPasswordForStoringInConfigFile(paw, "MD5");   //把密码加密

                    ef.EmployeePassword = paw;  //得到密钥
                    try
                    {
                        //写入数据库 事务提交
                        using (TransactionScope trans = new TransactionScope())
                        {
                            BLL.EmployeeInfoBusiness.EmployeeInfoAdd(ef);
                            BLL.PasswordBusiness.PasswordAdd(ef.EmployeeAccount, keyt);
                            trans.Complete();
                            Response.Redirect("RegisterSuccess.aspx", true);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                break;
            }
        }
        else
        {
            Common.MessageBox.Show(this.Page, "密码和确认密码不一样!");
            return;
        }
    }


    /// <summary>
    /// 随机产生12位员工账号
    /// </summary>
    /// <returns></returns>
    private string GetEmpAcc()
    {
        string EmpAcc = string.Empty;  //用于保存员工账号

        try
        {
            EmpNameList = BLL.EmployeeInfoBusiness.EmployeeInfoLookALLAcc();  //读取产生的所有员工账号

            //判断随机产生的员工账号是否唯一
            while (true)
            {
                string Emp = BasicOperate.SecurityCode(8) + BasicOperate.RanNumCode(4);  //随机产生12位员工账号

                bool isAdd = BasicOperate.strIsExistList(Emp, EmpNameList);//判断员工账号是否存在

                if (!isAdd)
                {
                    EmpAcc = Emp;  //员工账号唯一
                }
                break;
            }
        }
        catch (Exception)
        {
            throw;
        }

        return EmpAcc;
    }

    //按条件赋值日期的下拉框
    private void writeDay(int n)
    {
        day.Items.Clear(); //清除以前的节点，重新添加
        day.Items.Add("日");

        for (var i = 1; i < (n + 1); i++)
        {
            day.Items.Add(i.ToString());
        }
    }

    //赋月份的下拉框 
    private void writeMonth()
    {
        month.Items.Clear(); //清除以前的节点，重新添加
        month.Items.Add("月");

        for (var i = 1; i < 13; i++)
        {
            month.Items.Add(i.ToString());
        }
    }

    //年发生变化时日期发生变化(主要是判断闰平年)
    protected void year_SelectedIndexChanged(object sender, EventArgs e)
    {
        int str = Convert.ToInt32(year.SelectedValue);
        writeMonth();   //调用函数给月份的下拉框赋值
        //得到选择的月份
        string MMvalue = month.SelectedValue;

        if (MMvalue == "月")
        {
            day.Items.Clear();
            day.Items.Add("日");
            return;
        }
        int n = Convert.ToInt32(MonHead[Convert.ToInt32(MMvalue) - 1]);
        if (MMvalue.Equals("2") && BasicOperate.IsLeapYear(str)) n++;
        writeDay(n);  //调用赋天数的函数
    }

    //月发生变化时日期联动  
    protected void month_SelectedIndexChanged(object sender, EventArgs e)
    {
        string str = month.SelectedValue;  //得到选择的月份
        //得到选择的年份
        int YYYYvalue = Convert.ToInt32(year.SelectedValue);

        if (str == "月")
        {
            day.Items.Clear();
            return;
        }
        int n = Convert.ToInt32(MonHead[Convert.ToInt32(str) - 1]);
        if (str.Equals("2") && BasicOperate.IsLeapYear(YYYYvalue)) n++;
        writeDay(n);  //调用赋天数的函数
    }
}