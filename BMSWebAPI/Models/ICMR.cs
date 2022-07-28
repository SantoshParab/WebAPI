using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMSWebAPI.Models
{
    public class ICMR
    {
        public string Fromdate { get; set; }
        public string ToDate { get; set; }
        public string CollectionDate { get; set; }
        public string ReceivingDate { get; set; }

        public string TestingDate { get; set; }

        public string KitID { get; set; }

        public string UserID { get; set; }
    }
}