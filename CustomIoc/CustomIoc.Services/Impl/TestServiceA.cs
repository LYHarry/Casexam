using CustomIoc.Infrastructure.Attrs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomIoc.Services.Impl
{
    public class TestServiceA : ITestServiceA
    {
        private readonly ITestServiceB _testServiceB;
        private readonly ITestServiceD _testServiceD;

        /// <summary>
        /// 属性注入
        /// </summary>
        [PropertyInject]
        public ITestServiceE TestServiceE { get; set; }

        public TestServiceA()
        {
            Console.WriteLine("TestServiceA.Constructor，无参数");
        }

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="testServiceB"></param>
        [ConstructorInject]
        public TestServiceA(ITestServiceB testServiceB)
        {
            Console.WriteLine("TestServiceA.Constructor，一个参数");
            _testServiceB = testServiceB;
        }

        public TestServiceA(ITestServiceB testServiceB, ITestServiceD testServiceD)
        {
            Console.WriteLine("TestServiceA.Constructor，二个参数");
            _testServiceB = testServiceB;
            _testServiceD = testServiceD;
        }


        private ITestServiceC _testServiceC;
        /// <summary>
        /// 方法注入
        /// </summary>
        /// <param name="testServiceC"></param>
        [MethodInject]
        public void InitService(ITestServiceC testServiceC)
        {
            Console.WriteLine("TestServiceA.InitService");
            _testServiceC = testServiceC;
        }

        public void ShowMessage()
        {
            Console.WriteLine("TestServiceA.ShowMessage");
        }
    }
}
