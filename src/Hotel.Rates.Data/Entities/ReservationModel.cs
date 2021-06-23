using System;

namespace Hotel.Rates.Data.Entities
{
    public class ReservationModel
    {
        public DateTime ReservationStart { get; set; }

        public DateTime ReservationEnd { get; set; }

        public int RatePlanId { get; set; }

        public int RoomId { get; set; }

        public int AmountOfAdults { get; set; }

        public int AmountOfChildren { get; set; }

    }
}
