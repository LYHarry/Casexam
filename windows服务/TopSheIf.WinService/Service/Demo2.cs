using System;
using Easycode.Common.ResultCore;
using Easycode.TimerService;

namespace TopSheIf.WinService.Service
{
    public class Demo2 : AnalyticalModule
    {
        public override ModuleConfig ModuleDescription()
        {
            return new ModuleConfig()
            {
                ModuleName = "例子2测试",
                ModuleEName = nameof(Demo2),
                DataType = typeof(TimerConfig),
                Data = new TimerConfig()
                {
                    Hour = 14,
                    Minute = 38,
                    Interval = 1
                }
            };
        }

        public override AjaxResult Executes(long startTime, long endTime)
        {
            Console.WriteLine("具体逻辑实现方法，Executes(long)。");
            return new AjaxResult().SetValue(StatusCode.Success, "执行成功");
        }

        public override AjaxResult Executes(DateTime startTime, DateTime endTime)
        {
            return null;
        }
    }
}
