using Iut.MasterAnime.ClassLibrary;
using Iut.MasterAnime.Management;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Iut.MasterAnime.Winapp.CodeModifierBibliothèque
{
    /// <summary>
    /// Logique d'interaction pour ModifierBibliothèque.xaml
    /// </summary>
    public partial class ModifierBibliothèque : Window
    {
        /// <summary>
        /// Une nouvelle instance de la bibliothèque à modifier afin de pouvoir annuler les changements
        /// </summary>
        public Bibliothèque NouvelleBibliothèque
        {
            get => nouvelleBibliothèque;
            set
            {
                nouvelleBibliothèque.Nom = value.Nom;
                nouvelleBibliothèque.Image = value.Image;
                nouvelleBibliothèque.LesOeuvres.Clear();
                value.LesOeuvres.ToList().ForEach(oeuvre => nouvelleBibliothèque.AjouterOeuvre(oeuvre));
            }
        }
        private Bibliothèque nouvelleBibliothèque = new Bibliothèque("UneBibliothèque", "", new ObservableCollection<Oeuvre>());

        /// <summary>
        /// Le constructeur de la classe du user control ModifierBibliothèque
        /// </summary>
        public ModifierBibliothèque()
        {
            InitializeComponent();
            NouvelleBibliothèque = (Application.Current as App).Manager.BibliothèqueSélectionnée;

            DataContext = NouvelleBibliothèque;
        }

        /// <summary>
        /// Permet d'ouvrir une boite de dialogue pour sélectionner une image pour la bibliothèque
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void Explorer_Click(object sender, RoutedEventArgs e)
        {
            String chemin = Utilitaires.ExplorateurImage();
            if(chemin != null)
            {
                NouvelleBibliothèque.Image = chemin;
            }
        }

        /// <summary>
        /// Permet de sauvegarder les modifications de la bibliothèque
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void Sauvegarder_Click(object sender, RoutedEventArgs e)
        {
            Manager manager = (Application.Current as App).Manager;
            if(Validateur.BibliothèqueValidateur(NouvelleBibliothèque))
            {
                bool retour = manager.ModifierBibliothèque(manager.BibliothèqueSélectionnée.Nom, NouvelleBibliothèque.Nom,
                    NouvelleBibliothèque.Image, null);
                if(!retour)
                {
                    MessageBox.Show("Une bibliothèque avec ce nom existe déjà.\nVeuillez en trouver un autre.", "Erreur", MessageBoxButton.OK);
                    return;
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Certains champs sont invialides", "Erreur", MessageBoxButton.OK);
            }
        }

        /// <summary>
        /// Permet de supprimer des oeuvres de la bibliothèque sélectionnée
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void SuppressionOeuvres_Click(object sender, RoutedEventArgs e)
        {
            Navigateur navigateur = Navigateur.GetInstance();

            this.Hide();

            navigateur.NaviguerVers(Navigateur.SélectionSuppressionOeuvres_UC);

            (navigateur.UserControlSélectionné as SélectionSuppressionOeuvres).DésabonnementSuppression();
            (navigateur.UserControlSélectionné as SélectionSuppressionOeuvres).SuppressionFinie += SuppressionFinie;
        }

        /// <summary>
        /// Permet de supprimer la bibliothèque sélectionnée du manager
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void SuppressionBibliothèque_Click(object sender, RoutedEventArgs e)
        {
            Manager manager = (Application.Current as App).Manager;
            Navigateur navigateur = Navigateur.GetInstance();

            if (manager.BibliothèqueSélectionnée.Equals(manager.ListePrincipale))
            {
                MessageBox.Show("Vous ne pouvez supprimer la liste principale.\nCelle-ci contient toutes les oeuvres de l'application.", "Information",
                    MessageBoxButton.OK);
            }
            else
            {
                MessageBoxResult result = MessageBox.Show($"Êtes-vous sûr de vouloir supprimer  la bibliothèque " +
                    $"{manager.BibliothèqueSélectionnée.Nom} ?", "Attention", MessageBoxButton.YesNo, MessageBoxImage.Exclamation, MessageBoxResult.No);
                if (result == MessageBoxResult.Yes)
                {
                    manager.RetirerBibliothèque(manager.BibliothèqueSélectionnée);
                    (navigateur.ObtenirUserControl(Navigateur.SélectionSuppressionOeuvres_UC) as SélectionSuppressionOeuvres).DésabonnementSuppression();
                    this.Close();
                }
            }
        }

        /// <summary>
        /// Permet d'annuler les modifications de la bibliothèque
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            Navigateur navigateur = Navigateur.GetInstance();
            (navigateur.ObtenirUserControl(Navigateur.SélectionSuppressionOeuvres_UC) as SélectionSuppressionOeuvres).DésabonnementSuppression();
            this.Close();
        }

        /// <summary>
        /// Permet d'afficher la fenêtre lorsque l'utilisateur a fini de supprimer des oeuvres
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void SuppressionFinie(object sender, EventArgs e)
        {
            this.ShowDialog();
        }
    }
}
