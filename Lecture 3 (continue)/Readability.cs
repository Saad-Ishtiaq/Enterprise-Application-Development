using System;



namespace Lecture_3__continue_
{
    class Readability
    {
        static void Main(string[] args)
        {
            //Efficient way of checking type and type casting in your if statements

            Console.WriteLine("__________Simple _______________");

            object o = "saad";

            if (o.GetType() == typeof(int))
            {
                int k = (int)o;
                Console.WriteLine($"int {k}");
            }
            else if (o.GetType() == typeof(float))
            {
                float f = (float)o;
                Console.WriteLine($"float {f}");
            }
            else if (o.GetType() == typeof(string))
            {
                string str = (string)o;
                Console.WriteLine($"string {str}");
            }



            Console.WriteLine("__________Using is _______________");

            /*.......Now we will increase its readability........*/
            if (o is int)
            {
                int k = (int)o;
                Console.WriteLine($"int {k}");


            }

            if (o is double)
            {
                double d = (double)o;
                Console.WriteLine($"double {d}");

            }
            if (o is string)
            {
                string str = (string)o;
                Console.WriteLine($"string {str}");

            }

            //Now we are typecasting in same if condition
            Console.WriteLine("__________Using is and type casting _______________");
            if (o is int x)
            {
                Console.WriteLine($"int {x}");
            }
            if (o is double y)
            {
                Console.WriteLine($"double {y}");
            }
            if (o is string z)
            {
                Console.WriteLine($"string {z}");
            }


        }
    }
}