using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_7
{
    internal class Person
    {
        public string Name { get; set;}
        public int Age { get; set; }
        public Address Address { get; set; }
    }

    internal class Address
    {
        public string City { get; set; }
        public string Country { get; set; }
        public int Zip { get; set; }

    }
}
