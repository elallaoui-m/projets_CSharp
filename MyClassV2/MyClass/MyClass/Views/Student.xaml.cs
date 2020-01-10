using MyClass.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyClass.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Student : ContentPage
    {
        public Student()
        {
            InitializeComponent();
            //StudentIcon.Source = ImageSource.FromResource("MyClass.Resources.Student.png");

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (filiereText.SelectedIndex < 0)
            {
                DisplayAlert("Erreur de saisie", "L'étudiant doit appartenir à une filière!", "OK");
            }
            else
            {
                switch (StudentServices.checkForm(cneText.Text, firstNameText.Text, lastNameText.Text, emailText.Text, phoneNumberText.Text, filiereText.SelectedItem.ToString()))
                {
                    case 0:
                        DisplayAlert("Success", "You have successfully added a new student", "Back");

                        break;
                    case 1:
                        DisplayAlert("Erreur de saisie", "Veuillez spécifier le numéro de téléphone de l'étudiant!", "OK");
                        break;
                    case 2:
                        DisplayAlert("Erreur de saisie", "Veuillez spécifier l'adresse mail de l'étudiant!", "OK");
                        break;
                    case 3:
                        DisplayAlert("Erreur de saisie", "Le nom doit avoir un minimum de 3 caractères!", "OK");
                        break;
                    case 4:
                        DisplayAlert("Erreur de saisie", "Le prénom doit avoir un minimum de 3 caractères!", "OK");
                        break;
                    case 5:
                        DisplayAlert("Erreur de saisie", "Veuillez spécifier le CNE de l'étudiant!", "OK");
                        break;

                }
            }
        }
    }
}