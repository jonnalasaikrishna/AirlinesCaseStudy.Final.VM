using System;
using System.Collections.Generic;

#nullable disable

namespace CommonDAL.Models
{
    public partial class AirlineDetail
    {
        public int AirlineId { get; set; }
        public string AirlineName { get; set; }
        public string Address { get; set; }
        public int? ContactNumber { get; set; }
        public string Country { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string ActiveStatus { get; set; }
    }
}
