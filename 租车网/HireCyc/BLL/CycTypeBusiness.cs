using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// 车辆类型表BLL
    /// </summary>
  public  class CycTypeBusiness
    {
        /// <summary> 
        /// 添加车辆类型
        /// </summary>
        /// <param name="cycType"></param>
        /// <returns>bool值</returns>
        public static bool CycTypeAdd(Model.CycType cycType)
        {
            return DAL.CycTypeDataAccess.CycTypeAdd(cycType);
        }

        /// <summary>
        /// 删除车辆类型
        /// </summary>
        /// <param name="name">车辆类型名称</param>
        /// <returns>bool值</returns>
        public static bool CycTypeDel(string name)
        {
            return DAL.CycTypeDataAccess.CycTypeDel(name);
        }

        /// <summary>
        /// 查询所有的数据,并根据车辆库存排序
        /// </summary>
        /// <returns>list值</returns>
        public static List<Model.CycType> CycTypeLookAll()
        {
            return DAL.CycTypeDataAccess.CycTypeLookAll();
        }

        /// <summary>
        /// 查询所有的车辆类型名称
        /// </summary>
        /// <returns>list值</returns>
        public static List<string> CycTypeLookAllName()
        {
            return DAL.CycTypeDataAccess.CycTypeLookAllName();
        }

        /// <summary>
        /// 根据车辆类型查询数据
        /// </summary>
        /// <param name="name">车辆类型名称</param>
        /// <returns>list值</returns>
        public static Model.CycType CycTypeLookByName(string name)
        {
            return DAL.CycTypeDataAccess.CycTypeLookByName(name);
        }

        /// <summary>
        /// 查询所有数据，根据押金排序
        /// </summary>
        /// <returns>list值</returns>
        public static List<Model.CycType> CycTypeLookBypx()
        {
            return DAL.CycTypeDataAccess.CycTypeLookBypx();
        }

        /// <summary>
        /// 修改车辆的押金，车辆租金(小时)，车辆租金（天），车辆迟还时的租金(小时)，车辆迟还时的租金（天）
        /// </summary>
        /// <param name="cycType"></param>
        /// <returns>bool值</returns>
        public static bool CycTypeUpdateMoney(Model.CycType cycType)
        {
            return DAL.CycTypeDataAccess.CycTypeUpdateMoney(cycType);
        }

        /// <summary>
        ///  修改库存，根据车辆类型名称
        /// </summary>
        /// <param name="name">车辆类型名称</param>
        /// <param name="stock">库存</param>
        /// <returns>bool值</returns>
        public static bool CycTypeUpdateStock(string name, int stock)
        {
            return DAL.CycTypeDataAccess.CycTypeUpdateStock(name, stock);
        }
    }
}
