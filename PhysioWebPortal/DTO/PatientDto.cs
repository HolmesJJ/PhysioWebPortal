using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhysioWebPortal.DTO
{
    public class PatientDto
    {
        public string Id { get; set; }
        public string PatientCodeName { get; set; }
        public string Remarks { get; set; }
        public System.DateTime LastUpdated { get; set; }
        public string LastUpdatedBy { get; set; }
        public Nullable<int> PreferredLanguage { get; set; }
        public string ExName { get; set; }
    }
    
}