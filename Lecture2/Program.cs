using System;

namespace Lecture2
{
    class Program
    {
        static void Main(string[] args)
        {
            String myFirstVariable = "Hello World!";
            Console.WriteLine( myFirstVariable );


            char character = 'A';
            int number = 7;
            uint positiveNumber = 23;
            float f = 2.0F;
            double d = 3.5;
            decimal x = 3.45M;


            Console.WriteLine("int uses " + sizeof(int) + " bytes");
            Console.WriteLine("uint uses " + sizeof(uint) + " bytes");

            Console.WriteLine($"int minimum value : {int.MinValue} ");
            Console.WriteLine($"int maximum value : {int.MaxValue} ");


            Console.WriteLine($"uint minimum value : {uint.MinValue} ");
            Console.WriteLine($"uint maximum value : {uint.MaxValue} ");



            Console.WriteLine("float uses " + sizeof(float) + " bytes");
            Console.WriteLine("double uses " + sizeof(double) + " bytes");
            Console.WriteLine("decimal uses " + sizeof(decimal) + " bytes");


            Console.WriteLine($"float minimum value : {float.MinValue} ");
            Console.WriteLine($"float maximum value : {float.MaxValue} ");

            Console.WriteLine($"double minimum value : {double.MinValue} ");
            Console.WriteLine($"double maximum value : {double.MaxValue} ");

            Console.WriteLine($"decimal minimum value : {decimal.MinValue} ");
            Console.WriteLine($"decimal maximum value : {decimal.MaxValue} ");






            Console.WriteLine("Using doubles:");
            double a = 0.1;
            double b = 0.2;
            if (a + b == 0.3)
            {
                Console.WriteLine($"{a} + {b} equals 0.3");
            }
            else
            {
                Console.WriteLine($"{a} + {b} does NOT equal 0.3");
            }
            /*-----------------------------------------------*/


            Console.WriteLine("Using decimals:");
            decimal z = 0.1M; // M suffix means a decimal literal value
            decimal y = 0.2M;
            if (z + y == 0.3M)
            {
                Console.WriteLine($"{z} + {y} equals 0.3");
            }
            else
            {
                Console.WriteLine($"{z} + {y} does NOT equal 0.3" );
            }


            /*-----------------------------------------------*/


            bool happy = true;
            bool sad = false;


            double? num = null;

            Console.WriteLine(num);
            Console.WriteLine(num.GetValueOrDefault());





            num = 7;
            
            Console.WriteLine(num);
            Console.WriteLine(num.GetValueOrDefault());



        }
    }
}
