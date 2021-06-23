﻿using System;
using System.Linq;
using FinancialApp.Core;
using Hotel.Rates.Data.Entities;
using Hotel.Rates.Data.Interfaces;
using Microsoft.EntityFrameworkCore.Internal;

namespace Hotel.Rates.Data.Services
{
    public class ReservationService: IReservationService
    {
        private readonly IRepository<RatePlan> _ratePlanRepository;
        private readonly IRepository<Room> _roomRepository;

        public ReservationService(IRepository<RatePlan> ratePlanRepository,
            IRepository<Room> roomRepository)
        {
            _ratePlanRepository = ratePlanRepository;
            _roomRepository = roomRepository;
        }
        public ServiceResult<RatePlan> canReserve(int id, ReservationModel reservation)
        {
            var ratePlan = _ratePlanRepository.Getid(id);
            if (ratePlan.Seasons.Any(s => s.StartDate >= reservation.ReservationStart && s.EndDate <= reservation.ReservationEnd))
            {
                return ServiceResult<RatePlan>.SuccessResult(ratePlan);
            }

            return ServiceResult<RatePlan>.ErrorResult($"Can't Reserve");
        }

        public ServiceResult<Room> isAvailable(int id, ReservationModel reservation)
        {
            var room = _ratePlanRepository.Getid(id)
                .RatePlanRooms.FirstOrDefault(x => x.RoomId == reservation.RoomId && x.RatePlanId == reservation.RatePlanId);
            if (room.Room.Amount > 0 &&
                room.Room.MaxAdults > reservation.AmountOfChildren &&
                room.Room.MaxChildren <= reservation.AmountOfChildren)
            {
                return ServiceResult<Room>.SuccessResult(room.Room);
            }
            
            return ServiceResult<Room>.ErrorResult($"Is not Available");
        }
    }
}