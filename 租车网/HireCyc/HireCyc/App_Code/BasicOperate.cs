using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

/// <summary>
/// 该类提供基本操作方法，如判断密码和确认密码是否相同等
/// </summary>
public class BasicOperate
{
    /// <summary>
    /// 构造函数
    /// </summary>
    public BasicOperate()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    /// <summary>
    /// 判断两个字符串是否相同
    /// </summary>
    /// <param name="str1">第一个字符串</param>
    /// <param name="str2">第二个字符串</param>
    /// <returns>返回真假</returns>
    public static bool strIsEqual(string str1, string str2)
    {
        bool t = false; //用于保存是否相等

        if (str1.Length != str2.Length)
        {
            return t;
        }
        else
        {
            int f = 1;  //用于判断两个字符串是否相同
            int len = str1.Length;  //获取第一个字符串的长度

            for (int i = 0; i < len; i++)
            {
                string str = str1.Substring(i, 1); //获取第一个字符串的每一个字符
                string restr = str2.Substring(i, 1);//获取第二个字符串的每一个字符
                if (!(str.Equals(restr)))
                {
                    f = 0; break;
                }
            }

            if (f == 1)
                t = true;
        }

        return t;
    }

    /// <summary>
    /// 随机产生验证码字符串
    /// </summary>
    /// <param name="n">要产生多少位验证码</param>
    /// <returns>返回产生的验证码</returns>
    public static string SecurityCode(int n)
    {
        Random rd = new Random();

        int m = 48;
        string str = "";   //用于保存用于生成验证码的字符串，大小写字母，数字 
        string code = "";  //用于保存产生的验证码

        for (int i = 1; i < 62; i++)
        {
            char t = Convert.ToChar((m + i));
            str += t.ToString();
            if (i == 9)
                m = m + 7;

            if (i == 35)
                m = m + 6;
        }

        for (int j = 0; j < n; j++)
        {
            char c = str[rd.Next(str.Length)];

            code += c.ToString();
        }

        return code;
    }


    /// <summary>
    /// 随机产生6位验证码
    /// </summary>
    /// <returns></returns>
    public static string SecurityCode()
    {
        Random rd = new Random();
        string str = "";   //合法的字符串 
        string getstr = "";  //得到的随机字符串

        for (int i = 0; i < 26; i++)
        {
            str += Convert.ToChar(65 + i);
            str += Convert.ToChar(97 + i);
        }
        for (int j = 0; j <= 9; j++)
        {
            str += j;
        }
        for (int n = 0; n < 6; n++)
        {
            getstr += str.Substring(rd.Next(0, str.Length - 1), 1);
        }
        return getstr;
    }

    /// <summary>
    /// 把验证码字符串生成图片流
    /// </summary>
    /// <param name="strKey">要生成的验证码字符串</param>
    /// <param name="imgWith">图片的宽度</param>
    /// <param name="imgHeight">图片的高度</param>
    /// <returns>返回图片流</returns>
    public static byte[] CheckCodeImage(ref string strKey, int imgWith, int imgHeight)
    {
        Random rd = new Random();
        Bitmap image = new Bitmap(imgWith, imgHeight); //验证码科图片大小
        int BgRed = 0, BgGreen = 0, BgBlue = 0;  //保存随机产生的数值，用于设置背景色
        Graphics g = Graphics.FromImage(image);

        g.Clear(Color.White);  //清空图片背景色，并以白色填充背景色 

        //随机得到RGB三元色值
        BgRed = rd.Next(128) + 128;
        BgGreen = rd.Next(255) % 128 + 128;
        BgBlue = rd.Next(255) % 128 + 128;

        //绘制图片的边框线
        g.DrawRectangle(new Pen(Color.Azure), 0, 0, image.Width - 1, image.Height - 1);

        // 干扰线条颜色样式
        Pen pen = new Pen(Color.FromArgb(BgRed - 17, BgGreen - 17, BgBlue - 17), 1);

        for (int i = 0; i < 10; i++)   //绘制图片的背景干扰线
        {
            Point p1 = new Point();
            p1.X = rd.Next(image.Width);
            p1.Y = rd.Next(image.Height);
            Point p2 = new Point();
            p2.X = rd.Next(image.Width);
            p2.Y = rd.Next(image.Height);
            g.DrawLine(pen, p1, p2);
        }

        //绘制图片的背景干扰噪音点
        for (int i = 0; i < 2000; i++)
        {
            int x = rd.Next(image.Width);
            int y = rd.Next(image.Height);
            image.SetPixel(x, y, Color.FromArgb(rd.Next()));
        }

        // 确定字体样式
        Font font = new Font("Courier New", 20 + rd.Next() % 4, FontStyle.Bold);
        LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1.2f, true);
        g.DrawString(strKey, font, brush, 2, 2);  //绘制验证码字

        //在窗体上直接据image返回，赋给this.pictureBox1.BackgroundImage = image

        // 把图片转换为输出字节流
        MemoryStream stream = new MemoryStream();
        image.Save(stream, ImageFormat.Png);
        image.Dispose();
        g.Dispose();  //清除资源
        byte[] ImageByte = stream.ToArray();
        stream.Close();

        return ImageByte;
    }

    /// <summary>
    /// 判断身份证是否合法，18位
    /// </summary>
    /// <param name="card">要判断的身份证</param>
    /// <returns>返回真假</returns>
    public static string CardIDIsLegal(string card)
    {
        //保存我国每个地区的地区码
        string[] region = new string[] { "11", "12", "13", "14", "15", "21", 
            "22", "23", "31", "32", "33", "34", "35", "36", "37", "41", "42", 
            "43", "44", "45", "46", "50", "51", "52", "53", "54", "61", "62", 
            "63", "64", "65", "71", "81", "82", "91" };

        //判断身份证长度是否为18位
        if (card.Length != 18)
            return "身份证长度不等于18位";
        else
        {
            //判断前17位是否为数字
            string cardNum = card.Substring(0, card.Length - 1);
            if (!isNum(cardNum))
                return "前17位不全为数字";

            //判断第18位是否为数字或字母X
            if ((card[17] < '0' && card[17] > '9') && (card[17] != 'x') && (card[17] != 'X'))
                return "第18位不为数字或大小写字母X";

            //判断身份证地区码是否合法
            int f = 0;  //保存地区码意判断结果
            string cardRegion = card.Substring(0, 2);
            for (int i = 0; i < region.Length; i++)
            {
                string ch = region[i];  //取出地区码字符串数组与身份证地区码相比较
                if (cardRegion.Equals(ch))
                {
                    f = 1;
                    break;
                }
            }
            if (f == 0)
                return "地区码输入不合法";

            //取出年月日进行判断
            int cardYear = Convert.ToInt32(card.Substring(6, 4));
            int cardMonth = Convert.ToInt32(card.Substring(10, 2));
            int cardDay = Convert.ToInt32(card.Substring(12, 2));

            //判断年是否合法
            if (cardYear > DateTime.Now.Year || cardYear < 1880)
                return "年份输入不合法";

            //判断月是否合法
            if (cardMonth > 12 || cardMonth < 1)
                return "月份输入不合法";

            //判断日是否合法
            if (cardMonth == 2)
            {
                if (IsLeapYear(cardYear))
                {
                    if (cardDay > 29 || cardDay < 1)
                        return "天数输入不合法";
                    else if (cardDay > 28 || cardDay < 1)
                        return "天数输入不合法";
                }
            }
            else if (cardMonth == 4 || cardMonth == 6 || cardMonth == 9 || cardMonth == 11)
            {
                if (cardDay > 30 || cardDay < 1)
                    return "天数输入不合法";
            }
            else
            {
                if (cardDay > 31 || cardDay < 1)
                    return "天数输入不合法";
            }
        }

        return "成功";
    }

    /// <summary>
    /// 判断字符串是否全是数字
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public static bool isNum(string num)
    {
        bool t = false;

        int f = 1;  //保存每一位比值的结果
        for (int i = 0; i < num.Length; i++)
        {
            char ch = num[i];
            if (ch < '0' || ch > '9')
            {
                f = 0; break;
            }
        }

        if (f == 1)
            t = true;

        return t;
    }

    /// <summary>
    /// 判断是否为闰年
    /// </summary>
    /// <param name="year">要判断的年份</param>
    /// <returns>返回真假</returns>
    public static bool IsLeapYear(int year)
    {
        bool t = false;   //保存结果

        if (((year % 4 == 0) && (year % 100 != 0)) || (year % 400 == 0))
            t = true;

        return t;
    }

    /// <summary>
    /// 判断手机号码是否正确
    /// </summary>
    /// <param name="phone">要判断的号码</param>
    /// <returns>返回结果</returns>
    public static bool PhoneIsLegal(string phone)
    {
        bool t = false;  //用于保存结果

        Regex reg = new Regex("^1[34578][0-9]{9}$");

        Match m = reg.Match(phone);

        if (m.Success)
            t = true;

        return t;
    }

    /// <summary>
    /// 判断电子邮箱地址格式是否正确
    /// </summary>
    /// <param name="Email">要判断的电子邮箱地址</param>
    /// <returns>返回结果</returns>
    public static bool EmailIsLegal(string Email)
    {
        bool t = false;  //保存结果

        //(?i)忽略大小写
        Regex reg = new Regex("(?i)^[a-z0-9]+[-_]*[a-z0-9]+@[a-z0-9]+.com$");

        Match m = reg.Match(Email);

        if (m.Success)
            t = true;

        return t;
    }

    /// <summary>
    /// 得到某个文件夹下面所有文件的文件名称
    /// </summary>
    /// <param name="path">文件夹路径</param>
    /// <returns>文件名字列表</returns>
    public static List<string> GetFileName(string path)
    {
        //Directory.GetFiles(path);   得到path路径下所有文件的完整路径

        List<string> list = new List<string>();

        DirectoryInfo di = new DirectoryInfo(path);

        foreach (FileInfo FI in di.GetFiles())  //获取path路径下所有文件的文件名
        {
            list.Add(FI.Name);
        }
        return list;
    }

    /// <summary>
    /// 把一个字符串插入到另一个字符串中，形成一个新的字符串
    /// </summary>
    /// <param name="startIndex">插入的开始下标</param>
    /// <param name="formerly">插入到的字符串</param>
    /// <param name="keyt">要插入的字符串</param>
    /// <returns>形成的新字符串</returns>
    public static string InsertStr(int startIndex, string formerly, string keyt)
    {
        formerly = formerly.Insert(startIndex, keyt);

        return formerly;
    }

    /// <summary>
    /// 发送邮件
    /// </summary>
    /// <param name="form">发件人邮箱地址</param>
    /// <param name="password">发件人邮箱密码</param>
    /// <param name="to">接受者邮箱地址</param>
    /// <param name="host">SMTP服务器的主机名</param>
    /// <param name="sub">邮件主题</param>
    /// <param name="body">邮件主体正文</param>
    /// <returns></returns>
    public static string Send(string form, string password, string to, string host, string sub, string body)
    {
        string content = "";  //用于保存是否成功发送

        try
        {
            SmtpClient client = new SmtpClient(host, 25);
            client.UseDefaultCredentials = false;

            //设置超时时间  
            client.Timeout = 1000 * 60 * 2;  //两分钟后超时

            client.Credentials = new NetworkCredential(form, password);  //发件人地址和密码
            client.DeliveryMethod = SmtpDeliveryMethod.Network;  //指定电子邮件发送方式

            MailMessage message = new MailMessage(form, to); //发件人，收件人地址
            message.Subject = sub;  //邮箱标题
            message.SubjectEncoding = Encoding.UTF8;  //标题编码
            message.Body = body;  //正文内容
            message.BodyEncoding = Encoding.UTF8;  //正文编码
            message.IsBodyHtml = true;//设置为HTML格式
            message.Priority = MailPriority.High;//优先级

            client.Send(message);
        }
        catch (Exception ex)
        {
            content = ex.Message;
        }

        return content;
    }


    /// <summary>
    /// 发送手机短信息接口，短信通接口
    /// </summary>
    /// <param name="url">接口地址</param>
    /// <returns></returns>
    public static string GetHtmlFromUrl(string url)
    {
        string strRet = null;

        if (string.IsNullOrEmpty(url))
        {
            return strRet;
        }

        string targeturl = url.Trim().ToString();
        try
        {
            HttpWebRequest hr = (HttpWebRequest)WebRequest.Create(targeturl);
            hr.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)";
            hr.Method = "GET";
            hr.Timeout = 30 * 60 * 1000;
            WebResponse hs = hr.GetResponse();
            Stream sr = hs.GetResponseStream();
            StreamReader ser = new StreamReader(sr, Encoding.Default);
            strRet = ser.ReadToEnd();
        }
        catch (Exception ex)
        {
            strRet = ex.Message;
        }
        return strRet;
    }



    /// <summary>
    /// 随机产生数字
    /// </summary>
    /// <param name="n">产生多少位</param>
    /// <returns></returns>
    public static string RanNumCode(int n)
    {
        Random rd = new Random();

        int m = 47;
        string str = "";   //用于保存用于生成验证码数字字符串 
        string code = "";  //用于保存产生的验证码

        for (int i = 1; i < 11; i++)
        {
            char t = Convert.ToChar((m + i));
            str += t.ToString();
        }

        for (int j = 0; j < n; j++)
        {
            char c = str[rd.Next(str.Length)];

            code += c.ToString();
        }

        return code;
    }


    /// <summary>
    /// 对内容进行编码，飞信发送短信
    /// </summary>
    /// <param name="str">要编码的内容</param>
    /// <returns></returns>
    public static string BodyEncode(string str)
    {
        StringBuilder sb = new StringBuilder();
        byte[] byStr = System.Text.Encoding.Default.GetBytes(str);
        for (int i = 0; i < byStr.Length; i++)
        {
            sb.Append(@"%" + Convert.ToString(byStr[i], 16));
        }

        return (sb.ToString());
    }

    /// <summary>
    /// 发送短信，通过飞信接口
    /// </summary>
    /// <param name="Url">接口路径</param>
    /// <returns></returns>
    public static string getContent(string Url)
    {
        string strResult = "";
        try
        {
            //声明一个HttpWebRequest请求  
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            //设置连接超时时间  
            request.Timeout = 30000;
            request.Headers.Set("Pragma", "no-cache");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream streamReceive = response.GetResponseStream();
            Encoding encoding = Encoding.GetEncoding("GB2312");
            StreamReader streamReader = new StreamReader(streamReceive, encoding);
            strResult = streamReader.ReadToEnd();
            streamReader.Close();
        }
        catch (Exception)
        {
            throw;
        }
        return strResult;
    }

    /// <summary>
    /// 判断list中是否存在某字符串
    /// </summary>
    /// <param name="keyt">字符串</param>
    /// <param name="list">lis列表</param>
    /// <returns></returns>
    public static bool strIsExistList(string keyt, List<string> list)
    {
        bool isAdd = false;  //默认不存在

        foreach (string s in list)
        {
            if (s.Equals(keyt))
            {
                isAdd = true;
                break;
            }
        }

        return isAdd;
    }



}