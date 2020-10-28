using Iut.MasterAnime.Management;
using Iut.MasterAnime.Winapp.CodeCréationBibliothèque;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Iut.MasterAnime.Winapp.CodePagePrincipale
{
    /// <summary>
    /// Logique d'interaction pour ListeBibliothèques.xaml
    /// </summary>
    public partial class ListeBibliothèques : UserControl
    {
        /// <summary>
        /// Le manager étant dans l'App qui est ainsi le même pour toutes les vus
        /// </summary>
        public Manager Manager => (App.Current as App).Manager;

        /// <summary>
        /// Permet de définir si le mode sombre est activé ou non
        /// </summary>
        public bool ModeSombreActivé { get; set; } = false;

        /// <summary>
        /// Le constructeur de la classe du user control ListeBibliothèques
        /// </summary>
        public ListeBibliothèques()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Événement permettant de notifier que la bibliothèque sélectionnée a était changée
        /// </summary>
        public event EventHandler ChangementBibliothèque;

        /// <summary>
        /// Permet de lever l'événement ChangementBibliothèque notifiant que la bibliothèque sélectionnée a était changée
        /// </summary>
        private void OnChangementBibliothèque() => ChangementBibliothèque?.Invoke(this, null);

        /// <summary>
        /// Permet d'ouvrir la fenêtre de création d'une bibliothèque
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void AjoutBibliothèque_Click(object sender, RoutedEventArgs e)
        {
            CréationBibliothèque créationBibliothèque = new CréationBibliothèque();

            if(ModeSombreActivé)
            {
                créationBibliothèque.Background = new SolidColorBrush(Color.FromRgb(51, 51, 51));
                créationBibliothèque.Resources["CouleurTexte"] = Brushes.White;
            }
            else
            {
                créationBibliothèque.Background = Brushes.White;
                créationBibliothèque.Resources["CouleurTexte"] = Brushes.Black;
            }

            créationBibliothèque.ShowDialog();
        }

        /// <summary>
        /// Permet de notifier que l'utilisateur a cliqué sur une bibliothèque, et donc notifier la vue de ceci
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void LesBibliothèques_MouseUp(object sender, MouseButtonEventArgs e)
        {
            OnChangementBibliothèque();
        }

        /// <summary>
        /// Permet de notifier que l'utilisateur a sélectionner une bibliothèque, et donc notifier la vue de ceci
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void ComboBoxBibliothèques_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OnChangementBibliothèque();
        }
    }
}
