using _253504_Antikhovitch_Lab1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Antikhovitch_Lab1.Entities
{
    public class MathOperation : IMathOperation<decimal>
    {
        public decimal Add(decimal a, decimal b) => a + b;
        public decimal Subtract(decimal a, decimal b) => a - b;
        public decimal Multiply(decimal a, decimal b) => a * b;
        public decimal Divide(decimal a, decimal b) => a / b;
    }
}
