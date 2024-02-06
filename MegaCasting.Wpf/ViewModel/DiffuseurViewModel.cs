using MegaCasting.Core;
using MegaCasting.DBLib.Class;
using MegaCasting.Wpf.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using System.Windows;
using System.Windows.Data;




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


        private string _NewDiffuseurName;

        public string NewDiffuseurName
        {
            get { return _NewDiffuseurName; }
            set { SetProperty(nameof(NewDiffuseurName), ref _NewDiffuseurName, value); }
        }


        private Diffuseur _SelectedDiffuseur;

        public Diffuseur SelectedDiffuseur
        {
            get { return _SelectedDiffuseur; }
            set { SetProperty(nameof(SelectedDiffuseur), ref  _SelectedDiffuseur, value); }
        }


        public DiffuseurViewModel()
        {
            using (MegaCastingContext mg = new MegaCastingContext())
            {
                Diffuseurs = new ObservableCollection<Diffuseur>(mg.Diffuseurs.ToList());
            }


        }


        /// <summary>
        /// Ajoute un diffuseur
        /// </summary>
        /// <param name="libelle"></param>
        public void AddDiffuseur()
        {
            using (MegaCastingContext mg = new MegaCastingContext())
            {
                Diffuseur newDifuseur = new() { LibelleDiffuseur = NewDiffuseurName };
                mg.Add(newDifuseur);
                mg.SaveChanges();
                Diffuseurs.Add(newDifuseur);
            }
        }

        /// <summary>
        /// Mise à jour d'un diffuseur
        /// </summary>
        public void UpdateDiffuseur()
        {
            using (MegaCastingContext mg = new MegaCastingContext())
            {
                mg.Update(SelectedDiffuseur);
                mg.SaveChanges();
            }
        }

        /// <summary>
        /// Mise à jour d'un diffuseur
        /// </summary>
        public void RemoveDiffuseur()
        {
            using (MegaCastingContext mg = new MegaCastingContext())
            {
                mg.Remove(SelectedDiffuseur);
                mg.SaveChanges();
                Diffuseurs.Remove(SelectedDiffuseur);
            }
        }



        public void Refresh()
        {

        }
    }

}