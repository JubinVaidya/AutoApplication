using AutoApplication.DataLibrary.DataAccessServices;
using AutoApplication.DataLibrary.Model;
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
    public class SqlServerFindData : ISqlServerFindData
    {
        public IList<T> FindData<T>(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(SqlServerConnection.CnnValue()))
            {
                return cnn.Query<T>(sql).ToList();
            }
        }

        public IList<T> FindData<T>(string sql, int id)
        {
            using (IDbConnection cnn = new SqlConnection(SqlServerConnection.CnnValue()))
            {
                return cnn.Query<T>(sql, new {@AutoID = id }).ToList();
            };
        }

    }
}
