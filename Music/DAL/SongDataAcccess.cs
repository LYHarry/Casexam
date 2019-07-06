using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace Music.DAL
{
    /// <summary>
    /// Songs的数据访问类，处理和Songs有关的数据库访问的相关的操作
    /// </summary>
    public class SongDataAcccess
    {
        /// <summary>
        /// 添加Song(歌曲)对象
        /// </summary>
        /// <param name="user">要添加的Song对象</param>
        /// <returns>返回是否成功添加</returns>
        public static bool AddSong(Music.Model.Songs song)
        {
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@SongName",song.SongName),
                new SqlParameter("@Singer",song.Singer),
                new SqlParameter("@category",song.Category),
                new SqlParameter("@UploadTime",song.UploadTime), 
                new SqlParameter("@UserID",song.UserID),                
                new SqlParameter("@ClickCount",song.ClickCount), 
                new SqlParameter("@Path",song.Path)
            };
            int f = SQLHelper.ExecuteNonQuery("AddSong", CommandType.StoredProcedure, par);
            return f > 0;
        }

        /// <summary>
        /// 删除Song对象
        /// </summary>
        /// <param name="id">要删除Song对象的ID</param>
        /// <returns>返回是否成功删除</returns>
        public static bool DeleteSong(int id)
        {
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@id",id)
            };
            int f = SQLHelper.ExecuteNonQuery("DeleteSong", CommandType.StoredProcedure, par);
            return f > 0;
        }

        /// <summary>
        /// 更改歌曲对象信息
        /// </summary>
        /// <param name="song">要更改的歌曲对象</param>
        /// <returns>返回是否成功更改</returns>
        public static bool ChangeSong(Music.Model.Songs song)
        {
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@SongName",song.SongName),
                new SqlParameter("@Singer",song.Singer),
                new SqlParameter("@category",song.Category),
                new SqlParameter("@UploadTime",song.UploadTime),
                new SqlParameter("@UserID",song.UserID),
                new SqlParameter("@ClickCount",song.ClickCount),
                new SqlParameter("@Path",song.Path)
            };
            int f = SQLHelper.ExecuteNonQuery("ChangeSong", CommandType.StoredProcedure, par);
            return f > 0;
        }

        /// <summary>
        /// 获取指定的歌曲
        /// </summary>
        /// <param name="id">要获取歌曲的ID</param>
        /// <returns></returns>
        public static Music.Model.Songs GetSong(int id)
        {
            Music.Model.Songs song = new Model.Songs();  //创建一个Song对象

            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@id",id)
            };
            SqlDataReader sdr = SQLHelper.ExecuteDataReader("GetSong", CommandType.StoredProcedure, par);
            if (sdr.Read())
            {
                song.ID = Convert.ToInt32(sdr["ID"]);
                song.SongName = Convert.ToString(sdr["SongName"]);
                song.Singer = Convert.ToString(sdr["Singer"]);
                song.Category = Convert.ToString(sdr["Category"]);
                song.UploadTime = Convert.ToDateTime(sdr["UploadTime"]);
                song.UserID = Convert.ToInt32(sdr["UserID"]);
                song.ClickCount = Convert.ToInt32(sdr["ClickCount"]);
                song.Path = Convert.ToString(sdr["Path"]);
            }
            return song;
        }

        /// <summary>
        /// 增加歌曲的点击次数
        /// </summary>
        /// <param name="id">要增加歌曲次数的ID</param>
        /// <returns></returns>
        public static bool AddClickCount(int id)
        {
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@id",id)
            };
            int f = SQLHelper.ExecuteNonQuery("AddClickCount", CommandType.StoredProcedure, par);
            return f > 0;
        }

        /// <summary>
        /// 获取所有的歌曲对象
        /// </summary>
        /// <returns></returns>
        public static List<Music.Model.Songs> GetAllSongs()
        {
            List<Music.Model.Songs> list = new List<Model.Songs>(); //创建List集合
            SqlDataReader sdr = SQLHelper.ExecuteDataReader("GetAllSongs", CommandType.StoredProcedure);
            while (sdr.Read())
            {
                Music.Model.Songs song = new Model.Songs();
                song.ID = Convert.ToInt32(sdr["ID"]);
                song.SongName = Convert.ToString(sdr["SongName"]);
                song.Singer = Convert.ToString(sdr["Singer"]);
                song.Category = Convert.ToString(sdr["Category"]);
                song.UploadTime = Convert.ToDateTime(sdr["UploadTime"]);
                song.UserID = Convert.ToInt32(sdr["UserID"]);
                song.ClickCount = Convert.ToInt32(sdr["ClickCount"]);
                song.Path = Convert.ToString(sdr["Path"]);

                list.Add(song);
            }
            return list;
        }

        /// <summary>
        /// 获取最新上传的所有歌曲对象
        /// </summary>
        /// <param name="count">获取多少首最新上传的歌曲</param>
        /// <returns></returns>
        public static List<Music.Model.Songs> GetNewSongs(int count)
        {
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@count",count)
            };

            List<Music.Model.Songs> list = new List<Model.Songs>(); //创建List集合
            SqlDataReader sdr = SQLHelper.ExecuteDataReader("GetNewSongs", CommandType.StoredProcedure, par);
            while (sdr.Read())
            {
                Music.Model.Songs song = new Model.Songs();
                song.ID = Convert.ToInt32(sdr["ID"]);
                song.SongName = Convert.ToString(sdr["SongName"]);
                song.Singer = Convert.ToString(sdr["Singer"]);
                song.Category = Convert.ToString(sdr["Category"]);
                song.UploadTime = Convert.ToDateTime(sdr["UploadTime"]);
                song.UserID = Convert.ToInt32(sdr["UserID"]);
                song.ClickCount = Convert.ToInt32(sdr["ClickCount"]);
                song.Path = Convert.ToString(sdr["Path"]);

                list.Add(song);
            }
            return list;
        }

        /// <summary>
        /// 获取最热门的所有歌曲对象
        /// </summary>
        /// <param name="count">获取多少首最热门的歌曲</param>
        /// <returns></returns>
        public static List<Music.Model.Songs> GetHotSongs(int count)
        {
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@count",count)
            };

            List<Music.Model.Songs> list = new List<Model.Songs>(); //创建List集合
            SqlDataReader sdr = SQLHelper.ExecuteDataReader("GetHotSongs", CommandType.StoredProcedure, par);
            while (sdr.Read())
            {
                Music.Model.Songs song = new Model.Songs();
                song.ID = Convert.ToInt32(sdr["ID"]);
                song.SongName = Convert.ToString(sdr["SongName"]);
                song.Singer = Convert.ToString(sdr["Singer"]);
                song.Category = Convert.ToString(sdr["Category"]);
                song.UploadTime = Convert.ToDateTime(sdr["UploadTime"]);
                song.UserID = Convert.ToInt32(sdr["UserID"]);
                song.ClickCount = Convert.ToInt32(sdr["ClickCount"]);
                song.Path = Convert.ToString(sdr["Path"]);

                list.Add(song);
            }
            return list;
        }

        /// <summary>
        /// 获取指定用户上传的歌曲列表
        /// </summary>
        /// <param name="id">上传用户的ID</param>
        /// <returns></returns>
        public static List<Music.Model.Songs> GetSongsByUser(int id)
        {
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@id",id)
            };

            List<Music.Model.Songs> list = new List<Model.Songs>(); //创建List集合
            SqlDataReader sdr = SQLHelper.ExecuteDataReader("GetSongsByUser", CommandType.StoredProcedure, par);
            while (sdr.Read())
            {
                Music.Model.Songs song = new Model.Songs();
                song.ID = Convert.ToInt32(sdr["ID"]);
                song.SongName = Convert.ToString(sdr["SongName"]);
                song.Singer = Convert.ToString(sdr["Singer"]);
                song.Category = Convert.ToString(sdr["Category"]);
                song.UploadTime = Convert.ToDateTime(sdr["UploadTime"]);
                song.UserID = Convert.ToInt32(sdr["UserID"]);
                song.ClickCount = Convert.ToInt32(sdr["ClickCount"]);
                song.Path = Convert.ToString(sdr["Path"]);

                list.Add(song);
            }
            return list;
        }

        /// <summary>
        /// 按歌曲名获取歌曲列表
        /// </summary>
        /// <param name="songName">要查询的歌曲名称</param>
        /// <returns></returns>
        public static List<Music.Model.Songs> GetSongsBySongName(string songName)
        {
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@SongName",songName)
            };

            List<Music.Model.Songs> list = new List<Model.Songs>(); //创建List集合
            SqlDataReader sdr = SQLHelper.ExecuteDataReader("GetSongsBySongName", CommandType.StoredProcedure, par);
            while (sdr.Read())
            {
                Music.Model.Songs song = new Model.Songs();
                song.ID = Convert.ToInt32(sdr["ID"]);
                song.SongName = Convert.ToString(sdr["SongName"]);
                song.Singer = Convert.ToString(sdr["Singer"]);
                song.Category = Convert.ToString(sdr["Category"]);
                song.UploadTime = Convert.ToDateTime(sdr["UploadTime"]);
                song.UserID = Convert.ToInt32(sdr["UserID"]);
                song.ClickCount = Convert.ToInt32(sdr["ClickCount"]);
                song.Path = Convert.ToString(sdr["Path"]);

                list.Add(song);
            }
            return list;
        }

        /// <summary>
        /// 按歌手名获取歌曲列表
        /// </summary>
        /// <param name="singer">要查询的歌手名</param>
        /// <returns></returns>
        public static List<Music.Model.Songs> GetSongsBySinger(string singer)
        {
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@singer",singer)
            };

            List<Music.Model.Songs> list = new List<Model.Songs>(); //创建List集合
            SqlDataReader sdr = SQLHelper.ExecuteDataReader("GetSongsBySinger", CommandType.StoredProcedure, par);
            while (sdr.Read())
            {
                Music.Model.Songs song = new Model.Songs();
                song.ID = Convert.ToInt32(sdr["ID"]);
                song.SongName = Convert.ToString(sdr["SongName"]);
                song.Singer = Convert.ToString(sdr["Singer"]);
                song.Category = Convert.ToString(sdr["Category"]);
                song.UploadTime = Convert.ToDateTime(sdr["UploadTime"]);
                song.UserID = Convert.ToInt32(sdr["UserID"]);
                song.ClickCount = Convert.ToInt32(sdr["ClickCount"]);
                song.Path = Convert.ToString(sdr["Path"]);

                list.Add(song);
            }
            return list;
        }

    }
}
