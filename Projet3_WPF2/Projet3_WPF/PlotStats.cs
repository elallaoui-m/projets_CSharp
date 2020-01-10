using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Telerik.Windows.Data;

namespace Projet3_WPF
{
    public class PlotStats : DependencyObject
    {
        public static readonly DependencyProperty DataProperty = DependencyProperty.Register("Data",
        typeof(ObservableCollection<plot>),
        typeof(PlotStats),
        new PropertyMetadata(null));

        DataClasses1DataContext cl = new DataClasses1DataContext();
        public RadObservableCollection<plot> plots
        {
            get
            {
                return (RadObservableCollection<plot>)
                    this.GetValue(DataProperty);
            }
            set
            {
                this.SetValue(DataProperty, value);
            }
        }


        public PlotStats()
        {

            plots = new RadObservableCollection<plot>();
            var filiere = from f in cl.filiere select f;

            foreach (var x in filiere)
            {
                var tmp = from e in cl.etudiant
                          where e.id_filiere == x.id_filiere
                          select e;


                plots.Add(new plot(x.nom_filiere, tmp.Count()));
            }

           
        }


        public class plot
        {
            public plot(string filiere, double value)
            {
                this.Filiere = filiere;
                this.Value = value;
            }

            public string Filiere { get; set; }
            public double Value { get; set; }



        }
    }
}
