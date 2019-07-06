using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 学生管理系统
{
    class Program
    {
        static void Main(string[] args)
        {
            Operation op = new Operation();
            while (true)
            {
                menu();
                op.Oper();
            }
        }

        /// <summary>
        /// 菜单
        /// </summary>
        private static void menu()
        {
            Console.Clear();
            Console.WriteLine("\t\t学生管理系统");
            Console.WriteLine("\n--------------------------------------");
            Console.WriteLine("\t 1.添加学生信息。。");
            Console.WriteLine("\t 2.查找学生信息。。");
            Console.WriteLine("\t 3.删除学生信息。。");
            Console.WriteLine("\t 4.更改学生信息。。");
            Console.WriteLine("\t 5.对学生信息排序。。");
            Console.WriteLine("\t 6.显示所有学生信息。。");
            Console.WriteLine("\t 0.退出系统。。");
            Console.WriteLine("--------------------------------------");
        }
    }
}
