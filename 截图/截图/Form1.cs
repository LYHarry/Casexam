using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace 截图
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 开始截图按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCutter_Click(object sender, EventArgs e)
        {
            int ScreenWidth = Screen.AllScreens[0].Bounds.Width; //得到屏幕的宽度
            int ScreenHeight = Screen.AllScreens[0].Bounds.Height;//得到屏幕的高度

            // 通过Graphics的CopyFromScreen方法把全屏图片的拷贝到我们定义好的一个和屏幕大小相同的空白图片中，
            // 拷贝完成之后，CatchBmp就是全屏图片的拷贝了，然后指定为截图窗体背景图片就好了。
            // 新建一个和屏幕大小相同的图片
            Bitmap CatchBmp = new Bitmap(ScreenWidth, ScreenHeight);

            // 创建一个画板，让我们可以在画板上画图
            // 这个画板也就是和屏幕大小一样大的图片
            // 我们可以通过Graphics这个类在这个空白图片上画图
            Graphics g = Graphics.FromImage(CatchBmp);

            // 把屏幕图片拷贝到我们创建的空白图片 CatchBmp中
            g.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(ScreenWidth, ScreenHeight));
            //绘制一边红色边框
            g.DrawRectangle(new Pen(Color.Red, 5), new Rectangle(new Point(0, 0), new Size(ScreenWidth, ScreenHeight)));

            // 创建截图窗体
            CutterForm cutform = new CutterForm();
            // 指示窗体的背景图片为屏幕图片
            cutform.BackgroundImage = CatchBmp;
            cutform.MaximumSize = new Size(ScreenWidth, ScreenHeight);
            cutform.WindowState = FormWindowState.Maximized;
            cutform.Show();
            this.Hide();
        }

        /// <summary>
        ///  窗体加载事件处理
        ///  在窗体加载时注册热键（快捷键）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            // 调用了Win32中RegisterHotKey方法来完成热键的注册
            uint ctrlHotKey = (uint)(截图.HotKey.KeyModifiers.Alt | 截图.HotKey.KeyModifiers.Ctrl);
            // 注册热键为Alt+Ctrl+R, "100"为唯一标识热键
            HotKey.RegisterHotKey(this.Handle, 100, ctrlHotKey, (UInt32)Keys.R);
        }

        /// <summary>
        /// 窗体关闭时处理程序
        /// 窗体关闭时取消热键注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 卸载热键
            HotKey.UnregisterHotKey(this.Handle, 100);
        }

        /// <summary>
        /// 热键按下执行的方法
        /// </summary>
        private void GlobalKeyProcess()
        {
            this.WindowState = FormWindowState.Minimized;
            // 窗口最小化也需要一定时间
            Thread.Sleep(500);
            btnCutter.PerformClick(); //调用开始截图按钮的点击事件
        }

        /// <summary>
        /// 重写WndProc()方法，通过监视系统消息，来调用过程
        /// 监视Windows消息
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            //如果m.Msg的值为0x0312那么表示用户按下了热键
            const int WM_HOTKEY = 0x0312;
            switch (m.Msg)
            {
                case WM_HOTKEY:
                    {
                        if (m.WParam.ToString() == "100")
                        {
                            GlobalKeyProcess();
                        }
                    }
                    break;
            }
            // 将系统消息传递自父类的WndProc
            base.WndProc(ref m);
        }

    }
}
