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
    public partial class UpdateLecture : ContentPage
    {
        List<string> selected_switch = new List<string>();

        public UpdateLecture(Models.Lecture lecture)
        {
            InitializeComponent();
            listView.ItemsSource = lecture.students;
            /*foreach(Models.Student st in lecture.students)
            {
                Console.WriteLine(st.IsAbsent);
            }*/
           
        }

        private void IsAbsent_Toggled(object sender, ToggledEventArgs e)
        {
            var isAbsent = (Switch)sender;
            var student = (Models.Student)isAbsent.BindingContext;
            string id = student.id.ToString();

            if (isAbsent.IsToggled)
            {
                if (!selected_switch.Contains(id)) selected_switch.Add(id);
            }
            else
            {
                if (selected_switch.Contains(id)) selected_switch.Remove(id);
            }

        }
    }
}