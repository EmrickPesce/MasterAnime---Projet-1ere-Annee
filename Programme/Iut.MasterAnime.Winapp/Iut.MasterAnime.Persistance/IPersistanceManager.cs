using Iut.MasterAnime.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iut.MasterAnime.Persistance
{
    /// <summary>
    /// Interface possédant différentes méthodes dont la persistance devra avoir
    /// </summary>
    public interface IPersistanceManager
    {
        /// <summary>
        /// Récupère les données contenu dans le fichier de la persistance et les renvoies
        /// </summary>
        /// <returns>Les données récupérées, une Bibliothèque et une collection de Bibliothèques</returns>
        (Bibliothèque, IEnumerable<Bibliothèque>) ChargerDonnées();

        /// <summary>
        /// Écrit les données dans le fichier de la persistance
        /// </summary>
        /// <param name="listePrincipale">La Bibliothèque à écrire dans le fichier</param>
        /// <param name="lesBibliothèques">La collection de bibliothèques à écrire dans le fichier</param>
        void SauvegarderDonnées(Bibliothèque listePrincipale, IEnumerable<Bibliothèque> lesBibliothèques);

        /// <summary>
        /// Permet d'enregistrer le fichier de sauvegarde dans un autre répertoire
        /// </summary>
        /// <param name="chemin">Le répertoire où enregistrer la copie de la sauvegarde</param>
        void ExporterPersistance(string chemin);

        /// <summary>
        /// Permet de récupérer un fichier de sauvegarde et de l'incorporer à la persistance
        /// </summary>
        /// <param name="chemin">Le fichier et son chemin</param>
        /// <returns>Retourne dans l'ordre : Nombre Bibliothèque importées, Nombre Bibliothèque à importer, Nombre Oeuvre importées, Nombre Oeuvre à importer</returns>
        (int, int, int, int) ImporterPersistance(string cheminFichier);
    }
}
