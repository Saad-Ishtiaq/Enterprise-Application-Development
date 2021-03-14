using System;

namespace Lecture_5
{
    class Program
    {
        static void Main(string[] args)
        {


            //-----------------Lecture Part-1-----------------

            Person p = new Person { Age = 12, Name = "Ali", Country = "Pakistan" };
            //p.PrintPersonDetails();
            //Console.WriteLine(p.GetPersonName());
            //Console.WriteLine("name is "+ p.GetPersonNameAndAge().Text + "and age is "+
            //                  p.GetPersonNameAndAge().Number  );
            (string name, int age, string country) = p.GetPersonDetails();
            Console.WriteLine(name);
            Console.WriteLine(age);
            Console.WriteLine(country);

            //------------------Lecture Part-2------------------------

            Person2 p2 = new Person2 { Name = "Ali", Age = 12, Country = "Pakistan" };
            //p2.SayHello("shuja", 12);
            //p2.MyMethod("ali",123,85.69);
            //Console.WriteLine(p2.TotalMarks(1));
            //Console.WriteLine(p2.TotalMarks(1,2,3));
            //Console.WriteLine(p2.TotalMarks(1,2,3,4,5));
            //p2.TotalMarks(1,2,3,4,5,67,8,9);
            //p2.TotalMarks(1, 2, 3, 4, 5, 67, 8, 9,23);
            int a = 10;
            int b = 20;

            Console.WriteLine($"before passing a ={a}, b = {b}");
            p2.PassingParamters(a, ref b, out int c);
            Console.WriteLine($"after passing a ={a}, b = {b} and c={c}");


            //------------------Lecture Part-3------------------------

            
            Person3 p3 = new Person3();
            p3.Name = "Saad";
            p3.Age = 12;
            p3.Country = "Pakistan";
            Console.WriteLine(p3.Name +" age is " + p3.Age + " country is " + p3.Country + " Name "+ p3.MyName);

            p3[0] = "ali";
            Console.WriteLine(p3[0]);



            //------------------Lecture Part-4------------------------

            Box Box1 = new Box();   // Declare Box1 of type Box
            Box Box2 = new Box();   // Declare Box2 of type Box
            Box Box3;   // Declare Box3 of type Box


            // box 1 specification
            Box1.Length = 6.0;
            Box1.Width = 7.0;
            Box1.Height = 5.0;

            // box 2 specification
            Box2.Length = 12.0;
            Box2.Width = 13.0;
            Box2.Height = 10.0;




            // Add two object as follows:

            Box3 = Box1 + Box2;

            Box1.PrintBoxDetails();
            Box2.PrintBoxDetails();
            Box3.PrintBoxDetails();









            if (Box1 != Box2)
            { Console.WriteLine("Box1 is not equal to Box2"); }



            if (Box1 == Box2)
            { Console.WriteLine("Box1 is equal to Box2"); }
            else
            { Console.WriteLine("Box1 is not equal to Box2"); }
            //*/








            Person4 p4 = new Person4{ Name = "Ali", Age = 2 };
            Console.WriteLine(p4.ToString());
            Person4.Display("Saad");


        }
    }
}
