using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyClass.Models
{
    public class Professor
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string login { get; set; }
        public string password { get; set; }


        public override string ToString()
        {
            return firstName + " " + lastName + " " + login + " " + password;

        }
    }
}
