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
    public partial class Student_Info : ContentPage
    {

        public Student_Info(Models.Student student)
        {
            InitializeComponent();
            Title = student.infoFull;
            filiere.Text = student.filiere;
            nom.Text = student.infoFull;
            email.Text = student.email;
            nb_abs.Text = student.absence.ToString();
            cne.Text = student.cne;
        }

    }
}