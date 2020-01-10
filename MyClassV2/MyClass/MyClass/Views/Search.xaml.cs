using MyClass.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyClass.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Search : ContentPage
    {
        String _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myClass.db3");

        public Search()
        {
            InitializeComponent();
            var db = new SQLiteConnection(_dbPath);
            listView.ItemsSource = db.Table<MyClass.Models.Student>();
        }

        private void ListView_Refreshing(object sender, EventArgs e)
        {
            GetEtudiantsList();
            listView.EndRefresh();
        }

        private List<Models.Student> GetEtudiantsList(string searchText = null)
        {
            var students = new List<Models.Student>();
            var db = new SQLiteConnection(_dbPath); 
            students = db.Table<MyClass.Models.Student>().ToList();

            if (String.IsNullOrWhiteSpace(searchText))
                return students;

            return students.Where(c=> c.firstName.StartsWith(searchText, StringComparison.InvariantCultureIgnoreCase) || c.lastName.StartsWith(searchText, StringComparison.InvariantCultureIgnoreCase)).ToList();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            listView.ItemsSource = GetEtudiantsList(e.NewTextValue);
        }

        private void ListViewStudent_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var student = e.SelectedItem as Models.Student;
            //DisplayAlert("Student Selected ",student.firstName,"Ok");

            Navigation.PushAsync(new Student_Info(student));

        }
    }

    
}