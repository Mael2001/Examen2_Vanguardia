using Hotel.Rates.Data;
using Hotel.Rates.Data.Entities;
using Hotel.Rates.Infraestructure.Repositories;
using Hotel.Rates.Tests.Context;
using Xunit;

namespace Hotel.Rates.Tests.Services
{
    public class RoomRepositoryTests
    {
        [Fact]
        public void Room_Get_True()
        {
            var room = new Room
            {
                Amount = 22,
                Id = -1,
                MaxAdults = 12,
                MaxChildren = 20,
                Name = "Room 12"
            };

            //arange
            var context = DbContextUtils.GetInMemoryContext();
            context.SeedRooms();
            var roomRepository = new RoomRepository(context);

            //act
            var roomResult = roomRepository.Get();
            //assert
            Assert.Contains(roomResult, r => r.Id == room.Id);
        }
    }
}