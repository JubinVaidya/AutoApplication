using System;
using System.Configuration;

namespace AutoApplication.DataLibrary.DataAccess
{
    class SqlServerConnection
    {
        public static string CnnValue(string name = "AutoDealerVaidyaDB")
        {
            try
            {
                return ConfigurationManager.ConnectionStrings[name].ConnectionString;
            }
            catch (Exception ex)
            {
                
            }
            return null;
        }
    }
}
