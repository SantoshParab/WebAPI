using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BMSWebAPI.Models;
using BMSWebAPI.DBAccessLayers;

namespace BMSWebAPI.Controllers
{
    public class ReportsController : ApiController
    {
        Db dblayer = new Db();

        [AcceptVerbs("POST")]
        public IHttpActionResult BulkReceived([FromBody]ReportInput reportInput)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (reportInput.FromDate == null)
                {
                    reportInput.FromDate = new DateTime(2021, 01, 01);
                }

                if (reportInput.ToDate == null)
                {
                    reportInput.ToDate = DateTime.Today;
                }

                var report = dblayer.BulkReceived(reportInput);

                return Ok(report);
            }

            catch (Exception)
            {
                throw;
            }

        }

        [AcceptVerbs("POST")]
        public IHttpActionResult Bulk([FromBody]ReportInput reportInput)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (reportInput.FromDate == null)
                {
                    reportInput.FromDate = new DateTime(2021, 01, 01);
                }

                if (reportInput.ToDate == null)
                {
                    reportInput.ToDate = DateTime.Today;
                }

                var report = dblayer.Bulk(reportInput);

                return Ok(report);
            }

            catch (Exception)
            {
                throw;
            }

        }


        [AcceptVerbs("POST")]
        public IHttpActionResult BulkPlus([FromBody]ReportInput reportInput)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (reportInput.FromDate == null)
                {
                    reportInput.FromDate = new DateTime(2021, 01, 01);
                }

                if (reportInput.ToDate == null)
                {
                    reportInput.ToDate = DateTime.Today;
                }

                List<BulkPlusOutput> report = dblayer.BulkPlus(reportInput);

                return Ok(report);
            }

            catch (Exception)
            {
                throw;
            }

        }

        [AcceptVerbs("POST")]
        public IHttpActionResult SampleReceive([FromBody]ReportInput reportInput)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (reportInput.FromDate == null)
                {
                    reportInput.FromDate = new DateTime(2021, 01, 01);
                }

                if (reportInput.ToDate == null)
                {
                    reportInput.ToDate = DateTime.Today;
                }

                var report = dblayer.SampleReceive(reportInput);

                return Ok(report);
            }

            catch (Exception)
            {
                throw;
            }

        }

        [AcceptVerbs("POST")]
        public IHttpActionResult Sample([FromBody]ReportInput reportInput)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (reportInput.FromDate == null)
                {
                    reportInput.FromDate = new DateTime(2021, 01, 01);
                }

                if (reportInput.ToDate == null)
                {
                    reportInput.ToDate = DateTime.Today;
                }

                var report = dblayer.Sample(reportInput);

                return Ok(report);
            }

            catch (Exception)
            {
                throw;
            }

        }

        [AcceptVerbs("POST")]
        public IHttpActionResult SamplePlus([FromBody]ReportInput reportInput)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (reportInput.FromDate == null)
                {
                    reportInput.FromDate = new DateTime(2021, 01, 01);
                }

                if (reportInput.ToDate == null)
                {
                    reportInput.ToDate = DateTime.Today;
                }

                List<SamplePlusOutput> report = dblayer.SamplePlus(reportInput);

                return Ok(report);
            }

            catch (Exception)
            {
                throw;
            }

        }

        [AcceptVerbs("POST")]
        public IHttpActionResult BulkPlate([FromBody]ReportInput reportInput)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (reportInput.FromDate == null)
                {
                    reportInput.FromDate = new DateTime(2021, 01, 01);
                }

                if (reportInput.ToDate == null)
                {
                    reportInput.ToDate = DateTime.Today;
                }

                //List<BulkOutput> report = dblayer.BulkPlate(reportInput);

                //return Ok(report);

                ResponseClass resp = new ResponseClass();
                var result = dblayer.BulkPlate(reportInput);

                if (result.Item1.Rows.Count > 0)
                {
                    resp.TotalRecords = result.Item2.ToString();
                    resp.Data = result.Item1;
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

        [AcceptVerbs("POST")]
        public IHttpActionResult PlateData([FromBody]ReportInput reportInput)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (reportInput.FromDate == null)
                {
                    reportInput.FromDate = new DateTime(2021, 01, 01);
                }

                if (reportInput.ToDate == null)
                {
                    reportInput.ToDate = DateTime.Today;
                }

                //List<BulkOutput> report = dblayer.BulkPlate(reportInput);

                //return Ok(report);

                ResponseClass resp = new ResponseClass();
                var result = dblayer.PlateData(reportInput);

                if (result.Item1.Rows.Count > 0)
                {
                    // resp.TotalRecords = result.Item2.ToString();
                    resp.Data = result.Item1;
                    resp.DataCount = result.Item2;
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