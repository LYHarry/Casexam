using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Generic;


namespace Grame
{
    public partial class GrameConsole : Form
    {
        #region  设置图片
        //设置窗体的背景图片
        public Image BackGroundImg = Image.FromFile(@"images\bg.png");
        //设置我军的飞机
        public Image AirPlaneImg = Image.FromFile(@"images\myplane.png");
        //设置敌军的飞机
        public Image EnemyAirPlaneImg1 = Image.FromFile(@"images\enemyplane1.png");
        public Image EnemyAirPlaneImg2 = Image.FromFile(@"images\enemyplane2.png");
        //我军飞机击中敌机爆炸图片
        public Image[] ExplodeImg1 ={
                                      Image.FromFile(@"images\huicheng1.png"),
                                      Image.FromFile(@"images\huicheng2.png"),
                                      Image.FromFile(@"images\huicheng3.png"),
                                      Image.FromFile(@"images\huicheng4.png")
                                  };
        //我军飞机生命值结束爆炸图片
        public Image[] ExplodeImg2 ={
                                      Image.FromFile(@"images\explode1.png"),
                                      Image.FromFile(@"images\explode2.png"),
                                      Image.FromFile(@"images\explode3.png"),
                                      Image.FromFile(@"images\explode4.png")
                                  };
        //导弹图片
        public Image missileImg1 = Image.FromFile(@"images\missile.png");
        public Image missileImg2 = Image.FromFile(@"images\missile3.png");
        //子弹图片
        public Image BulletImg1 = Image.FromFile(@"images\bullet.png");
        public Image BulletImg2 = Image.FromFile(@"images\enemybullet.png");
        //道具图片
        public Image PropImg = Image.FromFile(@"images\life.png");
        //Boss图片
        public Image BossImg = Image.FromFile(@"images\boss.png");
        //游戏准备状态的图片
        public Image grameReadImg = Image.FromFile(@"images\GameRead.jpg");
        //游戏失败状态的图片
        public Image grameFailImg = Image.FromFile(@"images\Gameover.jpg");
        //游戏成功状态的图片
        public Image grameSuccessImg = Image.FromFile(@"images\fly5.jpg");
        //Boss子弹
        public Image bossBulletImg = Image.FromFile(@"images\missile2.png");
        #endregion

        private BackGround bg;   //创建背景类
        public MyAirPlane myair;   //创建我军飞机类
        public List<EnemyAirPlane> EnemyAirList = new List<EnemyAirPlane>(); //创建敌军飞机list集合
        public Explode explode;  //创建爆炸类
        public List<Bullet> bulletList = new List<Bullet>();  //创建子弹list集合
        public Random r = new Random();  //创建随机对象
        public List<Missile> missileList = new List<Missile>();  //创建导弹list集合
        public StatueBar stateBar;  //创建状态条对象
        public List<Props> propList = new List<Props>();  //创建道具list集合
        public Boss boss; //创建Boss类
        public GrameStatue grameState;  //创建游戏的状态对象

        #region 设置背景音乐
        //创建播放游戏准备状态的音乐文件对象
        public PlayMusic playRead = new PlayMusic(@"music\gamebegin.mp3");
        //创建播放游戏背景音乐文件对象
        public PlayMusic playBG = new PlayMusic(@"music\bgmusic.mp3");
        //创建播放敌机发子弹音乐文件对象
        public PlayMusic EnemyPlayMusic = new PlayMusic(@"music\enemybullet.mp3");
        //创建播放我军飞机发子弹音乐文件对象
        public PlayMusic MyAirPlayMusic = new PlayMusic(@"music\bullet.mp3");
        //创建播放游戏结束音乐文件对象
        public PlayMusic PlayOver = new PlayMusic(@"music\gameover.mp3");
        //创建播放游戏成功音乐文件对象
        public PlayMusic PlaySuccess = new PlayMusic(@"music\complete.mp3");
        //创建播放我军飞机增加血音乐文件对象
        public PlayMusic PlayAddLifeNum = new PlayMusic(@"music\zengjia.mp3");
        //创建播放我军飞机爆炸音乐文件对象
        public PlayMusic PlayMyExplode = new PlayMusic(@"music\myplaneexplode.mp3");
        //创建播放爆炸音乐文件对象
        public PlayMusic PlayExplode = new PlayMusic(@"music\explode.mp3");
        #endregion

        public GrameConsole()
        {
            InitializeComponent();

            bg = new BackGround(0, 0, 800, 500, this);   //创建背景
            myair = new MyAirPlane(0, 280, 60, 15, 8, 100, true, Direction.Stop, this);  //创建我军飞机
            stateBar = new StatueBar(90, 20, 200, 18, this);  //创建状态条              
        }

        /// <summary>
        /// 绘制敌机
        /// </summary>
        private void DrawEnemyAir()
        {
            if (r.Next(300) % 60 == 0)
            {
                int speed = r.Next(1, 20);
                EnemyAirPlane ep = new EnemyAirPlane(802, r.Next(10, 460), 60, 15, speed, Direction.Left, 1, true, this);
                EnemyAirList.Add(ep);
            }
            if (r.Next(300) % 100 == 0)
            {
                int speed = r.Next(1, 20);
                EnemyAirPlane ep = new EnemyAirPlane(802, r.Next(10, 460), 60, 15, speed, Direction.Left, 2, true, this);
                EnemyAirList.Add(ep);
            }
        }

        /// <summary>
        /// 绘制道具
        /// </summary>
        private void DrawProp()
        {
            if (r.Next(550) % 222 == 0)
            {
                propList.Add(new Props(802, r.Next(30, 450), 15, 15, 5, 1, Direction.Left, true, this));
                propList.Add(new Props(802, r.Next(30, 450), 15, 15, 6, 2, Direction.Left, true, this));
            }
        }

        /// <summary>
        /// 绘制Boss
        /// </summary>
        private void DrawBoss()
        {
            if (myair.Score >= 100 && boss == null)
                boss = new Boss(700, 200, 120, 50, 8, 100, Direction.Left, true, this);
        }

        /// <summary>
        /// 重写窗体的OnPaint(重绘)方法
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            //调用基类的OnPaint方法
            base.OnPaint(e);

            //游戏准备状态
            if (grameState == GrameStatue.Read)
            {
                e.Graphics.DrawImage(grameReadImg, 0, 0, 800, 500);
                e.Graphics.DrawString("回车游戏开始", new Font("宋体", 50), new SolidBrush(Color.Red), new PointF(200, 200));
                playRead.PlayRepeat();  //播放准备状态的背景音乐               
                return;
            }
            //游戏失败状态
            if (grameState == GrameStatue.Fail)
            {
                Thread.Sleep(1000);
                e.Graphics.DrawImage(grameFailImg, 0, 0, 800, 500);
                e.Graphics.DrawString("失败", new Font("宋体", 50), new SolidBrush(Color.Red), new PointF(300, 200));
                PlayOver.PlayRepeat();  //播放游戏结束的背景音乐                
                return;
            }
            //游戏成功状态
            if (grameState == GrameStatue.Success)
            {
                Thread.Sleep(1000);
                e.Graphics.DrawImage(grameSuccessImg, 0, 0, 800, 500);
                e.Graphics.DrawString("胜利", new Font("宋体", 50), new SolidBrush(Color.Red), new PointF(300, 200));
                PlaySuccess.PlayRepeat();
                return;
            }
            //在窗体上绘制背景图片
            bg.DrawMe(e.Graphics);
            //在窗体上绘制我军飞机
            myair.DrawMe(e.Graphics);
            //在窗体上绘制军敌飞机
            for (int i = 0; i < EnemyAirList.Count; i++)
            {
                EnemyAirList[i].DrawMe(e.Graphics);
            }
            //在窗体上绘制爆炸
            if (explode != null)
            {
                explode.DrawMe(e.Graphics);
            }
            //在窗体上绘制子弹
            for (int i = 0; i < bulletList.Count; i++)
            {
                bulletList[i].DrawMe(e.Graphics);
            }
            //在窗体上绘制状态条
            stateBar.DrawMe(e.Graphics);
            //在窗体上绘制道具
            for (int i = 0; i < propList.Count; i++)
            {
                propList[i].DrawMe(e.Graphics);
            }
            //在窗体上绘制Boss
            if (boss != null)
            {
                boss.DrawMe(e.Graphics);
            }
            //绘制导弹
            for (int i = 0; i < missileList.Count; i++)
            {
                missileList[i].DrawMe(e.Graphics);
            }
        }

        /// <summary>
        /// 每隔一段时间重绘窗体，用于自定义线程调用
        /// </summary>
        private void Run()
        {
            while (true)
            {
                Thread.Sleep(50);
                //使窗体重绘
                this.Invalidate();
                //调用绘制飞机的方法
                DrawEnemyAir();
                //调用绘制道具的方法
                DrawProp();
                //调用绘制Boss的方法
                DrawBoss();
            }
        }

        //键盘按下事件,控制我军飞机
        private void GrameConsole_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && (grameState == GrameStatue.Read))
            {
                grameState = GrameStatue.Start;
                Thread td = new Thread(new ThreadStart(Run));
                td.IsBackground = true;  //指定Run为后台线程  默认为true
                td.Start();

                //循环播放背景音乐
                playBG.PlayRepeat();
            }
            if (grameState == GrameStatue.Start)
            {
                myair.KeyDown(e);
            }
        }

        //键盘放开事件,控制我军飞机
        private void GrameConsole_KeyUp(object sender, KeyEventArgs e)
        {
            if (grameState == GrameStatue.Start)
            {
                myair.KeyUp(e);
            }
        }


    }
}
