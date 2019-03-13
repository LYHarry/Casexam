﻿using Microsoft.AspNetCore.Mvc;
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
        [HttpPost]
        [Route("Add")]
        public async Task<AjaxResult<bool>> Add(AddRequest request)
        {
            var result = await Task.FromResult(false);
            return new AjaxResult<bool>().SetSuccess(result);
        }

        [HttpPost]
        [Route("List")]
        public async Task<AjaxResult<PagedResult<GetListResult>>> List(GetListRequest request)
        {
            var result = await Task.FromResult(new PagedResult<GetListResult>());
            return new AjaxResult<PagedResult<GetListResult>>().SetSuccess(result);
        }

        [HttpPost]
        [Route("Update")]
        public async Task<AjaxResult<bool>> Update(UpdateRequest request)
        {
            var result = await Task.FromResult(false);
            return new AjaxResult<bool>().SetSuccess(result);
        }

        [HttpPost]
        [Route("ModifyPassword")]
        public async Task<AjaxResult<bool>> ModifyPassword(ModifyPasswordRequest request)
        {
            var result = await Task.FromResult(false);
            return new AjaxResult<bool>().SetSuccess(result);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<AjaxResult<bool>> Login(LoginRequest request)
        {
            var result = await Task.FromResult(false);
            return new AjaxResult<bool>().SetSuccess(result);
        }

        [HttpGet]
        [Route("Delete")]
        public async Task<AjaxResult<bool>> Delete(int id)
        {
            var result = await Task.FromResult(false);
            return new AjaxResult<bool>().SetSuccess(result);
        }
    }
}