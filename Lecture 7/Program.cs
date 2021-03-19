using System;

using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;


namespace Lecture_7
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            FileManager.ManageFile();


            Person p = new Person
            {
                Name = "Saad",
                Age = 20,
                Address = new Address
                {
                    City = "Lahore",
                    Country = "Pakistan",
                    Zip = 45632
                }
            };

            string jsonOutput = JsonSerializer.Serialize(p);
            Console.WriteLine(jsonOutput);

            File.WriteAllText("myFile.txt", jsonOutput);

            string jsonString = File.ReadAllText("myfile.txt");
            Person p2 = JsonSerializer.Deserialize<Person>(jsonString);
            Console.WriteLine(p2.Age+ p2.Name+ p2.Address.City);


        }
    }
}
