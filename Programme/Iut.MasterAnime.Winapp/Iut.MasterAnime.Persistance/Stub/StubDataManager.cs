using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.CompilerServices;

namespace Iut.MasterAnime.Persistance.Stub
{
    public abstract class StubDataManager<T> : IDataManager<T> where T : class
    {
        /// <summary>
        /// La collection de la persistance
        /// </summary>
        protected List<T> MaCollection { get; set; } = new List<T>();

        /// <summary>
        /// Permet de récupérer la collection de la persistance
        /// </summary>
        /// <returns>La collection de la persistance</returns>
        public IEnumerable<T> ObtenirTous()
        {
            return MaCollection;
        }

        /// <summary>
        /// Permet d'ajouter un élément à la persistance
        /// </summary>
        /// <param name="élément">L'élément à ajouter</param>
        /// <returns>Retourne l'élément si il a été ajoutée, null sinon</returns>
        public virtual T Ajouter(T élément)
        {
            MaCollection.Add(élément);
            return élément;
        }

        /// <summary>
        /// Permet de retirer un élément de la persistance
        /// </summary>
        /// <param name="élément">L'élément à retirer</param>
        /// <returns>True si il a bien été retiré, False si il n'y été pas</returns>
        public bool Retirer(T élément)
        {
            return MaCollection.Remove(élément);
        }

        /// <summary>
        /// Permet de réinitialiser la persistance
        /// </summary>
        public virtual void ToutRetirer()
        {
            MaCollection.Clear();
        }

        /// <summary>
        /// Permet de récupérer un élément de la persistance à partir de son nom
        /// </summary>
        /// <param name="nom">La nom de l'élément à chercher</param>
        /// <returns>L'élément trouvé ou null si il n'existe pas</returns>
        public abstract T ObtenirParNom(string nom);


        /// <summary>
        /// Sauvegarde les données de la persistance. Cette méthode n'est pas implémentée
        /// </summary>
        public void Sauvegarder()
        {
        }

        /// <summary>
        /// Charge les données de la persistance. Cette méthode n'est pas implémentée
        /// </summary>
        public void Charger()
        {
        }
    }
}
