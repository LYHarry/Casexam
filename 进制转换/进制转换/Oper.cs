using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace 进制转换
{
    /// <summary>
    /// 操作类
    /// </summary>
    class Oper
    {
        private char choice;
        private int choose = 0;
        private string toNumBer = "", result = "";
        private NumberChange numConvert = new NumberChange();


        /// <summary>
        /// 二进制转换
        /// </summary>
        private void Converto2()
        {
            do
            {
                Console.WriteLine("=============二进制转换==============");
                Console.WriteLine("   1、十进制转换为二进制");
                Console.WriteLine("   2、八进制转换为二进制");
                Console.WriteLine("   3、十六进制转换为二进制");
                Console.WriteLine("=====================================");
                Console.Write(">> ");

                choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        {
                            do
                            {
                                Console.Write("请输入转换的十进制：");
                                toNumBer = Console.ReadLine();
                            } while (!Regex.IsMatch(toNumBer, @"\d+"));

                            //十进制转换为二进制
                            result = numConvert.Base10To2(Convert.ToInt32(toNumBer));
                            Console.WriteLine("二进制：{0}", result);
                        } break;

                    case 2:
                        {
                            do
                            {
                                Console.Write("请输入转换的八进制：");
                                toNumBer = Console.ReadLine();
                            } while (!Regex.IsMatch(toNumBer, @"^[0-7]+$"));

                            //八进制转换为二进制
                            result = numConvert.Base8To2(toNumBer);
                            Console.WriteLine("二进制：{0}", result);

                        } break;

                    case 3:
                        {
                            do
                            {
                                Console.Write("请输入转换的十六进制：");
                                toNumBer = Console.ReadLine();
                            } while (!Regex.IsMatch(toNumBer, @"^[0-9A-F]+$", RegexOptions.IgnoreCase));

                            //十六进制转换为二进制                               
                            result = numConvert.Base16To2(toNumBer);
                            Console.WriteLine("二进制：{0}", result);
                        } break;
                }
                Console.WriteLine("\t\n你还想要继续计算吗？(y/n),按 A/a 返回主菜单。。");
                Console.Write(">> ");
                choice = Convert.ToChar(Console.ReadLine());
                if (choice == 'A' || choice == 'a')
                {
                    MainMenu();
                }
            }
            while (choice == 'y');
        }

        /// <summary>
        /// 八进制转换
        /// </summary>
        private void Converto8()
        {
            do
            {
                Console.WriteLine("=============八进制转换==============");
                Console.WriteLine("   1、十进制转换为八进制");
                Console.WriteLine("   2、二进制转换为八进制");
                Console.WriteLine("   3、十六进制转换为八进制");
                Console.WriteLine("=====================================");
                Console.Write(">> ");

                choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        {
                            do
                            {
                                Console.Write("请输入转换的十进制：");
                                toNumBer = Console.ReadLine();
                            } while (!Regex.IsMatch(toNumBer, @"\d+"));

                            //十进制转换为八进制
                            result = numConvert.Base10To8(Convert.ToInt32(toNumBer));
                            Console.WriteLine("八进制：{0}", result);
                        } break;

                    case 2:
                        {
                            do
                            {
                                Console.Write("请输入转换的二进制：");
                                toNumBer = Console.ReadLine();
                            } while (!Regex.IsMatch(toNumBer, @"^[0-1]+$"));

                            //二进制转换为十进制
                            result = numConvert.OtherToInt10(toNumBer, 2);
                            //十进制转换为八进制
                            result = numConvert.Base10To8(Convert.ToInt32(result));
                            Console.WriteLine("八进制：{0}", result);

                        } break;

                    case 3:
                        {
                            do
                            {
                                Console.Write("请输入转换的十六进制：");
                                toNumBer = Console.ReadLine();
                            } while (!Regex.IsMatch(toNumBer, @"^[0-9A-F]+$", RegexOptions.IgnoreCase));

                            //十六进制转换为十进制
                            result = numConvert.OtherToInt10(toNumBer, 16);
                            //十进制转换为八进制
                            result = numConvert.Base10To8(Convert.ToInt32(result));
                            Console.WriteLine("八进制：{0}", result);
                        } break;
                }
                Console.WriteLine("\t\n你还想要继续计算吗？(y/n),按 A/a 返回主菜单。。");
                Console.Write(">> ");
                choice = Convert.ToChar(Console.ReadLine());
                if (choice == 'A' || choice == 'a')
                {
                    MainMenu();
                }
            }
            while (choice == 'y');
        }

        /// <summary>
        /// 转换为十进制
        /// </summary>
        private void Converto10()
        {
            do
            {
                Console.WriteLine("=============十进制转换==============");
                Console.WriteLine("   1、二进制转换为十进制");
                Console.WriteLine("   2、八进制转换为十进制");
                Console.WriteLine("   3、十六进制转换为十进制");
                Console.WriteLine("=====================================");
                Console.Write(">> ");

                choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        {
                            do
                            {
                                Console.Write("请输入转换的二进制：");
                                toNumBer = Console.ReadLine();
                            } while (!Regex.IsMatch(toNumBer, @"^[0-1]+$"));

                            //二进制转换为十进制
                            result = numConvert.OtherToInt10(toNumBer, 2);
                            Console.WriteLine("十进制：{0}", result);
                        } break;

                    case 2:
                        {
                            do
                            {
                                Console.Write("请输入转换的八进制：");
                                toNumBer = Console.ReadLine();
                            } while (!Regex.IsMatch(toNumBer, @"^[0-7]+$"));

                            //八进制转换为十进制
                            result = numConvert.OtherToInt10(toNumBer, 8);
                            Console.WriteLine("十进制：{0}", result);
                        } break;

                    case 3:
                        {
                            do
                            {
                                Console.Write("请输入转换的十六进制：");
                                toNumBer = Console.ReadLine();
                            } while (!Regex.IsMatch(toNumBer, @"^[0-9A-F]+$", RegexOptions.IgnoreCase));

                            //十六进制转换为十进制
                            result = numConvert.OtherToInt10(toNumBer, 16);
                            Console.WriteLine("十进制：{0}", result);
                        } break;
                }
                Console.WriteLine("\t\n你还想要继续计算吗？(y/n),按 A/a 返回主菜单。。");
                Console.Write(">> ");
                choice = Convert.ToChar(Console.ReadLine());
                if (choice == 'A' || choice == 'a')
                {
                    MainMenu();
                }
            }
            while (choice == 'y');
        }

        /// <summary>
        /// 转换为十六进制
        /// </summary>
        private void Converto16()
        {
            do
            {
                Console.WriteLine("=============十六进制转换==============");
                Console.WriteLine("   1、二进制转换为十六进制");
                Console.WriteLine("   2、八进制转换为十六进制");
                Console.WriteLine("   3、十进制转换为十六进制");
                Console.WriteLine("=====================================");
                Console.Write(">> ");

                choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        {
                            do
                            {
                                Console.Write("请输入转换的二进制：");
                                toNumBer = Console.ReadLine();
                            } while (!Regex.IsMatch(toNumBer, @"^[0-1]+$"));

                            //二进制转换为十进制
                            result = numConvert.OtherToInt10(toNumBer, 2);
                            //十进制转换为十六进制
                            result = numConvert.Base10To16(Convert.ToInt32(result));

                            Console.WriteLine("十六进制：{0}", result);
                        } break;

                    case 2:
                        {
                            do
                            {
                                Console.Write("请输入转换的八进制：");
                                toNumBer = Console.ReadLine();
                            } while (!Regex.IsMatch(toNumBer, @"^[0-7]+$"));

                            //八进制转换为十进制
                            result = numConvert.OtherToInt10(toNumBer, 8);
                            //十进制转换为十六进制
                            result = numConvert.Base10To16(Convert.ToInt32(result));
                            Console.WriteLine("十六进制：{0}", result);
                        } break;

                    case 3:
                        {
                            do
                            {
                                Console.Write("请输入转换的十进制：");
                                toNumBer = Console.ReadLine();
                            } while (!Regex.IsMatch(toNumBer, @"^[0-9A-F]+$", RegexOptions.IgnoreCase));

                            //十进制转换为十六进制
                            result = numConvert.Base10To16(Convert.ToInt32(toNumBer));
                            Console.WriteLine("十六进制：{0}", result);
                        } break;
                }
                Console.WriteLine("\t\n你还想要继续计算吗？(y/n),按 A/a 返回主菜单。。");
                Console.Write(">> ");
                choice = Convert.ToChar(Console.ReadLine());
                if (choice == 'A' || choice == 'a')
                {
                    MainMenu();
                }
            }
            while (choice == 'y');
        }

        /// <summary>
        /// 主菜单
        /// </summary>
        private void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("==============进制转换===============");
            Console.WriteLine("   1、转换为二进制");
            Console.WriteLine("   2、转换为八进制");
            Console.WriteLine("   3、转换为十进制");
            Console.WriteLine("   4、转换为十六进制");
            Console.WriteLine("======================================");
            Console.Write(">> ");
        }

        /// <summary>
        /// 开始操作
        /// </summary>
        public void StartOper()
        {
            MainMenu(); //主菜单
            int type = Convert.ToInt32(Console.ReadLine());
            switch (type)
            {
                case 1:
                    {
                        Converto2(); //二进制转换
                    } break;
                case 2:
                    {
                        Converto8();//八进制转换
                    } break;
                case 3:
                    {
                        Converto10();//十进制转换
                    } break;
                case 4:
                    {
                        Converto16();//十六进制转换
                    } break;
                default:
                    {
                        MainMenu(); //主菜单
                    } break;
            }
        }

    }
}
