using System;

namespace Lecture_3
{
    class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine(args.Length);
            //Console.WriteLine(args[0]);
            //Console.WriteLine(args[1]);


            /*....................Object Datatype .........................*/
            //It can store any type of data
            object num = 25;
            Console.WriteLine(num);

            //Disadvantage of Object

            object st1 = "Hello Saad";
            //Console.WriteLine(name.Lenght); (error- because it cannot find method length in runtime as it is base data type)
            Console.WriteLine(((string)st1).Length);



            /*....................Dynamic Datatype .........................*/
            dynamic st2 = "Hello World";
            Console.WriteLine(st2.Length);

            //Disadvantage
            //Console.WriteLine(st2.ABC); // no error at compiler time , but at runtime error


            /*....................Var Datatype .........................*/
            var st3 = "This is something"; //value is given at compile time
            Console.WriteLine(st3.Length); //no error
            //Console.WriteLine(st3.Abc); //have error

            //Disavantage
            //var z= AnyFunction() //error- we dont know the return type at the time of compilation, thats why error

            //      q:     Where to use var?
            //      a:     where datatype is clear by viewing the code





            /*...............use of underscore..................*/

            int population = 66_000_000; //66 Million, we use "underscore" to increase readability in digits
            double number = 3.4_546;
            Console.WriteLine(population);
            Console.WriteLine(number);


            /*.................How to See Default Value .................*/
            Console.WriteLine(default(int));
            Console.WriteLine(default(bool));
            Console.WriteLine(default(string));
            Console.WriteLine(default(decimal));
            Console.WriteLine(default(float));
            Console.WriteLine(default(double));




            /*.................Arrays..................*/
            string[] st4;
            st4 = new string[4];

            st4[0] = "Hello";
            st4[1] = "World!";
            st4[2] = "Lets";
            st4[3] = "Code";

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(st4[i]);
            }

            /*....................How to Take input from user..........................*/
            //int age = Console.ReadLine(); //error because ReadLine return in string

            string st5 = Console.ReadLine();
            Console.WriteLine(st5);




            /*...........interpolated Strings...........*/
            string fruit = "Apple";
            int rupee = 12;
            Console.WriteLine($"{fruit} costs {rupee:C}");


            Console.WriteLine(
                format: "{0} costs {1:C} ",
                arg0: fruit,
                arg1: rupee
                );


            string formattedString = string.Format(
                format: "{0} costs {1:C} ",
                arg0: fruit,
                arg1: rupee
                );

            Console.WriteLine(formattedString);


            /*.....................ReadKey.....................*/
            //If you want to see which key has been pressed by user

            Console.WriteLine("Press any key Combination: ");
            ConsoleKeyInfo key = Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine(
                format: "key: {0}, Char: {1}, Modifier: {2}",
                arg0: key.Key,
                arg1: key.KeyChar,
                arg2: key.Modifiers
                );




            //formatting output using positional arguments
            string applesText = "Apples";
            int applesCount = 1234;
            string bananasText = "Bananas";
            int bananasCount = 56789;

            Console.WriteLine(
            format: "{0,-9} {1,6:N0}",
            arg0: "Name",
            arg1: "Count");

            Console.WriteLine(
                format: "{0,-9} {1,6:N0}",
                arg0: applesText,
                arg1: applesCount);

            Console.WriteLine(
            format: "{0,-9} {1,6:N0}",
            arg0: bananasText,
            arg1: bananasCount);




            /*.......................Operators in C#............................*/
            //unary operators
            int a = 5;
            int b = a--; //postfix operator

            Console.WriteLine($"a is {a} and b is {b}");

            int c = 5;
            int d = --c; //prefix operator

            Console.WriteLine($"c is {c} and d is {d}");

            Console.WriteLine(sizeof(int));
            Console.WriteLine(typeof(int));











        }
    }
}
