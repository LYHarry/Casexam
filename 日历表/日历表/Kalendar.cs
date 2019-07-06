using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 日历表
{
    class Kalendar
    {
        private int _Year = 0;   //判断某年
        private int _Month = 0;   //判断某月
        private int _Day = 0;    //判断某月的天数
        private int _Week = 0;    //判断某月的第一天星期几
        private int _SumDay = 0;    //判断距离2000年1月1日一共有多少天

        public Kalendar(int year, int month)
        {
            this._Year = year;
            this._Month = month;
        }

        public Kalendar(int year)
        {
            this._Year = year;
        }

        /// <summary>
        /// 判断是否闰年
        /// </summary>
        /// <param name="year">判断某年是否为闰年</param>
        /// <returns></returns>
        private bool LeapYear(int year)
        {
            return (year % 4 == 0 && year % 100 != 0 || year % 400 == 0);
        }

        /// <summary>
        /// 计算某年共有多少天
        /// </summary>
        /// <param name="year">计算的年</param>
        /// <returns>返回的天数</returns>
        private int ComputeYear(int year)
        {
            if (LeapYear(year))
                return 366;
            else
                return 365;
        }

        /// <summary>
        /// 判断某年某月共有多少天
        /// </summary>
        /// <returns>返回天数</returns>
        private int ComputeDay(int month)
        {
            if (month == 2)
            {
                if (LeapYear(this._Year))
                    this._Day = 29;
                else
                    this._Day = 28;
            }
            else
            {
                if (month == 4 || month == 6 || month == 9 || month == 11)
                    this._Day = 30;
                else
                    this._Day = 31;
            }
            return this._Day;
        }

        /// <summary>
        /// 计算某月的一号是星期几
        /// </summary>
        /// <param name="month">计算的月份</param>
        /// <returns>返回该月一号是星期几</returns>
        private int ComputeWeek(int month)
        {
            this._SumDay = 0;
            this._Month = month;
            month = this._Year - 2000; //以2000年为基数计算

            if (month > 0)
            {
                for (int n = 2000; n < this._Year; n++)
                    this._SumDay = this._SumDay + ComputeYear(n);

                for (int i = 1; i < this._Month; i++)
                    this._SumDay = this._SumDay + ComputeDay(i);
            }
            else if (month == 0)
            {
                for (int i = 1; i < this._Month; i++)
                    this._SumDay = this._SumDay + ComputeDay(i);
            }
            else if (month < 0)
            {
                int sum = 0;
                for (int n = this._Year; n < 2000; n++)
                    this._SumDay = this._SumDay + ComputeYear(n);

                for (int i = 1; i < this._Month; i++)
                    sum = sum + ComputeDay(i);

                this._SumDay = -(this._SumDay - sum);
            }

            if (this._SumDay >= 0)
                this._Week = (this._SumDay - 1) % 7;
            else
            {
                this._Week = (-(this._SumDay - 1)) % 7;
                this._Week = 7 - this._Week;
            }

            return this._Week;
        }

        /// <summary>
        /// 打印指定月份的日历
        /// </summary>
        public void Print()
        {
            this._Week = ComputeWeek(this._Month);
            this._Day = ComputeDay(this._Month);
            WriteContent(0);
        }

        /// <summary>
        /// 打印全年日历
        /// </summary>
        public void PrintAllYear()
        {
            for (int i = 1; i < 13; i++)
            {
                this._Week = ComputeWeek(i);
                this._Day = ComputeDay(i);
                WriteContent(365);
            }
        }


        /// <summary>
        /// 输出日历
        /// </summary>
        /// <param name="month"></param>
        private void WriteContent(int month)
        {
            Console.WriteLine("======================");
            if (month == 365)
            { Console.WriteLine("====== {0}月 =====", this._Month); }

            Console.WriteLine("第一天是：星期{0}", GetUpperWeek(this._Week));
            Console.WriteLine("这月共有：{0}天", this._Day);
            Console.WriteLine("======================\n");
            Console.WriteLine("===================================================\n");
            Console.WriteLine("日\t一\t二\t三\t四\t五\t六\n");

            for (int i = 1; i <= this._Week; i++)
                Console.Write("\t ");

            for (int b = 1; b <= this._Day; b++)
            {
                Console.Write("{0}\t", b);
                if ((b + this._Week) % 7 == 0)
                    Console.WriteLine("\n");
            }
            Console.WriteLine("\n===================================================\n");
        }


        /// <summary>
        /// 得到大写的星期表示方式
        /// </summary>
        /// <param name="week"></param>
        /// <returns></returns>
        private string GetUpperWeek(int week)
        {
            string res = "";
            switch (week)
            {
                case 1: { res = "一"; } break;
                case 2: { res = "二"; } break;
                case 3: { res = "三"; } break;
                case 4: { res = "四"; } break;
                case 5: { res = "五"; } break;
                case 6: { res = "六"; } break;
                default: { res = "天"; } break;
            }
            return res;
        }

    }
}
