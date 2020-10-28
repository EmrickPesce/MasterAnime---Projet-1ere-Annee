using Iut.MasterAnime.Management;
using Iut.MasterAnime.Winapp.CodePageRecherche;
using Ookii.Dialogs.Wpf;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Iut.MasterAnime.Winapp.CodeParametres
{
    /// <summary>
    /// Logique d'interaction pour Paramètres.xaml
    /// </summary>
    public partial class Paramètres : UserControl
    {
        /// <summary>
        /// Le manager étant dans l'App qui est ainsi le même pour toutes les vus
        /// </summary>
        public Manager Manager => (Application.Current as App).Manager;

        /// <summary>
        /// Le constructeur de la classe du user control Paramètres
        /// </summary>
        public Paramètres()
        {
            InitializeComponent();
            
            DataContext = this;
        }

        /// <summary>
        /// Permet de naviguer vers l'ancien user control
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            Navigateur.GetInstance().NavigerVersAncien();
        }

        /// <summary>
        /// Permet de réinitialiser les données du manager et donc de l'application
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void Réinitialisation_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult resultat = 
                MessageBox.Show("La réinitialisaton de l'application supprimera toutes les oeuvres et listes que vous avez créé.\nÊtes-vous sûr de vouloir le faire ?",
                "ATTENTION", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);
            if(resultat == MessageBoxResult.Yes)
            {
                (Application.Current as App).Manager.RéinitialiserManager();
                (Navigateur.GetInstance().ObtenirUserControl(Navigateur.Recherche_UC) as PageRecherche).RéinitialiserVue();
            }
        }

        /// <summary>
        /// Permet d'activer le mode sombre
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            Navigateur.GetInstance().ActivationModeSombre();
        }

        /// <summary>
        /// Permet de désactiver le mode sombre
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            Navigateur.GetInstance().DésactivationModeSombre();
        }

        /// <summary>
        /// Permet d'exporter les données du manager dans un fichier
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void Exporter_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new VistaFolderBrowserDialog();

            if (dialog.ShowDialog() == true)
            {
                DirectoryInfo di = new DirectoryInfo(dialog.SelectedPath);
                try
                {
                    Manager.ExporterPersistance(di.FullName);
                } catch (Exception exception)
                {
                    MessageBox.Show("Une erreur s'est produite. Impossible d'exporter le fichier.\nEssayez de lancer l'application en mode administrateur, puis réitérez.\n" +
                        $"Message d'Erreur : \n{exception.Message}",
                        "Erreur lors de l'exportation", MessageBoxButton.OK);
                    return;
                }
                MessageBox.Show("L'exportation a réussie.", "Information", MessageBoxButton.OK);
            }
        }

        /// <summary>
        /// Permet de récupérer des données importées à partir d'un fichier
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void Importer_Click(object sender, RoutedEventArgs e)
        {
            //Configuration de l'ouverture de la boite de dialogue
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "Desktop";
            dialog.DefaultExt = ".json";
            dialog.Filter = "JSON files (*.json) | *.json";

            //Ouverture de la boite de dialogue
            bool? result = dialog.ShowDialog();

            //Traitement du retour de la boite de dialogue
            if (result == true)
            {
                //Récupération du document
                FileInfo fi = new FileInfo(dialog.FileName);
                int r1;
                int r2;
                int r3;
                int r4;
                try
                {
                    (r1, r2, r3, r4) = Manager.ImporterPersistance(fi.FullName);
                } catch (Exception exception)
                {
                    MessageBox.Show("Une erreur s'est produite. Impossible d'importer le fichier.\nEssayez de lancer l'application en mode administrateur, puis réitérez.\n" +
                        $"Message d'Erreur : \n{exception.Message}",
                        "Erreur lors de l'importation", MessageBoxButton.OK);
                    return;
                }
                MessageBox.Show($"{r1} bibliothèques importées sur {r2}.\n{r3} oeuvres importées sur {r4}.", "Information", MessageBoxButton.OK);
            }
        }
    }
}
