using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMSWebAPI.Models
{
    public class SampleReceiveOutput
    {
        public DateTime ImportDate { get; set; }
        public string Name { get; set; }
        public string LabId { get; set; }
        public string SRFID { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string PHC { get; set; }
        public int BulkNumber { get; set; }
        public string Status2 { get; set; }
        public string Result { get; set; }
    }
}