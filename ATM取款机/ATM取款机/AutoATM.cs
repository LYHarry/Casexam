using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATM取款机
{
    /// <summary>
    /// ATM取款机
    /// </summary>
    class AutoATM
    {
        private string name;    //卡号                
        private int password;  //密码
        private double ResidueMoney;     //卡号余额
        private double ResidueMoneyATM;   //取款机余额

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">卡号</param>
        /// <param name="password">密码</param>
        /// <param name="ResidueMoney">卡号余额</param>
        public AutoATM(string name, int password, Double ResidueMoney)
        {
            this.name = name;
            this.password = password;
            this.ResidueMoney = ResidueMoney;
            this.ResidueMoneyATM = 10000;
        }

        /// <summary>
        /// 得到卡号
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return this.name;
        }

        /// <summary>
        /// 得到密码
        /// </summary>
        /// <returns></returns>
        public int GetPassWord()
        {
            return this.password;
        }

        /// <summary>
        /// 取款
        /// </summary>
        /// <param name="money">要取多少钱</param>
        /// <returns>返回取款金额</returns>
        public int GetMoney(double money)
        {
            int f = 1; //判断是否为100元的钱币

            if (money % 100 == 0)
            {
                if (money > ResidueMoney)
                    Console.WriteLine("卡上余额不足！");
                else if (money > ResidueMoneyATM)
                    Console.WriteLine("取款机余额不足！");
                else
                {
                    ResidueMoney = ResidueMoney - money;
                    ResidueMoneyATM = ResidueMoneyATM - money;
                }
            }
            else
                f = 0;

            return f;
        }

        /// <summary>
        /// 存款
        /// </summary>
        /// <param name="money">存款金额</param>
        public int SavaMoney(double money)
        {
            int f = 1; //判断是否为100元的钱币

            if (money % 100 == 0)
            {
                ResidueMoney = ResidueMoney + money;
                ResidueMoneyATM = ResidueMoneyATM + money;
            }
            else
                f = 0;

            return f;
        }

        /// <summary>
        /// 查询余额
        /// </summary>
        /// <returns>返回余额金额</returns>
        public double RemainderMoney()
        {
            return ResidueMoney;
        }

        /// <summary>
        /// 转帐
        /// </summary>
        /// <param name="money">转帐金额</param>
        /// <returns>判断是否输入正确</returns>
        public int TransferMoney(double money)
        {
            int f = 1;  //判断是否为100元的钱币

            if (money % 100 == 0)
            {
                if (money > ResidueMoney)
                    Console.WriteLine("卡上余额不足！");
                else if (money > ResidueMoneyATM)
                    Console.WriteLine("取款机余额不足！");
                else
                {
                    ResidueMoney = ResidueMoney - money;
                    ResidueMoneyATM = ResidueMoneyATM - money;
                }
            }
            else
                f = 0;

            return f;
        }

        /// <summary>
        /// 更改密码
        /// </summary>
        public void ChangePassword()
        {
            Console.Write("请输入新密码：");
            int ps = Convert.ToInt32(Console.ReadLine());

            Console.Write("请再次输入新密码：");
            int ps1 = Convert.ToInt32(Console.ReadLine());

            if (ps == ps1)
            {
                this.password = ps;
                Console.WriteLine("密码更改成功！");

            }
            else
                Console.WriteLine("输入错误！");
        }





    }
}
