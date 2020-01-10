using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Projet3_WPF.View
{
    /// <summary>
    /// Logique d'interaction pour Login.xaml
    /// </summary>
    public partial class Login : Window
    {

        DataClasses1DataContext cl = new DataClasses1DataContext();
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var q = from c in cl.users
                    where c.login == textlogin.Text && c.pass == textpassword.Password
                    select c;

            if(q.Count() == 1)
            {
                user u = q.FirstOrDefault();
                App.Current.Properties["connected"] = u.login;
                Accueil accueil = new Accueil();
                accueil.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Login ou Mot de passe incorret", "Erreur d'Authentification ", MessageBoxButton.OK, MessageBoxImage.Error);
            }


            /*if (textlogin.Text == "admin"*//* && textpassword.Password == "123456"*//*)
            {
                
            }
            else
            {
                MessageBox.Show("Login ou Mot de passe incorret", "Erreur d'Authentification ", MessageBoxButton.OK, MessageBoxImage.Error);
            }*/
        }

        private void BtnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            textlogin.Text = "";
            textpassword.Password = "";
        }
    }
}
