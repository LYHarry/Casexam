using System;
using System.Drawing;

namespace Grame
{
    /// <summary>
    /// 子弹类
    /// </summary>
    public class Bullet
    {
        /// <summary>
        /// 子弹的X轴坐标
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// 子弹的Y轴坐标
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// 子弹图片的宽度
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// 子弹图片的高度
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// 窗体对象类
        /// </summary>
        public GrameConsole GC { get; set; }

        /// <summary>
        /// 子弹飞行的速度
        /// </summary>
        public int Speed { get; set; }

        /// <summary>
        /// 子弹飞行的方向
        /// </summary>
        public Direction Direction { get; set; }

        /// <summary>
        /// 子弹的类型
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 子弹的状态
        /// </summary>
        public bool Statue { get; set; }

        /// <summary>
        /// 子弹类
        /// </summary>
        /// <param name="x">子弹的X轴坐标</param>
        /// <param name="y">子弹的Y轴坐标</param>
        /// <param name="width">子弹的宽度</param>
        /// <param name="height">子弹的高度</param>
        /// <param name="speed">子弹的速度</param>
        /// <param name="type">子弹的类型</param>
        /// <param name="direction">子弹的飞行的方向</param>
        /// <param name="statue">子弹的状态</param>
        /// <param name="gc">窗体对象类</param>
        public Bullet(int x, int y, int width, int height, int speed, int type, Direction direction, bool statue, GrameConsole gc)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.Speed = speed;
            this.Type = type;
            this.Direction = direction;
            this.Statue = statue;
            this.GC = gc;
        }

        /// <summary>
        /// 绘制子弹
        /// </summary>
        /// <param name="g"></param>
        public void DrawMe(Graphics g)
        {
            if (!this.Statue)
            {
                this.GC.bulletList.Remove(this);
                return;
            }

            if (this.Type == 1)  //我军子弹
            {
                g.DrawImage(GC.BulletImg1, this.X, this.Y, this.Width, this.Height);
            }
            else if (this.Type == 2)   //敌军子弹
            {
                g.DrawImage(GC.BulletImg2, this.X, this.Y, this.Width, this.Height);
            }
            else if (this.Type == 3)   //Boss飞机子弹
            {
                g.DrawImage(GC.bossBulletImg, this.X, this.Y, this.Width, this.Height);
            }

            Move(); //调用子弹移动的方法
        }

        /// <summary>
        /// 移动子弹
        /// </summary>
        private void Move()
        {
            switch (this.Direction)
            {
                case Direction.Up:
                    this.Y -= this.Speed;
                    if (this.Y <= -this.Height)
                        this.Statue = false;
                    break;
                case Direction.Down:
                    this.Y += this.Speed;
                    if (this.Y >= this.Height + 600)
                        this.Statue = false;
                    break;
                case Direction.Left:
                    this.X -= this.Speed;
                    if (this.X <= -this.Width)
                        this.Statue = false;
                    break;
                case Direction.Right:
                    this.X += this.Speed;
                    if (this.X >= 1000 + this.Width)
                        this.Statue = false;
                    break;
                case Direction.UpLeft:
                    this.Y -= this.Speed;
                    this.X -= this.Speed;
                    if (this.Y <= -this.Height || this.X <= -this.Width)
                        this.Statue = false;
                    break;
                case Direction.UpRight:
                    this.Y -= this.Speed;
                    this.X += this.Speed;
                    if (this.Y <= -this.Height || this.X >= 1000 + this.Width)
                        this.Statue = false;
                    break;
                case Direction.DownLeft:
                    this.Y += this.Speed;
                    this.X -= this.Speed;
                    if (this.Y >= 600 + this.Height || this.X <= -this.Width)
                        this.Statue = false;
                    break;
                case Direction.DownRight:
                    this.Y += this.Speed;
                    this.X += this.Speed;
                    if (this.Y >= 600 + this.Height || this.X >= 1000 + this.Height)
                        this.Statue = false;
                    break;
                case Direction.Stop:
                    break;
            }
            BulletHitAir(); //判断是否击中飞机
        }

        /// <summary>
        /// 获取我军飞机对象的距形框
        /// </summary>
        /// <returns></returns>
        public Rectangle GetBulletRectangle()
        {
            Rectangle rg = new Rectangle(this.X, this.Y, this.Width, this.Height);
            return rg;
        }

        /// <summary>
        /// 子弹碰撞敌军飞机
        /// </summary>
        private void BulletHitAir()
        {
            if (this.Type == 1)  //我军子弹
            {
                //判断敌机列表中的每个敌机是否碰撞当前子弹
                for (int i = 0; i < GC.EnemyAirList.Count; i++)
                {
                    if (GetBulletRectangle().IntersectsWith(GC.EnemyAirList[i].GetEnemyRectangle()))
                    {
                        GC.explode = new Explode(GC.EnemyAirList[i].X, GC.EnemyAirList[i].Y, 30, 30, 1, this.GC, true);
                        GC.PlayExplode.PlayMusicThread();  //播放爆炸的音乐
                        GC.EnemyAirList[i].Statue = false;  //把敌机状态设为false 表示被击中
                        this.Statue = false;   //销毁子弹对象
                        GC.myair.Score += 5;  //我军飞机得到分数
                    }
                }
            }
            else if (this.Type == 2)   //敌军子弹
            {
                //判断敌机列表中的每个子弹是否碰撞我军飞机
                if (GetBulletRectangle().IntersectsWith(GC.myair.GetMyAirRectangle()))
                {
                    GC.explode = new Explode(this.X, this.Y, 30, 30, 1, this.GC, true);
                    GC.myair.LifeNum -= 2;  //当子弹碰撞到我军飞机，我军飞机生命值减2                   
                    this.Statue = false;   //销毁子弹对象
                    if (GC.myair.LifeNum <= 0)
                    {
                        GC.explode = new Explode(GC.myair.X, GC.myair.Y, 80, 80, 2, this.GC, true);
                        GC.PlayExplode.PlayMusicThread();  //播放爆炸的音乐
                        GC.grameState = GrameStatue.Fail;
                        GC.myair.Statue = false;
                    }
                }
            }
        }
    }
}
