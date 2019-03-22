using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Rpc.ViewModel;

namespace Rpc.Api.Filter
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception == null)
                return;
            context.Result = new JsonResult(new AjaxResult<string>().SetFail(context.Exception.Message));
        }
    }
}
