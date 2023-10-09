using _253504_Antikhovitch_Lab3.Entities;

namespace _253504_Antikhovitch_Lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal();
            HotelSystem hotel = new HotelSystem();

            //подписка на события
            hotel.RoomsChanged += journal.RegisterEvent;
            hotel.ClientsChanged += journal.RegisterEvent;
            hotel.RoomsOccupied += (clientname, clientsurname, roomnumber) =>
            {
                string eventinfo = $"Client {clientname} {clientsurname} booked a room {roomnumber}.";
                journal.RegisterEvent(eventinfo);
            };

            hotel.RegisterClient("Pupa", "Jupa");
            hotel.RegisterClient("Ivan", "Mice");
            hotel.AddRooms(11, 6666);
            hotel.AddRooms(22, 7777);
            hotel.AddRooms(33, 8888);
            hotel.AddRooms(44, 9999);
            hotel.AddRooms(128, 42301);
            hotel.AddRooms(88, 500);
            hotel.OrderRoom(hotel.clients[0], hotel.rooms[11]);
            hotel.OrderRoom(hotel.clients[1], hotel.rooms[22]);
            hotel.OrderRoom(hotel.clients[0], hotel.rooms[33]);
            hotel.OrderRoom(hotel.clients[1], hotel.rooms[44]);
            hotel.OrderRoom(hotel.clients[1], hotel.rooms[128]);
            hotel.OrderRoom(hotel.clients[1], hotel.rooms[88]);
            journal.PrintEvents();
            Console.WriteLine();

            //список комнат, отсортированный по стоимости
            var sortedRoomNumberByPrice = hotel.GetSortedRoomNumbersByPrice();
            Console.WriteLine("Rooms list sorted by price:");
            foreach (var number in sortedRoomNumberByPrice)
            {
                Console.WriteLine($"Room {number}");
            }

            //стоимость всех забронированных комнат
            decimal totalCost = hotel.GetTotalReservedRoomCost();
            Console.WriteLine($"The total cost of all the tickets: {totalCost}");

            //Общая стоимость комнат забронированных клиентом
            decimal totalCostClient = hotel.CalculateTotalCost("Pupa", "Jupa");
            Console.WriteLine($"Total cost of rooms booked by the client: {totalCostClient}");

            //Имя клиента, заплатившего максимальную сумму
            string ?сlientWithMaxCost = hotel.GetClientWithMaxPayment();
            Console.WriteLine($"Сlient who has paid the maximum amount of money: {сlientWithMaxCost}");

            //Количество клиентов, которые заплатили больше 1000
            int clientAbove = hotel.GetNumberOfClientsPayingMoreThan(1000);
            Console.WriteLine($"Number of customers paying more than 1,000: {clientAbove}");
        }
    }
}