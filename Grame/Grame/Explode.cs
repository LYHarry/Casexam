using System;
using System.Drawing;

namespace Grame
{
    /// <summary>
    /// 爆炸类
    /// </summary>
    public class Explode
    {
        /// <summary>
        /// 爆炸时的X轴坐标
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// 爆炸时的Y轴坐标
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// 爆炸的宽度
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// 爆炸的高度
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// 窗体对象类
        /// </summary>
        public GrameConsole GC { get; set; }

        /// <summary>
        /// 爆炸图片的下标
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// 爆炸的状态，为真时表示飞机碰撞产生爆炸，为假时表示不产生爆炸
        /// </summary>
        public bool Statue { get; set; }

        /// <summary>
        /// 爆炸的类型，敌军死亡，还是我军死亡
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 爆炸类
        /// </summary>
        /// <param name="x">爆炸时的X轴坐标</param>
        /// <param name="y">爆炸时的Y轴坐标</param>
        /// <param name="width">爆炸的宽度</param>
        /// <param name="height">爆炸的高度</param>
        /// <param name="statue">飞机的状态,是否在工作区或被击中</param>
        /// <param name="gc">窗体对象类</param>
        public Explode(int x, int y, int width, int height, int type, GrameConsole gc, bool statue)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.GC = gc;
            this.Statue = statue;
            this.Type = type;
            this.Index = 0;
        }

        /// <summary>
        /// 绘制爆炸图片
        /// </summary>
        /// <param name="g"></param>
        public void DrawMe(Graphics g)
        {
            if (this.Index == GC.ExplodeImg1.Length)
            {
                this.Statue = false;
                return;
            }
            if (this.Statue)
            {
                if (this.Type == 1)
                {
                    g.DrawImage(GC.ExplodeImg1[this.Index], this.X, this.Y, this.Width, this.Height);
                }
                else if (this.Type == 2)
                {
                    g.DrawImage(GC.ExplodeImg2[this.Index], this.X, this.Y, this.Width, this.Height);
                }
                this.Index++;
            }
        }


    }
}
