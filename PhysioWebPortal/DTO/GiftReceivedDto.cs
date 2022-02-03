using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhysioWebPortal.DTO
{
    public class GiftReceivedDto
    {
        public int GiftReceivedId { get; set; }
        public int StayId { get; set; }
        public int GiftTypeId { get; set; }
        public System.DateTime ReceivedDateTime { get; set; }
        public string GivenById { get; set; }
    }
}