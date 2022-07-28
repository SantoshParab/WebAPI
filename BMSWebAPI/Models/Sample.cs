using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMSWebAPI.Models
{
    public class Sample
    {

        public int SampleId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public int MobileNumber { get; set; }
        public string SRFID
        {
            get; set;
        }
        public string LabId { get; set; }
        public int KMIO { get; set; }
        public int IsProcessed { get; set; }
        public int IsUnderProcess { get; set; }
        public DateTime SampleReceiveDate { get; set; }
        public int BulkNumber { get; set; }
        public string PlateNumber { get; set; }
        public int IsBlockedByPlate { get; set; }
        public DateTime PlateGenDate { get; set; }
        public int HospitalId { get; set; }
        public int Result { get; set; }
        public int IsICMRProcessed { get; set; }
        public int ImporterById { get; set; }
        public int ProcessedById { get; set; }
        public int ResultById { get; set; }
        public int ModifiedById { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public DateTime ProcessedDateTime { get; set; }
        public DateTime ResultDateTime { get; set; }
        public string TResult { get; set; }

    }
}