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
    /// Logique d'interaction pour GestionFiliere.xaml
    /// </summary>
    public partial class GestionFiliere : Window
    {
        
        DataClasses1DataContext cl = new DataClasses1DataContext();
        public GestionFiliere()
        {
            InitializeComponent();
        }

        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            
            filiere selected = (filiere)telerik_filiere.SelectedItem;
            if(selected ==  null)
            {
                MessageBox.Show("Veuillez selectionner une filiere");
            }
            else
            {
                MessageBoxResult message = MessageBox.Show("Vous etes sure?", "Confirmation de suppression", System.Windows.MessageBoxButton.YesNo);
                if (message == MessageBoxResult.Yes)
                {
                    selected = (filiere)telerik_filiere.SelectedItem;
                    var s = from st in cl.filiere
                            where st.id_filiere == selected.id_filiere 
                            select st;
                    cl.filiere.DeleteOnSubmit(s.FirstOrDefault());
                    cl.SubmitChanges();
                    telerik_filiere.Items.Refresh();
                    ViewModel vm = new ViewModel();
                    telerik_filiere.ItemsSource = vm.filieres;
                    MessageBox.Show("Filiere supprimer avec succes");
                    idTB.Clear();
                    nomTB.Clear();
                    respoTB.Clear();


                }
            }
        }

        private void telerik_filiere_SelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangeEventArgs e)
        {
            filiere selected = (filiere)telerik_filiere.SelectedItem;
            if (selected != null)
            {
                btnModifier.IsEnabled = true;
                btnSupprimer.IsEnabled = true;
                idTB.Text = selected.id_filiere.ToString();
                nomTB.Text = selected.nom_filiere;
                respoTB.Text = selected.resp;
            }
        }

        private void btnModifier_Click(object sender, RoutedEventArgs e)
        {

            filiere selected = (filiere)telerik_filiere.SelectedItem;
            if (selected == null)
            {
                MessageBox.Show("Veuillez selectionner une filiere");
            }
            else
            {
                filiere f = (from fl in cl.filiere
                             where fl.id_filiere == selected.id_filiere
                             select fl).FirstOrDefault();

                f.nom_filiere = nomTB.Text;
                f.resp = respoTB.Text;

                cl.SubmitChanges();
                telerik_filiere.Items.Refresh();
                ViewModel vm = new ViewModel();
                telerik_filiere.ItemsSource = vm.filieres;
                idTB.Clear();
                nomTB.Clear();
                respoTB.Clear();

                MessageBox.Show("Modifier avec succes");

            }

        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            if(nomTB.Text.Trim() == "" || respoTB.Text.Trim() == "")
            {
                MessageBox.Show("Merci de remplire tous les champs disponibles");
            }
            else
            {
                filiere filiere = new filiere();
                filiere.nom_filiere = nomTB.Text;
                filiere.resp = respoTB.Text;

                cl.filiere.InsertOnSubmit(filiere);
                cl.SubmitChanges();

                telerik_filiere.Items.Refresh();
                ViewModel vm = new ViewModel();
                telerik_filiere.ItemsSource = vm.filieres;

                nomTB.Clear();
                respoTB.Clear();
                MessageBox.Show("Filiere ajoute avec succes");
            }
           
        }

        private void radButton_Click(object sender, RoutedEventArgs e)
        {
            Accueil ac = new Accueil();
            ac.Show();
            this.Close();
        }
    }
}
