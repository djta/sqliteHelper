# SqliteHelper
C#的SQLITEHELPER，根据adriancs为基础，进行完善
sqlite是文件型数据库，具有使用方便、轻量级的特点。适合做像CS架构下的本地数据库。
DBHelper.cs是一个使用的例子。调用方法如下：

    DataTable dt = DBHelper.sqliteHelper.Select("select * from url_task");

