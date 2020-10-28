using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Iut.MasterAnime.ClassLibrary
{
    /// <summary>
    /// Rreprésente la classe Bibliothèque. Elle contient une ObservableCollection d'oeuvres
    /// </summary>
    public class Bibliothèque : ObservableObject, IDataErrorInfo, IEquatable<Bibliothèque>
    {
        /// <summary>
        /// Le nom de la bibliothèque ainsi que son getter et setter
        /// Il est requis et possède 16 caractères maximum
        /// </summary>
        [MaxLength(16, ErrorMessage = "Max 16 caractères")]
        [MinLength(1, ErrorMessage = "Nom requis")]
        [Required]
        public String Nom
        {
            get => nom;
            set
            {
                nom = value;
                OnPropertyChanged();
            }
        }
        private String nom;

        /// <summary>
        /// Le nom et le type de l'image de la bibliothèque ainsi que son getter et setter
        /// </summary>
        public String Image
        {
            get => image;
            set
            {
                image = value;
                OnPropertyChanged();
            }
        }
        private String image;

        /// <summary>
        /// ObservableCollection qui contiendra toutes les oeuvres de la bibliothèque ainsi que son getter et setter
        /// Le setter est privé car il n'a pas besoin d'être modifié, on ne peut modifier que ses éléments à l'intérieur
        /// </summary>
        public ObservableCollection<Oeuvre> LesOeuvres
        {
            get => lesOeuvres;
            private set
            {
                lesOeuvres = value;
            }
        }
        private ObservableCollection<Oeuvre> lesOeuvres = new ObservableCollection<Oeuvre>();

        /// <summary>
        /// Un Guid permettant d'avoir un GetHashCode unique à chaque Bibliothèque car on prend celui du Guid
        /// </summary>
        public Guid Guid
        {
            get => guid;
            set
            {
                guid = value;
            }
        }
        private Guid guid = Guid.NewGuid();

        /// <summary>
        /// Le message d'erreur indicant ce qui ne va pas avec cet objet. Par défault, string vide ("")
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// Constructeur de la classe Bibliothèque
        /// </summary>
        /// <param name="nom">Le nom de la Bibliothèque</param>
        /// <param name="image">Le nom et le type de l'image</param>
        /// <param name="lesOeuvres">Une ObservableCollection qui contiendra les oeuvres de la Bibliothèque. Null si aucune ne doit être ajoutée</param>
        public Bibliothèque(String nom, String image, ObservableCollection<Oeuvre> lesOeuvres = null)
        {
            Nom = nom;
            Image = image;
            if(lesOeuvres != null)
            {
                lesOeuvres.ToList().ForEach(oeuvre => AjouterOeuvre(oeuvre));
            }
        }

        /// <summary>
        /// Constructeur de la classe Bibliothèque. Celui-ci permet d'instancier un guid à partir d'un connu, pour la persistance
        /// </summary>
        /// <param name="nom">Le nom de la Bibliothèque</param>
        /// <param name="image">Le nom et le type de l'image</param>
        /// <param name="lesOeuvres">Une ObservableCollection qui contiendra les oeuvres de la Bibliothèque</param>
        /// <param name="guid">Le string du Guid pour la création</param>
        public Bibliothèque(String nom, String image, ObservableCollection<Oeuvre> lesOeuvres, string guid)
        {
            Nom = nom;
            Image = image;
            if (lesOeuvres != null)
            {
                lesOeuvres.ToList().ForEach(oeuvre => AjouterOeuvre(oeuvre));
            }
            Guid = Guid.Parse(guid);
        }

        /// <summary>
        /// Indexeur permettant d'obtenir et de modifier les oeuvres à une certaine position
        /// </summary>
        /// <param name="index">La position de l'oeuvre</param>
        /// <returns>L'oeuvre cherchée via le getter, null si l'index est hors limite</returns>
        public Oeuvre this[int index]
        {
            get
            {
                if (index >= NombreOeuvre() || index < 0)
                {
                    return null;
                }
                return LesOeuvres[index];
            }
            private set { }
        }

        /// <summary>
        /// Indexeur permettant d'obtenir les oeuvres à partir de leur nom
        /// </summary>
        /// <param name="nom">Le nom de l'oeuvre à chercher</param>
        /// <returns>Retourne l'oeuvre trouvée, ou null si elle n'est pas présente</returns>
        public Oeuvre this[String nom]
        {
            get
            {
                return ObtenirOeuvre(nom);
            }
            private set { }
        }

        /// <summary>
        /// Permet d'ajouter une oeuvre à la bibliothèque si elle n'est pas déjà présente
        /// </summary>
        /// <param name="oeuvre">L'oeuvre à ajouter</param>
        /// <returns>True si l'oeuvre a bien été ajoutée, false si elle était déjà présente</returns>
        public bool AjouterOeuvre(Oeuvre oeuvre)
        {
            if(! ContientOeuvre(oeuvre))
            {
                LesOeuvres.Add(oeuvre);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Permet de retirer une oeuvre de la bibliothèque
        /// </summary>
        /// <param name="oeuvre">L'oeuvre à retirer</param>
        /// <returns>Retourne true si cela s'est bien passé, false si l'oeuvre n'était pas présente</returns>
        public bool RetirerOeuvre(Oeuvre oeuvre) => LesOeuvres.Remove(oeuvre);

        /// <summary>
        /// Permet de retirer une oeuvre de la bibliothèque à partir de son Nom
        /// </summary>
        /// <param name="nom">Le nom de l'oeuvre à retirer</param>
        /// <returns>Retourne true si cela s'est bien passé, false si l'oeuvre n'était pas présente</returns>
        public bool RetirerOeuvre(String nom)
        {
            Oeuvre oeuvre = ObtenirOeuvre(nom);
            if (oeuvre != null) return RetirerOeuvre(oeuvre);
            return false;
        }

        /// <summary>
        /// Permet de savoir si la Bibliothèque contient l'oeuvre passée en paramètre
        /// </summary>
        /// <param name="oeuvre">L'oeuvre à chercher</param>
        /// <returns>Renvoie true si elle est à l'intérieur, false sinon</returns>
        public bool ContientOeuvre(Oeuvre oeuvre) => LesOeuvres.Contains(oeuvre);

        /// <summary>
        /// Permet de savoir si la Bibliothèque contient une oeuvre avec le même nom passé en paramètre
        /// </summary>
        /// <param name="nomOeuvre">Le nom de l'oeuvre à chercher</param>
        /// <returns>Renvoie true si elle est à l'intérieur, false sinon</returns>
        public bool ContientOeuvre(String nomOeuvre) => ObtenirOeuvre(nomOeuvre) == null ? false : true;

        /// <summary>
        /// Retourne l'oeuvre possédant le nom passé en paramètre, ou null si elle n'existe pas
        /// </summary>
        /// <param name="nomOeuvre">Le nom de l'oeuvre à chercher</param>
        /// <returns>Retourne l'oeuvre trouvée, ou null si aucune n'est trouvée</returns>
        public Oeuvre ObtenirOeuvre(String nomOeuvre) => LesOeuvres.SingleOrDefault(oeuvre => oeuvre.Nom.Equals(nomOeuvre));

        /// <summary>
        /// Permet de rechercher les oeuvres ayant des données similaires à celle passée en paramètre
        /// Les paramètres null ne seront pas considérés
        /// </summary>
        /// <param name="charNom">Une chaine de caractère présente dans le nom de l'oeuvre. Null si non souhaité</param>
        /// <param name="type">Le type d'oeuvre à rechercher. Ne peut être null, mais Type.Tout est présent pour toutes les oeuvres</param>
        /// <param name="date">Allié au paramètre 'quand', permet de sélectionner une oeuvre suivant sa date de sortie. Null si non souhaité</param>
        /// <param name="quand">Permet de dire si l'on cherche une date similaire, antérieure ou postérieure à celle passée en paramètre. Si la date est null
        /// ce paramètre devra être non null, mais ne changera pas la recherche</param>
        /// <param name="charCréateurAuteurRéalisateur">Une chaine de caractère présente dans le nom du créateur/de l'auteur/du réalisateur. Null si non souhaité</param>
        /// <param name="charStudioÉditeur">Une chaine de caractère présente dans le nom du studio/de l'éditeur. Null si non souhaité</param>
        /// <param name="motclé1">Une chaine de caractère présente dans les informations, le commentaire ou encore le synopsis. Null si non souhaité</param>
        /// <param name="motclé2">Une chaine de caractère présente dans les informations, le commentaire ou encore le synopsis. Null si non souhaité</param>
        /// <param name="motclé3">Une chaine de caractère présente dans les informations, le commentaire ou encore le synopsis. Null si non souhaité</param>
        /// <returns>Renvoie la collection d'oeuvre trouvée, celle-ci pouvant être vide</returns>
        public ObservableCollection<Oeuvre> RechercherOeuvre(String charNom, TypeOeuvre type, DateTime date, DateQuand quand,
            String charCréateurAuteurRéalisateur, String charStudioÉditeur, String motclé1, String motclé2, String motclé3)
        {
            ObservableCollection<Oeuvre> recherche = new ObservableCollection<Oeuvre>();

            //Permet de récupérer toutes les oeuvres d'un même type, ou toutes les oeuvres si le type est Type.Tout.
            Tri.OeuvresDuType(LesOeuvres, type).ToList().ForEach(oeuvre => recherche.Add(oeuvre));

            //Retire les oeuvres n'ayant pas la chaine de caractère dans leur nom
            if (charNom != null)
            {
                List<Oeuvre> àRetirer = new List<Oeuvre>();
                recherche.Where(oeuvre => !oeuvre.Nom.ToLower().Contains(charNom.ToLower())).ToList().ForEach(oeuvre => àRetirer.Add(oeuvre));
                àRetirer.ForEach(oeuvre => recherche.Remove(oeuvre));
            }

            //Retire les oeuvres n'entrant pas la sélection souhaitée
            if (date != null)
            {
                switch (quand)
                {
                    case DateQuand.NonUtilisé:
                        break;
                    case DateQuand.Avant:
                        var toRemove1 = recherche.ToList().Where(oeuvre => oeuvre.Sortie.Year.CompareTo(date.Year) >= 0);
                        toRemove1.ToList().ForEach(oeuvre => recherche.Remove(oeuvre));
                        break;
                    case DateQuand.Pendant:
                        var toRemove2 = recherche.ToList().Where(oeuvre => oeuvre.Sortie.Year.CompareTo(date.Year) != 0);
                        toRemove2.ToList().ForEach(oeuvre => recherche.Remove(oeuvre));
                        break;
                    case DateQuand.Après:
                        var toRemove3 = recherche.ToList().Where(oeuvre => oeuvre.Sortie.Year.CompareTo(date.Year) <= 0);
                        toRemove3.ToList().ForEach(oeuvre => recherche.Remove(oeuvre));
                        break;
                }
            }
            
            //Retire les oeuvres n'ayant pas la chaine de caractère souhaitée dans leurs informations
            if(charCréateurAuteurRéalisateur != null)
            {
                List<Oeuvre> àRetirer = new List<Oeuvre>();

                recherche.ToList().Where(oeuvre => oeuvre is Cinématographique)
                    .Where(oeuvre => !(oeuvre as Cinématographique).Réalisateur.ToLower().Contains(charCréateurAuteurRéalisateur.ToLower()))
                    .ToList().ForEach(oeuvre => àRetirer.Add(oeuvre));

                recherche.ToList().Where(oeuvre => oeuvre is Littéraire)
                    .Where(oeuvre => !(oeuvre as Littéraire).Auteur.ToLower().Contains(charCréateurAuteurRéalisateur.ToLower()))
                    .ToList().ForEach(oeuvre => àRetirer.Add(oeuvre));

                recherche.ToList().Where(oeuvre => oeuvre is Animé)
                    .Where(oeuvre => !(oeuvre as Animé).Auteur.ToLower().Contains(charCréateurAuteurRéalisateur.ToLower()))
                    .ToList().ForEach(oeuvre => àRetirer.Add(oeuvre));

                recherche.ToList().Where(oeuvre => oeuvre is Autre)
                    .Where(oeuvre => !(oeuvre as Autre).Créateur.ToLower().Contains(charCréateurAuteurRéalisateur.ToLower()))
                    .ToList().ForEach(oeuvre => àRetirer.Add(oeuvre));

                àRetirer.ForEach(oeuvre => recherche.Remove(oeuvre));
            }
            if (charStudioÉditeur != null)
            {
                List<Oeuvre> àRetirer = new List<Oeuvre>();

                recherche.ToList().Where(oeuvre => oeuvre is Cinématographique)
                    .Where(oeuvre => !(oeuvre as Cinématographique).Studio.ToLower().Contains(charStudioÉditeur.ToLower()))
                    .ToList().ForEach(oeuvre => àRetirer.Add(oeuvre));

                recherche.ToList().Where(oeuvre => oeuvre is Littéraire)
                    .Where(oeuvre => !(oeuvre as Littéraire).Éditeur.ToLower().Contains(charStudioÉditeur.ToLower()))
                    .ToList().ForEach(oeuvre => àRetirer.Add(oeuvre));

                recherche.ToList().Where(oeuvre => oeuvre is Animé)
                    .Where(oeuvre => !(oeuvre as Animé).Studio.ToLower().Contains(charStudioÉditeur.ToLower()))
                    .ToList().ForEach(oeuvre => àRetirer.Add(oeuvre));

                àRetirer.ForEach(oeuvre => recherche.Remove(oeuvre));
            }


            //Retire les oeuvres si le mot clé n'est pas présent au moins une fois
            List<Oeuvre> àRetirerMotClé = new List<Oeuvre>();
            if (motclé1 != null)
            {
                recherche.ToList().Where(oeuvre => oeuvre.ContientMotClé(motclé1) < 1)
                    .ToList().ForEach(oeuvre => àRetirerMotClé.Add(oeuvre));
            }
            if (motclé2 != null)
            {
                recherche.ToList().Where(oeuvre => oeuvre.ContientMotClé(motclé2) < 1)
                    .ToList().ForEach(oeuvre => àRetirerMotClé.Add(oeuvre));
            }
            if (motclé3 != null)
            {
                recherche.ToList().Where(oeuvre => oeuvre.ContientMotClé(motclé3) < 1)
                    .ToList().ForEach(oeuvre => àRetirerMotClé.Add(oeuvre));
            }
            àRetirerMotClé.ForEach(oeuvre => recherche.Remove(oeuvre));

            return recherche;
        }

        /// <summary>
        /// Donne le nombre d'oeuvres présentes dans la bibliothèque
        /// </summary>
        /// <returns>Le nombre d'oeuvres présentes dans cette bibliothèque</returns>
        public int NombreOeuvre() => LesOeuvres.Count;

        /// <summary>
        /// Vérifie si les deux bibliothèques possèdent le même nom
        /// </summary>
        /// <param name="biblio">la bibliothèque à comparer</param>
        /// <returns>True si la bibliothèque possède le même nom, false sinon</returns>
        public bool Equals(Bibliothèque biblio) => Nom.Equals(biblio.Nom);

        /// <summary>
        ///  Vérifie si les deux bibliothèques possèdent le même nom ou que c'est le même objet
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>True si c'est la même bibliothèque, false sinon</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as Bibliothèque);
        }

        /// <summary>
        /// Définit la fonction de Hashage de la Bibliothèque à partir du Guid
        /// </summary>
        /// <returns>Retourne le Hashage du Guid de l'oeuvre</returns>
        public override int GetHashCode() => Guid.GetHashCode();

        /// <summary>
        /// Donne le nom de la bibliothèque
        /// </summary>
        /// <returns>Le nom de la bibliothèque</returns>
        public override string ToString() => Nom;

        /// <summary>
        /// Donne le message d'erreur pour la propriété avec le nom donné
        /// </summary>
        /// <param name="columnName">Le nom de la propriété pour laquelle on veut le message d'erreur</param>
        /// <returns>Le message d'erreur de la propriété de la classe</returns>
        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                switch(columnName)
                {
                    case "Nom":
                        return string.IsNullOrEmpty(Nom) ? "Nom requis" : Nom.Length > 16 ? "Max 16 caractères" : null;
                    default:
                        return null;
                }
            }
        }
    }
}
