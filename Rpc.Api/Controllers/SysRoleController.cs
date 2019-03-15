using Microsoft.AspNetCore.Mvc;
using Rpc.Infrastructures.Server.RequestClient;
using Rpc.Model.SysRole;
using Rpc.ViewModel;
using Rpc.ViewModel.SysRole;
using System.Threading.Tasks;

namespace Rpc.Api.Controllers
{
    /// <summary>
    /// 系统角色
    /// </summary>
    [Route("api/SysRole")]
    [ApiController]
    public class SysRoleController : Controller
    {
        private readonly IServiceRequestClient _requestClient;

        public SysRoleController(IServiceRequestClient client)
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

        [HttpGet]
        [Route("Delete")]
        public async Task<AjaxResult<bool>> Delete(int id)
        {
            var result = await _requestClient.RequestAsync<int, bool>(id);
            return new AjaxResult<bool>().SetSuccess(result);
        }

        [HttpGet]
        [Route("NoArgument")]
        public async Task<AjaxResult<bool>> NoArguments()
        {
            var result = await _requestClient.RequestAsync<object, bool>(null);
            return new AjaxResult<bool>().SetSuccess(result);
        }
    }
}