using System;
using System.Drawing;

namespace Grame
{
    /// <summary>
    /// 状态条类
    /// </summary>
    public class StatueBar
    {
        /// <summary>
        /// 状态条的X轴坐标
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// 状态条的Y轴坐标
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// 状态条的宽度
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// 状态条的高度
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// 窗体对象类
        /// </summary>
        public GrameConsole GC { get; set; }

        /// <summary>
        /// 状态条
        /// </summary>
        /// <param name="x">状态条的X轴坐标</param>
        /// <param name="y">状态条的Y轴坐标</param>
        /// <param name="width">状态条的宽度</param>
        /// <param name="height">状态条的宽度</param>
        /// <param name="gc">窗体对象类</param>
        public StatueBar(int x, int y, int width, int height, GrameConsole gc)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.GC = gc;
        }

        /// <summary>
        /// 绘制状态条
        /// </summary>
        /// <param name="g"></param>
        public void DrawMe(Graphics g)
        {
            //绘制生命值
            g.DrawString("生命值 ", new Font("宋体", 15), new SolidBrush(Color.White), new PointF(20, 20));
            //绘制距形条
            g.DrawRectangle(new Pen(Color.Red), new Rectangle(this.X, this.Y, this.Width, this.Height));
            int stateWidth = GC.myair.LifeNum * 2;
            g.FillRectangle(new SolidBrush(Color.Red), new Rectangle(this.X + 1, this.Y + 1, stateWidth - 1, this.Height - 1));
            //绘制比率
            string lifeCount = GC.myair.LifeNum.ToString() + "%";
            g.DrawString(lifeCount, new Font("宋体", 12), new SolidBrush(Color.Wheat), new PointF(this.X + 80, this.Y + 2));
            //绘制生命值
            g.DrawString("分数 ", new Font("宋体", 15), new SolidBrush(Color.White), new PointF(this.X + this.Width + 10, this.Y));
            //绘制得分
            string score = GC.myair.Score.ToString();
            g.DrawString(score, new Font("宋体", 15), new SolidBrush(Color.Red), new PointF(this.X + this.Width + 60, this.Y));
            //绘制道具导弹
            g.DrawImage(GC.missileImg2, 400, 20, 20, 20);
            string missileCount = GC.myair.MissileCount.ToString();
            g.DrawString(missileCount, new Font("宋体", 15), new SolidBrush(Color.Red), new PointF(430, this.Y));
        }
    }
}
