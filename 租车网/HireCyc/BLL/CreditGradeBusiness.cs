using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// 信用等级表DAL
    /// </summary>
    public class CreditGradeBusiness
    {
        /// <summary>
        /// 添加权限等级表数据
        /// </summary>
        /// <param name="creditGrade">要添加的新权限对象</param>
        /// <returns></returns>
        public static bool CreditGradeAdd(Model.CreditGrade creditGrade)
        {
            return DAL.CreditGradeDataAccess.CreditGradeAdd(creditGrade);
        }

        /// <summary>
        /// 根据信用等级名称删除信用等级表数据
        /// </summary>
        /// <param name="CreditGradeGrade">要删除的权限名称</param>
        /// <returns></returns>
        public static bool CreditGradeDel(string CreditGradeGrade)
        {
            return DAL.CreditGradeDataAccess.CreditGradeDel(CreditGradeGrade);
        }

        /// <summary>
        /// 根据信用等级修改信息
        /// </summary>
        /// <param name="cg"></param>
        /// <returns></returns>
        public static bool CreditGradeUpdate(Model.CreditGrade cg)
        {
            return DAL.CreditGradeDataAccess.CreditGradeUpdate(cg);
        }

        /// <summary>
        /// 获取所有信息
        /// </summary>
        /// <returns></returns>
        public static List<Model.CreditGrade> CreditGradeLookAll()
        {
            return DAL.CreditGradeDataAccess.CreditGradeLookAll();
        }

        /// <summary>
        /// 查找所有信用等级数据
        /// </summary>
        /// <returns></returns>
        public static List<string> CreditGradeLookAllGrade()
        {
            return DAL.CreditGradeDataAccess.CreditGradeLookAllGrade();
        }

        /// <summary>
        /// 根据信用等级表获取查询数据
        /// </summary>
        /// <param name="grade"></param>
        /// <returns></returns>
        public static Model.CreditGrade CreditGradeLookById(string grade)
        {
            return DAL.CreditGradeDataAccess.CreditGradeLookById(grade);
        }

        /// <summary>
        /// 根据用户信用等级查询编号
        /// </summary>
        /// <param name="CreditGradeGrade">信用等级名称</param>
        /// <returns></returns>
        public static int CreditGradeLookIdByGrade(string CreditGradeGrade)
        {
            return DAL.CreditGradeDataAccess.CreditGradeLookIdByGrade(CreditGradeGrade);
        }

        /// <summary>
        /// 根据可租车数来查找编号
        /// </summary>
        /// <param name="CreditGradeCreditGrade"></param>
        /// <returns></returns>
        public static int CreditGradeLookIdByCount(int CreditGradeBorrowCount)
        {
            return DAL.CreditGradeDataAccess.CreditGradeLookIdByCount(CreditGradeBorrowCount);
        }

        /// <summary>
        /// 根据信用等级来查找可租车数
        /// </summary>
        /// <param name="CreditGradeBorrowCount"></param>
        /// <returns></returns>
        public static int CreditGradeLookcountByGrade(string CreditGradeGrade)
        {
            return DAL.CreditGradeDataAccess.CreditGradeLookcountByGrade(CreditGradeGrade);
        }

        /// <summary>
        /// 根据可租车数来查找信用等级
        /// </summary>
        /// <param name="CreditGradeCreditGrade"></param>
        /// <returns></returns>
        public static string CreditGradeLookgradeByCount(int CreditGradeBorrowCount)
        {
            return DAL.CreditGradeDataAccess.CreditGradeLookgradeByCount(CreditGradeBorrowCount);
        }

        /// <summary>
        /// 根据打折比率查询信用等级
        /// </summary>
        /// <param name="CreditGradeDiscount"></param>
        /// <returns></returns>
        public static string CreditGradeLookGradeByDiscount(float CreditGradeDiscount)
        {
            return DAL.CreditGradeDataAccess.CreditGradeLookGradeByDiscount(CreditGradeDiscount);
        }

        /// <summary>
        /// 根据信用等级查询打折比率
        /// </summary>
        /// <param name="CreditGradeGrade"></param>
        /// <returns></returns>
        public static float CreditGradeLookDisByGrade(string CreditGradeGrade)
        {
            return DAL.CreditGradeDataAccess.CreditGradeLookDisByGrade(CreditGradeGrade);
        }
    }
}
