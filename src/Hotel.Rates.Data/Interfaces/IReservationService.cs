using System;
using FinancialApp.Core;
using Hotel.Rates.Data.Entities;

namespace Hotel.Rates.Data.Interfaces
{
    public interface IReservationService
    {
        ServiceResult<RatePlan> canReserve(int id, ReservationModel reservation);
        ServiceResult<Room> isAvailable(int id, ReservationModel reservation);
    }
}