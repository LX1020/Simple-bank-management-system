using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ZJM
{
    class SQLHelper
    {
        private static string FLastError;
        /// 最近一次异常信息
        public static string LastError
        {
            get { return FLastError; }
        }
        /// 通用异常处理函数
        private static void HandleException(Exception e)
        {
            if (e is SqlException)
            {
                FLastError = string.Format("在打开连接时出现连接级别的错误:{0}", e.Message);
            }
            else if (e is InvalidOperationException)
            {
                FLastError = e.Message;
            }
            else if (e is DBConcurrencyException)
            {
                FLastError = string.Format("尝试执行 INSERT、UPDATE 或 DELETE 语句，但没有记录受到影响:{0}", e.Message);
            }
            else
            {
                FLastError = string.Format("未预料的异常:", e.Message);
            }
        }
        /// 获取数据库连接字符串、子类覆盖后自行修改
        private static string GetConnectionString()
        {
            return "Data Source=.;Initial Catalog=MyDatabase;Integrated Security=True";
        }

        private static SqlConnection OpenConnection()
        {
            return new SqlConnection(GetConnectionString());
        }
        /// 无返回值的SQL语句执行
        public static int ExecNonSQL(string ASql, params SqlParameter[] AParams)
        {
            using (SqlConnection Conn = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    //Open异常捕获
                    Conn.Open();
                    using (SqlCommand Cmd = Conn.CreateCommand())
                    {
                        Cmd.CommandText = ASql;
                        if (AParams != null)
                        {
                            foreach (SqlParameter param in AParams)
                            {
                                Cmd.Parameters.Add(param);
                            }
                        }
                        return Cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return -1;
        }
        /// 无返回值的SQL语句执行
        //执行select语句，返回单值
        public static string ExecOneSQL(string ASql, params SqlParameter[] AParams)
        {
            using (SqlConnection Conn = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    //Open异常捕获
                    Conn.Open();
                    using (SqlCommand Cmd = Conn.CreateCommand())
                    {
                        Cmd.CommandText = ASql;
                        if (AParams != null)
                        {
                            foreach (SqlParameter param in AParams)
                            {
                                Cmd.Parameters.Add(param);
                            }
                        }
                        return Cmd.ExecuteScalar().ToString();
                    }
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return "1";
        }
        //执行select语句，返回记录集
        public static DataSet ExecSQLByDataSet(string ASql, params SqlParameter[] AParams)
        {
            using (SqlConnection Conn = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    Conn.Open();
                    using (SqlCommand Cmd = Conn.CreateCommand())
                    {
                        Cmd.CommandText = ASql;
                        if (AParams != null)
                        {
                            foreach (SqlParameter param in AParams)
                            {
                                Cmd.Parameters.Add(param);
                            }
                        }

                        SqlDataAdapter Adapter = new SqlDataAdapter(Cmd);
                        DataSet Result = new DataSet();
                        Adapter.Fill(Result, "table");
                        return Result;
                    }
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
            return null;
        }
       
    }
}
