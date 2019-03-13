using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Rpc.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rpc.Api.Filter
{
    public class GlobalException : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception == null)
                return;
            context.Result = new JsonResult(new AjaxResult<string>().SetFail(context.Exception.Message));
        }
    }
}
