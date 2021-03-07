using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_9
{
    public class Person : System.Object
    {
        public string Name;
        public int Age;
        public static string Country = "Pakistan";
        public const string HomePlanet = "Earth";
        public readonly string HomePlanet2;

        public Person()
        {
            Name = default;
            Age = default;
            HomePlanet2 = "Moon";
        }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
            HomePlanet2 = "Moon";

        }
    }
}