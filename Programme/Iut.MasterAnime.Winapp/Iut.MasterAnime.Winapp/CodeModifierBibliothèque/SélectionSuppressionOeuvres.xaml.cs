using Iut.MasterAnime.ClassLibrary;
using Iut.MasterAnime.Management;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Iut.MasterAnime.Winapp.CodeModifierBibliothèque
{
    /// <summary>
    /// Logique d'interaction pour SélectionSuppressionOeuvres.xaml
    /// </summary>
    public partial class SélectionSuppressionOeuvres : UserControl
    {
        /// <summary>
        /// Une bibliothèque quelconque permettant de contenir les oeuvres à afficher. Ceci permet à la vue d'être correctement notifiée de tout changement
        /// </summary>
        public Bibliothèque Bibliothèque { get; private set; } = new Bibliothèque("--", "--", new ObservableCollection<Oeuvre>());

        /// <summary>
        /// Le manager étant dans l'App qui est ainsi le même pour toutes les vus
        /// </summary>
        public Manager Manager => (Application.Current as App).Manager;

        /// <summary>
        /// Les oeuvres sélectionnées pour être supprimées de la bibliothèque
        /// </summary>
        public List<Oeuvre> ASupprimer { get; private set; } = new List<Oeuvre>();

        /// <summary>
        /// Le constructeur de la classe du user control SélectionAjoutOeuvresModification
        /// </summary>
        public SélectionSuppressionOeuvres()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Événement permettant de notifier que l'utilisateur a terminé de sélectionner les oeuvres
        /// </summary>
        public event EventHandler SuppressionFinie;

        /// <summary>
        /// Permete de lever l'événement SuppressionFinie notifiant que l'utilisateur a terminé de sélectionner des oeuvres
        /// </summary>
        private void OnSuppressionFinie() => SuppressionFinie?.Invoke(this, null);

        /// <summary>
        /// Permet de retirer tous les abonnemens de SuppressionFinie. Ceci permet de ne pas appeler une window déjà fermée
        /// </summary>
        public void DésabonnementSuppression()
        {
            SuppressionFinie = null;
        }

        /// <summary>
        /// Permet d'ajouter ou retirer une oeuvre de ASupprimer, ainsi que de modifier l'affichage suivant si l'utilisateur l'a sélectionnée ou non
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void Oeuvre_Click(object sender, RoutedEventArgs e)
        {
            if (sender == null)
            {
                return;
            }

            //Si l'oeuvre n'est pas sélectionnée
            if ((sender as Button).BorderBrush == Brushes.LightGray)
            {
                (sender as Button).BorderBrush = new SolidColorBrush(Color.FromRgb(43, 120, 228));

                PackIcon lIcone = (PackIcon)(sender as Button).FindName("lIcone");

                lIcone.Kind = PackIconKind.TickCircleOutline;
                lIcone.Foreground = new SolidColorBrush(Color.FromRgb(43, 120, 228));

                ASupprimer.Add(Manager.BibliothèqueSélectionnée.ObtenirOeuvre((sender as Button).Tag as String));
            }
            //Si l'oeuvre était déjà sélectionnée
            else
            {
                (sender as Button).BorderBrush = Brushes.LightGray;

                PackIcon lIcone = (PackIcon)(sender as Button).FindName("lIcone");
                
                lIcone.Kind = PackIconKind.CircleOutline;
                lIcone.Foreground = Brushes.LightGray;

                ASupprimer.Remove(Manager.BibliothèqueSélectionnée.ObtenirOeuvre((sender as Button).Tag as String));
            }
        }

        /// <summary>
        /// Permet de sélectionner toutes les oeuvres, et donc de les ajouter à ASupprimer
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void ToutCocher_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < Manager.BibliothèqueSélectionnée.NombreOeuvre(); i++)
            {
                ContentPresenter contentPresenter = (ContentPresenter)lItemsControl.ItemContainerGenerator.ContainerFromItem(Manager.BibliothèqueSélectionnée[i]);

                Button leBouton = contentPresenter.ContentTemplate.FindName("leBoutonOeuvre", contentPresenter) as Button;
                PackIcon lIcone = contentPresenter.ContentTemplate.FindName("lIcone", contentPresenter) as PackIcon;

                leBouton.BorderBrush = new SolidColorBrush(Color.FromRgb(43, 120, 228));
                lIcone.Kind = PackIconKind.TickCircleOutline;
                lIcone.Foreground = new SolidColorBrush(Color.FromRgb(43, 120, 228));

                ASupprimer.Add(Manager.BibliothèqueSélectionnée[i]);
            }
        }

        /// <summary>
        /// Permet de désélectionner toutes les oeuvres, et donc de les retirer de ASupprimer
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void ToutDécocher_Click(object sender, RoutedEventArgs e)
        {
            for(int i = 0; i < Manager.BibliothèqueSélectionnée.NombreOeuvre(); i++)
            {
                ContentPresenter contentPresenter = (ContentPresenter)lItemsControl.ItemContainerGenerator.ContainerFromItem(Manager.BibliothèqueSélectionnée[i]);

                Button leBouton = contentPresenter.ContentTemplate.FindName("leBoutonOeuvre", contentPresenter) as Button;
                PackIcon lIcone = contentPresenter.ContentTemplate.FindName("lIcone", contentPresenter) as PackIcon;

                leBouton.BorderBrush = Brushes.LightGray;
                lIcone.Kind = PackIconKind.CircleOutline;
                lIcone.Foreground = Brushes.LightGray;
            }
            ASupprimer.Clear();
        }

        /// <summary>
        /// Permet de supprimer les oeuvres sélectionnées de la bibliothèque
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            Manager manager = (Application.Current as App).Manager;
            
            //Si la bibliothèque sélectionnée est la liste principale
            if (Manager.BibliothèqueSélectionnée.Equals(manager.ListePrincipale))
            {
                MessageBoxResult result = MessageBox.Show($"Êtes-vous sûr de vouloir supprimer {ASupprimer.Count} oeuvre(s) de l'application ?" +
                    $"\nCeci prendra fait immédiatement.", "Attention",
                    MessageBoxButton.YesNo, MessageBoxImage.Exclamation, MessageBoxResult.No);
                if (result == MessageBoxResult.Yes)
                {
                    ASupprimer.ForEach(oeuvre => manager.RetirerOeuvre(oeuvre));
                    Navigateur.GetInstance().NavigerVersAncien();
                    OnSuppressionFinie();
                }
            }
            //Si la bibliothèque sélectionnée n'est pas la liste principale
            else
            {
                MessageBoxResult result = MessageBox.Show($"Êtes-vous sûr de vouloir supprimer {ASupprimer.Count} oeuvre(s) de " +
                    $"{Manager.BibliothèqueSélectionnée.Nom} ?\nCeci prendra fait immédiatement.", "Attention",
                    MessageBoxButton.YesNo, MessageBoxImage.Exclamation, MessageBoxResult.No);
                if (result == MessageBoxResult.Yes)
                {
                    ASupprimer.ForEach(oeuvre => Manager.BibliothèqueSélectionnée.RetirerOeuvre(oeuvre));
                    Manager.SauvegarderLesDonnées();
                    Navigateur.GetInstance().NavigerVersAncien();
                    OnSuppressionFinie();
                }
            }
        }

        /// <summary>
        /// Permet de naviguer vers l'ancien user control, de notifier la fin de la suppression et d'effacer les oeuvres précédemment sélectionnées
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            ASupprimer.Clear();
            Navigateur.GetInstance().NavigerVersAncien();
            OnSuppressionFinie();
        }

        /// <summary>
        /// Permet de modifier l'ordre de trie de l'affichage
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void ordreTri_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TrierOeuvres();
        }

        /// <summary>
        /// Permet de cocher toutes les oeuvres présentes dans ASupprimer
        /// </summary>
        public void CocherSélectionnées()
        {
            for (int i = 0; i < ASupprimer.Count; i++)
            {
                ContentPresenter contentPresenter = (ContentPresenter)lItemsControl.ItemContainerGenerator.ContainerFromItem(ASupprimer.ElementAt(i));

                //Si l'oeuvre n'est pas présente dans l'affichage, quand par exemple un certain type est sélectionné
                if (contentPresenter == null) return;

                contentPresenter.ApplyTemplate();
                Button leBouton = contentPresenter.ContentTemplate.FindName("leBoutonOeuvre", contentPresenter) as Button;
                PackIcon lIcone = contentPresenter.ContentTemplate.FindName("lIcone", contentPresenter) as PackIcon;

                leBouton.BorderBrush = new SolidColorBrush(Color.FromRgb(43, 120, 228));
                lIcone.Kind = PackIconKind.TickCircleOutline;
                lIcone.Foreground = new SolidColorBrush(Color.FromRgb(43, 120, 228));
            }
        }

        /// <summary>
        /// Permet de trier l'affichage des oeuvres suivant ce que l'utilisateur a souhaité
        /// </summary>
        public void TrierOeuvres()
        {
            if (ordreTri == null || duType == null) return;

            TypeOeuvre leTypeOeuvre = TypeOeuvre.Tout;

            var lesOeuvres = new ObservableCollection<Oeuvre>();
            Manager.BibliothèqueSélectionnée.LesOeuvres.ToList().ForEach(oeuvre => lesOeuvres.Add(oeuvre));

            //Sélectionne le type des oeuvres à afficher
            if (duType.SelectedItem.ToString().Contains("Film")) leTypeOeuvre = TypeOeuvre.Film;
            else if (duType.SelectedItem.ToString().Contains("Série")) leTypeOeuvre = TypeOeuvre.Série;
            else if (duType.SelectedItem.ToString().Contains("Livre")) leTypeOeuvre = TypeOeuvre.Livre;
            else if (duType.SelectedItem.ToString().Contains("Scan")) leTypeOeuvre = TypeOeuvre.Scan;
            else if (duType.SelectedItem.ToString().Contains("Animé")) leTypeOeuvre = TypeOeuvre.Animé;
            else if (duType.SelectedItem.ToString().Contains("Autre")) leTypeOeuvre = TypeOeuvre.Autre;

            //Tri les oeuvres suivant ce que l'utilisateur a sélectionné
            if (ordreTri.SelectedItem.ToString().Contains("Décroissant"))
            {
                lesOeuvres = lesOeuvres.OeuvresDuType(leTypeOeuvre).TriDécroissant();
            }
            else if (ordreTri.SelectedItem.ToString().Contains("Type"))
            {
                lesOeuvres = lesOeuvres.OeuvresDuType(leTypeOeuvre).TriType();
            }
            else if (ordreTri.SelectedItem.ToString().Contains("Date"))
            {
                lesOeuvres = lesOeuvres.OeuvresDuType(leTypeOeuvre).TriDate();
            }
            else
            {
                lesOeuvres = lesOeuvres.OeuvresDuType(leTypeOeuvre).TriCroissant();
            }

            //Met à jour l'affichage
            Bibliothèque.LesOeuvres.Clear();
            lesOeuvres.ToList().ForEach(oeuvre => Bibliothèque.AjouterOeuvre(oeuvre));
            CocherSélectionnées();
        }
    }
}
