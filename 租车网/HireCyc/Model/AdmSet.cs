using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 权限表
    /// </summary>
    public class AdmSet
    {
        public AdmSet()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 权限表编号
        /// </summary>
        public int AdmSetId { get; set; }

        /// <summary>
        /// 权限的名称
        /// </summary>
        public string AdmSetName { get; set; }

        /// <summary>
        /// 系统设置权限
        /// </summary>
        public char AdmSetSystemManage { get; set; }

        /// <summary>
        /// 用户管理权限
        /// </summary>
        public char AdmSetBorrowerManage { get; set; }

        /// <summary>
        /// 车辆管理权限
        /// </summary>
        public char AdmSetCycManage { get; set; }

        /// <summary>
        /// 员工管理权限
        /// </summary>
        public char AdmSetEmpManage { get; set; }

        /// <summary>
        /// 订单管理权限
        /// </summary>
        public char AdmSetBowManage { get; set; }

        /// <summary>
        /// 用户查询权限
        /// </summary>
        public char AdmSetBorrowerLook { get; set; }

        /// <summary>
        /// 车辆查询权限
        /// </summary>
        public char AdmSetCycLook { get; set; }

        /// <summary>
        /// 员工查询权限
        /// </summary>
        public char AdmSetEmpLook { get; set; }

        /// <summary>
        /// 订单查询权限
        /// </summary>
        public char AdmSetBowLook { get; set; }
    }
}
