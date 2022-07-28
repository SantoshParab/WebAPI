using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMSWebAPI.Models
{
    public class ReportInput
    {
        public int HospitalID { get; set; }
        public int BulkNumber { get; set; }
        public string LabId { get; set; }
        public string Result { get; set; }
        public string Status { get; set; }
        public string PHC { get; set; }
        public string PlateNo { get; set; }
        public string Index { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}