using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 图形计算
{
    class Perimeter
    {
        public void ChartPerimeter()
        {
            char choice;
            do
            {
                Console.WriteLine("\t你想要计算什么图形的周长。。");
                Console.WriteLine("\t   1.三角形的周长。。");
                Console.WriteLine("\t   2.矩形的周长。。");
                Console.WriteLine("\t   3.梯形的周长。。");
                Console.WriteLine("\t   4.圆的周长。。");

                int choose = 0;
                String s = Console.ReadLine();
                choose = Convert.ToInt32(s);

                ComputePerimeter per = new ComputePerimeter();
                switch (choose)
                {
                    case 1: per.TrianglePerimeter(); break;
                    case 2: per.ShapePerimeter(); break;
                    case 3: per.TrapeziumPerimeter(); break;
                    case 4: per.RoundPerimeter(); break;

                }
                Console.WriteLine();
                Console.WriteLine("\t你还想要继续计算吗？(y/n),按 A/a 返回主菜单。。");
                string str = Console.ReadLine();
                choice = Convert.ToChar(str);
                if (choice == 'A' || choice == 'a')
                {
                    Primary p = new Primary();
                    p.chief();

                }
            } while (choice == 'y');
        }

    }
}

