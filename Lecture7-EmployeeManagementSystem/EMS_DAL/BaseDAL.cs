using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EMS_DAL
{
    public class BaseDAL
    {
        internal void Save(string text, string filename)
        {
            string filePath = Path.Combine(Environment.CurrentDirectory, filename);
            StreamWriter sw = new StreamWriter(filePath, append: true);
            sw.WriteLine(text);
            sw.Close();
        }

        internal List<string> Read(string filename )
        {
            List<string> list = new List<string>();
            string filepath = Path.Combine(Environment.CurrentDirectory, filename);

            StreamReader sr = new StreamReader(filepath);
            string line = String.Empty;

            while((line=sr.ReadLine())!=null)
            {
                list.Add(line);
            }
            return list;
        }
    }
}
