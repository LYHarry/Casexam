using System;
using System.Drawing;

namespace Grame
{
    /// <summary>
    /// 导弹类
    /// </summary>
    public class Missile
    {
        /// <summary>
        /// 导弹的X轴坐标
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// 导弹的Y轴坐标
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// 导弹图片的宽度
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// 导弹图片的高度
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// 窗体对象类
        /// </summary>
        public GrameConsole GC { get; set; }

        /// <summary>
        /// 导弹飞行的速度
        /// </summary>
        public int Speed { get; set; }

        /// <summary>
        /// 导弹飞行的方向
        /// </summary>
        public Direction Direction { get; set; }

        /// <summary>
        /// 导弹的类型，是否为道具导弹
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 导弹的状态
        /// </summary>
        public bool Statue { get; set; }

        private int Index { get; set; }

        /// <summary>
        /// 导弹类
        /// </summary>
        /// <param name="x">导弹的X轴坐标</param>
        /// <param name="y">导弹的Y轴坐标</param>
        /// <param name="width">导弹图片的宽度</param>
        /// <param name="height">导弹图片的高度</param>
        /// <param name="speed">导弹的速度</param>
        /// <param name="type">导弹的类型</param>
        /// <param name="direction">导弹的方向</param>
        /// <param name="statue">导弹的状态</param>
        /// <param name="gc">窗体对象类</param>
        public Missile(int x, int y, int width, int height, int speed, int type, Direction direction, bool statue, GrameConsole gc)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.Speed = speed;
            this.Direction = direction;
            this.Type = type;
            this.GC = gc;
            this.Statue = statue;
        }

        /// <summary>
        /// 绘制导弹
        /// </summary>
        /// <param name="g"></param>
        public void DrawMe(Graphics g)
        {
            if (!this.Statue)
            {
                this.GC.missileList.Remove(this);
                return;
            }
            if (this.Type == 1)  //我军发的普通导弹
            {
                g.DrawImage(GC.missileImg1, this.X, this.Y, this.Width, this.Height);
            }
            else if (this.Type == 2)   //道具导弹
            {
                g.DrawImage(GC.missileImg2, this.X, this.Y, this.Width, this.Height);
            }

            Move(); //调用导弹移动的方法
        }

        /// <summary>
        /// 移动导弹
        /// </summary>
        public void Move()
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
        /// 获取导弹对象的距形框
        /// </summary>
        /// <returns></returns>
        public Rectangle GetMissileRectangle()
        {
            Rectangle rg = new Rectangle(this.X, this.Y, this.Width, this.Height);
            return rg;
        }

        /// <summary>
        /// 导弹弹碰撞敌军飞机
        /// </summary>
        public void BulletHitAir()
        {
            //判断敌机列表中的每个敌机是否碰撞当前导弹
            for (int i = 0; i < GC.EnemyAirList.Count; i++)
            {
                if (GetMissileRectangle().IntersectsWith(GC.EnemyAirList[i].GetEnemyRectangle()))
                {
                    GC.explode = new Explode(GC.EnemyAirList[i].X, GC.EnemyAirList[i].Y, 30, 30, 1, this.GC, true);
                    GC.PlayExplode.PlayMusicThread();  //播放爆炸的音乐
                    GC.EnemyAirList[i].Statue = false;  //把敌机状态设为false 表示被击中
                    GC.myair.Score += 5;
                    this.Statue = false;   //销毁子弹对象
                }
            }

            if (this.Type == 1)
            {
                //判断是否为Boss飞机对象
                if (GC.boss != null)
                {
                    if (GetMissileRectangle().IntersectsWith(GC.boss.GetBossRectangle()))
                    {
                        GC.boss.LifeNum -= 8;
                        GC.myair.Score += 10;

                        if (GC.boss.LifeNum <= 0)
                        {
                            GC.explode = new Explode(GC.boss.X, GC.boss.Y, 30, 30, 1, this.GC, true);
                            GC.PlayExplode.PlayMusicThread();  //播放爆炸的音乐
                            GC.grameState = GrameStatue.Success;
                            GC.boss.Statue = false;  //清除Boss飞机对象
                        }
                        this.Statue = false;   //销毁子弹对象                      
                    }
                }
            }
            else if (this.Type == 2)
            {
                //判断是否为Boss飞机对象
                if (GC.boss != null)
                {
                    if (GetMissileRectangle().IntersectsWith(GC.boss.GetBossRectangle()))
                    {
                        GC.boss.LifeNum -= 10;
                        GC.myair.Score += 10;

                        if (GC.boss.LifeNum <= 0)
                        {
                            GC.explode = new Explode(GC.boss.X, GC.boss.Y, 30, 30, 1, this.GC, true);
                            GC.PlayExplode.PlayMusicThread();  //播放爆炸的音乐
                            GC.grameState = GrameStatue.Success;
                            GC.boss.Statue = false;  //清除Boss飞机对象
                        }
                        this.Statue = false;   //销毁子弹对象
                    }
                }
            }
        }
    }
}
