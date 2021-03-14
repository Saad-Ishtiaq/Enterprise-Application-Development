using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using static System.Console;

namespace Lecture_6
{
    internal class DirectoryManager
    {
        static internal void WorkingWithDirectories()
        {
            var newFolder = Path.Combine(Directory.GetCurrentDirectory(), "MyNewFolder");
            WriteLine(Directory.GetCurrentDirectory());
            //Tells does directory exists?
            WriteLine(Directory.Exists(newFolder));
            //Create new Directory at respective path and name
            Directory.CreateDirectory(newFolder);
            WriteLine(Directory.Exists(newFolder));
            //Delete Directory from repsoective path of given name
            Directory.Delete(newFolder, recursive: true);
            WriteLine(Directory.Exists(newFolder));
        }
    }
}
