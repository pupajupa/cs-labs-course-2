using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generic.Math;

namespace _253504_Antikhovitch_Lab1.Interfaces
{
    public interface IMathOperation<T>
    {
        T Add(T x, T y);
        T Subtract(T x, T y);
        T Multiply(T x, T y);
        T Divide(T x, T y);
    }
}
