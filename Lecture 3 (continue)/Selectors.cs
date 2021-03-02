using System;

namespace Lecture_3__continue_
{
    class Selectors
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine(" No command line argument");
            }
            else if (args.Length == 1)
            {
                Console.WriteLine(" One command line argument");
            }
            //else
            //{
            //    Console.WriteLine(" More than one command line argument");
            //}
        }
    }
}

