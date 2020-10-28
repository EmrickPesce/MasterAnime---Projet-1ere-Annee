using Iut.MasterAnime.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Iut.MasterAnime.Persistance.Stub
{
    public class StubBibliothèqueDataManager : StubDataManager<Bibliothèque>, IBibliothèqueDataManager
    {
        /// <summary>
        /// Le constructeur de la stub persistance
        /// </summary>
        public StubBibliothèqueDataManager()
        {
            (ListePrincipale, MaCollection) = DonnéesPrêtes.DonnéesDeBibliothèques();
        }

        /// <summary>
        /// La Liste Principale de la persistance
        /// </summary>
        protected Bibliothèque ListePrincipale { get; set; }

        /// <summary>
        /// Permet de récupérer la Liste Principale
        /// </summary>
        /// <returns>La Liste Principale de la persistance</returns>
        public Bibliothèque ObtenirPrincipale()
        {
            return ListePrincipale;
        }

        /// <summary>
        /// Permet de récupérer une bibliothèque de la persistance à partir de son nom
        /// </summary>
        /// <param name="nom">La nom de la biliothèque à chercher</param>
        /// <returns>La bibliothèque trouvée ou null si elle n'existe pas</returns>
        public override Bibliothèque ObtenirParNom(string nom)
        {
            return MaCollection.Find(match: bibliothèque => bibliothèque.Nom.Equals(nom));
        }

        /// <summary>
        /// Permet d'ajouter une bibliothèque à la persistance
        /// </summary>
        /// <param name="bibliothèque">La bibliothèque à ajouter</param>
        /// <returns>True si elle a bien été ajoutée, false si elle existe déjà</returns>
        public override Bibliothèque Ajouter(Bibliothèque bibliothèque)
        {
            if (!MaCollection.Contains(bibliothèque) && !ListePrincipale.Equals(bibliothèque))
            {
                bibliothèque.LesOeuvres.ToList().ForEach(oeuvre => ListePrincipale.AjouterOeuvre(oeuvre));
                MaCollection.Add(bibliothèque);
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
            return retour;
        }

        /// <summary>
        /// Permet de réinitialiser la persistance
        /// </summary>
        public override void ToutRetirer()
        {
            MaCollection.Clear();
            ListePrincipale.LesOeuvres.Clear();
            ListePrincipale.Nom = "Liste Principale";
            ListePrincipale.Nom = "AnimeLike.jpg";
        }

        /// <summary>
        /// Cette méthode n'est implémentée.
        /// Récupère les données contenu dans le fichier de la persistance et les renvoies
        /// </summary>
        /// <returns>Cette méthode n'est implémentée. Les données récupérées, une Bibliothèque et une collection de Bibliothèques</returns>
        public (Bibliothèque, IEnumerable<Bibliothèque>) ChargerDonnées()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Cette méthode n'est implémentée.
        /// Écrit les données dans le fichier de la persistance
        /// </summary>
        /// <param name="listePrincipale">La Bibliothèque à écrire dans le fichier</param>
        /// <param name="lesBibliothèques">La collection de bibliothèques à écrire dans le fichier</param>
        public void SauvegarderDonnées(Bibliothèque listePrincipale, IEnumerable<Bibliothèque> lesBibliothèques)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Cette méthode n'est implémentée.
        /// Permet d'enregistrer le fichier de sauvegarde dans un autre répertoire
        /// </summary>
        /// <param name="chemin">Le répertoire où enregistrer la copie de la sauvegarde</param>
        public void ExporterPersistance(string chemin)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Cette méthode n'est implémentée.
        /// Permet de récupérer un fichier de sauvegarde et de l'incorporer à la persistance
        /// </summary>
        /// <param name="chemin">Le fichier et son chemin</param>
        /// <returns>Cette méthode n'est implémentée. Retourne dans l'ordre : Nombre Bibliothèque importées, Nombre Bibliothèque à importer, Nombre Oeuvre importées,
        /// Nombre Oeuvre à importer</returns>
        public (int, int, int, int) ImporterPersistance(string cheminFichier)
        {
            throw new NotImplementedException();
        }
    }
}
