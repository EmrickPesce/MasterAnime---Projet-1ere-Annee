using Iut.MasterAnime.ClassLibrary;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Iut.MasterAnime.Persistance.Json
{
    /// <summary>
    /// Permet de convertir des données en Json dans les deux sens
    /// </summary>
    public static class ConvertiseurJson
    {
        /// <summary>
        /// Converti une Bibliothèque et une liste de Bibliothèques en Json
        /// </summary>
        /// <param name="listePrincipale">La bibliothèque à convertir</param>
        /// <param name="lesBibliothèques">La collection de bibliothèque à convertir</param>
        /// <returns>Le JObject de bibliothèques converties</returns>
        public static JObject BibliothèquesVersJson(Bibliothèque listePrincipale, IEnumerable<Bibliothèque> lesBibliothèques)
        {
            var biliothèquesElts = lesBibliothèques.Select(
                biblio => new JObject(
                    new JProperty("bibliothèque",
                        new JObject(
                            new JProperty("guid", biblio.Guid),
                            JPropertySiNonNull("nom", biblio.Nom),
                            JPropertySiNonNull("image", biblio.Image),
                            JPropertySiNonNull("oeuvres",
                                biblio.LesOeuvres.Select(oeuvre => new JObject(new JProperty("oeuvre", JObjectOeuvre(oeuvre)))))))));

            var principaleElt = new JObject(
                    new JProperty("bibliothèque",
                        new JObject(
                            new JProperty("guid", listePrincipale.Guid),
                            JPropertySiNonNull("nom", listePrincipale.Nom),
                            JPropertySiNonNull("image", listePrincipale.Image),
                            JPropertySiNonNull("oeuvres",
                                listePrincipale.LesOeuvres.Select(oeuvre => new JObject(new JProperty("oeuvre", JObjectOeuvre(oeuvre))))))));

            var JsonObject = new JObject(new JProperty("laPrincipale", principaleElt), new JProperty("lesBibliothèques", biliothèquesElts));
            return JsonObject;
        }

        /// <summary>
        /// Vérifie sur la valeur passée est null, et la remplace par "Inconnu" si elle l'est pour la création d'une JProperty
        /// </summary>
        /// <param name="nom">Le nom de la JProperty</param>
        /// <param name="value">La valeur de la JProperty à vérifier</param>
        /// <returns>La JProperty avec la valeur ou "Inconnu" à la place de celle-ci si elle est null</returns>
        private static JProperty JPropertySiNonNull(String nom, string value)
            => string.IsNullOrEmpty(value) ? new JProperty(nom, "Inconnu") : new JProperty(nom, value);

        /// <summary>
        /// Vérifie sur la valeur passée est null, et la remplace par "Inconnu" si elle l'est pour la création d'une JProperty
        /// </summary>
        /// <param name="nom">Le nom de la JProperty</param>
        /// <param name="value">La valeur de la JProperty à vérifier</param>
        /// <returns>La JProperty avec la valeur ou "Inconnu" à la place de celle-ci si elle est null</returns>
        private static JProperty JPropertySiNonNull(String nom, object value)
            => value == null ? new JProperty(nom, "Inconnu") : new JProperty(nom, value);

        /// <summary>
        /// Converti une Oeuvre JObject de Json
        /// </summary>
        /// <param name="oeuvre">L'Oeuvre à convertir</param>
        /// <returns>Le JObject de l'Oeuvre convertie</returns>
        private static JObject JObjectOeuvre(Oeuvre oeuvre)
        {
            JObject jObjectRetour;
            if (oeuvre is Autre)
            {
                jObjectRetour = new JObject(
                    new JProperty("type", TypeOeuvre.Autre),
                    new JProperty("guid", oeuvre.Guid),
                    JPropertySiNonNull("nom", oeuvre.Nom),
                    JPropertySiNonNull("image", oeuvre.Image),
                    JPropertySiNonNull("sortie", oeuvre.Sortie),
                    JPropertySiNonNull("créateur", (oeuvre as Autre).Créateur),
                    new JProperty("infos", oeuvre.InformationsComplémentaires.Select(
                        kvp => new JObject(
                            new JProperty("nomInfo", kvp.Key.LeString),
                            JPropertySiNonNull("lInfo", kvp.Value.LeString)))),
                    JPropertySiNonNull("synopsis", oeuvre.Synopsis),
                    JPropertySiNonNull("commentaire", oeuvre.Commentaire));
            }
            else if (oeuvre is Cinématographique)
            {
                jObjectRetour = new JObject(
                    new JProperty("type", oeuvre is Film ? TypeOeuvre.Film : TypeOeuvre.Série),
                    new JProperty("guid", oeuvre.Guid),
                    JPropertySiNonNull("nom", oeuvre.Nom),
                    JPropertySiNonNull("image", oeuvre.Image),
                    JPropertySiNonNull("sortie", oeuvre.Sortie),
                    JPropertySiNonNull("réalisateur", oeuvre is Film ? (oeuvre as Film).Réalisateur : (oeuvre as Série).Réalisateur),
                    JPropertySiNonNull("studio", oeuvre is Film ? (oeuvre as Film).Studio : (oeuvre as Série).Studio),
                    JPropertySiNonNull("infos", oeuvre.InformationsComplémentaires.Select(
                        kvp => new JObject(
                            new JProperty("nomInfo", kvp.Key.LeString),
                            JPropertySiNonNull("lInfo", kvp.Value.LeString)))),
                    JPropertySiNonNull("synopsis", oeuvre.Synopsis),
                    JPropertySiNonNull("commentaire", oeuvre.Commentaire));
            }
            else if (oeuvre is Littéraire)
            {
                jObjectRetour = new JObject(
                    new JProperty("type", oeuvre is Livre ? TypeOeuvre.Livre : TypeOeuvre.Scan),
                    new JProperty("guid", oeuvre.Guid),
                    JPropertySiNonNull("nom", oeuvre.Nom),
                    JPropertySiNonNull("image", oeuvre.Image),
                    JPropertySiNonNull("sortie", oeuvre.Sortie),
                    JPropertySiNonNull("auteur", oeuvre is Livre ? (oeuvre as Livre).Auteur : (oeuvre as Scan).Auteur),
                    JPropertySiNonNull("éditeur", oeuvre is Livre ? (oeuvre as Livre).Éditeur : (oeuvre as Scan).Éditeur),
                    JPropertySiNonNull("infos", oeuvre.InformationsComplémentaires.Select(
                        kvp => new JObject(
                            new JProperty("nomInfo", kvp.Key.LeString),
                            JPropertySiNonNull("lInfo", kvp.Value.LeString)))),
                    JPropertySiNonNull("synopsis", oeuvre.Synopsis),
                    JPropertySiNonNull("commentaire", oeuvre.Commentaire));
            }
            else
            {
                jObjectRetour = new JObject(
                    new JProperty("type", TypeOeuvre.Animé),
                    new JProperty("guid", oeuvre.Guid),
                    JPropertySiNonNull("nom", oeuvre.Nom),
                    JPropertySiNonNull("image", oeuvre.Image),
                    JPropertySiNonNull("sortie", oeuvre.Sortie),
                    JPropertySiNonNull("auteur", (oeuvre as Animé).Auteur),
                    JPropertySiNonNull("studio", (oeuvre as Animé).Studio),
                    JPropertySiNonNull("infos", oeuvre.InformationsComplémentaires.Select(
                        kvp => new JObject(
                            new JProperty("nomInfo", kvp.Key.LeString),
                            JPropertySiNonNull("lInfo", kvp.Value.LeString)))),
                    JPropertySiNonNull("synopsis", oeuvre.Synopsis),
                    JPropertySiNonNull("commentaire", oeuvre.Commentaire));
            }
            return jObjectRetour;
        }

        /// <summary>
        /// Converti un JObject en une Bibliothèque et une collection de Biblitohèques
        /// </summary>
        /// <param name="json">Le JObject à convertir</param>
        /// <returns>La Bibliothèque et la collection de Biblitohèques converties</returns>
        public static (Bibliothèque, IEnumerable<Bibliothèque>) JsonVersBibliothèques(JObject json)
        {
            Bibliothèque laPrincipale = new Bibliothèque(
                (string)json["laPrincipale"]["bibliothèque"]["nom"],
                (string)json["laPrincipale"]["bibliothèque"]["image"],
                JObjectVersObservableCollectionOeuvre(json["laPrincipale"]["bibliothèque"]["oeuvres"]),
                (string)json["laPrincipale"]["bibliothèque"]["guid"]
                );


            var laCollection = new ObservableCollection<Bibliothèque>();

            json["lesBibliothèques"].Select(j => new Bibliothèque(
                (string)j["bibliothèque"]["nom"],
                (string)j["bibliothèque"]["image"],
                JObjectVersObservableCollectionOeuvre(j["bibliothèque"]["oeuvres"]),
                (string)json["laPrincipale"]["bibliothèque"]["guid"])
            ).ToList().ForEach(biblio => laCollection.Add(biblio));

            return (laPrincipale, laCollection);
        }

        /// <summary>
        /// Converti un Jtoken en une ObservableDictionary
        /// </summary>
        /// <param name="jTokenOeuvre">Le JToken à convertir</param>
        /// <returns>L'ObservableDictionary convertie</returns>
        private static ObservableDictionary<StringVérifié, StringVérifié> JTokenVersObservableDictionnaryString(JToken jTokenCollectionOeuvres)
        {
            var dictionnaryRetour = new ObservableDictionary<StringVérifié, StringVérifié>();

            jTokenCollectionOeuvres["infos"].Select(j => dictionnaryRetour[new StringVérifié((string)j["nomInfo"])] = new StringVérifié((string)j["lInfo"]));

            return dictionnaryRetour;
        }

        /// <summary>
        /// Converti un Jtoken en une Oeuvre
        /// </summary>
        /// <param name="jTokenOeuvre">Le JToken à convertir</param>
        /// <returns>L'Oeuvre convertie</returns>
        private static Oeuvre JObjectVersOeuvre(JToken jTokenOeuvre)
        {
            Oeuvre oeuvreRetour;

            switch ((int)jTokenOeuvre["type"])
            {
                case (int)TypeOeuvre.Autre:
                    oeuvreRetour = new Autre((string)jTokenOeuvre["nom"], (string)jTokenOeuvre["image"], (DateTime)jTokenOeuvre["sortie"],
                        (string)jTokenOeuvre["créateur"], JTokenVersObservableDictionnaryString(jTokenOeuvre), (string)jTokenOeuvre["synopsis"], 
                        (string)jTokenOeuvre["commentaire"], (string)jTokenOeuvre["guid"]);
                    break;
                case (int)TypeOeuvre.Film:
                    oeuvreRetour = new Film((string)jTokenOeuvre["nom"], (string)jTokenOeuvre["image"], (DateTime)jTokenOeuvre["sortie"],
                        (string)jTokenOeuvre["réalisateur"], (string)jTokenOeuvre["studio"], JTokenVersObservableDictionnaryString(jTokenOeuvre),
                        (string)jTokenOeuvre["synopsis"], (string)jTokenOeuvre["commentaire"], (string)jTokenOeuvre["guid"]);
                    break;
                case (int)TypeOeuvre.Série:
                    oeuvreRetour = new Série((string)jTokenOeuvre["nom"], (string)jTokenOeuvre["image"], (DateTime)jTokenOeuvre["sortie"],
                        (string)jTokenOeuvre["réalisateur"], (string)jTokenOeuvre["studio"], JTokenVersObservableDictionnaryString(jTokenOeuvre),
                        (string)jTokenOeuvre["synopsis"], (string)jTokenOeuvre["commentaire"], (string)jTokenOeuvre["guid"]);
                    break;
                case (int)TypeOeuvre.Livre:
                    oeuvreRetour = new Livre((string)jTokenOeuvre["nom"], (string)jTokenOeuvre["image"], (DateTime)jTokenOeuvre["sortie"],
                        (string)jTokenOeuvre["auteur"], (string)jTokenOeuvre["éditeur"], JTokenVersObservableDictionnaryString(jTokenOeuvre), 
                        (string)jTokenOeuvre["synopsis"], (string)jTokenOeuvre["commentaire"], (string)jTokenOeuvre["guid"]);
                    break;
                case (int)TypeOeuvre.Scan:
                    oeuvreRetour = new Scan((string)jTokenOeuvre["nom"], (string)jTokenOeuvre["image"], (DateTime)jTokenOeuvre["sortie"],
                        (string)jTokenOeuvre["auteur"], (string)jTokenOeuvre["éditeur"], JTokenVersObservableDictionnaryString(jTokenOeuvre),
                        (string)jTokenOeuvre["synopsis"], (string)jTokenOeuvre["commentaire"], (string)jTokenOeuvre["guid"]);
                    break;
                default:
                    oeuvreRetour = new Animé((string)jTokenOeuvre["nom"], (string)jTokenOeuvre["image"], (DateTime)jTokenOeuvre["sortie"],
                        (string)jTokenOeuvre["auteur"], (string)jTokenOeuvre["studio"], JTokenVersObservableDictionnaryString(jTokenOeuvre),
                        (string)jTokenOeuvre["synopsis"], (string)jTokenOeuvre["commentaire"], (string)jTokenOeuvre["guid"]);
                    break;

            }

            return oeuvreRetour;
        }

        /// <summary>
        /// Converti un Jtoken en une collection d'oeuvres
        /// </summary>
        /// <param name="jObject">Le JToken à convertir</param>
        /// <returns>La collection d'oeuvres convertie</returns>
        private static ObservableCollection<Oeuvre> JObjectVersObservableCollectionOeuvre(JToken jObject)
        {
            var collectionRetour = new ObservableCollection<Oeuvre>();

            jObject.Select(o => JObjectVersOeuvre(o["oeuvre"])).ToList().ForEach(oeuvre => collectionRetour.Add(oeuvre));

            return collectionRetour;
        }


    }
}
