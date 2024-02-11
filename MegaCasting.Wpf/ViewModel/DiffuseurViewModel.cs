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
            // Vérifie si le libellé du diffuseur est rempli
            if (!string.IsNullOrWhiteSpace(NewDiffuseurName))
            {
                using (MegaCastingContext mg = new MegaCastingContext())
                {
                    Diffuseur newDiffuseur = new Diffuseur { LibelleDiffuseur = NewDiffuseurName };
                    mg.Add(newDiffuseur);
                    mg.SaveChanges();
                    Diffuseurs.Add(newDiffuseur);
                }
            }
            else
            {
                // Affiche un message d'erreur si le libellé du diffuseur n'est pas rempli
                MessageBox.Show("Veuillez remplir le libellé du diffuseur.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Mise à jour d'un diffuseur
        /// </summary>
        public void UpdateDiffuseur()
        {
            // Vérifie si un diffuseur est sélectionné
            if (SelectedDiffuseur != null)
            {
                using (MegaCastingContext mg = new MegaCastingContext())
                {
                    mg.Update(SelectedDiffuseur);
                    mg.SaveChanges();
                }
            }
            else
            {
                // Affiche un message d'erreur si aucun diffuseur n'est sélectionné
                MessageBox.Show("Veuillez sélectionner un diffuseur à mettre à jour.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Supprime un diffuseur
        /// </summary>
        public void RemoveDiffuseur()
        {
            // Vérifie si un diffuseur est sélectionné
            if (SelectedDiffuseur != null)
            {
                using (MegaCastingContext mg = new MegaCastingContext())
                {
                    mg.Remove(SelectedDiffuseur);
                    mg.SaveChanges();
                    Diffuseurs.Remove(SelectedDiffuseur);
                }
            }
            else
            {
                // Affiche un message d'erreur si aucun diffuseur n'est sélectionné
                MessageBox.Show("Veuillez sélectionner un diffuseur à supprimer.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        public void Refresh()
        {

        }
    }

}