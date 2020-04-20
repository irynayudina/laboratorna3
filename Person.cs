﻿using System;
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
        public DateTime Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }
        public int ChangeBirthday
        {
            get { return Birthday.Year; }
            set { Birthday = new DateTime(value, Birthday.Month, Birthday.Day); }
        }
        public Person(string name, string lastName, DateTime birthday)
        {
            Name = name;
            LastName = lastName;
            Birthday = birthday;
        }
        public Person()
        {
            Name = "Iryna";
            LastName = "Yudina";
            Birthday = new DateTime(2001, 01, 27);
        }
        override public string ToString()
        {
            return ($"\n Name: {Name}\n Last Name: {LastName}\n" +
                $" Date of birthday: {Birthday}\n");
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
        public object DeepCopy() {
            Person p = (Person)this.MemberwiseClone();
            p.Name = String.Copy(Name);
            p.LastName = String.Copy(LastName);
            p.Birthday = new DateTime(Birthday.Year, Birthday.Month, Birthday.Day);
            return p;
        }
        public  DateTime Date { get; set; }

    }
}
