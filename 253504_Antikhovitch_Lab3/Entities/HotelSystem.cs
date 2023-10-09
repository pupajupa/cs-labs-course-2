using _253504_Antikhovitch_Lab3.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Antikhovitch_Lab3.Entities
{
    public class HotelSystem : IHotelSystem
    {
        public delegate void HotelHandler(string str);
        public delegate void OccupiedRoomsHandler(string name, string surname, int number);
        public event HotelHandler RoomsChanged;
        public event HotelHandler ClientsChanged;
        public event OccupiedRoomsHandler RoomsOccupied;
        public Dictionary<int,Room> rooms;
        public List<Client> clients;
        public HotelSystem()
        {
            rooms = new Dictionary<int, Room>();
            clients = new List<Client>();
        }

        public void RegisterClient(string name,string surname)
        {
            clients.Add(new Client(name,surname));
            ClientsChanged?.Invoke($"Add new client {name} {surname}");
        }
        public void AddRooms(int number, decimal cost)
        {
            rooms[number] = new Room(number, cost, false);
            RoomsChanged?.Invoke($"Add new room {number}");
        }
        public List<int> GetSortedRoomNumbersByPrice()
        {
            var sortedRooms = rooms
                .OrderBy(keyValue => keyValue.Value.Cost)
                .Select(keyValue => keyValue.Key)
                .ToList();
            return sortedRooms;
        }

        public void OrderRoom(Client client, Room room)
        {
            if (!clients.Contains(client))
            {
                throw new ArgumentException("This client is not found");
            }

            if (!rooms.ContainsValue(room))
            {
                throw new ArgumentException("This room is not found");
            }

            if (!room.IsOccupied)
            {
                room.IsOccupied = true;
                client.OccupiedRooms.Add(room);
                RoomsOccupied?.Invoke(client.Name, client.Surname, room.Number);
            }
            else
            {
                Console.WriteLine("This room is already occupied");
            }
        }
        public Dictionary<int, Room> GetAvailableRooms()
        {
            Dictionary<int, Room> availableRooms = new Dictionary<int, Room>();
            foreach (Room room in rooms.Values)
            {
                if (!room.IsOccupied)
                {
                    availableRooms.Add(room.Number, room);
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
        // Получение общей стоимости всех забронированных в гостинице номеров
        public decimal GetTotalReservedRoomCost()
        {
            decimal totalCost = clients
                .Select(client => CalculateTotalCost(client.Name,client.Surname))
                .Sum();
            return totalCost;
        }

        // Получение имени клиента, заплатившего максимальную сумму
        public string? GetClientWithMaxPayment()
        {
            var clientPayments = clients
                .Select(client => new
                {
                    Client = client,
                    Payment = CalculateTotalCost(client.Name, client.Surname)
                });

            var maxPaymentClient = clientPayments
                .OrderByDescending(x => x.Payment)
                .FirstOrDefault();

            return maxPaymentClient != null ? $"{maxPaymentClient.Client.Name} {maxPaymentClient.Client.Surname}" : "No clients found";
        }
        // Получение количества клиентов, заплативших больше определенной суммы
        public int GetNumberOfClientsPayingMoreThan(decimal amount)
        {
            int count = clients
                .Count(client => CalculateTotalCost(client.Name,client.Surname) > amount);
            return count;
        }

        // Получение списка, показывающего, сколько номеров имеется в гостинице по каждой ценовой категории
        public Dictionary<decimal, int> GetRoomCountByPriceCategory()
        {
            var roomCountByPriceCategory = rooms
                .GroupBy(room => Convert.ToDecimal(room.Value))
                .ToDictionary(group => group.Key, group => group.Count());
            return roomCountByPriceCategory;
        }

        // Метод для получения списка номеров, забронированных клиентом
        public List<Room> GetClientRooms(Client client)
        {
            // Предположим, что у клиентов есть метод для получения списка забронированных номеров
            List<Room> clientRooms = new List<Room>();
            return clientRooms;
        }
    }
}
