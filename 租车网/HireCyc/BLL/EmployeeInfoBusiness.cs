using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// 员工表BLL
    /// </summary>
  public class EmployeeInfoBusiness
    {
        /// <summary>
        /// 添加员工（管理员）表信息
        /// </summary>
        /// <param name="employeeInfo"></param>
        /// <returns></returns>
        public static bool EmployeeInfoAdd(Model.EmployeeInfo employeeInfo)
        {
            return DAL.EmployeeInfoDataAccess.EmployeeInfoAdd(employeeInfo);
        }

        /// <summary>
        /// 根据帐号删除数据
        /// </summary>
        /// <param name="UserAccount">账号</param>
        /// <returns></returns>
        public static bool EmployeeInfoDel(string EmployeeAccount)
        {
            return DAL.EmployeeInfoDataAccess.EmployeeInfoDel(EmployeeAccount);
        }

        /// <summary>
        /// 根据帐号和原密码修改密码
        /// </summary>
        /// <param name="EmployeeAccount">账号</param>
        /// <param name="EmployeePassword1">原密码</param>
        /// <param name="EmployeePassword2">新密码</param>
        /// <returns></returns>
        public static bool EmployeeInfoUpdatePass(string EmployeeAccount, string EmployeePassword1, string EmployeePassword2)
        {
            return DAL.EmployeeInfoDataAccess.EmployeeInfoUpdatePass(EmployeeAccount, EmployeePassword1, EmployeePassword2);
        }

        /// <summary>
        /// 修改员工的职位和部门
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public static bool EmployeeInfoUpdate(Model.EmployeeInfo employeeInfo)
        {
            return DAL.EmployeeInfoDataAccess.EmployeeInfoUpdate(employeeInfo);
        }

        /// <summary>
        /// 员工权限修改
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="power">新权限编号</param>
        /// <returns></returns>
        public static bool EmployeeInfoUpdatePower(string account, int power)
        {
            return DAL.EmployeeInfoDataAccess.EmployeeInfoUpdatePower(account, power);
        }

        /// <summary>
        /// 员工修改密码
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="password">新密码</param>
        /// <returns></returns>
        public static bool EmployeeInfoForgetPass(string account, string password)
        {
            return DAL.EmployeeInfoDataAccess.EmployeeInfoForgetPass(account, password);
        }

        /// <summary>
        ///员工修改电话号码
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="tel">新电话号码</param>
        /// <returns></returns>
        public static bool EmployeeInfoUpdateTel(string account, string tel)
        {
            return DAL.EmployeeInfoDataAccess.EmployeeInfoUpdateTel(account, tel);
        }

        /// <summary>
        /// 员工修改家庭地址
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="address">新地址</param>
        /// <returns></returns>
        public static bool EmployeeInfoUpdateAddress(string account, string address)
        {
            return DAL.EmployeeInfoDataAccess.EmployeeInfoUpdateAddress(account, address);
        }

        /// <summary>
        /// 员工登陆
        /// </summary>
        /// <param name="UserAccount">账号</param>
        /// <param name="UserPassword">密码</param>
        /// <returns></returns>
        public static bool EmployeeInfoDengLu(string EmployeeAccount, string EmployeePassword)
        {
            return DAL.EmployeeInfoDataAccess.EmployeeInfoDengLu(EmployeeAccount, EmployeePassword);
        }

        /// <summary>
        /// 根据帐号查询数据
        /// </summary>
        /// <param name="UserAccount">账号</param>
        /// <returns></returns>
        public static List<Model.EmployeeInfo> EmployeeInfoLookByAcc(string EmployeeAccount)
        {
            return DAL.EmployeeInfoDataAccess.EmployeeInfoLookByAcc(EmployeeAccount);
        }

        /// <summary>
        /// 根据帐号查看权限名称
        /// </summary>
        /// <param name="UserNickName">账号</param>
        /// <returns></returns>
        public static string EmployeeInfoLookPowByAcc(string EmployeeAccount)
        {
            return DAL.EmployeeInfoDataAccess.EmployeeInfoLookPowByAcc(EmployeeAccount);
        }

        /// <summary>
        /// 根据部门查询
        /// </summary>
        /// <param name="EmployeeDepartment">部门名称</param>
        /// <returns></returns>
        public static List<Model.EmployeeInfo> EmployeeInfoLookDept(string EmployeeDepartment)
        {
            return DAL.EmployeeInfoDataAccess.EmployeeInfoLookDept(EmployeeDepartment);
        }

        /// <summary>
        /// 查询所有的员工信息
        /// </summary>
        /// <returns></returns>
        public static List<Model.EmployeeInfo> EmployeeInfoLookALLEmp()
        {
            return DAL.EmployeeInfoDataAccess.EmployeeInfoLookALLEmp();
        }

        /// <summary>
        /// 查询所有的员工账号
        /// </summary>
        /// <returns></returns>
        public static List<string> EmployeeInfoLookALLAcc()
        {
            return DAL.EmployeeInfoDataAccess.EmployeeInfoLookALLAcc();
        }

        /// <summary>
        /// 查询出进公司年限大于多少年的员工
        /// </summary>
        /// <param name="EmployeeSettime">多少年以上</param>
        /// <returns></returns>
        public static List<Model.EmployeeInfo> employeeInfo(int EmployeeSettime)
        {
            return DAL.EmployeeInfoDataAccess.employeeInfo(EmployeeSettime);
        }


        /// <summary>
        /// 判断指定的用户账号是否存在
        /// </summary>
        /// <param name="id">要判断的账号</param>
        /// <returns></returns>
        public static bool EmployeeInfoAccountIsExist(string account)
        {
            return DAL.EmployeeInfoDataAccess.EmployeeInfoAccountIsExist(account);
        }

        /// <summary>
        /// 分页显示
        /// </summary>
        /// <param name="ys">页数</param>
        /// <param name="count">每页的条数</param>
        /// <returns>list值</returns>
        public static List<Model.EmployeeInfo> EmployeeInfoFeny(int ys, int count)
        {
            return DAL.EmployeeInfoDataAccess.EmployeeInfoFeny(ys, count);
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="count">每页的条数</param>
        /// <returns>int值，总页数</returns>
        public static int EmployeeInfoYs(int count)
        {
            return DAL.EmployeeInfoDataAccess.EmployeeInfoYs(count);
        }
    }
}
