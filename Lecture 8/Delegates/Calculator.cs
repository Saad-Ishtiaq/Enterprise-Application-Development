using System;
using System.Collections.Generic;
using System.Text;

/*----------------------------Lecture 19--------------------------------------*/

namespace Delegates
{
    internal class Calculator
    {
        static internal int Add(int a, int b)
        {
            int result = a + b;
            Console.WriteLine($"Add Method result:{result}");
            return result;
        }
        static internal int Subtract(int a, int b)
        {
            int result = a - b;
            Console.WriteLine($"Subtract Method result: {result}");
            return result;
        }
        static internal int Multiply(int a, int b)
        {
            int result = a * b;
            Console.WriteLine($"Multiply Method result: {result}");
            return result;

        }
    }
}
