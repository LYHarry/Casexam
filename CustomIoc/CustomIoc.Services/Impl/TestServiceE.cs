using CustomIoc.Infrastructure.Attrs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomIoc.Services.Impl
{
    public class TestServiceE : ITestServiceE
    {
        /// <summary>
        /// 属性注入
        /// </summary>
        [PropertyInject]
        public ITestServiceD TestServiceD { get; set; }

        public TestServiceE()
        {
            Console.WriteLine("TestServiceE.Constructor");
        }

        private ITestServiceB _testServiceB;
        private ITestServiceD _testServiceD;
        /// <summary>
        /// 方法注入
        /// </summary>
        /// <param name="testServiceB"></param>
        /// <param name="testServiceD"></param>
        [MethodInject]
        public void InitService(ITestServiceB testServiceB, ITestServiceD testServiceD)
        {
            Console.WriteLine("TestServiceE.InitService");
            _testServiceB = testServiceB;
            _testServiceD = testServiceD;
        }

        public void ShowMessage()
        {
            Console.WriteLine("TestServiceE.ShowMessage");
        }
    }
}
