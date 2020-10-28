using Iut.MasterAnime.ClassLibrary;
using Iut.MasterAnime.Management;
using Iut.MasterAnime.Winapp.CodePagePrincipale;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Iut.MasterAnime.Winapp.CodeModifierBibliothèque
{
    /// <summary>
    /// Logique d'interaction pour SélectionAjoutOeuvresModification.xaml
    /// </summary>
    public partial class SélectionAjoutOeuvresModification : UserControl, INotifyPropertyChanged
    {
        /// <summary>
        /// Le manager étant dans l'App qui est ainsi le même pour toutes les vus
        /// </summary>
        public Manager Manager => (Application.Current as App).Manager;

        /// <summary>
        /// Une bibliothèque quelconque permettant de contenir les oeuvres à afficher. Ceci permet à la vue d'être correctement notifiée de tout changement
        /// </summary>
        public Bibliothèque Bibliothèque { get; private set; } = new Bibliothèque("--", "--", new ObservableCollection<Oeuvre>());

        /// <summary>
        /// Les oeuvres à afficher, ceux-sont toutes celles de l'application n'étant pas présentes dans la bibliothèque sélectionnée
        /// </summary>
        private List<Oeuvre> DesOeuvres
        {
            get
            {
                return desOeuvres;
            }
            set
            {
                desOeuvres.Clear();
                value.ToList().ForEach(oeuvre => desOeuvres.Add(oeuvre));
            }
        }
        private List<Oeuvre> desOeuvres = new List<Oeuvre>();

        /// <summary>
        /// Les oeuvres sélectionnées pour être ajoutées à la bibliothèque
        /// </summary>
        public List<Oeuvre> AAjouter { get; private set; } = new List<Oeuvre>();

        /// <summary>
        /// Le constructeur de la classe du user control SélectionAjoutOeuvresModification
        /// </summary>
        public SélectionAjoutOeuvresModification()
        {
            InitializeComponent();

            DataContext = this;

            SetOeuvres();
        }

        /// <summary>
        /// Un événement notifiant qu'une propriété a été changée
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Permet d'appeler l'événement pour notifier qu'une propriété a été modifiée
        /// </summary>
        /// <param name="propertyName">Le nom de la propriété modifiée</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(sender: this, e: new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Permet d'ajouter ou retirer une oeuvre de AjouterA, ainsi que de modifier l'affichage suivant si l'utilisateur l'a sélectionnée ou non
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

                //Permet de récupérer le nom de l'oeuvre
                TextBlock leTextBlock = (TextBlock)(sender as Button).FindName("leTextBlock");

                AAjouter.Add(DesOeuvres.Where(oeuvre => oeuvre.Nom.Equals(leTextBlock.Text as String)).FirstOrDefault());
            }
            //Si l'oeuvre était déjà sélectionnée
            else
            {
                (sender as Button).BorderBrush = Brushes.LightGray;

                PackIcon lIcone = (PackIcon)(sender as Button).FindName("lIcone");

                lIcone.Kind = PackIconKind.CircleOutline;
                lIcone.Foreground = Brushes.LightGray;

                //Permet de récupérer le nom de l'oeuvre
                TextBlock leTextBlock = (TextBlock)(sender as Button).FindName("leTextBlock");

                AAjouter.Remove(DesOeuvres.Where(oeuvre => oeuvre.Nom.Equals(leTextBlock.Text as String)).FirstOrDefault());
            }
        }

        /// <summary>
        /// Permet de sélectionner toutes les oeuvres, et donc de les ajouter à AjouterA
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void ToutCocher_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < lItemsControl.Items.Count; i++)
            {
                ContentPresenter contentPresenter = (ContentPresenter)lItemsControl.ItemContainerGenerator.ContainerFromItem(DesOeuvres.ElementAt(i));

                Button leBouton = contentPresenter.ContentTemplate.FindName("leBoutonOeuvre", contentPresenter) as Button;
                PackIcon lIcone = contentPresenter.ContentTemplate.FindName("lIcone", contentPresenter) as PackIcon;

                leBouton.BorderBrush = new SolidColorBrush(Color.FromRgb(43, 120, 228));
                lIcone.Kind = PackIconKind.TickCircleOutline;
                lIcone.Foreground = new SolidColorBrush(Color.FromRgb(43, 120, 228));
            }
            AAjouter.AddRange(DesOeuvres);
        }

        /// <summary>
        /// Permet de désélectionner toutes les oeuvres, et donc de les retirer de AjouterA
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void ToutDécocher_Click(object sender, RoutedEventArgs e)
        {
            ToutDécocher();
        }

        /// <summary>
        /// Permet de naviguer vers l'ancien user control sans ajouter les oeuvres sélectionnées
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            Navigateur.GetInstance().NavigerVersAncien();
        }

        /// <summary>
        /// Permet de naviguer vers l'ancien user control et d'ajouter les oeuvres sélectionnées à la bibliothèque
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            AAjouter.ForEach(oeuvre => Manager.BibliothèqueSélectionnée.AjouterOeuvre(oeuvre));
            Manager.SauvegarderLesDonnées();
            (Navigateur.GetInstance().ObtenirUserControl(Navigateur.PagePrincipale_UC) as PagePrincipale).TrierOeuvres();
            Navigateur.GetInstance().NavigerVersAncien();
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
        /// Permet de définir les oeuvres qui seront présentes dans l'affichage, étant donnée que les oeuvres déjà présentes dans la bibliothèque ne seront pas affichées
        /// </summary>
        public void SetOeuvres()
        {
            DesOeuvres = (Manager.ListePrincipale.LesOeuvres.ToList());
            Manager.BibliothèqueSélectionnée.LesOeuvres.ToList().ForEach(oeuvre => DesOeuvres.Remove(oeuvre));
            Bibliothèque.LesOeuvres.Clear();
            DesOeuvres.ForEach(oeuvre => Bibliothèque.AjouterOeuvre(oeuvre));
            TrierOeuvres();
        }

        /// <summary>
        /// Permet de décocher toutes les oeuvres sélectionnées, et donc les retirer de AjouterA
        /// </summary>
        public void ToutDécocher()
        {
            for (int i = 0; i < lItemsControl.Items.Count; i++)
            {
                ContentPresenter contentPresenter = (ContentPresenter)lItemsControl.ItemContainerGenerator.ContainerFromItem(DesOeuvres.ElementAt(i));

                Button leBouton = contentPresenter.ContentTemplate.FindName("leBoutonOeuvre", contentPresenter) as Button;
                PackIcon lIcone = contentPresenter.ContentTemplate.FindName("lIcone", contentPresenter) as PackIcon;

                leBouton.BorderBrush = Brushes.LightGray;
                lIcone.Kind = PackIconKind.CircleOutline;
                lIcone.Foreground = Brushes.LightGray;
            }
            AAjouter.Clear();
        }

        /// <summary>
        /// Permet de cocher toutes les oeuvres présentes dans AjouterA
        /// </summary>
        public void CocherSélectionnées()
        {
            for (int i = 0; i < AAjouter.Count; i++)
            {
                ContentPresenter contentPresenter = (ContentPresenter)lItemsControl.ItemContainerGenerator.ContainerFromItem(AAjouter.ElementAt(i));
                
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
            DesOeuvres.ForEach(oeuvre => lesOeuvres.Add(oeuvre));

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
