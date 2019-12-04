using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace apiWebApplication1
{
    public class DBConnections
    {
        public static SqlConnection GetConnection()
        {

            string ConnString = "Server=tcp:civapi.database.windows.net,1433;Initial Catalog=civapi;User ID=civ_user;Password=Monday1330;";
                //@"Server=tcp:civapi.database.windows.net,1433; database=civapi;User ID=civ_user;Password=Monday1330;";

            return new SqlConnection(ConnString);
        }
    }
}