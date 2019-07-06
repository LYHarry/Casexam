using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace 进制转换
{
    /// <summary>
    /// 进制转换帮助类
    /// </summary>
    class NumberChange
    {
        /// <summary>
        /// 十进制转换为二进制
        /// </summary>
        /// <param name="num">要转换的十进制</param>
        /// <returns></returns>
        public string Base10To2(int num)
        {
            int i = 0; string data = "";
            int[] temp = new int[100];

            while (num > 0)
            {
                temp[i] = num % 2;
                num = num / 2;
                i++;
            }

            for (i = i - 1; i >= 0; i--)
                data = data + temp[i].ToString();

            return data;
        }

        /// <summary>
        /// 八进制转二进制
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        public string Base8To2(string course)
        {
            string data = "", str = ""; int num = 0;

            for (int i = 0; i < course.Length; i++)
            {
                num = Convert.ToInt32(course[i].ToString());
                if (num > 0)
                {
                    str = Base10To2(num);//把每一位除2取余
                }
                else
                { str = "0"; }

                //对每个二进制位不足3位时，最左位补零
                str = (str.Length == 1 ? ("00" + str) : (str.Length == 2 ? ("0" + str) : str));
                data += str;
            }
            data = FilterZero(data);
            return data;
        }

        /// <summary>
        /// 十六进制转二进制
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        public string Base16To2(string course)
        {
            string data = "", str = "", wei = ""; int num = 0;

            for (int i = 0; i < course.Length; i++)
            {
                wei = course[i].ToString().ToUpper();
                switch (wei)
                {
                    case "A": { num = 10; } break;
                    case "B": { num = 11; } break;
                    case "C": { num = 12; } break;
                    case "D": { num = 13; } break;
                    case "E": { num = 14; } break;
                    case "F": { num = 15; } break;
                    default: { num = Convert.ToInt32(wei); } break;
                }
                if (num > 0)
                {
                    str = Base10To2(num);//把每一位除2取余
                }
                else
                { str = "0"; }

                //对每个二进制位不足4位时，最左位补零
                str = (str.Length == 1 ? ("000" + str) : (str.Length == 2 ? ("00" + str) : (str.Length == 3 ? ("0" + str) : str)));
                data += str;
            }
            data = FilterZero(data);
            return data;
        }


        /// <summary>
        /// 十进制转换为八进制
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public string Base10To8(int num)
        {
            int i = 0; string data = "";
            int[] temp = new int[50];

            while (num > 0)
            {
                temp[i] = num % 8;
                num = num / 8;
                i++;
            }

            for (i = i - 1; i >= 0; i--)
                data = data + temp[i].ToString();

            return data;
        }

        /// <summary>
        /// 十进制转换为十六进制
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public string Base10To16(int num)
        {
            int i = 0, t = 0;
            string temp = "", data = "";

            while (num > 0)
            {
                t = num % 16;
                if (t < 10)
                    temp = temp + t.ToString();
                else
                {
                    switch (t)
                    {
                        case 10: temp = temp + "A"; break;
                        case 11: temp = temp + "B"; break;
                        case 12: temp = temp + "C"; break;
                        case 13: temp = temp + "D"; break;
                        case 14: temp = temp + "E"; break;
                        case 15: temp = temp + "F"; break;
                    }
                }

                num = num / 16;
                i++;
            }

            for (i = temp.Length - 1; i >= 0; i--)
                data = data + temp[i].ToString();

            return data;
        }

        /// <summary>
        /// 其他进制转换为十进制
        /// </summary>
        /// <param name="data">要转换的数</param>
        /// <param name="n">进制数</param>
        /// <returns></returns>
        public string OtherToInt10(string data, int n)
        {
            int wq = 1, s = 0, wei = 0;
            char c = ' ';

            for (int i = data.Length - 1; i >= 0; i--)
            {
                if (n == 16)
                {
                    c = data[i];
                    switch (c)
                    {
                        case 'A':
                        case 'a': wei = 10; break;
                        case 'B':
                        case 'b': wei = 11; break;
                        case 'C':
                        case 'c': wei = 12; break;
                        case 'D':
                        case 'd': wei = 13; break;
                        case 'E':
                        case 'e': wei = 14; break;
                        case 'F':
                        case 'f': wei = 15; break;
                        default: wei = Convert.ToInt32(c) - 48; break;
                    }
                }
                else
                    wei = Convert.ToInt32(data[i]) - 48;

                s = s + wei * wq;
                wq = wq * n;
            }

            return s.ToString();
        }

        /// <summary>
        /// 过滤结果中最前面的零
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        private string FilterZero(string course)
        {
            return Regex.Replace(course, "^0+", "");
        }

    }
}
