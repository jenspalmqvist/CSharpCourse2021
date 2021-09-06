using System;
using System.Collections.Generic;
using System.Text;

namespace HotelOrganization
{
    class Room
    {
        public int PricePerNight { get; set; }
        public RoomType Type { get; set; }
        public bool IsAvailable { get; set; }

        public Room()
        {
        }

        public Room(int pricePerNight, RoomType type, bool isAvailable)
        {
            PricePerNight = pricePerNight;
            Type = type;
            IsAvailable = isAvailable;
        }

        public override string ToString()
        {
            return $"This is a {Type} room, it costs {PricePerNight}" +
                $" kr per night and is {(IsAvailable ? "available" : "not available")}";
        }
    }
}