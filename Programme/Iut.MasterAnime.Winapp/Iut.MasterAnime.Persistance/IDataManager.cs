using System;
using System.Collections.Generic;
using System.Text;

namespace Iut.MasterAnime.Persistance
{
    /// <summary>
    /// Interface possédant différentes méthodes dont la persistance devra avoir
    /// </summary>
    /// <typeparam name="T">Le type de données de la persistance</typeparam>
    public interface IDataManager<T> where T : class
    {
        /// <summary>
        /// Permet de récupérer la collection de la persistance
        /// </summary>
        /// <returns>La collection de la persistance</returns>
        IEnumerable<T> ObtenirTous();

        /// <summary>
        /// Permet de récupérer un élément de la persistance à partir de son nom
        /// </summary>
        /// <param name="nom">La nom de l'élément à chercher</param>
        /// <returns>L'élément trouvé ou null si il n'existe pas</returns>
        T ObtenirParNom(String nom);

        /// <summary>
        /// Permet d'ajouter un élément à la persistance
        /// </summary>
        /// <param name="élément">L'élément à ajouter</param>
        /// <returns>Retourne l'élément si il a été ajoutée, null sinon</returns>
        T Ajouter(T élément);

        /// <summary>
        /// Permet de retirer un élément de la persistance
        /// </summary>
        /// <param name="élément">L'élément à retirer</param>
        /// <returns>True si il a bien été retiré, False si il n'y été pas</returns>
        bool Retirer(T élément);

        /// <summary>
        /// Permet de réinitialiser la persistance
        /// </summary>
        void ToutRetirer();

        /// <summary>
        /// Sauvegarde les données de la persistance
        /// </summary>
        void Sauvegarder();

        /// <summary>
        /// Charge les données de la persistance
        /// </summary>
        void Charger();
    }
}
