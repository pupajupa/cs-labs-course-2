using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Antikhovitch_Lab5.Domain
{
    public interface ISerializer
    {
        IEnumerable<CCC> DeSerializeByLINQ(string fileName);
        IEnumerable<CCC> DeSerializeXML(string fileName);
        IEnumerable<CCC> DeSerializeJSON(string fileName);
        void SerializeByLINQ(IEnumerable<CCC> xxx, string fileName);
        void SerializeXML(IEnumerable<CCC> xxx, string fileName);
        void SerializeJSON(IEnumerable<CCC> xxx, string fileName);
    }
}
