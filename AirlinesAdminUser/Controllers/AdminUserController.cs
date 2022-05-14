using CommonDAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlinesAdminUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminUserController : ControllerBase
    {
        FlightBookingDBContext _flightBookingDBContext;
        public AdminUserController(FlightBookingDBContext flightBookingDBContext)
        {
            _flightBookingDBContext = flightBookingDBContext;
        }

        [Authorize]
        [HttpGet("GetAdminData")]
        
        public IActionResult GetAdminData()
        {
            try
            {
                var AdminData = _flightBookingDBContext.AdminUsers.ToList();
                if (AdminData.Count == 0)
                {
                    return NotFound("No Admin Data is exist");
                }
                return Ok(AdminData);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("check-admin-details")]
        public IActionResult CheckAdminDetails(AdminUser admin)
        {
            try
            {
                // Validate modelState
                //if (!ModelState.IsValid)
                //{
                //    return UnprocessableEntity(ModelState);
                //}

                var adminUserData = _flightBookingDBContext.AdminUsers.ToList()
                             .Where(o => o.AdminId == admin.AdminId && o.Password == admin.Password);
                return Ok("Admin Data was Matched");

            }
            catch
            {
                return BadRequest();
            }
        }


    }
}
