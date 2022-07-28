using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMSWebAPI.Models
{
    public class Hospital
    {


        public int HospitalId { get; set; }
        public string PHC { get; set; }
        public string Code { get; set; }
        public string Zone { get; set; }
        public string Email { get; set; }
        public int IsActive { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatedBy { get; set; }
        public string Index { get; set; }
    }
}