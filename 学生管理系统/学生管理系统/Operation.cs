using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 学生管理系统
{
    /// <summary>
    /// 操作类
    /// </summary>
    class Operation
    {
        private int choice = 0;
        private string s;   //用于存放输入信息
        private int f = 0;  //用于存放学生个数;
        private char ch;  //用于提示是否继续

        Manage m = new Manage();

        public void Oper()
        {
            s = Console.ReadLine();
            choice = Convert.ToInt32(s);
            switch (choice)
            {
                case 1:
                    {
                        do
                        {
                            Console.WriteLine("请输入你要添加多少个学生信息！");
                            Console.Write("个数为： ");
                            s = Console.ReadLine();
                            f = Convert.ToInt32(s);

                            m.setM(f);

                            for (int i = 0; i < f; i++)
                            {
                                Console.WriteLine("请输入学生信息！");
                                Console.Write("学号：");
                                string id = Console.ReadLine();
                                Console.Write("姓名：");
                                string name = Console.ReadLine();
                                Console.Write("性别：");
                                string sex = Console.ReadLine();
                                Console.Write("年龄：");
                                s = Console.ReadLine();
                                int age = Convert.ToInt32(s);
                                Console.Write("班级：");
                                string grade = Console.ReadLine();
                                Console.Write("成绩：");
                                s = Console.ReadLine();
                                int score = Convert.ToInt32(s);

                                Student str = new Student(id, name, sex, age, grade, score);

                                m.AddStr(str);
                            }
                            Console.WriteLine("已成功添加！");
                            Console.WriteLine("你还要继续吗？(y/n),按0退出系统！");
                            s = Console.ReadLine();
                            ch = Convert.ToChar(s);
                            if (ch == '0') Environment.Exit(0);
                        } while (ch == 'y');
                    } break;

                case 2: m.Seek(); break;

                case 3:
                    {
                        m.Del();
                        m.DisPlay();
                    } break;

                case 4:
                    {
                        m.Change();
                        m.DisPlay();
                    } break;

                case 5:
                    {
                        m.Sort();
                        m.DisPlay();
                        Console.ReadLine();
                    } break;

                case 6:
                    {
                        m.DisPlay();
                        Console.ReadLine();
                        Console.Clear();
                    } break;

                case 0: Environment.Exit(0); break;
            }

        }

    }
}
