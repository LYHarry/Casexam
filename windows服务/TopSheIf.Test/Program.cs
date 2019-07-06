using System;

namespace Topshelf.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<RunTimerService>(s =>
                {
                    s.ConstructUsing(name => new RunTimerService());
                    s.WhenStarted(tc => tc.OnStart());
                    s.WhenStopped(tc => tc.OnStop());
                    s.WhenShutdown(tc => tc.OnShutdown());
                });
                x.RunAsLocalSystem();
                x.SetDescription("Sample Topshelf Host");
                x.SetDisplayName("Stuff");
                x.SetServiceName("Stuff");
                x.OnException(ex =>
                {
                    Console.WriteLine("执行出错：" + ex.Message + "\r\n" + ex.StackTrace);
                });
                x.AfterInstall(setting =>
                {
                    Console.WriteLine("安装服务 => 安装成功 时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff"));
                    Console.WriteLine($"安装成功");
                });
                x.AfterUninstall(() =>
                {
                    Console.WriteLine("卸载服务 => 卸载成功 时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff"));
                    Console.WriteLine($"卸载成功");
                });
                x.BeforeUninstall(() =>
                {
                    Console.WriteLine("卸载服务 => 即将卸载 时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff"));
                });
            });
        }
    }
}
