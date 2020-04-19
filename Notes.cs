using System;
using System.Collections.Generic;
using System.Text;

namespace laboratorna3
{
    class Notes
    {
        public string NameOfTheNote { get;  set; }
        public string NameOfTheConference { get; set; }
        public DateTime DateOfPublishingTheNote { get; set; }
        public Notes()
        {
            NameOfTheNote = "Default note";
            NameOfTheConference = "Default conference";
            DateOfPublishingTheNote = DateTime.Today;
        }
        public Notes(string name, string conf, DateTime date)
        {
            NameOfTheNote = name;
            NameOfTheConference = conf;
            DateOfPublishingTheNote = date;
        }
        public override string ToString()
        {
            return $"Name of the note: {NameOfTheNote}\nName of the conference: {NameOfTheConference}\nDate of publishing the note {DateOfPublishingTheNote}";
        }
    }
}
