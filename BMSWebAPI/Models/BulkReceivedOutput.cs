using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMSWebAPI.Models
{
    public class BulkReceivedOutput
    {
        public int Bulknumber { get; set; }
        public DateTime ImportedDate { get; set; }
        public string UserName { get; set; }
        public string UserType { get; set; }
        public string ExcelLink { get; set; }
    }
}