using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace POS_BASE_DAL
{
    public class BaseDAL
    {

        public void Save(string text,string filename)
        {
            string filePath = Path.Combine(Environment.CurrentDirectory, filename);
            StreamWriter sw = new StreamWriter(filePath, append: true);
            sw.WriteLine(text);
            sw.Close();
        }

    }
}
