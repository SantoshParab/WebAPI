using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMSWebAPI.Models
{
    public class SampleProcess
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Index { get; set; }
        public string UserID { get; set; }
        public string HospitalID { get; set; }
        public string BulkNumber { get; set; }
        public string SampleID { get; set; }
        public string PlateNumber { get; set; }
        public string LabID { get; set; }
        public string FromLab { get; set; }
        public string ToLab { get; set; }
        public string UserType { get; set; }
        public int SampleProcessedOrder { get; set; }
        public int PoolNumber { get; set; }
        public int PlateType { get; set; }

    }
}