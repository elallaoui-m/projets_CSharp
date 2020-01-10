using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using System.Drawing.Imaging;

namespace Projet3_WPF
{
    /// <summary>
    /// Logique d'interaction pour Ajouter.xaml
    /// </summary>
    public partial class Ajouter : Window
    {

        string mode = "ajoute";
        etudiant etu;
        public Ajouter()
        {
            InitializeComponent();
        }

        public Ajouter(etudiant e)
        {
            InitializeComponent();
            fillWithStudent(e);
            mode = "modifie";
            etu = e;
            button.Content = "Modifie";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           

            DataClasses1DataContext cl = new DataClasses1DataContext();

            if (datep.SelectedDate==null  || textsexe.Text == "" ||
                textcne.Text == "" || textnom.Text == "" || textprenom.Text == "" || textfiliere.SelectedItem == null)
            {
                MessageBox.Show("Merci de remplire tous les champs");
            }
            else
            {
                var nom = textnom.Text;
                var prenom = textprenom.Text;
                var filiere = textfiliere.SelectedItem;
                var date = datep.SelectedDate;
                var image = image_file.FilePath;                               
                var sexe = textsexe.Text;
                var telephone = texttele.Text;
                var cne = textcne.Text;
                byte[] b = image_file.FilePath == "" ? etu.picture.ToArray() : File.ReadAllBytes(image_file.FilePath);


                if (mode == "ajoute")
                {
                    etu = new etudiant();
                }
                else
                {
                    etu = (from c in cl.etudiant where c.id_etudiant == etu.id_etudiant select c).FirstOrDefault();
                }
                
                

                etu.sexe = sexe[0];
                etu.cne = cne;
                etu.tele = telephone;
                etu.prenom = prenom;
                etu.nom = nom;
                etu.date_naissance = date;
                etu.id_filiere = ((filiere)filiere).id_filiere;
                etu.picture = b;


                if (mode == "ajoute")
                {
                    cl.etudiant.InsertOnSubmit(etu);
                }
               
                cl.SubmitChanges();

                MessageBox.Show("Etudiant "+mode+" avec succes");

                Gestion_Etudiants ge = new Gestion_Etudiants();
                ge.Show();
                this.Close();

            }

           
            
        }


        private void fillWithStudent(etudiant e)
        {
            textnom.Text =  e.nom;
            textprenom.Text = e.prenom;
            textfiliere.Text = e.filiere.nom_filiere;
            datep.SelectedDate = e.date_naissance;
            image_file.FilePath="";
            textsexe.Text = e.sexe.ToString(); 
            texttele.Text = e.tele;
            textcne.Text = e.cne;
            image.Source = byteArrayToImage(e.picture.ToArray());



        }

        public ImageSource byteArrayToImage(byte[] byteArrayIn)
        {
            BitmapImage biImg = new BitmapImage();
            MemoryStream ms = new MemoryStream(byteArrayIn);
            biImg.BeginInit();
            biImg.StreamSource = ms;
            biImg.EndInit();

            ImageSource imgSrc = biImg as ImageSource;

            return imgSrc;  
        }
    }
}
