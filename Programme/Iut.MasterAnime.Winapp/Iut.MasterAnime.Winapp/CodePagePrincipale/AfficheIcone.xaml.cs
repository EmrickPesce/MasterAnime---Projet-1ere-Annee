using Iut.MasterAnime.ClassLibrary;
using Iut.MasterAnime.Management;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace Iut.MasterAnime.Winapp.CodePagePrincipale
{
    /// <summary>
    /// Logique d'interaction pour AfficheIcone.xaml
    /// </summary>
    public partial class AfficheIcone : UserControl, INotifyPropertyChanged
    {
        /// <summary>
        /// Le manager étant dans l'App qui est ainsi le même pour toutes les vus
        /// </summary>
        public Manager Manager => (Application.Current as App).Manager;

        /// <summary>
        /// Les oeuvres qui seront affichées
        /// </summary>
        public ObservableCollection<Oeuvre> OeuvresAffichées
        {
            get => oeuvresAffichées;
            set
            {
                oeuvresAffichées = value;
                OnPropertyChanged();
            }
        }
        ObservableCollection<Oeuvre> oeuvresAffichées;

        /// <summary>
        /// Le constructeur de la classe du user control AfficheIcone
        /// </summary>
        public AfficheIcone()
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
        /// Permet de sélectionner une oeuvre et de naviguer vers celle-ci
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void BouttonOeuvre_Click(object sender, RoutedEventArgs e)
        {
            Navigateur navigateur = Navigateur.GetInstance();

            Manager.OeuvreSélectionnée = Manager.BibliothèqueSélectionnée.ObtenirOeuvre(((sender as Button).Tag.ToString()));
            navigateur.NaviguerVers(Navigateur.AffichageOeuvre_UC);
        }
    }
}
