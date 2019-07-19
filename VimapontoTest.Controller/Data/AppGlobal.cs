using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace VimapontoTest.Controller.Data
{
    public class AppGlobal : IDisposable
    {
        protected DSVimaponto dsGlobal = new DSVimaponto();
        protected SqlDataAdapter dtAdapter = null;
        protected DataTable dtTable = null;
        protected String sQuery = "";
        protected static readonly String formatoDataBD = "yyyyMMdd hh:MM:ss";
        public static readonly String conn = "Data Source=MASTRO;Initial Catalog=BDVimaponto;Integrated Security=True";

        private static SqlConnection sqlConnection;
        private static string sqlConnectionString;

        public AppGlobal()
        { }

        private static string DbConnectionString()
        {
            sqlConnectionString = conn;
            return sqlConnectionString;
        }

        protected static SqlConnection DbConnection()
        {
            sqlConnection = new SqlConnection(conn);
            sqlConnection.Open();
            return sqlConnection;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
