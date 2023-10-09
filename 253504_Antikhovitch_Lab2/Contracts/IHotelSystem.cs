using _253504_Antikhovitch_Lab2.Collections;
using _253504_Antikhovitch_Lab2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Antikhovitch_Lab2.Contracts
{
    public interface IHotelSystem
    {
        void RegisterClient(Client client);
        void AddRooms(Room room);
        void OrderRoom(Client client, Room room);
        MyCustomCollection<Room> GetAvailableRooms();
        decimal CalculateTotalCost(string name,string surname);
    }
}
