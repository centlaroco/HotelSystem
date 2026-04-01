using System;
using HotelD2.Hotel;

namespace HotelD2
{
    class Menu
    {
        private HotelService service = new HotelService();

        public void Start()
        {
            int pili = 0;

            while (pili != 5)
            {
                Console.WriteLine("\n++Book a Hotel++");
                Console.WriteLine("\t(1) All Rooms");
                Console.WriteLine("\t(2) Book a Room");
                Console.WriteLine("\t(3) Cancel Booking");
                Console.WriteLine("\t(4) User Info");
                Console.WriteLine("\t(5) Exit");


                Console.Write("Enter Number: ");
                Console.ForegroundColor= ConsoleColor.Yellow;
                pili = Convert.ToInt32(Console.ReadLine());
                Console.ResetColor();

                if (pili == 1)
                {
                    service.ShowRooms();
                }
                else if (pili == 2)
                {
                    BookRoom();
                }
                else if (pili == 3)
                {
                    CancelRoom();
                }
                else if (pili == 4)
                {
                    service.ShowUsers();
                }
                else if (pili == 5)
                {
                    Console.WriteLine("Bye thanks for Booking a Room");
                }
                else
                {
                    Console.WriteLine("Invalid");
                }
            }
        }

        private void BookRoom()
        {
            Console.Write("Enter Room Number: ");
            int num = Convert.ToInt32(Console.ReadLine());

            Room room = service.FindRoom(num);

            if (room == null)
            {
                Console.WriteLine("Room not found");
                return;
            }

            if(room.NakaBooked)
            {
                Console.WriteLine($"Room {room.RoomNumber} is already booked. Please choose another room.");
                return;
            }

            Console.Write("Enter your name: ");
            room.Name = Console.ReadLine();

            Console.Write("Enter your age: ");
            room.Age = Convert.ToInt32(Console.ReadLine());

            if (room.Age < 18)
            {
                Console.WriteLine("You are still a minor");
                return;
            }

            Console.Write("Enter your address: ");
            room.Address = Console.ReadLine();

            Console.WriteLine("Payment Options:");
            Console.WriteLine("(1) Cash");
            Console.WriteLine("(2) Credit");
            Console.Write("Choose payment: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            Payment payment = null;
            string paymentType = "";

            if (choice == 1)
            {
                payment = new CashPayment();
                paymentType = "Cash";
            }
            else if (choice == 2)
            {
                payment = new CreditPayment();
                paymentType = "Credit";
            }

            if(payment==null)
            {
                Console.WriteLine("Booking cancelled due to invalid payment choice");
                return;
            }

            room.BookARoom();

            if (payment != null)
            {
                Console.WriteLine($"Payment: {paymentType}");
                payment.Pay(room.Price);
            }
        }

        private void CancelRoom()
        {
            Console.Write("Enter Room Number: ");
            int num = Convert.ToInt32(Console.ReadLine());

            Room room = service.FindRoom(num);

            if (room == null)
            {
                Console.WriteLine("Room not found");
                return;
            }

            room.CancelBooking();
        }
    }
}