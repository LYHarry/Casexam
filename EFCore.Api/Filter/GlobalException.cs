using EFCore.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EFCore.Api.Filter
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
