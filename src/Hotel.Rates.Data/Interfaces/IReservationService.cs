using System;
using FinancialApp.Core;
using Hotel.Rates.Data.Entities;

namespace Hotel.Rates.Data.Interfaces
{
    public interface IReservationService
    {
        ServiceResult<RatePlan> canReserve (ReservationModel reservation);
        ServiceResult<Room> isAvailable(ReservationModel reservation);
    }
}