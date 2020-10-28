using Iut.MasterAnime.ClassLibrary;
using Iut.MasterAnime.Management;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Iut.MasterAnime.Winapp.CodePageRecherche
{
    /// <summary>
    /// Logique d'interaction pour PageRecherche.xaml
    /// </summary>
    public partial class PageRecherche : UserControl, INotifyPropertyChanged
    {
        /// <summary>
        /// Le manager étant dans l'App qui est ainsi le même pour toutes les vus
        /// </summary>
        public Manager Manager => (Application.Current as App).Manager;

        /// <summary>
        /// La bibliothèque dans laquelle on recherche les oeuvres
        /// </summary>
        public Bibliothèque BibliothèqueRecherche { get; set; } = (Application.Current as App).Manager.ListePrincipale;

        /// <summary>
        /// Les caractètres que le nom de l'oeuvre doit posséder dans la recherche
        /// </summary>
        public string CharNom { get; set; } = null;

        /// <summary>
        /// Le type de l'oeuvre que la recherche doit rendre
        /// </summary>
        public TypeOeuvre TypeDeLOeuvre { get; set; } = TypeOeuvre.Tout;

        /// <summary>
        /// La date de l'oeuvre à rechercher
        /// </summary>
        public DateTime DateTimeDeLOeuvre
        {
            get => dateTimeDeLOeuvre;
            set
            {
                dateTimeDeLOeuvre = value;
                OnPropertyChanged();
            }
        }
        private DateTime dateTimeDeLOeuvre = DateTime.Today;

        /// <summary>
        /// Le référentiel par rapport à la date que la recherche doit prendre
        /// </summary>
        public DateQuand DateQuandDeLOeuvre { get; set; } = DateQuand.NonUtilisé;

        /// <summary>
        /// Les caractères que l'auteur, le réalisateur ou encore le créateur doivent posséder dans la recherche
        /// </summary>
        public string AuteurRéalisateur { get; set; } = null;

        /// <summary>
        /// Les caractères que le sutdio ou l'éditeur doivent posséder dans la recherche
        /// </summary>
        public string StudioÉditeur { get; set; } = null;

        /// <summary>
        /// Un mot clé que l'oeuvre doit posséder dans ses informations complémentaires, synopsis ou encore dans le commentaire
        /// </summary>
        public string MotClé1 { get; set; } = null;

        /// <summary>
        /// Un mot clé que l'oeuvre doit posséder dans ses informations complémentaires, synopsis ou encore dans le commentaire
        /// </summary>
        public string MotClé2 { get; set; } = null;

        /// <summary>
        /// Un mot clé que l'oeuvre doit posséder dans ses informations complémentaires, synopsis ou encore dans le commentaire
        /// </summary>
        public string MotClé3 { get; set; } = null;

        /// <summary>
        /// L'ordre dans lequelle la recherche va afficher les oeuvres trouvées
        /// </summary>
        public OrdreTri OrdreDuTri { get; set; } = OrdreTri.Croissant;

        /// <summary>
        /// Dictionary possédant les user control des affichages de la recherche
        /// </summary>
        Dictionary<string, UserControl> LesAffichages { get; set; } = new Dictionary<string, UserControl>()
        {
            ["Icône"] = new AfficheIconeRecherche(),
            ["Ligne"] = new AfficheLigneRecherche(),
            ["NonTrouvées"] = new AucuneOeuvreTrouvée(),
        };

        /// <summary>
        /// Le constructeur de la classe du user control PageRecherche
        /// </summary>
        public PageRecherche()
        {
            InitializeComponent();

            NaviguerVers("Icône");

            DésactivationModeSombre();

            DataContext = this;
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
        /// Permet de lancer le changement d'affichage suivant la sélection de l'utilisateur
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void ChangementAffichageOeuvres(object sender, SelectionChangedEventArgs e)
        {
            var content = (e.AddedItems[0] as ListBoxItem).Content as string;

            NaviguerVers(content);
        }

        /// <summary>
        /// Méthode permettant de naviguer vers la page des paramètres
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            Navigateur.GetInstance().NavigerVersAncien();
        }

        /// <summary>
        /// Méthode permettant de naviguer vers l'ancien user control
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void Paramètres_Click(object sender, RoutedEventArgs e)
        {
            Navigateur.GetInstance().NaviguerVers(Navigateur.Paramètres_UC);
        }

        /// <summary>
        /// Permet changer l'ordre d'affichage des oeuvres trouvées
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void Ordre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var content = (e.AddedItems[0] as ListBoxItem)?.Content as string;

            //De base on le met à croissant
            OrdreDuTri = OrdreTri.Croissant;
            if (content == "Décroissant") OrdreDuTri = OrdreTri.Décroissant;
            if (content == "Type") OrdreDuTri = OrdreTri.Type;
            if (content == "Date de sortie") OrdreDuTri = OrdreTri.Date_de_sortie;

            NaviguerVers(null);
        }

        /// <summary>
        /// Permet de changer le type des oeuvres à rechercher
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void Type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var content = (e.AddedItems[0] as ListBoxItem)?.Content as string;

            TypeDeLOeuvre = TypeOeuvre.Tout;
            if (content == "Film") TypeDeLOeuvre = TypeOeuvre.Film;
            if (content == "Série") TypeDeLOeuvre = TypeOeuvre.Série;
            if (content == "Livre") TypeDeLOeuvre = TypeOeuvre.Livre;
            if (content == "Scan") TypeDeLOeuvre = TypeOeuvre.Scan;
            if (content == "Animé") TypeDeLOeuvre = TypeOeuvre.Animé;
            if (content == "Autre") TypeDeLOeuvre = TypeOeuvre.Autre;

            NaviguerVers(null);
        }

        /// <summary>
        /// Permet de changer la biliothèque dans laquelle on fait la recherche
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void Bibliothèque_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                BibliothèqueRecherche = (e.AddedItems[0] as Bibliothèque);
            } catch (Exception)
            {
                BibliothèqueRecherche = Manager.ListePrincipale;
            }

            NaviguerVers(null);
        }

        /// <summary>
        /// Permet de changer la date de la recherche
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var content = (sender as DatePicker)?.SelectedDate;

            DateTimeDeLOeuvre = content.Value;

            NaviguerVers(null);
        }

        /// <summary>
        /// Permet de modifier le référentiel par rapport à la date que la recherche va prendre
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void RéférentielDate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var content = (e.AddedItems[0] as ListBoxItem)?.Content as String;

            DateQuandDeLOeuvre = DateQuand.NonUtilisé;
            if (content == "Après") DateQuandDeLOeuvre = DateQuand.Après;
            if (content == "Pendant") DateQuandDeLOeuvre = DateQuand.Pendant;
            if (content == "Avant") DateQuandDeLOeuvre = DateQuand.Avant;

            NaviguerVers(null);
        }

        /// <summary>
        /// Permet de notifier la vue que les textbox ont de nouvelles valeurs
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Si on remet la textBox vide, ou si il y a au moins 4 caractères
            //(Le fait de relancer la recherche lorsque la textBox est vide permet un affichage plus fluide (plus sympa à utiliser), mais si notre 
            //persistance comportait beaucoup de données, on enlèverai ceci pour de meilleurs performances)
            if (string.IsNullOrEmpty((sender as TextBox)?.Text) || (sender as TextBox).Text.Count() > 3)
            {
                NaviguerVers(null);
            }
        }

        /// <summary>
        /// Permet de lancer la recherche
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void Recherche_Click(object sender, RoutedEventArgs e)
        {
            NaviguerVers(null);
        }

        /// <summary>
        /// Permet de naviguer vers la page de création d'oeuvre
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void AjoutOeuvre_Click(object sender, RoutedEventArgs e)
        {
            Navigateur.GetInstance().NaviguerVers(Navigateur.CréationOeuvre_UC);
        }

        /// <summary>
        /// Permet de réinitialiser les valeurs de la recherche ainsi que la vue
        /// </summary>
        public void RéinitialiserVue()
        {
            LeType.SelectedIndex = 0;
            TypeDeLOeuvre = TypeOeuvre.Tout;
            DateTimeDeLOeuvre = DateTime.Today;
            RéférentielDate.SelectedIndex = 0;
            DateQuandDeLOeuvre = DateQuand.NonUtilisé;
            AuteurRéa.Text = null;
            StudioÉdit.Text = null;
            Mot1.Text = null;
            Mot2.Text = null;
            Mot3.Text = null;
            NaviguerVers(null);
        }

        /// <summary>
        /// Permet de lancer la recherche et de la renvoyer
        /// </summary>
        /// <returns>les oeuvres trouvées et triées lors de la recherche</returns>
        private ObservableCollection<Oeuvre> LaRecherche()
        {
            var recherche = BibliothèqueRecherche?.RechercherOeuvre(CharNom, TypeDeLOeuvre, DateTimeDeLOeuvre, DateQuandDeLOeuvre, AuteurRéalisateur,
                StudioÉditeur, MotClé1, MotClé2, MotClé3);

            if (OrdreDuTri == OrdreTri.Décroissant) return Tri.TriDécroissant(recherche);
            if (OrdreDuTri == OrdreTri.Date_de_sortie) return Tri.TriDate(recherche);
            if (OrdreDuTri == OrdreTri.Type) return Tri.TriType(recherche);

            return Tri.TriCroissant(recherche);
        }

        /// <summary>
        /// Permet de changer l'affichage de la recherche ou de recharger cette dernière pour afficher correctement les oeuvres trouvées
        /// </summary>
        /// <param name="content">Le nom de l'affichage à mettre. Null si l'affichage ne doit pas changer, mais met à jour ce dernier</param>
        public void NaviguerVers(string content)
        {
            if (AffichageOeuvres == null)
            {
                return;
            }

            (LesAffichages["Icône"] as AfficheIconeRecherche).Recherche = LaRecherche();
            (LesAffichages["Ligne"] as AfficheLigneRecherche).Recherche = LaRecherche();

            if (LaRecherche()?.Count < 1)
            {
                AffichageOeuvres.Content = LesAffichages["NonTrouvées"];
                return;
            }

            //Mettre la valeur content à null permet juste de mettre à jour l'affichage des oeuvres, et si aucune oeuvre n'a été trouvée
            if (content != null)
            {
                AffichageOeuvres.Content = LesAffichages[content];
            }
            else
            {
                if ((bool)typeAffichage?.SelectedItem.ToString().Contains("Icône"))
                {
                    AffichageOeuvres.Content = LesAffichages["Icône"];
                }
                else
                {
                    AffichageOeuvres.Content = LesAffichages["Ligne"];
                }
            }
        }

        /// <summary>
        /// Permet d'activer le mode sombre
        /// </summary>
        public void ActivationModeSombre()
        {
            (LesAffichages["Icône"] as AfficheIconeRecherche).Resources["CouleurDeFond"] = new SolidColorBrush(Color.FromRgb(51, 51, 51));
            (LesAffichages["Icône"] as AfficheIconeRecherche).Resources["CouleurTexte"] = Brushes.White;

            (LesAffichages["Ligne"] as AfficheLigneRecherche).Resources["CouleurDeFond"] = new SolidColorBrush(Color.FromRgb(51, 51, 51));
            (LesAffichages["Ligne"] as AfficheLigneRecherche).Resources["CouleurTexte"] = Brushes.White;

            (LesAffichages["NonTrouvées"] as AucuneOeuvreTrouvée).Resources["CouleurTexte"] = Brushes.White;
        }

        /// <summary>
        /// Permet de désactiver le mode sombre
        /// </summary>
        public void DésactivationModeSombre()
        {
            (LesAffichages["Icône"] as AfficheIconeRecherche).Resources["CouleurDeFond"] = Brushes.White;
            (LesAffichages["Icône"] as AfficheIconeRecherche).Resources["CouleurTexte"] = Brushes.Black;

            (LesAffichages["Ligne"] as AfficheLigneRecherche).Resources["CouleurDeFond"] = Brushes.White;
            (LesAffichages["Ligne"] as AfficheLigneRecherche).Resources["CouleurTexte"] = Brushes.Black;

            (LesAffichages["NonTrouvées"] as AucuneOeuvreTrouvée).Resources["CouleurTexte"] = Brushes.Black;
        }
    }
}
