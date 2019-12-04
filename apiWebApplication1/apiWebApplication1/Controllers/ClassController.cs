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
    public class ClassController : ApiController
    {
        // GET: api/Class
        public IEnumerable<ClassModel> Get()
        {
            SqlConnection conn = DBConnections.GetConnection();
            SqlCommand cmd;
            SqlDataReader rdr;
            string query;
            List<ClassModel> output = new List<ClassModel>();
            try
            {
                conn.Open();
                query = "select * from Class";
                cmd = new SqlCommand(query, conn);
                //read the data for that command
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    output.Add(new ClassModel(rdr["classCode"].ToString(),
                                              rdr["Name"].ToString(),
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
        }

        // GET: api/Class/5
        public ClassModel Get(string id)
        {
            SqlConnection conn = DBConnections.GetConnection();
            SqlCommand cmd;
            SqlDataReader rdr;
            String query;
            // ClassModel output = new ClassModel("classCode","name", "cLbuilding", 11);
            ClassModel output = new ClassModel();
            try
            {
                conn.Open();
                query = "select * from Class where ClassCode = '" + id + "'";
                cmd = new SqlCommand(query, conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    output = new ClassModel(rdr.GetValue(0).ToString(),
                             rdr.GetValue(1).ToString(),
                             rdr.GetValue(2).ToString(),
                             Int32.Parse(rdr.GetValue(3).ToString()));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }
            return output;
            /* public IEnumerable<ClassModel> Get()
             {
                 SqlConnection conn = DBConnections.GetConnection();
                 SqlCommand cmd;
                 SqlDataReader rdr;
                 string query;
                 List<ClassModel> output = new List<ClassModel>();
                 try
                 {
                     conn.Open();
                     query = "select ClassCode from Class";
                     cmd = new SqlCommand(query, conn);
                     //read the data for that command
                     rdr = cmd.ExecuteReader();
                     while (rdr.Read())
                     {
                         output.Add(new ClassModel(rdr["classCode"].ToString(),
                                                   rdr["Name"].ToString(),
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
                 return output;*/

        }

        // POST: api/Class
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Class/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Class/5
        public void Delete(int id)
        {
        }
    }
}
