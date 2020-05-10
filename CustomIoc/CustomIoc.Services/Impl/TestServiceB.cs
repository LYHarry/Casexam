using CustomIoc.Infrastructure.Attrs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomIoc.Services.Impl
{
    public class TestServiceB : ITestServiceB
    {
        private readonly ITestServiceC _testServiceC;

        public TestServiceB(ITestServiceC testServiceC)
        {
            Console.WriteLine("TestServiceB.Constructor");
            _testServiceC = testServiceC;
        }

        [ConstructorInject]
        public TestServiceB([ParameterConstInject(0)]int index,
            ITestServiceC testServiceC,
            [ParameterConstInject(1)]string name)
        {
            Console.WriteLine($"TestServiceB.Constructor index:{index} name:{name}.");
            _testServiceC = testServiceC;
        }

        private ITestServiceC _testServiceBB;
        private ITestServiceD _testServiceD;
        /// <summary>
        /// 方法注入
        /// </summary>
        /// <param name="testServiceB"></param>
        /// <param name="testServiceD"></param>
        [MethodInject]
        public void InitService(ITestServiceC testServiceC,
            [ParameterConstInject(0)]int index,
            ITestServiceD testServiceD,
            [ParameterConstInject(1)]string name,
            [ParameterConstInject(2)]string age)
        {
            Console.WriteLine($"TestServiceB.InitService index:{index} name:{name} age:{age}");
            _testServiceBB = testServiceC;
            _testServiceD = testServiceD;
        }

        public void ShowMessage()
        {
            Console.WriteLine("TestServiceB.ShowMessage");
        }
    }
}
