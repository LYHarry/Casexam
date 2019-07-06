<%@ WebHandler Language="C#" Class="Handler2" %>

using System;
using System.Web;

public class Handler2 : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        string type = context.Request.QueryString["Type"].ToString();  //得到当前操作的是哪种类型
        string rowId = context.Request.QueryString["id"].ToString();  //得到当前选中的行ID

        string[] nameId = rowId.Split(',');
        int[] id = null;
        for (int i = 0; i < nameId.Length; i++)
        {
            id[i] = Convert.ToInt32(nameId[i]);
        }

        bool f = false;  //用于保存是否删除成功

        switch (type)
        {
            case "cycDam": { f = CycDamDel(id); } //调用删除车辆毁坏信息方法
                break;

            case "feed": { f = FeedBackDel(id); } //调用删除反馈表信息方法
                break;

            case "orderApp": { f = OrderAppDel(id); } //调用删除订单评价信息方法
                break;

            case "order": { f = OrderDel(id); } //调用删除订单信息方法
                break;
        }
        context.Response.Write(f);  //返回操作结果
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

    /// <summary>
    /// 删除车辆毁坏信息
    /// </summary>
    /// <param name="nameid">毁坏信息ID</param>
    /// <returns></returns>
    private bool CycDamDel(int[] nameid)
    {
        bool f = false; //用于保存是否删除成功

        try
        {
            for (int i = 0; i < nameid.Length; i++)
            {
                f = BLL.CycDamageBusiness.CycDamageDelByID(nameid[i]);
                if (!f) break;
            }
        }
        catch (Exception)
        {
            throw;
        }
        return f;
    }


    /// <summary>
    /// 删除订单信息
    /// </summary>
    /// <param name="nameid">订单编号</param>
    /// <returns></returns>
    private bool OrderDel(int[] nameid)
    {
        bool f = false; //用于保存是否删除成功

        try
        {
            for (int i = 0; i < nameid.Length; i++)
            {
                f = BLL.CycBorrowBusiness.CycBorrowDel(nameid[i]);
                if (!f) break;
            }
        }
        catch (Exception)
        {
            throw;
        }
        return f;
    }

    /// <summary>
    /// 删除反馈表信息
    /// </summary>
    /// <param name="nameid">反馈表编号</param>
    /// <returns></returns>
    private bool FeedBackDel(int[] nameid)
    {
        bool f = false; //用于保存是否删除成功

        try
        {
            for (int i = 0; i < nameid.Length; i++)
            {
                f = BLL.FeedbackBusiness.FeedbackDel(nameid[i]);
                if (!f) break;
            }
        }
        catch (Exception)
        {
            throw;
        }
        return f;
    }

    /// <summary>
    /// 删除反馈表信息
    /// </summary>
    /// <param name="nameid">反馈表编号</param>
    /// <returns></returns>
    private bool OrderAppDel(int[] nameid)
    {
        bool f = false; //用于保存是否删除成功

        try
        {
            for (int i = 0; i < nameid.Length; i++)
            {
                f = BLL.OrderAppraiseBusiness.OrderAppraiseDel(nameid[i]);
                if (!f) break;
            }
        }
        catch (Exception)
        {
            throw;
        }
        return f;
    }

}