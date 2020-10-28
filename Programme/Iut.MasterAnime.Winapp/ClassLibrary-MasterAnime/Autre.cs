using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Iut.MasterAnime.ClassLibrary
{
    /// <summary>
    /// Représente le type Autre
    /// </summary>
    public class Autre : Oeuvre, IDataErrorInfo
    {
        /// <summary>
        /// Le nom du créateur de l'oeuvre ainsi que son getter et setter
        /// Possède 16 caractères maximum
        /// </summary>
        [MaxLength(16, ErrorMessage = "Maximum 16 caractères")]
        public String Créateur
        {
            get => créateur;
            set
            {
                créateur = value;
                OnPropertyChanged();
            }
        }
        private String créateur;

        /// <summary>
        /// Le message d'erreur indicant ce qui ne va pas avec cet objet. Par défault, string vide ("")
        /// </summary>
        public new string Error { get; set; }

        /// <summary>
        /// Contructeur de la classe Autre
        /// </summary>
        /// <param name="nom">Le nom de l'oeuvre</param>
        /// <param name="image">Le nom et le type de l'image de l'oeuvre. Par défaut : "PlacerImage.png"</param>
        /// <param name="sortie">La date de sortie de l'oeuvre, en DateTime. Par défaut celle d'aujoud'hui</param>
        /// <param name="créateur">Le nom du réalisateur de l'oeuvre. Par défaut : "Inconnu"</param>
        /// <param name="informationsComplémentaires">Un ObservableDictionary contenant des informations sur l'oeuvre sous la forme de couple (sortieInfo, Info). Si null est initialisé</param>
        /// <param name="synopsis">Le synopsis de l'oeuvre. Par défaut : "Inconnu"</param>
        /// <param name="commentaire">Un commentaire personnel de l'utilisateur sur l'oeuvre. Par défaut : "Inconnu"</param>
        public Autre(String nom, String image, DateTime sortie, String créateur,
            ObservableDictionary<StringVérifié, StringVérifié> informationsComplémentaires, String synopsis, String commentaire)
            : base(nom, image, sortie, informationsComplémentaires, synopsis, commentaire)
        {
            Créateur = string.IsNullOrEmpty(créateur) ? "Inconnu" : créateur;
        }

        /// <summary>
        /// Contructeur de la classe Autre. Celui-ci permet d'instancier un guid à partir d'un connu, pour la persistance
        /// </summary>
        /// <param name="nom">Le nom de l'oeuvre</param>
        /// <param name="image">Le nom et le type de l'image de l'oeuvre. Par défaut : "PlacerImage.png"</param>
        /// <param name="sortie">La date de sortie de l'oeuvre, en DateTime. Par défaut celle d'aujoud'hui</param>
        /// <param name="créateur">Le nom du réalisateur de l'oeuvre. Par défaut : "Inconnu"</param>
        /// <param name="informationsComplémentaires">Un ObservableDictionary contenant des informations sur l'oeuvre sous la forme de couple (sortieInfo, Info). Si null est initialisé</param>
        /// <param name="synopsis">Le synopsis de l'oeuvre. Par défaut : "Inconnu"</param>
        /// <param name="commentaire">Un commentaire personnel de l'utilisateur sur l'oeuvre. Par défaut : "Inconnu"</param>
        /// <param name="guid">Le string du Guid pour la création</param>
        public Autre(String nom, String image, DateTime sortie, String créateur,
            ObservableDictionary<StringVérifié, StringVérifié> informationsComplémentaires, String synopsis, String commentaire, string guid)
            : base(nom, image, sortie, informationsComplémentaires, synopsis, commentaire, guid)
        {
            Créateur = string.IsNullOrEmpty(créateur) ? "Inconnu" : créateur;
        }

        /// <summary>
        /// Permet de modifier les informations de Autre.
        /// Les informations possédants une valeur null ne seront pas modifiées
        /// </summary>
        /// <param name="newNom">Le nouveau nom de l'oeuvre. Null si pas de changement</param>
        /// <param name="newImage">Le nouveau chemin de l'image. Null si pas de changement</param>
        /// <param name="newSortie">La nouvelle date de sortie. Null si pas de changement</param>
        /// <param name="newCréateur">Le nouveau nom du créateur. Null si pas de changement</param>
        /// <param name="newInfo">Les nouvelles informations complémentaires. Null si pas de changement</param>
        /// <param name="newSynopsis">Le nouveau synopsis. Null si pas de changement</param>
        /// <param name="newCommentaire">Le nouveau commentaire. Null si pas de changement</param>
        public void ModifierOeuvre(String newNom, String newImage, DateTime newSortie, String newCréateur,
            ObservableDictionary<StringVérifié, StringVérifié> newInfo, String newSynopsis, String newCommentaire)
        {
            Nom = string.IsNullOrEmpty(newNom) ? Nom : newNom;
            Image = string.IsNullOrEmpty(newImage) ? Image : newImage;
            Sortie = newSortie == null ? Sortie : newSortie;
            Créateur = string.IsNullOrEmpty(newCréateur) ? Créateur : newCréateur;
            Synopsis = string.IsNullOrEmpty(newSynopsis) ? Synopsis : newSynopsis;
            Commentaire = string.IsNullOrEmpty(newCommentaire) ? Commentaire : newCommentaire;

            if (newInfo != null)
            {
                ClearInformation();
                newInfo.ToList().ForEach(kvp => AjouterInformation(kvp.Key, kvp.Value));
            }
        }

        /// <summary>
        /// Permet de modifier les informations de Autre à partir des informations d'un différent Autre
        /// </summary>
        /// <param name="autre">L'oeuvre à partir de laquelle on récupère les informations à modifier</param>
        public void ModifierOeuvre(Autre autre)
        {
            ModifierOeuvre(autre.Nom, autre.Image, autre.Sortie, autre.Créateur, autre.InformationsComplémentaires, autre.Synopsis, autre.Commentaire);
        }

        /// <summary>
        /// Permet de retourner les informations de l'oeuvre
        /// </summary>
        /// <returns>Les différentes informations de l'oeuvre</returns>
        public override string ToString()
        {
            return $"Type : Autre\nNom : {Nom}\nImage : {Image}\nSortie : {Sortie}\n" +
                $"Créateur : {Créateur}\n" +
                InfoToString() +
                $"Synopsis : {Synopsis}\nCommentaire : {Commentaire}";
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
                    case "Nom":
                        return string.IsNullOrEmpty(Nom) ? "Nom requis" : Nom.Length > 16 ? "Max 16 caractères" : null;
                    case "Créateur":
                        return Créateur.Length > 16 ? "Max 16 caractères" : null;
                    default:
                        return null;
                }
            }
        }
    }
}
