using System;
using System.Collections.Generic;
using System.Text;

namespace Rpc.ViewModel
{
    /// <summary>
    /// 数据处理结果返回类
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    public class AjaxResult<TData>
    {
        /// <summary>
        /// 服务返回状态
        /// </summary>
        public ServiceStatus Status { get; set; }

        /// <summary>
        /// 提示消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 返回数据
        /// </summary>
        public TData Data { get; set; }

        /// <summary>
        /// 设置值
        /// </summary>
        /// <param name="state">返回状态</param>
        /// <param name="msg">提示消息</param>
        /// <param name="data">返回数据</param>
        /// <returns></returns>
        public AjaxResult<TData> SetValue(ServiceStatus state, string msg, TData data)
        {
            this.Status = state;
            this.Message = string.IsNullOrWhiteSpace(msg) ? state.ToString() : msg;
            this.Data = data;
            return this;
        }

        /// <summary>
        /// 设置失败值
        /// </summary>
        /// <param name="msg">提示消息</param>
        /// <param name="data">返回数据</param>
        /// <returns></returns>
        public AjaxResult<TData> SetFail(string msg, TData data)
        {
            return SetValue(ServiceStatus.Failure, msg, data);
        }

        /// <summary>
        /// 设置失败值
        /// </summary>
        /// <param name="msg">提示消息</param>
        /// <returns></returns>
        public AjaxResult<TData> SetFail(string msg)
        {
            return SetFail(msg, default(TData));
        }

        /// <summary>
        /// 设置成功值
        /// </summary>
        /// <param name="msg">提示消息</param>
        /// <param name="data">返回数据</param>
        /// <returns></returns>
        public AjaxResult<TData> SetSuccess(string msg, TData data)
        {
            return SetValue(ServiceStatus.Success, msg, data);
        }

        /// <summary>
        /// 设置成功值
        /// </summary>
        /// <param name="data">返回数据</param>
        /// <returns></returns>
        public AjaxResult<TData> SetSuccess(TData data)
        {
            return SetValue(ServiceStatus.Success, string.Empty, data);
        }

    }
}
