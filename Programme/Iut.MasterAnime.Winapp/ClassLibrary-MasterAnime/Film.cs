using System;

namespace Iut.MasterAnime.ClassLibrary
{
    /// <summary>
    /// Représente le type Film
    /// </summary>
    public class Film : Cinématographique
    {
        /// <summary>
        /// Contructeur de la classe Film
        /// </summary>
        /// <param name="nom">Le nom de l'oeuvre</param>
        /// <param name="image">Le nom et le type de l'image de l'oeuvre. Par défaut : "PlacerImage.png"</param>
        /// <param name="sortie">La date de sortie de l'oeuvre, en DateTime. Par défaut celle d'aujoud'hui</param>
        /// <param name="réalisateur">Le nom du réalisateur de l'oeuvre. Par défaut : "Inconnu"</param>
        /// <param name="studio">Le nom du studio de l'oeuvre. Par défaut : "Inconnu"</param>
        /// <param name="informationsComplémentaires">Un ObservableDictionary contenant des informations sur l'oeuvre sous la forme de couple (sortieInfo, Info). Si null est initialisé</param>
        /// <param name="synopsis">Le synopsis de l'oeuvre. Par défaut : "Inconnu"</param>
        /// <param name="commentaire">Un commentaire personnel de l'utilisateur sur l'oeuvre. Par défaut : "Inconnu"</param>
        public Film(String nom, String image, DateTime sortie, String réalisateur, String studio,
            ObservableDictionary<StringVérifié, StringVérifié> informationsComplémentaires, String synopsis, String commentaire)
            : base(nom, image, sortie, réalisateur, studio, informationsComplémentaires, synopsis, commentaire)
        { }

        /// <summary>
        /// Contructeur de la classe Film. Celui-ci permet d'instancier un guid à partir d'un connu, pour la persistance
        /// </summary>
        /// <param name="nom">Le nom de l'oeuvre</param>
        /// <param name="image">Le nom et le type de l'image de l'oeuvre. Par défaut : "PlacerImage.png"</param>
        /// <param name="sortie">La date de sortie de l'oeuvre, en DateTime. Par défaut celle d'aujoud'hui</param>
        /// <param name="réalisateur">Le nom du réalisateur de l'oeuvre. Par défaut : "Inconnu"</param>
        /// <param name="studio">Le nom du studio de l'oeuvre. Par défaut : "Inconnu"</param>
        /// <param name="informationsComplémentaires">Un ObservableDictionary contenant des informations sur l'oeuvre sous la forme de couple (sortieInfo, Info). Si null est initialisé</param>
        /// <param name="synopsis">Le synopsis de l'oeuvre. Par défaut : "Inconnu"</param>
        /// <param name="commentaire">Un commentaire personnel de l'utilisateur sur l'oeuvre. Par défaut : "Inconnu"</param>
        /// <param name="guid">Le string du Guid pour la création</param>
        public Film(String nom, String image, DateTime sortie, String réalisateur, String studio,
            ObservableDictionary<StringVérifié, StringVérifié> informationsComplémentaires, String synopsis, String commentaire, string guid)
            : base(nom, image, sortie, réalisateur, studio, informationsComplémentaires, synopsis, commentaire, guid)
        { }

        /// <summary>
        /// Permet de retourner les informations de l'oeuvre
        /// </summary>
        /// <returns>Les différentes informations de l'oeuvre</returns>
        public override string ToString()
        {
            return $"Type : Film\nNom : {Nom}\nImage : {Image}\nSortie : {Sortie}" +
                $"\nRéalisateur : {Réalisateur}\nStudio : {Studio}\n" +
                InfoToString() +
                $"Synopsis : {Synopsis}\nCommentaire : {Commentaire}";
        }
    }
}
