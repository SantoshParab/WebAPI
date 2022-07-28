using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMSWebAPI.Models
{
    public class SampleOutput
    {
        public int HospitalId { get; set; }
        public string PHC { get; set; }
        
        public int TotalCount { get; set; }
        public int UnderProcessCount { get; set; }
        public int ProcessedCount { get; set; }
        public int PositiveCount { get; set; }
        public int NegativeCount { get; set; }
        public int RejectedCount { get; set; }
    }
}