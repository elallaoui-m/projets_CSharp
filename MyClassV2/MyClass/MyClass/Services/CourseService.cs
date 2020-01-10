using MyClass.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MyClass.Services
{
    class CourseService
    {
        static String _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myClass.db3");

        public static void addLecture(String courseName, String filiereName)
        {
            var db = new SQLiteConnection(_dbPath);
            db.CreateTable<Course>();

            var maxPk = db.Table<Course>().OrderByDescending(c => c.id).FirstOrDefault();
            Course course = new Course()
            {
                id = (maxPk == null ? 1 : maxPk.id + 1),
                courseName = courseName,
                courseFiliere = filiereName,
                
            };
            db.Insert(course);

        }
    }
}
