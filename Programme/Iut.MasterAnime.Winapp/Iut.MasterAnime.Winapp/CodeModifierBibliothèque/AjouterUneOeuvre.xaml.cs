using System.Windows;

namespace Iut.MasterAnime.Winapp.CodeModifierBibliothèque
{
    /// <summary>
    /// Logique d'interaction pour AjouterUneOeuvre.xaml
    /// </summary>
    public partial class AjouterUneOeuvre : Window
    {
        /// <summary>
        /// Constructeur de la classe du user control AjouterUneOeuvre
        /// </summary>
        public AjouterUneOeuvre()
        {
            InitializeComponent();
        }

        /// <summary>
        /// L'événement annonçant que l'utilisateur a choisi de séléctionner des oeuvres
        /// </summary>
        public event RoutedEventHandler SélectionOeuvresClick
        {
            add
            {
                SélectionOeuvres1.Click += value;
                SélectionOeuvres2.Click += value;
                SélectionOeuvres3.Click += value;
            }
            remove
            {
                SélectionOeuvres1.Click -= value;
                SélectionOeuvres2.Click -= value;
                SélectionOeuvres3.Click -= value;
            }
        }

        /// <summary>
        /// L'événement annonçant que l'utilisateur a choisi de créer une oeuvre
        /// </summary>
        public event RoutedEventHandler CréationOeuvreClick
        {
            add
            {
                CréationOeuvre1.Click += value;
                CréationOeuvre2.Click += value;
                CréationOeuvre3.Click += value;
            }
            remove
            {
                CréationOeuvre1.Click -= value;
                CréationOeuvre2.Click -= value;
                CréationOeuvre3.Click -= value;
            }
        }

        /// <summary>
        /// L'utilisateur ne choisi rien, il annule
        /// </summary>
        public event RoutedEventHandler AnnulerClick
        {
            add
            {
                Annuler.Click += value;
            }
            remove
            {
                Annuler.Click -= value;
            }
        }
    }
}
