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
    public class RoomsNotUsedController : ApiController
    {
        // GET: api/RoomsNotUsed
        public IEnumerable<RoomModel> Get()
        {
            SqlConnection conn = DBConnections.GetConnection();
            SqlCommand cmd;
            SqlDataReader rdr;
            String query;
            List<RoomModel> output = new List<RoomModel>();

            try
            {
                conn.Open();


                //query = "select * from Room where Capacity = null";
                query = "select * from Room r where concat(r.building, r.RoomNo) not in (select concat(c.Building, c.RoomNo) from class c)";


                cmd = new SqlCommand(query, conn);

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
                output.Clear();
                throw e;

            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return output;
            //return new string[] { "value1", "value2" };
        }

        // GET: api/RoomsNotUsed/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/RoomsNotUsed
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/RoomsNotUsed/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/RoomsNotUsed/5
        public void Delete(int id)
        {
        }
    }
}
