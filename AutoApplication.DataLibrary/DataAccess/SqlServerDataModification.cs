using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace AutoApplication.DataLibrary.DataAccess
{
    public class SqlServerDataModification : ISqlServerDataModification
    {
        public int SaveData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(SqlServerConnection.CnnValue()))
            {
                return cnn.Execute(sql, data);
            }
        }

    }
}
