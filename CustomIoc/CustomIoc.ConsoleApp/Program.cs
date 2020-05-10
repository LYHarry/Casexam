using CustomIoc.Infrastructure;
using CustomIoc.Infrastructure.Impl;
using CustomIoc.Services;
using CustomIoc.Services.Impl;
using System;

namespace CustomIoc.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ICustomIocContainers containers = new CustomIocContainers();
                //1、注册服务
                containers.Register<ITestServiceA, TestServiceA>();
                containers.Register<ITestServiceB, TestServiceB>(10, "jokeff", "25");
                containers.Register<ITestServiceC, TestServiceC>();
                containers.Register<ITestServiceD, TestServiceD>();
                containers.Register<ITestServiceE, TestServiceE>();
                //单接口多实现
                containers.Register<ITestServiceB, TestServiceBB>();
                containers.Register<ITestServiceF, TestServiceF>();

                //2、创建对象实例
                //ITestService testService = containers.Resolve<ITestServiceA>();
                //ITestService testService = containers.Resolve<ITestServiceE>();

                //单接口多实现
                //ITestService testService = containers.Resolve<ITestServiceB>();
                //ITestService testServiceBB = containers.Resolve<ITestServiceB>(typeof(TestServiceBB));
                ITestService testService = containers.Resolve<ITestServiceF>();

                //3、方法调用
                testService.ShowMessage();
                //testServiceBB.ShowMessage();
            }
            catch (Exception ex)
            {
                Console.WriteLine("err: ", ex.Message);
            }
        }
    }
}
