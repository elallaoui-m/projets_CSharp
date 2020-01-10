using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logique d'interaction pour Gestion_Etudiants.xaml
    /// </summary>
    public partial class Gestion_Etudiants : Window
    {
        DataClasses1DataContext cl = new DataClasses1DataContext();
        public ObservableCollection<filiere> filieres;



        public Gestion_Etudiants( )
        {
            InitializeComponent();
            this.DataContext = filieres;           
        }


        private void onLoad(object sender, RoutedEventArgs e)
        {
            grido.ItemsSource = new EtudiantOperation().etudiants;


        }

        private void BtnAjouter_Click(object sender, RoutedEventArgs e)
        {
            Ajouter a = new Ajouter();
            a.Show();
        }

        private void Precedent_Click(object sender, RoutedEventArgs e)
        {
            Accueil a = new Accueil();
            a.Show();
            this.Close();
        }

        private void Combofiliere_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            filiere f = (filiere)combofiliere.SelectedItem;
            grido.ItemsSource = new EtudiantOperation(f.id_filiere).etudiants;

        }

        private void BtnModifier_Click(object sender, RoutedEventArgs e)
        {
            if(grido.SelectedItem == null)
            {
                MessageBox.Show("Veuillez selectionner un etudiant");
            }
            else
            {
                etudiant selected =(etudiant) grido.SelectedItem;
                Ajouter a = new Ajouter(selected);
                a.Show();
                this.Close();
                
            }
        }

        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            if (grido.SelectedItem == null)
            {
                MessageBox.Show("Veuillez selectionner un etudiant");
            }
            else
            {
                MessageBoxResult message = MessageBox.Show("Vous etes sure?", "Confirmation de suppression", System.Windows.MessageBoxButton.YesNo);
                if(message == MessageBoxResult.Yes)
                {
                    etudiant selected = (etudiant)grido.SelectedItem;
                    var s = from st in cl.etudiant 
                            where st.id_etudiant == selected.id_etudiant 
                            select st;
                    cl.etudiant.DeleteOnSubmit(s.FirstOrDefault());
                    cl.SubmitChanges();
                    grido.Items.Refresh();
                    MessageBox.Show("Etudiant supprimer avec succes");
                }
            }

        }

        
    }
}
