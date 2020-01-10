using MyClass.Models;
using MyClass.Services;
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
    public partial class LoginPage : ContentPage
    {
        String _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myClass.db3");

        public LoginPage()
        {

            var db = new SQLiteConnection(_dbPath);
            db.CreateTable<Models.Professor>();
            InitializeComponent();
            LoginIcon.Source = ImageSource.FromResource("MyClass.Resources.TeacherLogo.png");
            init();
        }

        public void init()
        {
            userText.Completed += (s, e) => passwordText.Focus();
            passwordText.Completed += (s, e) => Button_Clicked(s, e);
        }

        private void UserText_Completed(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Professor professor = ProfessorServices.checkLogin(userText.Text, passwordText.Text);
            //Console.WriteLine(5+21 + professor == null);
            if (professor != null) // null.
            {
                Application.Current.MainPage = new Home();
            }
            else
            {
                DisplayAlert("Error", "No match found", "OK");
            }
        }

        private async void SignUp_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }

    }
}