using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhysioWebPortal.DTO
{
    public class ExerciseDto
    {
        public int ExId { get; set; }
        public string ExName { get; set; }
        public string ExNameMandarin { get; set; }
        public string ExNameMalay { get; set; }
        public string ExNameTamil { get; set; }
        public string ExDescription { get; set; }
        public int ExSetNo { get; set; }
        public int ExRepNo { get; set; }
        public int ExType { get; set; }
        public int ExTimePerDay { get; set; }
        public string ExAngleMeasureType { get; set; }
        public Nullable<double> ExAngleStandingPose { get; set; }
        public Nullable<double> ExAngleLyingPose { get; set; }
        public Nullable<double> ExHoldDuration { get; set; }
        public System.DateTime LastUpdated { get; set; }
        public string LastUpdatedBy { get; set; }
        public ICollection<ExerciseVideo> ExerciseVideos { get; set; }
    }
}