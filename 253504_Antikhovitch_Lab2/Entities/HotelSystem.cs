using _253504_Antikhovitch_Lab2.Collections;
using _253504_Antikhovitch_Lab2.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Antikhovitch_Lab2.Entities
{
    public class HotelSystem:IHotelSystem
    {
        public delegate void HotelHandler(string str);
        public delegate void OccupiedRoomsHandler(string name, string surname, int number);
        public event HotelHandler RoomsChanged;
        public event HotelHandler ClientsChanged;
        public event OccupiedRoomsHandler RoomsOccupied;
        public MyCustomCollection<Room> rooms;
        public MyCustomCollection<Client> clients;
        public HotelSystem()
        {
            rooms = new MyCustomCollection<Room>();
            clients = new MyCustomCollection<Client>();
        }

        public void RegisterClient(Client client)
        {
            clients.Add(client);
            ClientsChanged?.Invoke($"Add new client {client.Name} {client.Surname}");
        }
        public void AddRooms(Room room)
        {
            rooms.Add(room);
            RoomsChanged?.Invoke($"Add new room {room.Number}");
        }
        public void OrderRoom(Client client, Room room)
        {
            bool flag = true;
            foreach(var cl in clients)
            {
                if(cl == client)
                {
                    flag = false;
                    break;
                }
                else
                {
                    continue;
                }
            }
            if (flag)
            {
                throw new ArgumentException("This client is not founded");
            }
            flag = true;
            foreach(var r in rooms)
            {
                if(r == room)
                {
                    flag = false;
                    break;
                }
                else
                {
                    continue;
                }
            }
            if (flag)
            {
                throw new ArgumentException("This room is not founded");
            }
            if (!room.IsOccupied)
            {
                room.IsOccupied = true;
                client.OccupiedRooms.Add(room);
                RoomsOccupied?.Invoke(client.Name, client.Surname,room.Number);
            }
            else
            {
                Console.WriteLine("This room is already occupied");
            }
        }
        public MyCustomCollection<Room> GetAvailableRooms()
        {
            MyCustomCollection<Room> availableRooms = new MyCustomCollection<Room>();
            foreach (Room room in rooms)
            {
                if (!room.IsOccupied)
                {
                    availableRooms.Add(room);
                }
            }
            return availableRooms;
        }
        public decimal CalculateTotalCost(string name, string surname)
        {
            decimal totalCost = 0;
            foreach (var client in clients)
            {
                if (client.Name == name && client.Surname == surname)
                {
                    foreach (var room in client.OccupiedRooms)
                    {
                        if (room.IsOccupied)
                        {
                            totalCost += room.Cost;
                        }
                    }
                }
            }
            if (totalCost == 0)
            {
                throw new ArgumentNullException("This client was not found");
            }
            return totalCost;
        }
    }
}
