using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 窗体拖动
{
    public partial class Form1 : Form
    {
        private Point mouseoffset;//记录鼠标指针的坐标
        private bool isMouseDown = false;//记录鼠标左键是否按下

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.FormBorderStyle //设置窗体的边框样式
            //this.ControlBox //设置窗体顶部是否显示关闭、最大化、最小化按钮
        }

        /// <summary>
        /// 鼠标放开事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
            }
        }
        /// <summary>
        /// 鼠标移动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseoffset.X, mouseoffset.Y);
                Location = mousePos;
            }
        }
        /// <summary>
        /// 鼠标按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseoffset = new Point(-e.X, -e.Y);
                isMouseDown = true;
            }
        }
    }
}
