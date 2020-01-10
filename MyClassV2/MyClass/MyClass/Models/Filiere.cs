using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyClass.Models
{
    public class Filiere
    {
        [PrimaryKey, AutoIncrement]

        public int id { get; set; }
        public string filiereName { get; set; }
    }
}
