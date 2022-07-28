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
    public class KitController : ApiController
    {
        Db dblayer = new Db();
        public IHttpActionResult CreateKit([FromBody] Kit cs)
        {
            Kit usr = new Models.Kit();
            try

            {
                if (!ModelState.IsValid)

                {

                    return BadRequest(ModelState);

                }

                // { TestingKitName: "New Test Kit"};
                int retval = dblayer.CreateKit(cs);
                Response res = new Response();
                if (retval == 0)
                {
                    res.StatusCode = "0";
                    res.Message = "Unable to Create Testing Kit..Please Try Again";
                    return Ok(res);
                }
                else
                {
                    res.StatusCode = "1";
                    res.Message = "Testing Kit Created Successfully";
                    return Ok(res);
                }

            }

            catch (Exception)

            {
                return Ok(usr);

            }

        }

        [AcceptVerbs("GET", "POST")]
        public IHttpActionResult EditKit([FromBody] Kit cs)
        {
            Kit usr = new Models.Kit();
            try

            {
                if (!ModelState.IsValid)

                {

                    return BadRequest(ModelState);

                }

                //{ TestingKitName: "Test Kit230", IsActive: "1",TestingKitId: "1"}
                int retval = dblayer.EditKit(cs);
                Response res = new Response();
                if (retval == 0)
                {
                    res.StatusCode = "0";
                    res.Message = "Unable to Change Kit Details..Please Try Again";
                    return Ok(res);
                }
                else
                {
                    res.StatusCode = "1";
                    res.Message = "Kit Details Changed Successfully";
                    return Ok(res);
                }

            }

            catch (Exception)

            {
                return Ok(usr);

            }

        }

        [AcceptVerbs("GET", "POST")]
        public IHttpActionResult GetKit([FromBody] Kit obj)
        {
            DataTable dt = new DataTable();
            try
            {

                if (!ModelState.IsValid)

                {

                    return BadRequest(ModelState);

                }
                //{Index: "1",TestingKitName: "Test Kit123" }
                var result = dblayer.GetAllkits(obj);

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
    }
}
