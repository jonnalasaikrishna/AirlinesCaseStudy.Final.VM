using CommonDAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineInventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirlineInventoryController : ControllerBase
    {
        FlightBookingDBContext _flightBookingDBContext;
        public AirlineInventoryController(FlightBookingDBContext flightBookingDBContext)
        {
            _flightBookingDBContext = flightBookingDBContext;
        }

        [HttpGet("GetInventoryDetails")]

        public IActionResult GetInventoryData()
        {
            try
            {
                var InventoryData = _flightBookingDBContext.InventoryDetails.ToList();
                if (InventoryData.Count == 0)
                {
                    return NotFound("No Admin Data is exist");
                }
                return Ok(InventoryData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost("InsertInventryDetails")]
        public IActionResult InsertUser(InventoryDetail InventoryData)
        {
            try
            {
                _flightBookingDBContext.InventoryDetails.Add(InventoryData);
                _flightBookingDBContext.SaveChanges();

                return Ok("Inventory Details was added");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost]
        [Route("search-inventories")]
        public IActionResult GetAllInventories(InventoryDetail serachInventory)
        {
            try
            {
                // Validate modelState
                if (!ModelState.IsValid)
                {
                    return UnprocessableEntity(ModelState);
                }

                return Ok(_flightBookingDBContext.InventoryDetails.Where(a => a.StartDate >= serachInventory.StartDate &&
                                                               a.FromPlace.ToLower().Contains(serachInventory.FromPlace.ToLower()) &&
                                                             a.ToPlace.ToLower().Contains(serachInventory.ToPlace.ToLower())));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
