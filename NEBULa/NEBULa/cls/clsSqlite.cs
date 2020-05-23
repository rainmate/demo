using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data;

namespace NEBULa.cls
{
    class clsSqlite
    {
        /// <summary>
        /// 数据库
        /// </summary>
        public static string dataBasePath;

        public static string dataBasePasssord;

        /// <summary>
        /// 获取连接
        /// </summary>
        /// <returns></returns>
        private static SQLiteConnection getSQLiteConnection()
        {
            SQLiteConnection conn = null;
            try
            {
                conn = new SQLiteConnection();
                SQLiteConnectionStringBuilder connStr = new SQLiteConnectionStringBuilder();
                connStr.DataSource = dataBasePath;
                connStr.Password = dataBasePasssord;                        //设置密码，SQLite ADO.NET实现了数据库密码保护
                conn.ConnectionString = connStr.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("连接数据库异常:" + ex.Message);
            }
            return conn;
        }

        #region 执行查询

        /// <summary>
        /// 执行SQL，返回影响的记录数
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int ExecuteSql(string sql)
        {
            int iResult = -1;
            using (SQLiteConnection conn = getSQLiteConnection())
            {
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    try
                    {
                        conn.Open();
                        iResult = cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine( ex.Message);
                    }
                }
            }
            return iResult;
        }
        #endregion


        public static bool checkeUser(string userName, string password)
        {
            bool Flag = false;
            try
            {
                string sql = string.Format("{0} where code='{1}' and password='{2}'", "select count(0) from infoclient", userName, password);
                if (clsSqlite.ExecuteSqldt(sql).Rows.Count > 0)
                {
                    Flag = true;

                }
                return Flag;
            }
            catch (Exception ex)
            {
                return Flag;
            }
        }


        #region 执行查询
        /// <summary>
        /// 执行SQL，返回影响的DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable ExecuteSqldt(string sql)
        {
            DataTable iResult =null;
            DataSet ds = new DataSet();
            using (SQLiteConnection conn = getSQLiteConnection())
            {
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        SQLiteDataAdapter da =new SQLiteDataAdapter(cmd);
                        da.Fill(ds,"poc");

                        iResult = ds.Tables[0];
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine( ex.Message);
                    }
                }
            }
            return iResult;
        }
        #endregion
    }
}
