using Iut.MasterAnime.ClassLibrary;
using Iut.MasterAnime.Management;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Iut.MasterAnime.Winapp.CodePageRecherche
{
    /// <summary>
    /// Logique d'interaction pour AfficheLigneRecherche.xaml
    /// </summary>
    public partial class AfficheLigneRecherche : UserControl
    {
        /// <summary>
        /// Une dependency property permettant de passer en paramètres la recherche
        /// </summary>
        public static readonly DependencyProperty RechercheProperty = DependencyProperty.Register("Recherche", typeof(ObservableCollection<Oeuvre>),
            typeof(AfficheLigneRecherche));

        /// <summary>
        /// La recherche, étant la collection d'oeuvres trouvées
        /// </summary>
        public ObservableCollection<Oeuvre> Recherche
        {
            get => GetValue(RechercheProperty) as ObservableCollection<Oeuvre>;
            set
            {
                SetValue(RechercheProperty, value);
            }
        }

        /// <summary>
        /// Le constructeur de la classe du user control AfficheLigneRecherche
        /// </summary>
        public AfficheLigneRecherche()
        {
            InitializeComponent();

            DataContext = this;
        }

        /// <summary>
        /// Permet de sélectionner une oeuvre et de naviguer vers celle-ci
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void BouttonOeuvre_Click(object sender, RoutedEventArgs e)
        {
            Manager manager = (Application.Current as App).Manager;
            manager.OeuvreSélectionnée = manager.BibliothèqueSélectionnée.ObtenirOeuvre(((sender as Button).Tag.ToString()));

            Navigateur.GetInstance().NaviguerVers(Navigateur.AffichageOeuvre_UC);
        }
    }
}
