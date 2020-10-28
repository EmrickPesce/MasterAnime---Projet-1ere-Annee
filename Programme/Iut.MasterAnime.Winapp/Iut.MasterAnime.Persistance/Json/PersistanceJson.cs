using Iut.MasterAnime.ClassLibrary;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Iut.MasterAnime.Persistance.Json
{
    /// <summary>
    /// Classe permettant d'écrire et de lire dans un fichier Json pour la persistance
    /// </summary>
    public class PersistanceJson : IBibliothèqueDataManager
    {
        /// <summary>
        /// Le répertoire du fichier de sauvegarde
        /// </summary>
        public string RépertoireFichier { get; set; } = "..\\Json";

        /// <summary>
        /// Le nom du fichier de sauvegarde
        /// </summary>
        public string NomFichier { get; set; } = "MasterAnime.json";

        /// <summary>
        /// La combinaison du répertoir et du fichier de sauvegarde
        /// </summary>
        public string CheminFichier => Path.Combine(RépertoireFichier, NomFichier);

        /// <summary>
        /// La Liste Principale de la persistance
        /// </summary>
        protected Bibliothèque ListePrincipale { get; set; }

        /// <summary>
        /// La collection de Bibliothèques de la persistance
        /// </summary>
        protected List<Bibliothèque> MaCollection { get; set; } = new List<Bibliothèque>();

        /// <summary>
        /// Le constructeur de la persistance en Json
        /// </summary>
        /// <param name="chargementFichier">True pour le chargement des données à partir du fichier de sauvegarder.
        /// False pour la création d'une nouvelle sauvegarde</param>
        public PersistanceJson(bool chargementFichier)
        {
            if (chargementFichier)
            {
                Charger();
            }
            else
            {
                (ListePrincipale, MaCollection) = DonnéesPrêtes.DonnéesDeBibliothèques();
                VérifierDonnées.VérifierDonnéesBibliothèques(ListePrincipale, MaCollection);
                Sauvegarder();
            }
        }

        /// <summary>
        /// Le constructeur de la persistance en Json créant une nouvelle sauvegarde
        /// </summary>
        public PersistanceJson() : this(false) { }

        /// <summary>
        /// Permet de récupérer la Liste Principale
        /// </summary>
        /// <returns>La Liste Principale de la persistance</returns>
        public Bibliothèque ObtenirPrincipale()
        {
            Charger();
            return ListePrincipale;
        }

        /// <summary>
        /// Permet de récupérer une bibliothèque de la persistance à partir de son nom
        /// </summary>
        /// <param name="nom">La nom de la biliothèque à chercher</param>
        /// <returns>La bibliothèque trouvée ou null si elle n'existe pas</returns>
        public Bibliothèque ObtenirParNom(string nom)
        {
            Charger();
            return MaCollection.Find(match: bibliothèque => bibliothèque.Nom.Equals(nom));
        }

        /// <summary>
        /// Permet de récupérer la collection de Bibliothèques de la persistance
        /// </summary>
        /// <returns>La collection de Bibliothèques de la persistance</returns>
        public IEnumerable<Bibliothèque> ObtenirTous()
        {
            Charger();
            return MaCollection;
        }

        /// <summary>
        /// Permet d'ajouter une bibliothèque à la persistance
        /// </summary>
        /// <param name="bibliothèque">La bibliothèque à ajouter</param>
        /// <returns>Retourne la Bibliothèque si elle a été ajoutée, null sinon</returns>
        public Bibliothèque Ajouter(Bibliothèque bibliothèque)
        {
            if (!MaCollection.Contains(bibliothèque) && !ListePrincipale.Equals(bibliothèque))
            {
                bibliothèque.LesOeuvres.ToList().ForEach(oeuvre => AjouterOeuvre(oeuvre));
                MaCollection.Add(bibliothèque);
                Sauvegarder();
                return bibliothèque;
            }
            return null;
        }

        /// <summary>
        /// Permet d'ajouter une bibliothèque à la persistance et à différentes bibliothèques
        /// </summary>
        /// <param name="oeuvre">L'oeuvre à ajouter</param>
        /// <param name="bibliothèques">Les bibliothèques à laquelle l'ajouter</param>
        /// <returns>True si elle a bien été ajoutée, false si elle existe déjà</returns>
        public bool AjouterOeuvre(Oeuvre oeuvre, params Bibliothèque[] bibliothèques)
        {
            bool retour = ListePrincipale.AjouterOeuvre(oeuvre);
            if (retour)
            {
                bibliothèques.ToList().ForEach(biblio => biblio.AjouterOeuvre(oeuvre));
            }
            Sauvegarder();
            return retour;
        }

        /// <summary>
        /// Permet de retirer une Bibliothèque de la persistance
        /// </summary>
        /// <param name="élément">La bibliothèque à retirer</param>
        /// <returns>True si elle a bien été retirée, False si elle n'y été pas</returns>
        public bool Retirer(Bibliothèque élément)
        {
            bool retour = MaCollection.Remove(élément);
            Sauvegarder();
            return retour;
        }

        /// <summary>
        /// Permet de réinitialiser la persistance
        /// </summary>
        public void ToutRetirer()
        {
            MaCollection.Clear();
            ListePrincipale.LesOeuvres.Clear();
            ListePrincipale.Nom = "Liste Principale";
            ListePrincipale.Nom = "AnimeLike.jpg";
            Sauvegarder();
        }

        /// <summary>
        /// Charge les données contenu dans le fichier de la persistance
        /// </summary>
        public void Charger()
        {
            IEnumerable<Bibliothèque> laCollection;
            Bibliothèque laPrincipale;
            (laPrincipale, laCollection) = ChargerDonnées();
            VérifierDonnées.VérifierDonnéesBibliothèques(laPrincipale, laCollection);
            ListePrincipale = laPrincipale;
            MaCollection = laCollection.ToList();
        }

        /// <summary>
        /// Récupère les données contenu dans le fichier de la persistance et les renvoies
        /// </summary>
        /// <returns>Les données récupérées, une Bibliothèque et une collection de Bibliothèques</returns>
        public (Bibliothèque, IEnumerable<Bibliothèque>) ChargerDonnées()
        {
            string jsonText = File.ReadAllText(CheminFichier);
            JObject json = JObject.Parse(jsonText);

            Bibliothèque laPrincipale;
            IEnumerable<Bibliothèque> laCollection;

            (laPrincipale, laCollection) = ConvertisseurJson.JsonVersBibliothèques(json);

            return (laPrincipale, laCollection);
        }

        /// <summary>
        /// Sauvegarde les données de la persistance dans le fichier de persistance
        /// </summary>
        public void Sauvegarder() => SauvegarderDonnées(ListePrincipale, MaCollection);

        /// <summary>
        /// Écrit les données dans le fichier de la persistance
        /// </summary>
        /// <param name="listePrincipale">La Bibliothèque à écrire dans le fichier</param>
        /// <param name="lesBibliothèques">La collection de bibliothèques à écrire dans le fichier</param>
        public void SauvegarderDonnées(Bibliothèque listePrincipale, IEnumerable<Bibliothèque> lesBibliothèques)
        {
            var MasterAnimeFichier = ConvertisseurJson.BibliothèquesVersJson(listePrincipale, lesBibliothèques);

            if(!Directory.Exists(RépertoireFichier))
            {
                Directory.CreateDirectory(RépertoireFichier);
            }

            File.WriteAllText(CheminFichier, MasterAnimeFichier.ToString());
            Charger();
        }

        /// <summary>
        /// Permet d'enregistrer le fichier de sauvegarde dans un autre répertoire
        /// </summary>
        /// <param name="chemin">Le répertoire où enregistrer la copie de la sauvegarde</param>
        public void ExporterPersistance(string chemin)
        {
            var MasterAnimeFichier = ConvertisseurJson.BibliothèquesVersJson(ListePrincipale, MaCollection);

            if (!Directory.Exists(chemin))
            {
                Directory.CreateDirectory(chemin);
            }

            File.WriteAllText(Path.Combine(chemin, "MasterAnime-Fichier.json"), MasterAnimeFichier.ToString());
        }

        /// <summary>
        /// Permet de récupérer un fichier de sauvegarde et de l'incorporer à la persistance
        /// </summary>
        /// <param name="chemin">Le fichier et son chemin</param>
        /// <returns>Retourne dans l'ordre : Nombre Bibliothèque importées, Nombre Bibliothèque à importer, Nombre Oeuvre importées, Nombre Oeuvre à importer</returns>
        public (int, int, int, int) ImporterPersistance(string cheminFichierAImporter)
        {
            int nombreBiblioImportée = 0;
            int nombreBiblioAImporter = 0;
            int nombreOeuvreImportée = 0;
            int nombreOeuvreAImporter = 0;

            string jsonText = File.ReadAllText(cheminFichierAImporter);
            JObject json = JObject.Parse(jsonText);

            Bibliothèque laPrincipale;
            IEnumerable<Bibliothèque> laCollection;

            (laPrincipale, laCollection) = ConvertisseurJson.JsonVersBibliothèques(json);

            //Ajoute les oeuvres à la liste principale en indiquant si elles étaient déjà présentes ou non
            foreach(Oeuvre oeuvre in laPrincipale.LesOeuvres)
            {
                nombreOeuvreAImporter++;
                if (AjouterOeuvre(oeuvre)) nombreOeuvreImportée++;
            }

            //Ajoute les bibliothèques à la collection en indiquant si elles étaient déjà présentes ou non
            foreach (Bibliothèque biblio in laCollection)
            {
                nombreBiblioAImporter++;
                //Met à jour les oeuvres de la bibliothèque à partir de celles de la liste principale
                for (int i = 0; i < biblio.NombreOeuvre(); i++)
                {
                    if (ListePrincipale.ContientOeuvre(biblio[i]))
                    {
                        Oeuvre oeuvre = ListePrincipale.ObtenirOeuvre(biblio[i].Nom);
                        biblio.RetirerOeuvre(biblio[i]);
                        biblio.AjouterOeuvre(oeuvre);
                    } else
                    {
                        ListePrincipale.AjouterOeuvre(biblio[i]);
                    }
                }

                if (Ajouter(biblio) != null)
                {
                    nombreBiblioImportée++;
                }
            }

            Sauvegarder();
            return (nombreBiblioImportée, nombreBiblioAImporter, nombreOeuvreImportée, nombreOeuvreAImporter);
        }
    }
}
