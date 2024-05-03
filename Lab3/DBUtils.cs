using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Lab3
{
    class DBUtils
    {
        public static MySqlConnection GetDBConnection()
        {
            string host = "localhost";
            int port = 3306;
            string database = "individ";
            string username = "n7lots";
            string password = "database";

            return DBMySQLUtils.GetDBConnection(host, port, database, username, password);
        }
    }
}
