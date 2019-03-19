using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.ViewModel
{
    /// <summary>
    /// 数据处理结果返回类
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    public class AjaxResult<TData>
    {
        public ServiceStatus Status { get; set; }

        public string Message { get; set; }

        public TData Data { get; set; }


        public AjaxResult<TData> SetValue(ServiceStatus state, string msg, TData data)
        {
            this.Status = state;
            this.Message = string.IsNullOrWhiteSpace(msg) ? state.ToString() : msg;
            this.Data = data;
            return this;
        }

        public AjaxResult<TData> SetFail(string msg, TData data)
        {
            return SetValue(ServiceStatus.Failure, msg, data);
        }

        public AjaxResult<TData> SetFail(string msg)
        {
            return SetFail(msg, default(TData));
        }

        public AjaxResult<TData> SetSuccess(string msg, TData data)
        {
            return SetValue(ServiceStatus.Success, msg, data);
        }

        public AjaxResult<TData> SetSuccess(TData data)
        {
            return SetValue(ServiceStatus.Success, string.Empty, data);
        }

    }
}
