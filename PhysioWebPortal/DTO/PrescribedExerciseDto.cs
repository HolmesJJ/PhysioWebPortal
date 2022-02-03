using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhysioWebPortal.DTO
{
    public class PrescribedExerciseDto
    {
        public int PEId { get; set; }
        public int StayId { get; set; }
        public int ExId { get; set; }
        public System.DateTime AssignedDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public int ExSetNo { get; set; }
        public int ExRepNo { get; set; }
        public int ExTimePerDay { get; set; }
        public System.DateTime LastUpdated { get; set; }
        public string LastUpdatedBy { get; set; }
        public string VThumbnail { get; set; }
        public int ExType { get; set; }
        public string ExName { get; set; }
        public string Id { get; set; }
        
    }
}