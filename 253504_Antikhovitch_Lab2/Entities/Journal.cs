using _253504_Antikhovitch_Lab2.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Antikhovitch_Lab2.Entities
{
    public class Journal
    {
        private MyCustomCollection<string> events = new MyCustomCollection<string>();
        public void RegisterEvent(string eventInfo)
        {
            events.Add(eventInfo);
        }
        public void PrintEvents()
        {
            foreach (var e in events)
            {
                Console.WriteLine(e);
            }
        }
    }
}
