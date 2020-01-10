using Newtonsoft.Json;
using SQLite;
using SQLiteNetExtensions.Attributes;
using SQLiteNetExtensions.Extensions.TextBlob;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyClass.Models
{
    public class Lecture
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public DateTime dateTime { get; set; }
        public String courseName { get; set; }
        public String filiereName { get; set; }
       

        public String studentsBlobbed { get; set; }

        [TextBlob("studentsBlobbed")]
        public List<Student> students { get; set; }


        public override string ToString()
        {
            return filiereName + " " + courseName + " " + dateTime;
        }
    }
}

/*
               public String test { get; set; }
               //   [TextBlob("studentsBlobbed")]
             //  public String studentsSerialized { get; set; }
               //[TextBlob]
               public List<Student> students
               {
                   get
                   {
                       return JsonConvert.DeserializeObject<List<Student>>(studentsSerialized);
                   }
                   set
                   {
                       studentsSerialized = JsonConvert.SerializeObject(value);
                   }
                   */
