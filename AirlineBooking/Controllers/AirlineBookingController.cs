using AirlineBooking.Events;
using AirlineBooking.Models;
using AirlineBooking.ViewModels;
using CommonDAL.Models;
using MassTransit.KafkaIntegration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace AirlineBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirlineBookingController : ControllerBase
    {
        FlightBookingDBContext _flightBookingDBContext;
        private ITopicProducer<BookingEvent> _topicProducer;
        public AirlineBookingController(FlightBookingDBContext flightBookingDBContext, ITopicProducer<BookingEvent> topicProducer)
        {
            _flightBookingDBContext = flightBookingDBContext;
            _topicProducer = topicProducer;
        }

        // To get Booking details

        [Authorize]
        [HttpGet("GetBookingDetails")]

        public IActionResult GetBookingData()
        {
            try
            {
                var BookingData = _flightBookingDBContext.BookingDetails.ToList();
                if (BookingData.Count == 0)
                {
                    return NotFound("No Admin Data is exist");
                }
                return Ok(BookingData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[Authorize]
        //[HttpPost("InsertBookindDetails")]
        //public IActionResult InsertUser(BookingDetail BookingData)
        //{
        //    try
        //    {
        //        _flightBookingDBContext.BookingDetails.Add(BookingData);
        //        _flightBookingDBContext.SaveChanges();

        //        return Ok("User Details was added");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        [HttpPost]
        [Route("InsertBookindDetails")]
        public async Task<IActionResult> InsertUserDetails([FromBody] BookingViewModel bookingViewModel)
        {
            try
            {
                IEnumerable<UsersViewModel> _usersViewModels = bookingViewModel.usersViewModels;
                int setCount = _usersViewModels.Count();
                InventoryDetail _inventorys = null;
                BookingDetail bookings;
                if (bookingViewModel.Seattype == 0)
                {
                    _inventorys = _flightBookingDBContext.InventoryDetails.ToList()
                        .Where(o => o.FlightNumber == bookingViewModel.FlightNumber && o.FclassCount >= setCount).FirstOrDefault();
                }
                else if (bookingViewModel.Seattype == 1)
                {
                    _inventorys = _flightBookingDBContext.InventoryDetails.ToList()
                        .Where(o => o.FlightNumber == bookingViewModel.FlightNumber && o.StartDate == bookingViewModel.DateOfJourney
                        && o.NclassAvailableCount >= setCount).FirstOrDefault();
                }

                if (_inventorys == null)
                {
                    return BadRequest("Invalid Flight Number or Seats not Available");
                }
                string BookingId = GenerateBookingID();
                string flightNumber = bookingViewModel.FlightNumber;
                DateTime DateOfJourney = bookingViewModel.DateOfJourney;
                string FromPlace = bookingViewModel.FromPlace;
                string ToPlace = bookingViewModel.ToPlace;
                string BoardingTime = bookingViewModel.BoardingTime;
                string CreatedBy = bookingViewModel.CreatedBy;
                string EmailID = bookingViewModel.EmailID;

                int seatNumber = 0;
                if (bookingViewModel.Seattype == 0)
                {
                    seatNumber = (int)(_inventorys.FclassCount+1 - _inventorys.FclassAvailableCount);
                }
                else if (bookingViewModel.Seattype == 1)
                {
                    seatNumber = (int)(_inventorys.NclassCount+1 - _inventorys.NclassAvailableCount);
                }
                foreach (UsersViewModel usersViewModel in _usersViewModels)
                {
                    bookings = new BookingDetail();
                    bookings.TicketId = GenerateticketID();
                    bookings.BookingId = BookingId;
                    bookings.FlightNumber = flightNumber;
                    bookings.DateOfJourney = DateOfJourney;
                    bookings.FromPlace = FromPlace;
                    bookings.ToPlace = ToPlace;
                    bookings.BoardingTime = BoardingTime;
                    bookings.EmailId = EmailID;
                    bookings.UserName = usersViewModel.UserName;
                    bookings.PassportNumber = usersViewModel.passportNumber;
                    bookings.Age = usersViewModel.Age;
                    bookings.SeatNumber = seatNumber;
                    bookings.Status = 1;
                    bookings.Statusstr = "Ticket Booked";
                    bookings.CreatedBy = CreatedBy;
                    bookings.CreateDate = DateTime.Now;
                    bookings.UpdateDate = DateTime.Now;
                    bookings.UpdatedBy = CreatedBy;
                    bookings.Seattype = bookingViewModel.Seattype;
                    using (var scope = new TransactionScope())
                    {
                        _flightBookingDBContext.BookingDetails.Add(bookings);
                        _flightBookingDBContext.SaveChanges();
                        scope.Complete();
                    }
                }
                await _topicProducer.Produce(new BookingEvent
                {
                    FlightNumber = flightNumber,
                    FromPlace = FromPlace,
                    ToPlace = ToPlace,
                    StartDate = DateOfJourney,
                    startTime = BoardingTime,
                    NumberOfTickets = setCount,
                    Seattype = bookingViewModel.Seattype
                });


                return Ok("Booking Done Successfully");
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }
        /// <summary>
        /// Generate UniQue TiketID
        /// </summary>
        /// <returns></returns>
        private string GenerateticketID()
        {
            int count = _flightBookingDBContext.BookingDetails.ToList().Count();
            string strSecretCode = string.Empty;
            string strguid = string.Empty;
            string strYearCode = string.Empty;
            string TicketID = string.Empty;
            try
            {
                System.Guid guid = System.Guid.NewGuid();
                strguid = guid.ToString();
                strSecretCode = strguid.Substring(strguid.LastIndexOf("-") + 1);
                strSecretCode = strSecretCode.ToUpper().Replace('O', 'W').Replace('0', '4');
                strSecretCode = strSecretCode.Substring(0, 6);

                TicketID = "TIC" + strSecretCode.ToUpper() + count;

                return TicketID;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return TicketID;
            }

        }
        /// <summary>
        /// Genarate unique Booking iD
        /// </summary>
        /// <returns></returns>
        private string GenerateBookingID()
        {
            int count = _flightBookingDBContext.BookingDetails.ToList().Count();
            string strSecretCode = string.Empty;
            string strguid = string.Empty;
            string strYearCode = string.Empty;
            string TicketID = string.Empty;
            try
            {
                System.Guid guid = System.Guid.NewGuid();
                strguid = guid.ToString();
                strSecretCode = strguid.Substring(strguid.LastIndexOf("-") + 1);
                strSecretCode = strSecretCode.ToUpper().Replace('O', 'W').Replace('0', '4');
                strSecretCode = strSecretCode.Substring(0, 6);
                TicketID = "BOK" + strSecretCode.ToUpper() + count;

                return TicketID;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return TicketID;
            }

        }

        //Get details by Email id 

        [HttpGet]
        [Route("Email-ticket")]
        public IActionResult GetTicket(string EmailID)
        {
            try
            {
                IEnumerable<BookingDetail> bookings = _flightBookingDBContext.BookingDetails.ToList()
                                                .Where(o => o.EmailId.ToUpper() == EmailID.ToUpper());
                return new OkObjectResult(bookings);
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Cancel Ticket
        /// </summary>
        /// <param name="TicketID"></param>
        /// <returns></returns>
      
        //[Authorize]
        [HttpPut]
        [Route("cancel-ticket/{TicketID}")]
        public IActionResult CancelTicket(string TicketID)
        {
            try
            {
                IEnumerable<BookingDetail> bookings = _flightBookingDBContext.BookingDetails.ToList().Where(o => o.TicketId == TicketID).Take(1);
                foreach (BookingDetail booking in bookings)
                {
                    booking.Status = 0;
                    booking.Statusstr = "Canceled";
                    using (var scope = new TransactionScope())
                    {
                        _flightBookingDBContext.Entry(booking).State=EntityState.Modified;
                        _flightBookingDBContext.SaveChanges();
                        scope.Complete();
                    }
                }
                
                return new OkObjectResult(bookings);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        /// <summary>
        /// PNR STATUS Check
        /// </summary>
        /// <param name="TicketID"></param>
        /// <returns></returns>
        /// 
        [Authorize]
        [HttpGet]
        [Route("pnr-ticket/{TicketID}")]
        public IActionResult GetpnrTicket(string TicketID)
        {
            try
            {
                IEnumerable<BookingDetail> bookings = _flightBookingDBContext.BookingDetails.ToList()
                                                .Where(o => o.TicketId.ToUpper() == TicketID.ToUpper());
                return new OkObjectResult(bookings);
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
