using Easycode.Common.ResultCore;
using Easycode.TimerService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Timers;

namespace Topshelf.Test
{
    public class RunTimerService
    {
        //处理事务的定时器
        private Timer _timer = null;
        //加载待处理事务数据的定时器
        private Timer _readActionTimer = null;
        //上一次加载待处理事务数据的时间
        private DateTime lastLoadModuleTime = DateTime.Parse("1970-01-01");
        //需要处理的事务列表
        private Queue<ITimerService> ModulesList { get; set; } = new Queue<ITimerService>();
        //保存设置了执行间隔天数的模块的下次执行时间
        private Dictionary<string, DateTime> NextLoadTimeDict = new Dictionary<string, DateTime>();

        /// <summary>
        /// 开启定时器
        /// </summary>
        public void OnStart()
        {
            _timer = new Timer() //处理事务
            {
                AutoReset = true,
                Enabled = true,
                Interval = TimeSpan.FromSeconds(3).TotalMilliseconds
            };
            _timer.Elapsed += _timer_Elapsed;
            _timer.Start();

            _readActionTimer = new Timer() //加载待处理事务
            {
                AutoReset = true,
                Enabled = true,
                Interval = TimeSpan.FromSeconds(1).TotalMilliseconds
            };
            _readActionTimer.Elapsed += _readActionTimer_Elapsed;
            _readActionTimer.Start();
        }

        /// <summary>
        /// 加载待处理事务数据的定时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _readActionTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            DateTime dt = Convert.ToDateTime(e.SignalTime); //每次定时器调用的时间

            //一个小时去加载一次数据，不管待处理和事务处理完没都去加载数据
            if (lastLoadModuleTime.Hour == dt.Hour)
            {
                Console.WriteLine("未到加载待处理事务数据的时间，时间：{0}", lastLoadModuleTime.AddHours(1).ToString("yyyy-MM-dd HH"));
                return;
            }

            Console.WriteLine("开始加载待处理事务数据， 时间：" + dt.ToString("yyyy-MM-dd HH:mm:ss fff"));
            var optResult = LoadModules();
            if (optResult.State == StatusCode.Success.Value())
            {
                lastLoadModuleTime = DateTime.Now;
                _readActionTimer.Interval = TimeSpan.FromSeconds(45).TotalMilliseconds;
            }
            else
            {
                Console.WriteLine(optResult.Message);
            }

            Console.WriteLine("结束加载待处理事务数据， 共加载到" + ModulesList.Count + "条待处理事务 时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff"));
            Console.WriteLine();
        }


        /// <summary>
        /// 加载该处理的事务的方法
        /// </summary>
        private AjaxResult LoadModules()
        {
            AjaxResult result = new AjaxResult();
            try
            {
                if (ModulesList != null && ModulesList.Count > 0)
                {
                    Console.WriteLine("上次处理事务时，待处理事务还有" + ModulesList.Count + "条没有处理完。");
                }

                ModulesList.Clear();
                string dir = AppDomain.CurrentDomain.BaseDirectory;
                string[] assPaths = Directory.GetFiles(dir, "TimerService".AppSetting());
                if (assPaths == null || assPaths.Length < 1)
                {
                    return result.SetValue(StatusCode.Error, "没有找到名称中包含WinService的dll程序集");
                }

                Assembly assembly = Assembly.LoadFile(assPaths[0]);
                if (assembly == null)
                {
                    return result.SetValue(StatusCode.Error, assPaths[0] + " 程序集内容为空。");
                }

                List<Type> moduleTypes = assembly.GetTypes().Where(m => m.GetInterface(nameof(ITimerService), true) != null && m.IsAbstract == false).ToList();
                if (moduleTypes == null || moduleTypes.Count < 1)
                {
                    return result.SetValue(StatusCode.Error, "程序集中没有实现ITimerService接口或AnalyticalModule抽象类的实例类");
                }

                foreach (Type moduleType in moduleTypes)
                {
                    var module = Activator.CreateInstance(moduleType) as ITimerService;
                    if (module == null) { continue; }
                    ModulesList.Enqueue(module);
                }
                return result.SetValue(StatusCode.Success, "成功加载该处理事务");
            }
            catch (Exception ex)
            {
                return result.SetValue(StatusCode.Exception, "加载待处理事务出错：" + ex.Message);
            }
        }


        /// <summary>
        /// 处理事务的定时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (ModulesList == null || ModulesList.Count < 1)
            {
                Console.WriteLine("没有待处理的事务。"); return;
            }

            Console.WriteLine("待处理的事务共有{0}条。\r\n", ModulesList.Count);
            var moduleObj = ModulesList.Dequeue();
            try
            {
                var desc = moduleObj.ModuleDescription();
                if (desc == null || desc.DataType != typeof(TimerConfig))
                {
                    Console.WriteLine("配置类DataType属性不等于TimerConfig类型"); return;
                }

                TimerConfig config = desc.Data as TimerConfig;
                if (config == null)
                {
                    Console.WriteLine("该事务模块没有设置定时器配置类。"); return;
                }

                //if (config.Hour != DateTime.Now.Hour || config.Minute != DateTime.Now.Minute)
                //{
                //    Console.WriteLine(desc.ModuleName + "(" + desc.ModuleEName + ")事务未到处理时间。{0}:{1}", config.Hour, config.Minute);
                //    ModulesList.Enqueue(moduleObj); return;
                //}

                //判断当前模块是否设置执行间隔天数
                if (NextLoadTimeDict != null && NextLoadTimeDict.Count > 0 && NextLoadTimeDict.ContainsKey(desc.ModuleEName))
                {
                    DateTime nexttime = NextLoadTimeDict[desc.ModuleEName];
                    if (nexttime != null && config.Interval > 0)
                    {
                        if (nexttime.Year != DateTime.Now.Year || nexttime.Month != DateTime.Now.Month || nexttime.Day != DateTime.Now.Day)
                        {
                            Console.WriteLine(desc.ModuleName + "(" + desc.ModuleEName + ")事务未到处理时间。{2} {0}:{1} 间隔{3}天。", config.Hour, config.Minute, nexttime.ToString("yyyy-MM-dd"), config.Interval);
                            ModulesList.Enqueue(moduleObj); return;
                        }
                    }
                }

                Console.WriteLine(desc.ModuleName + "(" + desc.ModuleEName + ")开始执行。执行时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff"));
                var loadResult = moduleObj.Load();
                if (loadResult.State == StatusCode.Success.Value())
                {
                    //当前模块执行成功后，判断当前模块是否设置执行间隔天数
                    if (config.Interval > 0)
                    {
                        if (NextLoadTimeDict.ContainsKey(desc.ModuleEName))
                        {
                            NextLoadTimeDict[desc.ModuleEName] = DateTime.Now.AddDays(config.Interval + 1);
                        }
                        else
                        {
                            NextLoadTimeDict.Add(desc.ModuleEName, DateTime.Now.AddDays(config.Interval + 1));
                        }
                    }
                }
                Console.WriteLine(desc.ModuleName + "(" + desc.ModuleEName + ")结束执行。完成时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff"));
                Console.WriteLine();
            }
            catch (Exception exception)
            {
                moduleObj.OnLoadException(exception);
            }
        }

        /// <summary>
        /// 关闭定时器
        /// </summary>
        public void OnShutdown()
        {
            _readActionTimer.Stop();
            _timer.Stop();
        }

        /// <summary>
        /// 关闭定时器
        /// </summary>
        public void OnStop()
        {
            _readActionTimer.Stop();
            _timer.Stop();
        }

    }
}
