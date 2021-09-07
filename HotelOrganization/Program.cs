using System;
using System.Collections.Generic;
using ConsoleCompanion;

namespace HotelOrganization
{
    class Program
    {
        static void Main(string[] args)
        {
            Hotel hotel = new Hotel(new List<Room> {
                new Room(1200, RoomType.Single, true),
                new Room(1200, RoomType.Single, true),
                new Room(1500, RoomType.Double, true),
                new Room(1500, RoomType.Double, true),
                new Room(2200, RoomType.Suite, false),
                new Room(2200, RoomType.Suite, true)
            });

            List<Room> availableSingleRooms = hotel.Rooms
                .FindAll(room => room.Type == RoomType.Single && room.IsAvailable);

            // Gör en foreach-loop över hotel.Rooms, returnerar alla rum där logiken blir true;
            foreach (Room room in availableSingleRooms)
            {
                Console.WriteLine(room);
            }
            //hotel.ListRooms();
        }
    }
}

// Hotell
// Antal rum

// Pris
// Typ av rum

// Antal personer i sällskapet
// Antal nätter
// Barn/vuxna
// Frukost eller inte
// All-inclusive