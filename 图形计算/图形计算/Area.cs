using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 图形计算
{
    class Area
    {
        public void ChartArea()
        {
            char choice;
            do
            {
                Console.WriteLine("\t你想要计算什么图形的面积。。");
                Console.WriteLine("\t   1.三角形的面积。。");
                Console.WriteLine("\t   2.矩形的面积。。");
                Console.WriteLine("\t   3.圆的面积。。");
                Console.WriteLine("\t   4.梯形的面积。。");
                Console.WriteLine("\t   5.平行四边形的面积。。");
                Console.WriteLine("\t   6.长方体的表面积。。");
                Console.WriteLine("\t   7.圆柱体的表面积。。");
                Console.WriteLine("\t   8.圆锥体的表面积。。");
                Console.WriteLine("\t   9.球体的表面积。。");

                int choose = 0;
                String s = Console.ReadLine();
                choose = Convert.ToInt32(s);

                ComputeArea area = new ComputeArea();
                switch (choose)
                {
                    case 1: area.TriangleArea(); break;
                    case 2: area.ShapeArea(); break;
                    case 3: area.RoundArea(); break;
                    case 4: area.TrapeziumArea(); break;
                    case 5: area.ParallelogramArea(); break;
                    case 6: area.CuboidArea(); break;
                    case 7: area.CylinderArea(); break;
                    case 8: area.ConeArea(); break;
                    case 9: area.SphereArea(); break;
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
            }
            while (choice == 'y');

        }
    }
}
