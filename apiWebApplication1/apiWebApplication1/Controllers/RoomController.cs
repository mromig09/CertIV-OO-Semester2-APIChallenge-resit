using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using apiWebApplication1.Models;
using System.Data;

namespace apiWebApplication1.Controllers
{
    public class RoomController : ApiController
    {
        // GET: api/Room
        public IEnumerable<RoomModel> Get()
        {
            SqlConnection conn = DBConnections.GetConnection();

            SqlCommand cmd;
            SqlDataReader rdr;
            string query;
            List<RoomModel> output = new List<RoomModel>();

            try
            {

                conn.Open();

                query = "select * from Room";
                cmd = new SqlCommand(query, conn);

                //read the data for that command
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    output.Add(new RoomModel(rdr["Building"].ToString(),
                                                Int32.Parse(rdr["RoomNo"].ToString()),
                                                Int32.Parse(rdr["Capacity"].ToString())));
                }

            }
            catch (Exception e)
            {
                throw e;

                //throw e;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }
            return output;
            //return new string[] { "value1", "value2" };
        }

        // GET: api/Room/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Room
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Room/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Room/5
        public void Delete(int id)
        {
        }
    }
}
