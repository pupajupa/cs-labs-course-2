using _253504_Antikhovitch_Lab1.Entities;

namespace _253504_Antikhovitch_Lab1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var hotelSystem = new HotelSystem<decimal>();

            var room101 = new Room (101, 100, false);
            var room102 = new Room (102, 150, false);
            var room72 = new Room(72, 150, false);
            var room8 = new Room(8, 150, false);
            hotelSystem.rooms.Add(room72);
            hotelSystem.rooms.Add(room8);
            hotelSystem.rooms.Add(room101);
            hotelSystem.rooms.Add(room102);
            hotelSystem.RegisterClient(new Client("Pupa", "Jupa"));

            hotelSystem.OrderRoom(hotelSystem.clients[0], room101);
            hotelSystem.OrderRoom(hotelSystem.clients[0], room102);

            var availableRooms = hotelSystem.GetAvailableRooms();
            Console.WriteLine("Available Rooms:");
            foreach (var room in availableRooms)
            {
                Console.WriteLine($"Room {room.Number}, Cost: {room.Cost}");
            }
            decimal totalCost = hotelSystem.CalculateTotalCost(hotelSystem.clients[0]);
            Console.WriteLine($"Total cost for Pupa Jupa: {totalCost}");
            Console.ReadKey();
        }
    }
}