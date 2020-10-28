using Iut.MasterAnime.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace Iut.MasterAnime.Persistance.Stub
{
    /// <summary>
    /// Persistance d'oeuvres
    /// </summary>
    public class StubOeuvreDataManager : StubDataManager<Oeuvre>
    {
        /// <summary>
        /// Le constructeur de la persistance d'oeuvres
        /// </summary>
        public StubOeuvreDataManager()
        {
            MaCollection = DonnéesPrêtes.DonnéesDOeuvres();
        }

        /// <summary>
        /// Permet de récupérer une oeuvre via son nom
        /// </summary>
        /// <param name="nom">Le nom de l'oeuvre à récupérer</param>
        /// <returns>L'oeuvre possédant le nom passé en paramètre, null si elle n'existe pas</returns>
        public override Oeuvre ObtenirParNom(string nom)
        {
            return MaCollection.Find(match: oeuvre => oeuvre.Nom.Equals(nom));
        }
    }
}
