using System;
using HotelD2.Hotel;

namespace HotelD2
{
    class HotelService
    {
        private Room[] rooms;

        public HotelService()
        {
            rooms = new Room[5];

            rooms[0] = new SkwaaMoor(101, 500);
            rooms[1] = new ChakaMoor(103, 1000);
            rooms[2] = new NormalMoor(201, 2500);
            rooms[3] = new LayshoMoor(302, 5500);
            rooms[4] = new DeluxeMoor(403, 11000);
        }
        public void ShowRooms()
        {
            for (int i = 0; i < rooms.Length; i++)
            {
                rooms[i].DisplayHotelInfo();
            }
        }

        public Room FindRoom(int number)
        {
            for (int i = 0; i < rooms.Length; i++)
            {
                if (rooms[i].RoomNumber == number)
                {
                    return rooms[i];
                }
            }
            return null;
        }

        public void ShowUsers()
        {
            bool hasBooked = false;

            for (int i = 0; i < rooms.Length; i++)
            {
                if (rooms[i].NakaBooked)
                {
                    hasBooked = true;
                    Console.WriteLine("\n------------------------");
                    Console.WriteLine($"Name: {rooms[i].Name}");
                    Console.WriteLine($"Age: {rooms[i].Age}");
                    Console.WriteLine($"Address: {rooms[i].Address}");
                    Console.WriteLine($"Room Number: {rooms[i].RoomNumber}");
                    Console.WriteLine($"Room Type: {rooms[i].DisplayRoomType()}");
                    Console.WriteLine($"Price: ${rooms[i].Price:f2}");
                }
            }

            if (!hasBooked)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("No users have booked yet");
                Console.ResetColor();
            }
        }
    }
}