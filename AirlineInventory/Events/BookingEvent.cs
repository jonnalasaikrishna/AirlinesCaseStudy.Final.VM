using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineInventory.Events
{
    public class BookingEvent
    {
        public string FlightNumber { get; set; }

        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public DateTime StartDate { get; set; }
        public string startTime { set; get; }
        public int NumberOfTickets { set; get; }

        public int Seattype { set; get; }
    }
}
