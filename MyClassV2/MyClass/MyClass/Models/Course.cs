using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyClass.Models
{
    public class Course
    {
        [PrimaryKey]
        public int id { get; set; }
        public string courseName { get; set; }
        
        public string courseFiliere { get; set; }

    }
}
