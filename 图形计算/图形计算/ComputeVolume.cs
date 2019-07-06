using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 图形计算
{
    /// <summary>
    /// 体积计算帮助类
    /// </summary>
    class ComputeVolume
    {
        /// <summary>
        /// 计算长方体体积
        /// </summary>
        public void CuboidVolume()
        {
            Console.WriteLine("输入长方体的长、宽、高：");
            Console.Write("长为： ");
            String s = Console.ReadLine();
            float l = Convert.ToSingle(s);
            Console.Write("宽为： ");
            s = Console.ReadLine();
            float w = Convert.ToSingle(s);
            Console.Write("高为： ");
            s = Console.ReadLine();
            float h = Convert.ToSingle(s);
            float sum = l * w * h;
            Console.WriteLine("长方体的体积为:  {0}", sum);
        }

        /// <summary>
        /// 计算圆柱体的体积
        /// </summary>
        public void CylinderVolume()
        {
            Console.WriteLine("输入圆柱体的高和半径：");
            Console.Write("高为： ");
            String s = Console.ReadLine();
            float h = Convert.ToSingle(s);
            Console.Write("半径为： ");
            s = Console.ReadLine();
            float r = Convert.ToSingle(s);
            float pi = 3.14f;
            float sum = pi * r * r * h;
            Console.WriteLine("圆柱体的体积为： {0}", sum);
        }

        /// <summary>
        /// 计算圆锥体的体积
        /// </summary>
        public void ConeVolume()
        {
            Console.WriteLine("输入圆锥体的高和半径：");
            Console.Write("高为： ");
            String s = Console.ReadLine();
            float h = Convert.ToSingle(s);
            Console.Write("半径为：");
            s = Console.ReadLine();
            float r = Convert.ToSingle(s);
            float pi = 3.14f;
            float sum = (pi * r * r * h) / 3;
            Console.WriteLine("圆锥体的体积为： {0}", sum);
        }

        /// <summary>
        /// 计算球体的体积
        /// </summary>
        public void SphereVolume()
        {
            Console.WriteLine("输入球体的半径:");
            Console.Write("半径为:  ");
            String s = Console.ReadLine();
            float r = Convert.ToSingle(s);
            float pi = 3.14f;
            float sum = ((pi * r * r * r) * 4) / 3;
            Console.WriteLine("球体的体积为:  {0}", sum);
        }

    }
}
