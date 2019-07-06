using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATM取款机
{
    class Program
    {
        static void Main(string[] args)
        {
            AutoATM atm = new AutoATM("123", 123456, 1000);
            Operation oper = new Operation(atm);

            Console.WriteLine("卡号：123 密码：123456");
            for (int i = 0; i < 3; i++)
            {
                Console.Write("\n请输入卡号：");
                string name = Console.ReadLine();
                Console.Write("请输入密码：");
                int password = Convert.ToInt32(Console.ReadLine());

                if (name == atm.GetName() && password == atm.GetPassWord())
                {
                    while (true)
                    {
                        Operation.Menu();
                        oper.Oper();
                    }
                }
                else
                {
                    if (i == 2)
                    {
                        Console.WriteLine("你已输入错误三次！");
                        Environment.Exit(0);
                    }
                    else
                        Console.WriteLine("你输入错误！");
                }
            }

        }
    }
}
