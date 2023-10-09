using _253504_Antikhovitch_Lab1.Collections;
using _253504_Antikhovitch_Lab1.Contracts;
using _253504_Antikhovitch_Lab1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Antikhovitch_Lab1.Entities
{
    public class HotelSystem<T>:IHotelSystem<T>
    {
        public MyCustomCollection<Room> rooms;
        public MyCustomCollection<Client> clients;
        private MathOperation mathOperation;
        public HotelSystem()
        {
            rooms = new MyCustomCollection<Room>();
            clients = new MyCustomCollection<Client>();
            mathOperation = new MathOperation();
        }

        public void RegisterClient(Client client)
        {
            clients.Add(client);
        }
        public void OrderRoom(Client client, Room room) 
        {
            if (!room.IsOccupied)
            {
                room.IsOccupied = true;
                client.OccupiedRooms.Add(room);
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
                if (!room.IsOccupied){
                    availableRooms.Add(room);
                }
            }
            return availableRooms;
        }
        public decimal CalculateTotalCost(Client client) 
        {
            decimal totalCost = 0;
            foreach(var room in client.OccupiedRooms)
            {
                if (room.IsOccupied)
                {
                    totalCost=mathOperation.Add(totalCost, room.Cost);
                }
            }
            return totalCost;
        }
    }
}
