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
                ICustomIocContainers container = new CustomIocContainers();
                ////1、注册服务
                //container.Register<ITestServiceA, TestServiceA>();
                //container.Register<ITestServiceB, TestServiceB>(constParams: new object[] { 10, "jokeff", "25" });
                //container.Register<ITestServiceC, TestServiceC>();
                //container.Register<ITestServiceD, TestServiceD>();
                //container.Register<ITestServiceE, TestServiceE>();
                ////单接口多实现
                //container.Register<ITestServiceB, TestServiceBB>();
                //container.Register<ITestServiceF, TestServiceF>();

                //2、创建对象实例
                //ITestService testService = container.Resolve<ITestServiceA>();
                //ITestService testService = container.Resolve<ITestServiceE>();

                //单接口多实现
                //ITestService testService = container.Resolve<ITestServiceB>();
                //ITestService testServiceBB = container.Resolve<ITestServiceB>(typeof(TestServiceBB));
                //ITestService testService = container.Resolve<ITestServiceF>();         

                //3、方法调用
                //testService.ShowMessage();
                //testServiceBB.ShowMessage();

                #region 生命周期

                //单例
                container.RegisterSingleton<ITestServiceC, TestServiceC>();
                ITestService sc1 = container.Resolve<ITestServiceC>();
                ITestService sc2 = container.Resolve<ITestServiceC>();
                Console.WriteLine("单例 ITestServiceC {0}", object.ReferenceEquals(sc1, sc2));
                Console.WriteLine("======================== \r\n");

                //瞬时
                container.RegisterTransient<ITestServiceD, TestServiceD>();
                ITestService sd1 = container.Resolve<ITestServiceD>();
                ITestService sd2 = container.Resolve<ITestServiceD>();
                Console.WriteLine("瞬时 TestServiceD {0}", object.ReferenceEquals(sd1, sd2));
                Console.WriteLine("======================== \r\n");

                //容器单例
                container.RegisterScoped<ITestServiceG, TestServiceG>();
                ITestService sg1 = container.Resolve<ITestServiceG>();
                ITestService sg2 = container.Resolve<ITestServiceG>();

                ICustomIocContainers childContainer1 = container.CreateChildContainer();
                childContainer1.RegisterScoped<ITestServiceG, TestServiceG>();
                ITestService sg11 = childContainer1.Resolve<ITestServiceG>();
                ITestService sg12 = childContainer1.Resolve<ITestServiceG>();

                ICustomIocContainers childContainer2 = container.CreateChildContainer();
                childContainer2.RegisterScoped<ITestServiceG, TestServiceG>();
                ITestService sg21 = childContainer2.Resolve<ITestServiceG>();
                ITestService sg22 = childContainer2.Resolve<ITestServiceG>();

                Console.WriteLine("容器单例 父-父 {0}", object.ReferenceEquals(sg1, sg2));
                Console.WriteLine("容器单例 父-子1 {0}", object.ReferenceEquals(sg1, sg11));
                Console.WriteLine("容器单例 父-子1 {0}", object.ReferenceEquals(sg1, sg12));
                Console.WriteLine("容器单例 父-子2 {0}", object.ReferenceEquals(sg1, sg21));
                Console.WriteLine("容器单例 父-子2 {0}", object.ReferenceEquals(sg1, sg22));
                Console.WriteLine("容器单例 子1-子1 {0}", object.ReferenceEquals(sg11, sg12));
                Console.WriteLine("容器单例 子1-子2 {0}", object.ReferenceEquals(sg11, sg21));
                Console.WriteLine("容器单例 子1-子2 {0}", object.ReferenceEquals(sg11, sg22));
                Console.WriteLine("容器单例 子2-子2 {0}", object.ReferenceEquals(sg21, sg22));

                #endregion

            }
            catch (Exception ex)
            {
                Console.WriteLine("err: ", ex.Message);
            }
        }
    }
}
