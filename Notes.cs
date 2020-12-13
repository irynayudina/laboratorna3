using System;
using System.Collections.Generic;
using System.Text;

namespace laboratorna3
{
    [Serializable]
    class Notes: IDateAndCopy
    {
        public string NameOfTheNote { get;  set; }
        public string NameOfTheConference { get; set; }
        public DateTime Date { get; set; }// DateOfPublishingTheNote
        public Notes()
        {
            NameOfTheNote = "Default note";
            NameOfTheConference = "Default conference";
            Date = DateTime.Today;
        }
        public Notes(string name, string conf, DateTime date)
        {
            NameOfTheNote = name;
            NameOfTheConference = conf;
            Date = date;
        }
        public override string ToString()
        {
            return $"Name of the note: {NameOfTheNote}\nName of the conference: {NameOfTheConference}\nDate of publishing the note {Date}";
        }
        public virtual object DeepCopy()
        {
            Notes n = (Notes)this.MemberwiseClone();
            n.NameOfTheNote = new string(NameOfTheNote); //String.Copy(NameOfTheNote);
            n.NameOfTheConference = new string(NameOfTheConference); //String.Copy(NameOfTheConference);
            n.Date = new DateTime(Date.Year, Date.Month, Date.Day);
            return n;
        }
    }
}
