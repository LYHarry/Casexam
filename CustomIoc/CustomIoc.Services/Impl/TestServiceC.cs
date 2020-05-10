using System;
using System.Collections.Generic;
using System.Text;

namespace CustomIoc.Services.Impl
{
    public class TestServiceC : ITestServiceC
    {
        public TestServiceC()
        {
            Console.WriteLine("TestServiceC.Constructor");
        }

        public void ShowMessage()
        {
            Console.WriteLine("TestServiceC.ShowMessage");
        }
    }
}
