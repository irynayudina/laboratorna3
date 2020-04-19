using System;
using System.Collections.Generic;
using System.Text;

namespace laboratorna3
{
    class GraduateStudet: Person, IDateAndCopy
    {
        private string employeePosition;
        private Person dataOfTheSupervisor;
        private string speciality;
        private FormOfStudy form;
        private int learningYear;
        private List<Article> articlesPublished;
        private List<Notes> notesMade;
        public string EmployeePosition { 
            get { return employeePosition; }
            set { employeePosition = value; }
        }
        public Person DataOfTheSupervisor
        {
            get { return dataOfTheSupervisor; }
            set { dataOfTheSupervisor = value; }
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
            set { learningYear = value; }
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
        public GraduateStudet()
        {
            EmployeePosition = "Default employee position";
            DataOfTheSupervisor = new Person();
            Speciality = "Default speciality";
            Form = 0;
            LearningYear = DateTime.Today.Year;
            ArticlesPublished = new List<Article>();
            NotesMade = new List<Notes>();
        }
        public GraduateStudet(string employeePosition, Person supervisor, string speciality, FormOfStudy form, int learningYear, List<Article> articlesPublished, List<Notes> notesMade)
        {
            EmployeePosition = employeePosition;
            DataOfTheSupervisor = supervisor;
            Speciality = speciality;
            Form = form;
            LearningYear = learningYear;
            ArticlesPublished = articlesPublished;
            NotesMade = notesMade;
        }

    }
}
