using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Antikhovitch_Lab2.Entities
{
    public class Room
    {
        public int Number { get; set; }
        public decimal Cost { get; set; }
        public bool IsOccupied { get; set; }
        public Room(int number, decimal cost, bool isOccupied)
        {
            Number = number;
            Cost = cost;
            IsOccupied = isOccupied;
        }
    }
}