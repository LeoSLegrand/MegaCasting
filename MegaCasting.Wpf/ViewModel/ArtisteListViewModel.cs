using MegaCasting.Core;
using MegaCasting.DBLib.Class;
using MegaCasting.Wpf.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCasting.Wpf.ViewModel
{
    class ArtisteListViewModel : ObservableObject
    {
        private ObservableCollection<Artiste> _Artistes;

        public ObservableCollection<Artiste> Artistes
        {
            get { return _Artistes; }
            set { SetProperty(nameof(Artistes), ref _Artistes, value); }
        }


        public ArtisteListViewModel()
        {
            using (MegaCastingContext mg = new MegaCastingContext())
            {
                Artistes = new ObservableCollection<Artiste>(mg.Artistes.ToList());
            }

            
        }
    }
}
