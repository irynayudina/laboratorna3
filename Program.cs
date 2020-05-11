using System;
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
            Person person1 = new Person();
            Person person2 = new Person();
            Console.WriteLine("Person2 and Person1 are the same instance: " + ReferenceEquals(person2, person1));
            Console.WriteLine("Person2 equals Person1: " + person2.Equals(person1));
            Console.WriteLine($"Person1 hash code: {person1.GetHashCode()}");
            Console.WriteLine($"Person2 hash code: {person2.GetHashCode()}");
            GraduateStudet graduate = new GraduateStudet();
            Random rand = new Random();
            Article[] a = new Article[3];            
            for (int i = 0; i< a.Length; i++)
            {
                int y = rand.Next((DateTime.Today.Year - graduate.LearningYear + 1), DateTime.Today.Year);
                int m = rand.Next(1, 12);
                int d = rand.Next(1, 28);
                a[i] = new Article($"article{i + 1}", $"place{i + 1}", new DateTime(y, m, d));
            }
            graduate.AddArticles(a);
            Notes[] n = new Notes[3];
            for (int i = 0; i < n.Length; i++)
            {
                int y = rand.Next((DateTime.Today.Year - graduate.LearningYear + 1), DateTime.Today.Year);
                int m = rand.Next(1, 12);
                int d = rand.Next(1, 28);
                n[i] = new Notes($"note{i + 1}", $"conference{i + 1}", new DateTime(y, m, d));
            }
            graduate.AddNotes(n);
            Console.WriteLine("\n\n\n\n\n\n Original graduate student: \n\n\n\n\n\n");
            Console.WriteLine(graduate);
            Console.WriteLine("\n\n\n\n\n\n The value of 'Person' property of the original graduate student: \n\n\n\n\n\n");
            Console.WriteLine(graduate.PersonProperty);
            GraduateStudet graduate1 = (GraduateStudet)graduate.DeepCopy();
            graduate.PersonProperty = new Person("Lidia", graduate.LastName, graduate.Date);
            graduate.ArticlesPublished[0].Name = "**********************Name of this article has been changed******************";
            Console.WriteLine("\n\n\n\n\n\n Deep copy of the graduate student: \n\n\n\n\n\n");
            Console.WriteLine(graduate1);
            Console.WriteLine("\n\n\n\n\n\n Original graduate student: \n\n\n\n\n\n");
            Console.WriteLine(graduate);
            Console.WriteLine("\n\n\n\n\n\n Attempt to assign incorrect value to learning year \n");
            try
            {
                graduate.LearningYear = 5;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            

            Console.WriteLine("\n\n\n\n\n\n Union of articles: \n\n\n\n\n\n");
            foreach (var v in graduate.UnionOfArticlesAndNotes())
            {
                Console.WriteLine(v);
            }
            Console.WriteLine("\n\n\n\n\n\n Recent articles: \n\n\n\n\n\n");
            foreach (Article artic in graduate.RecentArticles(2))
            {
                Console.WriteLine(artic);
            }
        }
    }
}
