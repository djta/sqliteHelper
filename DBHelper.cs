using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YCFramework.Common;
using LitJson;
using System.Data.SQLite;
namespace YCtimer
{
    public static class DBHelper
    {
        public static SQLiteHelper sqliteHelper ;
        private static SQLiteCommand cmd ;
        private static SQLiteConnection conn;
        
        static DBHelper()
        {          
           OpenDB();          
        }

        public static void Begin()
        {
            return;
        }

        public static void OpenDB(){           
            conn = new SQLiteConnection(config.DataSource);
            Log("dbpath:" + config.DataSource);           
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
