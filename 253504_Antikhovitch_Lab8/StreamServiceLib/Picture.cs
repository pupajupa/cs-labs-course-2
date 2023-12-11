using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamServiceLib
{
    public class Picture
    {
        public int ID { get; set; } = 0;
        public string Title { get; set; } = "No Name";
        public string Artist { get; set; } = "No name";

        public Picture(int id, string title, string artist)
        {
            ID = id;
            Title = title;
            Artist = artist;
        }
        public Picture() { }
    }
}
