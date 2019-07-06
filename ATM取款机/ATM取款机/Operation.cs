using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATM取款机
{
    /// <summary>
    /// 操作类
    /// </summary>
    class Operation
    {
        AutoATM atm;
        double money;  //用于存放输入金额

        /// <summary>
        /// 声明AutoATM
        /// </summary>
        /// <param name="atm"></param>
        public Operation(AutoATM atm)
        {
            this.atm = atm;
        }

        public void Oper()
        {
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    {
                        Console.Write("请输入取款金额：");
                        money = Convert.ToDouble(Console.ReadLine());
                        if (atm.GetMoney(money) == 1)
                            Console.WriteLine("返回： {0}", money);
                        else
                            Console.WriteLine("你输入出错，最少面值100元！");

                        Console.ReadLine();

                    } break;

                case 2:
                    {
                        Console.Write("请输入存款金额：");
                        money = Convert.ToDouble(Console.ReadLine());
                        if (atm.SavaMoney(money) == 1)
                            Console.WriteLine("存款成功！");
                        else
                            Console.WriteLine("你输入出错，最少面值100元！");

                        Console.ReadLine();
                    } break;

                case 3:
                    {
                        Console.Write("请输入转款账号：");
                        string s = Console.ReadLine();
                        Console.Write("请再次输入转款账号：");
                        string s1 = Console.ReadLine();

                        if (s == s1)
                        {
                            Console.Write("请输入转款金额：");
                            money = Convert.ToDouble(Console.ReadLine());

                            if (atm.TransferMoney(money) == 1)
                                Console.WriteLine("转账成功！");
                            else
                                Console.WriteLine("你输入出错，最少面值100元！");
                        }
                        else
                            Console.WriteLine("账号输入错误！");

                        Console.ReadLine();
                    } break;

                case 4:
                    {
                        money = atm.RemainderMoney();
                        Console.WriteLine("余额为：{0}", money);
                        Console.ReadLine();
                    } break;

                case 5:
                    {
                        atm.ChangePassword();
                        Console.ReadLine();
                    } break;

                case 0: Environment.Exit(0); break;
            }
        }

        /// <summary>
        /// 菜单
        /// </summary>
        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t自动取款机");
            Console.WriteLine("\n----------------------------------");
            Console.WriteLine("\t 1.取款。。");
            Console.WriteLine("\t 2.存款。。");
            Console.WriteLine("\t 3.转帐。。");
            Console.WriteLine("\t 4.查询余额。。");
            Console.WriteLine("\t 5.更改密码。。");
            Console.WriteLine("\t 0.退出系统。。");
            Console.WriteLine("----------------------------------");
        }

    }
}





