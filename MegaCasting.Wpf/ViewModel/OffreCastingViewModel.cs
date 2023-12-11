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
    class OffreCastingViewModel : ObservableObject
    {
        private ObservableCollection<Casting> _OffreCastings;

        public ObservableCollection<Casting> OffreCastings
        {
            get { return _OffreCastings; }
            set { SetProperty(nameof(OffreCastings), ref _OffreCastings, value); }
        }


        public OffreCastingViewModel()
        {
            using (MegaCastingContext mg = new MegaCastingContext())
            {
                OffreCastings = new ObservableCollection<Casting>(mg.Castings.ToList());
            }

            
        }
    }
}
