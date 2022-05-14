using System;
using System.Collections.Generic;

#nullable disable

namespace CommonDAL.Models
{
    public partial class InventoryDetail
    {
        public int InventoryId { get; set; }
        public string FlightNumber { get; set; }
        public int? AirlineId { get; set; }
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? ScheduledDays { get; set; }
        public int? FclassCount { get; set; }
        public int? NclassCount { get; set; }
        public int? FticketCost { get; set; }
        public int? NticketCost { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? FclassAvailableCount { get; set; }
        public int? NclassAvailableCount { get; set; }
        public int? Rows { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int? MealService { get; set; }
    }
}
