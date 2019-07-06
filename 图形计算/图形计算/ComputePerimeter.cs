using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 图形计算
{
    /// <summary>
    /// 周长计算帮助类
    /// </summary>
    class ComputePerimeter
    {
        /// <summary>
        /// 计算三角形的周长
        /// </summary>
        public void TrianglePerimeter()
        {
            Console.WriteLine("请输入三角形三边：");
            Console.Write("请输入第一条边:  ");
            String s = Console.ReadLine();
            float a = Convert.ToSingle(s);
            Console.Write("请输入第二条边:  ");
            s = Console.ReadLine();
            float b = Convert.ToSingle(s);
            Console.Write("请输入第三条边:  ");
            s = Console.ReadLine();
            float c = Convert.ToSingle(s);
            float sum = a + b + c;
            Console.WriteLine("三角形周长为:  {0}", sum);
        }

        /// <summary>
        /// 计算长方形的周长
        /// </summary>
        public void ShapePerimeter()
        {
            Console.WriteLine("输入长方形的长和宽：");
            Console.Write("长为： ");
            String s = Console.ReadLine();
            float l = Convert.ToSingle(s);
            Console.Write("宽为： ");
            s = Console.ReadLine();
            float w = Convert.ToSingle(s);
            float sum = (l + w) * 2;
            Console.WriteLine("长方形的周长为： {0}", sum);
        }

        /// <summary>
        /// 计算梯形的周长
        /// </summary>
        public void TrapeziumPerimeter()
        {
            Console.WriteLine("输入梯形各边的边长：");
            Console.Write("上底为： ");
            String s = Console.ReadLine();
            float a = Convert.ToSingle(s);
            Console.Write("下底为： ");
            s = Console.ReadLine();
            float b = Convert.ToSingle(s);
            Console.Write("右腰为： ");
            s = Console.ReadLine();
            float c = Convert.ToSingle(s);
            Console.Write("左腰为： ");
            s = Console.ReadLine();
            float d = Convert.ToSingle(s);
            float sum = a + b + c + d;
            Console.WriteLine("梯形的周长为: {0}", sum);
        }

        /// <summary>
        /// 计算圆的周长
        /// </summary>
        public void RoundPerimeter()
        {
            Console.WriteLine("输入圆的半径：");
            Console.Write("半径为:  ");
            String s = Console.ReadLine();
            float r = Convert.ToSingle(s);
            float pi = 3.14f;
            float sum = 2 * pi * r;
            Console.WriteLine("圆的周长为: {0}", sum);
        }


    }
}
