using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhysioWebPortal.DTO
{
    public class PerformedExerciseDto
    {
        public int PerformExId { get; set; }
        public string ExName { get; set; }
        public int PEId { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime EndTime { get; set; }
        public int ExSetNo { get; set; }
        public int ExRepNo { get; set; }
        public int ExType { get; set; }
        public double AvgAngle { get; set; }
        public Nullable<double> AvgHoldDuration { get; set; }
        public string ExVisualFile { get; set; }
        public System.DateTime LastUpdated { get; set; }
        public string LastUpdatedBy { get; set; }
        public int Score { get; set; }
        public int ExId { get; set; }
        public string PatientId { get; set; }
        public string PatientCodeName { get; set; }
        public int ExTimePerDay { get; set; }
        public int StayId { get; set; }

    }
}