using System.Drawing;

namespace Grame
{
    /// <summary>
    /// 背景类
    /// </summary>
    public class BackGround
    {
        /// <summary>
        /// 背景图片左顶点的X坐标
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// 背景图片左顶点的Y坐标
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// 背景图片的宽度
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// 背景图片的高度
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// 窗体对象
        /// </summary>
        public GrameConsole GC { get; set; }

        /// <summary>
        /// 背景图片
        /// </summary>
        /// <param name="x">背景图片左顶点的X坐标</param>
        /// <param name="y">背景图片左顶点的Y坐标</param>
        /// <param name="width">背景图片的宽度</param>
        /// <param name="height">背景图片的高度</param>
        public BackGround(int x, int y, int width, int height, GrameConsole gc)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.GC = gc;
        }

        /// <summary>
        /// 绘制背景
        /// </summary>
        /// <param name="g">为哪个对象画背景，该对象的Graphics</param>
        public void DrawMe(Graphics g)
        {
            g.DrawImage(GC.BackGroundImg, this.X, this.Y, this.Width, this.Height);
            g.DrawImage(GC.BackGroundImg, this.X + this.Width - 1, this.Y, this.Width, this.Height);
            Move();
        }

        /// <summary>
        /// 移动背景
        /// </summary>
        public void Move()
        {
            this.X--;
            if (this.X <= -(this.Width - 1))
                this.X = 0;
        }
    }
}
