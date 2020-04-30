using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Xml.Schema;

namespace laboratorna3
{
    class GraduateStudet: Person, IDateAndCopy
    {
        private string employeePosition;
      //  private Person dataOfTheSupervisor = new Person("","", new DateTime(200, 01, 01));
        // Предупреждение CS0649  Полю "GraduateStudet.dataOfTheSupervisor" нигде не присваивается значение, 
        //поэтому оно всегда будет иметь значение по умолчанию null
        // private Person dataOfTheSupervisor;
        private string speciality;
        private FormOfStudy form;
        private int learningYear;
        private List<Article> articlesPublished;
        private List<Notes> notesMade;

        //Ошибка CS1929 'List<Article>" не содержит определение для "Concat", и наиболее подходящий перегруженный метод расширения "ParallelEnumerable.Concat<Notes>(ParallelQuery<Notes>, IEnumerable<Notes>)" требует наличия получателя типа "ParallelQuery<Notes>". laboratorna3 D:\source\repos\homeworkCs\2Semester\laboratorna3\GraduateStudet.cs 18 Активные
        //public IEnumerable<object> union(){ return articlesPublished.Union(notesMade);}


        public IEnumerable<object> UnionOfArticlesAndNotes()
        {
            for (int i = 0; i < articlesPublished.Count + notesMade.Count; i++)
            {
                if (i < articlesPublished.Count)
                {
                    yield return articlesPublished[i];
                }
                yield return notesMade[i];
            }
        }
        public IEnumerable<object> RecentArticles(int n)
        {
            
            for ( int i = 0; i< ArticlesPublished.Count; i++)
            {
                //if (ArticlesPublished[i].Date.Year > (ArticlesPublished[i].Date.Year - n ))
                //{
                //    yield return articlesPublished[i];
                //} если статья написана за последние н лет от сегодняшней даты включительно:
                if ( (ArticlesPublished[i].Date).Subtract(new DateTime((DateTime.Today.Year - n), (DateTime.Today).Month, (DateTime.Today).Day)).Days >= 0)
                {
                    yield return articlesPublished[i];
                }
            }
        }

        public string EmployeePosition { 
            get { return employeePosition; }
            set { employeePosition = value; }
        }
        public Person PersonProprety
        {
            get { return new Person(this.Name, this.LastName, this.Date) ; }
            set { this.Name = value.Name;// System.NullReferenceException: "Oject reference not set to an instance of an object" data of the supervisor was null
                  this.LastName = value.LastName;
                  this.Date = value.Date;
            }
        }
        
          public Person Supervisor
        {  get;  set;
        }

        public string Speciality
        {
            get { return speciality; }
            set { speciality = value; }
        }
        public FormOfStudy Form
        {
            get { return form; }
            set { form = value; }
        }
        public int LearningYear
        {
            get { return learningYear; }
            set {
                try
                {
                    if (value < 0 || value > 4)
                    {
                        throw new ArgumentException("Learning year cannot be greater  than 4 or less than 0");

                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                learningYear = value; }
        }
        public List<Article> ArticlesPublished
        {
            get 
            {
                
                return articlesPublished; 
            }
            set { articlesPublished = value; }
        }
        public List<Notes> NotesMade
        {
            get { return notesMade; }
            set { notesMade = value; }
        }
        public void AddArticles(params Article[] p)
        {
            
            for (int i = ArticlesPublished.Count; i < p.Length; i++)
            {
                ArticlesPublished.Add(p[i]);
            }
        }
        public void AddNotes(params Notes[] p)
        {
            for (int i = NotesMade.Count; i < p.Length; i++)
            {
                NotesMade.Add(p[i]);
            }
        }
        public Article LastArticle
        {
            get
            {
                if(ArticlesPublished.Count == 0)
                {
                    return null;
                }

                Article[] art = ArticlesPublished.OrderBy(a => a.Date).ToArray();
                return art[ArticlesPublished.Count - 1];
            }
        }
        public GraduateStudet()
        {
            EmployeePosition = "Default employee position";
            Supervisor = new Person();
            Speciality = "Default speciality";
            Form = 0;
            LearningYear = 4;
            ArticlesPublished = new List<Article>();
            NotesMade = new List<Notes>();
        }
        public GraduateStudet(string employeePosition, Person supervisor, string speciality, FormOfStudy form, int learningYear) 
            : base(supervisor.Name, supervisor.LastName, supervisor.Date)//List<Article> articlesPublished, List<Notes> notesMade
        {
            EmployeePosition = employeePosition;
            Supervisor = supervisor;
            Speciality = speciality;
            Form = form;
            LearningYear = learningYear;
            ArticlesPublished = new List<Article>();
            NotesMade = new List<Notes>();
            //ArticlesPublished = articlesPublished;
            //NotesMade = notesMade;
        }
        
        public override string ToString()
        {
            string allInfo = ($"\n  Data of the graduate student:\n Name: {Name}\n Last Name: {LastName}\n" +
                       $" Date of birthday: {Date}\n Employee position {EmployeePosition}\n Data of the supervisor: {Supervisor}" +
                       $"Form of study {Form}\n learning year {LearningYear}\n List of Articles:\n");
            foreach (Article a in ArticlesPublished)
            {
                allInfo += a.ToString();
            }
            allInfo += $"\n List of notes:\n";
            foreach (Notes n in NotesMade)
            {
                allInfo += n.ToString();
            }
            return allInfo;
        }
        public override string ToShortString()
        {
            return $"\n Name: {Name}\n Last Name: {LastName}\n" +
                       $" Date of birthday: {Date}\n Employee position {EmployeePosition}\n Data of the supervisor: {Supervisor}\n" +
                       $"Form of study {Form}\n learning year {LearningYear}\n Number of Articles: {ArticlesPublished.Count}\n Number of notes: {NotesMade.Count}";
        }
        public override object DeepCopy()
        {
            GraduateStudet g = (GraduateStudet)this.MemberwiseClone();
            g.Name = new string(Name); //String.Copy(Name); is obsolete
            g.LastName = new string(LastName); //String.Copy(LastName);
            //g.Date = //new DateTime(Date.Year, Date.Month, Date.Day);//struct value type unnecessary new
            g.EmployeePosition = new string(EmployeePosition); //String.Copy(EmployeePosition);// new + assign values
            g.Supervisor = (Person)this.DeepCopy();
            g.Speciality = new string(Speciality); //String.Copy(Speciality);
            g.ArticlesPublished = new List<Article>();
            for (int i = 0; i < ArticlesPublished.Count; i++)
            {
                g.ArticlesPublished.Add((Article)this.ArticlesPublished[i].DeepCopy()) ;
            }
            g.NotesMade = new List<Notes>();
            foreach (Notes n in this.NotesMade)
            {
                g.NotesMade.Add((Notes)n.DeepCopy());
            }
            return g;
        }
        
    }
}
