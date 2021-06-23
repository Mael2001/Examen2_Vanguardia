using Hotel.Rates.Api.Models;
using Hotel.Rates.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Rates.Infraestructure.Context;

namespace Hotel.Rates.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationsController : ControllerBase
    {
        private readonly InventoryContext _context;

        public ReservationsController(InventoryContext context)
        {
            this._context = context;
        }

        [HttpPost]
        public IActionResult Post([FromBody]ReservationModel reservationModel)
        {
            var ratePlan = _context
                .NightlyRatePlans
                .Include(r => r.Seasons)
                .Include(r => r.RatePlanRooms)
                .ThenInclude(r => r.Room)
                .First(r => r.Id == reservationModel.RatePlanId);
            var canReserve = ratePlan.Seasons
                .Any(s => s.StartDate >= reservationModel.ReservationStart && s.EndDate <= reservationModel.ReservationEnd);
            var room = ratePlan.RatePlanRooms
                .First(r => r.RoomId == reservationModel.RoomId && r.RatePlanId == reservationModel.RatePlanId);
            var isRoomAvailable = room.Room.Amount > 0 &&
                room.Room.MaxAdults > reservationModel.AmountOfChildren &&
                room.Room.MaxChildren <= reservationModel.AmountOfChildren;

            if (canReserve && isRoomAvailable)
            {
                room.Room.Amount -= 1;
                _context.SaveChanges();
                var days = (reservationModel.ReservationEnd - reservationModel.ReservationStart).TotalDays;
                return Ok(new
                {
                    Price = days * ratePlan.Price
                });
            }
            return BadRequest();
        }
    }
}
