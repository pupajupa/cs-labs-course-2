using _253504_Antikhovitch_Lab1.Collections;
using _253504_Antikhovitch_Lab1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Antikhovitch_Lab1.Contracts
{
    public interface IHotelSystem<T>
    {
        void RegisterClient(Client client);
        void OrderRoom(Client client, Room room);
        MyCustomCollection<Room> GetAvailableRooms();
        decimal CalculateTotalCost(Client client);
    }
}
