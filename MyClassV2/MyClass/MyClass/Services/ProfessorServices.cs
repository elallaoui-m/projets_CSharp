using MyClass.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MyClass.Services
{
    class ProfessorServices
    {
        static String _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myClass.db3");

        public static int checkForm(String firstName, String lastName, String login, String password, String reconfirmPassword)
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
            if (!String.IsNullOrEmpty(firstName) && firstName.Length >= 3) //
            {
                if (!String.IsNullOrEmpty(lastName) && lastName.Length >= 3)
                {
                    if (!String.IsNullOrWhiteSpace(password) && password.Length > 7)
                    {
                        if (password.Equals(reconfirmPassword))
                        {
                            var db = new SQLiteConnection(_dbPath);
                            db.CreateTable<Professor>();

                            var maxPk = db.Table<Professor>().OrderByDescending(c => c.id).FirstOrDefault();
                            Professor professeur = new Professor()
                            {
                                id = (maxPk == null ? 1 : maxPk.id + 1),
                                firstName = firstName,
                                lastName = lastName,
                                login = login,
                                password = password
                            };
                            db.Insert(professeur);

                            return 0;
                        }

                        return 4;

                    }
                    return 3;
                }
                return 2;
            }
            return 1;
        }

        public static Professor checkLogin(string login, string password)
        {

            var db = new SQLiteConnection(_dbPath);
            TableQuery<Professor> tableQuery = db.Table<Professor>();


            Professor professor = tableQuery.Where(i => i.login == login && i.password == password).FirstOrDefault();
            if (professor != null)
            {
                return professor;
            }

            return null;
        }
    }
}






