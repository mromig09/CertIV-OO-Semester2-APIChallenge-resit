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
    public class ComputerController : ApiController
    {
        // GET: api/Computer
        public IEnumerable<ComputerModel> Get()
        {
            SqlConnection conn = DBConnections.GetConnection();
            SqlCommand cmd;
            SqlDataReader rdr;
            string query;
            List<ComputerModel> output = new List<ComputerModel>();
            try
            {
                conn.Open();
                query = "select * from Computer";
                cmd = new SqlCommand(query, conn);
                //read the data for that command
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    output.Add(new ComputerModel(Int32.Parse(rdr["Number"].ToString()),
                                                 Int32.Parse(rdr["AssembledYear"].ToString()),
                                                 rdr["Building"].ToString(),
                                                 Int32.Parse(rdr["RoomNo"].ToString())));

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
                    conn.Close();
            }
            return output;
            //return new string[] { "value1", "value2" };
        }

        // GET: api/Computer/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Computer
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Computer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Computer/5
        public void Delete(int id)
        {
        }
    }
}
