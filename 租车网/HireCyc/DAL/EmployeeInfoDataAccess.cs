using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// 员工类的处理
    /// </summary>
    public class EmployeeInfoDataAccess
    {
        /// <summary>
        /// 添加员工（管理员）表信息
        /// </summary>
        /// <param name="employeeInfo"></param>
        /// <returns></returns>
        public static bool EmployeeInfoAdd(Model.EmployeeInfo employeeInfo)
        {
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@Account",employeeInfo.EmployeeAccount),
                new SqlParameter("@Password",employeeInfo.EmployeePassword),
                new SqlParameter("@Name",employeeInfo.EmployeeName),
                new SqlParameter("@Sex",employeeInfo.EmployeerSex),
                new SqlParameter("@Power",employeeInfo.EmployeePower),
                new SqlParameter("@Certificate",employeeInfo.EmployeeCertificate),
                new SqlParameter("@Tel",employeeInfo.EmployeeTel),
                new SqlParameter("@Email",employeeInfo.EmployeeEmail),
                new SqlParameter("@Birth",employeeInfo.EmployeeBirth),
                new SqlParameter("@Address",employeeInfo.EmployeeAddress),
                new SqlParameter("@Position",employeeInfo.EmployeePosition),
                new SqlParameter("@Department",employeeInfo.EmployeeDepartment)
            };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("EmployeeInfoAdd", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 根据帐号删除数据
        /// </summary>
        /// <param name="UserAccount">账号</param>
        /// <returns></returns>
        public static bool EmployeeInfoDel(string EmployeeAccount)
        {
            SqlParameter[] p = new SqlParameter[]
            {
               new SqlParameter("@account",EmployeeAccount)
            };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("EmployeeInfoDel", CommandType.StoredProcedure, p));
            return i > 0;
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
            SqlParameter[] p = new SqlParameter[]
             {
               new SqlParameter("@Account",EmployeeAccount),
               new SqlParameter("@Password1",EmployeePassword1),
               new SqlParameter("@Password2",EmployeePassword2)
             };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("EmployeeInfoUpdatePass", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 修改员工的职位和部门
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public static bool EmployeeInfoUpdate(Model.EmployeeInfo employeeInfo)
        {
            SqlParameter[] p = new SqlParameter[]
             {
                new SqlParameter("@Account",employeeInfo.EmployeeAccount),
                new SqlParameter("@Position",employeeInfo.EmployeePosition),
                new SqlParameter("@Department",employeeInfo.EmployeeDepartment)
             };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("EmployeeInfoUpdateJob", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 员工权限修改
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="power">新权限编号</param>
        /// <returns></returns>
        public static bool EmployeeInfoUpdatePower(string account, int power)
        {
            SqlParameter[] p = new SqlParameter[]
             {
                new SqlParameter("@Account",account),
                new SqlParameter("@Power",power)
             };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("EmployeeInfoUpdatePower", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 员工修改密码
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="password">新密码</param>
        /// <returns></returns>
        public static bool EmployeeInfoForgetPass(string account, string password)
        {
            SqlParameter[] p = new SqlParameter[]
             {
                new SqlParameter("@Account",account),
                new SqlParameter("@Password",password)
             };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("EmployeeInfoForgetPass", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        ///员工修改电话号码
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="tel">新电话号码</param>
        /// <returns></returns>
        public static bool EmployeeInfoUpdateTel(string account, string tel)
        {
            SqlParameter[] p = new SqlParameter[]
             {
                new SqlParameter("@Account",account),
                new SqlParameter("@Tel",tel)
             };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("EmployeeInfoUpdateTel", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 员工修改家庭地址
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="address">新地址</param>
        /// <returns></returns>
        public static bool EmployeeInfoUpdateAddress(string account, string address)
        {
            SqlParameter[] p = new SqlParameter[]
             {
                new SqlParameter("@Account",account),
                new SqlParameter("@Address",address)
             };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("EmployeeInfoUpdateAddress", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 员工登陆
        /// </summary>
        /// <param name="UserAccount">账号</param>
        /// <param name="UserPassword">密码</param>
        /// <returns></returns>
        public static bool EmployeeInfoDengLu(string EmployeeAccount, string EmployeePassword)
        {
            SqlParameter[] p = new SqlParameter[]
            {
              new SqlParameter("@Account",EmployeeAccount),
              new SqlParameter("@Password",EmployeePassword)
            };
            int i = Convert.ToInt32(SQLHelper.ExecuteScalar("EmployeeInfoDengLu", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 根据帐号查询数据
        /// </summary>
        /// <param name="UserAccount">账号</param>
        /// <returns></returns>
        public static List<Model.EmployeeInfo> EmployeeInfoLookByAcc(string EmployeeAccount)
        {
            List<Model.EmployeeInfo> list = new List<Model.EmployeeInfo>();

            SqlParameter[] p = new SqlParameter[]
            {
              new SqlParameter("@account",EmployeeAccount)
            };
            SqlDataReader sdr = SQLHelper.ExecuteDataReader("EmployeeInfoLookByAcc", CommandType.StoredProcedure, p);

            while (sdr.Read())
            {
                Model.EmployeeInfo employeeInfo = new Model.EmployeeInfo();//创建一个Emp对象

                employeeInfo.EmployeeName = Convert.ToString(sdr["姓名"]);
                employeeInfo.EmployeerSex = Convert.ToString(sdr["性别"]);
                employeeInfo.EmployeePower = Convert.ToInt32(sdr["权限"]);
                employeeInfo.EmployeeCertificate = Convert.ToString(sdr["身份证号"]);
                employeeInfo.EmployeeTel = Convert.ToString(sdr["电话"]);
                employeeInfo.EmployeeEmail = Convert.ToString(sdr["邮箱"]);
                employeeInfo.EmployeeBirth = Convert.ToDateTime(sdr["出生日期"]);
                employeeInfo.EmployeeAddress = Convert.ToString(sdr["地址"]);
                employeeInfo.EmployeeSettime = Convert.ToDateTime(sdr["进公司时间"]);
                employeeInfo.EmployeePosition = Convert.ToString(sdr["职位"]);
                employeeInfo.EmployeeDepartment = Convert.ToString(sdr["部门"]);

                list.Add(employeeInfo);
            }
            return list;
        }

        /// <summary>
        /// 根据帐号查看权限名称
        /// </summary>
        /// <param name="UserNickName">账号</param>
        /// <returns></returns>
        public static string EmployeeInfoLookPowByAcc(string EmployeeAccount)
        {
            SqlParameter[] p = new SqlParameter[]
             {
              new SqlParameter("@account",EmployeeAccount)
             };
            string power = Convert.ToString(SQLHelper.ExecuteScalar("EmployeeInfoLookPowByAcc", CommandType.StoredProcedure, p));
            return power;
        }

        /// <summary>
        /// 根据部门查询
        /// </summary>
        /// <param name="EmployeeDepartment">部门名称</param>
        /// <returns></returns>
        public static List<Model.EmployeeInfo> EmployeeInfoLookDept(string EmployeeDepartment)
        {
            List<Model.EmployeeInfo> list = new List<Model.EmployeeInfo>();

            SqlParameter[] p = new SqlParameter[]
            {
              new SqlParameter("@Department",EmployeeDepartment)
            };
            SqlDataReader sdr = SQLHelper.ExecuteDataReader("EmployeeInfoLookByDepar", CommandType.StoredProcedure, p);
            while (sdr.Read())
            {
                Model.EmployeeInfo employeeInfo = new Model.EmployeeInfo();//创建一个对象

                employeeInfo.EmployeeAccount = Convert.ToString(sdr["账号"]);
                employeeInfo.EmployeeName = Convert.ToString(sdr["姓名"]);
                employeeInfo.EmployeerSex = Convert.ToString(sdr["性别"]);
                employeeInfo.EmployeePower = Convert.ToInt32(sdr["权限"]);
                employeeInfo.EmployeeCertificate = Convert.ToString(sdr["身份证号"]);
                employeeInfo.EmployeeTel = Convert.ToString(sdr["电话"]);
                employeeInfo.EmployeeEmail = Convert.ToString(sdr["邮箱"]);
                employeeInfo.EmployeeBirth = Convert.ToDateTime(sdr["出生日期"]);
                employeeInfo.EmployeeAddress = Convert.ToString(sdr["地址"]);
                employeeInfo.EmployeeSettime = Convert.ToDateTime(sdr["进公司时间"]);
                employeeInfo.EmployeePosition = Convert.ToString(sdr["职位"]);

                list.Add(employeeInfo);
            }
            return list;
        }

        /// <summary>
        /// 查询所有的员工信息
        /// </summary>
        /// <returns></returns>
        public static List<Model.EmployeeInfo> EmployeeInfoLookALLEmp()
        {
            List<Model.EmployeeInfo> list = new List<Model.EmployeeInfo>();

            SqlDataReader sdr = SQLHelper.ExecuteDataReader("EmployeeInfoLookAllEmp", CommandType.StoredProcedure);

            while (sdr.Read())
            {
                Model.EmployeeInfo employeeInfo = new Model.EmployeeInfo();//创建一个对象

                employeeInfo.EmployeeAccount = Convert.ToString(sdr["帐号"]);
                employeeInfo.EmployeeName = Convert.ToString(sdr["姓名"]);
                employeeInfo.EmployeerSex = Convert.ToString(sdr["性别"]);
                employeeInfo.EmployeePower = Convert.ToInt32(sdr["权限"]);
                employeeInfo.EmployeeCertificate = Convert.ToString(sdr["身份证号"]);
                employeeInfo.EmployeeTel = Convert.ToString(sdr["电话"]);
                employeeInfo.EmployeeEmail = Convert.ToString(sdr["邮箱"]);
                employeeInfo.EmployeeBirth = Convert.ToDateTime(sdr["出生日期"]);
                employeeInfo.EmployeeAddress = Convert.ToString(sdr["地址"]);
                employeeInfo.EmployeeSettime = Convert.ToDateTime(sdr["进公司时间"]);
                employeeInfo.EmployeePosition = Convert.ToString(sdr["职位"]);
                employeeInfo.EmployeeDepartment = Convert.ToString(sdr["部门"]);

                list.Add(employeeInfo);
            }
            return list;
        }

        /// <summary>
        /// 查询所有的员工账号
        /// </summary>
        /// <returns></returns>
        public static List<string> EmployeeInfoLookALLAcc()
        {
            List<string> list = new List<string>();

            SqlDataReader sdr = SQLHelper.ExecuteDataReader("EmployeeInfoLookAllAcc", CommandType.StoredProcedure);

            while (sdr.Read())
            {
                string EmployeeAccount = Convert.ToString(sdr["帐号"]);

                list.Add(EmployeeAccount);
            }
            return list;
        }

        /// <summary>
        /// 查询出进公司年限大于多少年的员工
        /// </summary>
        /// <param name="EmployeeSettime">多少年以上</param>
        /// <returns></returns>
        public static List<Model.EmployeeInfo> employeeInfo(int EmployeeSettime)
        {
            List<Model.EmployeeInfo> list = new List<Model.EmployeeInfo>();

            SqlParameter[] p = new SqlParameter[]
            {
              new SqlParameter("@year",EmployeeSettime)
            };

            SqlDataReader sdr = SQLHelper.ExecuteDataReader("EmployeeInfoLookBySettime", CommandType.StoredProcedure, p);
            while (sdr.Read())
            {
                Model.EmployeeInfo employeeInfo = new Model.EmployeeInfo();//创建一个User对象

                employeeInfo.EmployeeAccount = Convert.ToString(sdr["账号"]);
                employeeInfo.EmployeeName = Convert.ToString(sdr["姓名"]);
                employeeInfo.EmployeerSex = Convert.ToString(sdr["性别"]);
                employeeInfo.EmployeePower = Convert.ToInt32(sdr["权限"]);
                employeeInfo.EmployeeCertificate = Convert.ToString(sdr["身份证号"]);
                employeeInfo.EmployeeTel = Convert.ToString(sdr["电话"]);
                employeeInfo.EmployeeEmail = Convert.ToString(sdr["邮箱"]);
                employeeInfo.EmployeeBirth = Convert.ToDateTime(sdr["出生日期"]);
                employeeInfo.EmployeeAddress = Convert.ToString(sdr["地址"]);
                employeeInfo.EmployeeSettime = Convert.ToDateTime(sdr["进公司时间"]);
                employeeInfo.EmployeePosition = Convert.ToString(sdr["职位"]);
                employeeInfo.EmployeeDepartment = Convert.ToString(sdr["部门"]);
                list.Add(employeeInfo);
            }
            return list;
        }


        /// <summary>
        /// 判断指定的用户账号是否存在
        /// </summary>
        /// <param name="id">要判断的账号</param>
        /// <returns></returns>
        public static bool EmployeeInfoAccountIsExist(string account)
        {
            SqlParameter[] p = new SqlParameter[]
            {
               new SqlParameter("@account",account)
             };
            int f = Convert.ToInt32(SQLHelper.ExecuteScalar("EmployeeInfoAccountIsExist", CommandType.StoredProcedure, p));

            return f == 1;   //为真表示存在
        }


        /// <summary>
        /// 分页显示
        /// </summary>
        /// <param name="ys">页数</param>
        /// <param name="count">每页的条数</param>
        /// <returns>list值</returns>
        public static List<Model.EmployeeInfo> EmployeeInfoFeny(int ys, int count)
        {
            List<Model.EmployeeInfo> list = new List<Model.EmployeeInfo>();

            SqlParameter[] p = new SqlParameter[]
            {
              new SqlParameter("@ys",ys),
              new SqlParameter("@count",count)
            };
            SqlDataReader sdr = SQLHelper.ExecuteDataReader("EmployeeInfoFeny", CommandType.StoredProcedure, p);
            while (sdr.Read())
            {
                Model.EmployeeInfo employeeInfo = new Model.EmployeeInfo();//创建一个对象
                employeeInfo.EmployeeId = Convert.ToInt32(sdr["编号"]);
                employeeInfo.EmployeeName = Convert.ToString(sdr["姓名"]);
                employeeInfo.EmployeerSex = Convert.ToString(sdr["性别"]);
                employeeInfo.EmployeePower = Convert.ToInt32(sdr["权限"]);
                employeeInfo.EmployeeCertificate = Convert.ToString(sdr["身份证号"]);
                employeeInfo.EmployeeTel = Convert.ToString(sdr["电话"]);
                employeeInfo.EmployeeEmail = Convert.ToString(sdr["邮箱"]);
                employeeInfo.EmployeeBirth = Convert.ToDateTime(sdr["出生日期"]);
                employeeInfo.EmployeeAddress = Convert.ToString(sdr["地址"]);
                employeeInfo.EmployeeSettime = Convert.ToDateTime(sdr["进公司时间"]);
                employeeInfo.EmployeePosition = Convert.ToString(sdr["职位"]);
                employeeInfo.EmployeeDepartment = Convert.ToString(sdr["部门"]);

                list.Add(employeeInfo);
            }
            return list;
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="count">每页的条数</param>
        /// <returns>int值，总页数</returns>
        public static int EmployeeInfoYs(int count)
        {
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@count",count)        
            };
            int i = Convert.ToInt32(SQLHelper.ExecuteScalar("EmployeeInfoYs", CommandType.StoredProcedure, p));
            return i;
        }
    }

}
