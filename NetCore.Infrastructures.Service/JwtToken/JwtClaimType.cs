using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Infrastructures.JwtToken
{
    /// <summary>
    /// JwtClaimType
    /// </summary>
    public class JwtClaimType
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public const string UserId = "http://schemas.microsoft.com/ws/2008/06/identity/claims/userid";

        /// <summary>
        /// 用户名称
        /// </summary>
        public const string UserName = "http://schemas.microsoft.com/ws/2008/06/identity/claims/username";

        /// <summary>
        /// 账户
        /// </summary>
        public const string Account = "http://schemas.microsoft.com/ws/2008/06/identity/claims/account";
        
        /// <summary>
        /// 角色ID
        /// </summary>
        public const string RoleId = "http://schemas.microsoft.com/ws/2008/06/identity/claims/roleid";

        /// <summary>
        /// 角色名称
        /// </summary>
        public const string RoleName = "http://schemas.microsoft.com/ws/2008/06/identity/claims/rolename";

        /// <summary>
        /// 防伪印章
        /// </summary>
        public const string SecuritySeal = "http://schemas.microsoft.com/ws/2008/06/identity/claims/securityseal";
    }
}
