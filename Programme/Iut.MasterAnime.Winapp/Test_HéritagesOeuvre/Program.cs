using System.Collections.Generic;
using Iut.MasterAnime.ClassLibrary;
using System;
using static System.Console;
using System.Linq;
using Iut.MasterAnime.Persistance.Stub;

namespace Test_HéritagesOeuvre
{
    class Program
    {
        static void Main(string[] args)
        {
            StubOeuvreDataManager oeuvreDataManager = new StubOeuvreDataManager();

            oeuvreDataManager.ToutRetirer();

            oeuvreDataManager.Ajouter(new Autre("unAutre", "CheminImageAutre", DateTime.Today, "unCréateur", 
                new ObservableDictionary<StringVérifié, StringVérifié>()
                { { new StringVérifié("NomPremièreInfo"), new StringVérifié("UnePremièreInfo") }, { new StringVérifié("NomSecondeInfo"),
                        new StringVérifié("UneSecondeInfo") } }, "Ceci est un synopsis - Autre",
                "Ceci est un commentaire personnel - Autre"));

            oeuvreDataManager.Ajouter(new Film("unFilm", "CheminImageFilm", DateTime.Today, "unRéalisateur", "unStudio", 
                new ObservableDictionary<StringVérifié, StringVérifié>()
                { { new StringVérifié("NomPremièreInfo"), new StringVérifié("UnePremièreInfo") }, { new StringVérifié("NomSecondeInfo"),
                        new StringVérifié("UneSecondeInfo") } }, "Ceci est un synopsis - Film",
                "Ceci est un commentaire personnel - Film"));

            oeuvreDataManager.Ajouter(new Série("uneSérie", "CheminImageSérie", DateTime.Today, "unRéalisateur", "unStudio", 
                new ObservableDictionary<StringVérifié, StringVérifié>()
                { { new StringVérifié("NomPremièreInfo"), new StringVérifié("UnePremièreInfo") }, { new StringVérifié("NomSecondeInfo"), 
                        new StringVérifié("UneSecondeInfo") } }, "Ceci est un synopsis - Série",
                    "Ceci est un commentaire personnel - Série"));

            oeuvreDataManager.Ajouter(new Livre("unLivre", "CheminImageLivre", DateTime.Today, "unAuteur", "unÉditeur", 
                new ObservableDictionary<StringVérifié, StringVérifié>()
                { { new StringVérifié("NomPremièreInfo"), new StringVérifié("UnePremièreInfo") }, { new StringVérifié("NomSecondeInfo"),
                        new StringVérifié("UneSecondeInfo") } }, "Ceci est un synopsis - Livre",
                "Ceci est un commentaire personnel - Livre"));

            oeuvreDataManager.Ajouter(new Scan("unScan", "CheminImageScan", DateTime.Today, "unAuteur", "unÉditeur",
                new ObservableDictionary<StringVérifié, StringVérifié>()
                { { new StringVérifié("NomPremièreInfo"), new StringVérifié("UnePremièreInfo") }, { new StringVérifié("NomSecondeInfo"), 
                        new StringVérifié("UneSecondeInfo") } }, "Ceci est un synopsis - Scan",
                "Ceci est un commentaire personnel - Scan"));
                
            oeuvreDataManager.Ajouter(new Animé("unAnimé", "CheminImageAnimé", DateTime.Today, "unAuteur", "unStudio",
                new ObservableDictionary<StringVérifié, StringVérifié>()
                { { new StringVérifié("NomPremièreInfo"), new StringVérifié("UnePremièreInfo") }, { new StringVérifié("NomSecondeInfo"), 
                        new StringVérifié("UneSecondeInfo") } }, "Ceci est un synopsis - Animé",
                "Ceci est un commentaire personnel - Animé"));

            for (int i = 0; i < 6; i++)
            {
                WriteLine("Test des classes héritières de Oeuvre :\n");
                WriteLine(oeuvreDataManager.ObtenirTous().ToList()[i]);
                WriteLine("\n\nTappez sur entrez pour continuer");
                ReadLine();
                Clear();
            }

            (oeuvreDataManager.ObtenirTous().ToList()[0] as Autre).ModifierOeuvre("unAutreModifié", "CheminImageAutreModifié", new DateTime(2000,01,01), 
                "unCréateurModifié", new ObservableDictionary<StringVérifié, StringVérifié>() 
                { { new StringVérifié("NomPremièreInfoModifié"), new StringVérifié("UnePremièreInfoModifié") }, 
                    { new StringVérifié("NomSecondeInfoModifié"), new StringVérifié("UneSecondeInfoModifié") } },
                "Ceci est un synopsis Modifié - Autre", "Ceci est un commentaire personnel Modifié - Autre");

            (oeuvreDataManager.ObtenirTous().ToList()[1] as Film).ModifierOeuvre("unFilmModifié", "CheminImageFilmModifié", new DateTime(2000,01,01),
                "unRéalisateurModifié", "unStudioModifié", new ObservableDictionary<StringVérifié, StringVérifié>()
                { { new StringVérifié("NomPremièreInfoModifié"), new StringVérifié("UnePremièreInfoModifié") },
                    { new StringVérifié("NomSecondeInfoModifié"), new StringVérifié("UneSecondeInfoModifié") } }, "Ceci est un synopsisModifié - Film", 
                "Ceci est un commentaire personnelModifié - Film");

            (oeuvreDataManager.ObtenirTous().ToList()[2] as Série).ModifierOeuvre("uneSérieModifié", "CheminImageSérieModifié", new DateTime(2000,01,01),
                "unRéalisateurModifié", "unStudioModifié", new ObservableDictionary<StringVérifié, StringVérifié>() 
                { { new StringVérifié("NomPremièreInfoModifié"), new StringVérifié("UnePremièreInfoModifié") },
                    { new StringVérifié("NomSecondeInfoModifié"), new StringVérifié("UneSecondeInfoModifié") } }, "Ceci est un synopsisModifié - Série",
                "Ceci est un commentaire personnelModifié - Série");

            (oeuvreDataManager.ObtenirTous().ToList()[3] as Livre).ModifierOeuvre("unLivreModifié", "CheminImageLivreModifié", new DateTime(2000,01,01), 
                "unAuteurModifié", "unÉditeurModifié", new ObservableDictionary<StringVérifié, StringVérifié>() 
                { { new StringVérifié("NomPremièreInfoModifié"), new StringVérifié("UnePremièreInfoModifié") },
                    { new StringVérifié("NomSecondeInfoModifié"), new StringVérifié("UneSecondeInfoModifié") } }, "Ceci est un synopsisModifié - Livre",
                "Ceci est un commentaire personnelModifié - Livre");

            (oeuvreDataManager.ObtenirTous().ToList()[4] as Scan).ModifierOeuvre("unScanModifié", "CheminImageScanModifié", new DateTime(2000,01,01), 
                "unAuteurModifié", "unÉditeurModifié", new ObservableDictionary<StringVérifié, StringVérifié>() 
                { { new StringVérifié("NomPremièreInfoModifié"), new StringVérifié("UnePremièreInfoModifié") }, 
                    { new StringVérifié("NomSecondeInfoModifié"), new StringVérifié("UneSecondeInfoModifié") } }, "Ceci est un synopsisModifié - Scan", 
                "Ceci est un commentaire personnelModifié - Scan");

            (oeuvreDataManager.ObtenirTous().ToList()[5] as Animé).ModifierOeuvre("unAniméModifié", "CheminImageAniméModifié", new DateTime(2000,01,01), 
                "unAuteurModifié", "unStudioModifié", new ObservableDictionary<StringVérifié, StringVérifié>() 
                { { new StringVérifié("NomPremièreInfoModifié"), new StringVérifié("UnePremièreInfoModifié") }, 
                    { new StringVérifié("NomSecondeInfoModifié"), new StringVérifié("UneSecondeInfoModifié") } }, "Ceci est un synopsisModifié - Animé", 
                "Ceci est un commentaire personnelModifié - Animé");

            for (int i = 0; i < 6; i++)
            {
                WriteLine("Test des modifications des classes héritières de Oeuvre :\n");
                WriteLine(oeuvreDataManager.ObtenirTous().ToList()[i]);
                WriteLine("\n\nTappez sur entrez pour continuer");
                ReadLine();
                Clear();
            }
        }
    }
}
