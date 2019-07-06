using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Music.Model
{
    /// <summary>
    /// 歌曲实体类
    /// </summary>
    public class Songs
    {
        private int id;   //歌曲编号
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string songName;   //歌曲名称
        public string SongName
        {
            get { return songName; }
            set { songName = value; }
        }

        private string singer;  //歌手
        public string Singer
        {
            get { return singer; }
            set { singer = value; }
        }

        private string category;  //歌曲风格
        public string Category
        {
            get { return category; }
            set { category = value; }
        }

        private DateTime uploadTime;  //上传时间
        public DateTime UploadTime
        {
            get { return uploadTime; }
            set { uploadTime = value; }
        }

        private int userID;   //上传者编号
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        private int clickCount;   //点击次数
        public int ClickCount
        {
            get { return clickCount; }
            set { clickCount = value; }
        }

        private string path;    //歌曲保存路径
        public string Path
        {
            get { return path; }
            set { path = value; }
        }
    }
}
