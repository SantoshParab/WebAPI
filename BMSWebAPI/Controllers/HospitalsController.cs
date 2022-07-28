using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using BMSWebAPI.Models;
using BMSWebAPI.DBAccessLayers;

namespace BMSWebAPI.Controllers
{
    public class HospitalsController : ApiController
    {
        Db dblayer = new Db();

        [AcceptVerbs("GET", "POST")]
        public IHttpActionResult GetHospitals()
        {
            try

            {
                if (!ModelState.IsValid)

                {

                    return BadRequest(ModelState);

                }

                DataTable hospital = dblayer.GetHospitals();

                if (hospital!=null)
                {
                    return Ok(hospital);
                }
                else
                {
                    return Ok(hospital);
                }

            }

            catch (Exception)

            {
                throw;

            }

        }

        public IHttpActionResult CreatePHC([FromBody] Hospital cs)
        {
            Hospital usr = new Models.Hospital();
            try

            {
                if (!ModelState.IsValid)

                {

                    return BadRequest(ModelState);

                }

                // { PHC: "Test PHC", Code: "TTT",Zone:"North",Email:"s@gmail.com" };
                int retval = dblayer.CreatePHC(cs);
                Response res = new Response();
                if (retval == 0)
                {
                    res.StatusCode = "0";
                    res.Message = "Unable to Create PHC..Please Try Again";
                    return Ok(res);
                }
                else
                {
                    res.StatusCode = "1";
                    res.Message = "PHC Created Successfully";
                    return Ok(res);
                }

            }

            catch (Exception)

            {
                return Ok(usr);

            }

        }

        [AcceptVerbs("GET", "POST")]
        public IHttpActionResult EditPHC([FromBody] Hospital cs)
        {
            Hospital usr = new Models.Hospital();
            try

            {
                if (!ModelState.IsValid)

                {

                    return BadRequest(ModelState);

                }

                //{ PHC: "Test PHC", Code: "TTT",Zone:"North",Email:"s@gmail.com",IsActive:"1",HospitalId:"84" };
                int retval = dblayer.EditPHC(cs);
                Response res = new Response();
                if (retval == 0)
                {
                    res.StatusCode = "0";
                    res.Message = "Unable to Change PHC Details..Please Try Again";
                    return Ok(res);
                }
                else
                {
                    res.StatusCode = "1";
                    res.Message = "PHC Details Changed Successfully";
                    return Ok(res);
                }

            }

            catch (Exception)

            {
                return Ok(usr);

            }

        }

        [AcceptVerbs("GET", "POST")]
        public IHttpActionResult GetPHC([FromBody] Hospital obj)
        {
            DataTable dt = new DataTable();
            try
            {

                if (!ModelState.IsValid)

                {

                    return BadRequest(ModelState);

                }
                //{Index: "1",PHC: "SIN" }
                var result = dblayer.GetAllPHC(obj);

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
