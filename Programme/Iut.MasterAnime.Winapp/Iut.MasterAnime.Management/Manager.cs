using System;
using System.Collections.ObjectModel;
using Iut.MasterAnime.ClassLibrary;
using System.Linq;
using Iut.MasterAnime.Persistance;

namespace Iut.MasterAnime.Management
{
    /// <summary>
    /// Cette classe permettra de gérer les différentes classes de l'application
    /// </summary>
    public class Manager : ObservableObject
    {
        /// <summary>
        /// La Bibliothèque qui contiendra toutes les oeuvres de l'application ainsi que son getter et setter
        /// Le setter est privé car on n'a pas besoin de modifier la classe, hormis avec les fonctions de la classe déjà proposées
        /// </summary>
        public Bibliothèque ListePrincipale { get; private set; } = new Bibliothèque("Liste Principale", "AnimeLike.jpg", new ObservableCollection<Oeuvre>());

        /// <summary>
        /// Les différentes Bibliothèques de l'application ainsi que son getter et setter
        /// Le setter est privé car on n'a pas besoin de modifier la collection, juste d'ajouter ou supprimer des Bibliothèques
        /// </summary>
        public ObservableCollection<Bibliothèque> LesBibliothèques { get; private set; } = new ObservableCollection<Bibliothèque>();

        /// <summary>
        /// L'interface permettant de gérer les données
        /// </summary>
        public IBibliothèqueDataManager BibliothèqueDataManager { get; private set; }

        /// <summary>
        /// La Bibliothèque sélectionnée. Permet de mieux gérer l'affichage
        /// </summary>
        public Bibliothèque BibliothèqueSélectionnée
        {
            get => bibliothèqueSélectionnée;
            set
            {
                bibliothèqueSélectionnée = value;
                OnPropertyChanged();
            }
        }
        private Bibliothèque bibliothèqueSélectionnée;

        /// <summary>
        /// L'Oeuvre sélectionnée. Permet de mieux gérer l'affichage
        /// </summary>
        public Oeuvre OeuvreSélectionnée
        {
            get => oeuvreSélectionnée;
            set
            {
                oeuvreSélectionnée = value;
                OnPropertyChanged();
            }
        }
        private Oeuvre oeuvreSélectionnée;

        /// <summary>
        /// Toutes les bibliothèques, y comprit la ListePrincipale, sont contenues dans cette dernière. Permet de mieux gérer l'affichage
        /// </summary>
        public ObservableCollection<Bibliothèque> VuDesBibliothèques { get; private set; } = new ObservableCollection<Bibliothèque>();

        /// <summary>
        ///// Le constructeur de la classe Manager
        /// </summary>
        /// <param name="IBibliothèqueDataManager">Cette interface permet de récupérer et gérer les données</param>
        public Manager(IBibliothèqueDataManager iBibliothèqueDataManager)
        {
            if (!String.IsNullOrWhiteSpace(iBibliothèqueDataManager.ObtenirPrincipale().Nom))
            {
                ListePrincipale.Nom = iBibliothèqueDataManager.ObtenirPrincipale().Nom;
            }

            if (!String.IsNullOrWhiteSpace(iBibliothèqueDataManager.ObtenirPrincipale().Image))
            {
                ListePrincipale.Image = iBibliothèqueDataManager.ObtenirPrincipale().Image;
            }

            VuDesBibliothèques.Add(ListePrincipale);

            iBibliothèqueDataManager.ObtenirPrincipale().LesOeuvres.ToList().ForEach(oeuvre => AjouterOeuvre(oeuvre));

            BibliothèqueDataManager = iBibliothèqueDataManager;

            iBibliothèqueDataManager.ObtenirTous().ToList().ForEach(biblio => AjouterBibliothèque(biblio));

            //Met à jour la persistance si elle avait plusieurs bibliothèques du même nom ou que le nom/l'image de ListePrincipale était null ou vide
            for(int i=0; i < iBibliothèqueDataManager.ObtenirTous().Count(); i++)
            {
                if(! LesBibliothèques.Contains(iBibliothèqueDataManager.ObtenirTous().ToList()[i]))
                {
                    iBibliothèqueDataManager.Retirer(iBibliothèqueDataManager.ObtenirTous().ToList()[i]);
                }
            }

            //Met à jour la persistance si les informations n'étaient pas conformes
            iBibliothèqueDataManager.ObtenirPrincipale().Nom = ListePrincipale.Nom;
            iBibliothèqueDataManager.ObtenirPrincipale().Image = ListePrincipale.Image;
            //Met à jour la persistance si elle avait plusieurs oeuvres du même nom ou qu'une des bibliothèques n'a pas été chargé et ses oeuvres non plus
            for (int i = 0; i < iBibliothèqueDataManager.ObtenirPrincipale().LesOeuvres.Count; i++)
            {
                if (!ListePrincipale.ContientOeuvre(iBibliothèqueDataManager.ObtenirPrincipale().LesOeuvres[i]))
                {
                    iBibliothèqueDataManager.ObtenirPrincipale().RetirerOeuvre(iBibliothèqueDataManager.ObtenirPrincipale().LesOeuvres[i]);
                }
            }
            iBibliothèqueDataManager.SauvegarderDonnées(ListePrincipale, LesBibliothèques);

            BibliothèqueSélectionnée = ListePrincipale;
            OeuvreSélectionnée = null;
        }

        /// <summary>
        /// Indexeur permettant d'obtenir et de modifier les bibliothèques à une certaine position. La ListePrincipale n'est pas prise en compte
        /// </summary>
        /// <param name="index">La position de la bibliothèque</param>
        /// <returns>La bibliothèque cherchée via le getter ou null si l'indexeur est hors limite</returns>
        public Bibliothèque this[int index]
        {
            get
            {
                if (index >= NombreBibliothèque() || index < 0)
                {
                    return null;
                }
                return LesBibliothèques[index];
            }
            private set { }
        }

        /// <summary>
        /// Indexeur permettant d'obtenir les bibliothèques à partir de leur nom. La ListePrincipale n'est pas prise en compte
        /// </summary>
        /// <param name="nom">Le nom de la bibliothèque à chercher</param>
        /// <returns>Retourne la bibliothèque trouvée, ou null si elle n'est pas présente</returns>
        public Bibliothèque this[String nom]
        {
            get
            {
                return ObtenirBibliothèque(nom);
            }
            private set { }
        }

        /// <summary>
        /// Permet de sauvegarder les données de l'application dans le fichier de persistance
        /// </summary>
        public void SauvegarderLesDonnées()
        {
            BibliothèqueDataManager?.SauvegarderDonnées(ListePrincipale, LesBibliothèques);
        }

        /// <summary>
        /// Permet de charger les données de l'application à partir du fichier de persistance
        /// </summary>
        public void ChargerLesDonnées()
        {
            if (BibliothèqueDataManager == null) return;
            
            BibliothèqueDataManager.Charger();

            if (!String.IsNullOrWhiteSpace(BibliothèqueDataManager.ObtenirPrincipale().Nom))
            {
                ListePrincipale.Nom = BibliothèqueDataManager.ObtenirPrincipale().Nom;
            }

            if (!String.IsNullOrWhiteSpace(BibliothèqueDataManager.ObtenirPrincipale().Image))
            {
                ListePrincipale.Image = BibliothèqueDataManager.ObtenirPrincipale().Image;
            }

            BibliothèqueDataManager.ObtenirPrincipale().LesOeuvres.ToList().ForEach(oeuvre => AjouterOeuvre(oeuvre));

            BibliothèqueDataManager.ObtenirTous().ToList().ForEach(biblio => AjouterBibliothèque(biblio));

            //Met à jour la persistance si elle avait plusieurs bibliothèques du même nom ou que le nom/l'image de ListePrincipale était null ou vide
            for (int i = 0; i < BibliothèqueDataManager.ObtenirTous().Count(); i++)
            {
                if (!LesBibliothèques.Contains(BibliothèqueDataManager.ObtenirTous().ToList()[i]))
                {
                    BibliothèqueDataManager.Retirer(BibliothèqueDataManager.ObtenirTous().ToList()[i]);
                }
            }

            //Met à jour la persistance si les informations n'étaient pas conformes
            BibliothèqueDataManager.ObtenirPrincipale().Nom = ListePrincipale.Nom;
            BibliothèqueDataManager.ObtenirPrincipale().Image = ListePrincipale.Image;
            //Met à jour la persistance si elle avait plusieurs oeuvres du même nom ou qu'une des bibliothèques n'a pas été chargé et ses oeuvres non plus
            for (int i = 0; i < BibliothèqueDataManager.ObtenirPrincipale().LesOeuvres.Count; i++)
            {
                if (!ListePrincipale.ContientOeuvre(BibliothèqueDataManager.ObtenirPrincipale().LesOeuvres[i]))
                {
                    BibliothèqueDataManager.ObtenirPrincipale().RetirerOeuvre(BibliothèqueDataManager.ObtenirPrincipale().LesOeuvres[i]);
                }
            }

            SauvegarderLesDonnées();
        }

        /// <summary>
        /// Ajoutera la bibliothèque à l'application si il en existe pas une avec le même nom
        /// </summary>
        /// <param name="bibliothèque">La bibliothèque à ajouter à l'application</param>
        /// <returns>Retourne true si cela a fonctionné, et false sinon</returns>
        public bool AjouterBibliothèque(Bibliothèque bibliothèque)
        {
            //On vérifie qu'il n'existe pas déjà cette Bibliothèque, ou une avec le même nom
            if(! LesBibliothèques.Contains(bibliothèque) && ! ListePrincipale.Equals(bibliothèque))
            {
                LesBibliothèques.Add(bibliothèque);

                //Ajoute les oeuvres de la bibliothèque à l'application
                for (int i = 0; i < bibliothèque.LesOeuvres.Count; i++)
                {
                    //Vérifie si la Liste principale possède déjà une oeuvre avec le même nom
                    if (!AjouterOeuvre(bibliothèque.LesOeuvres[i]))
                    {
                        //Met à jour la bibliothèque ajoutée si une de ses oeuvres a le même nom qu'une déjà existante
                        String nom = bibliothèque.LesOeuvres[i].Nom;
                        bibliothèque.RetirerOeuvre(bibliothèque.LesOeuvres[i]);
                        bibliothèque.AjouterOeuvre(ListePrincipale.ObtenirOeuvre(nom));
                    }
                }
                
                BibliothèqueDataManager.Ajouter(bibliothèque);

                VuDesBibliothèques.Add(bibliothèque);

                return true;
            }
            return false;
        }

        /// <summary>
        /// Modifie la bibliothèque possédant le même nom passé en paramètre.
        /// </summary>
        /// <param name="nom">Le nom de la Bibliothèque à modifier</param>
        /// <param name="newNom">Le nouveau nom à donner. Null si aucune modification</param>
        /// <param name="newImage">Le nouveau chemin de l'image. Null si aucune modification</param>
        /// <param name="lesOeuvres">La nouvelle collection d'oeuvres. Null si aucune modification</param>
        /// <returns>Si cela s'est bien passé, retourne true, et false si aucune bibliothèque n'a était trouvée ou que le nouveau nom existe déjà</returns>
        public bool ModifierBibliothèque(String nom, String newNom, String newImage, ObservableCollection<Oeuvre> lesOeuvres)
        {
            Bibliothèque laBiblio = ObtenirBibliothèque(nom);

            if (laBiblio == null)
            {
                return false;
            }

            //Si le nom n'a pas était changé le count suivant possèdera une bibliothèque en plus
            int i = nom == newNom ? 1 : 0;
            //Si il existe déjà une bibliothèque avec ce nouveau nom
            if(LesBibliothèques.ToList().Where(biblio => biblio.Nom.Equals(newNom)).Count() > i)
            {
                return false;
            }

            laBiblio.Nom = newNom == null ? laBiblio.Nom : newNom;
            laBiblio.Image = newImage == null ? laBiblio.Image : newImage;

            if(lesOeuvres != null)
            {
                laBiblio.LesOeuvres.Clear();
                foreach(Oeuvre oeuvre in lesOeuvres)
                {
                    if(AjouterOeuvre(oeuvre))
                    {
                        laBiblio.AjouterOeuvre(oeuvre);
                    } else
                    {
                        //Si une oeuvre possède déjà ce nom, elle sea ajoutée dans la bibliothèque à la place de la nouvelle
                        laBiblio.AjouterOeuvre(ListePrincipale.ObtenirOeuvre(oeuvre.Nom));
                    }
                }
            }

            SauvegarderLesDonnées();

            return true;
        }

        /// <summary>
        /// Modifie la Bibliothèque possédant le nom passé en paramètre par rapport à celle passé également en paramètres
        /// </summary>
        /// <param name="nom">Le nom de la Bibliothèque à modifier</param>
        /// <param name="bibliothèque">La Bibliothèque où l'on récupère les informations à mettre à jour</param>
        /// <returns>Si cela s'est bien passé, retourne true, et false si aucune bibliothèque ne possède le même nom</returns>
        public bool ModifierBibliothèque(String nom, Bibliothèque bibliothèque) 
            => ModifierBibliothèque(nom, bibliothèque.Nom, bibliothèque.Image, bibliothèque.LesOeuvres);

        /// <summary>
        /// Supprime la bibliothèque passée en paramètre
        /// </summary>
        /// <param name="bibliothèque">La bibliothèque à supprimer</param>
        /// <returns>Retourne true si cela s'est bien passé, false si elle n'y était pas ou que c'est la liste principale</returns>
        public bool RetirerBibliothèque(Bibliothèque bibliothèque)
        {
            if (bibliothèque == ListePrincipale) return false;
            if (BibliothèqueSélectionnée.Equals(bibliothèque)) BibliothèqueSélectionnée = ListePrincipale;
            BibliothèqueDataManager.Retirer(bibliothèque);
            VuDesBibliothèques.Remove(bibliothèque);
            bool retour = LesBibliothèques.Remove(bibliothèque);
            return retour;
        }

        /// <summary>
        /// Supprime la biliothèque possédant le nom donné
        /// </summary>
        /// <param name="nom">Le nom de la bibliothèque à supprimer</param>
        /// <returns>Retourne true si cela a fonctionné, false si aucune bibliothèque n'a ce nom</returns>
        public bool RetirerBibliothèque(String nom)
        {
            Bibliothèque laBiblio = ObtenirBibliothèque(nom);
            
            if (laBiblio == null)
            {
                return false;
            }
            return RetirerBibliothèque(laBiblio);
        }

        /// <summary>
        /// Retourne la bibliothèque possédant le nom passé en paramètre, ou null si elle n'existe pas
        /// </summary>
        /// <param name="nom">Le nom de la bibliothèque à chercher</param>
        /// <returns>Retourne la bibliothèque trouvée, ou null si aucune n'est trouvée</returns>
        public Bibliothèque ObtenirBibliothèque(String nom) => VuDesBibliothèques.SingleOrDefault(biblio => biblio.Nom.Equals(nom));

        /// <summary>
        /// Retournera les Bibliothèques possédant le mot clé dans leur nom
        /// </summary>
        /// <param name="motClé">La chaine de caractère à rechercher</param>
        /// <returns>La collection de Bibliothèques trouvées</returns>
        public ObservableCollection<Bibliothèque> RechercherBibliothèque(String motClé)
        {
            ObservableCollection<Bibliothèque> trouvées = new ObservableCollection<Bibliothèque>();
            foreach(Bibliothèque biblio in VuDesBibliothèques)
            {
                if(biblio.Nom.ToLower().Contains(motClé))
                {
                    trouvées.Add(biblio);
                }
            }
            return trouvées;
        }

        /// <summary>
        /// Retourne le nombre de bibliothèque présentes dans le manager. La ListePrincipale n'est pas prise en compte
        /// </summary>
        /// <returns>Le nombre de bibliothèques présentes dans ce manager</returns>
        public int NombreBibliothèque() => LesBibliothèques.Count;

        /// <summary>
        /// Ajoutera l'oeuvre à l'application si il en n'existe pas déjà une avec le même nom.
        /// Les Bibliothèques passées en paramètre auront l'oeuvre ajoutée à leur liste.
        /// </summary>
        /// <param name="oeuvre">L'oeuvre à ajouter à l'application</param>
        /// <param name="bibliothèques">Les Bibliothèques qui auront cette oeuvre</param>
        /// <returns>Renvoie true si ça s'est bien passé, false sinon.</returns>
        public bool AjouterOeuvre(Oeuvre oeuvre, params Bibliothèque[] bibliothèques)
        {
            bool retour = ListePrincipale.AjouterOeuvre(oeuvre);
            if (retour)
            {
                bibliothèques.ToList().ForEach(biblio => biblio.AjouterOeuvre(oeuvre));
            }
            BibliothèqueDataManager?.Sauvegarder();
            return retour;
        }

        /// <summary>
        /// Permet de modifier les informations de l'oeuvre possédant le même nom que passé en paramètre.
        /// Les informations possédant une valeur null ne seront pas modifiées
        /// </summary>
        /// <param name="nom">Le nom de l'oeuvre à modifier</param>
        /// <param name="newNom">Le nouveau nom de l'oeuvre. Null si pas de changement</param>
        /// <param name="newImage">Le nouveau chemin de l'image. Null si pas de changement</param>
        /// <param name="newSortie">La nouvelle date de sortie. Null si pas de changement</param>
        /// <param name="newAuteurCréateurRéalisateur">Le nouveau nom du créateur/de l'auteur/du réalisateur (suivant le type de l'oeuvre). Null si pas de changement</param>
        /// <param name="newStudioÉditeur">Le nouveau nom du studio/de l'éditeur (suivant le type de l'oeuvre). Null si pas de changement</param>
        /// <param name="newInfo">Les nouvelles informations complémentaires. Null si pas de changement</param>
        /// <param name="newSynopsis">Le nouveau synopsis. Null si pas de changement</param>
        /// <param name="newCommentaire">Le nouveau commentaire. Null si pas de changement</param>
        /// <returns>Retourne false si il n'a pas trouvé d'oeuvre avec le même nom, true si cela s'est bien passé</returns>
        public bool ModifierOeuvre(String nom, String newNom, String newImage, DateTime newSortie, String newAuteurCréateurRéalisateur, String newStudioÉditeur,
            ObservableDictionary<StringVérifié, StringVérifié> newInfo, String newSynopsis, String newCommentaire)
        {
            if(! ListePrincipale.ContientOeuvre(nom))
            {
                return false;
            }
            Oeuvre oeuvre = ListePrincipale.ObtenirOeuvre(nom);

            if(oeuvre is Autre)
            {
                (oeuvre as Autre).ModifierOeuvre(newNom, newImage, newSortie, newAuteurCréateurRéalisateur, newInfo, newSynopsis, newCommentaire);
            }
            else if(oeuvre is Cinématographique)
            {
                (oeuvre as Cinématographique).ModifierOeuvre(newNom, newImage, newSortie, newAuteurCréateurRéalisateur, newStudioÉditeur, newInfo, newSynopsis, newCommentaire);
            }
            else if (oeuvre is Littéraire)
            {
                (oeuvre as Littéraire).ModifierOeuvre(newNom, newImage, newSortie, newAuteurCréateurRéalisateur, newStudioÉditeur, newInfo, newSynopsis, newCommentaire);
            }
            else if (oeuvre is Animé)
            {
                (oeuvre as Animé).ModifierOeuvre(newNom, newImage, newSortie, newAuteurCréateurRéalisateur, newStudioÉditeur, newInfo, newSynopsis, newCommentaire);
            }
            SauvegarderLesDonnées();
            return true;
        }

        /// <summary>
        /// Permet de modifier les informations de l'oeuvre possédant le même nom que passé en paramètre, à partir des informations d'une différente Oeuvre
        /// </summary>
        /// <param name="nom">Le nom de l'oeuvre à modifier</param>
        /// <param name="newOeuvre">L'oeuvre à partir de laquelle on récupère les informations à modifier</param>
        /// <returns></returns>
        public bool ModifierOeuvre(String nom, Oeuvre newOeuvre)
        {
            if (!ListePrincipale.ContientOeuvre(nom))
            {
                return false;
            }
            Oeuvre oeuvre = ListePrincipale.ObtenirOeuvre(nom);

            if (oeuvre is Autre)
            {
                (oeuvre as Autre).ModifierOeuvre(newOeuvre as Autre);
            }
            else if (oeuvre is Cinématographique)
            {
                (oeuvre as Cinématographique).ModifierOeuvre(newOeuvre as Cinématographique);
            }
            else if (oeuvre is Littéraire)
            {
                (oeuvre as Littéraire).ModifierOeuvre(newOeuvre as Littéraire);
            }
            else if (oeuvre is Animé)
            {
                (oeuvre as Animé).ModifierOeuvre(newOeuvre as Animé);
            }
            SauvegarderLesDonnées();
            return true;
        }

        /// <summary>
        /// Supprime l'oeuvre avec le même nom de l'application
        /// </summary>
        /// <param name="nom">Le nom de l'oeuvre à supprimer</param>
        /// <returns>Renvoie true si ça s'est bien passé, false si aucune oeuvre n'a ce nom</returns>
        public bool RetirerOeuvre(String nom)
        {
            LesBibliothèques.ToList().ForEach(biblio => biblio.RetirerOeuvre(nom));
            bool retour = ListePrincipale.RetirerOeuvre(nom);
            SauvegarderLesDonnées();
            return retour;
        }

        /// <summary>
        /// Supprime l'oeuvre de l'application
        /// </summary>
        /// <param name="oeuvre">L'oeuvre à supprimer</param>
        /// <returns>True si ça s'est bien passé, false sinon</returns>
        public bool RetirerOeuvre(Oeuvre oeuvre)
        {
            LesBibliothèques.ToList().ForEach(biblio => biblio.RetirerOeuvre(oeuvre));
            bool retour = ListePrincipale.RetirerOeuvre(oeuvre);
            SauvegarderLesDonnées();
            return retour;
        }

        /// <summary>
        /// Permet de supprimer toutes les bibliothèques et oeuvres de l'application
        /// </summary>
        public void RéinitialiserManager()
        {
            VuDesBibliothèques.Clear();
            LesBibliothèques.Clear();
            BibliothèqueDataManager.ToutRetirer();
            ListePrincipale.LesOeuvres.Clear();
            ListePrincipale.Nom = "Liste Principale";
            ListePrincipale.Image = "AnimeLike.jpg";
            VuDesBibliothèques.Add(ListePrincipale);
            BibliothèqueSélectionnée = ListePrincipale;
            OeuvreSélectionnée = null;
        }

        /// <summary>
        /// Permet d'enregistrer le fichier de sauvegarde dans un autre répertoire
        /// </summary>
        /// <param name="chemin">Le répertoire où enregistrer la copie de la sauvegarde</param>
        public void ExporterPersistance(string chemin)
        {
            BibliothèqueDataManager.ExporterPersistance(chemin);
            ChargerLesDonnées();
        }

        /// <summary>
        /// Permet de récupérer un fichier de sauvegarde et de l'incorporer à la persistance
        /// </summary>
        /// <param name="chemin">Le fichier et son chemin</param>
        /// <returns>Retourne dans l'ordre : Nombre Bibliothèque importées, Nombre Bibliothèque à importer, Nombre Oeuvre importées, Nombre Oeuvre à importer</returns>
        public (int, int, int, int) ImporterPersistance(string cheminFichier)
        {
            int r1;
            int r2;
            int r3;
            int r4;
            (r1, r2, r3, r4) = BibliothèqueDataManager.ImporterPersistance(cheminFichier);
            ChargerLesDonnées();
            return (r1, r2, r3, r4);
        }
    }
}
