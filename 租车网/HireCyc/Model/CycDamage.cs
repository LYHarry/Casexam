using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{

    /// <summary>
    /// 车辆毁坏表
    /// </summary>
    public class CycDamage
    {

        public CycDamage()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 车辆毁坏表编号
        /// </summary>
        public int CycDamageId { get; set; }

        /// <summary>
        /// 车辆类型名称
        /// </summary>
        public string CycDamageCycType { get; set; }

        /// <summary>
        /// 车辆毁坏情况
        /// </summary>
        public string CycDamageSituation { get; set; }

        /// <summary>
        /// 罚金
        /// </summary>
        public float CycDamageMoney { get; set; }

    }
}
