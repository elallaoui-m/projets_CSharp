using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet3_WPF
{
    class EtudiantOperation
    {

        public ObservableCollection<etudiant> etudiants;
        public EtudiantOperation()
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            etudiants = new ObservableCollection<etudiant>(dc.etudiant.ToList());
        }

        public EtudiantOperation(int id_filiere)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            etudiants = new ObservableCollection<etudiant>(dc.etudiant.Where<etudiant>(e => e.id_filiere == id_filiere).ToList());
        }
    }
}
