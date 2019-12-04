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
    public class RoomsUsedController : ApiController
    {
        // GET: api/RoomsUsed
        public IEnumerable<RoomUsedModel> Get()
        {
            SqlConnection conn = DBConnections.GetConnection();
            SqlCommand cmd;
            SqlDataReader rdr;
            String query;

            List<RoomUsedModel> output = new List<RoomUsedModel>();

            try
            {
                conn.Open();


                query = "select * from Room r where concat(r.building, r.RoomNo) in (select concat(c.Building, c.RoomNo) from class c)";
                cmd = new SqlCommand(query, conn);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    output.Add(new RoomUsedModel(rdr["Building"].ToString(),
                                                 Int32.Parse(rdr["RoomNo"].ToString()),
                                                 Int32.Parse(rdr["Capacity"].ToString())));
                                                 //rdr["classCode"].ToString(),
                                                 //rdr["name"].ToString(),
                                                 //rdr["cLbuilding"].ToString(),
                                                 //Int32.Parse(rdr["cLRoom"].ToString())));

                }

            }
            catch (Exception e)
            {
                output.Clear();
                throw e;
                //output.Add(e.Message);

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

        // GET: api/RoomsUsed/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/RoomsUsed
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/RoomsUsed/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/RoomsUsed/5
        public void Delete(int id)
        {
        }
    }
}
