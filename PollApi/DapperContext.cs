using System.Data;
using Microsoft.Data.SqlClient;

namespace PollApi
{
    public class DapperContext
    {
        private string _connectionString { get; set; }
        public DapperContext()
        {
            _connectionString = "Server=ASPOSE\\SQLEXPRESS01;Database=pollmd;Trusted_Connection=True;";
        }

        public IDbConnection CreateConecton() => new SqlConnection("Server=ASPOSE\\SQLEXPRESS01;Database=pollmd;Trusted_Connection=True;");
    }
}
