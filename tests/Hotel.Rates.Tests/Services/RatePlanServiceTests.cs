using System.Collections.Generic;
using Hotel.Rates.Data;
using Hotel.Rates.Data.Entities;
using Hotel.Rates.Data.Interfaces;
using Hotel.Rates.Data.Plans;
using Hotel.Rates.Data.Services;
using Hotel.Rates.Infraestructure.Repositories;
using Hotel.Rates.Tests.Context;
using Moq;
using Xunit;

namespace Hotel.Rates.Tests.Services
{
    public class RatePlanServiceTests
    {
        [Fact]
        public void RatePlanInterval_Get_True()
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
                    RatePlanRooms = new List<RatePlanRoom> { },
                    Seasons = new List<Season>(),
                    IntervalLength = 2
                }
            };

            var ratePlanRepositoryMock = new Mock<IRepository<RatePlan>>();
            ratePlanRepositoryMock.Setup(t => t.Getid(1))
                .Returns(ratePlans.Rateplan);

            var ratePlanService = new RatePlanService(ratePlanRepositoryMock.Object);

            var result = ratePlanService.GetRatePlanById(1);
            Assert.Equal(result.Result,ratePlans.Rateplan);
        }
        [Fact]
        public void RatePlanNightly_Get_True()
        {
            var ratePlans = new RatePlanRoom
            {
                Room = new Room
                {
                    Name = "Room 1",
                    Amount = 200,
                },
                RatePlanId = 20,
                Rateplan = new NightlyRatePlan
                {
                    Name = "Prueba",
                    Id = 2,
                    RatePlanType = 1,
                    Price = 20,
                    RatePlanRooms = new List<RatePlanRoom> { },
                    Seasons = new List<Season>()
                }
            };

            var ratePlanRepositoryMock = new Mock<IRepository<RatePlan>>();
            ratePlanRepositoryMock.Setup(t => t.Getid(1))
                .Returns(ratePlans.Rateplan);

            var ratePlanService = new RatePlanService(ratePlanRepositoryMock.Object);

            var result = ratePlanService.GetRatePlanById(1);
            Assert.Equal(result.Result, ratePlans.Rateplan);
        }
    }
}