<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;
using System.Text;

public class Handler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        context.Response.ContentEncoding = Encoding.UTF8;

        string type = context.Request.QueryString["Type"].ToString();  //得到当前操作的是哪种类型
        string rowId = context.Request.QueryString["id"].ToString();  //得到当前选中的行ID

        string[] nameId = rowId.Split(',');
        
        bool f = false;  //用于保存是否删除成功

        switch (type)
        {
            case "cyc": { f = CycDel(nameId); } //调用删除自行车信息方法
                break;

            case "cycType": { f = CycTypeDel(nameId); } //调用删除自行车类型信息方法
                break;

            case "Emp": { f = EmpDel(nameId); } //调用删除员工信息方法
                break;

            case "power": { f = PowerDel(nameId); } //调用删除权限信息方法
                break;

            case "user": { f = UserDel(nameId); } //调用删除用户信息方法
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
    /// 删除自行车信息
    /// </summary>
    /// <param name="nameid">自行车名称</param>
    /// <returns></returns>
    private bool CycDel(string[] nameid)
    {
        bool f = false; //用于保存是否删除成功

        try
        {
            for (int i = 0; i < nameid.Length; i++)
            {
                f = BLL.CycInfoBusiness.CycInfoDel(nameid[i]);
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
    /// 删除员工信息
    /// </summary>
    /// <param name="nameid">员工账号</param>
    /// <returns></returns>
    private bool EmpDel(string[] nameid)
    {
        bool f = false; //用于保存是否删除成功

        try
        {
            for (int i = 0; i < nameid.Length; i++)
            {
                f = BLL.EmployeeInfoBusiness.EmployeeInfoDel(nameid[i]);
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
    /// 删除自行车类型信息
    /// </summary>
    /// <param name="nameid">自行车类型名称</param>
    /// <returns></returns>
    private bool CycTypeDel(string[] nameid)
    {
        bool f = false; //用于保存是否删除成功

        try
        {
            for (int i = 0; i < nameid.Length; i++)
            {
                f = BLL.CycTypeBusiness.CycTypeDel(nameid[i]);
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
    /// 删除权限信息
    /// </summary>
    /// <param name="nameid">权限名称</param>
    /// <returns></returns>
    private bool PowerDel(string[] nameid)
    {
        bool f = false; //用于保存是否删除成功

        try
        {
            for (int i = 0; i < nameid.Length; i++)
            {
                f = BLL.AdmSetBusiness.AdmSetDelete(nameid[i]);
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
    /// 删除用户信息
    /// </summary>
    /// <param name="nameid">用户账号</param>
    /// <returns></returns>
    private bool UserDel(string[] nameid)
    {
        bool f = false; //用于保存是否删除成功

        try
        {
            for (int i = 0; i < nameid.Length; i++)
            {
                f = BLL.UserInfoBusiness.DeteleUserInfo(nameid[i]);
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