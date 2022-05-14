using System;
using System.Collections.Generic;

#nullable disable

namespace AirlinesDbConnection.Models
{
    public partial class FlightDetail
    {
        public int FlightId { get; set; }
        public string FlightNumber { get; set; }
        public int? AirlineId { get; set; }
        public string FlightName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string Country { get; set; }
    }
}
