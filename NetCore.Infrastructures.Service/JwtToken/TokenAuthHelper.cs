using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Infrastructures.JwtToken
{
    /// <summary>
    /// 验证 token 帮助类
    /// </summary>
    public class TokenAuthHelper
    {
        /// <summary>
        /// 创建 Token
        /// </summary>
        /// <param name="jwtClaim">jwtClaim 参数</param>
        /// <returns></returns>
        public static Task<string> CreateToken(JwtClaimTypeParam jwtClaim, TokenProviderOptions jwtToken)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtClaimType.UserId, jwtClaim.UserId.ToString()),
                new Claim(JwtClaimType.UserName, jwtClaim.UserName),
                new Claim(JwtClaimType.Account, jwtClaim.Account),
                new Claim(JwtClaimType.Phone, jwtClaim.Phone),
                new Claim(JwtClaimType.RoleId, jwtClaim.RoleId.ToString()),
                new Claim(JwtClaimType.RoleName, jwtClaim.RoleName),
                new Claim(JwtClaimType.SecuritySeal, Guid.NewGuid().ToString("N"))
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtToken.SecurityKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
               issuer: jwtToken.Issuer,
               audience: jwtToken.Audience,
               claims: claims,
               notBefore: DateTime.Now,
               expires: DateTime.Now.Add(jwtToken.Expiration),
               signingCredentials: creds);
            var result = new JwtSecurityTokenHandler().WriteToken(token);
            return Task.FromResult(result);
        }


        /// <summary>
        /// 添加 token 验证服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddTokenService(IServiceCollection services, IConfiguration configuration)
        {
            //得到jwt 验证配置项
            var jwtOption = configuration.GetSection("JwtAuthentication").Get<TokenProviderOptions>();
            jwtOption.Expiration = TimeSpan.FromMinutes(30);
            services.AddSingleton(Options.Create(jwtOption));
            //添加jwt验证
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = "JwtBearer";
                opt.DefaultChallengeScheme = "JwtBearer"; //这两个名字要一致
            }).AddJwtBearer("JwtBearer", opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    //是否验证Issuer
                    ValidateIssuer = true,
                    //是否验证Audience
                    ValidateAudience = true,
                    //是否验证失效时间,使用当前时间与Token的Claims中的NotBefore和Expires对比
                    ValidateLifetime = true,
                    //是否验证SecurityKey
                    ValidateIssuerSigningKey = true,
                    //是否要求Token的Claims中必须包含Expires
                    RequireExpirationTime = true,
                    //验证时间时的时钟偏移
                    ClockSkew = TimeSpan.Zero,
                    ValidAudience = jwtOption.Audience,
                    ValidIssuer = jwtOption.Issuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOption.SecurityKey)),

                };
            });
        }

    }
}
