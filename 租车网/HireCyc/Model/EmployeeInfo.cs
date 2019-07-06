using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 员工（管理员）表
    /// </summary>
    public class EmployeeInfo
    {
        public EmployeeInfo()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 员工（管理员）表编号
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// 员工帐号(随机产生)
        /// </summary>
        public string EmployeeAccount { get; set; }

        /// <summary>
        /// 员工的密码
        /// </summary>
        public string EmployeePassword { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string EmployeeName { get; set; }

        /// <summary>
        /// 用户性别
        /// </summary>
        public string EmployeerSex { get; set; }

        /// <summary>
        /// 权限编号
        /// </summary>
        public int EmployeePower { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string EmployeeCertificate { get; set; }

        /// <summary>
        /// 员工联系电话
        /// </summary>
        public string EmployeeTel { get; set; }

        /// <summary>
        /// 员工电子邮箱地址
        /// </summary>
        public string EmployeeEmail { get; set; }

        /// <summary>
        /// 员工的出生年龄
        /// </summary>
        public DateTime EmployeeBirth { get; set; }

        /// <summary>
        /// 员工的家庭地址
        /// </summary>
        public string EmployeeAddress { get; set; }

        /// <summary>
        /// 员工进公司的时间
        /// </summary>
        public DateTime EmployeeSettime { get; set; }

        /// <summary>
        /// 职位
        /// </summary>
        public string EmployeePosition { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public string EmployeeDepartment { get; set; }

    }
}
