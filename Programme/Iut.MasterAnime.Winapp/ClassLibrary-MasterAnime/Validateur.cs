using System;
using System.Linq;

namespace Iut.MasterAnime.ClassLibrary
{
    /// <summary>
    /// Classe permettant de valider les prorpiétés d'une Bibliothèque et d'une Oeuvre
    /// </summary>
    public static class Validateur
    {
        /// <summary>
        /// Méthode permettant de valider une bibliothèque
        /// </summary>
        /// <param name="bibliothèque">La bibliothèque à vérifier</param>
        /// <returns>True si elle est valide, false sinon</returns>
        public static bool BibliothèqueValidateur(this Bibliothèque bibliothèque)
        {
            if (String.IsNullOrEmpty(bibliothèque.Nom)) return false;
            if (bibliothèque.Nom.Length > 16) return false;
            return true;
        }

        /// <summary>
        /// Méthode permettant de valider une oeuvre
        /// </summary>
        /// <param name="oeuvre">L'oeuvre à vérifier</param>
        /// <returns>True si elle est valide, false sinon</returns>
        public static bool OeuvreValidateur(this Oeuvre oeuvre)
        {
            //Vérifie le nom
            if (String.IsNullOrEmpty(oeuvre.Nom)) return false;
            if (oeuvre.Nom.Length > 16) return false;

            //Vérifie les informations complémentaires
            foreach (StringVérifié key in oeuvre.InformationsComplémentaires.Keys)
            {
                if (key.LeString.Length > 16) return false;
            }
            foreach (StringVérifié value in oeuvre.InformationsComplémentaires.Values)
            {
                if (value.LeString.Length > 16) return false;
            }
            foreach (StringVérifié info in oeuvre.InformationsComplémentaires.Keys)
            {
                if (oeuvre.InformationsComplémentaires.ToList().Where(kvp => kvp.Key.LeString.Equals(info.LeString)).Count() > 1)
                {
                    return false;
                }
            }

            //Vérifie les informations par défault
            if (oeuvre is Autre)
            {
                if ((oeuvre as Autre).Créateur.Length > 16) return false;
            }
            else if (oeuvre is Cinématographique)
            {
                if ((oeuvre as Cinématographique).Réalisateur.Length > 16) return false;
                if ((oeuvre as Cinématographique).Studio.Length > 16) return false;
            }
            else if (oeuvre is Littéraire)
            {
                if ((oeuvre as Littéraire).Auteur.Length > 16) return false;
                if ((oeuvre as Littéraire).Éditeur.Length > 16) return false;
            }
            else if (oeuvre is Animé)
            {
                if ((oeuvre as Animé).Auteur.Length > 16) return false;
                if ((oeuvre as Animé).Studio.Length > 16) return false;
            }

            return true;
        }
    }
}
