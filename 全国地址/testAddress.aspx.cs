using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

namespace 全国地址
{
    public partial class TestAddress : System.Web.UI.Page
    {
        private string mod = "", codeNo = "";
        Common common = new Common();

        protected void Page_Load(object sender, EventArgs e)
        {
            mod = Request.QueryString["action"] ?? "";

            if (IsPostBack) { return; }

            if (mod == "") //得到所有省
            {
                string sqlStr = "select area_name,area_province from nationwide_address where area_city='0'";
                DataTable datadt = common.GetAddressInfo(sqlStr);
                prov_rep.DataSource = datadt;
                prov_rep.DataBind();
            }
            else if (mod == "city") //得到市
            {
                codeNo = Request.QueryString["code"] ?? "0";

                string sqlStr = "select area_name as name,area_city as code from nationwide_address";
                sqlStr += string.Format(" where area_province='{0}' and area_district='0' and area_city>'0'", codeNo);

                GetAddress(sqlStr);
            }
            else if (mod == "dist") //得到区县
            {
                codeNo = Request.QueryString["code"] ?? "0";

                string sqlStr = "select area_name as name,area_district as code from nationwide_address";
                sqlStr += string.Format(" where area_city='{0}' and area_town='0' and area_district>'0'", codeNo);
                GetAddress(sqlStr);
            }
            else if (mod == "town") //得到乡镇
            {
                codeNo = Request.QueryString["code"] ?? "0";

                string sqlStr = "select area_name as name,area_town as code from nationwide_address";
                sqlStr += string.Format(" where area_district='{0}' and area_street='0' and area_town>'0'", codeNo);
                GetAddress(sqlStr);
            }
            else if (mod == "street") //得到街道
            {
                codeNo = Request.QueryString["code"] ?? "0";

                string sqlStr = "select area_name as name,area_street as code from nationwide_address";
                sqlStr += string.Format(" where area_town='{0}' and area_street>'0'", codeNo);
                GetAddress(sqlStr);
            }
        }

        /// <summary>
        /// 得到地址信息
        /// </summary>
        /// <param name="sqlstr"></param>
        /// <returns></returns>
        private void GetAddress(string sqlstr)
        {
            Response.ContentType = "text/plain";
            Response.HeaderEncoding = Encoding.UTF8;
            Response.ContentEncoding = Encoding.UTF8;

            string ResultData = "";
            List<object> objlist = new List<object>();
            if (sqlstr != "")
            {
                //查询数据库
                DataTable datadt = common.GetAddressInfo(sqlstr);
                if (datadt != null && datadt.Rows.Count > 0)
                {
                    foreach (DataRow item in datadt.Rows)
                    {
                        objlist.Add(new
                        {
                            code = item["code"].ToString(),
                            name = item["name"].ToString()
                        });
                    }
                    ResultData = common.ToJSON(objlist);
                }
                else { ResultData = "[]"; }
            }
            else { ResultData = "[]"; }

            Response.Write(ResultData);
            Response.End();
        }


    }
}