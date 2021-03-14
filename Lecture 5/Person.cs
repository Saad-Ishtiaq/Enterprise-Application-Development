using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_5
{

    //-----------------Lecture Part-1-----------------

    /*class TextAndNumber {
        public string Text;
        public int Number;
    }*/

    class Person
    {
        public string Name;
        public int Age;
        public string Country;

        public void PrintPersonDetails()
        {
            Console.WriteLine($"Person Name is : {this.Name}" +
                $"  and age is {this.Age}    ");
        }

        public string GetPersonName()
        {
            return $"My Name is {this.Name}";
        }

        public (string MyName, int MyAge, string MyCountry) GetPersonDetails()
        {
            return (this.Name, this.Age, this.Country);
        }


        /* public TextAndNumber GetPersonNameAndAge() {
             return new TextAndNumber { Text = this.Name, Number = this.Age };
         }*/



    }
    //-----------------Lecture Part-2-----------------
    class Person2
    {
        public string Name;
        public int Age;
        public string Country;

        public void SayHello()
        {
            Console.WriteLine($"My name is {this.Name}");
        }

        public void SayHello(string inputName)
        {
            Console.WriteLine($"My name is {this.Name} and input name is {inputName}");
        }

        public void SayHello(string inputName, int myValue)
        {
            Console.WriteLine($"My name is {this.Name} and input name is {inputName}");
        }

        public void MyMethod(string name = "Saad", int someValue = 5, double someOtherValue = 2.5)
        {
            Console.WriteLine($"name is {name} and int value is {someValue} " +
                $" and double is {someOtherValue}");
        }

        public int TotalMarks(params int[] data)
        {
            int result = 0;
            
            foreach (int value in data)
            {
                result = result + value;
            }

            return result;
        }

        public void PassingParamters(int x, ref int y, out int z)
        {
            z = 99;
            x++;
            y++;
            z++;

        }
    }
}
