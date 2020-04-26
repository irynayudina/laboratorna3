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
            Article[] a = new Article[60];
            int y = DateTime.Today.Year - graduate.LearningYear + 1;
            for (int i = 0; i< a.Length; i++)
            {
                a[i] = new Article($"article{i+1}", $"place{i+1}", new DateTime((DateTime.Today.Year - graduate.LearningYear + 1), 1, 1).AddDays(4*i));
                //DateTime.Today.AddDays(4 * i)
            }
            graduate.AddArticles(a);
            Console.WriteLine(graduate);
        }
    }
}
