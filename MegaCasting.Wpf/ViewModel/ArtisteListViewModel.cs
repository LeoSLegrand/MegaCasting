using MegaCasting.Core;
using MegaCasting.DBLib.Class;
using MegaCasting.Wpf.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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

        // Add a property to hold the collection of Metiers
        private ObservableCollection<Metier> _Metiers;

        public ObservableCollection<Metier> Metiers
        {
            get { return _Metiers; }
            set { SetProperty(nameof(Metiers), ref _Metiers, value); }
        }

        private Metier _SelectedMetier;

        public Metier SelectedMetier
        {
            get { return _SelectedMetier; }
            set { SetProperty(nameof(SelectedMetier), ref _SelectedMetier, value); }
        }

        private string _NewArtisteName;

        public string NewArtisteName
        {
            get { return _NewArtisteName; }
            set { SetProperty(nameof(NewArtisteName), ref _NewArtisteName, value); }
        }




        private string _NewArtisteAge;

        public string NewArtisteAge
        {
            get { return _NewArtisteAge; }
            set { SetProperty(nameof(NewArtisteAge), ref _NewArtisteAge, value); }
        }



        private string _NewArtistePrenom;

        public string NewArtistePrenom
        {
            get { return _NewArtistePrenom; }
            set { SetProperty(nameof(NewArtistePrenom), ref _NewArtistePrenom, value); }
        }


        private Artiste _SelectedArtiste;

        public Artiste SelectedArtiste
        {
            get { return _SelectedArtiste; }
            set { SetProperty(nameof(SelectedArtiste), ref _SelectedArtiste, value); }
        }

        public ArtisteListViewModel()
        {
            using (MegaCastingContext mg = new MegaCastingContext())
            {
                Artistes = new ObservableCollection<Artiste>(mg.Artistes.ToList());

                // Populate the collection of Metiers
                Metiers = new ObservableCollection<Metier>(mg.Metiers.ToList());
            }
        }

        /// <summary>
        /// Ajoute un artiste
        /// </summary>
        /// <param name="artiste"></param>
        public void AddArtiste()
        {
            using (MegaCastingContext mg = new MegaCastingContext())
            {
                // Vérifie si un Metier est sélectionné
                if (SelectedMetier != null)
                {
                    // Vérifie si les champs Nom et Prénom sont remplis
                    if (!string.IsNullOrEmpty(NewArtisteName) && !string.IsNullOrEmpty(NewArtistePrenom))
                    {
                        // Convertit NewArtisteAge en entier
                        if (int.TryParse(NewArtisteAge, out int age))
                        {
                            // Crée un nouvel Artiste avec l'ID du Metier sélectionné
                            Artiste newArtiste = new Artiste
                            {
                                Nom = NewArtisteName,
                                Prenom = NewArtistePrenom, // Définit le prénom
                                Age = age, // Définit l'âge
                                MetierId = SelectedMetier.Id  // Définit l'ID du Metier sélectionné
                            };

                            mg.Add(newArtiste);
                            mg.SaveChanges();
                            Artistes.Add(newArtiste);
                        }
                        else
                        {
                            // Affiche un message d'erreur pour l'âge non valide
                            MessageBox.Show("L'âge doit être un entier valide.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        // Affiche un message d'erreur pour les champs manquants
                        MessageBox.Show("Veuillez remplir tous les champs.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    // Affiche un message d'erreur pour aucun Metier sélectionné
                    MessageBox.Show("Veuillez sélectionner un métier.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        /// <summary>
        /// Mise à jour d'un artiste
        /// </summary>
        public void UpdateArtiste()
        {
            // Vérifie si un artiste est sélectionné
            if (SelectedArtiste != null)
            {
                using (MegaCastingContext mg = new MegaCastingContext())
                {
                    mg.Update(SelectedArtiste);
                    mg.SaveChanges();
                }
            }
            else
            {
                // Affiche un message d'erreur si aucun artiste n'est sélectionné
                MessageBox.Show("Veuillez sélectionner un artiste à mettre à jour.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Supprime un artiste
        /// </summary>
        public void RemoveArtiste()
        {
            // Vérifie si un artiste est sélectionné
            if (SelectedArtiste != null)
            {
                using (MegaCastingContext mg = new MegaCastingContext())
                {
                    mg.Remove(SelectedArtiste);
                    mg.SaveChanges();
                    Artistes.Remove(SelectedArtiste);
                }
            }
            else
            {
                // Affiche un message d'erreur si aucun artiste n'est sélectionné
                MessageBox.Show("Veuillez sélectionner un artiste à supprimer.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}