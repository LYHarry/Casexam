using System;
using System.Drawing;

namespace Grame
{
    /// <summary>
    /// 道具类
    /// </summary>
    public class Props
    {
        /// <summary>
        /// 道具的X轴坐标
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// 道具的Y轴坐标
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// 道具图片的宽度
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// 道具图片的高度
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// 窗体对象类
        /// </summary>
        public GrameConsole GC { get; set; }

        /// <summary>
        /// 道具飞行的速度
        /// </summary>
        public int Speed { get; set; }

        /// <summary>
        /// 道具飞行的方向
        /// </summary>
        public Direction Direction { get; set; }

        /// <summary>
        /// 道具的类型
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 道具的状态
        /// </summary>
        public bool Statue { get; set; }


        public Props(int x, int y, int width, int height, int speed, int type, Direction direction, bool statue, GrameConsole gc)
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
        /// 绘制道具
        /// </summary>
        /// <param name="g"></param>
        public void DrawMe(Graphics g)
        {
            if (!this.Statue)
            {
                this.GC.propList.Remove(this);
                return;
            }

            if (this.Type == 1)
            {
                g.DrawImage(GC.PropImg, this.X, this.Y, this.Width, this.Height);
            }
            else if (this.Type == 2)
            {
                g.DrawImage(GC.missileImg2, this.X, this.Y, this.Width, this.Height);
            }

            Move(); //调用道具移动的方法
        }

        /// <summary>
        /// 移动道具
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
            GetProps(); //获取道具
        }

        /// <summary>
        /// 获取道具对象的距形框
        /// </summary>
        /// <returns></returns>
        public Rectangle GetPropRectangle()
        {
            Rectangle rg = new Rectangle(this.X, this.Y, this.Width, this.Height);
            return rg;
        }

        /// <summary>
        /// 道具碰撞我军飞机
        /// </summary>
        public void GetProps()
        {
            if (this.Type == 1)  //判断道具的类型
            {
                if (GetPropRectangle().IntersectsWith(GC.myair.GetMyAirRectangle()))
                {
                    if (GC.myair.LifeNum < 100)
                    {
                        GC.myair.LifeNum += 5;  //我军飞机生命值加5
                        if (GC.myair.LifeNum >= 100)
                            GC.myair.LifeNum = 100;
                    }
                    GC.PlayAddLifeNum.PlayMusicThread();
                    this.Statue = false;  //清除道具对象
                }
            }
            else if (this.Type == 2)  //判断道具的类型
            {
                if (GetPropRectangle().IntersectsWith(GC.myair.GetMyAirRectangle()))
                {
                    GC.myair.MissileCount += 1;
                    GC.PlayAddLifeNum.PlayMusicThread();
                    this.Statue = false;  //清除道具对象
                }
            }


        }
    }
}
