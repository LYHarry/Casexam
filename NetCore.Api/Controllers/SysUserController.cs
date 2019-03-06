using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore.Models.SysUser;
using NetCore.Services.Interface;
using NetCore.ViewModels;
using NetCore.ViewModels.SysUser;

namespace NetCore.Api.Controllers
{
    /// <summary>
    /// 系统管理员用户
    /// </summary>
    [Route("api/SysUser")]
    [ApiController]
    public class SysUserController : Controller
    {
        private readonly ISysUserService _sysUserService;

        public SysUserController(ISysUserService sysUser)
        {
            _sysUserService = sysUser;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<AjaxResult<bool>> Add(AddRequest request)
        {
            var result = await _sysUserService.Add(request);
            return new AjaxResult<bool>().SetSuccess(result);
        }

        [HttpPost]
        [Route("List")]
        public async Task<AjaxResult<PagedResult<GetListResult>>> List(GetListRequest request)
        {
            var result = await _sysUserService.List(request);
            return new AjaxResult<PagedResult<GetListResult>>().SetSuccess(result);
        }

        [HttpPost]
        [Route("Update")]
        public async Task<AjaxResult<bool>> Update(UpdateRequest request)
        {
            var result = await _sysUserService.Update(request);
            return new AjaxResult<bool>().SetSuccess(result);
        }

        [HttpPost]
        [Route("ModifyPassword")]
        public async Task<AjaxResult<bool>> ModifyPassword(ModifyPasswordRequest request)
        {
            var result = await _sysUserService.ModifyPassword(request);
            return new AjaxResult<bool>().SetSuccess(result);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<AjaxResult<bool>> Login(LoginRequest request)
        {
            var result = await _sysUserService.Login(request);
            return new AjaxResult<bool>().SetSuccess(result);
        }

        [HttpGet]
        [Route("Delete")]
        public async Task<AjaxResult<bool>> Delete(int id)
        {
            var result = await _sysUserService.Delete(id);
            return new AjaxResult<bool>().SetSuccess(result);
        }
    }
}