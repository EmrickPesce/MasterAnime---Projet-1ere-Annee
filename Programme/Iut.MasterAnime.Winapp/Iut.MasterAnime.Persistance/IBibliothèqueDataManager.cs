using Iut.MasterAnime.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iut.MasterAnime.Persistance
{
    /// <summary>
    /// Interface possédant différentes méthodes dont la persistance devra avoir
    /// </summary>
    public interface IBibliothèqueDataManager : IDataManager<Bibliothèque>, IPersistanceManager
    {
        /// <summary>
        /// Permet de récupérer la Liste Principale
        /// </summary>
        /// <returns>La Liste Principale de la persistance</returns>
        Bibliothèque ObtenirPrincipale();

        /// <summary>
        /// Permet d'ajouter une bibliothèque à la persistance et à différentes bibliothèques
        /// </summary>
        /// <param name="oeuvre">L'oeuvre à ajouter</param>
        /// <param name="bibliothèques">Les bibliothèques à laquelle l'ajouter</param>
        /// <returns>True si elle a bien été ajoutée, false si elle existe déjà</returns>
        bool AjouterOeuvre(Oeuvre oeuvre, params Bibliothèque[] bibliothèques);
    }
}
