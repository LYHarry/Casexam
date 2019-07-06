using System;
using System.Drawing;
using System.Windows.Forms;

namespace Grame
{
    /// <summary>
    /// 我军的飞机类
    /// </summary>
    public class MyAirPlane
    {
        /// <summary>
        /// 我军飞机的X轴坐标
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// 我军飞机的Y轴坐标
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
        /// 飞机飞行的速度
        /// </summary>
        public int Speed { get; set; }

        /// <summary>
        /// 飞机飞行的方向
        /// </summary>
        public Direction Direction { get; set; }

        /// <summary>
        /// 我军飞机的生命值
        /// </summary>
        public int LifeNum { get; set; }

        /// <summary>
        /// 我军飞机的状态，是否还活着
        /// </summary>
        public bool Statue { get; set; }

        /// <summary>
        /// 键盘的上、下、左、右键
        /// </summary>
        private bool keyUp, keyDown, keyRight, keyLeft;

        private bool isFire;  //能否开火

        private bool MissileIsFire;  //道具导弹能否开火

        /// <summary>
        /// 我军导弹的数量
        /// </summary>
        public int MissileCount { get; set; }

        /// <summary>
        /// 我军飞机得到的分数
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// 我军飞机类
        /// </summary>
        /// <param name="x">我军飞机的X轴坐标</param>
        /// <param name="y">我军飞机的Y轴坐标</param>
        /// <param name="width">飞机图片的宽度</param>
        /// <param name="height">飞机图片的高度</param>
        /// <param name="speed">飞机运行的速度</param>
        /// <param name="direction">飞机运行的方向</param>
        /// <param name="gc">窗体对象类</param>
        public MyAirPlane(int x, int y, int width, int height, int speed, int lifeNum, bool statue, Direction direction, GrameConsole gc)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.GC = gc;
            this.Direction = direction;
            this.Speed = speed;
            this.LifeNum = lifeNum;
            this.Statue = statue;
            this.isFire = true;
            this.Score = 0;
            this.MissileCount = 0;
            this.MissileIsFire = false;
        }

        /// <summary>
        /// 绘制我军飞机
        /// </summary>
        /// <param name="g"></param>
        public void DrawMe(Graphics g)
        {
            if (this.Statue)
            {
                Move();   //调用飞机移动的方法
                g.DrawImage(GC.AirPlaneImg, this.X, this.Y, this.Width, this.Height);
            }
        }

        /// <summary>
        /// 飞机类的键盘按下的处理方法
        /// </summary>
        /// <param name="e"></param>
        public void KeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    keyUp = true;
                    break;
                case Keys.Down:
                    keyDown = true;
                    break;
                case Keys.Left:
                    keyLeft = true;
                    break;
                case Keys.Right:
                    keyRight = true;
                    break;
                case Keys.Q:
                    if (isFire)
                        Fire(Keys.Q);
                    isFire = false;
                    break;
                case Keys.W:
                    if (isFire)
                        Fire(Keys.W);
                    isFire = false;
                    break;
                case Keys.E:
                    if (MissileIsFire)
                    {
                        FireMissile();
                        GC.myair.MissileCount -= 1;
                    }
                    MissileIsFire = false;
                    break;
            }
        }

        /// <summary>
        /// 键盘放下事件
        /// </summary>
        /// <param name="e"></param>
        public void KeyUp(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    keyUp = false;
                    break;
                case Keys.Down:
                    keyDown = false;
                    break;
                case Keys.Left:
                    keyLeft = false;
                    break;
                case Keys.Right:
                    keyRight = false;
                    break;
                case Keys.Q:  //发子弹
                    isFire = true;
                    break;
                case Keys.W:  //发导弹
                    isFire = true;
                    break;
                case Keys.E:  //发道具导弹
                    if (GC.myair.MissileCount > 0)
                        MissileIsFire = true;
                    break;
            }
        }

        /// <summary>
        /// 设置方向
        /// </summary>
        private void SetDirection()
        {
            if (keyUp && !keyDown && !keyLeft && !keyRight)
            {
                this.Direction = Direction.Up;   //上
            }
            else if (!keyUp && keyDown && !keyLeft && !keyRight)
            {
                this.Direction = Direction.Down;   //下
            }
            else if (!keyUp && !keyDown && keyLeft && !keyRight)
            {
                this.Direction = Direction.Left;   //左
            }
            else if (!keyUp && !keyDown && !keyLeft && keyRight)
            {
                this.Direction = Direction.Right;   //右
            }
            else if (keyUp && !keyDown && keyLeft && !keyRight)
            {
                this.Direction = Direction.UpLeft;   //上左
            }
            else if (keyUp && !keyDown && !keyLeft && keyRight)
            {
                this.Direction = Direction.UpRight;   //上右
            }
            else if (!keyUp && keyDown && keyLeft && !keyRight)
            {
                this.Direction = Direction.DownLeft;   //下左
            }
            else if (!keyUp && keyDown && !keyLeft && keyRight)
            {
                this.Direction = Direction.DownRight;   //下右
            }
            else
            {
                this.Direction = Direction.Stop;   //停止
            }
        }

        /// <summary>
        /// 移动事件
        /// </summary>
        private void Move()
        {
            SetDirection();
            switch (this.Direction)
            {
                case Direction.Up:
                    this.Y -= this.Speed;
                    if (this.Y < 0)
                        this.Y = 0;
                    break;
                case Direction.Down:
                    this.Y += this.Speed;
                    if (this.Y > 440)
                        this.Y = 440;
                    break;
                case Direction.Left:
                    this.X -= this.Speed;
                    if (this.X < 0)
                        this.X = 0;
                    break;
                case Direction.Right:
                    this.X += this.Speed;
                    if (this.X > 700)
                        this.X = 700;
                    break;
                case Direction.UpLeft:
                    this.Y -= this.Speed;
                    this.X -= this.Speed;
                    if (this.Y < 0)
                        this.Y = 0;
                    if (this.X < 0)
                        this.X = 0;
                    break;
                case Direction.UpRight:
                    this.Y -= this.Speed;
                    this.X += this.Speed;
                    if (this.Y < 0)
                        this.Y = 0;
                    if (this.X > 900)
                        this.X = 900;
                    break;
                case Direction.DownLeft:
                    this.Y += this.Speed;
                    this.X -= this.Speed;
                    if (this.Y > 540)
                        this.Y = 540;
                    if (this.X < 0)
                        this.X = 0;
                    break;
                case Direction.DownRight:
                    this.Y += this.Speed;
                    this.X += this.Speed;
                    if (this.Y > 540)
                        this.Y = 0;
                    if (this.X > 900)
                        this.X = 900;
                    break;
                case Direction.Stop:
                    break;
            }
        }

        /// <summary>
        /// 获取我军飞机对象的距形框
        /// </summary>
        /// <returns></returns>
        public Rectangle GetMyAirRectangle()
        {
            Rectangle rg = new Rectangle(this.X, this.Y, this.Width, this.Height);
            return rg;
        }

        /// <summary>
        /// 我军开火的方法，产生子弹对象
        /// </summary>
        private void Fire(Keys key)
        {
            if (key == Keys.Q)
                GC.bulletList.Add(new Bullet(this.X + this.Width, this.Y + (this.Height / 2), 10, 10, 20, 1, Direction.Right, true, this.GC));
            else if (key == Keys.W)
                GC.missileList.Add(new Missile(this.X + this.Width, this.Y + (this.Height / 2), 15, 10, 20, 1, Direction.Right, true, this.GC));

            GC.MyAirPlayMusic.PlayMusicThread(); //播放发导弹音乐
        }

        /// <summary>
        /// 我军开火的方法，发道具导弹
        /// </summary>
        private void FireMissile()
        {
            GC.missileList.Add(new Missile(this.X + this.Width, this.Y + (this.Height / 2), 15, 15, 20, 2, Direction.Right, true, this.GC));
            GC.MyAirPlayMusic.PlayMusicThread(); //播放发导弹音乐
        }
    }
}
