using Iut.MasterAnime.ClassLibrary;
using Iut.MasterAnime.Management;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Iut.MasterAnime.Winapp.CodeCréationBibliothèque
{
    /// <summary>
    /// Logique d'interaction pour CréationBibliothèque.xaml
    /// </summary>
    public partial class CréationBibliothèque : Window, INotifyPropertyChanged
    {
        /// <summary>
        /// Le manager étant dans l'App qui est ainsi le même pour toutes les vus
        /// </summary>
        public Manager Manager => (Application.Current as App).Manager;

        /// <summary>
        /// La nouvelle bibliothèque à créer
        /// </summary>
        public Bibliothèque NouvelleBibliothèque { get; set; } = new Bibliothèque("", "PlacerImage.png", new ObservableCollection<Oeuvre>());

        /// <summary>
        /// La collection des oeuvres à ajouter à la nouvelle bibliothèque
        /// </summary>
        public ObservableCollection<Oeuvre> AAjouter
        {
            get => àAjouter;
            private set
            {
                àAjouter = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Oeuvre> àAjouter = new ObservableCollection<Oeuvre>();

        /// <summary>
        /// Le constructeur de la classe du user control CréationBibliothèque
        /// </summary>
        public CréationBibliothèque()
        {
            InitializeComponent();

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
        /// Permet d'ouvrir une fenêtre de dialogue pour récupérer une image
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void Explorer_Click(object sender, RoutedEventArgs e)
        {
            String chemin = Utilitaires.ExplorateurImage();
            if (chemin != null)
            {
                NouvelleBibliothèque.Image = chemin;
            }
        }

        /// <summary>
        /// Permet de naviguer vers l'ancien user control
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Permet de créer la nouvelle bibliothèque et de l'ajouter au manager
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void Sauvegarder_Click(object sender, RoutedEventArgs e)
        {
            if(Validateur.BibliothèqueValidateur(NouvelleBibliothèque))
            {
                if(!Manager.AjouterBibliothèque(NouvelleBibliothèque))
                {
                    MessageBox.Show("Il existe déjà une liste avec ce nom.\nVeuillez en trouver un autre.", "Erreur", MessageBoxButton.OK);
                    return;
                }
                this.Close();
            } else
            {
                MessageBox.Show("Certains champs sont invialides", "Erreur", MessageBoxButton.OK);
            }
        }

        /// <summary>
        /// Permet de naviguer vers le user control de sélection d'oeuvres pour les ajouter à la nouvelle bibliothèque
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void AjoutOeuvres_Click(object sender, RoutedEventArgs e)
        {
            Navigateur.GetInstance().NaviguerVers(Navigateur.SélectionAjoutOeuvresCréation_UC);

            AAjouter = (Navigateur.GetInstance().UserControlSélectionné as SélectionAjoutOeuvresCréation).AAjouter;
            this.Hide();

            //Le désabonnement permet que les anciennes fenêtres ne soient pas appelées alors qu'elles ont déjà étaient fermées
            (Navigateur.GetInstance().UserControlSélectionné as SélectionAjoutOeuvresCréation).DésabonnementAjout();
            (Navigateur.GetInstance().UserControlSélectionné as SélectionAjoutOeuvresCréation).AjoutFini += (sender, args)
                => AAjouter.ToList().ForEach(oeuvre => NouvelleBibliothèque.AjouterOeuvre(oeuvre));
            (Navigateur.GetInstance().UserControlSélectionné as SélectionAjoutOeuvresCréation).AjoutFini += (sender, args) => this.ShowDialog();
        }
    }
}
