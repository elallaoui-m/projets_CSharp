using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyClass.Models
{
    public class Student
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string cne { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string filiere { get; set; }

        public int absence { get; set; }

        public bool IsAbsent { get; set; }

        public string infoFull
        {
            get { return $"{firstName} {lastName}"; }
        }
        public override string ToString()
        {
            return firstName + " " + lastName + " " + filiere;
        }
    }
}
