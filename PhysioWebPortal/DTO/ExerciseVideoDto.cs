using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhysioWebPortal.DTO
{
    public class ExerciseVideoDto
    {
        public int VId { get; set; }
        public int ExId { get; set; }
        public string VFileEnglish { get; set; }
        public string VFileMandarin { get; set; }
        public string VFileMalay { get; set; }
        public string VFileTamil { get; set; }
        public System.DateTime LastUpdated { get; set; }
        public string LastUpdatedBy { get; set; }
        public string VThumbnail { get; set; }
    }
}