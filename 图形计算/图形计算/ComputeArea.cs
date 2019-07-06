using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 图形计算
{
    /// <summary>
    /// 面积计算帮助类
    /// </summary>
    class ComputeArea
    {
        /// <summary>
        /// 计算三角形的面积
        /// </summary>
        public void TriangleArea()
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
            float m = (a + b + c) / 2;
            float sum = (float)Math.Sqrt(m * (m - a) * (m - b) * (m - c));
            Console.WriteLine("三角形面积为:  {0}", sum);
        }

        /// <summary>
        /// 计算矩形的面积
        /// </summary>
        public void ShapeArea()
        {
            Console.WriteLine("输入长方形的长和宽：");
            Console.Write("长为： ");
            String s = Console.ReadLine();
            float l = Convert.ToSingle(s);
            Console.Write("宽为： ");
            s = Console.ReadLine();
            float w = Convert.ToSingle(s);
            float sum = l * w;
            Console.WriteLine("长方形的面积为： {0}", sum);
        }

        /// <summary>
        /// 计算梯形的面积
        /// </summary>
        public void TrapeziumArea()
        {
            Console.WriteLine("输入梯形各边的边长：");
            Console.Write("上底为： ");
            String s = Console.ReadLine();
            float a = Convert.ToSingle(s);
            Console.Write("下底为： ");
            s = Console.ReadLine();
            float b = Convert.ToSingle(s);
            Console.Write("高为： ");
            s = Console.ReadLine();
            float h = Convert.ToSingle(s);

            float sum = (a + b) * h / 2;
            Console.WriteLine("梯形的面积为: {0}", sum);
        }

        /// <summary>
        /// 计算圆的面积
        /// </summary>
        public void RoundArea()
        {
            Console.WriteLine("输入圆的半径：");
            Console.Write("半径为:  ");
            String s = Console.ReadLine();
            float r = Convert.ToSingle(s);
            float pi = 3.14f;
            float sum = pi * r * r;
            Console.WriteLine("圆的面积为: {0}", sum);
        }

        /// <summary>
        /// 计算平行四边形的面积
        /// </summary>
        public void ParallelogramArea()
        {
            Console.WriteLine("输入平行四边形的底和高：");
            Console.Write("输入底边： ");
            String s = Console.ReadLine();
            float a = Convert.ToSingle(s);
            Console.Write("输入高： ");
            s = Console.ReadLine();
            float l = Convert.ToSingle(s);
            float sum = a * l;
            Console.WriteLine("平行四边形的面积为: {0}", sum);
        }

        /// <summary>
        /// 计算长方体的面积
        /// </summary>
        public void CuboidArea()
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
            float sum = (l * w + w * h + l * h) * 2;
            Console.WriteLine("长方体的面积为：{0}", sum);
        }

        /// <summary>
        /// 计算圆柱体的面积
        /// </summary>
        public void CylinderArea()
        {
            Console.WriteLine("输入圆柱体的半径、高");
            Console.Write("半径为：");
            String s = Console.ReadLine();
            float r = Convert.ToSingle(s);
            Console.Write("高为：");
            s = Console.ReadLine();
            float h = Convert.ToSingle(s);
            float pi = 3.14f;
            float sum = 2 * pi * r * h + 2 * pi * r * r;
            Console.WriteLine("圆柱体的面积为: {0}", sum);
        }

        /// <summary>
        /// 圆锥体的面积
        /// </summary>
        public void ConeArea()
        {
            Console.WriteLine("输入圆锥体的母线和半径：");
            Console.Write("母线为: ");
            String s = Console.ReadLine();
            float l = Convert.ToSingle(s);
            Console.Write("半径为: ");
            s = Console.ReadLine();
            float r = Convert.ToSingle(s);
            float pi = 3.14f;
            float sum = l * pi * r + pi * r * r;
            Console.WriteLine("圆锥体的面积为： {0}", sum);
        }

        /// <summary>
        /// 球体的面积
        /// </summary>
        public void SphereArea()
        {
            Console.WriteLine("输入球体的半径：");
            Console.Write("半径为: ");
            String s = Console.ReadLine();
            float r = Convert.ToSingle(s);
            float pi = 3.14f;
            float sum = 4 * pi * r * r;
            Console.WriteLine("球体的面积为: {0}", sum);
        }


    }
}
