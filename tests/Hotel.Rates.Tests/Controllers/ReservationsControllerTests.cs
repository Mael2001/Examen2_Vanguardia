using Hotel.Rates.Api.Controllers;
using Hotel.Rates.Api.Models;
using Hotel.Rates.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Hotel.Rates.Data.Entities;
using Hotel.Rates.Data.Interfaces;
using Hotel.Rates.Data.Plans;
using Hotel.Rates.Data.Services;
using Hotel.Rates.Infraestructure.Context;
using Moq;
using Xunit;

namespace Hotel.Rates.Tests
{
    public class ReservationsControllerTests
    {
        [Fact]
        public void Post_ValidNightlyRatePlanData_Returns200Ok()
        {
            var reservation = new ReservationModel
            {
                AmountOfAdults = 1,
                AmountOfChildren = 0,
                RatePlanId = -1,
                ReservationStart = new DateTime(2020, 07, 01),
                ReservationEnd = new DateTime(2020, 07, 03),
                RoomId = -1
            };
            var room = new List<Room>
            {
                new Room
                {
                    Amount = 22,
                    Id = -1,
                    MaxAdults = 12,
                    MaxChildren = 20,
                    Name = "Room 12"
                },
                new Room
                {
                    Amount = 222,
                    Id = -2,
                    MaxAdults = 1,
                    MaxChildren = 2,
                    Name = "Room 2"
                }
            };

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
            var connection = new SqliteConnection("Data Source=:memory:");

            connection.Open();

            var dbContextOptions = new DbContextOptionsBuilder<InventoryContext>()
                .UseSqlite(connection)
                .Options;

            var context = new InventoryContext(dbContextOptions);
            context.Database.EnsureCreated();


            var ratePlanRepositoryMock = new Mock<IRepository<RatePlan>>();
            ratePlanRepositoryMock.Setup(t => t.Getid(1))
                .Returns(ratePlans.Rateplan);

            var roomRepositoryMock = new Mock<IRepository<Room>>();
            roomRepositoryMock.Setup(t => t.Get())
                .Returns(room);

            var roomService = new RoomService(roomRepositoryMock.Object);

            var ratePlanService = new RatePlanService(ratePlanRepositoryMock.Object);

            var reservationsService = new ReservationService(ratePlanRepositoryMock.Object, roomRepositoryMock.Object);

            var controller = new ReservationsController(reservationsService);

            var response = controller.Post(reservation);

            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public void Post_ValidIntervalRatePlanData_Returns200Ok()
        {
            var reservation = new ReservationModel
            {
                AmountOfAdults = 1,
                AmountOfChildren = 0,
                RatePlanId = -3,
                ReservationStart = new DateTime(2020, 08, 01),
                ReservationEnd = new DateTime(2020, 08, 03),
                RoomId = -1
            };
            var room = new List<Room>
            {
                new Room
                {
                    Amount = 22,
                    Id = -1,
                    MaxAdults = 12,
                    MaxChildren = 20,
                    Name = "Room 12"
                },
                new Room
                {
                    Amount = 222,
                    Id = -2,
                    MaxAdults = 1,
                    MaxChildren = 2,
                    Name = "Room 2"
                }
            };

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
            var connection = new SqliteConnection("Data Source=:memory:");

            connection.Open();

            var dbContextOptions = new DbContextOptionsBuilder<InventoryContext>()
                .UseSqlite(connection)
                .Options;

            var context = new InventoryContext(dbContextOptions);
            context.Database.EnsureCreated();


            var ratePlanRepositoryMock = new Mock<IRepository<RatePlan>>();
            ratePlanRepositoryMock.Setup(t => t.Getid(1))
                .Returns(ratePlans.Rateplan);

            var roomRepositoryMock = new Mock<IRepository<Room>>();
            roomRepositoryMock.Setup(t => t.Get())
                .Returns(room);

            var roomService = new RoomService(roomRepositoryMock.Object);

            var ratePlanService = new RatePlanService(ratePlanRepositoryMock.Object);

            var reservationsService = new ReservationService(ratePlanRepositoryMock.Object,roomRepositoryMock.Object);

            var controller = new ReservationsController(reservationsService);
            
            var response = controller.Post(reservation);

            Assert.IsType<OkObjectResult>(response);
        }
    }
}
