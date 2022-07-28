using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ClosedXML.Excel;
using Microsoft.Office.Interop.Excel;

namespace BMSWebAPI.Common
{
    public class Commn
    {

        public static string application_uri = "http://api.cagmdx.com";
        public System.Data.DataTable GetExcelTable()
        {
            System.Data.DataTable dt = new System.Data.DataTable();

            dt.Columns.Add("SL NO");
            dt.Columns.Add("Name");
            dt.Columns.Add("Age");
            dt.Columns.Add("Gender");
            dt.Columns.Add("Mobile No");
            dt.Columns.Add("SRF ID");
            dt.Columns.Add("LAB ID");
            dt.Columns.Add("KMIO");
            dt.Columns.Add("RT PCR RESULTS");

            return dt;

        }

        public Tuple<string, string> ExportToExcel(System.Data.DataTable dt, string bulknumber, int Type, string PHC)
        {
            if (dt != null)
            {
                var PATH = "";

                if (Type == 1)
                {
                    PATH = HttpContext.Current.Server.MapPath("~/Data/Samples_received/");
                    //PATH = application_uri + "/Data/Samples_received/";
                }
                else
                {
                    PATH = HttpContext.Current.Server.MapPath("~/Data/ICMR_REPORT/");
                    //PATH = application_uri + "/Data/ICMR_REPORT/";
                }

                string filename = "";
                string pdffilename = "";
                using (XLWorkbook wb = new XLWorkbook())
                {


                    if (Type == 1)
                    {

                        var ws = wb.AddWorksheet(dt, "Samples Received");
                        ws.Row(1).InsertRowsAbove(1);
                        ws.Cell("A1").Value = "PHC:" + PHC + ",Bulk Number: " + bulknumber + ",Total Samples:" + dt.Rows.Count.ToString();
                        var range = ws.Range("A1:I1");
                        range.Merge().Style.Font.SetBold().Font.FontSize = 14;
                        range.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        filename = GenerateFileNameXLSX(bulknumber);
                        pdffilename = GenerateFileNamePDF(bulknumber);
                        string excellink = PATH + filename;
                        wb.SaveAs(excellink);
                    }
                    else
                    {
                        wb.AddWorksheet(dt, "Samples Received");
                        filename = GenerateFileNameXLSX(bulknumber);
                        pdffilename = GenerateFileNamePDF(bulknumber);
                        string excellink = PATH + filename;
                        wb.SaveAs(excellink);
                    }

                    //pdf saving
                    //Application app = new Application();
                    //Workbook wkb = app.Workbooks.Open(PATH + filename);
                    //var sheet = (Worksheet)wkb.Worksheets.Item[1];
                    //sheet.PageSetup.FitToPagesWide = 1;
                    //sheet.PageSetup.FitToPagesTall = false;
                    //sheet.Columns.AutoFit();
                    //string pdflink = PATH + pdffilename;
                    //wkb.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF,pdflink );
                    string link1 = "";
                    if (Type == 1)
                    {
                        link1 = application_uri + "/Data/Samples_received/" + filename;
                    }
                    else
                    {
                        link1 = application_uri + "/Data/ICMR_REPORT/" + filename;
                    }

                    return Tuple.Create(link1, "");

                }

            }
            return Tuple.Create("", "");
        }

        public string GenerateFileNameXLSX(string bulknumber)
        {
            Guid guid = Guid.NewGuid();
            string str = bulknumber + "_ " + guid.ToString() + ".xlsx";
            return str;
        }

        public string GenerateFileNamePDF(string bulknumber)
        {
            Guid guid = Guid.NewGuid();
            string str = bulknumber + "_ " + guid.ToString() + ".pdf";
            return str;
        }

        public string GenerateLabID(string labID, string hspcode)
        {
            string month = DateTime.Now.Month.ToString();
            if (month.Length == 1)
            {
                month = "0" + month;
            }
            string year = DateTime.Now.Year.ToString().Substring(2);

            if (labID.Length == 1)
            {
                string lab = "000" + labID;
                return year + hspcode + DateTime.Now.Day + month + lab;
            }
            else if (labID.Length == 2)
            {
                string lab = "00" + labID;
                return year + hspcode + DateTime.Now.Day + month + lab;
            }
            else if (labID.Length == 3)
            {
                string lab = "0" + labID;
                return year + hspcode + DateTime.Now.Day + month + lab;
            }
            else
            {
                string lab = labID;
                return year + hspcode + DateTime.Now.Day + month + lab;
            }
        }

        public string GenerateKMIO(string kmio)
        {


            if (kmio.Length == 1)
            {
                string kmiono = "000000" + kmio;
                return "KMIO-COV-" + kmiono;
            }
            else if (kmio.Length == 2)
            {
                string kmiono = "00000" + kmio;
                return "KMIO-COV-" + kmiono;
            }
            else if (kmio.Length == 3)
            {
                string kmiono = "0000" + kmio;
                return "KMIO-COV-" + kmiono;
            }
            else if (kmio.Length == 4)
            {
                string kmiono = "000" + kmio;
                return "KMIO-COV-" + kmiono;
            }
            else if (kmio.Length == 5)
            {
                string kmiono = "00" + kmio;
                return "KMIO-COV-" + kmiono;
            }
            else if (kmio.Length == 6)
            {
                string kmiono = "0" + kmio;
                return "KMIO-COV-" + kmiono;
            }
            else
            {
                return "KMIO-COV-" + kmio;
            }

        }

        public Tuple<int, int> GetLimits(string index)
        {
            int pagesize = Convert.ToInt32(index + 0);//10
            int lowerlimit = pagesize - 10;//10-10--0
            //int upperlimit = lowerlimit + 10;//0+10--10
            int upperlimit = 10;
            return Tuple.Create(lowerlimit, upperlimit);
        }

        public Tuple<int, int> GetLimits_P100(string index)
        {
            int pagesize = Convert.ToInt32(index + "00");//10
            int lowerlimit = pagesize - 100;//10-10--0
            //int upperlimit = lowerlimit + 10;//0+10--10
            int upperlimit = 100;
            return Tuple.Create(lowerlimit, upperlimit);
        }


        public Tuple<int, int> GetLimits_N(string index, int PlateType)
        {
            int items_per_page = PlateType;
            int offset = (Convert.ToInt32(index) - 1) * items_per_page;
            return Tuple.Create(offset, items_per_page);
        }

        public string GeneratePlateNumber(string plateno)
        {
            string month = DateTime.Now.Month.ToString();
            if (month.Length == 1)
            {
                month = "0" + month;
            }
            if (plateno.Length == 1)
            {
                string plat = "000" + plateno;
                return DateTime.Now.Day + month + "P" + plat;
            }
            else if (plateno.Length == 2)
            {
                string plat = "00" + plateno;
                return DateTime.Now.Day + month + "P" + plat;
            }
            else if (plateno.Length == 3)
            {
                string plat = "0" + plateno;
                return DateTime.Now.Day + month + "P" + plat;
            }
            else
            {
                string plat = plateno;
                return DateTime.Now.Day + month + "P" + plat;
            }
        }

        public int CheckImportFileHeader(System.Data.DataTable dt)
        {
            string sr = dt.Rows[0][0].ToString();
            string name = dt.Rows[0][1].ToString();
            string age = dt.Rows[0][2].ToString();
            string gender = dt.Rows[0][3].ToString();
            string mobile = dt.Rows[0][4].ToString();
            string srf = dt.Rows[0][5].ToString();
            string temp = "Age";

            if (sr != "SL NO")
            {
                return 0;
            }
            else if (name != "Name")
            {
                return 0;
            }
            else if (!age.Contains(temp))
            {
                return 0;
            }
            else if (gender != "Gender")
            {
                return 0;
            }
            else if (mobile != "Mobile No")
            {
                return 0;
            }
            else if (srf != "SRF ID")
            {
                return 0;
            }
            else
            {
                return 1;
            }

        }
    }
}