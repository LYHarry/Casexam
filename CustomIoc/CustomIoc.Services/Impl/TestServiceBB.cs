using System;
using System.Collections.Generic;
using System.Text;

namespace CustomIoc.Services.Impl
{
    public class TestServiceBB : ITestServiceB
    {
        private readonly ITestServiceD _testServiceD;

        public TestServiceBB(ITestServiceD testServiceD)
        {
            Console.WriteLine("TestServiceBB.Constructor");
            _testServiceD = testServiceD;
        }

        public void ShowMessage()
        {
            Console.WriteLine("TestServiceBB.ShowMessage");
        }
    }
}
