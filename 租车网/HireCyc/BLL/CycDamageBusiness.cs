using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CycDamageBusiness
    {
        /// <summary>
        ///添加车辆损坏表信息
        /// </summary>
        /// <param name="cycDamage"></param>
        /// <returns></returns>
        public static bool CycDamageAdd(Model.CycDamage cycDamage)
        {
            return DAL.CycDamageDataAccess.CycDamageAdd(cycDamage);
        }

        /// <summary>
        /// 根据毁坏编号删除毁坏信息
        /// </summary>
        /// <param name="CycDamageId"></param>
        /// <returns></returns>
        public static bool CycDamageDelByID(int CycDamageId)
        {
            return DAL.CycDamageDataAccess.CycDamageDelByID(CycDamageId);
        }

        /// <summary>
        /// 根据毁坏情况删除毁坏信息
        /// </summary>
        /// <param name="CycDamageSituation"></param>
        /// <returns></returns>
        public static bool CycDamageDelBySituation(string CycDamageSituation)
        {
            return DAL.CycDamageDataAccess.CycDamageDelBySituation(CycDamageSituation);
        }


        /// <summary>
        /// 根据车辆毁坏表编号修改车辆毁坏表信息
        /// </summary>
        /// <param name="cycDamage"></param>
        /// <returns></returns>
        public static bool CycDamageUpdate(Model.CycDamage cycDamage)
        {
            return DAL.CycDamageDataAccess.CycDamageUpdate(cycDamage);
        }

        /// <summary>
        /// 根据车辆类型名称和自行车毁坏情况查询
        /// </summary>
        /// <param name="CycDamageCycType"></param>
        /// <param name="CycDamageSituation"></param>
        /// <returns></returns>
        public static Model.CycDamage CycDamageUpdateMoenyByTypeAndSituation(string CycDamageCycType, string CycDamageSituation)
        {
            return DAL.CycDamageDataAccess.CycDamageUpdateMoenyByTypeAndSituation(CycDamageCycType, CycDamageSituation);
        }

        /// <summary>
        /// 根据自行车毁坏情况查询
        /// </summary>
        /// <returns></returns>
        public static List<Model.CycDamage> CycDamageLookBySituation(string situation)
        {
            return DAL.CycDamageDataAccess.CycDamageLookBySituation(situation);
        }



        /// <summary>
        /// 根据自行车类型查询
        /// </summary>
        /// <returns></returns>
        public static List<Model.CycDamage> CycDamageLookByType(string type)
        {
            return DAL.CycDamageDataAccess.CycDamageLookByType(type);
        }


        /// <summary>
        /// 根据车辆类型和车辆毁坏情况更改罚金
        /// </summary>
        /// <param name="cycDamage"></param>
        /// <returns></returns>
        public static bool CycDamageUpdateMoenyByTypeAndSituation(Model.CycDamage cycDamage)
        {
            return DAL.CycDamageDataAccess.CycDamageUpdateMoenyByTypeAndSituation(cycDamage);
        }

        /// <summary>
        /// 判断指定的ID是否存在
        /// </summary>
        /// <param name="id">要判断的ID</param>
        /// <returns></returns>
        public static bool CycDamageLookId(int id)
        {
            return DAL.CycDamageDataAccess.CycDamageLookId(id);
        }

        /// <summary>
        /// 分页显示
        /// </summary>
        /// <param name="ys">页数</param>
        /// <param name="count">每页的条数</param>
        /// <returns>list值</returns>
        public static List<Model.CycDamage> CycDamageFeny(int ys, int count)
        {
            return DAL.CycDamageDataAccess.CycDamageFeny(ys, count);
        }

        /// <summary>
        /// 分页，根据每页的条数，计算总页数
        /// </summary>
        /// <param name="count">每页的条数</param>
        /// <returns>int值</returns>
        public static int CycDamageYs(int count)
        {
            return DAL.CycDamageDataAccess.CycDamageYs(count);
        }

        /// <summary>
        /// 查询所有的车辆毁坏情况
        /// </summary>
        /// <returns></returns>
        public static List<Model.CycDamage> CycDamageLookALL()
        {
            return DAL.CycDamageDataAccess.CycDamageLookALL();
        }
    }
}
