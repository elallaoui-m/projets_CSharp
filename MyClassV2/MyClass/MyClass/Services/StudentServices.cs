using MyClass.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MyClass.Services
{
    class StudentServices
    {
        static String _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myClass.db3");
        public static int checkForm(String cne, String firstName, String lastName, String email, String phoneNumber, String filiere)
        {
            /**
             * LoginForm (String login, String password)
             * SignupForm extends LoginForm (String firstName, String lastName, String reconfirmPassword)
             * 
             * Validators LoginValidator / UserCreationValidator 
             * 
             * ValidationException(exceptionMessage,minumumLength,parameter)// String, 
             * 
             * 
             * 
             */

            if (!String.IsNullOrEmpty(cne))
            {
                if (!String.IsNullOrEmpty(firstName) && firstName.Length >= 3) //
                {
                    if (!String.IsNullOrEmpty(lastName) && lastName.Length >= 3)
                    {
                        if (!String.IsNullOrWhiteSpace(email) && email.Length >= 3)
                        {
                            if (!String.IsNullOrWhiteSpace(phoneNumber) && phoneNumber.Length >= 8)
                            {
                                var db = new SQLiteConnection(_dbPath);
                                db.CreateTable<Student>();

                                var maxPk = db.Table<Student>().OrderByDescending(c => c.id).FirstOrDefault();
                                Student student = new Student()
                                {
                                    id = (maxPk == null ? 1 : maxPk.id + 1),
                                    cne = cne,
                                    firstName = firstName,
                                    lastName = lastName,
                                    email = email,
                                    phoneNumber = phoneNumber,
                                    filiere = filiere
                                };
                                db.Insert(student);
                                return 0;
                            }

                            return 1;

                        }
                        return 2;
                    }
                    return 3;
                }
                return 4;
            }
            return 5;
        }

        public static Student findStudent(int id)
        {
            var db = new SQLiteConnection(_dbPath);
            Student student = db.Table<Student>().Where(x => x.id == id).FirstOrDefault();
            return student;
        }
    }
}
