﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore.Models.SysRole;
using NetCore.Services.Interface;
using NetCore.ViewModels;
using NetCore.ViewModels.SysRole;

namespace NetCore.Api.Controllers
{
    /// <summary>
    /// 系统角色
    /// </summary>
    [Route("api/SysRole")]
    [ApiController]
    public class SysRoleController : Controller
    {
        private readonly ISysRoleService _sysRoleService;

        public SysRoleController(ISysRoleService sysRole)
        {
            _sysRoleService = sysRole;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<AjaxResult<bool>> Add(AddRequest request)
        {
            var result = await _sysRoleService.Add(request);
            return new AjaxResult<bool>().SetSuccess(result);
        }

        [HttpPost]
        [Route("List")]
        public async Task<AjaxResult<PagedResult<GetListResult>>> List(GetListRequest request)
        {
            var result = await _sysRoleService.List(request);
            return new AjaxResult<PagedResult<GetListResult>>().SetSuccess(result);
        }

        [HttpPost]
        [Route("Update")]
        public async Task<AjaxResult<bool>> Update(UpdateRequest request)
        {
            var result = await _sysRoleService.Update(request);
            return new AjaxResult<bool>().SetSuccess(result);
        }

        [HttpGet]
        [Route("Delete")]
        public async Task<AjaxResult<bool>> Delete(int id)
        {
            var result = await _sysRoleService.Delete(id);
            return new AjaxResult<bool>().SetSuccess(result);
        }
    }
}