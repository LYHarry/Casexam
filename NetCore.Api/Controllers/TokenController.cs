using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NetCore.Infrastructures.JwtToken;
using NetCore.ViewModels;
using System.Threading.Tasks;

namespace NetCore.Api.Controllers
{
    [Route("api/Token")]
    [ApiController]
    public class TokenController : Controller
    {
        private readonly TokenProviderOptions _jwtTokenOption;

        public TokenController(IOptions<TokenProviderOptions> jwttoken)
        {
            _jwtTokenOption = jwttoken.Value;
        }


        /// <summary>
        /// 成生 jwt token
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("Produce")]
        public async Task<AjaxResult<string>> Produce(JwtClaimTypeParam request)
        {
            var result = await TokenAuthHelper.CreateToken(request, _jwtTokenOption);
            return new AjaxResult<string>().SetSuccess(result);
        }
    }
}