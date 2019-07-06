using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 加密信息表Model层
    /// </summary>
    public class Password
    {
        public Password()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 编号
        /// </summary>
        public int passwId { get; set; }

        /// <summary>
        /// 用户帐号
        /// </summary>
        public string passwAccount { get; set; }

        /// <summary>
        /// 加密密钥
        /// </summary>
        public string passwpass { get; set; }
    }
}
