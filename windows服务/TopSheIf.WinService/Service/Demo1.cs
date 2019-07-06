using System;
using Easycode.Common.ResultCore;
using Easycode.TimerService;

namespace TopSheIf.WinService.Service
{
    public class Demo1 : AnalyticalModule
    {
        public override ModuleConfig ModuleDescription()
        {
            return new ModuleConfig()
            {
                ModuleName = "例子1测试",
                ModuleEName = nameof(Demo1),
                DataType = typeof(TimerConfig),
                Data = new TimerConfig()
                {
                    Year = 2017,
                    Month = 11,
                    Day = 2,
                    Hour = 14,
                    Minute = 38
                }
            };
        }

        public override AjaxResult Executes(long startTime, long endTime)
        {
            return null;
        }

        public override AjaxResult Executes(DateTime startTime, DateTime endTime)
        {
            Console.WriteLine("具体逻辑实现方法，Executes(DateTime)。");
            return new AjaxResult().SetValue(StatusCode.Success, "执行成功");
        }
    }
}
