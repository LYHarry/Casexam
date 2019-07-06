using System;
using System.Drawing;

namespace Grame
{
    /// <summary>
    /// 敌军飞机类
    /// </summary>
    public class EnemyAirPlane
    {
        /// <summary>
        /// 敌军飞机的X轴坐标
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// 敌军飞机的Y轴坐标
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// 飞机图片的宽度
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// 飞机图片的高度
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// 窗体对象类
        /// </summary>
        public GrameConsole GC { get; set; }

        /// <summary>
        /// 敌军移动的速度
        /// </summary>
        public int Speed { get; set; }

        /// <summary>
        /// 敌军飞机的类型
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 敌军的状态，是否在工作区或被击中
        /// </summary>
        public bool Statue { get; set; }

        /// <summary>
        /// 敌军飞机的方向
        /// </summary>
        public Direction Direction { get; set; }

        /// <summary>
        /// 敌军飞机类
        /// </summary>
        /// <param name="x">敌军飞机的X轴坐标</param>
        /// <param name="y">敌军飞机的Y轴坐标</param>
        /// <param name="width">飞机图片的宽度</param>
        /// <param name="height">飞机图片的高度</param>
        /// <param name="speed">敌机飞行的速度</param>
        /// <param name="direction">敌机飞行的方向</param>
        /// <param name="type">敌机的类型</param>
        /// <param name="statue">敌机的状态</param>
        /// <param name="gc">窗体对象类</param>
        public EnemyAirPlane(int x, int y, int width, int height, int speed, Direction direction, int type, bool statue, GrameConsole gc)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.GC = gc;
            this.Type = type;
            this.Direction = direction;
            this.Statue = statue;
            this.Speed = speed;
        }

        /// <summary>
        /// 绘制敌军飞机
        /// </summary>
        /// <param name="g"></param>
        public void DrawMe(Graphics g)
        {
            //判断敌机的状态，是否在工作区，如果是false，就从列表中将此对象移除
            if (!this.Statue)
            {
                this.GC.EnemyAirList.Remove(this);
                return;
            }
            //判断飞机的类型，绘制不同类型的飞机
            if (this.Type == 1)
            {
                g.DrawImage(GC.EnemyAirPlaneImg1, this.X, this.Y, this.Width, this.Height);
            }
            else if (this.Type == 2)
            {
                g.DrawImage(GC.EnemyAirPlaneImg2, this.X, this.Y, this.Width, this.Height);
            }
            Move();  //调用敌军飞机移动的方法           
        }

        /// <summary>
        /// 移动事件
        /// </summary>
        public void Move()
        {
            this.X -= this.Speed;
            if (this.X < -this.Width)
            {
                this.Statue = false;
            }

            AirPlaneBump();  //调用飞机碰撞方法
            Fire();  //调用敌军开火的方法
        }

        /// <summary>
        /// 获取敌军飞机对象的距形框
        /// </summary>
        /// <returns></returns>
        public Rectangle GetEnemyRectangle()
        {
            Rectangle rg = new Rectangle(this.X, this.Y, this.Width, this.Height);
            return rg;
        }

        /// <summary>
        /// 敌军碰撞我军飞机
        /// </summary>
        public void AirPlaneBump()
        {
            //调用矩形对象的方法IntersectsWith，判断两个矩形是否相交
            bool flag = GetEnemyRectangle().IntersectsWith(GC.myair.GetMyAirRectangle());
            if (flag)
            {
                GC.explode = new Explode(this.X, this.Y, 30, 30, 1, this.GC, true);
                this.Statue = false;

                //我军飞机生命值减5
                GC.myair.LifeNum -= 5;
                GC.myair.Score += 2;  //我军得到分数
                if (GC.myair.LifeNum <= 0)
                {
                    GC.explode = new Explode(GC.myair.X, GC.myair.Y, 80, 80, 2, this.GC, true);
                    GC.grameState = GrameStatue.Fail;
                    GC.myair.Statue = false;
                }
            }
        }

        /// <summary>
        /// 敌军开火的方法，产生子弹对象
        /// </summary>
        public void Fire()
        {
            if (GC.r.Next(200) % 10 == 0)
            {
                GC.bulletList.Add(new Bullet(this.X, this.Y + (this.Height / 2), 8, 8, 20, 2, Direction.Left, true, this.GC));
                //GC.EnemyPlayMusic.PlayMusicThread();  //敌机发子弹，播放音乐
            }
        }
    }
}
