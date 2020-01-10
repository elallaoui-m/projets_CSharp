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
    /// Interaction logic for Statistiques.xaml
    /// </summary>
    public partial class Statistiques : Window
    {

        DataClasses1DataContext cl = new DataClasses1DataContext();

        public Statistiques()
        {
            InitializeComponent();

        }

        


        void fillStatisticsChart()
        {

            var filiere = from f in cl.filiere select f;

            foreach (var x in filiere)
            {
                var tmp = from e in cl.etudiant
                          where e.id_filiere == x.id_filiere
                          select e;
/*                states.Series["Nombre Etudiant"].Points.AddXY(x.nom_filiere, tmp.Count());
*/            }

        }
    }
}
