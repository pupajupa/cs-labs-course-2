﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Antikhovitch_Lab3.Entities
{
    public class Client
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Room> OccupiedRooms { get; set; }
        public Client(string name, string surname)
        {
            Name = name;
            Surname = surname;
            OccupiedRooms = new List<Room>();
        }
    }
}
