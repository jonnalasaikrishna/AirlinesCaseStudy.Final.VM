using AirlineAuthentication.Interface;
using AirlineAuthentication.Models;
using CommonDAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IJWTManagerRepository iJWTManager;
        FlightBookingDBContext _flightBookingDBContext;

        public UsersController(IJWTManagerRepository jWTManager, FlightBookingDBContext flightBookingDBContext)
        {
            iJWTManager = jWTManager;
            _flightBookingDBContext = flightBookingDBContext;
        }
        
        
        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate([FromBody] Users userdata)
        {
            List<AuthenticateUser> Users = _flightBookingDBContext.AuthenticateUsers.ToList().Where(o => o.EmailId.ToLower() == userdata.EmailId.ToLower() && o.Password == userdata.Password).ToList();
            if(Users.Count() <=0)
            {
                return Unauthorized("Invalid Credentials");
            }
            var token = iJWTManager.Authenticate(Users[0]);
            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
