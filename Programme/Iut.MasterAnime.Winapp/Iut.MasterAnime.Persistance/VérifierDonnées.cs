using Iut.MasterAnime.ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Iut.MasterAnime.Persistance
{
    /// <summary>
    /// Classe permettant de vérifier les données récupérées dans un fichier
    /// </summary>
    public class VérifierDonnées
    {
        /// <summary>
        /// Vérifie les données et leurs concordances entre elles. Modifie directement les données via les références
        /// </summary>
        /// <param name="listePrincipale">La liste principale à vérifier</param>
        /// <param name="lesBibliothèques">La collection de bibliothèques à vérifier</param>
        public static void VérifierDonnéesBibliothèques(Bibliothèque listePrincipale, IEnumerable<Bibliothèque> lesBibliothèques)
        {
            //Change le nom de la liste principale si celui-ci n'est pas correct
            if(String.IsNullOrEmpty(listePrincipale.Nom) || listePrincipale.Nom.Length > 16)
            {
                listePrincipale.Nom = "Liste Principale";
            }

            //Vérifie si la liste principale ne contient pas de doublons d'oeuvres
            for (int i = 0; i < listePrincipale.LesOeuvres.Count; i++)
            {
                List<Oeuvre> desOeuvres = listePrincipale.LesOeuvres.Where(oeuvre => listePrincipale[i].Equals(oeuvre)).ToList();
                if (desOeuvres.Count > 1)
                {
                    //Retire les oeuvres dupliquées de la liste principale et des bibliothèques
                    for (int j = 0; j < desOeuvres.Count; j++)
                    {
                        lesBibliothèques.ToList().ForEach(biblio => biblio.RetirerOeuvre(desOeuvres[j]));
                        listePrincipale.RetirerOeuvre(desOeuvres[j]);
                    }
                }
            }

            //Vérifie chaques bibliothèques unes par unes
            lesBibliothèques.ToList().ForEach(biblio => VérifierUneBibliothèque(biblio));

            //Vérifie si les bibliothèques n'ont pas le même nom
            for (int i = 0; i < lesBibliothèques.ToList().Count; i++)
            {
                List<Bibliothèque> desBiblios = lesBibliothèques.ToList().Where(biblio => lesBibliothèques.ToList().ElementAt(i).Nom.Equals(biblio.Nom)).ToList();
                if (desBiblios.Count > 1)
                {
                    //Pour les bibliothèques possédants le même nom, sauf la première, étant celle qu'on va considérée comme l'originale
                    for(int k = 1; k < desBiblios.Count; k++)
                    {
                        Bibliothèque biblio = desBiblios[k];
                        if (biblio.Nom.Contains("Inconnu")) biblio.Nom = "Inconnu";
                        int j = 0;
                        //Change le nom de la bibliothèque pour ajouter un numéro à la fin
                        while (desBiblios.Where(uneBiblio => uneBiblio.Nom.Equals($"{biblio.Nom} {j}")).Count() > 0)
                        {
                            j++;
                        }

                        //Si en ajoutant le numéro la taille est supérieur à 16 on change le nom pour qu'il devienne 'Inconnu'
                        if($"{biblio.Nom} {j}".Length > 16)
                        {
                            biblio.Nom = "Inconnu";
                            int v = 0;
                            while (desBiblios.Where(uneBiblio => uneBiblio.Nom.Equals($"{biblio.Nom} {v}")).Count() > 0)
                            {
                                v++;
                            }
                        }

                        biblio.Nom = $"{biblio.Nom} {j}";
                    }
                }
            }

            foreach(Bibliothèque bibliothèque in lesBibliothèques)
            {
                //Vérifie chaques oeuvres de la bibliothèque
                bibliothèque.LesOeuvres.ToList().ForEach(oeuvre => VérifierUneOeuve(oeuvre));

                for(int i = 0; i < bibliothèque.LesOeuvres.Count; i++)
                {
                    Oeuvre oeuvre = bibliothèque[i];
                    //Met à jour la bibliothèque par rapport aux oeuvres de la liste principale
                    if(listePrincipale.ContientOeuvre(oeuvre.Nom))
                    {
                        bibliothèque.RetirerOeuvre(oeuvre.Nom);
                        bibliothèque.AjouterOeuvre(listePrincipale.ObtenirOeuvre(oeuvre.Nom));
                    } 
                    //Met à jour la liste principale par rapport aux oeuvres de la bibliothèque
                    else
                    {
                        //listePrincipale.AjouterOeuvre(oeuvre);

                        int j = 0;
                        //Tant que le nom de l'oeuvre est déjà existant dans la page principale
                        while (!listePrincipale.AjouterOeuvre(oeuvre))
                        {
                            if ($"{oeuvre.Nom} {j}".Length > 16)
                            {
                                oeuvre.Nom = $"Inconnu {j}";
                            }
                            else
                            {
                                oeuvre.Nom = $"{oeuvre.Nom} {j}";
                            }

                            j++;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Vérifie les données d'une bibliothèque. Modifie directement les données via la référence
        /// </summary>
        /// <param name="laBibliothèque">La bibliothèque à vérifier</param>
        public static void VérifierUneBibliothèque(Bibliothèque laBibliothèque)
        {
            //Change le nom de la Bilbiothèque si celui-ci n'est pas correct
            if (String.IsNullOrEmpty(laBibliothèque.Nom) || laBibliothèque.Nom.Length > 16)
            {
                laBibliothèque.Nom = "Inconnu";
            }

            //Vérifie si la Bilbiothèque ne contient pas de doublons d'oeuvres
            for (int i = 0; i < laBibliothèque.LesOeuvres.Count; i++)
            {
                List<Oeuvre> desOeuvres = laBibliothèque.LesOeuvres.Where(oeuvre => laBibliothèque[i].Equals(oeuvre)).ToList();
                if (desOeuvres.Count > 1)
                {
                    //Retire les oeuvres dupliquées de la Bilbiothèque
                    for (int j = 0; i < desOeuvres.Count - 1; j++)
                    {
                        laBibliothèque.RetirerOeuvre(desOeuvres[0]);
                    }
                }
            }
        }

        /// <summary>
        /// Vérifie les données d'une oeuvre. Modifie directement les données via la référence
        /// </summary>
        /// <param name="oeuvre">L'oeuvre à vérifier</param>
        public static void VérifierUneOeuve(Oeuvre oeuvre)
        {
            //Vérifie le nom
            if (String.IsNullOrEmpty(oeuvre.Nom) || oeuvre.Nom.Length > 16)
            {
                oeuvre.Nom = "Inconnu";
            }

            //Vérifie les informations complémentaires
            foreach (StringVérifié key in oeuvre.InformationsComplémentaires.Keys)
            {
                if (key.LeString.Length > 16) key.LeString = "Inconnu";
            }
            foreach (StringVérifié value in oeuvre.InformationsComplémentaires.Values)
            {
                if (value.LeString.Length > 16) value.LeString = "Inconnu";
            }
            //Vérifie si des informations ont le même nom
            foreach (StringVérifié info in oeuvre.InformationsComplémentaires.Keys)
            {
                List<KeyValuePair<StringVérifié, StringVérifié>> desInfos = oeuvre.InformationsComplémentaires.Where(kvp => kvp.Key.LeString.Equals(info.LeString)).ToList();
                
                //Si des informations ont le même nom
                if (desInfos.Count > 1)
                {
                    foreach (KeyValuePair<StringVérifié, StringVérifié> kvp in desInfos)
                    {
                        int j = 0;
                        //Change le nom de l'information pour ajouter un numéro à la fin
                        while (desInfos.Where(unKvp => unKvp.Key.LeString.Equals($"{kvp.Key.LeString} {j}")).Count() > 0)
                        {
                            j++;
                        }

                        //Si en ajoutant le numéro la taille est supérieur à 16 on change le nom pour qu'il devienne 'Inconnu'
                        if ($"{kvp.Key.LeString} {j}".Length > 16)
                        {
                            kvp.Key.LeString = "Inconnu";
                            int v = 0;
                            while (desInfos.Where(unKvp => unKvp.Key.LeString.Equals($"{kvp.Key.LeString} {v}")).Count() > 0)
                            {
                                v++;
                            }
                        }

                        kvp.Key.LeString = $"{kvp.Key.LeString} {j}";
                    }
                }
            }

            //Vérifie les informations par défault
            if (oeuvre is Autre)
            {
                if ((oeuvre as Autre).Créateur.Length > 16) (oeuvre as Autre).Créateur = "Inconnu";
            }
            else if (oeuvre is Cinématographique)
            {
                if ((oeuvre as Cinématographique).Réalisateur.Length > 16) (oeuvre as Cinématographique).Réalisateur = "Inconnu";
                if ((oeuvre as Cinématographique).Studio.Length > 16) (oeuvre as Cinématographique).Studio = "Inconnu";
            }
            else if (oeuvre is Littéraire)
            {
                if ((oeuvre as Littéraire).Auteur.Length > 16) (oeuvre as Littéraire).Auteur = "Inconnu";
                if ((oeuvre as Littéraire).Éditeur.Length > 16) (oeuvre as Littéraire).Éditeur = "Inconnu";
            }
            else if (oeuvre is Animé)
            {
                if ((oeuvre as Animé).Auteur.Length > 16) (oeuvre as Animé).Auteur = "Inconnu";
                if ((oeuvre as Animé).Studio.Length > 16) (oeuvre as Animé).Studio = "Inconnu";
            }
        }


    }
}
