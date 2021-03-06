using System.Collections.Generic;
using FinancialApp.Core;
using Hotel.Rates.Data.Entities;
using Hotel.Rates.Data.Interfaces;

namespace Hotel.Rates.Data.Services
{
    public class RoomService: IRoomService
    {
        private readonly IRepository<Room> _roomRepository;

        public RoomService(IRepository<Room> roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public ServiceResult<IReadOnlyList<Room>> GetRooms()
        {
            return ServiceResult<IReadOnlyList<Room>>.SuccessResult(_roomRepository.Get());
        }

        public ServiceResult<bool> DecreaceResult(Room room)
        {
            _roomRepository.Decreace(room);
            return ServiceResult<bool>.SuccessResult(true);
        }
    }
}