using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 图形计算
{
    class Primary
    {
        public void chief()
        {
            Console.WriteLine("\t你想要进行怎样的图形计算。。");
            Console.WriteLine("\t   1.计算图形的周长。。");
            Console.WriteLine("\t   2.计算图形的面积。。");
            Console.WriteLine("\t   3.计算图形的体积。。");
            int choose = 0;
            String s = Console.ReadLine();
            choose = Convert.ToInt32(s);
            switch (choose)
            {
                case 1:
                    {
                        Perimeter per = new Perimeter();
                        per.ChartPerimeter();
                    }
                    break;
                case 2:
                    {
                        Area area = new Area();
                        area.ChartArea();
                    } break;
                case 3:
                    {
                        Volume v = new Volume();
                        v.ChartVolume();
                    } break;
            }
        }
    }
}
