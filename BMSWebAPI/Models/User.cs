using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMSWebAPI.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int UserTypeId { get; set; }
        public int IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int ModifiedBy { get; set; }
        public int ModifiedDateTime { get; set; }
        public string UserType { get; set; }
        public string Index { get; set; }

    }
}