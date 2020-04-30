using System;
using System.Collections.Generic;
using System.Text;

namespace laboratorna3
{
    class Person: IDateAndCopy
    {
        protected string name;
        protected string lastName;
        protected DateTime birthday;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public DateTime Date
        {
            get { return birthday; }
            set { birthday = value; }
        }
        public int ChangeBirthday
        {
            get { return Date.Year; }
            set { Date = new DateTime(value, Date.Month, Date.Day); }
        }
        public Person(string name, string lastName, DateTime birthday)
        {
            Name = name;
            LastName = lastName;
            Date = birthday;
        }
        public Person()
        {
            Name = "Iryna";
            LastName = "Yudina";
            Date = new DateTime(2001, 01, 27);
        }
        override public string ToString()
        {
            return ($"\n Name: {Name}\n Last Name: {LastName}\n" +
                $" Date of birthday: {Date}\n");
        }
        public virtual string ToShortString()
        {
            return ($"{Name} {LastName}");
        }
        public override bool Equals(object obj)
        {
            if(obj != null && obj.ToString() == this.ToString())
            {
                return true;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        public static bool operator == (Person p1, Person p2)
        {
            return p1.Equals(p2);
        }
        public static bool operator !=(Person p1, Person p2)
        {
            return !p1.Equals(p2);
        }
        public virtual object DeepCopy() {
            Person p = (Person)this.MemberwiseClone();
            p.Name = new string(Name);//String.Copy(Name);
            p.LastName = new string(LastName); //String.Copy(LastName);
            //p.Date = new DateTime(Date.Year, Date.Month, Date.Day);//birthday
            return p;
        }

    }
}
