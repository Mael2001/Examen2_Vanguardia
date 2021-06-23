using Hotel.Rates.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialApp.Core;
using Hotel.Rates.Data.Services;
using Hotel.Rates.Infraestructure.Context;

namespace Hotel.Rates.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatePlansController : ControllerBase
    {
        private readonly RatePlanService _ratePlanService;

        public RatePlansController(RatePlanService ratePlanService)
        {
            _ratePlanService = ratePlanService;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            var result = _ratePlanService.GetRatePlans().Result
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
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (_ratePlanService.GetRatePlanById(id).ResponseCode == ResponseCode.Error)
            {
                return BadRequest();
            }
            var ratePlan = _ratePlanService.GetRatePlanById(id).Result;

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
