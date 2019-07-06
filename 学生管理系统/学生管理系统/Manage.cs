using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 学生管理系统
{
    /// <summary>
    /// 管理类
    /// </summary>
    class Manage
    {
        private Student[] str = null;
        private int count = 0;  //用于存放数组大小
        private string data = "";  //用于存入输入信息
        private char ch;   //用于提示是否循环

        /// <summary>
        /// 创建学生对象
        /// </summary>
        /// <param name="n">创建个数</param>
        public void setM(int n)
        {
            str = new Student[n];
            count = 0;
        }



        /// <summary>
        /// 添加学生数据
        /// </summary>
        /// <param name="st"></param>
        public void AddStr(Student st)
        {
            str[count] = st;
            count++;
        }


        /// <summary>
        /// 显示数据
        /// </summary>
        public void DisPlay()
        {
            Console.WriteLine("学号\t姓名\t性别\t年龄\t班级\t\t成绩");
            for (int i = 0; i < count; i++)
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", str[i].id, str[i].name, str[i].sex, str[i].age, str[i].grade, str[i].score);
        }



        /// <summary>
        /// 查找数据
        /// </summary>
        public void Seek()
        {
            do
            {
                Console.WriteLine("\n--------------------------------------");
                Console.WriteLine("\t 1.根据学号查找。。");
                Console.WriteLine("\t 2.根据姓名查找。。");
                Console.WriteLine("\t 3.根据班级查找。。");
                Console.WriteLine("--------------------------------------");

                data = Console.ReadLine();
                int choice = Convert.ToInt32(data);
                switch (choice)
                {
                    case 1:
                        {
                            Console.Write("学号：");
                            data = Console.ReadLine();
                            for (int i = 0; i < count; i++)
                                if (str[i].id == data)
                                {
                                    Console.WriteLine("你查找的学生信息为：");
                                    Console.WriteLine("学号\t姓名\t性别\t年龄\t班级\t\t成绩");
                                    Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", str[i].id, str[i].name, str[i].sex, str[i].age, str[i].grade, str[i].score);
                                }
                        } break;

                    case 2:
                        {
                            Console.Write("姓名：");
                            data = Console.ReadLine();
                            for (int i = 0; i < count; i++)
                                if (str[i].name == data)
                                {
                                    Console.WriteLine("你查找的学生信息为：");
                                    Console.WriteLine("学号\t姓名\t性别\t年龄\t班级\t\t成绩");
                                    Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", str[i].id, str[i].name, str[i].sex, str[i].age, str[i].grade, str[i].score);
                                }
                        } break;

                    case 3:
                        {
                            Console.Write("班级：");
                            data = Console.ReadLine();
                            for (int i = 0; i < count; i++)
                                if (str[i].grade == data)
                                {
                                    Console.WriteLine("你查找的学生信息为：");
                                    Console.WriteLine("学号\t姓名\t性别\t年龄\t班级\t\t成绩");
                                    Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", str[i].id, str[i].name, str[i].sex, str[i].age, str[i].grade, str[i].score);
                                }
                        } break;
                }
                Console.WriteLine("你要继续吗？(y/n)");
                data = Console.ReadLine();
                ch = Convert.ToChar(data);
            } while (ch == 'y');
        }



        /// <summary>
        /// 排序数据
        /// </summary>
        public void Sort()
        {
            Student t;
            for (int i = 0; i < count; i++)
                for (int j = i + 1; j < count; j++)
                    if (str[i].score > str[j].score)
                    { t = str[i]; str[i] = str[j]; str[j] = t; }
        }



        /// <summary>
        /// 删除数据
        /// </summary>
        public void Del()
        {
            do
            {
                Console.WriteLine("\n--------------------------------------");
                Console.WriteLine("\t 1.根据学号删除。。");
                Console.WriteLine("\t 2.根据姓名删除。。");
                Console.WriteLine("\t 3.根据班级删除。。");
                Console.WriteLine("--------------------------------------");

                data = Console.ReadLine();
                int choice = Convert.ToInt32(data);
                switch (choice)
                {
                    case 1:
                        {
                            Console.Write("学号：");
                            data = Console.ReadLine();
                            for (int i = 0; i < count; i++)
                                if (data == str[i].id)
                                {
                                    Console.WriteLine("你要删除的学生信息是：");
                                    Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", str[i].id, str[i].name, str[i].sex, str[i].age, str[i].grade, str[i].score);

                                    str[i] = str[i + 1];
                                    count--;
                                }
                        } break;

                    case 2:
                        {
                            Console.Write("姓名：");
                            data = Console.ReadLine();
                            for (int i = 0; i < count; i++)
                                if (data == str[i].name)
                                {
                                    Console.WriteLine("你要删除的学生信息是：");
                                    Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", str[i].id, str[i].name, str[i].sex, str[i].age, str[i].grade, str[i].score);

                                    str[i] = str[i + 1];
                                    count--;
                                }
                        } break;

                    case 3:
                        {
                            Console.Write("班级：");
                            data = Console.ReadLine();
                            for (int i = 0; i < count; i++)
                                if (data == str[i].grade)
                                {
                                    Console.WriteLine("你要删除的学生信息是：");
                                    Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", str[i].id, str[i].name, str[i].sex, str[i].age, str[i].grade, str[i].score);

                                    str[i] = str[i + 1];
                                    count--;
                                }
                        } break;
                }
                Console.WriteLine("你要继续吗？(y/n)");
                data = Console.ReadLine();
                ch = Convert.ToChar(data);
            } while (ch == 'y');
        }


        /// <summary>
        /// 更改数据
        /// </summary>
        public void Change()
        {
            do
            {
                Console.WriteLine("\n--------------------------------------");
                Console.WriteLine("\t 1.更改学号。。");
                Console.WriteLine("\t 2.更改姓名。。");
                Console.WriteLine("\t 3.更改班级。。");
                Console.WriteLine("\t 4.更改年龄。。");
                Console.WriteLine("--------------------------------------");

                data = Console.ReadLine();
                int choice = Convert.ToInt32(data);
                switch (choice)
                {
                    case 1:
                        {
                            Console.Write("要更改的学号：");
                            data = Console.ReadLine();

                            Console.Write("更改的学号：");
                            string dn = Console.ReadLine();
                            for (int i = 0; i < count; i++)
                                if (data == str[i].id)
                                {
                                    str[i].id = dn;
                                    Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", str[i].id, str[i].name, str[i].sex, str[i].age, str[i].grade, str[i].score);
                                }
                        } break;

                    case 2:
                        {
                            Console.Write("要更改的姓名：");
                            data = Console.ReadLine();

                            Console.Write("更改的姓名：");
                            string dn = Console.ReadLine();
                            for (int i = 0; i < count; i++)
                                if (data == str[i].name)
                                {
                                    str[i].name = dn;
                                    Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", str[i].id, str[i].name, str[i].sex, str[i].age, str[i].grade, str[i].score);
                                }
                        } break;

                    case 3:
                        {
                            Console.Write("要更改的班级：");
                            data = Console.ReadLine();

                            Console.Write("更改的班级：");
                            string dn = Console.ReadLine();

                            for (int i = 0; i < count; i++)
                                if (data == str[i].grade)
                                {
                                    str[i].grade = dn;
                                    Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", str[i].id, str[i].name, str[i].sex, str[i].age, str[i].grade, str[i].score);
                                }
                        } break;
                    case 4:
                        {
                            Console.Write("要更改的年龄：");
                            data = Console.ReadLine();
                            int da = Convert.ToInt32(data);

                            Console.Write("更改的年龄：");
                            data = Console.ReadLine();
                            int dna = Convert.ToInt32(data);
                            for (int i = 0; i < count; i++)
                                if (da == str[i].age)
                                {
                                    str[i].age = dna;
                                    Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", str[i].id, str[i].name, str[i].sex, str[i].age, str[i].grade, str[i].score);
                                }
                        } break;
                }
                Console.WriteLine("你要继续吗？(y/n)");
                data = Console.ReadLine();
                ch = Convert.ToChar(data);
            } while (ch == 'y');
        }
    }
}