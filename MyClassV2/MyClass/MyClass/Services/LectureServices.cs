using MyClass.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SQLiteNetExtensionsAsync.Extensions;
using SQLite;

namespace MyClass.Services
{
    class LectureServices
    {
        static String _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myClass.db3");
        static readonly SQLiteAsyncConnection database = new SQLiteAsyncConnection(_dbPath);

        public static void addLecture(String courseName, DateTime dateTime, String filiereName, List<Student> students)
        {
            Lecture lecture = new Lecture()
            {
                courseName = courseName,
                filiereName = filiereName,
                dateTime = dateTime,
                students = students,
            };
            SaveLectureAsync(lecture);

        }



        public static Task SaveLectureAsync(Lecture lecture)
        {
            return database.InsertWithChildrenAsync(lecture);
        }
        public static Task<Lecture> GetLectureAsync(int id)
        {
            return null;
        }
        public static Task<List<Lecture>> GetLecturesAsync()
        {
            return database.GetAllWithChildrenAsync<Lecture>();
        }

        public static Task RemoveLectureAsyc(Lecture lecture)
        {
            return database.DeleteAsync(lecture);
        }
    }
}
