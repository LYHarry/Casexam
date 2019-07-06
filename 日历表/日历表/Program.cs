using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 日历表
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n======================打印日历====================\n");
            Console.Write("是否打印整年的日历（1是）：");
            int isallyear = 0;
            try
            {
                isallyear = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            { isallyear = 0; }

            if (isallyear == 1)
            {
                Console.Write("输入年：");
                int year = Convert.ToInt32(Console.ReadLine());

                Kalendar ka = new Kalendar(year);
                ka.PrintAllYear();
            }
            else
            {
                Console.Write("输入年：");
                int year = Convert.ToInt32(Console.ReadLine());
                Console.Write("输入月：");
                int month = Convert.ToInt32(Console.ReadLine());

                Kalendar ka = new Kalendar(year, month);
                ka.Print();
            }
            Console.Read();
        }
    }
}
