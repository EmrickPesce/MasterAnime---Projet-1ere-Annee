using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Iut.MasterAnime.ClassLibrary
{
    /// <summary>
    /// Classe permettant de vérifier un string contenu dans un dictionary à travers la vue
    /// </summary>
    public class StringVérifié : IDataErrorInfo, IEquatable<StringVérifié>
    {
        /// <summary>
        /// Le string à vérifier
        /// </summary>
        [MaxLength(16, ErrorMessage = "Maximum 16 caractères")]
        public string LeString { get; set; }

        /// <summary>
        /// Le message d'erreur indicant ce qui ne va pas avec cet objet. Par défault, string vide ("")
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// Le constructeur de la class StringVérifié
        /// </summary>
        /// <param name="leString">Le string à vérifier</param>
        public StringVérifié(string leString)
        {
            LeString = leString;
        }

        /// <summary>
        /// Permet de retourner directement l'attribut LeString
        /// </summary>
        /// <returns>Retourne l'attribut LeString</returns>
        public override string ToString()
        {
            return LeString;
        }

        /// <summary>
        /// Donne le message d'erreur pour la propriété avec le nom donné
        /// </summary>
        /// <param name="columnName">Le nom de la propriété pour laquelle on veut le message d'erreur</param>
        /// <returns>Le message d'erreur de la propriété de la classe</returns>
        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "LeString":
                        return LeString.Length > 16 ? "Max 16 caractères" : null;
                    default:
                        return null;
                }
            }
        }

        /// <summary>
        /// Vérifie si les deux StringVérifié possèdent le même string
        /// </summary>
        /// <param name="oeuvre">Le StringVérifié à comparer</param>
        /// <returns>True si le StringVérifié possède le même string, false sinon</returns>
        public bool Equals(StringVérifié stringVérifié) => LeString.Equals(stringVérifié.LeString);

        /// <summary>
        /// Vérifie si les deux StringVérifié possèdent le même nom ou que c'est le même string
        /// </summary>
        /// <param name="obj">L'objet à comparer</param>
        /// <returns>True si c'est le même StringVérifié, false sinon</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as StringVérifié);
        }

        /// <summary>
        /// Définit la fonction de Hashage du StringVérifié à partir du string
        /// </summary>
        /// <returns>Retourne le Hashage du string du StringVérifié</returns>
        public override int GetHashCode() => LeString.GetHashCode();
    }
}
