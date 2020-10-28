using Iut.MasterAnime.ClassLibrary;
using Iut.MasterAnime.Management;
using Iut.MasterAnime.Winapp.CodeModifierBibliothèque;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Iut.MasterAnime.Winapp.CodePagePrincipale
{
    /// <summary>
    /// Logique d'interaction pour PagePrincipale.xaml
    /// </summary>
    public partial class PagePrincipale : UserControl
    {
        /// <summary>
        /// Le manager étant dans l'App qui est ainsi le même pour toutes les vus
        /// </summary>
        public Manager Manager => (Application.Current as App).Manager;

        /// <summary>
        /// Dictionary contenant les user control pour l'affichage des oeuvres
        /// </summary>
        public Dictionary<string, UserControl> LesAffichages { get; set; } = new Dictionary<string, UserControl>()
        {
            ["Icône"] = new AfficheIcone(),
            ["Ligne"] = new AfficheLigne(),
        };

        /// <summary>
        /// Permet de définir si le mode sombre est activé ou non
        /// </summary>
        public bool ModeSombreActivé { get; set; } = false;

        /// <summary>
        /// Le constructeur de la classe du user control PagePrincipale
        /// </summary>
        public PagePrincipale()
        {
            InitializeComponent();

            AffichageOeuvres.Content = LesAffichages["Icône"];

            DataContext = this;

            TrierOeuvres();

            LaListeBibliothèque.ChangementBibliothèque += (sender, args) => TrierOeuvres();
        }

        /// <summary>
        /// Méthode permettant de naviguer vers la page des paramètres
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void Paramètres_Click(object sender, RoutedEventArgs e)
        {
            Navigateur.GetInstance().NaviguerVers(Navigateur.Paramètres_UC);
        }

        /// <summary>
        /// Méthode permettant de naviguer vers la page de recherche
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void Recherche_Click(object sender, RoutedEventArgs e)
        {
            Navigateur.GetInstance().NaviguerVers(Navigateur.Recherche_UC);
        }

        /// <summary>
        /// Permet de changer le type d'affichage des oeuvres
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void ChangementAffichageOeuvres(object sender, SelectionChangedEventArgs e)
        {
            if (AffichageOeuvres == null)
            {
                return;
            }
            
            var content = (e.AddedItems[0] as ListBoxItem).Content as string;

            AffichageOeuvres.Content = LesAffichages[content];

            //Pour le tri d'affichage
            TrierOeuvres();
        }

        /// <summary>
        /// Méthode permettant de trier les oeuvres affichées
        /// </summary>
        public void TrierOeuvres()
        {
            if (ordreTri == null || duType == null || AffichageOeuvres == null || Manager.BibliothèqueSélectionnée == null) return;

            TypeOeuvre leTypeOeuvre = TypeOeuvre.Tout;

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
                if (AffichageOeuvres.Content is AfficheIcone) (LesAffichages["Icône"] as AfficheIcone).OeuvresAffichées =
                        Manager.BibliothèqueSélectionnée.LesOeuvres.OeuvresDuType(leTypeOeuvre).TriDécroissant();
                if (AffichageOeuvres.Content is AfficheLigne) (LesAffichages["Ligne"] as AfficheLigne).OeuvresAffichées =
                        Manager.BibliothèqueSélectionnée.LesOeuvres.OeuvresDuType(leTypeOeuvre).TriDécroissant();
            }
            else if (ordreTri.SelectedItem.ToString().Contains("Type"))
            {
                if (AffichageOeuvres.Content is AfficheIcone) (LesAffichages["Icône"] as AfficheIcone).OeuvresAffichées =
                    Manager.BibliothèqueSélectionnée.LesOeuvres.OeuvresDuType(leTypeOeuvre).TriType();
                if (AffichageOeuvres.Content is AfficheLigne) (LesAffichages["Ligne"] as AfficheLigne).OeuvresAffichées =
                    Manager.BibliothèqueSélectionnée.LesOeuvres.OeuvresDuType(leTypeOeuvre).TriType();
            }
            else if (ordreTri.SelectedItem.ToString().Contains("Date"))
            {
                if (AffichageOeuvres.Content is AfficheIcone) (LesAffichages["Icône"] as AfficheIcone).OeuvresAffichées =
                      Manager.BibliothèqueSélectionnée.LesOeuvres.OeuvresDuType(leTypeOeuvre).TriDate();
                if (AffichageOeuvres.Content is AfficheLigne) (LesAffichages["Ligne"] as AfficheLigne).OeuvresAffichées =
                      Manager.BibliothèqueSélectionnée.LesOeuvres.OeuvresDuType(leTypeOeuvre).TriDate();
            }
            else
            {
                if (AffichageOeuvres.Content is AfficheIcone) (LesAffichages["Icône"] as AfficheIcone).OeuvresAffichées =
                        Manager.BibliothèqueSélectionnée.LesOeuvres.OeuvresDuType(leTypeOeuvre).TriCroissant();
                if (AffichageOeuvres.Content is AfficheLigne) (LesAffichages["Ligne"] as AfficheLigne).OeuvresAffichées =
                        Manager.BibliothèqueSélectionnée.LesOeuvres.OeuvresDuType(leTypeOeuvre).TriCroissant();
            }
        }

        /// <summary>
        /// Permet d'ouvrir la fenêtre de modification d'une bibliothèque
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void ModifierBibliothèque_Click(object sender, RoutedEventArgs e)
        {
            ModifierBibliothèque modifierBibliothèque = new ModifierBibliothèque();

            if(ModeSombreActivé)
            {
                modifierBibliothèque.Background = new SolidColorBrush(Color.FromRgb(51, 51, 51));
            }
            else
            {
                modifierBibliothèque.Background = Brushes.White;
            }

            modifierBibliothèque.ShowDialog();
        }

        /// <summary>
        /// Permet d'ouvrir la fenêtre proposant différentes manières d'ajouter une oeuvre à la biliothèque
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void AjouterOeuvre_Click(object sender, RoutedEventArgs e)
        {
            AjouterUneOeuvre ajouterUneOeuvre = new AjouterUneOeuvre();

            if(ModeSombreActivé)
            {
                ajouterUneOeuvre.Resources["CouleurTexte"] = Brushes.White;
                ajouterUneOeuvre.Background = new SolidColorBrush(Color.FromRgb(51, 51, 51));
            }
            else
            {
                ajouterUneOeuvre.Resources["CouleurTexte"] = Brushes.Black;
                ajouterUneOeuvre.Background = Brushes.White;
            }

            ajouterUneOeuvre.AnnulerClick += (sender, args) => ajouterUneOeuvre.Close();

            ajouterUneOeuvre.CréationOeuvreClick += (sender, args) => ajouterUneOeuvre.Close();
            ajouterUneOeuvre.CréationOeuvreClick += (sender, args) => Navigateur.GetInstance().NaviguerVers(Navigateur.CréationOeuvre_UC);

            ajouterUneOeuvre.SélectionOeuvresClick += (sender, args) => SélectionAjoutOeuvres(ajouterUneOeuvre);

            ajouterUneOeuvre.ShowDialog();
        }

        /// <summary>
        /// Permet de naviguer vers la page de sélection d'ajout d'oeuvres
        /// </summary>
        /// <param name="ajouterUneOeuvre"></param>
        public void SélectionAjoutOeuvres(AjouterUneOeuvre ajouterUneOeuvre)
        {
            //Si la bibliothèque sélectionnée est la liste principale
            if(Manager.BibliothèqueSélectionnée.Equals(Manager.ListePrincipale))
            {
                MessageBox.Show("La liste principale contient déjà toutes les oeurves de l'application.\n" +
                    "Créez une oeuvre si vous souhaitez lui en ajouter.", "Information", MessageBoxButton.OK);
                return;
            }

            Navigateur.GetInstance().NaviguerVers(Navigateur.SélectionAjoutOeuvresModification_UC);
            ajouterUneOeuvre.Close();
        }

        /// <summary>
        /// Permet de modifier l'ordre de trie de l'affichage
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void TriOeuvres_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TrierOeuvres();
        }
    }
}
