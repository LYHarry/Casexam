using System;
using System.Collections.Generic;
using System.Text;

namespace CustomIoc.Services.Impl
{
    public class TestServiceG : ITestServiceG
    {
        public TestServiceG()
        {
            Console.WriteLine("TestServiceG.Constructor");
        }

        public void ShowMessage()
        {
            Console.WriteLine("TestServiceG.ShowMessage");
        }
    }
}
