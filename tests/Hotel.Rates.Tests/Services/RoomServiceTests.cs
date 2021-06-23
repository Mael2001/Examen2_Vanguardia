using System.Collections.Generic;
using FinancialApp.Core;
using Hotel.Rates.Data;
using Hotel.Rates.Data.Entities;
using Hotel.Rates.Data.Interfaces;
using Hotel.Rates.Data.Services;
using Hotel.Rates.Infraestructure.Repositories;
using Hotel.Rates.Tests.Context;
using Moq;
using Xunit;

namespace Hotel.Rates.Tests.Services
{
    public class RoomServiceTests
    {
        [Fact]
        public void Room_Get_True()
        {
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
            
            var roomRepositoryMock = new Mock<IRepository<Room>>();
            roomRepositoryMock.Setup(t => t.Get())
                .Returns(room);

            var ratePlanService = new RoomService(roomRepositoryMock.Object);

            var result = ratePlanService.GetRooms();
            Assert.Equal(result.ResponseCode, ResponseCode.Success);
        }
    }
}