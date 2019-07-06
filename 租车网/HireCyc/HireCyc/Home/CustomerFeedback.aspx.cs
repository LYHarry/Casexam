using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home_CustomerFeedback : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //提交按钮
    protected void subBut_Click(object sender, EventArgs e)
    {
        Model.Feedback fb = new Model.Feedback();

        fb.FeedbackTheme = subject.Value.Trim(); //得到主题
        fb.FeedbackContent = CustomerFeedbackContent.Value.Trim();  //得到反馈内容
        fb.FeedbackTel = tel.Value.Trim();  //得到反馈人联系电话
        string code = testCode.Value.Trim();  //得到验证码

        string checkCode = Session["code"].ToString();   //获取保存在session中的验证码

        #region 判断文本框是否为空

        if (string.IsNullOrEmpty(fb.FeedbackTheme))
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "提示", "<script>alert('反馈主题不为空!')</script>");
            return;
        }
        if (string.IsNullOrEmpty(fb.FeedbackContent))
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "提示", "<script>alert('反馈内容不为空!')</script>");
            return;
        }

        if (string.IsNullOrEmpty(code))
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "提示", "<script>alert('验证码不能为空!')</script>");
            return;
        }
        #endregion

        //判断手机号码格式是否正确
        if (!string.IsNullOrEmpty(fb.FeedbackTel))
        {
            if (!BasicOperate.PhoneIsLegal(fb.FeedbackTel))
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "提示", "<script>alert('手机号码格式不正确，请重新输入!')</script>");
                return;
            }
        }
        
        if (BasicOperate.strIsEqual(code, checkCode))
        {
            try
            {
                if (BLL.FeedbackBusiness.FeedbackAdd(fb))  //把反馈内容写入数据库
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "提示", "<script>alert('反馈信息已提交，我们会尽快处理，感谢您的宝贵意见!')</script>");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}