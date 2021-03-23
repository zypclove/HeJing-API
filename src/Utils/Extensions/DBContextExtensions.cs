using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace UltraNuke.CommonMormon.Utils.Extensions
{
    public static class DBContextExtensions
    {
        /// <summary>
        /// 执行SQL返回受影响的行数
        /// </summary>
        public static int ExecSqlNoQuery<T>(this DbContext db, string sql, SqlParameter[] sqlParams = null) where T : new()
        {
            return ExecuteNoQuery<T>(db, sql, sqlParams);
        }

        /// <summary>
        /// 执行存储过程返回IEnumerable数据集
        /// </summary>
        public static IEnumerable<T> ExecProcReader<T>(this DbContext db, string sql, SqlParameter[] sqlParams = null) where T : new()
        {
            return Execute<T>(db, sql, CommandType.StoredProcedure, sqlParams);
        }

        /// <summary>
        /// 执行sql返回IEnumerable数据集
        /// </summary>
        public static IEnumerable<T> ExecSqlReader<T>(this DbContext db, string sql, SqlParameter[] sqlParams = null) where T : new()
        {
            return Execute<T>(db, sql, CommandType.Text, sqlParams);
        }

        private static int ExecuteNoQuery<T>(this DbContext db, string sql, SqlParameter[] sqlParams) where T : new()
        {
            DbConnection connection = db.Database.GetDbConnection();
            DbCommand cmd = connection.CreateCommand();
            int result = 0;
            db.Database.OpenConnection();
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            if (sqlParams != null)
            {
                cmd.Parameters.AddRange(sqlParams);
            }
            result = cmd.ExecuteNonQuery();
            db.Database.CloseConnection();
            return result;
        }

        private static IEnumerable<T> Execute<T>(this DbContext db, string sql, CommandType type, SqlParameter[] sqlParams) where T : new()
        {
            DbConnection connection = db.Database.GetDbConnection();
            DbCommand cmd = connection.CreateCommand();
            db.Database.OpenConnection();
            cmd.CommandText = sql;
            cmd.CommandType = type;
            if (sqlParams != null)
            {
                cmd.Parameters.AddRange(sqlParams);
            }
            DataTable dt = new DataTable();
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                dt.Load(reader);
            }
            db.Database.CloseConnection();
            return dt.ToCollection<T>();
        }
    }
}
