using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BMSWebAPI.Models;
using BMSWebAPI.DBAccessLayers;
using System.Threading.Tasks;
using System.IO;
using System.Web;
using ExcelDataReader;
using System.Data;
using System.IO;
using Newtonsoft.Json;
using BMSWebAPI.Common;

namespace BMSWebAPI.Controllers
{
    public class SamplesController : ApiController
    {
        Db dblayer = new Db();



        //[AcceptVerbs("GET", "POST")]
        //public Task<HttpResponseMessage> ImportFile(int hospitalID)
        //{
        //    var folderName = "uploads";
        //    var PATH = HttpContext.Current.Server.MapPath("~/App_Data/Uploads");
        //    var rootUrl = Request.RequestUri.AbsoluteUri.Replace(Request.RequestUri.AbsolutePath, String.Empty);
        //    if (Request.Content.IsMimeMultipartContent())
        //    {

        //        var streamProvider = new CustomMultipartFormDataStreamProvider(PATH);
        //        //var streamProvider = new MultipartFormDataStreamProvider(PATH);
        //        //    var task = Request.Content.ReadAsMultipartAsync(streamProvider).ContinueWith<IEnumerable<FileDesc>>(t =>
        //        //{

        //        //    if (t.IsFaulted || t.IsCanceled)
        //        //    {
        //        //        throw new HttpResponseException(HttpStatusCode.InternalServerError);
        //        //    }

        //        //    var fileInfo = streamProvider.FileData.Select(i =>
        //        //    {
        //        //        var info = new FileInfo(i.LocalFileName);
        //        //        return new FileDesc(info.Name, rootUrl + "/" + folderName + "/" + info.Name, info.Length / 1024);
        //        //    });
        //        //    return fileInfo;
        //        //});

        //        var task = Request.Content.ReadAsMultipartAsync(streamProvider).
        //        ContinueWith<HttpResponseMessage>(o =>
        //        {

        //            //string file1 = provider.BodyPartFileNames.First().Value;
        //            // this is the file name on the server where the file was saved 

        //            return new HttpResponseMessage()
        //            {
        //                Content = new StringContent("File uploaded.")
        //            };
        //        }
        //    );
        //        //var info=string.Empty;


        //        IEnumerable<FileDesc> fileInfo = streamProvider.FileData.Select(i =>
        //        {
        //            var info = new FileInfo(i.LocalFileName);
        //            return new FileDesc(info.Name, rootUrl + "/" + folderName + "/" + info.Name, info.Length / 1024);
        //        });
        //        string filename = "";
        //        foreach (FileDesc file in fileInfo)
        //        {
        //            filename = file.Name;
        //        }

        //        string oldfilename = PATH + "/" + filename;
        //        string newfilename = PATH + "/" + "12004.xlsx";
        //        File.Copy(oldfilename, newfilename);


        //        return task;

        //    }
        //    else
        //    {
        //        throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotAcceptable, "This request is not properly formatted"));
        //    }

        //}

        [AcceptVerbs("GET", "POST")]
        public IHttpActionResult ImportFile()
        {


            #region Variable Declaration  
            string message = "";
            HttpResponseMessage ResponseMessage = null;
            var httpRequest = HttpContext.Current.Request;
            var hospitalid = HttpContext.Current.Request.Form["hospitalID"];
            var userid = HttpContext.Current.Request.Form["userid"];

            #endregion
            if (httpRequest.Files.Count > 0)
            {

                Response res = uploadexcel(httpRequest, Convert.ToInt32(userid), Convert.ToInt32(hospitalid));
                return Ok(res);
            }
            else
                ResponseMessage = Request.CreateResponse(HttpStatusCode.BadRequest);
            Response resp = new Response();
            resp.Message = "File Format not Supported";
            return Ok(resp);
        }

        [AcceptVerbs("GET", "POST")]
        public IHttpActionResult ValidateFile()
        {


            #region Variable Declaration  
            string message = "";
            HttpResponseMessage ResponseMessage = null;
            var httpRequest = HttpContext.Current.Request;
            var hospitalid = Convert.ToInt32(httpRequest.Form["hospitalID"]);
            var userid = Convert.ToInt32(httpRequest.Form["userid"]);

            #endregion
            if (httpRequest.Files.Count > 0)
            {

                DataSet dsexcelRecords = new DataSet();
                IExcelDataReader reader = null;
                HttpPostedFile Inputfile = null;
                Stream FileStream = null;
                Response res = new Response();
                Commn objcommn = new Commn();
                var PATH = HttpContext.Current.Server.MapPath("~/App_Data/Samples_received");

                try
                {

                    Inputfile = httpRequest.Files[0];
                    FileStream = Inputfile.InputStream;

                    if (Inputfile != null && FileStream != null)
                    {
                        if (Inputfile.FileName.EndsWith(".xls"))
                            reader = ExcelReaderFactory.CreateBinaryReader(FileStream);
                        else if (Inputfile.FileName.EndsWith(".xlsx"))
                            reader = ExcelReaderFactory.CreateOpenXmlReader(FileStream);
                        else
                            res.Message = "The file format is not supported.";
                        //Inputfile.SaveAs(PATH + "/" + "12001.xlsx");
                        dsexcelRecords = reader.AsDataSet();
                        reader.Close();

                        if (dsexcelRecords != null && dsexcelRecords.Tables.Count > 0)
                        {

                            DataTable dtSampleRecords = dsexcelRecords.Tables[0];


                            int excelvalid = objcommn.CheckImportFileHeader(dtSampleRecords);

                            if (excelvalid == 1)
                            {
                                int valid = dblayer.ValidateExcelData(dtSampleRecords, userid, hospitalid);

                                if (valid > 0)
                                {
                                    res.Message = "Excel File Validated";
                                    res.Link = (dtSampleRecords.Rows.Count - 1).ToString();
                                }
                                else
                                {
                                    res.Message = "Invalid Excel Data.";
                                }
                            }
                            else
                                res.Message = "Invalid Excel Headers.";
                        }
                        else
                            res.Message = "Selected file is empty.";
                    }
                    else
                        res.Message = "Invalid File.";

                    return Ok(res);

                }
                catch (Exception)
                {
                    res.Message = "Something Went Wrong!, Please Upload File again";
                    return Ok(res);
                }
            }
            else
                ResponseMessage = Request.CreateResponse(HttpStatusCode.BadRequest);
            Response resp = new Response();
            resp.Message = "File Format not Supported";
            return Ok(resp);
        }
        public Response uploadexcel(HttpRequest httpRequest, int userid, int hospitalid)
        {
            DataSet dsexcelRecords = new DataSet();
            IExcelDataReader reader = null;
            HttpPostedFile Inputfile = null;
            Stream FileStream = null;
            Response res = new Response();
            Commn objcommn = new Commn();
            var PATH = HttpContext.Current.Server.MapPath("~/App_Data/Samples_received");

            try
            {

                Inputfile = httpRequest.Files[0];
                FileStream = Inputfile.InputStream;

                if (Inputfile != null && FileStream != null)
                {
                    if (Inputfile.FileName.EndsWith(".xls"))
                        reader = ExcelReaderFactory.CreateBinaryReader(FileStream);
                    else if (Inputfile.FileName.EndsWith(".xlsx"))
                        reader = ExcelReaderFactory.CreateOpenXmlReader(FileStream);
                    else
                        res.Message = "The file format is not supported.";
                    //Inputfile.SaveAs(PATH + "/" + "12001.xlsx");
                    dsexcelRecords = reader.AsDataSet();
                    reader.Close();

                    if (dsexcelRecords != null && dsexcelRecords.Tables.Count > 0)
                    {

                        DataTable dtSampleRecords = dsexcelRecords.Tables[0];

                        int valid = dblayer.ValidateExcelData(dtSampleRecords, userid, hospitalid);
                        if (valid > 0)
                        {

                            int output = dblayer.InsertSampleRecieved(dtSampleRecords, userid, hospitalid);


                            //iutput = objEntity.SaveChanges();



                            if (output > 0)
                                res.Message = "The Excel file has been successfully uploaded.";
                            else
                                res.Message = "Something Went Wrong!, The Excel file uploaded has failed.";
                        }
                        else
                        {
                            res.Message = "Invalid Excel Data.";
                        }

                    }
                    else
                        res.Message = "Selected file is empty.";
                }
                else
                    res.Message = "Invalid File.";

                return res;

            }
            catch (Exception)
            {
                res.Message = "Something Went Wrong!, The Excel file uploaded has failed";
                return res;
            }
        }

        [AcceptVerbs("GET", "POST")]
        public IHttpActionResult GetBulkSamples([FromBody] SampleProcess obj)
        {
            DataTable dt = new DataTable();
            try
            {

                if (!ModelState.IsValid)

                {

                    return BadRequest(ModelState);

                }
                string fromdate = "2021/05/01";
                string todate = "2021/05/19";
                string userid = "1";
                string index = "1";
                //{ FromDate:  "2021/05/01", ToDate: "2021/05/19",UserID:"1",Index:"1" };--Request Object
                var result = dblayer.GetBulkSamples(obj.FromDate, obj.ToDate, obj.UserID, obj.Index);

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
        public IHttpActionResult GetProcessingSamples([FromBody] SampleProcess obj)
        {
            DataTable dt = new DataTable();
            try
            {
                if (!ModelState.IsValid)

                {

                    return BadRequest(ModelState);

                }

                ResponseClass resp = new ResponseClass();
                //{ FromDate: "2021/05/01", ToDate: "2021/05/19",UserID: "1",Index: "1",BulkNumber:"4",HospitalID:"2",FromLab:null,ToLab:null }
                var result = dblayer.SamplesForPlate(obj.FromDate, obj.ToDate, obj.UserID, obj.Index, obj.BulkNumber, obj.HospitalID, obj.FromLab, obj.ToLab, obj.PlateType);

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

        [AcceptVerbs("GET", "POST")]
        public IHttpActionResult AllocatePlate([FromBody] List<SampleProcess> obj)
        {
            SampleProcess sp = new SampleProcess();
            try
            {
                if (!ModelState.IsValid)

                {

                    return BadRequest(ModelState);

                }


                //{UserID: "1",SampleID: "1"}
                sp.PlateNumber = dblayer.BlockSamples(obj);

                return Ok(sp);



            }

            catch (Exception)

            {
                return Ok(sp);

            }

        }

        public IHttpActionResult ConfirmPlate([FromBody] List<SampleProcess> obj)
        {
            SampleProcess sp = new SampleProcess();
            try
            {
                if (!ModelState.IsValid)

                {

                    return BadRequest(ModelState);

                }


                //{UserID: "1",SampleID: "1"}
                sp.PlateNumber = dblayer.ConfirmPlate(obj);

                return Ok(sp);



            }

            catch (Exception)

            {
                return Ok(sp);

            }

        }


        [AcceptVerbs("GET", "POST")]
        public IHttpActionResult DeleteAllPlate([FromBody] List<SampleProcess> obj)
        {
            Response res = new Response();
            res.Message = "Couldn't remove samples from plate..Try again";
            try
            {
                if (!ModelState.IsValid)

                {

                    return BadRequest(ModelState);

                }


                //{UserID: "1",SampleID: "1"}
                int output = dblayer.DeAssignPlate(obj);

                if (output == 1)
                {
                    res.Message = "Samples removed from plates successfully";
                }
                else
                {
                    res.Message = "Couldn't remove samples from plate..Try again";
                }
                return Ok(res);



            }

            catch (Exception)

            {
                return Ok(res);

            }

        }


        [AcceptVerbs("GET", "POST")]
        public IHttpActionResult DeletePlate([FromBody] SampleProcess obj)
        {
            Response res = new Response();
            res.Message = "Couldn't remove samples from plate..Try again";
            try
            {
                if (!ModelState.IsValid)

                {

                    return BadRequest(ModelState);

                }


                //{UserID: "1",SampleID: "1"}
                int output = dblayer.DeAssignPlate(obj);

                if (output == 1)
                {
                    res.Message = "Samples removed from plates successfully";
                }
                else
                {
                    res.Message = "Couldn't remove samples from plate..Try again";
                }
                return Ok(res);



            }

            catch (Exception)

            {
                return Ok(res);

            }

        }

        [AcceptVerbs("GET", "POST")]
        public IHttpActionResult GetPlatedSamples([FromBody] SampleProcess obj)
        {
            DataTable dt = new DataTable();
            try
            {
                if (!ModelState.IsValid)

                {

                    return BadRequest(ModelState);

                }

                ResponseClass resp = new ResponseClass();
                //{ UserID: "1",Index: "1"}
                var result = dblayer.GetAssignedPlates(obj.UserID, obj.Index);

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

        [AcceptVerbs("GET", "POST")]
        public IHttpActionResult GetPlates([FromBody] SampleProcess obj)
        {
            DataTable dt = new DataTable();
            try
            {
                if (!ModelState.IsValid)

                {

                    return BadRequest(ModelState);

                }

                ResponseClass resp = new ResponseClass();
                //{ PlateNumber: "1",Index: "1"}
                var result = dblayer.GetPlates(obj.PlateNumber, obj.Index);

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

        [AcceptVerbs("GET", "POST")]
        public IHttpActionResult GetAllLabID([FromBody] SampleProcess obj)
        {
            DataTable dt = new DataTable();
            try
            {
                if (!ModelState.IsValid)

                {

                    return BadRequest(ModelState);

                }

                ResponseClass resp = new ResponseClass();
                //{ PlateNumber: "1",UserType:"Admin",Index: "1"}
                var result = dblayer.GetAllLabID(obj.PlateNumber, obj.UserType, obj.Index);

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

        [AcceptVerbs("GET", "POST")]
        public IHttpActionResult GetLabID([FromBody] SampleProcess obj)
        {
            DataTable dt = new DataTable();
            try
            {
                if (!ModelState.IsValid)

                {

                    return BadRequest(ModelState);

                }

                ResponseClass resp = new ResponseClass();
                //{ PlateNumber: "1",UserType:"Admin",Index: "1",LabID:="456656"}
                var result = dblayer.GetLabID(obj.PlateNumber, obj.UserType, obj.Index, obj.LabID);

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

        [AcceptVerbs("GET", "POST")]
        public IHttpActionResult SetResult([FromBody] List<Sample> obj)
        {
            Response res = new Response();
            res.Message = "Couldn't remove samples from plate..Try again";
            try
            {
                if (!ModelState.IsValid)

                {

                    return BadRequest(ModelState);

                }


                //{ Result: "Negative",LabID: "1",ResultById: "1"}
                int output = dblayer.UpdateResult(obj);

                if (output == 1)
                {
                    res.Message = "Results updated successfully";
                }
                else
                {
                    res.Message = "Couldn't update results..Try again";
                }
                return Ok(res);



            }

            catch (Exception)

            {
                return Ok(res);

            }

        }

        [AcceptVerbs("GET", "POST")]
        public IHttpActionResult GetTestingKit()
        {
            try

            {
                if (!ModelState.IsValid)

                {

                    return BadRequest(ModelState);

                }

                DataTable kit = dblayer.GetTestingKit();

                if (kit != null)
                {
                    return Ok(kit);
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
        public IHttpActionResult GetICMRData([FromBody] SampleProcess obj)
        {
            DataTable dt = new DataTable();
            try
            {
                if (!ModelState.IsValid)

                {

                    return BadRequest(ModelState);

                }

                ResponseClass resp = new ResponseClass();
                //{ FromDate: "2021/05/01",ToDate:"2021/05/19",Index: "1""}
                var result = dblayer.GetICMRData(obj.FromDate, obj.ToDate, obj.Index);

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

        [AcceptVerbs("GET", "POST")]
        public IHttpActionResult GenerateICMRReport(ICMR obj)
        {

            Response res = new Response();
            res.Message = "Couldn't generate ICMR Report..Try again";
            try
            {
                if (!ModelState.IsValid)

                {

                    return BadRequest(ModelState);

                }


                //{ Fromdate: ,ToDate: "1",CollectionDate: "1",ReceivingDate:"",TestingDate:"",KitID:"",UserID:""}
                Tuple<int, string> output = dblayer.GenerateICMRData(obj);

                if (output.Item1 == 1)
                {
                    res.Link = output.Item2;
                    res.Message = "ICMR Data Generated Sucessfully";

                }
                else
                {
                    res.Link = "";
                    res.Message = "No Data Found for ICMR Report..Try again";
                }
                return Ok(res);



            }

            catch (Exception)

            {
                return Ok(res);

            }

        }
    }

    public class CustomMultipartFormDataStreamProvider : MultipartFormDataStreamProvider
    {
        public CustomMultipartFormDataStreamProvider(string path) : base(path)
        { }

        public override string GetLocalFileName(System.Net.Http.Headers.HttpContentHeaders headers)
        {

            var name = !string.IsNullOrWhiteSpace(headers.ContentDisposition.FileName) ? headers.ContentDisposition.FileName : "NoName";
            return name.Replace("\"", string.Empty);





        }
    }
}

