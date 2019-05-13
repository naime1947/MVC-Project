using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVCProject.DBGateWay
{
    public class DBContext
    {
        protected SqlConnection Connection { get; set; }
        protected SqlDataReader Reader { get; set; }
        protected SqlCommand Command { get; set; }
        protected SqlDataAdapter sqlDataAdapter { get; set; }

        public DBContext()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            Connection = new SqlConnection(connectionString);
        }
    }
}