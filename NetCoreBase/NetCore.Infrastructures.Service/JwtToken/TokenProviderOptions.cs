using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Infrastructures.JwtToken
{
    /// <summary>
    /// jwt token 
    /// </summary>
    public class TokenProviderOptions
    {
        /// <summary>
        /// 安全验证 key
        /// </summary>
        public string SecurityKey { get; set; }

        /// <summary>
        /// 发行人
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// 接收者
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public TimeSpan Expiration { get; set; }
    }
}
