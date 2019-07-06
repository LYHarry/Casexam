using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading;

namespace Grame
{
    /// <summary>
    /// 播放音乐类
    /// </summary>
    public class PlayMusic
    {
        /// <summary>
        /// 音乐文件的路径
        /// </summary>
        public string MusicPath { get; set; }

        //定义API函数使用的字符串变量
        [DllImport("winmm.dll")]
        private static extern int mciSendString(string m_strCmd, string m_strReceive, int m_v1, int m_v2);


        /// <summary>
        /// 播放音乐类
        /// </summary>
        /// <param name="path">音乐文件的路径</param>
        public PlayMusic(string path)
        {
            this.MusicPath = path;
        }

        /// <summary>
        /// 播放音乐
        /// </summary>
        private void Play()
        {
            mciSendString(@"close all", null, 0, 0);  //停止所有正在播放的音乐
            //打开指定的音乐文件，并取别名为 song
            mciSendString(@"open " + this.MusicPath + " alias song", null, 0, 0);
            mciSendString("play song", null, 0, 0); //播放音乐song
        }

        /// <summary>
        /// 循环播放音乐
        /// </summary>
        public void PlayRepeat()
        {
            mciSendString(@"close all", null, 0, 0);  //停止所有正在播放的音乐
            //打开指定的音乐文件，并取别名为 song
            mciSendString(@"open " + this.MusicPath + " alias song", null, 0, 0);
            mciSendString("play song repeat", null, 0, 0); //重复播放音乐song
        }

        /// <summary>
        /// 开启一个异步调用线程
        /// lambda表达式
        /// </summary>
        public void PlayMusicThread()
        {
            ThreadStart ts = new ThreadStart(() =>
            {
                Play();
            });
            ts.BeginInvoke(null, null);
        }
    }
}
