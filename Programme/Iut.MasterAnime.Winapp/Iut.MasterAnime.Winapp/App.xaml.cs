using System;
using System.Windows;
using Iut.MasterAnime.Management;
using Iut.MasterAnime.Persistance.Json;
using System.Windows.Media;

namespace Iut.MasterAnime.Winapp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Le manager étant qui est partager et donc le même pour toutes les vus
        /// </summary>
        public Manager Manager { get; private set; } = new Manager(new PersistanceJson());

        /// <summary>
        /// Le constructeur de la classe de l'Application App
        /// </summary>
        public App()
        {
            //Permet de récupérer toutes les exceptions non gérées
            var currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }

        /// <summary>
        /// Méthode se lançant lorsque l'Application a été générée. Ici on va définir les ressources dynamiques étant dans l'App
        /// </summary>
        /// <param name="e">Les arguments, qui ici ne sont pas utilisés</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            this.Resources["CouleurBordures"] = Brushes.Black;
            this.Resources["CouleurTexte"] = Brushes.Black;
        }

        /// <summary>
        /// Méthode permettant d'afficher le message et le StackTrace d'une excetpion
        /// </summary>
        /// <param name="sender">L'object qui lève l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = (Exception)e.ExceptionObject;

            MessageBox.Show($"UnhandledException caught : {ex.Message}\nUnhandledException StackTrace : {ex.StackTrace}\n Runtime terminating: {0}");
        }
    }
}
