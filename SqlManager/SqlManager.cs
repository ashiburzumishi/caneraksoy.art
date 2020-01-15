using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlManager
{
    public class SqlManager
    {
        static SqlConnection GetConnection()
        {
            var connection = new SqlConnection("Server=94.73.145.4;Database=u8545856_caner;User Id=u8545856_caner;Password=WHon47L3;");
            connection.Open();
            return connection;
            
        }

        public static DataTable GetDataTable (SqlCommand command)
        {
            command.Connection = GetConnection();
            var datatable = new DataTable();
            datatable.Load(command.ExecuteReader());
            command.Connection.Dispose();
            return datatable;
        }
    }
}
