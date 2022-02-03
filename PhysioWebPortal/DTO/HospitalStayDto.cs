using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhysioWebPortal.DTO
{
    public class HospitalStayDto
    {
        public int StayId { get; set; }
        public string PatientId { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public int Pose { get; set; }
        public string Remarks { get; set; }
        public string PhysiotherapistId { get; set; }
        public System.DateTime LastUpdated { get; set; }
        public string LastUpdatedBy { get; set; }
        public int PEID { get; set; }
    }
}