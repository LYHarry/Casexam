using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 全国地址
{
    public partial class Index : System.Web.UI.Page
    {
        private string dataResult = "", pageContent = "", nameReg = "", codeReg = "", contentReg = "";
        private string childUrl = "", childUrlReg = "", parentID = "", parentIDReg = "";
        private string keys = "", values = "";
        private List<AddressModel> addressProv = null, addressCity = null, addressDist = null, addressTown = null, addressStreet = null, ProvAddress = null, AddressList = null;
        private Dictionary<object, List<AddressModel>> dictTown = null;
        private Dictionary<object, object> dictDist = null, dictCity = null, dictProv = null;
        private List<string> dataList = null;

        private string reg1, reg2, reg3, reg4, reg5, reg6, reg7, reg8, reg9, reg10, regAddress, regName;

        Common comm = new Common();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) { return; }
        }


        /// <summary>
        /// 确定按钮，过滤出全国地址
        /// 全国地区行政代码，版本2016年7月31日
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Unnamed_Click(object sender, EventArgs e)
        {
            //创建变量存储数据
            dictProv = new Dictionary<object, object>();
            ProvAddress = new List<AddressModel>();
            dataList = new List<string>();

            //得到全国地址信息
            GetAddress("http://www.stats.gov.cn/tjsj/tjbz/tjyqhdmhcxhfdm/2016/index.html");
            Response.Write(dataResult);
        }


        /// <summary>
        /// 得到全国地址
        /// </summary>
        /// <param name="url"></param>
        private void GetAddress(string url)
        {
            ClearData("all"); //清除数据
            //得到省数据
            addressProv = GetProvAddress(url);
            if (addressProv != null && addressProv.Count > 0)
            {
                for (int i = 30; i < addressProv.Count; i++)
                {
                    #region 市地址

                    dictCity = new Dictionary<object, object>();
                    ClearData("prov"); //清除数据
                    //得到该省下的市地址
                    url = addressProv[i].ChildUrl;
                    //得到直辖市区子链接
                    addressCity = GetCityAddress(url, addressProv[i].ProvID, addressProv[i].Code);
                    if (addressCity != null && addressCity.Count > 0)
                    {
                        for (int j = 0; j < addressCity.Count; j++)
                        {
                            #region 县地址

                            dictDist = new Dictionary<object, object>();
                            ClearData("city"); //清除数据
                            //得到该市下的县地址
                            url = addressCity[j].ChildUrl;
                            //得到县数据
                            addressDist = GetDistrictAddress(url, addressCity[j].ProvID, addressCity[j].Code);
                            if (addressDist != null && addressDist.Count > 0)
                            {
                                for (int m = 0; m < addressDist.Count; m++)
                                {
                                    #region 得到乡镇地址

                                    dictTown = new Dictionary<object, List<AddressModel>>();
                                    ClearData("dist"); //清除数据
                                    //得到该县下的乡镇地址
                                    url = addressDist[m].ChildUrl;
                                    //得到乡镇数据
                                    addressTown = GetTownAddress(url, addressDist[m].ProvID, addressDist[m].Code);
                                    if (addressTown != null && addressTown.Count > 0)
                                    {
                                        for (int n = 0; n < addressTown.Count; n++)
                                        {
                                            #region 得到乡镇街道

                                            ClearData("town"); //清除数据
                                            //得到该县下的乡镇地址
                                            url = addressTown[n].ChildUrl;
                                            //得到街道数据
                                            addressStreet = GetStreetAddress(url, addressTown[n].ProvID, addressTown[n].Code);
                                            dictTown.Add(addressTown[n], addressStreet);

                                            #endregion

                                        }//镇for结束
                                    }//镇if结束

                                    dictDist.Add(addressDist[m], dictTown);

                                    #endregion

                                } // 县for结束

                            } //县if结束

                            dictCity.Add(addressCity[j], dictDist);

                            #endregion

                        }//市for结束

                    } //市if结束 

                    dictProv.Add(addressProv[i], dictCity);
                    //Task task = new Task(() =>
                    //{
                    SaveAddress(dictProv, (i + 1));
                    //});
                    //task.Start();

                    #endregion

                } //省for结束            

            } //省if结束
        }


        /// <summary>
        /// 清除数据
        /// </summary>
        private void ClearData(string clearWhere)
        {
            switch (clearWhere)
            {
                case "prov":
                    {
                        if (addressCity != null) { addressCity.Clear(); }
                        if (addressDist != null) { addressDist.Clear(); }
                        if (addressTown != null) { addressTown.Clear(); }
                        if (dictProv != null) { dictProv.Clear(); }
                    }
                    break;
                case "city":
                    {
                        if (addressDist != null) { addressDist.Clear(); }
                        if (addressTown != null) { addressTown.Clear(); }
                    }
                    break;
                case "dist":
                    {
                        if (addressTown != null) { addressTown.Clear(); }
                    }
                    break;
                case "all":
                    {
                        if (addressProv != null) { addressProv.Clear(); }
                        if (addressCity != null) { addressCity.Clear(); }
                        if (addressDist != null) { addressDist.Clear(); }
                        if (addressTown != null) { addressTown.Clear(); }

                        if (dictTown != null) { dictTown.Clear(); }
                        if (dictDist != null) { dictDist.Clear(); }
                        if (dictCity != null) { dictCity.Clear(); }
                        if (dictProv != null) { dictProv.Clear(); }
                    }
                    break;
            }
            if (dataList != null) { dataList.Clear(); }
            if (addressStreet != null) { addressStreet.Clear(); }
        }


        /// <summary>
        /// 得到省数据
        /// </summary>
        private List<AddressModel> GetProvAddress(string url)
        {
            ProvAddress.Clear();
            // 下载网页页面内容
            pageContent = comm.DownloadPageContent(url, Encoding.Default);

            //过滤地址列表内容
            nameReg = "[省级]";
            contentReg = "暂未公布。<br></td>\r\n</tr>\r\n";
            contentReg += nameReg;
            contentReg += "</table>\r\n</TD>\r\n</TR>\r\n</TBODY>\r\n</TABLE>\r\n</TD>\r\n</TR>\r\n<TR>\r\n<TD style=\"BACKGROUND-REPEAT";

            //过滤出列表内容
            dataResult = comm.GetMatch(pageContent, contentReg, nameReg);

            // 过滤出每个地址
            contentReg = "<td>";
            nameReg = "[省地址]";
            contentReg += nameReg;
            contentReg += "</td>";
            dataList = comm.GetMatchContent(dataResult, contentReg, nameReg);

            //过滤出每个地址的代码和名称
            if (dataList != null && dataList.Count > 0)
            {
                codeReg = "<a href='[省代码].html'>[变量]<br/></a>";
                nameReg = "<a href='[变量]'>[省名称]<br/></a>";
                childUrlReg = "<a href='[子链接]'>[变量]<br/></a>";

                foreach (var item in dataList)
                {
                    keys = comm.GetMatch(item, codeReg, "[省代码]");
                    values = comm.GetMatch(item, nameReg, "[省名称]");
                    childUrl = comm.GetMatch(item, childUrlReg, "[子链接]");

                    //过滤省名称
                    values = values.Replace("市", "").Replace("省", "").Replace("自治区", "").Trim();
                    values = values.Replace("壮族", "").Replace("回族", "").Replace("维吾尔", "").Trim();

                    if (keys != "" && values != "" && childUrl != "")
                    {
                        ProvAddress.Add(new AddressModel()
                        {
                            Code = keys.Trim(),
                            Name = values.Trim(),
                            ChildUrl = GetChildAddressUrl(childUrl).Trim(),
                            ProvID = keys.Trim(),
                            ParentID = "0"
                        });
                    }
                }
            }
            return ProvAddress;
        }


        /// <summary>
        /// 得到市级地址
        /// </summary>
        /// <param name="url"></param>
        private List<AddressModel> GetCityAddress(string url, string prov, string parent)
        {
            // 下载网页页面内容
            pageContent = comm.DownloadPageContent(url, Encoding.Default);

            //过滤地址列表内容
            nameReg = "[市级]";
            contentReg = "vAlign=top>\r\n<table class='citytable'>\r\n";
            contentReg += nameReg;
            contentReg += "</table></TD></TR></TBODY></TABLE></TD></TR>   <TR>\r\n";
            //过滤出列表内容
            dataResult = comm.GetMatch(pageContent, contentReg, nameReg);

            // 过滤出每个地址信息
            contentReg = "<tr class='citytr'>";
            nameReg = "[市地址]";
            contentReg += nameReg;
            contentReg += "</tr>";
            dataList = comm.GetMatchContent(dataResult, contentReg, nameReg);

            //过滤出每个地址的代码和名称
            return GetAddressCodeName(dataList, prov, parent);
        }


        /// <summary>
        /// 得到县级地址
        /// </summary>
        /// <param name="url"></param>
        private List<AddressModel> GetDistrictAddress(string url, string prov, string parent)
        {
            // 下载网页页面内容
            pageContent = comm.DownloadPageContent(url, Encoding.Default);

            //过滤地址列表内容
            nameReg = "[县级]";
            contentReg = "<table class='countytable'>";
            contentReg += nameReg;
            contentReg += "</table></TD></TR></TBODY></TABLE></TD></TR>";
            //过滤出列表内容
            dataResult = comm.GetMatch(pageContent, contentReg, nameReg);

            // 过滤出每个地址信息
            contentReg = "<tr class='countytr'><td>";
            nameReg = "[县地址]";
            contentReg += nameReg;
            contentReg += "</td></tr>";
            dataList = comm.GetMatchContent(dataResult, contentReg, nameReg);

            //过滤出每个地址的代码和名称
            return GetAddressCodeName(dataList, prov, parent);
        }


        /// <summary>
        /// 得到乡镇地址
        /// </summary>
        /// <param name="url"></param>
        /// <param name="prov"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        private List<AddressModel> GetTownAddress(string url, string prov, string parent)
        {
            // 下载网页页面内容
            pageContent = comm.DownloadPageContent(url, Encoding.Default);

            //过滤地址列表内容
            nameReg = "[乡镇级]";
            contentReg = "vAlign=top>\r\n<table class='towntable'>";
            contentReg += nameReg;
            contentReg += "</table></TD></TR></TBODY></TABLE></TD></TR>   <TR>";
            //过滤出列表内容
            dataResult = comm.GetMatch(pageContent, contentReg, nameReg);

            // 过滤出每个地址信息
            contentReg = "<tr class='towntr'><td>";
            nameReg = "[乡镇地址]";
            contentReg += nameReg;
            contentReg += "</td></tr>";
            dataList = comm.GetMatchContent(dataResult, contentReg, nameReg);

            //过滤出每个地址的代码和名称
            return GetAddressCodeName(dataList, prov, parent);
        }



        /// <summary>
        /// 得到街道办地址
        /// </summary>
        /// <param name="url"></param>
        /// <param name="prov"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        private List<AddressModel> GetStreetAddress(string url, string prov, string parent)
        {
            // 下载网页页面内容
            pageContent = comm.DownloadPageContent(url, Encoding.Default);

            //过滤地址列表内容
            nameReg = "[街道级]";
            contentReg = "vAlign=top><table class='villagetable'>";
            contentReg += nameReg;
            contentReg += "</table></TD></TR></TBODY></TABLE></TD></TR>   <TR>";
            //过滤出列表内容
            dataResult = comm.GetMatch(pageContent, contentReg, nameReg);

            // 过滤出每个地址信息
            contentReg = "<tr class='villagetr'><td>";
            nameReg = "[街道地址]";
            contentReg += nameReg;
            contentReg += "</td></tr>";
            dataList = comm.GetMatchContent(dataResult, contentReg, nameReg);

            //过滤出每个地址的代码和名称
            return GetAddressCodeName(dataList, prov, parent);
        }


        /// <summary>
        /// 得到地址的编码和名称
        /// </summary>
        /// <param name="dataList"></param>
        /// <returns></returns>
        private List<AddressModel> GetAddressCodeName(List<string> dataList, string prov, string parent)
        {
            AddressList = new List<AddressModel>();
            //过滤出每个地址的代码和名称
            if (dataList != null && dataList.Count > 0)
            {
                codeReg = "</td><td><a href='[变量]/[代码].html'>[变量]</a>";
                nameReg = "</td><td><a href='[变量]'>[名称]</a>";
                childUrlReg = "</td><td><a href='[子链接]'>[变量]</a>";

                foreach (var item in dataList)
                {
                    keys = comm.GetMatch(item, codeReg, "[代码]");
                    values = comm.GetMatch(item, nameReg, "[名称]");
                    childUrl = comm.GetMatch(item, childUrlReg, "[子链接]");

                    //过滤地址
                    regAddress = "村委会|居委会|基地|委员会|保税区|经济区|物流区|铁路十八局|教育园区|农业园区|科技园|产业园|商务区|科技谷|汽车园|地毯园|京滨园|保税港区|生态城|科技城|生活区|办公室|管委会|服务中心|县区直属镇|技术园区|示范区|单位|博览园|项目区|物流园|公司|示范园|管理局|街道管理中心|筹备处|示范场|龙头分园|繁殖场|救助安置中心|公共服务站|绥化局直|保税片区|度假区|出口加工区|夫管办|高新园区|生态科技岛|大学城|科技创新园|国际创意园|创业|社区|软件谷|实验场|良种繁育场|风景名胜区|生态休闲区|风景区|丝绸市场|农科所|蚕种场|试验|科学园|环科园|食品城|医院|盐场|旅游|管理处|集团|矿务局|办事|苗圃场|保护区|地矿局|人民政府|模拟镇|水库|物流中心|转移园|研究所|热带作物场|校区|学校|工作办|管理委员|学院|指挥部|选育场";

                    if (Regex.IsMatch(values, regAddress, RegexOptions.ECMAScript))
                    { continue; }

                    //过滤掉包含了县名或省名的乡镇名称
                    values = DealTownName(values, prov, parent);
                    //过滤地址名称
                    values = DealAddressName(values);

                    if (prov != parent) { childUrl = string.Format("{0}/{1}", prov, childUrl.TrimStart('/')); }
                    if (keys != "" && values != "" && childUrl != "")
                    {
                        AddressList.Add(new AddressModel()
                        {
                            Code = keys.Trim(),
                            Name = values.Trim(),
                            ChildUrl = GetChildAddressUrl(childUrl).Trim(),
                            ProvID = prov.Trim(),
                            ParentID = parent.Trim()
                        });
                    }
                }
            }
            return AddressList;
        }


        /// <summary>
        /// 过滤掉包含了县名或省名的乡镇名称
        /// </summary>
        /// <param name="name">乡镇名</param>
        /// <param name="prov">省ID</param>
        /// <param name="parent">父级ID</param>
        /// <returns></returns>
        private string DealTownName(string name, string prov, string parent)
        {
            name = name.Trim();
            if (string.IsNullOrEmpty(name)) return "";

            AddressModel provObj = null, townObj = null, distObj = null, cityObj = null;
            if (addressProv != null && addressProv.Count > 0)
            {
                provObj = addressProv.ToList().Where(p => p.Code == prov).FirstOrDefault();
            }
            string provname = provObj == null ? "-22" : provObj.Name;

            if (addressTown != null && addressTown.Count > 0)
            {
                townObj = addressTown.ToList().Where(p => p.Code == parent).FirstOrDefault();
            }
            string townname = townObj == null ? "-22" : townObj.Name;

            if (addressDist != null && addressDist.Count > 0)
            {
                distObj = addressDist.ToList().Where(p => p.Code == (townObj == null ? parent : townObj.ParentID)).FirstOrDefault();
            }
            string distname = distObj == null ? "-22" : distObj.Name;

            if (addressCity != null && addressCity.Count > 0)
            {
                cityObj = addressCity.ToList().Where(p => p.Code == (distObj == null ? parent : distObj.ParentID)).FirstOrDefault();
            }
            string cityname = cityObj == null ? "-22" : cityObj.Name;

            name = name.Replace(provname, "").Replace(distname, "").Replace(cityname, "").Replace(townname, "");
            name = name.Length == 1 ? provname + name : name;
            return name.Trim();
        }


        /// <summary>
        /// 处理地址名称
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private string DealAddressName(string name)
        {
            name = name.Trim();
            if (string.IsNullOrEmpty(name)) return "";

            reg1 = ("回族满族乡|满族蒙古族乡|俄罗斯族民族乡|满族朝鲜族乡|满族蒙古族锡伯族乡|侗族苗族乡|苗族瑶族乡|回族维吾尔族乡|苗族侗族乡|维吾尔族回族乡|壮族瑶族乡|瑶族苗族乡|苗族土家族乡|苗族仡佬族乡|藏族彝族乡|彝族藏族乡|瑶族壮族乡|瑶族水族乡|土家族苗族乡|苗族仡佬族侗族乡|仡佬族侗族乡|侗族仡佬族乡|苗族彝族回族乡|白族彝族苗族乡|彝族白族苗族乡|苗族彝族白族乡|布依族苗族彝族乡|苗族彝族布依族乡|苗族彝族满族乡|彝族苗族布依族乡|白族彝族乡|白族彝族仡佬族乡|彝族蒙古族乡|彝族苗族乡|彝族苗族白族乡|苗族彝族仡佬族乡|彝族苗族满族乡|苗族彝族乡|彝族白族乡|回族苗族乡|苗族布依族乡|仡佬族苗族乡|布依族白族苗族乡|苗族布依族彝族乡|彝族布依族苗族乡|布依族彝族乡|布依族苗族乡|彝族苗族回族乡|苗族回族乡|彝族仡佬族乡|傈僳族彝族乡|苗族壮族乡|傣族傈僳族自治乡|彝族傣族乡|傈僳族普米族乡|傈僳族傣族乡|彝族纳西族乡|回族彝族乡|彝族傈僳族乡|彝族布朗族乡|布朗族彝族乡|回族东乡族乡");
            name = Regex.Replace(name, reg1, "乡", RegexOptions.Multiline);

            reg2 = ("畲族少数民族乡|回族乡|蒙古族乡|朝鲜民族乡|瑶族乡|苗族乡|壮族乡|白族乡|维吾尔族乡|达斡尔族乡|鄂温克族乡|鄂伦春族民族乡|畲族乡|满族乡|朝鲜族乡|土家族乡|侗族乡|仫佬族乡|土家族自治乡|藏族乡|傣族乡|傈僳族乡|纳西族乡|彝族乡|羌族乡|毛南族乡|水族乡|布依族乡|仡佬族乡|阿昌族乡|傣族自治乡|白族自治乡|拉祜族乡|哈尼族乡|佤族乡|土族乡|东乡族乡|蔵族乡|蒙古民族乡|柯尔克孜民族乡|柯尔克孜族乡|塔吉克族乡|回族民族乡|哈萨克民族乡|哈萨克乡");
            name = Regex.Replace(name, reg2, "乡", RegexOptions.Multiline);


            reg3 = ("满族蒙古族自治县|苗族侗族自治县|壮族瑶族自治县|仫佬族自治县|毛南族自治县|黎族苗族自治县|苗族土家族自治县|土家族苗族自治县|彝族回族苗族自治县|苗族布依族自治县|布依族苗族自治县|仡佬族苗族自治县|彝族回族自治县|独龙族怒族自治县|白族普米族自治县|苗族瑶族傣族自治县|拉祜族佤族布朗族傣族自治县|傣族佤族自治县|哈尼族彝族自治县|傣族彝族自治县|彝族哈尼族拉祜族自治县|傣族拉祜族佤族自治县|哈尼族彝族傣族自治县|彝族傣族自治县|彝族苗族自治县|回族彝族自治县|保安族东乡族撒拉族自治县|回族土族自治县");
            name = Regex.Replace(name, reg3, "县", RegexOptions.Multiline);

            reg4 = ("土家族自治县|回族自治县|蒙古族自治县|满族自治县|朝鲜族自治县|畲族自治县|侗族自治县|瑶族自治县|苗族自治县|各族自治县|黎族县|黎族自治县|藏族自治县|彝族自治县|羌族自治县|水族自治县|傈僳族自治县|佤族自治县|哈尼族自治县|拉祜族自治县|纳西族自治县|哈萨克族自治县|裕固族自治县|土族自治县|撒拉族自治县|蒙古自治县|锡伯自治县|塔吉克自治县|哈萨克自治县");
            name = Regex.Replace(name, reg4, "县", RegexOptions.Multiline);


            reg5 = ("达斡尔族自治旗");
            name = Regex.Replace(name, reg5, "旗", RegexOptions.Multiline);

            reg6 = ("自治旗");
            name = Regex.Replace(name, reg6, "旗", RegexOptions.Multiline);


            reg7 = ("满族锡伯族镇");
            name = Regex.Replace(name, reg7, "镇", RegexOptions.Multiline);

            reg8 = ("满族镇|朝鲜族镇|蒙古族镇|达斡尔族镇|畲族镇|回族镇|瑶族镇");
            name = Regex.Replace(name, reg8, "镇", RegexOptions.Multiline);


            reg9 = ("土家族苗族自治州|藏族羌族自治州|布依族苗族自治州|苗族侗族自治州|哈尼族彝族自治州|壮族苗族自治州|傣族景颇族自治州|蒙古族藏族自治州");
            name = Regex.Replace(name, reg9, "州", RegexOptions.Multiline);



            reg10 = ("朝鲜族自治州|藏族自治州|彝族自治州|傣族自治州|傈僳族自治州|白族自治州|回族自治州|哈萨克自治州|蒙古自治州|柯尔克孜自治州");
            name = Regex.Replace(name, reg10, "州", RegexOptions.Multiline);


            name = Regex.Replace(name, "达斡尔族区|回族区", "区", RegexOptions.Multiline);


            name = Regex.Replace(name, "呼伦贝尔新城区", "新城区", RegexOptions.Multiline);
            name = Regex.Replace(name, "东土城劳动教养管理所", "东土城", RegexOptions.Multiline);
            name = Regex.Replace(name, "孟恩套力盖矿区工作部", "孟恩套力盖矿区", RegexOptions.Multiline);
            name = Regex.Replace(name, "布敦化矿区工作部", "布敦化矿区", RegexOptions.Multiline);
            name = Regex.Replace(name, "自治区图牧吉强制隔离戒毒所", "图牧吉劳管所", RegexOptions.Multiline);
            name = Regex.Replace(name, "二连边境经济技术合作区", "边境经济技术合作区", RegexOptions.Multiline);
            name = Regex.Replace(name, "西乌旗白音华能源化工园区", "白音华能源化工园区", RegexOptions.Multiline);
            name = Regex.Replace(name, "多伦新型工业化化工区", "新型工业化化工区", RegexOptions.Multiline);
            name = Regex.Replace(name, "大黑山特别行政管理区", "大黑山管理区", RegexOptions.Multiline);
            name = Regex.Replace(name, "得力其鄂温克民族乡", "得力其尔乡", RegexOptions.Multiline);
            name = Regex.Replace(name, "音河达斡尔鄂温克民族乡", "音河乡", RegexOptions.Multiline);
            name = Regex.Replace(name, "巴彦塔拉达斡尔民族乡", "巴彦塔拉乡", RegexOptions.Multiline);
            name = Regex.Replace(name, "延边新兴工业集中区", "延边工业区", RegexOptions.Multiline);
            name = Regex.Replace(name, "临江硅藻土工业集中区", "硅藻土工业区", RegexOptions.Multiline);
            name = Regex.Replace(name, "龙河镇保安林场", "保安林场", RegexOptions.Multiline);
            name = Regex.Replace(name, "龙河镇茂山林场", "茂山林场", RegexOptions.Multiline);
            name = Regex.Replace(name, "龙河镇国庆林场", "国庆林场", RegexOptions.Multiline);
            name = Regex.Replace(name, "学田镇富源林场", "富源林场", RegexOptions.Multiline);
            name = Regex.Replace(name, "老莱镇宽余林场", "宽余林场", RegexOptions.Multiline);
            name = Regex.Replace(name, "六合镇黎明奶牛场", "黎明奶牛场", RegexOptions.Multiline);
            name = Regex.Replace(name, "孔国乡进化种猪场", "进化种猪场", RegexOptions.Multiline);
            name = Regex.Replace(name, "二克浅镇二里种畜场", "二里种畜场", RegexOptions.Multiline);
            name = Regex.Replace(name, "龙河镇青色草原种畜场", "青色草原种畜场", RegexOptions.Multiline);
            name = Regex.Replace(name, "桦南林业局岚峰林场", "岚峰林场", RegexOptions.Multiline);
            name = Regex.Replace(name, "庐阳工业区（林店街道）", "林店街道", RegexOptions.Multiline);
            name = Regex.Replace(name, "岭下溪国有防护林场", "岭下溪林场", RegexOptions.Multiline);
            name = Regex.Replace(name, "新康府街道（油茶林场）", "新康府街道", RegexOptions.Multiline);
            name = Regex.Replace(name, "平度外向型工业加工区", "工业加工区", RegexOptions.Multiline);
            name = Regex.Replace(name, "中沙群岛的岛礁及其海域", "中沙群岛", RegexOptions.Multiline);
            name = Regex.Replace(name, "大理创新工业园区凤仪镇", "凤仪镇", RegexOptions.Multiline);
            name = Regex.Replace(name, "西双版纳磨憨经济开发区（尚勇镇）", "尚勇镇", RegexOptions.Multiline);
            name = Regex.Replace(name, "街道办", "街道", RegexOptions.Multiline);

            name = Regex.Replace(name, "镇政府", "镇", RegexOptions.Multiline);
            name = Regex.Replace(name, "兵团喀拉拜勒镇", "喀拉拜勒镇", RegexOptions.Multiline);




            name = Regex.Replace(name, "鄂温克民族乡", "乡", RegexOptions.Multiline);
            name = Regex.Replace(name, "民族乡", "乡", RegexOptions.Multiline);


            name = Regex.Replace(name, "陈旗", "", RegexOptions.Multiline);
            name = Regex.Replace(name, "（中心团场）", "", RegexOptions.Multiline);
            name = Regex.Replace(name, "中心团场", "", RegexOptions.Multiline);

            regName = "萧山商业城|萧山钱江世纪城|县特产场场区|花凉亭水电站|薛楼板材加工园|水产局管辖村|火车站站前区|产业集中区|庐山林科所|庐山生态文化新城|建筑材料厂|信阳国际家居产业小镇|西蒿漆场|旱粮粮种场|网岭循环经济园|醴陵经济开发区|白云山农垦场|扁朝牧场|麻风村|韶关发电厂|大宝山矿|前海合作区|宝安国际机场|翠山湖新区|硫铁矿|南山矿|经济技术开发区|城中办街道事处|城北办街道事处|小峰经济作物场|德保铝业|来华投资区|中沙岛礁|辖曼牧场|白河牧场|九寨沟国营牧场|三溪口森林经营所|绵竹经济开发区|酒业集中发展区|高新技术开发区|保山工贸园区|红河谷森林公园|马头滩林业局|辛家山林业场|高校园区|氟化硅产业业园|苗圃|木王林厂|黑窑沟林厂|桑科种羊场|机饲总站|种子站|大水军牧场|河曲马场|国营柏林牧场|国营大峪牧场|小泉子治沙站|张掖宝瓶河牧场|省绵羊育种场|张掖滨河新区|天祝建材厂|天水经济开发区|莫河畜牧场|铁卜加草改站|曹家堡临空综合|安置农场|巴卡台农场|海兴开发区|涵养林总场|国营农林牧场|巴尔鲁克山塔斯特林场|老风口林场|白杨河林场|科克苏林场|特克斯军马场|天山西部林业局昭苏林场|公安农场|都拉塔口岸|山区林场|平原林场|良种繁育中心|综合开发区|经济新区|巴扎达什牧林场|麻扎尔种羊场|疏附广州工业城|新垦农场|库车种羊场|水电二处|马兰公安管区|兵团农二师湖光糖厂|自治区林业厅玛纳斯平原林场|哈密伊吾马场";

            regName += "|管理区|矿区|园艺场|工业园区|良种场|大畜场|奶牛场|种畜场|原种场|监狱|工业集中区|工业加工区|技术产业开发区|工业区";
            //regName += "|茶场|工业园|原种场|良种场|养殖场|管理区|机械厂|园艺场|棉科所|工业聚集区|畜牧场|劳教所|林场|农场|监狱|管理所|林业局|化工园区";

            if (Regex.IsMatch(name, regName, RegexOptions.ECMAScript))
            { return ""; }

            return name.Trim();
        }



        /// <summary>
        /// 得到子链接地址
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private string GetChildAddressUrl(string url)
        {
            return string.Format("http://www.stats.gov.cn/tjsj/tjbz/tjyqhdmhcxhfdm/2016/{0}", url.TrimStart('/'));
        }


        /// <summary>
        /// 保存地址
        /// </summary>
        /// <param name="DictAddress"></param>
        private void SaveAddress(Dictionary<object, object> DictAddress, int provSort)
        {
            AddressModel addressProvObj = null, addressCityObj = null, addressDistObj = null, addressTownObj = null, addressStreetObj = null;

            Dictionary<object, object> dictProvObj = null, dictCityObj = null;
            Dictionary<object, List<AddressModel>> dictDistObj = null;
            List<AddressModel> dictTownObj = null;
            string sqlProv = "", sqlCity = "", sqlDist = "", sqlTown = "", sqlStreet = "";
            int citySort = 1, distSort = 1, townSort = 1, streetSort = 1;

            if (DictAddress != null && DictAddress.Count > 0)
            {
                foreach (var itemProv in DictAddress) //编历省
                {
                    addressProvObj = itemProv.Key as AddressModel;
                    //插入省                  
                    sqlProv += "insert into test_address";
                    sqlProv += string.Format(" values('{0}','86','{1}','0','0','0','0','','','{1}','{0}',0,'','',{2});", addressProvObj.Name, addressProvObj.Code, provSort);

                    comm.SaveInfo(sqlProv);

                    dictProvObj = itemProv.Value as Dictionary<object, object>; //市数据
                    if (dictProvObj != null && dictProvObj.Count > 0)
                    {
                        foreach (var itemCity in dictProvObj) //编历市
                        {
                            addressCityObj = itemCity.Key as AddressModel;
                            //插入市
                            sqlCity += "insert into test_address";
                            sqlCity += string.Format(" values('{0}','86','{1}','{2}','0','0','0','','','{1}-{2}','{3}-{0}',0,'','',{4});", addressCityObj.Name, addressProvObj.Code, addressCityObj.Code, addressProvObj.Name, citySort);

                            citySort++;
                            if (addressProvObj.Code == "11" || addressProvObj.Code == "12" || addressProvObj.Code == "31" || addressProvObj.Code == "50")
                            {
                                comm.SaveInfo(sqlCity);
                                citySort = 1; sqlCity = "";
                            }
                            else
                            {
                                if (citySort == 51 && sqlCity != "")
                                {
                                    comm.SaveInfo(sqlCity);
                                    citySort = 1; sqlCity = "";
                                }
                            }

                            dictCityObj = itemCity.Value as Dictionary<object, object>; //县数据
                            if (dictCityObj != null && dictCityObj.Count > 0)
                            {
                                foreach (var itemDist in dictCityObj)
                                {
                                    addressDistObj = itemDist.Key as AddressModel;
                                    //插入县                                   
                                    sqlDist += "insert into test_address";
                                    sqlDist += string.Format(" values('{0}','86','{1}','{2}','{3}','0','0','','','{1}-{2}-{3}','{4}-{5}-{0}',0,'','',{6});", addressDistObj.Name, addressProvObj.Code, addressCityObj.Code, addressDistObj.Code, addressProvObj.Name, addressCityObj.Name, distSort);

                                    distSort++;
                                    if (distSort == 51 && sqlDist != "")
                                    {
                                        comm.SaveInfo(sqlDist);
                                        distSort = 1; sqlDist = "";
                                    }
                                    dictDistObj = itemDist.Value as Dictionary<object, List<AddressModel>>; //乡镇数据
                                    if (dictDistObj != null && dictDistObj.Count > 0)
                                    {
                                        foreach (var itemTown in dictDistObj)
                                        {
                                            addressTownObj = itemTown.Key as AddressModel;
                                            //插入镇
                                            sqlTown += "insert into test_address";
                                            sqlTown += string.Format(" values('{0}','86','{1}','{2}','{3}','{4}','0','','','{1}-{2}-{3}-{4}','{5}-{6}-{7}-{8}',0,'','',{9});", addressTownObj.Name, addressProvObj.Code, addressCityObj.Code, addressDistObj.Code, addressTownObj.Code, addressProvObj.Name, addressCityObj.Name, addressDistObj.Name, addressTownObj.Name, townSort);

                                            townSort++;
                                            if (townSort == 51 && sqlTown != "")
                                            {
                                                comm.SaveInfo(sqlTown);
                                                townSort = 1; sqlTown = "";
                                            }

                                            dictTownObj = itemTown.Value as List<AddressModel>; //街道数据
                                            if (dictTownObj != null && dictTownObj.Count > 0)
                                            {
                                                foreach (var itemStreet in dictTownObj)
                                                {
                                                    addressStreetObj = itemStreet as AddressModel;
                                                    //插入街道
                                                    sqlStreet += "insert into test_address";
                                                    sqlStreet += string.Format(" values('{0}','86','{1}','{2}','{3}','{4}','{5}','','','{1}-{2}-{3}-{4}-{5}','{6}-{7}-{8}-{9}-{0}',0,'','',{10});", addressStreetObj.Name, addressProvObj.Code, addressCityObj.Code, addressTownObj.Code, addressTownObj.Code, addressStreetObj.Code, addressProvObj.Name, addressCityObj.Name, addressDistObj.Name, addressTownObj.Name, streetSort);

                                                    streetSort++;
                                                    if (streetSort == 51 && sqlStreet != "")
                                                    {
                                                        comm.SaveInfo(sqlStreet);
                                                        streetSort = 1; sqlStreet = "";
                                                    }

                                                }//街道数据for结束
                                                if (streetSort > 0 && sqlStreet != "")
                                                {
                                                    comm.SaveInfo(sqlStreet);
                                                    streetSort = 1; sqlStreet = "";
                                                }
                                            }//街道数据if结束
                                        } //乡镇数据for结束
                                        if (townSort > 0 && sqlTown != "")
                                        {
                                            comm.SaveInfo(sqlTown);
                                            townSort = 1; sqlTown = "";
                                        }
                                    } //乡镇数据if结束
                                }//县数据for结束
                                if (distSort > 0 && sqlDist != "")
                                {
                                    comm.SaveInfo(sqlDist);
                                    distSort = 1; sqlDist = "";
                                }
                            }//县数据if结束
                        } //市数据for结束
                        if (citySort > 0 && sqlCity != "")
                        {
                            comm.SaveInfo(sqlCity);
                            citySort = 1; sqlCity = "";
                        }

                    } //市数据if结束
                } //省数据for结束
            } //数据列表if结束
        }





    }
}