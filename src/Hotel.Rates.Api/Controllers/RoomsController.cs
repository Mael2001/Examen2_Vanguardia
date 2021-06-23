using Hotel.Rates.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Rates.Api.Models;
using Hotel.Rates.Data.Services;
using Hotel.Rates.Infraestructure.Context;

namespace Hotel.Rates.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController : ControllerBase
    {
        private readonly RoomService _rooomService;

        public RoomsController(RoomService rooomService)
        {
            _rooomService = rooomService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var rooms = _rooomService.GetRooms()
                .Result
                .Select(x => new RoomDto
                {
                    Amount = x.Amount,
                    Id = x.Id,
                    MaxAdults = x.MaxAdults,
                    MaxChildren = x.MaxChildren,
                    Name = x.Name,
                    RatePlanRooms = x.RatePlanRooms
                });
            return Ok(rooms);
        }
    }
}
