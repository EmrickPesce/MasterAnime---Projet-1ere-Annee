using System;

namespace Iut.MasterAnime.ClassLibrary
{
    /// <summary>
    /// Représente le type Livre
    /// </summary>
    public class Livre : Littéraire
    {
        /// <summary>
        /// Contructeur de la classe Livre
        /// </summary>
        /// <param name="nom">Le nom de l'oeuvre</param>
        /// <param name="image">Le nom et le type de l'image de l'oeuvre. Par défaut : "PlacerImage.png"</param>
        /// <param name="sortie">La date de sortie de l'oeuvre, en DateTime. Par défaut celle d'aujoud'hui</param>
        /// <param name="auteur">Le nom de l'auteur de l'oeuvre. Par défaut : "Inconnu"</param>
        /// <param name="éditeur">Le nom de l'éditeur de l'oeuvre. Par défaut : "Inconnu"</param>
        /// <param name="informationsComplémentaires">Un ObservableDictionary contenant des informations sur l'oeuvre sous la forme de couple (sortieInfo, Info). Si null est initialisé</param>
        /// <param name="synopsis">Le synopsis de l'oeuvre. Par défaut : "Inconnu"</param>
        /// <param name="commentaire">Un commentaire personnel de l'utilisateur sur l'oeuvre. Par défaut : "Inconnu"</param>
        public Livre(String nom, String image, DateTime sortie, String auteur, String éditeur,
            ObservableDictionary<StringVérifié, StringVérifié> informationsComplémentaires, String synopsis, String commentaire)
            : base(nom, image, sortie, auteur, éditeur, informationsComplémentaires, synopsis, commentaire)
        {
        }

        /// <summary>
        /// Contructeur de la classe Livre. Celui-ci permet d'instancier un guid à partir d'un connu, pour la persistance
        /// </summary>
        /// <param name="nom">Le nom de l'oeuvre</param>
        /// <param name="image">Le nom et le type de l'image de l'oeuvre. Par défaut : "PlacerImage.png"</param>
        /// <param name="sortie">La date de sortie de l'oeuvre, en DateTime. Par défaut celle d'aujoud'hui</param>
        /// <param name="auteur">Le nom de l'auteur de l'oeuvre. Par défaut : "Inconnu"</param>
        /// <param name="éditeur">Le nom de l'éditeur de l'oeuvre. Par défaut : "Inconnu"</param>
        /// <param name="informationsComplémentaires">Un ObservableDictionary contenant des informations sur l'oeuvre sous la forme de couple (sortieInfo, Info). Si null est initialisé</param>
        /// <param name="synopsis">Le synopsis de l'oeuvre. Par défaut : "Inconnu"</param>
        /// <param name="commentaire">Un commentaire personnel de l'utilisateur sur l'oeuvre. Par défaut : "Inconnu"</param>
        /// <param name="guid">Le string du Guid pour la création</param>
        public Livre(String nom, String image, DateTime sortie, String auteur, String éditeur,
            ObservableDictionary<StringVérifié, StringVérifié> informationsComplémentaires, String synopsis, String commentaire, string guid)
            : base(nom, image, sortie, auteur, éditeur, informationsComplémentaires, synopsis, commentaire, guid)
        {
        }


        /// <summary>
        /// Permet de retourner les informations de l'oeuvre
        /// </summary>
        /// <returns>Les différentes informations de l'oeuvre</returns>
        public override string ToString()
        {
            return $"Type : Livre\nNom : {Nom}\nImage : {Image}\nSortie : {Sortie}\n" +
                $"Auteur : {Auteur}\nÉditeur : {Éditeur}\n" +
                InfoToString() +
                $"Synopsis : {Synopsis}\nCommentaire : {Commentaire}";
        }
    }
}
