using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Iut.MasterAnime.ClassLibrary
{
    /// <summary>
    /// Représente une oeuvre de l'application
    /// </summary>
    public abstract class Oeuvre : ObservableObject, IEquatable<Oeuvre>, IDataErrorInfo
    {
        /// <summary>
        /// Le nom de l'oeuvre ainsi que son getter et setter
        /// Il est requis et possède 16 caractères maximum
        /// </summary>
        [Required]
        [MaxLength(16, ErrorMessage = "Maximum 16 caractères")]
        [MinLength(1, ErrorMessage = "Minimum 1 caractère")]
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
        /// La source de l'image de l'oeuvre ainsi que son getter et setter
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
        /// La date de sortie de l'oeuvre ainsi que son getter et setter
        /// </summary>
        public DateTime Sortie
        {
            get => sortie;
            set
            {
                sortie = value;
                OnPropertyChanged();
            }
        }
        private DateTime sortie;

        /// <summary>
        /// ObservableDictionary contenant des informations sur l'oeuvre sous la forme de couple (nomInfo, Info) ainsi que son getter et setter
        /// Le setter est privé car il ne doit pas être modifié, on ne peut modifier que ses éléments à l'intérieur
        /// </summary>
        public ObservableDictionary<StringVérifié, StringVérifié> InformationsComplémentaires { get; private set; }

        /// <summary>
        /// Le synopsis de l'oeuvre ainsi que son getter et setter
        /// </summary>
        public String Synopsis
        {
            get => synopsis;
            set
            {
                synopsis = value;
                OnPropertyChanged();
            }
        }
        private String synopsis;

        /// <summary>
        /// Un commentaire personnel de l'utilisateur sur l'oeuvre ainsi que son getter et setter
        /// </summary>
        public String Commentaire
        {
            get => commentaire;
            set
            {
                commentaire = value;
                OnPropertyChanged();
            }
        }
        private String commentaire;

        /// <summary>
        /// Un Guid permettant d'avoir un GetHashCode unique à chaque Oeuvre car on prend celui du Guid
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
        /// Contructeur de la classe Oeuvre
        /// </summary>
        /// <param name="nom">Le nom de l'oeuvre</param>
        /// <param name="sortie">La date de sortie de l'oeuvre, en DateTime. Par défaut celle d'aujoud'hui</param>
        /// <param name="image">Le nom et le de l'image de l'oeuvre. Par défaut : "PlacerImage.png"</param>
        /// <param name="sortie">La date de sortie de l'oeuvre, en DateTime</param>
        /// <param name="informationsComplémentaires">Un ObservableDictionary contenant des informations sur l'oeuvre sous la forme de couple (sortieInfo, Info). Si null est initialisé</param>
        /// <param name="synopsis">Le synopsis de l'oeuvre. Par défaut : "Inconnu"</param>
        /// <param name="commentaire">Un commentaire personnel de l'utilisateur sur l'oeuvre. Par défaut : "Inconnu"</param>
        public Oeuvre(String nom, String image, DateTime sortie, ObservableDictionary<StringVérifié, StringVérifié> informationsComplémentaires,
            String synopsis, String commentaire)
        {
            Nom = nom;
            Image = String.IsNullOrEmpty(image) ? "PlacerImage.png" : image;
            Sortie = sortie == null ? DateTime.Today : sortie;
            InformationsComplémentaires = informationsComplémentaires;
            Synopsis = String.IsNullOrEmpty(synopsis) ? "Inconnu" : synopsis;
            Commentaire = String.IsNullOrEmpty(commentaire) ? "Inconnu" : commentaire;
        }

        /// <summary>
        /// Contructeur de la classe Oeuvre. Celui-ci permet d'instancier un guid à partir d'un connu, pour la persistance
        /// </summary>
        /// <param name="nom">Le nom de l'oeuvre</param>
        /// <param name="sortie">La date de sortie de l'oeuvre, en DateTime. Par défaut celle d'aujoud'hui</param>
        /// <param name="image">Le nom et le de l'image de l'oeuvre. Par défaut : "PlacerImage.png"</param>
        /// <param name="sortie">La date de sortie de l'oeuvre, en DateTime</param>
        /// <param name="informationsComplémentaires">Un ObservableDictionary contenant des informations sur l'oeuvre sous la forme de couple (sortieInfo, Info). Si null est initialisé</param>
        /// <param name="synopsis">Le synopsis de l'oeuvre. Par défaut : "Inconnu"</param>
        /// <param name="commentaire">Un commentaire personnel de l'utilisateur sur l'oeuvre. Par défaut : "Inconnu"</param>
        /// <param name="guid">Le string du Guid pour la création</param>
        public Oeuvre(String nom, String image, DateTime sortie, ObservableDictionary<StringVérifié, StringVérifié> informationsComplémentaires,
            String synopsis, String commentaire, string guid)
        {
            Nom = nom;
            Image = String.IsNullOrEmpty(image) ? "PlacerImage.png" : image;
            Sortie = sortie == null ? DateTime.Today : sortie;
            InformationsComplémentaires = informationsComplémentaires;
            Synopsis = String.IsNullOrEmpty(synopsis) ? "Inconnu" : synopsis;
            Commentaire = String.IsNullOrEmpty(commentaire) ? "Inconnu" : commentaire;
            Guid = Guid.Parse(guid);
        }

        /// <summary>
        /// Permet d'ajouter une information complémentaire dans le ObservableDictionary
        /// </summary>
        /// <param name="nomInfo">La clé de l'information, c'est également le nom qui sera affiché</param>
        /// <param name="info">L'information en elle même</param>
        public void AjouterInformation(StringVérifié nomInfo, StringVérifié info) => InformationsComplémentaires[nomInfo] = info;

        /// <summary>
        /// Permet de retirer une information complémentaire dans le ObservableDictionary
        /// </summary>
        /// <param name="nomInfo">La clé de l'information, c'est également le nom qui sera affiché</param>
        /// <returns>Renvoie true si l'élément a bien était retiré, et false si il n'a pas été trouvé</returns>
        public bool RetirerInformation(StringVérifié nomInfo) => InformationsComplémentaires.Remove(nomInfo);

        /// <summary>
        /// Permet d'effacer toutes les informations complémentaires de l'oeuvre
        /// </summary>
        public void ClearInformation() => InformationsComplémentaires.Clear();

        /// <summary>
        /// Permet de rechercher une information complémentaire dans le ObservableDictionary
        /// </summary>
        /// <param name="nomInfo">La clé de l'information, c'est également le nom qui sera affiché</param>
        /// <returns>Renvoie l'information reliée à la clé, ou null si elle n'existe pas</returns>
        public StringVérifié RechercherInformation(StringVérifié nomInfo)
        {
            StringVérifié value = new StringVérifié("");
            
            if(InformationsComplémentaires.TryGetValue(nomInfo, out value))
            {
                return value;
            } else
            {
                return null;
            }
        }

        /// <summary>
        /// Donne les informations complémentaires de l'oeuvre
        /// </summary>
        /// <returns>Les informations complémentaires de l'oeuvre</returns>
        public String InfoToString()
        {
            String retour = "";
            foreach (StringVérifié nomInfo in InformationsComplémentaires.Keys)
            {
                retour += $"{nomInfo} : {InformationsComplémentaires[nomInfo]}\n";
            }
            return retour;
        }

        /// <summary>
        /// Permet de compter combien de fois apparait la chaine de caractère dans l'oeuvre (commentaire, synopsis et informations complémentaires)
        /// On ne prend pas en compte les majuscules et minuscules
        /// </summary>
        /// <param name="chaine">La chaine de caractère qui doit être recherchée</param>
        /// <returns>Retourne le nombre de fois qu'apparait la chaine de caractère</returns>
        public int ContientMotClé(String chaine)
        {
            int nombreFois = 0;
            chaine = chaine.ToLower();

            String[] motsCommentaire = Commentaire.ToLower().Split();

            foreach(String mot in motsCommentaire)
            {
                nombreFois += mot.Contains(chaine) ? 1 : 0;
            }

            String[] motsSynopsis = Synopsis.ToLower().Split();

            foreach (String mot in motsSynopsis)
            {
                nombreFois += mot.Contains(chaine) ? 1 : 0;
            }

            foreach (StringVérifié mot in InformationsComplémentaires.Keys)
            {
                nombreFois += mot.ToString().ToLower().Contains(chaine) ? 1 : 0;
            }

            foreach (StringVérifié mot in InformationsComplémentaires.Values)
            {
                nombreFois += mot.ToString().ToLower().Contains(chaine) ? 1 : 0;
            }

            return nombreFois;
        }

        /// <summary>
        /// Vérifie si les deux oeuvres possèdent le même nom
        /// </summary>
        /// <param name="oeuvre">L'oeuvre à comparer</param>
        /// <returns>True si l'oeuvre possède le même nom, false sinon</returns>
        public bool Equals(Oeuvre oeuvre) => Nom.Equals(oeuvre.Nom);

        /// <summary>
        /// Vérifie si les deux oeuvres possèdent le même nom ou que c'est le même objet
        /// </summary>
        /// <param name="obj">L'objet à comparer</param>
        /// <returns>True si c'est la même oeuvre, false sinon</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as Oeuvre);
        }

        /// <summary>
        /// Définit la fonction de Hashage de l'oeuvre à partir du Guid
        /// </summary>
        /// <returns>Retourne le Hashage du Guid de l'oeuvre</returns>
        public override int GetHashCode() => Guid.GetHashCode();

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
                    default:
                        return null;
                }
            }
        }

    }
}
