using CommonDAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineUserRegistation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegistationController : ControllerBase
    {
        FlightBookingDBContext _flightBookingDBContext;
        public UserRegistationController(FlightBookingDBContext flightBookingDBContext)
        {
            _flightBookingDBContext = flightBookingDBContext;
        }

        [Authorize]
        [HttpGet("GetUserDetails")]

        public IActionResult GetUserData()
        {
            try
            {
                var UserData = _flightBookingDBContext.UserRegisters.ToList();
                if (UserData.Count == 0)
                {
                    return NotFound("No Admin Data is exist");
                }
                return Ok(UserData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost("InsertUserDetails")]
        public IActionResult InsertUser(UserRegister UserData)
        {
            try
            {
                _flightBookingDBContext.UserRegisters.Add(UserData);
                _flightBookingDBContext.SaveChanges();

                return Ok("User Details was added");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //[HttpPost]
        //[Route("insert-user-details")]
        //public IActionResult InsertUserDetails(UserRegister user)
        //{
        //    try
        //    {
        //        using (var scope = new TransactionScope())
        //        {
        //            _flightBookingDBContext.Add(user);
        //            scope.Complete();
        //            return Accepted();
        //        }
        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }
        //}
    }
}
