using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace POS_DAL
{
    public class BaseDAL
    {
        //Reading , Writing and overwriting on files 

        internal void Save(string text, string filename)
        {
            string filePath = Path.Combine(Environment.CurrentDirectory, filename);
            StreamWriter sw = new StreamWriter(filePath, append: true);
            sw.WriteLine(text);
            sw.Close();
            Console.WriteLine("\nItem Information successfully saved!!!");
        }


        internal void Empty(string filename)
        {
            string filePath = Path.Combine(Environment.CurrentDirectory, filename);
            StreamWriter sw = new StreamWriter(filePath, append: false);
            sw.Close();
            Console.WriteLine("\nItem Information successfully saved!!!");

        }

        internal List<string> Read(string filename)
        {
            List<string> list = new List<string>();
            string filepath = Path.Combine(Environment.CurrentDirectory, filename);

            StreamReader sr = new StreamReader(filepath);
            string line = String.Empty;

            while ((line = sr.ReadLine()) != null)
            {
                list.Add(line);
            }
            sr.Close();
            return list;
        }


        internal void overwrite(string text, string filename)
        {
            string filePath = Path.Combine(Environment.CurrentDirectory, filename);
            StreamWriter sw = new StreamWriter(filePath, append: false);
            sw.WriteLine(text);
            sw.Close();
        }
    }
}
