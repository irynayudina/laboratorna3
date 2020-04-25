using System;

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
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Notes note = new Notes();
            Console.WriteLine(note);
            Person p1 = new Person();
            Person p2 = p1;
            Person p3 = new Person();
            Console.WriteLine(p2.Equals(p1));
            Console.WriteLine(p3.Equals(p1));
            p1.Name = "Same Page";
            Console.WriteLine(p2);
            p2.Name = "Another Page";
            Console.WriteLine(p1);
            GraduateStudet graduate = new GraduateStudet();
            Console.WriteLine(graduate);
        }
    }
}
