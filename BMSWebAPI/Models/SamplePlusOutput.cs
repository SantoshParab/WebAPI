using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMSWebAPI.Models
{
    public class SamplePlusOutput
    {
        public DateTime ImportedDate { get; set; }
        public string PHC { get; set; }
        public int BulkNumber { get; set; }
        public string LabId { get; set; }
        public string Status2 { get; set; }
        public string Result { get; set; }
    }
}