using System.Collections.ObjectModel;
using System.Linq;

namespace Iut.MasterAnime.ClassLibrary
{
    /// <summary>
    /// Classe permettant de trier de différentes manières une collection d'oeuvres
    /// </summary>
    public static class Tri
    {
        /// <summary>
        /// Prend une Collection d'oeuvre et en retrourne une nouvelle triée par ordre croissant
        /// </summary>
        /// <param name="àTrier">La collection à trier</param>
        /// <returns>Retourne la nouvelle collection triée par ordre croissant</returns>
        public static ObservableCollection<Oeuvre> TriCroissant(this ObservableCollection<Oeuvre> àTrier)
        {
            if (àTrier == null) return null;

            ObservableCollection<Oeuvre> trié = new ObservableCollection<Oeuvre>();

            àTrier.OrderBy(oeuvre => oeuvre.Nom).ToList().ForEach(oeuvre => trié.Add(oeuvre));

            return trié;
        }

        /// <summary>
        /// Prend une Collection d'oeuvre et en retrourne une nouvelle triée par ordre décroissant
        /// </summary>
        /// <param name="àTrier">La collection à trier</param>
        /// <returns>Retourne la nouvelle collection triée par ordre décroissant</returns>
        public static ObservableCollection<Oeuvre> TriDécroissant(this ObservableCollection<Oeuvre> àTrier)
        {
            if (àTrier == null) return null;

            ObservableCollection<Oeuvre> trié = new ObservableCollection<Oeuvre>();

            àTrier.OrderByDescending(oeuvre => oeuvre.Nom).ToList().ForEach(oeuvre => trié.Add(oeuvre));

            return trié;
        }

        /// <summary>
        /// Prend une Collection d'oeuvre et en retrourne une nouvelle triée par type par ordre croissant
        /// </summary>
        /// <param name="àTrier">La collection à trier</param>
        /// <returns>Retourne la nouvelle collection triée par type par ordre croissant</returns>
        public static ObservableCollection<Oeuvre> TriType(this ObservableCollection<Oeuvre> àTrier)
        {
            if (àTrier == null) return null;

            ObservableCollection<Oeuvre> trié = new ObservableCollection<Oeuvre>();

            àTrier.Where(oeuvre => oeuvre is Film).OrderBy(oeuvre => oeuvre.Nom).ToList().ForEach(oeuvre => trié.Add(oeuvre));
            àTrier.Where(oeuvre => oeuvre is Série).OrderBy(oeuvre => oeuvre.Nom).ToList().ForEach(oeuvre => trié.Add(oeuvre));
            àTrier.Where(oeuvre => oeuvre is Livre).OrderBy(oeuvre => oeuvre.Nom).ToList().ForEach(oeuvre => trié.Add(oeuvre));
            àTrier.Where(oeuvre => oeuvre is Scan).OrderBy(oeuvre => oeuvre.Nom).ToList().ForEach(oeuvre => trié.Add(oeuvre));
            àTrier.Where(oeuvre => oeuvre is Animé).OrderBy(oeuvre => oeuvre.Nom).ToList().ForEach(oeuvre => trié.Add(oeuvre));
            àTrier.Where(oeuvre => oeuvre is Autre).OrderBy(oeuvre => oeuvre.Nom).ToList().ForEach(oeuvre => trié.Add(oeuvre));

            return trié;
        }

        /// <summary>
        /// Prend une Collection d'oeuvre et en retrourne une nouvelle triée par date de la plus récente à la plus ancienne
        /// </summary>
        /// <param name="àTrier">La collection à trier</param>
        /// <returns>Retourne la nouvelle collection triée par date de la plus récente à la plus ancienne</returns>
        public static ObservableCollection<Oeuvre> TriDate(this ObservableCollection<Oeuvre> àTrier)
        {
            if (àTrier == null) return null;

            ObservableCollection<Oeuvre> trié = new ObservableCollection<Oeuvre>();

            àTrier.OrderBy(oeuvre => oeuvre.Sortie).ToList().ForEach(oeuvre => trié.Add(oeuvre));

            return trié;
        }

        /// <summary>
        /// Prend une Collection d'oeuvre et retourne toutes les oeuvres du type souhaité
        /// </summary>
        /// <param name="àTrier">La collection à trier suivant le type</param>
        /// <param name="type">Le type d'oeuvre souhaité</param>
        /// <returns>Retourne la nouvelle collection d'oeuvre du type passé en paramètre</returns>
        public static ObservableCollection<Oeuvre> OeuvresDuType(this ObservableCollection<Oeuvre> àTrier, TypeOeuvre type)
        {
            if (àTrier == null) return null;

            ObservableCollection<Oeuvre> trié = new ObservableCollection<Oeuvre>();

            if (type == TypeOeuvre.Tout) àTrier.OrderBy(oeuvre => oeuvre.Nom).ToList().ForEach(oeuvre => trié.Add(oeuvre));
            if (type == TypeOeuvre.Film) àTrier.Where(oeuvre => oeuvre is Film).OrderBy(oeuvre => oeuvre.Nom).ToList().ForEach(oeuvre => trié.Add(oeuvre));
            if (type == TypeOeuvre.Série) àTrier.Where(oeuvre => oeuvre is Série).OrderBy(oeuvre => oeuvre.Nom).ToList().ForEach(oeuvre => trié.Add(oeuvre));
            if (type == TypeOeuvre.Livre) àTrier.Where(oeuvre => oeuvre is Livre).OrderBy(oeuvre => oeuvre.Nom).ToList().ForEach(oeuvre => trié.Add(oeuvre));
            if (type == TypeOeuvre.Scan) àTrier.Where(oeuvre => oeuvre is Scan).OrderBy(oeuvre => oeuvre.Nom).ToList().ForEach(oeuvre => trié.Add(oeuvre));
            if (type == TypeOeuvre.Animé) àTrier.Where(oeuvre => oeuvre is Animé).OrderBy(oeuvre => oeuvre.Nom).ToList().ForEach(oeuvre => trié.Add(oeuvre));
            if (type == TypeOeuvre.Autre) àTrier.Where(oeuvre => oeuvre is Autre).OrderBy(oeuvre => oeuvre.Nom).ToList().ForEach(oeuvre => trié.Add(oeuvre));

            return trié;
        }
    }
}
