using System;
using System.Collections.Generic;

#nullable disable

namespace AirlinesDbConnection.Models
{
    public partial class BookingDetail
    {
        public int TicketId { get; set; }
        public int? BookingId { get; set; }
        public int? FlightId { get; set; }
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public DateTime? DateOfJourney { get; set; }
        public DateTime? BoardingTime { get; set; }
        public string UserName { get; set; }
        public string PassportNumber { get; set; }
        public int? Age { get; set; }
        public int? SeatNumber { get; set; }
        public int? Status { get; set; }
        public string StatusPos { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
