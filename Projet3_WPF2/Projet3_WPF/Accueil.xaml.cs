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

namespace Projet3_WPF
{
    /// <summary>
    /// Logique d'interaction pour Accueil.xaml
    /// </summary>
    public partial class Accueil : Window
    {
        public Accueil()
        {
            InitializeComponent();
            Userlabel.Content = App.Current.Properties["connected"];
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Gestion_Etudiants gestion_Etudiants = new Gestion_Etudiants();
            gestion_Etudiants.Show();
            
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GestionFiliere gestion = new GestionFiliere();
            gestion.Show();
            
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Statistiques statistiques = new Statistiques();
            statistiques.Show();
            
        }
    }
}
