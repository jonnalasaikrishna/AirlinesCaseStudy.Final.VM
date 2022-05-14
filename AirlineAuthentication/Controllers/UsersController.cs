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
            IEnumerable<AuthenticateUser> Users = _flightBookingDBContext.AuthenticateUsers.ToList().Where(o => o.UserName.ToLower() == userdata.Name.ToLower() && o.Password == userdata.Password);
            if(Users.Count() <=0)
            {
                return Unauthorized("Invalid Credentials");
            }
            var token = iJWTManager.Authenticate(userdata);
            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
