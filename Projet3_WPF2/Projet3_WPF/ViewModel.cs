using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet3_WPF
{
    public class ViewModel 
    {
        DataClasses1DataContext cl = new DataClasses1DataContext();
        public  ObservableCollection<filiere> filieres { get; set; }
        

        public ViewModel()
        {
            filieres = new ObservableCollection<filiere>(cl.filiere.ToList<filiere>());
            
        }

    }
}
