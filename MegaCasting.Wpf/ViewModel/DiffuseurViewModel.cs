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
    class DiffuseurViewModel : ObservableObject
    {
        private ObservableCollection<Diffuseur> _Diffuseurs;

        public ObservableCollection<Diffuseur> Diffuseurs
        {
            get { return _Diffuseurs; }
            set { SetProperty(nameof(Diffuseurs), ref _Diffuseurs, value); }
        }

        public DiffuseurViewModel()
        {
            using (MegaCastingContext mg = new MegaCastingContext())
            {
                Diffuseurs = new ObservableCollection<Diffuseur>(mg.Diffuseurs.ToList());
            }

            
        }
    }
}
