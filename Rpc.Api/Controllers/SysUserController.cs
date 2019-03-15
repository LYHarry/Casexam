using Microsoft.AspNetCore.Mvc;
using Rpc.Infrastructures.Server.RequestClient;
using Rpc.Model.SysUser;
using Rpc.ViewModel;
using Rpc.ViewModel.SysUser;
using System.Threading.Tasks;

namespace Rpc.Api.Controllers
{
    /// <summary>
    /// 系统管理员用户
    /// </summary>
    [Route("api/SysUser")]
    [ApiController]
    public class SysUserController : Controller
    {
        private readonly IServiceRequestClient _requestClient;

        public SysUserController(IServiceRequestClient client)
        {
            _requestClient = client;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<AjaxResult<bool>> Add(AddRequest request)
        {
            var result = await _requestClient.RequestAsync<AddRequest, bool>(request);
            return new AjaxResult<bool>().SetSuccess(result);
        }

        [HttpPost]
        [Route("List")]
        public async Task<AjaxResult<PagedResult<GetListResult>>> List(GetListRequest request)
        {
            var result = await _requestClient.RequestAsync<GetListRequest, PagedResult<GetListResult>>(request);
            return new AjaxResult<PagedResult<GetListResult>>().SetSuccess(result);
        }

        [HttpPost]
        [Route("Update")]
        public async Task<AjaxResult<bool>> Update(UpdateRequest request)
        {
            var result = await _requestClient.RequestAsync<UpdateRequest, bool>(request);
            return new AjaxResult<bool>().SetSuccess(result);
        }

        [HttpPost]
        [Route("ModifyPassword")]
        public async Task<AjaxResult<bool>> ModifyPassword(ModifyPasswordRequest request)
        {
            var result = await _requestClient.RequestAsync<ModifyPasswordRequest, bool>(request);
            return new AjaxResult<bool>().SetSuccess(result);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<AjaxResult<bool>> Login(LoginRequest request)
        {
            var result = await _requestClient.RequestAsync<LoginRequest, bool>(request);
            return new AjaxResult<bool>().SetSuccess(result);
        }

        [HttpGet]
        [Route("Delete")]
        public async Task<AjaxResult<bool>> Delete(int id)
        {
            var result = await _requestClient.RequestAsync<int, bool>(id);
            return new AjaxResult<bool>().SetSuccess(result);
        }
    }
}