using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace BMSWebAPI.Models
{
    public class ResponseClass
    {
        public string TotalRecords { get; set; }
        public DataTable DataCount { get; set; }
        public DataTable Data { get; set; }

    }
}