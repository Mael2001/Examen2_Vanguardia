using Hotel.Rates.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Rates.Data.Services;
using Hotel.Rates.Infraestructure.Context;

namespace Hotel.Rates.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatePlansController : ControllerBase
    {
        private readonly RatePlanService _ratePlanService;
        private readonly InventoryContext _context;

        public RatePlansController(RatePlanService ratePlanService,  InventoryContext context)
        {
            _ratePlanService = ratePlanService;
            _context = context;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            var result = _context.RatePlans.Include(r => r.Seasons).Include(r => r.RatePlanRooms).ThenInclude(r => r.Room)
                .Select(x => new
                {
                    RatePlanId = x.Id,
                    RatePlanName = x.Name,
                    x.RatePlanType,
                    x.Price,
                    Seasons = x.Seasons.Select(s => new
                    {
                        s.Id,
                        s.StartDate,
                        s.EndDate
                    }),
                    Rooms = x.RatePlanRooms.Select(r => new
                    {
                        r.Room.Name,
                        r.Room.MaxAdults,
                        r.Room.MaxChildren,
                        r.Room.Amount
                    })
                });
            return Ok(_ratePlanService.GetRatePlans());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var ratePlan = _context.RatePlans
                .Include(r => r.Seasons)
                .Include(r => r.RatePlanRooms)
                .ThenInclude(r => r.Room)
                .FirstOrDefault(x => x.Id == id);

            return Ok(new
            {
                RatePlanId = ratePlan.Id,
                RatePlanName = ratePlan.Name,
                ratePlan.RatePlanType,
                ratePlan.Price,
                Seasons = ratePlan.Seasons.Select(s => new
                {
                    s.Id,
                    s.StartDate,
                    s.EndDate
                }),
                Rooms = ratePlan.RatePlanRooms.Select(r => new
                {
                    r.Room.Name,
                    r.Room.MaxAdults,
                    r.Room.MaxChildren,
                    r.Room.Amount
                })
              });
        }
    }
}
