using System;
using System.Collections.Generic;
using System.Text;

namespace HotelOrganization
{
    class Hotel
    {
        public List<Room> Rooms { get; set; }
        public int Revenue { get; set; }

        public Hotel()
        {
            Rooms = new List<Room>();
        }

        public Hotel(List<Room> rooms)
        {
            Rooms = rooms;
        }

        public void RentRoom(Room room, int numberOfNights)
        {
            if (!room.IsAvailable)
            {
                Console.WriteLine("Room is not available!");
            }
            else
            {
                Revenue += numberOfNights * room.PricePerNight;
                room.IsAvailable = false;
                Console.WriteLine("Room is now rented out for {0}",
                    numberOfNights * room.PricePerNight);
            }
        }

        public void CheckoutRoom(Room room)
        {
            room.IsAvailable = true;
        }

        public void ListRooms()
        {
            foreach (Room room in Rooms)
            {
                Console.WriteLine(room.ToString());
            }
        }
    }
}