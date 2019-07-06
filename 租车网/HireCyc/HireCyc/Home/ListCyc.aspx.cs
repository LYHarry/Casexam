using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home_ListCyc : System.Web.UI.Page
{
    string serverPath = "../Images/";  //用于读取自行车图片路径
    int i = 1; //用于设置图片ID
    string cycTypeName = string.Empty;  //用于保存选择的车辆类型名称

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["name"] != null)
            {
                cycTypeName = Request.QueryString["name"].ToString();  //得到车辆分类名称                  
            }

            switch (cycTypeName)
            {
                case "普通自行车": serverPath += "CommonCyc/"; break;
                case "公路自行车": serverPath += "HighwayCyc/"; break;
                case "山地自行车": serverPath += "MountainsCyc/"; break;
                case "死飞自行车": serverPath += "GearCyc/"; break;
                case "三人自行车": serverPath += "MultiCyc/"; break;
                case "双人自行车": serverPath += "TwoCyc/"; break;
                default:
                    {
                        serverPath += "HighwayCyc/";
                        cycTypeName = "公路自行车";
                    } break;
            }
            string path = Server.MapPath(serverPath);  //得到物理路径
            List<string> FileNameList = BasicOperate.GetFileName(path); //得到该路径下所有文件名称         

            //读取数据库显示自行车名称
            List<string> CycNameList = BLL.CycInfoBusiness.CycInfoLookNameByType(cycTypeName);

            foreach (string CycName in CycNameList)
            {
                //动态成生DIV标签显示自行车信息
                Panel pan = new Panel();
                pan.ID = "pan" + i;
                pan.CssClass = "panStyle";
                panel.Controls.Add(pan);
                //动态成生image标签显示自行车图片
                ImageButton img = new ImageButton();
                img.ImageUrl = serverPath + FileNameList[i - 1];
                img.ID = "img" + i;
                img.AlternateText = CycName;
                img.CssClass = "imgStyle";
                img.Attributes.Add("onclick", "alert('添加成功！')");
                img.Click += img_Click;
                pan.Controls.Add(img);
                //动态成生label标签显示自行车名称
                Label label = new Label();
                label.ID = "label" + i;
                label.CssClass = "labelStyle";
                label.Text = CycName;
                pan.Controls.Add(label);

                i++;  //下标递增
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void img_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton ib = ((ImageButton)sender);
        Session["cycName"] = ib.AlternateText;  //把车辆名称保存到session中
        Session["cycPath"] = ib.ImageUrl;   //保存选择的自行车图片路径
        Session["cycTypeName"] = cycTypeName;   //把车辆类型保存到session中
        Session["Cycnum"] = "1";
    }

    //提交订单按钮
    protected void subBut_ServerClick(object sender, EventArgs e)
    {
        //判断购物车里面是否有商品

        if (Session["cycName"] == null && Session["cycTypeName"] == null)
        {
            Common.MessageBox.Show(this.Page, "购物车为空!");
            return;
        }
        else
        {
            Response.Redirect("ConfirmOrder.aspx", true);
        }
    }

    //删除订单信息
    protected void Unnamed_ServerClick(object sender, EventArgs e)
    {
        Session["cycName"] = null;
        Session["cycPath"] = null;
        Session["cycTypeName"] = null;
        Session["Cycnum"] = null;
    }
}