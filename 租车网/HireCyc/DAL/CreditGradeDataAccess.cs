using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// 信用等级表DAL
    /// </summary>
    public class CreditGradeDataAccess
    {
        /// <summary>
        /// 添加权限等级表数据
        /// </summary>
        /// <param name="creditGrade">要添加的新权限对象</param>
        /// <returns></returns>
        public static bool CreditGradeAdd(Model.CreditGrade creditGrade)
        {
            SqlParameter[] p = new SqlParameter[]
            {
            new SqlParameter("@CreditGrade",creditGrade.CreditGradeGrade),
            new SqlParameter("@BorrowCount",creditGrade.CreditGradeBorrowCount),
            new SqlParameter("@Discount",creditGrade.CreditGradeDiscount)
            };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("CreditGradeAdd", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 根据信用等级名称删除信用等级表数据
        /// </summary>
        /// <param name="CreditGradeGrade">要删除的权限名称</param>
        /// <returns></returns>
        public static bool CreditGradeDel(string CreditGradeGrade)
        {
            SqlParameter[] p = new SqlParameter[]
             {
                 new SqlParameter("@Grade",CreditGradeGrade)
              };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("CreditGradeDel", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 根据信用等级修改信息
        /// </summary>
        /// <param name="cg"></param>
        /// <returns></returns>
        public static bool CreditGradeUpdate(Model.CreditGrade cg)
        {
            SqlParameter[] p = new SqlParameter[]
             {
               new SqlParameter("@CreditGrade",cg.CreditGradeGrade),
               new SqlParameter("@BorrowCount",cg.CreditGradeBorrowCount),
               new SqlParameter("@Discount",cg.CreditGradeDiscount)
             };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("CreditGradeUpdate", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 获取所有信息
        /// </summary>
        /// <returns></returns>
        public static List<Model.CreditGrade> CreditGradeLookAll()
        {
            List<Model.CreditGrade> list = new List<Model.CreditGrade>(); //创建List集合
            SqlDataReader sdr = SQLHelper.ExecuteDataReader("CreditGradeLookAll", CommandType.StoredProcedure);
            while (sdr.Read())
            {
                Model.CreditGrade creditGrade = new Model.CreditGrade();
                creditGrade.CreditGradeGrade = Convert.ToString(sdr["信用等级"]);
                creditGrade.CreditGradeBorrowCount = Convert.ToInt32(sdr["可租用车数"]);
                creditGrade.CreditGradeDiscount = Convert.ToChar(sdr["优惠打折率"]);

                list.Add(creditGrade);
            }
            return list;
        }

        /// <summary>
        /// 查找所有信用等级数据
        /// </summary>
        /// <returns></returns>
        public static List<string> CreditGradeLookAllGrade()
        {
            List<string> list = new List<string>(); //创建List集合
            SqlDataReader sdr = SQLHelper.ExecuteDataReader("CreditGradeLookAllGrade", CommandType.StoredProcedure);
            while (sdr.Read())
            {
                string creditGrade = Convert.ToString(sdr["信用等级"]);
                list.Add(creditGrade);
            }
            return list;
        }

        /// <summary>
        /// 根据信用等级表获取查询数据
        /// </summary>
        /// <param name="grade"></param>
        /// <returns></returns>
        public static Model.CreditGrade CreditGradeLookById(string grade)
        {
            Model.CreditGrade creditGrade = new Model.CreditGrade();  //创建一个User对象

            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@Grade",grade)
            };            
            SqlDataReader sdr = SQLHelper.ExecuteDataReader("CreditGradeLookByGradeName", CommandType.StoredProcedure, par);

            while (sdr.Read())
            {
                creditGrade.CreditGradeGrade = Convert.ToString(sdr["信用等级"]);
                creditGrade.CreditGradeBorrowCount = Convert.ToInt32(sdr["可租用车数"]);
                creditGrade.CreditGradeDiscount = Convert.ToChar(sdr["优惠打折率"]);
            }

            return creditGrade;
        }

        /// <summary>
        /// 根据用户信用等级查询编号
        /// </summary>
        /// <param name="CreditGradeGrade">信用等级名称</param>
        /// <returns></returns>
        public static int CreditGradeLookIdByGrade(string CreditGradeGrade)
        {
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@grade",CreditGradeGrade)
            };
            int CreditGradeId = Convert.ToInt32(SQLHelper.ExecuteScalar("CreditGradeLookIdByGrade", CommandType.StoredProcedure, par));

            return CreditGradeId;
        }

        /// <summary>
        /// 根据可租车数来查找编号
        /// </summary>
        /// <param name="CreditGradeCreditGrade"></param>
        /// <returns></returns>
        public static int CreditGradeLookIdByCount(int CreditGradeBorrowCount)
        {
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@BorrowCount",CreditGradeBorrowCount)
            };
            int CreditGradeId = Convert.ToInt32(SQLHelper.ExecuteScalar("CreditGradeLookIdByCount", CommandType.StoredProcedure, par));

            return CreditGradeId;
        }

        /// <summary>
        /// 根据信用等级来查找可租车数
        /// </summary>
        /// <param name="CreditGradeBorrowCount"></param>
        /// <returns></returns>
        public static int CreditGradeLookcountByGrade(string CreditGradeGrade)
        {
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@grade",CreditGradeGrade)
            };
            int CreditGradeBorrowCount = Convert.ToInt32(SQLHelper.ExecuteScalar("CreditGradeLookcountByGrade", CommandType.StoredProcedure, par));

            return CreditGradeBorrowCount;
        }

        /// <summary>
        /// 根据可租车数来查找信用等级
        /// </summary>
        /// <param name="CreditGradeCreditGrade"></param>
        /// <returns></returns>
        public static string CreditGradeLookgradeByCount(int CreditGradeBorrowCount)
        {
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@BorrowCount",CreditGradeBorrowCount)
            };
            string CreditGradeGrade = Convert.ToString(SQLHelper.ExecuteScalar("CreditGradeLookgradeByCount", CommandType.StoredProcedure, par));

            return CreditGradeGrade;
        }

        /// <summary>
        /// 根据打折比率查询信用等级
        /// </summary>
        /// <param name="CreditGradeDiscount"></param>
        /// <returns></returns>
        public static string CreditGradeLookGradeByDiscount(float CreditGradeDiscount)
        {
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@Discount",CreditGradeDiscount)
            };
            string CreditGradeGrade = Convert.ToString(SQLHelper.ExecuteScalar("CreditGradeLookGradeByDiscount", CommandType.StoredProcedure, par));

            return CreditGradeGrade;
        }

        /// <summary>
        /// 根据信用等级查询打折比率
        /// </summary>
        /// <param name="CreditGradeGrade"></param>
        /// <returns></returns>
        public static float CreditGradeLookDisByGrade(string CreditGradeGrade)
        {
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@Grade",CreditGradeGrade)
            };
            float CreditGradeDiscount = Convert.ToSingle(SQLHelper.ExecuteScalar("CreditGradeLookDiscountByGradeName", CommandType.StoredProcedure, par));

            return CreditGradeDiscount;
        }
    }
}
