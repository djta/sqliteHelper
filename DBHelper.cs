using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YCFramework.Common;
using LitJson;
using System.Data.SQLite;
namespace YCtimer
{
    /// <summary>
    /// SQLite数据库操作类
    /// </summary>
    public static class DBHelper
    {
        public static SQLiteHelper sqliteHelper ;
        private static SQLiteCommand cmd ;
        private static SQLiteConnection conn;
        
        static DBHelper()
        {          
           OpenDB();          
        }

     
        /// <summary>
        /// 打开数据库
        /// </summary>
        public static void OpenDB(){
            conn = new SQLiteConnection(config.DataSource);//连接数据库，config.DataSource数据库连接字符串
            Log("dbpath:" + config.DataSource); //打印日志          
            cmd = new SQLiteCommand();
            cmd.Connection = conn;
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
                Log("conn_open");
            }
            sqliteHelper = new SQLiteHelper(cmd);
            Log("new sqliteHelper");
        }

        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public static void CloseDB()
        {
            Log(" conn.Close()");
            conn.Close();
           
        }


      
        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="msg"></param>
        public static void Log(string msg)
        {
            Log(msg, "i");
        }

        public static void Log(string msg, string level)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["time"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:dd");
            dic["info"] = msg;
            dic["level"] = level;
            string json = LitJson.JsonMapper.ToJson(dic);
            string path = Environment.CurrentDirectory + "/log/" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            FileControl.FileAdd(path, json + "\r\n");
        }
    }
}
