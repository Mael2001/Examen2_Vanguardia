using System.Collections.Generic;
using Hotel.Rates.Data;
using Hotel.Rates.Data.Entities;
using Hotel.Rates.Data.Plans;
using Hotel.Rates.Infraestructure.Repositories;
using Hotel.Rates.Tests.Context;
using Moq;
using Xunit;

namespace Hotel.Rates.Tests.Services
{
    public class RatePlanRepositoryTests
    {
        [Fact]
        public void RatePlan_Get_True()
        {
            var ratePlans = new RatePlanRoom
            {
                Room = new Room
                {
                    Name = "Room 1",
                    Amount = 200,
                },
                RatePlanId = 20,

            };

            //arange
            var context = DbContextUtils.GetInMemoryContext();
            context.SeedRatePlans();
            var ratePlanRepository = new RatePlanRepository(context);

            //act
            var ratePlansResult = ratePlanRepository.Get();
            //assert
            Assert.Contains(ratePlansResult, r => r.Id==ratePlans.RatePlanId);
        }
        [Fact]
        public void RatePlan_GetbyId_True()
        {
            var ratePlans = new RatePlanRoom
            {
                Room = new Room
                {
                    Name = "Room 1",
                    Amount = 200,
                },
                RatePlanId = 20,
                Rateplan = new IntervalRatePlan
                {
                    Name = "Prueba",
                    Id = 2,
                    RatePlanType = 1,
                    Price = 20,
                    RatePlanRooms = new List<RatePlanRoom>{},
                    Seasons = new List<Season>(),
                    IntervalLength = 2
                }
            };

            //arange
            var context = DbContextUtils.GetInMemoryContext();
            context.SeedRatePlans();
            var ratePlanRepository = new RatePlanRepository(context);

            //act
            var ratePlansResult = ratePlanRepository.Getid(2);
            //assert
            Assert.Equal(ratePlansResult.Id,ratePlans.Rateplan.Id);
        }
    }
}