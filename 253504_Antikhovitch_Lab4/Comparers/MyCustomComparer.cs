using _253504_Antikhovitch_Lab4.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Antikhovitch_Lab4.Comparers
{
    public class MyCustomComparer:IComparer<ArtObject>
    {
        public int Compare(ArtObject x, ArtObject y) => string.Compare(x.Name, y.Name);
    }
}
