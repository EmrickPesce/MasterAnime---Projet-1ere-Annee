using System.Windows;
using System.Windows.Controls;

namespace Iut.MasterAnime.Winapp.CodePageRecherche
{
    /// <summary>
    /// Logique d'interaction pour AucuneOeuvreTrouvée.xaml
    /// </summary>
    public partial class AucuneOeuvreTrouvée : UserControl
    {
        /// <summary>
        /// Le constructeur de la classe du user control AucuneOeuvreTrouvée
        /// </summary>
        public AucuneOeuvreTrouvée()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Permet de naviguer vers la page de création d'une oeuvre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AjoutOeuvre_Click(object sender, RoutedEventArgs e)
        {
            Navigateur.GetInstance().NaviguerVers(Navigateur.CréationOeuvre_UC);
        }
    }
}
