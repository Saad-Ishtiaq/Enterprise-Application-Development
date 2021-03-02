using System;

namespace Lecture_3__continue_
{
    class IterationStatements
    {
        static void Main(string[] args)
        {

            Console.WriteLine("__________While Loop___________");

            int a = 1;
            while (a <= 5)
            {
                Console.WriteLine($"{a}");
                a++;
            }


            Console.WriteLine("__________do while Loop___________");
            //it comes in the loop first then chech the condition
            string password = "";
            do
            {
                Console.Write("Enter your password: ");
                password = Console.ReadLine();
            }
            while (password != "123");
            Console.WriteLine("Correct!");


            Console.WriteLine("__________for Loop___________");
            for (int i = 6; i < 11; i++)
            {
                Console.WriteLine($"{i}");
            }



            Console.WriteLine("__________foreach Loop___________");

            string[] names = { "Saad", "Usama", "Ali", "Umer" };
            foreach (string name in names)
            {
                Console.WriteLine($"name: {name}   ,   Characters: {name.Length}");
            }


        }
    }

}