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
        private readonly RoomService _roomService;

        public RoomsController(RoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var rooms = _roomService.GetRooms()
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
