using System;
using static System.Console;
using System.Collections.ObjectModel;
using Iut.MasterAnime.ClassLibrary;
using Iut.MasterAnime.Persistance.Stub;

namespace Test_Bibliothèque
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Test de la classe Bibliothèque");

            StubBibliothèqueDataManager bibliothèqueDataManager = new StubBibliothèqueDataManager();

            bibliothèqueDataManager.ToutRetirer();

            bibliothèqueDataManager.Ajouter(new Bibliothèque("laBibliothèque", "CheminImageBiblio", new ObservableCollection<Oeuvre>()));

            Bibliothèque bibliothèque = bibliothèqueDataManager.ObtenirParNom("laBibliothèque");

            bibliothèque.AjouterOeuvre(new Autre("unAutre", "CheminImageAutre",
                DateTime.Today, "unCréateur", new ObservableDictionary<StringVérifié, StringVérifié>(), "Ceci est un synopsis - Autre", 
                "Ceci est un commentaire personnel - Autre"));

            bibliothèque.AjouterOeuvre(new Film("unFilm", "CheminImageFilm",
                DateTime.Today, "unRéalisateur", "unStudio", new ObservableDictionary<StringVérifié, StringVérifié>(), "Ceci est un synopsis - Film",
                "Ceci est un commentaire personnel - Film"));

            bibliothèque.AjouterOeuvre(new Série("uneSérie", "CheminImageSérie",
                DateTime.Today, "unRéalisateur", "unStudio", new ObservableDictionary<StringVérifié, StringVérifié>(), "Ceci est un synopsis - Série", 
                "Ceci est un commentaire personnel - Série"));

            bibliothèque.AjouterOeuvre(new Livre("unLivre", "CheminImageLivre",
                DateTime.Today, "unAuteur", "unÉditeur", new ObservableDictionary<StringVérifié, StringVérifié>(), "Ceci est un synopsis - Livre", 
                "Ceci est un commentaire personnel - Livre"));

            bibliothèque.AjouterOeuvre(new Animé("unAnimé", "CheminImageAnimé",
                DateTime.Today, "unAuteur", "unStudio", new ObservableDictionary<StringVérifié, StringVérifié>(), "Ceci est un synopsis - Animé",
                "Ceci est un commentaire personnel - Animé"));

            bibliothèque.AjouterOeuvre(new Scan("unScan", "CheminImageScan",
                DateTime.Today, "unAuteur", "unÉditeur", new ObservableDictionary<StringVérifié, StringVérifié>(), "Ceci est un synopsis - Scan",
                "Ceci est un commentaire personnel - Scan"));



            WriteLine($"Informations de la Bibliothèque :\nNom : {bibliothèqueDataManager.ObtenirParNom("laBibliothèque").Nom}\nImage : {bibliothèque.Image}\n");
            WriteLine("\n\nTappez sur entrez pour continuer et voir ses oeuvres");
            ReadLine();
            Clear();

            foreach(Oeuvre oeuvre in bibliothèqueDataManager.ObtenirParNom("laBibliothèque").LesOeuvres)
            {
                WriteLine("Ses oeuvres :\n");

                WriteLine(oeuvre);

                WriteLine("\n\nTappez sur entrez pour continuer");
                ReadLine();
                Clear();
            }

            WriteLine("On retire toutes ses oeuvres sauf la série\n");
            bibliothèque.RetirerOeuvre("unAutre");
            bibliothèque.RetirerOeuvre(bibliothèqueDataManager.ObtenirParNom("laBibliothèque").ObtenirOeuvre("unFilm"));
            bibliothèque.RetirerOeuvre("unLivre");
            bibliothèque.RetirerOeuvre("unAnimé");
            bibliothèque.RetirerOeuvre("unScan");
            
            WriteLine($"unAutre présente ? : {bibliothèqueDataManager.ObtenirParNom("laBibliothèque").ContientOeuvre("unAutre")}   (Doit être False)");
            WriteLine($"unFilm présente ? : {bibliothèqueDataManager.ObtenirParNom("laBibliothèque").ContientOeuvre("unFilm")}   (Doit être False)");
            WriteLine($"unLivre présente ? : {bibliothèqueDataManager.ObtenirParNom("laBibliothèque").ContientOeuvre("unLivre")}   (Doit être False)");
            WriteLine($"unAnimé présente ? : {bibliothèque.ContientOeuvre(bibliothèque.ObtenirOeuvre("unAnimé"))}   (Doit être False)");
            WriteLine($"unScan présente ? : {bibliothèque.ContientOeuvre(bibliothèque.ObtenirOeuvre("unScan"))}   (Doit être False)");
            WriteLine($"uneSérie présente ? : {bibliothèque.ContientOeuvre("uneSérie")}   (Doit être True)");
        }
    }
}
