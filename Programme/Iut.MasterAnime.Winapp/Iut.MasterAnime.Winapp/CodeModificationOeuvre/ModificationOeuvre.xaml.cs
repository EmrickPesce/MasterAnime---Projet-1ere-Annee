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

namespace Iut.MasterAnime.Winapp.CodeModificationOeuvre
{
    /// <summary>
    /// Logique d'interaction pour ModificationOeuvre.xaml
    /// </summary>
    public partial class ModificationOeuvre : UserControl, INotifyPropertyChanged
    {
        /// <summary>
        /// Le manager étant dans l'App qui est ainsi le même pour toutes les vus
        /// </summary>
        public Manager Manager => (Application.Current as App).Manager;

        /// <summary>
        /// Une nouvelle instance de l'oeuvre à modifier afin de pouvoir annuler les modifications
        /// </summary>
        public Oeuvre Oeuvre
        {
            get => oeuvre;
            set
            {
                oeuvre = value;
                OnPropertyChanged();
            }
        }
        private Oeuvre oeuvre;

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
        /// Les bibliothèques où on ajoutera l'oeuvre
        /// </summary>
        protected List<Bibliothèque> AjouterA { get; set; } = new List<Bibliothèque>();

        /// <summary>
        /// Les bibliothèques où on retirera l'oeuvre
        /// </summary>
        protected List<Bibliothèque> RetirerDe { get; set; } = new List<Bibliothèque>();

        /// <summary>
        /// Le constructeur de la classe du user control ModificationOeuvre
        /// </summary>
        public ModificationOeuvre()
        {
            InitializeComponent();

            ChargerOeuvre();

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
        /// Permet d'ajouter des informations aux informations complémentaires de l'oeuvre
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void AjoutInfos_Click(object sender, RoutedEventArgs e)
        {
            int i = 0;
            while (Dictionary.ContainsKey(new StringVérifié($"Information {i}")))
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
        /// Permet de supprimer l'oeuvre de la bibliothèque sélectionnée
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cette oeuvre ?", "Attention", MessageBoxButton.YesNo,
                MessageBoxImage.Exclamation, MessageBoxResult.No);

            if(result == MessageBoxResult.Yes)
            {
                //Si l'oeuvre se truve dans la liste principale
                if(Manager.BibliothèqueSélectionnée.Nom.Equals(Manager.ListePrincipale.Nom))
                {
                    Manager.RetirerOeuvre(Manager.OeuvreSélectionnée);
                }
                //Si l'oeuvre se trouve dans une bibliothèque autre que la liste principale
                else
                {
                    Manager.BibliothèqueSélectionnée.RetirerOeuvre(Manager.OeuvreSélectionnée);
                    Manager.SauvegarderLesDonnées();
                }
                Navigateur.GetInstance().NavigerVersAncien();
                Navigateur.GetInstance().NavigerVersAncien();
            }
        }

        /// <summary>
        /// Permet de sauvegarder les modifications de l'oeuvre
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void Sauvegarder_Click(object sender, RoutedEventArgs e)
        {
            if (Oeuvre is Autre)
            {
                if (String.IsNullOrEmpty((Oeuvre as Autre).Créateur)) (Oeuvre as Autre).Créateur = "Inconnu";
            }
            else if (Oeuvre is Cinématographique)
            {
                if (String.IsNullOrEmpty((Oeuvre as Cinématographique).Réalisateur)) (Oeuvre as Cinématographique).Réalisateur = "Inconnu";
                if (String.IsNullOrEmpty((Oeuvre as Cinématographique).Studio)) (Oeuvre as Cinématographique).Studio = "Inconnu";
            }
            else if (Oeuvre is Littéraire)
            {
                if (String.IsNullOrEmpty((Oeuvre as Littéraire).Auteur)) (Oeuvre as Littéraire).Auteur = "Inconnu";
                if (String.IsNullOrEmpty((Oeuvre as Littéraire).Éditeur)) (Oeuvre as Littéraire).Éditeur = "Inconnu";
            }
            else if (Oeuvre is Animé)
            {
                if (String.IsNullOrEmpty((Oeuvre as Animé).Auteur)) (Oeuvre as Animé).Auteur = "Inconnu";
                if (String.IsNullOrEmpty((Oeuvre as Animé).Studio)) (Oeuvre as Animé).Studio = "Inconnu";
            }

            //Ce test est déjà fait dans le validateur, mais on le fait ici pour que l'utilisateur sache d'où vient le problème
            foreach(StringVérifié info in Oeuvre.InformationsComplémentaires.Keys)
            {
                if(Oeuvre.InformationsComplémentaires.ToList().Where(kvp => kvp.Key.LeString.Equals(info.LeString)).Count() > 1)
                {
                    MessageBox.Show("Les informations complémentaires ne peuvent avoir le même nom.\nVeuillez en modifier un.", "Erreur", MessageBoxButton.OK);
                    return;
                }
            }

            if (Validateur.OeuvreValidateur(Oeuvre))
            {
                //Si une oeuvre autre que celle-ci ne possède pas déjà ce nom dans le manager
                if (Manager.ListePrincipale.LesOeuvres.Where(uneOeuvre => uneOeuvre.Nom.Equals(Oeuvre.Nom)).Count() == 1)
                {
                    Manager.ModifierOeuvre(Manager.OeuvreSélectionnée.Nom, Oeuvre);
                    AjouterA.ForEach(biblio => biblio.AjouterOeuvre(Manager.OeuvreSélectionnée));
                    RetirerDe.ForEach(biblio => biblio.RetirerOeuvre(Manager.OeuvreSélectionnée));
                    Manager.SauvegarderLesDonnées();
                    Navigateur.GetInstance().NavigerVersAncien();
                }
                else
                {
                    MessageBox.Show("Une oeuvre contient déjà ce nom.\nVeuillez en trouver un autre.", "Erreur", MessageBoxButton.OK);
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
        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            Navigateur.GetInstance().NavigerVersAncien();
        }

        /// <summary>
        /// Permet d'ajouter la bibliothèque sélectionnée et d'afficher sa sélection
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void AjoutABibliothèques_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Bibliothèque laBiblio;
            //Si on a une exception, on ne continue pas le programme. Ceci se produit notamment quand on met le selectedIndex à -1
            try
            {
                laBiblio = e.AddedItems[0] as Bibliothèque;
            } catch (Exception)
            {
                return;
            }


            var container = (ComboBoxItem)AjoutABibliothèques.ItemContainerGenerator.ContainerFromItem(laBiblio);

            if (laBiblio.ContientOeuvre(Manager.OeuvreSélectionnée))
            {
                if(RetirerDe.Contains(laBiblio))
                {
                    RetirerDe.Remove(laBiblio);
                    container.Resources["LePackIcon"] = PackIconKind.CheckOutline;
                } else
                {
                    RetirerDe.Add(laBiblio);
                    container.Resources["LePackIcon"] = PackIconKind.Cancel;
                }
            } else
            {
                if (AjouterA.Contains(laBiblio))
                {
                    AjouterA.Remove(laBiblio);
                    container.Resources["LePackIcon"] = PackIconKind.Cancel;
                }
                else
                {
                    AjouterA.Add(laBiblio);
                    container.Resources["LePackIcon"] = PackIconKind.CheckOutline;
                }
            }
            //On déselectionne l'item pour afficher "Ajouter à" et non la bibliothèque sélectionnée précédemment
            (sender as ComboBox).SelectedIndex = -1;
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
                foreach (var item in AjoutABibliothèques.Items)
                {
                    var container = (ComboBoxItem)AjoutABibliothèques.ItemContainerGenerator.ContainerFromItem(item);

                    if (container == null) return;

                    //Si la bibliothèqe possède cette oeuvre
                    if ((item as Bibliothèque).ContientOeuvre(Manager.OeuvreSélectionnée))
                    {
                        //Si on doit retirer l'oeuvre de la bibliothèque
                        if (RetirerDe.Contains(item as Bibliothèque))
                        {
                            container.Resources["LePackIcon"] = PackIconKind.Cancel;
                        }
                        else
                        {
                            container.Resources["LePackIcon"] = PackIconKind.CheckOutline;
                            AjouterA.Add((Bibliothèque)item);
                        }
                    } else
                    {
                        //Si on doit ajouter l'oeuvre à la bibliothèque
                        if (AjouterA.Contains((Bibliothèque)item))
                        {
                            container.Resources["LePackIcon"] = PackIconKind.CheckOutline;
                        }
                        else
                        {
                            container.Resources["LePackIcon"] = PackIconKind.Cancel;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Permet de charger la vue et le code avec l'oeuvre sélectionnée
        /// </summary>
        public void ChargerOeuvre()
        {
            Oeuvre oeuvreCourante = Manager.OeuvreSélectionnée;
            if (oeuvreCourante == null) return;
            Oeuvre oeuvreEnChargement;

            //Réinitliase l'ajout ou la suppression de l'oeuvre à une bibliothèque
            AjouterA.Clear();
            RetirerDe.Clear();

            Dictionary = oeuvreCourante.InformationsComplémentaires;

            //Charge l'oeuvre suivant son type
            if (oeuvreCourante is Autre)
            {
                Autre autreCourant = (oeuvreCourante as Autre);
                oeuvreEnChargement = new Autre(autreCourant.Nom, autreCourant.Image, autreCourant.Sortie, autreCourant.Créateur, Dictionary,
                    autreCourant.Synopsis, autreCourant.Commentaire);
            }
            else if (oeuvreCourante is Film)
            {
                Film filmCourant = (oeuvreCourante as Film);
                oeuvreEnChargement = new Film(filmCourant.Nom, filmCourant.Image, filmCourant.Sortie, filmCourant.Réalisateur, filmCourant.Studio,
                    Dictionary, filmCourant.Synopsis, filmCourant.Commentaire);
            }
            else if (oeuvreCourante is Série)
            {
                Série sérieCourant = (oeuvreCourante as Série);
                oeuvreEnChargement = new Série(sérieCourant.Nom, sérieCourant.Image, sérieCourant.Sortie, sérieCourant.Réalisateur, sérieCourant.Studio,
                    Dictionary, sérieCourant.Synopsis, sérieCourant.Commentaire);
            }
            else if (oeuvreCourante is Livre)
            {
                Livre LivreCourant = (oeuvreCourante as Livre);
                oeuvreEnChargement = new Livre(LivreCourant.Nom, LivreCourant.Image, LivreCourant.Sortie, LivreCourant.Auteur, LivreCourant.Éditeur,
                    Dictionary, LivreCourant.Synopsis, LivreCourant.Commentaire);
            }
            else if (oeuvreCourante is Scan)
            {
                Scan scanCourant = (oeuvreCourante as Scan);
                oeuvreEnChargement = new Scan(scanCourant.Nom, scanCourant.Image, scanCourant.Sortie, scanCourant.Auteur, scanCourant.Éditeur,
                    Dictionary, scanCourant.Synopsis, scanCourant.Commentaire);
            }
            else if (oeuvreCourante is Animé)
            {
                Animé animéCourant = (oeuvreCourante as Animé);
                oeuvreEnChargement = new Animé(animéCourant.Nom, animéCourant.Image, animéCourant.Sortie, animéCourant.Auteur, animéCourant.Studio,
                    Dictionary, animéCourant.Synopsis, animéCourant.Commentaire);
            }
            else return;
            Oeuvre = oeuvreEnChargement;
        }
    }
}
