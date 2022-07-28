using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BMSWebAPI.Models;
using BMSWebAPI.DBAccessLayers;
using System.Data;

namespace BMSWebAPI.Controllers
{
    public class UsersController : ApiController
    {
        Db dblayer = new Db();

        [AcceptVerbs("GET", "POST")]
        public IHttpActionResult login([FromBody] User cs)
        {
            User usr = new Models.User();
            try
            
            {
                if (!ModelState.IsValid)

                {

                    return BadRequest(ModelState);

                }

               usr= dblayer.GetUsers(cs.UserName.Trim(),cs.Password.Trim());

                if (usr.UserName != string.Empty)
                {
                    return Ok(usr);
                }
                else
                {
                    return Ok(usr);
                }
                
            }

            catch (Exception)

            {
                return Ok(usr);

            }

        }

        [AcceptVerbs("GET", "POST")]
        public IHttpActionResult CreateUser([FromBody] User cs)
        {
            User usr = new Models.User();
            try

            {
                if (!ModelState.IsValid)

                {

                    return BadRequest(ModelState);

                }
       
               // { UserName: "Receiver1", Password: "Test123",UserTypeId:"1",CreatedBy:"2" };
                int retval = dblayer.CreateUser(cs);
                Response res = new Response();
                if (retval==0)
                {
                    res.StatusCode = "0";
                    res.Message = "Unable to Create User..Please Try Again";
                    return Ok(res);
                }
                else
                {
                    res.StatusCode = "1";
                    res.Message = "User Created Successfully";
                    return Ok(res);
                }

            }

            catch (Exception)

            {
                return Ok(usr);

            }

        }

        [AcceptVerbs("GET", "POST")]
        public IHttpActionResult EditUser([FromBody] User cs)
        {
            User usr = new Models.User();
            try

            {
                if (!ModelState.IsValid)

                {

                    return BadRequest(ModelState);

                }

                //{ UserName: "Receiver1", Password: "Test123",UserTypeId: "1",CreatedBy:"2",UserId:"1",IsActive:"1"}
                int retval = dblayer.EditUser(cs);
                Response res = new Response();
                if (retval == 0)
                {
                    res.StatusCode = "0";
                    res.Message = "Unable to Change User Details..Please Try Again";
                    return Ok(res);
                }
                else
                {
                    res.StatusCode = "1";
                    res.Message = "User Details Changed Successfully";
                    return Ok(res);
                }

            }

            catch (Exception)

            {
                return Ok(usr);

            }

        }

        [AcceptVerbs("GET", "POST")]
        public IHttpActionResult GetUsers([FromBody] User  obj)
        {
            DataTable dt = new DataTable();
            try
            {

                if (!ModelState.IsValid)

                {

                    return BadRequest(ModelState);

                }
                //{Index: "1",UserName: "Receiver1" }
                var result = dblayer.GetAllUsers(obj);

                ResponseClass resp = new ResponseClass();

                if (result.Item1.Rows.Count > 0)
                {
                    resp.Data = result.Item1;
                    resp.TotalRecords = result.Item2.ToString();
                    //string json = JsonConvert.SerializeObject(resp);
                    return Ok(resp);

                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception)
            {
                throw;

            }

        }

        [AcceptVerbs("GET", "POST")]
        public IHttpActionResult GetUser([FromBody] User usr)
        {
            DataTable dt = new DataTable();
            try
            {

                if (!ModelState.IsValid)

                {

                    return BadRequest(ModelState);

                }
               // { UserName: "Receiver1"}

                var result = dblayer.GetUser(usr.UserName);

                ResponseClass resp = new ResponseClass();

                if (result.Item1.Rows.Count > 0)
                {
                    resp.Data = result.Item1;
                    resp.TotalRecords = result.Item2.ToString();
                    //string json = JsonConvert.SerializeObject(resp);
                    return Ok(resp);

                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception)
            {
                throw;

            }

        }

        [AcceptVerbs("GET", "POST")]
        public IHttpActionResult GetUserTypes()
        {
            try

            {
                if (!ModelState.IsValid)

                {

                    return BadRequest(ModelState);

                }

                DataTable usrtype = dblayer.GetUserTypes();

                if (usrtype != null)
                {
                    return Ok(usrtype);
                }
                else
                {
                    return NotFound();
                }

            }

            catch (Exception)

            {
                throw;

            }

        }
    }
}
