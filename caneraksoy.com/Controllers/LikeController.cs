using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace caneraksoy.com.Controllers
{
    [RoutePrefix("caner")]
    public class LikeController : ApiController
    {
        // GET api/<controller>
        [HttpGet]
        [Route("getlikes")]
        public IHttpActionResult Get()
        {
            try
            {
                var likes = new List<Photograph>();
                SqlCommand command = new SqlCommand("Select * From photographs");
                var datatable = SqlManager.SqlManager.GetDataTable(command);
                foreach (DataRow row in datatable.Rows)
                {
                    likes.Add(new Photograph
                    {

                        Id = int.Parse(row["Id"].ToString()),
                        Like = int.Parse(!string.IsNullOrEmpty(row["likeCount"].ToString()) ? row["likeCount"].ToString() : "0"),


                    }
                        );
                }
                return Ok(likes);
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}