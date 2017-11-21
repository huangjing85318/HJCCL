using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using HJCCL.Utils;

namespace HJCCL.Services
{
    public class SqlHelper
    {
        private string connString;
        /// <summary>
        /// 设置数据库连接字符串
        /// </summary>
        public string ConnString
        {
            set { connString = value; }
        }
        /// <summary>
        /// 执行一个查询,并返回查询结果
        /// </summary>
        /// <param name="sql">要执行的SQL语句</param>
        /// <param name="commandType">要执行的查询语句的类型，如存储过程或者SQL文本命令</param>
        /// <param name="parameters">Transact-SQL 语句或存储过程的参数数组</param>
        /// <returns></returns>
        public DataTable ExecuteDataTable(string sql, CommandType commandType, SqlParameter[] parameters)
        {
            DataTable data = new DataTable();//实例化DataTable，用于装载查询结果集
            if (connString.Length > 0)
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.CommandType = commandType; //设置command的CommandType为指定的CommandType
                        //如果同时传入了参数，则添加这些参数
                        if (parameters != null)
                        {
                            foreach (SqlParameter parameter in parameters)
                            {
                                command.Parameters.Add(parameter);
                            }
                        }
                        //通过包含查询SQL的SqlCommand实例来实例化SqlDataAdapter
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(data); //填充DataTable
                    }
                }
            }
            else
            {
                
            }
            return data;
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="sql">要执行的查询SQL文本命令</param>
        /// <returns></returns>
        public SqlDataReader ExecuteReader(string sql)
        {
            return ExecuteReader(sql, CommandType.Text, null);
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="sql">要执行的SQL语句</param>
        /// <param name="commandType">要执行的查询语句的类型，如存储过程或者SQL文本命令</param>
        /// <returns></returns>
        public SqlDataReader ExecuteReader(string sql, CommandType commandType)
        {
            return ExecuteReader(sql, commandType, null);
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="sql">要执行的SQL语句</param>
        /// <param name="commandType">要执行的查询语句的类型，如存储过程或者SQL文本命令</param>
        /// <param name="parameters">Transact-SQL 语句或存储过程的参数数组</param>
        /// <returns></returns>
        public SqlDataReader ExecuteReader(string sql, CommandType commandType, SqlParameter[] parameters)
        {
            SqlConnection connection = new SqlConnection(connString);
            SqlCommand command = new SqlCommand(sql, connection);
            //如果同时传入了参数，则添加这些参数
            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }
            connection.Open();
            //CommandBehavior.CloseConnection参数指示关闭Reader对象时关闭与其关联的Connection对象
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="sql">要执行的查询SQL文本命令</param>
        /// <returns></returns>
        public SqlResult ExecuteScalar(string sql)
        {
            return ExecuteScalar(sql, CommandType.Text, null);
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="sql">要执行的SQL语句</param>
        /// <param name="commandType">要执行的查询语句的类型，如存储过程或者SQL文本命令</param>
        /// <returns></returns>
        public SqlResult ExecuteScalar(string sql, CommandType commandType)
        {
            return ExecuteScalar(sql, commandType, null);
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="sql">要执行的SQL语句</param>
        /// <param name="commandType">要执行的查询语句的类型，如存储过程或者SQL文本命令</param>
        /// <param name="parameters">Transact-SQL 语句或存储过程的参数数组</param>
        /// <returns></returns>
        public SqlResult ExecuteScalar(string sql, CommandType commandType, SqlParameter[] parameters)
        {
            SqlResult result = null;
            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = commandType;//设置command的CommandType为指定的CommandType
                    //如果同时传入了参数，则添加这些参数
                    if (parameters != null)
                    {
                        foreach (SqlParameter parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    connection.Open();//打开数据库连接
                    result.status = true;
                    result.context =ConvertObject.ToString(command.ExecuteScalar());
                }
            }
            return result;//返回查询结果
        }
        /// <summary>
        /// 对数据库执行增删改操作
        /// </summary>
        /// <param name="sql">要执行的查询SQL文本命令</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sql)
        {
            return ExecuteNonQuery(sql, CommandType.Text, null);
        }
        /// <summary>
        /// 对数据库执行增删改操作
        /// </summary>
        /// <param name="sql">要执行的SQL语句</param>
        /// <param name="commandType">要执行的查询语句的类型，如存储过程或者SQL文本命令</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sql, CommandType commandType)
        {
            return ExecuteNonQuery(sql, commandType, null);
        }
        /// <summary>
        /// 对数据库执行增删改操作
        /// </summary>
        /// <param name="sql">要执行的SQL语句</param>
        /// <param name="commandType">要执行的查询语句的类型，如存储过程或者SQL文本命令</param>
        /// <param name="parameters">Transact-SQL 语句或存储过程的参数数组</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sql, CommandType commandType, SqlParameter[] parameters)
        {
            int count = 0;
            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = commandType;//设置command的CommandType为指定的CommandType
                    //如果同时传入了参数，则添加这些参数
                    if (parameters != null)
                    {
                        foreach (SqlParameter parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    connection.Open();//打开数据库连接
                    count = command.ExecuteNonQuery();
                }
            }
            return count;//返回执行增删改操作之后，数据库中受影响的行数
        }
        /// <summary>
        /// 返回当前连接的数据库中所有由用户创建的数据库
        /// </summary>
        /// <returns></returns>
        public DataTable GetTables()
        {
            DataTable data = null;
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();//打开数据库连接
                data = connection.GetSchema("Tables");
            }
            return data;
        }
    }
}
