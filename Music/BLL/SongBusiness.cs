using System.Collections.Generic;

namespace Music.BLL
{
    /// <summary>
    /// Song的业务逻辑访问类
    /// </summary>
    public class SongBusiness
    {
        /// <summary>
        /// 添加Song(歌曲)对象
        /// </summary>
        /// <param name="user">要添加的Song对象</param>
        /// <returns>返回是否成功添加</returns>
        public static bool AddSong(Music.Model.Songs song)
        {
            return Music.DAL.SongDataAcccess.AddSong(song);
        }

        /// <summary>
        /// 删除Song对象
        /// </summary>
        /// <param name="id">要删除Song对象的ID</param>
        /// <returns>返回是否成功删除</returns>
        public static bool DeleteSong(int id)
        {
            return Music.DAL.SongDataAcccess.DeleteSong(id);
        }

        /// <summary>
        /// 更改歌曲对象信息
        /// </summary>
        /// <param name="song">要更改的歌曲对象</param>
        /// <returns>返回是否成功更改</returns>
        public static bool ChangeSong(Music.Model.Songs song)
        {
            return Music.DAL.SongDataAcccess.ChangeSong(song);
        }

        /// <summary>
        /// 获取指定的歌曲
        /// </summary>
        /// <param name="id">要获取歌曲的ID</param>
        /// <returns></returns>
        public static Music.Model.Songs GetSong(int id)
        {
            return Music.DAL.SongDataAcccess.GetSong(id);
        }

        /// <summary>
        /// 增加歌曲的点击次数
        /// </summary>
        /// <param name="id">要增加歌曲次数的ID</param>
        /// <returns></returns>
        public static bool AddClickCount(int id)
        {
            return Music.DAL.SongDataAcccess.AddClickCount(id);
        }

        /// <summary>
        /// 获取所有的歌曲对象
        /// </summary>
        /// <returns></returns>
        public static List<Music.Model.Songs> GetAllSongs()
        {
            return Music.DAL.SongDataAcccess.GetAllSongs();
        }

        /// <summary>
        /// 获取最新上传的所有歌曲对象
        /// </summary>
        /// <param name="count">获取多少首最新上传的歌曲</param>
        /// <returns></returns>
        public static List<Music.Model.Songs> GetNewSongs(int count)
        {
            return Music.DAL.SongDataAcccess.GetNewSongs(count);
        }

        /// <summary>
        /// 获取最热门的所有歌曲对象
        /// </summary>
        /// <param name="count">获取多少首最热门的歌曲</param>
        /// <returns></returns>
        public static List<Music.Model.Songs> GetHotSongs(int count)
        {
            return Music.DAL.SongDataAcccess.GetHotSongs(count);
        }

        /// <summary>
        /// 获取指定用户上传的歌曲列表
        /// </summary>
        /// <param name="id">上传用户的ID</param>
        /// <returns></returns>
        public static List<Music.Model.Songs> GetSongsByUser(int id)
        {
            return Music.DAL.SongDataAcccess.GetSongsByUser(id);
        }

        /// <summary>
        /// 按歌曲名获取歌曲列表
        /// </summary>
        /// <param name="songName">要查询的歌曲名称</param>
        /// <returns></returns>
        public static List<Music.Model.Songs> GetSongsBySongName(string songName)
        {
            return Music.DAL.SongDataAcccess.GetSongsBySongName(songName);
        }

        /// <summary>
        /// 按歌手名获取歌曲列表
        /// </summary>
        /// <param name="singer">要查询的歌手名</param>
        /// <returns></returns>
        public static List<Music.Model.Songs> GetSongsBySinger(string singer)
        {
            return Music.DAL.SongDataAcccess.GetSongsBySinger(singer);
        }
    }
}
