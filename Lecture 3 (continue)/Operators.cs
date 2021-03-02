using System;

namespace Lecture_3__continue_
{
    class Operators
    {
        static void Main(string[] args)
        {
            //Operators

            Console.WriteLine("_____________Unary Operators____________");
            //Those which works on one variable are caller unary Operators 

            //Post Fix
            int a = 5;
            int b = a++;
            Console.WriteLine($"a = {a}  b={b}");

            //Pre Fix
            int c = 5;
            int d = ++c;
            Console.WriteLine($"a = {c}  b={d}");




            Console.WriteLine("_____________Binary Operators____________");
            //Those which works on two or more variable are caller Binary Operators 
            int e = 6;
            int f = 4;

            Console.WriteLine($" e + f = {e + f} ");
            Console.WriteLine($" e - f = {e - f} ");
            Console.WriteLine($" e * f = {e * f} ");
            Console.WriteLine($" e / f = {e / f} ");
            Console.WriteLine($" e % f = {e % f} ");



            Console.WriteLine("_____________Assignment Operators____________");
            //Those which are used to assign values are called assignment operators
            int g = 3;
            g += 3; // equivalent to g = g + 3
            Console.WriteLine($"value of g = {g}");
            g -= 3; // equivalent to g = g - 3
            Console.WriteLine($"value of g = {g}");
            g *= 3; // equivalent to g = g * 3
            Console.WriteLine($"value of g = {g}");
            g /= 3; // equivalent to g = g / 3
            Console.WriteLine($"value of g = {g}");


            Console.WriteLine("_____________Logical Operators____________");
            //these operators operate on boolean values so either return true or false.

            bool x = true;
            bool y = false;

            //AND : Both operators should be true
            Console.WriteLine("----------AND-----------");
            Console.WriteLine(x & x);
            Console.WriteLine(x & y);
            Console.WriteLine(y & x);
            Console.WriteLine(y & y);
            //OR  : Atleast One should be true
            Console.WriteLine("----------OR-----------");
            Console.WriteLine(x | x);
            Console.WriteLine(x | y);
            Console.WriteLine(y | x);
            Console.WriteLine(y | y);
            //XOR : Either can be true but not the both
            Console.WriteLine("----------XOR-----------");
            Console.WriteLine(x ^ x);
            Console.WriteLine(x ^ y);
            Console.WriteLine(y ^ x);
            Console.WriteLine(y ^ y);
            //NOT : inverts the value of operator
            Console.WriteLine("----------NOT-----------");
            Console.WriteLine(!x);
            Console.WriteLine(!y);

        }
    }
}
