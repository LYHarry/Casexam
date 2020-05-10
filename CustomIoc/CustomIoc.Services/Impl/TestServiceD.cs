using System;
using System.Collections.Generic;
using System.Text;

namespace CustomIoc.Services.Impl
{
    public class TestServiceD : ITestServiceD
    {
        public TestServiceD()
        {
            Console.WriteLine("TestServiceD.Constructor");
        }

        public void ShowMessage()
        {
            Console.WriteLine("TestServiceD.ShowMessage");
        }
    }
}
