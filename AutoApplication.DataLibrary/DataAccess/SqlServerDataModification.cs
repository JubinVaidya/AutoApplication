using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace AutoApplication.DataLibrary.DataAccess
{
   public static class SqlServerDataModification
    {
        public static int SaveData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(SqlServerConnection.CnnValue()))
            {
                return cnn.Execute(sql, data);
            }
        }

    }
}
