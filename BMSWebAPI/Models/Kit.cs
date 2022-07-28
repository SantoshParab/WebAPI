using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMSWebAPI.Models
{
    public class Kit
    {
        public int TestingKitId { get; set; }

        public string TestingKitName { get; set; }

        public int IsActive { get; set; }

        public string Index { get; set; }
    }
}