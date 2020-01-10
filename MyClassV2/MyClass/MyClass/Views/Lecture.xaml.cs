using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyClass.Models;

namespace MyClass.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Lecture : ContentPage
    {
        String _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myClass.db3");
        String filiereSelected;
        int filiereID;
        List<string> selected_switch = new List<string>();


        public Lecture()
        {
            InitializeComponent();
            
            /*if (tableQuery != null && tableQuery.Count() > 0)
            {
                listView.ItemsSource = tableQuery.OrderBy(x => x.firstName).ToList();
            }
            */
        }

        private void FilierePicker_SelectedIndexChanged(object sender, EventArgs e)
        {

            Picker picker = (Picker)sender;
            filiereID = picker.SelectedIndex;
            filiereSelected = filierePicker.SelectedItem.ToString();
            coursePicker.IsEnabled = true;
            coursePicker.Items.Clear();
            var db = new SQLiteConnection(_dbPath);
            TableQuery<Models.Student> tableQuery = db.Table<MyClass.Models.Student>();
            listView.ItemsSource = tableQuery.Where(i => i.filiere == filiereSelected);
            switch (filiereID)
            {
                
                case 0: coursePicker.Items.Add("C#"); coursePicker.Items.Add("Java"); coursePicker.Items.Add("PHP"); coursePicker.Items.Add("Androird"); break;
                case 1: coursePicker.Items.Add("BE Réseaux"); coursePicker.Items.Add("Administration Linux"); break;
                case 2: coursePicker.Items.Add("Thermodynamique et Thermique"); coursePicker.Items.Add("Mécaniques des fluides"); coursePicker.Items.Add("Mathématiques de l’Ingénieur"); break;
                case 3: coursePicker.Items.Add("Chimie"); coursePicker.Items.Add("Procédés Industriels"); coursePicker.Items.Add("Conduite des procédés"); break;

            }
        }

        private void IsAbsent_Toggled(object sender, ToggledEventArgs e)
        {
            var isAbsent =  (Switch) sender;
            var student = (Models.Student)isAbsent.BindingContext;
            string id = student.id.ToString();

            if (isAbsent.IsToggled) {
                if (!selected_switch.Contains(id)) selected_switch.Add(id);
            } else
            {
                if (selected_switch.Contains(id)) selected_switch.Remove(id);
            }
         
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            TableQuery<Models.Student> tableQuery = db.Table<MyClass.Models.Student>();
            List<Models.Student> students = new List<Models.Student>();
            students = tableQuery.Where(i => i.filiere == filiereSelected).ToList();


            // to review
            foreach (string id_etudiant in selected_switch)
            {
                foreach (Models.Student st in students)
                {
                    if (st.id == Int32.Parse(id_etudiant))
                    {
                        st.IsAbsent = true;
                        st.absence ++;
                        db.Update(st);
                    }
                }
            }

            /*foreach (Models.Student st in students)
               {
               Console.WriteLine(st.IsAbsent);
           }*/


            Services.LectureServices.addLecture(coursePicker.SelectedItem.ToString(), DateTime.Now, filierePicker.SelectedItem.ToString(), students);
        }

      
    }
}