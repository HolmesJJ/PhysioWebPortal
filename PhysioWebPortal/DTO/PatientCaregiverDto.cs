using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhysioWebPortal.DTO
{
    public class PatientCaregiverDto
    {
        public string PatientId { get; set; }
        public string CaregiverId { get; set; }
        public System.DateTime LastUpdated { get; set; }
        public string LastUpdatedBy { get; set; }
    }
}