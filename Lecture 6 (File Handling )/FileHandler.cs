using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lecture_6__File_Handling__
{
    internal class FileHandler
    {
        internal static void WritetoFile()
        {
            FileStream fout = null;
            try
            {
                fout = new FileStream("test.txt", FileMode.Create, FileAccess.Write);

                for (char c = 'A'; c <= 'Z'; c++)
                {
                    fout.WriteByte((byte)c);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                fout.Close();
            }
        }

        internal static void ReadFromFile()
        {
            FileStream fin = null;
            try
            {
                fin = new FileStream("test.txt", FileMode.Open, FileAccess.Read);
                int i = fin.ReadByte();

                Console.WriteLine(i);
                Console.WriteLine((char)i);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                fin.Close();
            }
        }

        internal static void WriteFileusingStreamWriter()
        {
            FileStream fout = null;
            try
            {
                fout = new FileStream("myFile.txt", FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fout);
                string str = "This is some data which I need to store on file";
                sw.Write(str);
                sw.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.GetType());
                Console.WriteLine(ex.Message);
            }
            finally { 
                fout.Close();
            }
        }

        internal static void ReadFileusingStreamReader()
        {
            FileStream fout = null;
            try { 
                fout = new FileStream("myFile.txt", FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fout);
                string line = String.Empty;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
                sr.Close();

                //ReadToEnd can also be used to read all at single time

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                fout.Close();
            }
        }
    }
}
