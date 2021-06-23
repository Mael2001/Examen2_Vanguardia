using System.Collections.Generic;
using FinancialApp.Core;
using Hotel.Rates.Data.Entities;

namespace Hotel.Rates.Data.Interfaces
{
    public interface IRoomService
    {
        ServiceResult<IReadOnlyList<Room>> GetRooms();
        ServiceResult<bool> DecreaceResult(Room room);
    }
}