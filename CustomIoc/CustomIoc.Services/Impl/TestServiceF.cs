using CustomIoc.Infrastructure.Attrs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomIoc.Services.Impl
{
    public class TestServiceF : ITestServiceF
    {
        private readonly ITestServiceB _testServiceBB;

        [ParameterAliasInject(typeof(TestServiceB))]
        public ITestServiceB TestServiceB { get; set; }

        /// <summary>
        /// 单接口多实现，注入特定服务实例
        /// </summary>
        /// <param name="testServiceBB"></param>
        public TestServiceF([ParameterAliasInject(typeof(TestServiceBB))]ITestServiceB testServiceBB)
        {
            Console.WriteLine("TestServiceF.Constructor");
            _testServiceBB = testServiceBB;
        }

        public void ShowMessage()
        {
            Console.WriteLine("TestServiceF.ShowMessage");
        }
    }
}
