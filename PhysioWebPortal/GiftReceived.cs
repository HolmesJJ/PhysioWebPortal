//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PhysioWebPortal
{
    using System;
    using System.Collections.Generic;
    
    public partial class GiftReceived
    {
        public int GiftReceivedId { get; set; }
        public int StayId { get; set; }
        public int GiftTypeId { get; set; }
        public System.DateTime ReceivedDateTime { get; set; }
        public string GivenById { get; set; }
    
        public virtual Gift Gift { get; set; }
        public virtual HospitalStay HospitalStay { get; set; }
    }
}
