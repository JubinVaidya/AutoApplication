using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApplication.DataLibrary.DataAccess
{
    public static class SqlServerDataAccess
    {
        public static IList<T> LoadData<T>(string sql)
        {
            using(IDbConnection cnn = new SqlConnection(SqlServerConnection.CnnValue()))
            {
                return cnn.Query<T>(sql).ToList();
            }
        }

        public static int SaveData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(SqlServerConnection.CnnValue()))
            {
                return cnn.Execute(sql, data);
            }
        }

    }
}
