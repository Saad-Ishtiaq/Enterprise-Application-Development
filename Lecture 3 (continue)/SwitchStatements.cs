using System;

namespace Lecture_3__continue_
{

    class SwitchStatements
    {
        static void Main(string[] args)
        {




            Console.WriteLine("____________Literal Matching___________");
            //Generate a random variable
            int number = (new Random()).Next(1, 5);

            Console.WriteLine($"Random number: {number}");

            switch (number)
            {
                case 1:
                    Console.WriteLine("One");
                    break;

                case 2:
                    Console.WriteLine("Two ");
                    goto case 1;

                case 3:
                    break;

                default:
                    Console.WriteLine("Either 4 or 5");
                    break;

            }


            Console.WriteLine("____________Pattern Matching___________");
            object[] myObjects = { 2, "Saad", 5.6 };




            foreach (object x in myObjects)
            {

                switch (x)
                {
                    case 2:
                        Console.WriteLine($"int {x}");
                        break;
                    case "Saad":
                        Console.WriteLine($"String {x}");
                        break;

                    case 5.6:
                        Console.WriteLine($"Double {x}");
                        break;

                }

            }




            //The case values no longer need to be literal values. They can be pattern
            foreach (var y in myObjects)
            {

                switch (y)
                {
                    case int u:
                        Console.WriteLine($"it is an integer {u}");
                        break;
                    case string s:
                        Console.WriteLine($"it is a string {s}");
                        break;
                    //case double d:
                    case double d when d == 2.36:
                        Console.WriteLine($"it is a double {d}");
                        break;
                    case bool b:
                        Console.WriteLine($"it is a boolean {b}");
                        break;
                    case null:
                        Console.WriteLine($"it is a null value");
                        break;
                    default:
                        Console.WriteLine("in default");
                        break;
                }
            }
        }
    }
}