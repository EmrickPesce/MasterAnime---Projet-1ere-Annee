using Iut.MasterAnime.Management;
using System.Windows;
using System.Windows.Controls;

namespace Iut.MasterAnime.Winapp.CodeAffichageOeuvre
{
    /// <summary>
    /// Logique d'interaction pour AffichageOeuvre.xaml
    /// </summary>
    public partial class AffichageOeuvre : UserControl
    {
        /// <summary>
        /// Le manager étant dans l'App qui est ainsi le même pour toutes les vus
        /// </summary>
        public Manager Manager => (Application.Current as App).Manager;

        /// <summary>
        /// Le constructeur de la classe du user control AffichageOeuvre
        /// </summary>
        public AffichageOeuvre()
        {
            InitializeComponent();

            DataContext = this;
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
        /// Méthode permettant de naviguer vers l'ancien user control
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            Navigateur.GetInstance().NavigerVersAncien();
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
        /// Méthode permettant de naviguer vers la page de modification de l'oeuvre
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void Modifier_Click(object sender, RoutedEventArgs e)
        {
            Navigateur.GetInstance().NaviguerVers(Navigateur.ModificationOeuvre_UC);
        }
    }
}
