using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyClass.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : Shell
    {
        String _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myClass.db3");

        public Home()
        {
            Lecture lecture = new Lecture();
           
            var db = new SQLiteConnection(_dbPath);
            db.CreateTable<Models.Lecture>();
            db.CreateTable<Models.Student>();
            db.CreateTable<Models.Course>();
            db.CreateTable <Models.Filiere>();
            InitializeComponent();
        }
    }
}