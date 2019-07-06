using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 图形计算
{
    class Volume
    {
        public void ChartVolume()
        {
            char choice;
            int choose = 0;
            do
            {
                Console.WriteLine("\t你想要计算什么图形的体积。。");
                Console.WriteLine("\t   1.长方体的体积。。");
                Console.WriteLine("\t   2.圆柱体的体积。。");
                Console.WriteLine("\t   3.圆锥体的体积。。");
                Console.WriteLine("\t   4.球体的体积。。");

                String s = Console.ReadLine();
                choose = Convert.ToInt32(s);

                ComputeVolume volume = new ComputeVolume();
                switch (choose)
                {
                    case 1: volume.CuboidVolume(); break;
                    case 2: volume.CylinderVolume(); break;
                    case 3: volume.ConeVolume(); break;
                    case 4: volume.SphereVolume(); break;
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
