using Iut.MasterAnime.ClassLibrary;
using Iut.MasterAnime.Management;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Iut.MasterAnime.Winapp.CodeCréationOeuvre
{
    /// <summary>
    /// Logique d'interaction pour CréationOeuvre.xaml
    /// </summary>
    public partial class CréationOeuvre : UserControl, INotifyPropertyChanged
    {
        /// <summary>
        /// Le manager étant dans l'App qui est ainsi le même pour toutes les vus
        /// </summary>
        public Manager Manager => (Application.Current as App).Manager;

        /// <summary>
        /// La nouvelle oeuvre à créer
        /// </summary>
        public Oeuvre Oeuvre
        {
            get => oeuvre;
            private set
            {
                oeuvre = value;
                OnPropertyChanged();
            }
        }
        private Oeuvre oeuvre;

        /// <summary>
        /// Les bibliothèques où vont se trouver l'oeuvre
        /// </summary>
        protected List<Bibliothèque> AjouterA { get; set; } = new List<Bibliothèque>();

        /// <summary>
        /// Le dictionary de InformationsComplémentaires de l'oeuvre
        /// </summary>
        public ObservableDictionary<StringVérifié, StringVérifié> Dictionary
        {
            get => dictionary;
            set
            {
                dictionary.Clear();
                value.ToList().ForEach(kvp => dictionary.Add(kvp.Key, kvp.Value));
            }
        }
        private ObservableDictionary<StringVérifié, StringVérifié> dictionary = new ObservableDictionary<StringVérifié, StringVérifié>();

        /// <summary>
        /// Le constructeur de la classe du user control CréationOeuvre
        /// </summary>
        public CréationOeuvre()
        {
            InitializeComponent();

            CréerNouvelleOeuvre();

            DataContext = this;

            //Permet de notifier que la combobox a été générée
            AjoutABibliothèques.ItemContainerGenerator.StatusChanged += ItemContainerGenerator_StatusChanged;
            //Permet de notifier que la combobox a été chargée
            AjoutABibliothèques.Loaded += ItemContainerGenerator_StatusChanged;
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
        /// Permet de créer une nouvelle oeuvre suivant le type que l'utilisateur a sélectionné
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void Type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if((sender as ComboBox).SelectedItem == null)
            {
                return;
            }
            String type = (sender as ComboBox).SelectedItem.ToString();

            //On remet les informations de bases des informations complémentaires
            Dictionary.Clear();
            Dictionary.Add(new StringVérifié("Information 0"), new StringVérifié("L'information 0"));
            Dictionary.Add(new StringVérifié("Information 1"), new StringVérifié("L'information 1"));

            //On créer une nouvelle oeuvre suivant le type sélectionné
            switch (type)
            {
                case string a when a.Contains("Autre"):
                    Oeuvre = new Autre(Oeuvre.Nom, Oeuvre.Image, DateTime.Now, "", Dictionary, Oeuvre.Synopsis, Oeuvre.Commentaire);
                    break;
                case string a when a.Contains("Film"):
                    Oeuvre = new Film(Oeuvre.Nom, Oeuvre.Image, DateTime.Now, "", "", Dictionary, Oeuvre.Synopsis, Oeuvre.Commentaire);
                    break;
                case string a when a.Contains("Série"):
                    Oeuvre = new Série(Oeuvre.Nom, Oeuvre.Image, DateTime.Now, "", "", Dictionary, Oeuvre.Synopsis, Oeuvre.Commentaire);
                    break;
                case string a when a.Contains("Livre"):
                    Oeuvre = new Livre(Oeuvre.Nom, Oeuvre.Image, DateTime.Now, "", "", Dictionary, Oeuvre.Synopsis, Oeuvre.Commentaire);
                    break;
                case string a when a.Contains("Scan"):
                    Oeuvre = new Scan(Oeuvre.Nom, Oeuvre.Image, DateTime.Now, "", "", Dictionary, Oeuvre.Synopsis, Oeuvre.Commentaire);
                    break;
                case string a when a.Contains("Animé"):
                    Oeuvre = new Animé(Oeuvre.Nom, Oeuvre.Image, DateTime.Now, "", "", Dictionary, Oeuvre.Synopsis, Oeuvre.Commentaire);
                    break;
                default:
                    return;
            }
        }

        /// <summary>
        /// Permet d'ajouter des informations aux informations complémentaires de l'oeuvre
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void AjoutInfos_Click(object sender, RoutedEventArgs e)
        {
            int i = 0;
            while (Dictionary.Keys.Where(lesInfos => lesInfos.LeString.Equals($"Information {i}")).Count() > 0)
            {
                i++;
            }
            Dictionary.Add(new StringVérifié($"Information {i}"), new StringVérifié($"L'Information {i}"));
        }

        /// <summary>
        /// Permet d'ouvrir une boite de dialogue pour sélectionner une image pour l'oeuvre
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void Explorer_Click(object sender, RoutedEventArgs e)
        {
            String chemin = Utilitaires.ExplorateurImage();
            if (chemin != null)
            {
                Oeuvre.Image = chemin;
            }
        }

        /// <summary>
        /// Permet d'ajouter l'oeuvre créée au manager
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void Sauvegarder_Click(object sender, RoutedEventArgs e)
        {
            //Ce test est déjà fait dans le validateur, mais on le fait ici pour que l'utilisateur sache d'où vient le problème
            foreach (StringVérifié info in Oeuvre.InformationsComplémentaires.Keys)
            {
                if (Oeuvre.InformationsComplémentaires.ToList().Where(kvp => kvp.Key.LeString.Equals(info.LeString)).Count() > 1)
                {
                    MessageBox.Show("Les informations complémentaires ne peuvent avoir le même nom.\nVeuillez en modifier un.", "Erreur", MessageBoxButton.OK);
                    return;
                }
            }

            //On vérifie le contenu de l'oeuvre
            if(Validateur.OeuvreValidateur(Oeuvre))
            {
                //Si l'oeuvre n'existe pas déjà dans le manager
                if(!Manager.ListePrincipale.ContientOeuvre(Oeuvre))
                {
                    Manager.AjouterOeuvre(Oeuvre);
                    AjouterA.ForEach(biblio => biblio.AjouterOeuvre(Oeuvre));
                    Manager.SauvegarderLesDonnées();
                    Manager.OeuvreSélectionnée = Oeuvre;
                    Navigateur.GetInstance().NavigerVersAncien();
                    Navigateur.GetInstance().NaviguerVers(Navigateur.AffichageOeuvre_UC);
                } else
                {
                    MessageBox.Show("Cette oeuvre existe déjà.\nEssayez un autre nom ?", "Erreur", MessageBoxButton.OK);
                }
            } else
            {
                MessageBox.Show("Certains champs sont invialides", "Erreur", MessageBoxButton.OK);
            }
        }

        /// <summary>
        /// Permet de naviguer vers la page des paramètres
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void Paramètres_Click(object sender, RoutedEventArgs e)
        {
            Navigateur.GetInstance().NaviguerVers(Navigateur.Paramètres_UC);
        }

        /// <summary>
        /// Permet de naviguer vers l'ancien user control
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            Navigateur.GetInstance().NavigerVersAncien();
        }

        /// <summary>
        /// Permet de charger la combobox où les bibliothèques auxquelles ajouter l'oeuvre sont sélectionnées
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        void ItemContainerGenerator_StatusChanged(object sender, System.EventArgs e)
        {
            //Si la combobox a bien été générée
            if (AjoutABibliothèques.ItemContainerGenerator.Status == GeneratorStatus.ContainersGenerated)
            {
                //Si on n'est pas dans la ListePrincipale, car celle-ci possèdera obligatoirement l'oeuvre
                if (!Manager.BibliothèqueSélectionnée.Equals(Manager.ListePrincipale))
                {
                    //On ajoute la bibliothèque à AjouterA
                    if (!AjouterA.Contains(Manager.BibliothèqueSélectionnée)) AjouterA.Add(Manager.BibliothèqueSélectionnée);
                }

                foreach (var item in AjoutABibliothèques.Items)
                {
                    var container = (ComboBoxItem)AjoutABibliothèques.ItemContainerGenerator.ContainerFromItem(item);

                    if (container == null) return;

                    if (AjouterA.Contains(item as Bibliothèque))
                    {
                        //Si la bibliothèque est sélectionnée
                        container.Resources["LePackIcon"] = PackIconKind.CheckOutline;
                    }
                    else
                    {
                        //Si la bibliothèque n'est pas sélectionnée
                        container.Resources["LePackIcon"] = PackIconKind.Cancel;
                    }
                }
            }
        }

        /// <summary>
        /// Permet d'ajouter la bibliothèque sélectionnée et d'afficher sa sélection
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void AjoutABibliothèques_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Bibliothèque laBiblio;

            //Si on a une exception, on ne continue pas le programme. Ceci se produit notamment quand on met le selectedIndex à -1, ce qui re-appelle cette fonction
            try
            {
                laBiblio = e.AddedItems[0] as Bibliothèque;
            }
            catch (Exception)
            {
                return;
            }

            //On récupère le comboboxItem contenant la bibliothèque sélectionnée
            var container = (ComboBoxItem)AjoutABibliothèques.ItemContainerGenerator.ContainerFromItem(laBiblio);

            //Si la bibliothèque été déjà sélectionnée
            if (AjouterA.Contains(laBiblio))
            {
                //On la retire, et on affiche qu'elle ne l'est plus
                AjouterA.Remove(laBiblio);
                container.Resources["LePackIcon"] = PackIconKind.Cancel;
            }
            //Si la bibliothèque n'était pas sélectionnée
            else
            {
                //On l'ajouter à AjouterA et on affiche sa sélection
                AjouterA.Add(laBiblio);
                container.Resources["LePackIcon"] = PackIconKind.CheckOutline;
            }

            //On déselectionne l'item pour afficher "Ajouter à" et non la bibliothèque sélectionnée précédemment
            (sender as ComboBox).SelectedIndex = -1;
        }

        /// <summary>
        /// Permet de réinitialiser l'affichage complet ainsi que l'oeuvre
        /// </summary>
        public void CréerNouvelleOeuvre()
        {
            AjouterA.Clear();
            Dictionary.Clear();
            Dictionary.Add(new StringVérifié("Information 0"), new StringVérifié("L'information 0"));
            Dictionary.Add(new StringVérifié("Information 1"), new StringVérifié("L'information 1"));
            Oeuvre = new Autre("", "", DateTime.Now, "", Dictionary, "", "");
        }
    }
}
