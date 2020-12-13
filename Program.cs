using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace laboratorna3
{
    public enum FormOfStudy
    {
        FullTime,
        PartTime,
        Distance
    }
    class Program
    {
        static void Main()//string[] args
        {
            Article a1 = new Article();
            a1.Name = "firstArticle";
            Article a2 = new Article();
            a2.Name = "secondArticle";
            GraduateStudet g = new GraduateStudet();
            g.AddArticles(a1, a2);
            GraduateStudet gCopy = new GraduateStudet();
            gCopy = g.DeepCopySerialize();
            Console.WriteLine($"*****************INITIAL**************************\n{g.ToString()}\n\n\n\n**************************COPY******************************\n{gCopy.ToString()}\n\n\n\n");



            Console.WriteLine("Enter the name of a file");
            string filenameinp = Console.ReadLine();
            if (String.IsNullOrEmpty(filenameinp))
            {
                filenameinp = "defaultInput.dat";
                Console.WriteLine("you have entered invalid filename. It was replaced with defaultInput.dat");

            }
            string path = System.IO.Directory.GetCurrentDirectory();
            Console.WriteLine(path);
            string filename = path + "\\" + filenameinp;
            Console.WriteLine(filename);
            if (File.Exists(filename))
            {
                g.Load(filename);
            }
            else
            {
                Console.WriteLine("File does not exist! Creating it now");
                
                var MYfile = File.Create(filename);
                MYfile.Close();
            //    using (Stream fі = new FileStream(filename,

            //FileMode.Create, FileAccess.Write,

            //FileShare.None)) { }
                    //File.Create(filename);
            }



            Console.WriteLine(g.ToString());



            g.AddFromConsole();
            g.Save(filename);
            Console.WriteLine(g.ToString());




            GraduateStudet.Load(filename, ref g);
            g.AddFromConsole();
            GraduateStudet.Save(filename, g);




            Console.WriteLine(g.ToString());


            //if(f)
        }
    }
}
