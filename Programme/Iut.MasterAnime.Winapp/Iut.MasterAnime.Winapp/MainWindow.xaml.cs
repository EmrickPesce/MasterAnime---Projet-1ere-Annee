using System.Windows;

namespace Iut.MasterAnime.Winapp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Le Navigateur contenant la vue, étant utilisé dans le xaml
        /// </summary>
        public Navigateur Navigateur => Navigateur.GetInstance();

        /// <summary>
        /// Le constructeur de classe de la fenêtre principale
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;
        }
    }
}
