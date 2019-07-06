using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 截图
{
    /// <summary>
    /// 截图
    /// 参考来源：http://www.jb51.net/article/81960.htm
    /// </summary>
    public partial class CutterForm : Form
    {
        private Point DownPoint;
        private Rectangle CatchRectangle;
        private Bitmap originBmp = null;
        private bool CatchStart = false, CatchFinished = false; //是否开始截图，是否已截图完璧


        public CutterForm()
        {
            InitializeComponent();
        }

        private void CutterForm_Load(object sender, EventArgs e)
        {
            originBmp = new Bitmap(this.BackgroundImage);
        }

        /// <summary>
        /// 鼠标点击事件
        /// 鼠标右键点击则是退出截图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CutterForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.DialogResult = DialogResult.OK;
                Application.Exit(); //this.Close();
                //Environment.Exit(0);
            }
        }

        /// <summary>
        /// 鼠标按下事件
        /// 鼠标左键按下时，即代表开始截图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CutterForm_MouseDown(object sender, MouseEventArgs e)
        {
            // 鼠标左键按下是开始截图
            if (e.Button == MouseButtons.Left)
            {
                // 如果捕捉没有开始
                if (!CatchStart)
                {
                    CatchStart = true;
                    // 保存此时鼠标按下坐标
                    DownPoint = new Point(e.X, e.Y);
                }
            }
        }

        /// <summary>
        /// 鼠标移动事件 绘制截图
        /// 移动鼠标来改变截图的大小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CutterForm_MouseMove(object sender, MouseEventArgs e)
        {
            // 确保截图开始
            if (CatchStart)
            {
                // 新建一个图片对象，让它与屏幕图片相同
                Bitmap copyBmp = (Bitmap)originBmp.Clone();
                // 获取鼠标按下的坐标
                Point newPoint = new Point(DownPoint.X, DownPoint.Y);
                // 新建画板和画笔
                Graphics g = Graphics.FromImage(copyBmp);
                Pen p = new Pen(Color.Red, 2);

                // 获取矩形的长宽
                int width = Math.Abs(e.X - DownPoint.X);
                int height = Math.Abs(e.Y - DownPoint.Y);
                if (e.X < DownPoint.X)
                {
                    newPoint.X = e.X;
                }
                if (e.Y < DownPoint.Y)
                {
                    newPoint.Y = e.Y;
                }
                CatchRectangle = new Rectangle(newPoint, new Size(width, height));
                // 将矩形画在画板上
                g.DrawRectangle(p, CatchRectangle);
                // 释放目前的画板
                g.Dispose();
                p.Dispose();

                // 从当前窗体创建新的画板
                Graphics g1 = this.CreateGraphics();
                // 将刚才所画的图片画到截图窗体上
                // 为什么不直接在当前窗体画图呢？
                // 如果将矩形（截图图形）画在当前窗体上，会造成图片抖动并且有无数个矩形,这样实现也属于二次缓冲技术
                g1.DrawImage(copyBmp, new Point(0, 0));
                g1.Dispose();
                // 释放拷贝图片，防止内存被大量消耗
                copyBmp.Dispose();
            }
        }

        /// <summary>
        /// 鼠标松开事件
        /// 鼠标弹起时即代表结束截图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CutterForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // 如果截图已经开始，鼠标左键弹起设置截图完成
                if (CatchStart)
                {
                    CatchStart = false;
                    CatchFinished = true;
                }
            }
        }

        /// <summary>
        /// 鼠标双击事件
        /// 如果鼠标位于矩形内,则将矩形内的图片保存到剪切板中并保存图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CutterForm_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && CatchFinished)
            {
                // 新建一个与矩形（所截图）一样大小的空白图片
                Bitmap CatchedBmp = new Bitmap(CatchRectangle.Width, CatchRectangle.Height);

                Graphics g = Graphics.FromImage(CatchedBmp);
                // 把originBmp中指定部分按照指定大小画到空白图片上
                // CatchRectangle指定originBmp中指定部分
                // 第二个参数指定绘制到空白图片的位置和大小
                // 画完后CatchedBmp不再是空白图片了，而是具有与截取的图片一样的内容
                g.DrawImage(originBmp, new Rectangle(0, 0, CatchRectangle.Width, CatchRectangle.Height), CatchRectangle, GraphicsUnit.Pixel);

                // 将图片保存到剪切板中
                Clipboard.SetImage(CatchedBmp);
                //保存截图图片在磁盘上
                CatchedBmp.Save(string.Format(@"d:\{0}.jpg", DateTime.Now.ToString("yyyyMMddhhmmssfff")));

                g.Dispose();
                CatchFinished = false;
                this.BackgroundImage = originBmp;
                CatchedBmp.Dispose();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        /// <summary>
        /// 键盘按下松开事件
        /// 将矩形内的图片保存到剪切板中并保存图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CutterForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && CatchFinished) //回车
            {
                // 新建一个与矩形（所截图）一样大小的空白图片
                Bitmap CatchedBmp = new Bitmap(CatchRectangle.Width, CatchRectangle.Height);

                Graphics g = Graphics.FromImage(CatchedBmp);
                // 把originBmp中指定部分按照指定大小画到空白图片上
                // CatchRectangle指定originBmp中指定部分
                // 第二个参数指定绘制到空白图片的位置和大小
                // 画完后CatchedBmp不再是空白图片了，而是具有与截取的图片一样的内容
                g.DrawImage(originBmp, new Rectangle(0, 0, CatchRectangle.Width, CatchRectangle.Height), CatchRectangle, GraphicsUnit.Pixel);

                // 将图片保存到剪切板中
                Clipboard.SetImage(CatchedBmp);
                //保存截图图片在磁盘上
                CatchedBmp.Save(string.Format(@"d:\{0}.jpg", DateTime.Now.ToString("yyyyMMddhhmmssfff")));

                g.Dispose();
                CatchFinished = false;
                this.BackgroundImage = originBmp;
                CatchedBmp.Dispose();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

    }
}
