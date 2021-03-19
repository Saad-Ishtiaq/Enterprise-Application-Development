using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using static System.Console;


namespace Lecture_7
{
    class FileManager
    {
        internal static void ManageFile()
        {
            string textFile = Path.Combine(
                Environment.CurrentDirectory,"streams.txt"
                );

            WriteLine(File.Exists(textFile));
            StreamWriter sw = File.CreateText(textFile);
            sw.WriteLine("This line is added by String Writer.");
            WriteLine(File.Exists(textFile));
            sw.Close();

            //Getting Info about file's Folder etc (Path)
            WriteLine($"Folder Name: {Path.GetDirectoryName(textFile)}");
            WriteLine($"File Name: {Path.GetFileName(textFile)}");
            WriteLine($"File Name Without Extension: {Path.GetFileNameWithoutExtension(textFile)}");
            WriteLine($"File Extension: {Path.GetExtension(textFile)}");
            WriteLine($"File Full Path: {Path.GetFullPath(textFile)}");


            //Getting File's info Itself. (FileInfo)
            var info =new FileInfo(textFile);
            WriteLine($"File Full Name: {info.FullName}");
            WriteLine($"File Length: {info.Length}");
            WriteLine($"File Name: {info.Name}");
            WriteLine($"File Last Access Time: {info.LastAccessTime}");
            WriteLine($"File Last Access Time UTC: {info.LastAccessTimeUtc}");
            WriteLine($"is ReadOnly: {info.IsReadOnly}");



            //Copy File , Delete File , ReadFile( 1-stream reader  2- File)

            string backupFile = Path.Combine(Environment.CurrentDirectory, "backup.bak");
            File.Copy(sourceFileName: textFile, destFileName: backupFile, overwrite:true);

            ReadLine();
            File.Delete(textFile);


            StreamReader sr = File.OpenText(backupFile);
            WriteLine(sr.ReadToEnd());
            sr.Close();

            //To Write
            string append = "This is appended Line";
            File.AppendAllText(backupFile, append);
            
            //To Read
            WriteLine(File.ReadAllText(backupFile));



        }

    }
}
