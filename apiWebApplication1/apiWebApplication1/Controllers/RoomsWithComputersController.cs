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
    public class RoomsWithComputersController : ApiController
    {
        // GET: api/RoomsWithComputers
        public IEnumerable<RoomsWithComputersModel> Get()
        {
            SqlConnection conn = DBConnections.GetConnection();
            SqlCommand cmd;
            SqlDataReader rdr;
            String query;

            List<RoomsWithComputersModel> output = new List<RoomsWithComputersModel>();

            try
            {
                conn.Open();

                query = "select * from Room r where concat(r.building, r.RoomNo) in (select concat(c.Building, c.RoomNo) from computer c)";
                /*query = "select * " +
                    "from Room " +
                    "inner join Rooms on Room.RoomsComputer = RoomsComputer.roomNo " +
                    "where Room.RoomsComputer is not null";*/
                cmd = new SqlCommand(query, conn);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    output.Add(new RoomsWithComputersModel(rdr["Building"].ToString(),
                                                           Int32.Parse(rdr["RoomNo"].ToString()),
                                                           Int32.Parse(rdr["Capacity"].ToString())));
                                                           //Int32.Parse(rdr["number"].ToString()),
                                                           //Int32.Parse(rdr["assembledYear"].ToString()),
                                                           //rdr["cbuilding"].ToString(),
                                                           //Int32.Parse(rdr["cRoomNo"].ToString())));

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

        // GET: api/RoomsWithComputers/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/RoomsWithComputers
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/RoomsWithComputers/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/RoomsWithComputers/5
        public void Delete(int id)
        {
        }
    }
}
