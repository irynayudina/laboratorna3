using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;


namespace laboratorna3
{
   [Serializable]
   [DataContract]
    class GraduateStudet: Person, IDateAndCopy
    {
        public GraduateStudet DeepCopySerialize()
        {
            GraduateStudet savedToStream = new GraduateStudet();
            Save("infoForCopy.dat", this);
            Load("infoForCopy.dat", ref savedToStream);
            return savedToStream;
        }
       public bool Save(string fileName)
        {
            // Сохранить граф объектов в файл в двоичном виде.

            BinaryFormatter binFormat = new BinaryFormatter();

            using (Stream fStream = new FileStream(fileName,

            FileMode.OpenOrCreate, FileAccess.Write,

            FileShare.None))

            {
                try
                {
                    binFormat.Serialize(fStream, this);
                }
                catch(SerializationException e)
                {
                    Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                    return false;
                }

            }      
            

            Console.WriteLine("=> Saved graduate student in binary format!");
            return true;
        }
        //private void serialize(List<Article> ARticles, Stream stream)
        //{
        //    foreach (var f in ARticles)
        //    {
        //      //  stream.Write(f);
        //    }
        //}
        public bool Load(string fileName)
        {
            GraduateStudet FromDisk;
            BinaryFormatter binFormat = new BinaryFormatter();

            // Прочитать объект из двоичного файла.

            using (Stream fStream = File.OpenRead(fileName))

            {

                try
                {
                    FromDisk = (GraduateStudet)binFormat.Deserialize(fStream);
                }
                catch (SerializationException e)
                {
                    Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                    return false;
                }
            }


            this.Form = FromDisk.Form;
            this.LearningYear = FromDisk.LearningYear;
            this.PersonProperty = (Person)FromDisk.PersonProperty.DeepCopy();
            this.EmployeePosition = new string(FromDisk.EmployeePosition); //String.Copy(EmployeePosition);
            this.Supervisor = (Person)FromDisk.Supervisor.DeepCopy();
            this.Speciality = new string(FromDisk.Speciality); //String.Copy(Speciality);
            this.ArticlesPublished = FromDisk.ArticlesPublished;
            //    new List<Article>();
            //for (int i = 0; i < FromDisk.ArticlesPublished.Count; i++)
            //{
            //    this.ArticlesPublished.Add((Article)FromDisk.ArticlesPublished[i].DeepCopy());
            //}
            this.NotesMade = new List<Notes>();
            foreach (Notes n in FromDisk.NotesMade)
            {
                this.NotesMade.Add((Notes)n.DeepCopy());
            }
            return true;
        }

        public bool AddFromConsole()
        {
            Console.WriteLine("Enter the Article element of         public List<Article> ArticlesPublished       as a string with deviders\nInput string should contain every element of Article in this order:\n name*place*date     \nWhere date is year/month/day");
            string inputedString = Console.ReadLine();
            if (String.IsNullOrEmpty(inputedString))
            {
                Console.WriteLine("Empty input");
                return false;
            }
            string[] arrayInp = inputedString.Split(new char[] { '*' });
            Article a = new Article();
            if (String.IsNullOrEmpty(arrayInp[0]))
            {
                Console.WriteLine("Empty name");
                return false;
            }
            a.Name = arrayInp[0];
            if (String.IsNullOrEmpty(arrayInp[1]))
            {
                Console.WriteLine("Empty place");
                return false;
            }
            a.Place = arrayInp[1];
            int y, m, d;
            if (String.IsNullOrEmpty(arrayInp[2]))
            {
                Console.WriteLine("Empty date");
                return false;
            }
            string[] arrDate = arrayInp[2].Split(new char[] { '/' });
            if(!Int32.TryParse(arrDate[0], out y))
            {
                return false;
            }
            if (!Int32.TryParse(arrDate[1], out m))
            {
                return false;
            }
            if (!Int32.TryParse(arrDate[2], out d))
            {
                return false;
            }
            a.Date = new DateTime(y, m, d);
            this.ArticlesPublished.Add(a); 
            return true;
        }
       




        public static bool Save(string filename, GraduateStudet objGraph)
        {
            // Сохранить граф объектов в файл в двоичном виде.

            BinaryFormatter binFormat = new BinaryFormatter();

            using (Stream fStream = new FileStream(filename,

            FileMode.Create, FileAccess.Write,

            FileShare.None))

            {
                try
                {
                    binFormat.Serialize(fStream, objGraph);
                }
                catch (SerializationException e)
                {
                    Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                    return false;
                   // throw;
                }
                return true;
            }
        }




        public static bool Load(string fileName, ref GraduateStudet FromDisk)

        {
            GraduateStudet buff = (GraduateStudet)FromDisk.DeepCopy();

            BinaryFormatter binFormat = new BinaryFormatter();

            // Прочитать объект из двоичного файла.

            using (Stream fStream = File.OpenRead(fileName))

            {
                try
                {
                    FromDisk = (GraduateStudet)binFormat.Deserialize(fStream);
                }
                catch (SerializationException e)
                {
                    Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                    FromDisk = buff;
                    return false;
                }
            }

            return true;
        }








        private string employeePosition;
        private string speciality;
        private FormOfStudy form;
        private int learningYear;
        private List<Article> articlesPublished;
        private List<Notes> notesMade;
        public Person Supervisor { get; set; }
        public Person PersonProperty
        {
            get { return new Person(this.Name, this.LastName, this.Date); }
            set
            {
                this.Name = value.Name;// System.NullReferenceException: "Oject reference not set to an instance of an object" data of the supervisor was null
                this.LastName = value.LastName;
                this.Date = value.Date;
            }
        }
        //Could be automatic properties<!-----
        public string EmployeePosition { 
            get { return employeePosition; }
            set { employeePosition = value; }
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
        public List<Article> ArticlesPublished
        {
            get { return articlesPublished; }
            set { articlesPublished = value; }
        }
        public List<Notes> NotesMade
        {
            get { return notesMade; }
            set { notesMade = value; }
        }
        // ------------->
        public int LearningYear
        {
            get { return learningYear; }
            set
            {

                if (value < 0 || value > 4)
                {
                    throw new ArgumentException("Learning year cannot be greater  than 4 or less than 0");

                }

                else { learningYear = value; }
            }
        }
        public IEnumerable UnionOfArticlesAndNotes()
        {
            
            for (int i = 0; i < articlesPublished.Count; i++)
            {
                yield return articlesPublished[i];
            }
            for (int i = 0; i < notesMade.Count; i++)
            {
                yield return notesMade[i];
            }
        }
        public IEnumerable RecentArticles(int n)
        {

            for (int i = 0; i < ArticlesPublished.Count; i++)
            {
               
                //} если статья написана за последние н лет от сегодняшней даты включительно:
                if ((ArticlesPublished[i].Date).Subtract(new DateTime((DateTime.Today.Year - n), (DateTime.Today).Month, (DateTime.Today).Day)).Days >= 0)
                {
                    yield return articlesPublished[i];
                }
            }
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
        public GraduateStudet(Person p, Person sup, string employeePosition, string speciality, FormOfStudy form, int learningYear) 
            : base(p.Name, p.LastName, p.Date)//List<Article> articlesPublished, List<Notes> notesMade
        {
            EmployeePosition = employeePosition;
            Supervisor = sup;
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
                       $"Form of study {Form}\n learning year {LearningYear}\n\nList of Articles:\n");
            foreach (Article a in ArticlesPublished)
            {
                allInfo += a.ToString();
            }
            allInfo += $"\nLast Article:\n {LastArticle}\nList of notes:\n";//added output of last article
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
            g.PersonProperty = (Person)this.PersonProperty.DeepCopy();
            g.EmployeePosition = new string(EmployeePosition); //String.Copy(EmployeePosition);
            g.Supervisor = (Person)this.Supervisor.DeepCopy();
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
