using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// 车辆损坏表DAL
    /// </summary>
    public class CycDamageDataAccess
    {
        /// <summary>
        ///添加车辆损坏表信息
        /// </summary>
        /// <param name="cycDamage"></param>
        /// <returns></returns>
        public static bool CycDamageAdd(Model.CycDamage cycDamage)
        {
            SqlParameter[] p = new SqlParameter[]
            {
            new SqlParameter("@type",cycDamage.CycDamageCycType),
            new SqlParameter("@Situation",cycDamage.CycDamageSituation),
            new SqlParameter("@Money",cycDamage.CycDamageMoney)
            };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("CycDamageAdd", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 根据毁坏编号删除毁坏信息
        /// </summary>
        /// <param name="CycDamageId"></param>
        /// <returns></returns>
        public static bool CycDamageDelByID(int CycDamageId)
        {
            SqlParameter[] p = new SqlParameter[]
            {
               new SqlParameter("@id",CycDamageId)        
             };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("CycDamageDelByID", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 根据毁坏情况删除毁坏信息
        /// </summary>
        /// <param name="CycDamageSituation"></param>
        /// <returns></returns>
        public static bool CycDamageDelBySituation(string CycDamageSituation)
        {
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@Situation",CycDamageSituation)        
             };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("CycDamageDelBySituation", CommandType.StoredProcedure, p));
            return i > 0;
        }


        /// <summary>
        /// 根据车辆毁坏表编号修改车辆毁坏表信息
        /// </summary>
        /// <param name="cycDamage"></param>
        /// <returns></returns>
        public static bool CycDamageUpdate(Model.CycDamage cycDamage)
        {
            SqlParameter[] p = new SqlParameter[]
             {
                new SqlParameter("@id", cycDamage.CycDamageId),
                new SqlParameter("@type",cycDamage.CycDamageCycType),
                new SqlParameter("@Situation",cycDamage.CycDamageSituation),
                new SqlParameter("@Money",cycDamage.CycDamageMoney)           
             };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("CycDamageUpdate", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 根据车辆类型名称和自行车毁坏情况查询
        /// </summary>
        /// <param name="CycDamageCycType"></param>
        /// <param name="CycDamageSituation"></param>
        /// <returns></returns>
        public static Model.CycDamage CycDamageUpdateMoenyByTypeAndSituation(string CycDamageCycType, string CycDamageSituation)
        {
            SqlParameter[] p = new SqlParameter[]
             {
                new SqlParameter("@type",CycDamageCycType),
                new SqlParameter("@Situation",CycDamageSituation)
             };
            SqlDataReader dr = SQLHelper.ExecuteDataReader("CycDamageLookByTypeAndSituation", CommandType.StoredProcedure, p);
            Model.CycDamage cycDamage = new Model.CycDamage();

            cycDamage.CycDamageCycType = dr["车辆类型名称"].ToString();
            cycDamage.CycDamageSituation = dr["自行车毁坏情况"].ToString();
            cycDamage.CycDamageMoney = Convert.ToSingle(dr["赔款"]);

            return cycDamage;
        }

        /// <summary>
        /// 根据自行车毁坏情况查询
        /// </summary>
        /// <returns></returns>
        public static List<Model.CycDamage> CycDamageLookBySituation(string situation)
        {
            List<Model.CycDamage> list = new List<Model.CycDamage>(); //创建List集合

            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@Situation",situation)
            };

            SqlDataReader sdr = SQLHelper.ExecuteDataReader("CycDamageLookBySituation", CommandType.StoredProcedure, p);
            while (sdr.Read())
            {
                Model.CycDamage cycDamage = new Model.CycDamage();
                cycDamage.CycDamageId = Convert.ToInt32(sdr["表编号"]);
                cycDamage.CycDamageCycType = sdr["车辆类型名称"].ToString();
                cycDamage.CycDamageSituation = sdr["自行车毁坏情况"].ToString();
                cycDamage.CycDamageMoney = Convert.ToSingle(sdr["赔款"]);

                list.Add(cycDamage);
            }
            return list;
        }



        /// <summary>
        /// 根据自行车类型查询
        /// </summary>
        /// <returns></returns>
        public static List<Model.CycDamage> CycDamageLookByType(string type)
        {
            List<Model.CycDamage> list = new List<Model.CycDamage>(); //创建List集合

            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@type",type)
            };

            SqlDataReader sdr = SQLHelper.ExecuteDataReader("CycDamageLookByType", CommandType.StoredProcedure, p);
            while (sdr.Read())
            {
                Model.CycDamage cycDamage = new Model.CycDamage();

                cycDamage.CycDamageId = Convert.ToInt32(sdr["表编号"]);
                cycDamage.CycDamageCycType = sdr["车辆类型名称"].ToString();
                cycDamage.CycDamageSituation = sdr["自行车毁坏情况"].ToString();
                cycDamage.CycDamageMoney = Convert.ToSingle(sdr["赔款"]);

                list.Add(cycDamage);
            }
            return list;
        }


        /// <summary>
        /// 根据车辆类型和车辆毁坏情况更改罚金
        /// </summary>
        /// <param name="cycDamage"></param>
        /// <returns></returns>
        public static bool CycDamageUpdateMoenyByTypeAndSituation(Model.CycDamage cycDamage)
        {
            SqlParameter[] p = new SqlParameter[]
             {          
                new SqlParameter("@type",cycDamage.CycDamageCycType),
                new SqlParameter("@Situation",cycDamage.CycDamageSituation),
                new SqlParameter("@money",cycDamage.CycDamageMoney)           
             };
            int i = Convert.ToInt32(SQLHelper.ExecuteNonQuery("CycDamageUpdateMoenyByTypeAndSituation", CommandType.StoredProcedure, p));
            return i > 0;
        }

        /// <summary>
        /// 判断指定的ID是否存在
        /// </summary>
        /// <param name="id">要判断的ID</param>
        /// <returns></returns>
        public static bool CycDamageLookId(int id)
        {
            SqlParameter[] p = new SqlParameter[]
            {
               new SqlParameter("@id",id)
             };
            int f = Convert.ToInt32(SQLHelper.ExecuteScalar("CycDamageLookID", CommandType.StoredProcedure, p));

            return f == 1;
        }


        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="ys">页数</param>
        /// <param name="count">每页的条数</param>
        /// <returns>list值</returns>
        public static List<Model.CycDamage> CycDamageFeny(int ys, int count)
        {
            List<Model.CycDamage> list = new List<Model.CycDamage>(); //创建List集合

            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@ys",ys),
                new SqlParameter("@count",count)
            };

            SqlDataReader sdr = SQLHelper.ExecuteDataReader("CycDamageFeny", CommandType.StoredProcedure, p);
            while (sdr.Read())
            {
                Model.CycDamage cycDamage = new Model.CycDamage();
                cycDamage.CycDamageId = Convert.ToInt32(sdr["编号"]);
                cycDamage.CycDamageCycType = sdr["车辆类型名称"].ToString();
                cycDamage.CycDamageSituation = sdr["自行车毁坏情况"].ToString();
                cycDamage.CycDamageMoney = Convert.ToSingle(sdr["赔款"]);
                list.Add(cycDamage);
            }
            return list;
        }

        /// <summary>
        /// 分页，根据每页的条数，计算总页数
        /// </summary>
        /// <param name="count">每页的条数</param>
        /// <returns>int值</returns>
        public static int CycDamageYs(int count)
        {
            SqlParameter[] p = new SqlParameter[]
            {
              new SqlParameter("@count",count)
            };
            int i = Convert.ToInt32(SQLHelper.ExecuteScalar("CycDamageYs", CommandType.StoredProcedure, p));
            return i;
        }


        /// <summary>
        /// 查询所有的车辆毁坏情况
        /// </summary>
        /// <returns></returns>
        public static List<Model.CycDamage> CycDamageLookALL()
        {
            List<Model.CycDamage> list = new List<Model.CycDamage>(); //创建List集合

            SqlDataReader sdr = SQLHelper.ExecuteDataReader("CycDamageLookALL", CommandType.StoredProcedure);
            while (sdr.Read())
            {
                Model.CycDamage cycDamage = new Model.CycDamage();

                cycDamage.CycDamageId = Convert.ToInt32(sdr["表编号"]);
                cycDamage.CycDamageCycType = sdr["车辆类型"].ToString();
                cycDamage.CycDamageSituation = sdr["毁坏情况"].ToString();
                cycDamage.CycDamageMoney = Convert.ToSingle(sdr["赔偿标准"]);

                list.Add(cycDamage);
            }
            return list;
        }

    }
}
