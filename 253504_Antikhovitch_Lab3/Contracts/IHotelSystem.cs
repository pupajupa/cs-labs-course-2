using _253504_Antikhovitch_Lab3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Antikhovitch_Lab3.Contracts
{
    public interface IHotelSystem
    {
        void RegisterClient(string name, string surname);
        public void AddRooms(int number, decimal cost);
        void OrderRoom(Client client, Room room);
        Dictionary<int,Room> GetAvailableRooms();
        decimal CalculateTotalCost(string name, string surname);
        int GetNumberOfClientsPayingMoreThan(decimal amount);
        Dictionary<decimal, int> GetRoomCountByPriceCategory();
        List<Room> GetClientRooms(Client client);
    }
}
