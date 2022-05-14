using AirlineInventory.Events;
using CommonDAL.Models;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineInventory.Consumers
{
    public class BookingEventConsumer : IConsumer<BookingEvent>
    {
        public readonly FlightBookingDBContext _flightBookingDBContext;
        public BookingEventConsumer(FlightBookingDBContext flightBookingDBContext)
        {
            _flightBookingDBContext = flightBookingDBContext;
        }
        public Task Consume(ConsumeContext<BookingEvent> context)
        {
            try

            {
                InventoryDetail inventory = _flightBookingDBContext.InventoryDetails.ToList().Where(a => //a.StartDate == context.Message.StartDate &&
                                                                     a.FromPlace.ToLower().Contains(context.Message.FromPlace.ToLower()) &&
                                                                   a.ToPlace.ToLower().Contains(context.Message.ToPlace.ToLower()) &&
                                                                    a.FlightNumber == context.Message.FlightNumber
                                                                   && a.StartTime == context.Message.startTime
                                                                  ).FirstOrDefault();
                if (context.Message.Seattype == 0)
                {
                    inventory.FclassAvailableCount = inventory.FclassAvailableCount - context.Message.NumberOfTickets;
                    inventory.UpdatedBy = "user";
                    inventory.UpdateDate = DateTime.Now;
                }
                else if (context.Message.Seattype == 1)
                {
                    inventory.NclassAvailableCount = inventory.NclassAvailableCount - context.Message.NumberOfTickets;
                    inventory.UpdatedBy = "user";
                    inventory.UpdateDate = DateTime.Now;
                }
                _flightBookingDBContext.Entry(inventory).State = EntityState.Modified;
                _flightBookingDBContext.SaveChanges();

                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                return Task.FromException(ex);
            }

        }
    }
}
