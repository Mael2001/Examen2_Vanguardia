using System.Collections.Generic;
using Hotel.Rates.Data;

namespace Hotel.Rates.Api.Models
{
    public class RoomDto
    {
        public RoomDto()
        {
            RatePlanRooms = new List<RatePlanRoom>();
        }
        public int Id { get; set; }

        public int MaxAdults { get; set; }

        public int MaxChildren { get; set; }

        public string Name { get; set; }

        public int Amount { get; set; }

        public ICollection<RatePlanRoom> RatePlanRooms { get; set; }
    }
}