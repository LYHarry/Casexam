using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Grame
{
    /// <summary>
    /// Boss类
    /// </summary>
    public class Boss
    {
        /// <summary>
        /// Boss的X轴坐标
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Boss的Y轴坐标
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Boss图片的宽度
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Boss图片的高度
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// 窗体对象类
        /// </summary>
        public GrameConsole GC { get; set; }

        /// <summary>
        /// Boss飞行的速度
        /// </summary>
        public int Speed { get; set; }

        /// <summary>
        /// Boss飞行的方向
        /// </summary>
        public Direction Direction { get; set; }

        /// <summary>
        /// Boss的生命值
        /// </summary>
        public int LifeNum { get; set; }

        /// <summary>
        /// Boss的状态
        /// </summary>
        public bool Statue { get; set; }

        /// <summary>
        /// Boss类
        /// </summary>
        /// <param name="x">Boss的X轴坐标</param>
        /// <param name="y">Boss的Y轴坐标</param>
        /// <param name="width">Boss飞机图片宽度</param>
        /// <param name="height">Boss飞机图片高度</param>
        /// <param name="speed">Boss飞机飞行的速度</param>
        /// <param name="lifeNum">Boss飞机的生命值</param>
        /// <param name="direction">Boss飞机飞行的方向</param>
        /// <param name="statue">Boss飞机状态</param>
        /// <param name="gc">窗体对象类</param>
        public Boss(int x, int y, int width, int height, int speed, int lifeNum, Direction direction, bool statue, GrameConsole gc)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.Speed = speed;
            this.Direction = direction;
            this.Statue = statue;
            this.GC = gc;
            this.LifeNum = lifeNum;
        }

        /// <summary>
        /// 绘制Boss飞机
        /// </summary>
        /// <param name="g"></param>
        public void DrawMe(Graphics g)
        {
            if (!this.Statue)
            {
                return;
            }
            g.DrawImage(GC.BossImg, this.X, this.Y, this.Width, this.Height);

            Move(); //调用Boss移动的方法
        }

        /// <summary>
        /// 移动Boss飞机
        /// </summary>
        private void Move()
        {
            if (GC.r.Next(100) % 20 == 0)
            {
                SetDirection();  //调用设置Boss飞行方向的方法
            }

            switch (this.Direction)
            {
                case Direction.Up:
                    this.Y -= this.Speed;
                    if (this.Y < 10)
                        this.Y = 10;
                    break;
                case Direction.Down:
                    this.Y += this.Speed;
                    if (this.Y > 550 - this.Height)
                        this.Y = 550 - this.Height;
                    break;
                case Direction.Left:
                    this.X -= this.Speed;
                    if (this.X < 300)
                        this.X = 300;
                    break;
                case Direction.Right:
                    this.X += this.Speed;
                    if (this.X > 800 - this.Width)
                        this.X = 800 - this.Width;
                    break;
                case Direction.UpLeft:
                    this.Y -= this.Speed;
                    this.X -= this.Speed;
                    if (this.Y < 0)
                        this.Y = 0;
                    if (this.X < 300)
                        this.X = 300;
                    break;
                case Direction.UpRight:
                    this.Y -= this.Speed;
                    this.X += this.Speed;
                    if (this.Y < 0)
                        this.Y = 0;
                    if (this.X > 800 - this.Width)
                        this.X = 800 - this.Width;
                    break;
                case Direction.DownLeft:
                    this.Y += this.Speed;
                    this.X -= this.Speed;
                    if (this.Y > 480 - this.Height)
                        this.Y = 480 - this.Height;
                    if (this.X < 300)
                        this.X = 300;
                    break;
                case Direction.DownRight:
                    this.Y += this.Speed;
                    this.X += this.Speed;
                    if (this.Y > 480 - this.Height)
                        this.Y = 480 - this.Height;
                    if (this.X > 800 - this.Width)
                        this.X = 800 - this.Width;
                    break;
                case Direction.Stop:
                    break;
            }

            BulletHitAir(); //判断是否击中飞机
            Fire();  //调用Boss飞机开火的方法
        }

        /// <summary>
        /// 设置Boss飞行的方向
        /// </summary>
        private void SetDirection()
        {
            switch (GC.r.Next(9))
            {
                case 0: this.Direction = Direction.Stop;
                    break;
                case 1: this.Direction = Direction.Up;
                    break;
                case 2: this.Direction = Direction.Down;
                    break;
                case 3: this.Direction = Direction.Left;
                    break;
                case 4: this.Direction = Direction.Right;
                    break;
                case 5: this.Direction = Direction.UpLeft;
                    break;
                case 6: this.Direction = Direction.UpRight;
                    break;
                case 7: this.Direction = Direction.DownLeft;
                    break;
                case 8: this.Direction = Direction.DownRight;
                    break;
            }
        }

        /// <summary>
        /// 获取Boss飞机对象的距形框
        /// </summary>
        /// <returns></returns>
        public Rectangle GetBossRectangle()
        {
            Rectangle rg = new Rectangle(this.X, this.Y, this.Width, this.Height);
            return rg;
        }

        /// <summary>
        /// 我军子弹碰撞Boss飞机
        /// </summary>
        private void BulletHitAir()
        {
            for (int i = 0; i < GC.bulletList.Count; i++)
            {
                if (GC.bulletList[i].Type == 1)  //我军子弹
                {
                    if (GetBossRectangle().IntersectsWith(GC.bulletList[i].GetBulletRectangle()))
                    {
                        this.LifeNum -= 2;  //Boss的生命值减2
                        GC.myair.Score += 5;
                        GC.bulletList[i].Statue = false;  //清除子弹对象
                        if (this.LifeNum <= 0)
                        {
                            GC.explode = new Explode(this.X, this.Y, 30, 30, 1, this.GC, true);
                            GC.PlayExplode.PlayMusicThread();  //播放爆炸的音乐
                            GC.grameState = GrameStatue.Success;
                            this.Statue = false;  //表示Boss被消灭
                        }
                    }
                }
                else if (GC.bulletList[i].Type == 3)  //Boss飞机子弹
                {
                    if (GC.bulletList[i].GetBulletRectangle().IntersectsWith(GC.myair.GetMyAirRectangle()))
                    {
                        GC.myair.LifeNum -= 10;  //我军飞机生命值减10
                        GC.bulletList[i].Statue = false;  //清除子弹对象
                        if (GC.myair.LifeNum <= 0)
                        {
                            GC.explode = new Explode(this.X, this.Y, 30, 30, 1, this.GC, true);
                            GC.PlayMyExplode.PlayMusicThread(); //播放我军飞机爆炸音乐
                            GC.myair.Statue = false;  //表示我军飞机被消灭
                            GC.grameState = GrameStatue.Fail;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Boss飞机开火的方法，产生子弹对象
        /// </summary>
        private void Fire()
        {
            if (GC.r.Next(300) % 10 == 0)
            {
                GC.bulletList.Add(new Bullet(this.X, this.Y + (this.Height / 2), 15, 15, 20, 3, Direction.Left, true, this.GC));
                GC.bulletList.Add(new Bullet(this.X, this.Y + (this.Height / 2), 15, 15, 20, 3, Direction.UpLeft, true, this.GC));
                GC.bulletList.Add(new Bullet(this.X, this.Y + (this.Height / 2), 15, 15, 20, 3, Direction.DownLeft, true, this.GC));
            }
        }
    }

}
