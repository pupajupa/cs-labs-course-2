using _253504_Antikhovitch_Lab2.Entities;
using _253504_Antikhovitch_Lab2.Collections;
using _253504_Antikhovitch_Lab2.Contracts;
using System.Collections.Immutable;

namespace _253504_Antikhovitch_Lab2
{
    public class Program
    {

        static void Main(string[] args)
        {
            HotelSystem hotel = new HotelSystem();
            Journal journal = new Journal();
            hotel.RoomsChanged+=journal.RegisterEvent;
            hotel.ClientsChanged += journal.RegisterEvent;
            hotel.RoomsOccupied += (clientname, clientsurname, roomnumber) =>
            {
                string eventinfo = $"Client {clientname} {clientsurname} booked a room {roomnumber}.";
                journal.RegisterEvent(eventinfo);
            };
            hotel.RegisterClient(new Client("Pupa", "Jupa"));
            hotel.RegisterClient(new Client("Ivan", "Mice"));
            hotel.AddRooms(new Room(11, 6666, false));
            hotel.AddRooms(new Room(22, 7777, false));
            hotel.AddRooms(new Room(33, 8888, false));
            hotel.AddRooms(new Room(44, 9999, false));
            hotel.OrderRoom(hotel.clients[0], hotel.rooms[0]);
            hotel.OrderRoom(hotel.clients[1], hotel.rooms[1]);
            hotel.OrderRoom(hotel.clients[0], hotel.rooms[2]);
            hotel.OrderRoom(hotel.clients[1], hotel.rooms[3]);
            journal.PrintEvents();
            Console.WriteLine($"Room rates booked by customer Pupa Jupa : {hotel.CalculateTotalCost("Pupa", "Jupa")}");
            Console.WriteLine($"Room rates booked by customer Ivan Mice : {hotel.CalculateTotalCost("Ivan", "Mice")}");
        }
    }
}