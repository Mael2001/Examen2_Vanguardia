using Hotel.Rates.Api.Models;
using Hotel.Rates.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialApp.Core;
using Hotel.Rates.Data.Entities;
using Hotel.Rates.Data.Rules;
using Hotel.Rates.Data.Services;
using Hotel.Rates.Infraestructure.Context;

namespace Hotel.Rates.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationsController : ControllerBase
    {
        private readonly ReservationService _reservationService;

        public ReservationsController(ReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost]
        public IActionResult Post([FromBody]ReservationModel reservationModel)
        {
            var ratePlan = _reservationService.canReserve(reservationModel);
            var room = _reservationService.isAvailable(reservationModel);
            if (ratePlan.ResponseCode==ResponseCode.Success &&ratePlan.ResponseCode == ResponseCode.Success)
            {
                var days = (reservationModel.ReservationEnd - reservationModel.ReservationStart).TotalDays;
                var engine = new RuleEngine.Builder()
                    .WithIntervalBuilder()
                    .WithNightlyBuilder()
                    .Build();
                return Ok(new
                {
                    Price = engine.GetPrice(ratePlan.Result,(int) days)
                });
            }
            return BadRequest();
        }
    }
}
