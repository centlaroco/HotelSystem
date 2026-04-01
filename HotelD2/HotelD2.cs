using System;

namespace HotelD2.Hotel
{
    // Abstract base class (the process of hiding certain details and showing only important information to the user)
    abstract class Room
    {
        // private fields (encapsulation)
        private int roomNumber;
        private double price;
        private bool nakaBooked; // tracks booking status

        // public properties (getters and setters)
        public int RoomNumber{
            get{return roomNumber;}
            set{roomNumber= value;}
        }

        public double Price{
            get{return price;}
            set{price= value;}
        }

        public bool NakaBooked{
            get{return nakaBooked;}
            set{nakaBooked= value;}
        }

        // automated properties of user infos
        public string Name{get; set;}
        public int Age{get; set;}
        public string Address{get; set;}

        // Constructor to initialize room details
        public Room(int RoomNumber, double Price){
            roomNumber=RoomNumber;
            price=Price;
            nakaBooked=false; // default: if the availability is not booked
        }

        // Static constructor (runs once when program starts)
        static Room(){
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n===WELCOME TO HOTEL 2D===");
            Console.ResetColor();
        }

        // Method to book a room
        public void BookARoom()
        {
            if(nakaBooked){
                Console.WriteLine($"Room {roomNumber} is already booked. Please choose another room.");
                return;
            }
            
                nakaBooked=true; // mark the room as booked
                // Display booking details
                Console.WriteLine("\n\t===Booking Details===");
                Console.WriteLine($"Name: {Name}");
                Console.WriteLine($"Age: {Age}");
                Console.WriteLine($"Address: {Address}");
                Console.WriteLine($"Room Number: {roomNumber}");
                Console.WriteLine($"Room Type: {DisplayRoomType()}");
                Console.WriteLine($"Room {roomNumber} booked successfully.");
                Console.WriteLine("============================");
            

        }

        // method to cancel booking
        public void CancelBooking()
        {
            if(nakaBooked)
            {
                nakaBooked=false;
                Console.WriteLine($"Cancelled Book: {roomNumber}");
            }
            else{
                Console.WriteLine($"Room {roomNumber} is not booked.");
            }
        }

        // abstract method (implemented by derived classes) defines the room type
        public abstract string DisplayRoomType();

        // virtual method it could be overriden
        public virtual void DisplayHotelInfo()
        {
            Console.WriteLine($"{DisplayRoomType()} | Room: {roomNumber} | Price: {price} | Available: {(nakaBooked ? "No" : "Yes")}");  
        }
    }

    // Different room types (inheritance + polymorphism)
    class SkwaaMoor: Room
    {
        public SkwaaMoor(int RoomNumber, double Price): base(RoomNumber, Price){}

        public override string DisplayRoomType()
        {
            return "Skwaa Room";
        }
        
    }

    class ChakaMoor: Room
    {
        public ChakaMoor(int RoomNumber, double Price): base(RoomNumber,Price){}

        public override string DisplayRoomType()
        {
            return "Chaka Room";
        }
    }

    class NormalMoor: Room
    {
        public NormalMoor(int RoomNumber, double Price): base(RoomNumber,Price){}

        public override string DisplayRoomType()
        {
            return "Normal Room";
        }
    }

    class LayshoMoor: Room
    {
        public LayshoMoor(int RoomNumber, double Price): base(RoomNumber,Price){}

        public override string DisplayRoomType()
        {
            return "Laysho Room";
        }
    }

    class DeluxeMoor: Room
    {
        public DeluxeMoor(int RoomNumber, double Price): base(RoomNumber,Price){}

        public override string DisplayRoomType()
        {
            return "Deluxe Room";
        }
    }

    // Abstract Payment class (Polymorphism)
    abstract class Payment
    {
        public abstract void Pay(double amount);
    }

    // cash payment implementation 
    class CashPayment: Payment
    {
        public override void Pay(double amount)
        {
            Console.WriteLine($"Received {amount} in cash");
            Console.WriteLine("Thanks for paying in cash");
        }
    }

    // credit payment implementation
    class CreditPayment: Payment
    {
        public override void Pay(double amount)
        {
            Console.WriteLine($"Received {amount} in credit");
            Console.WriteLine("Thanks for paying in Credit");
        }
    }
}