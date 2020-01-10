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
    public partial class SignUpPage : ContentPage
    {

        public SignUpPage()
        {
            InitializeComponent();
            LoginIcon.Source = ImageSource.FromResource("MyClass.Resources.TeacherLogo.png");
            init();

        }
        public void init()
        {
            firstNameText.Completed += (s, e) => lastNameText.Focus();
            lastNameText.Completed += (s, e) => passwordText.Focus();
            passwordText.Completed += (s, e) => reconfirmPasswordText.Focus();
            reconfirmPasswordText.Completed += (s, e) => Button_Clicked(s, e);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            switch (ProfessorServices.checkForm(firstNameText.Text, lastNameText.Text, loginText.Text, passwordText.Text, reconfirmPasswordText.Text))
            {
                case 0:
                    DisplayAlert(null, "You have successfully signed up", "Back");
                    Navigation.PopAsync();
                    break;
                case 1:
                    DisplayAlert("Erreur de saisie", "Le prénom doit avoir un minimum de 3 caractères!", "OK");
                    break;
                case 2:
                    DisplayAlert("Erreur de saisie", "Le nom doit avoir un minimum de 3 caractères!", "OK");
                    break;
                case 3:
                    DisplayAlert("Erreur de saisie", "Le mot de passe doit avoir un minimum de 8 caractères!", "OK");
                    break;
                case 4:
                    DisplayAlert("Erreur de saisie", "Les mots de passe ne se correspondent pas", "OK");
                    break;
            }
        }

    }
}