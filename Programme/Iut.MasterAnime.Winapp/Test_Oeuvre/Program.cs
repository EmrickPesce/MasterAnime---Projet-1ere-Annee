using Iut.MasterAnime.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using Iut.MasterAnime.Persistance.Stub;

namespace Test_Oeuvre
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test de la classe Oeuvre\n");

            //Pour faire ce test, la classe n'était plus abstract
            /*
            Oeuvre oeuvre = new Oeuvre("oeuvre", "CheminOeuvre", DateTime.Now, new ObservableDictionary<StringVérifié, StringVérifié>(),
                "Ceci est le synopsis de l'oeuvre 1", "Ceci est le commentaire de l'oeuvre 1");

            Console.WriteLine($"Nom : {oeuvre.Nom}\nImage : {oeuvre.Image}\nSortie : {oeuvre.Sortie}\n" +
                              $"Synopsis : {oeuvre.Synopsis}\nCommentaire : {oeuvre.Commentaire}");
           
            oeuvre.AjouterInformation(new StringVérifié("PremièreInfo"), new StringVérifié("L'infoUtile"));
            oeuvre.AjouterInformation(new StringVérifié("SecondeInfo"), new StringVérifié("L'infoNonIndispensable"));
            oeuvre.AjouterInformation(new StringVérifié("TroisièmeInfo"), new StringVérifié("L'infoInutile"));

            Console.WriteLine("\nLes informations de l'oeuvre :");
            Console.WriteLine(oeuvre.InfoToString());

            Console.WriteLine("\nModification des informations de l'oeuvre :");
            Console.WriteLine($"Suppression de l'info inutile : {oeuvre.RetirerInformation("TroisièmeInfo")}");

            String? info2 = oeuvre.RechercherInformation("SecondeInfo");
            Console.WriteLine(info2 == null ? "SecondeInfo introuvable par RechercherInformation !(pas bien)" :
                "SecondeInfo trouvée par RechercherInformation !(bien)");
            String? info3 = oeuvre.RechercherInformation("TroisièmeInfo");
            Console.WriteLine(info3 == null ? "TroisièmeInfo introuvable par RechercherInformation car supprimée (bien)" :
                "TroisièmeInfo trouvée par RechercherInformation alors que supprimée !(pas bien)");

            Console.WriteLine("\nCompte combien de fois apparait la chaine \"Oeuvre\"");
            Console.WriteLine($"Doit en trouver 2, et en trouve : {oeuvre.ContientMotClé("Oeuvre")}");
            Console.WriteLine();
            Console.WriteLine("Compte combien de fois apparait la chaine \"info\"");
            Console.WriteLine($"Doit en trouver 4, et en trouve : {oeuvre.ContientMotClé("info")}");
            */

            //Ce test permet de ne pas instancier une Oeuvre directement
            StubOeuvreDataManager oeuvreDataManager = new StubOeuvreDataManager();

            oeuvreDataManager.ToutRetirer();
            oeuvreDataManager.Ajouter(new Autre("unAutre", "CheminImageAutre", DateTime.Today, "unCréateur",
                new ObservableDictionary<StringVérifié, StringVérifié>()
                    { { new StringVérifié("NomPremièreInfo"), new StringVérifié("UnePremièreInfo") }, { new StringVérifié("NomSecondeInfo"),
                        new StringVérifié("UneSecondeInfo") } }, "Ceci est un synopsis - Autre",
                    "Ceci est un commentaire personnel - Autre"));

            Oeuvre oeuvre = (oeuvreDataManager.ObtenirParNom("unAutre") as Oeuvre);

            WriteLine(oeuvre);

            oeuvre.AjouterInformation(new StringVérifié("TroisièmeInfo"), new StringVérifié("L'infoInutile"));

            WriteLine("\nModification des informations de l'oeuvre :");
            WriteLine($"Suppression de l'info inutile : {oeuvre.RetirerInformation(new StringVérifié("TroisièmeInfo"))}");

            StringVérifié info1 = oeuvre.RechercherInformation(new StringVérifié("NomPremièreInfo"));
            WriteLine(info1 == null ? "PremièreInfo introuvable par RechercherInformation !(pas bien)" : "SecondeInfo trouvée par RechercherInformation !(bien)");

            StringVérifié info3 = oeuvre.RechercherInformation(new StringVérifié("TroisièmeInfo"));
            WriteLine(info3 == null ? "TroisièmeInfo introuvable par RechercherInformation car supprimée (bien)" :
                "TroisièmeInfo trouvée par RechercherInformation alors que supprimée !(pas bien)");

            WriteLine("\nCompte combien de fois apparait la chaine \"Autre\"");
            WriteLine($"Doit en trouver 2, et en trouve : {oeuvre.ContientMotClé("Autre")}");
            WriteLine();
            WriteLine("Compte combien de fois apparait la chaine \"info\"");
            WriteLine($"Doit en trouver 4, et en trouve : {oeuvre.ContientMotClé("info")}");

        }
    }
}