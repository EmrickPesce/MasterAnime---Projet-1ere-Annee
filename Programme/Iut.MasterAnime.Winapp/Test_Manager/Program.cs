using Iut.MasterAnime.ClassLibrary;
using Iut.MasterAnime.Management;
using System;
using static System.Console;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Iut.MasterAnime.Persistance.Stub;

namespace Test_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Test de la classe Manager\n");

            StubBibliothèqueDataManager bibliothèqueDataManager = new StubBibliothèqueDataManager();

            bibliothèqueDataManager.ToutRetirer();

            bibliothèqueDataManager.ObtenirPrincipale().AjouterOeuvre(new Film("unFilmListePrincipale", "CheminImageFilmListePrincipale",
                new DateTime(2016, 01, 25), "unRéalisateur", "unStudio", new ObservableDictionary<StringVérifié, StringVérifié>(), 
                "Ceci est un synopsis - Film - ListePrincipale",
                "Ceci est un commentaire personnel - Film - ListePrincipale"));

            bibliothèqueDataManager.ObtenirPrincipale().AjouterOeuvre(new Livre("unLivreListePrincipale", "CheminImageLivreListePrincipale",
                new DateTime(1998, 02, 23), "unAuteur", "unÉditeur", new ObservableDictionary<StringVérifié, StringVérifié>(), 
                "Ceci est un synopsis - Livre - ListePrincipale",
                "Ceci est un commentaire personnel - Livre - ListePrincipale"));

            bibliothèqueDataManager.Ajouter(new Bibliothèque("laBibliothèque1", "CheminImageBiblio1", new ObservableCollection<Oeuvre>()));

            bibliothèqueDataManager.AjouterOeuvre(new Autre("unAutreBibliothèque1", "CheminImageAutreBibliothèque1",
                DateTime.Today, "unCréateur", new ObservableDictionary<StringVérifié, StringVérifié>(), "Ceci est un synopsis - Autre - Bibliothèque1",
                "Ceci est un commentaire personnel - Autre - Bibliothèque1"), bibliothèqueDataManager.ObtenirParNom("laBibliothèque1"));

            bibliothèqueDataManager.AjouterOeuvre(new Film("unFilmBibliothèque1", "CheminImageFilmBibliothèque1",
                new DateTime(2019, 05, 25), "unRéalisateur", "unStudio", new ObservableDictionary<StringVérifié, StringVérifié>(),
                "Ceci est un synopsis - Film - Bibliothèque1",
                "Ceci est un commentaire personnel - Film - Bibliothèque1"), bibliothèqueDataManager.ObtenirParNom("laBibliothèque1"));

            bibliothèqueDataManager.AjouterOeuvre(new Série("uneSérieBibliothèque1", "CheminImageSérieBibliothèque1",
                new DateTime(2001, 06, 05), "unRéalisateur", "unStudio", new ObservableDictionary<StringVérifié, StringVérifié>(), 
                "Ceci est un synopsis - Série - Bibliothèque1",
                "Ceci est un commentaire personnel - Série - Bibliothèque1"), bibliothèqueDataManager.ObtenirParNom("laBibliothèque1"));

            Manager manager = new Manager(bibliothèqueDataManager);


            Bibliothèque bibliothèque2 = new Bibliothèque("laBibliothèque2", "CheminImageBiblio2", new ObservableCollection<Oeuvre>());

            bibliothèque2.AjouterOeuvre(new Livre("unLivreBibliothèque2", "CheminImageLivreBibliothèque2",
                DateTime.Today, "unAuteur", "unÉditeur", new ObservableDictionary<StringVérifié, StringVérifié>(), 
                "Ceci est un synopsis - Livre - Bibliothèque2",
                "Ceci est un commentaire personnel - Livre - Bibliothèque2"));

            bibliothèque2.AjouterOeuvre(new Animé("unAniméBibliothèque2", "CheminImageAniméBibliothèque2",
                new DateTime(2015, 05, 01), "unAuteur", "unStudio", new ObservableDictionary<StringVérifié, StringVérifié>(),
                "Ceci est un synopsis - Animé - Bibliothèque2",
                "Ceci est un commentaire personnel - Animé - Bibliothèque2"));

            bibliothèque2.AjouterOeuvre(new Scan("unScanBibliothèque2", "CheminImageScanBibliothèque2",
                DateTime.Today, "unAuteur", "unÉditeur", new ObservableDictionary<StringVérifié, StringVérifié>(), 
                "Ceci est un synopsis - Scan - Bibliothèque2",
                "Ceci est un commentaire personnel - Scan - Bibliothèque2"));


            manager.AjouterOeuvre(new Livre("unLivreManager", "CheminImageLivreManager",
                new DateTime(1998, 02, 23), "unAuteur", "unÉditeur", new ObservableDictionary<StringVérifié, StringVérifié>(),
                "Ceci est un synopsis - Livre - Manager",
                "Ceci est un commentaire personnel - Livre - Manager"));

            manager.AjouterBibliothèque(bibliothèque2);

            WriteLine("Regardons les informations du manager");
            WriteLine("\n\nTappez sur entrez pour continuer");
            ReadLine();
            Test_Du_Manager(manager, false);

            Clear();
            WriteLine("Test de la classe Manager\n");
            WriteLine("Réinitialisons le manager, et réaffichons ses informations");
            WriteLine("\n\nTappez sur entrez pour continuer");
            ReadLine();
            manager.RéinitialiserManager();
            
            Test_Du_Manager(manager, true);

            Clear();
            WriteLine("Test de la classe Manager\n");

            WriteLine("On remet les deux bibliothèques et on suprrime la première via son nom, et la seconde via son Objet :");
            WriteLine($"Ajout de la première : {manager.AjouterBibliothèque(new Bibliothèque("laBibliothèque1", "CheminImageBiblio1", new ObservableCollection<Oeuvre>()))}");
            WriteLine($"Ajout de la seconde : {manager.AjouterBibliothèque(bibliothèque2)}");
            WriteLine($"Suppression de la première : {manager.RetirerBibliothèque("laBibliothèque1")}");
            WriteLine($"Suppression de la seconde : {manager.RetirerBibliothèque(bibliothèque2)}");
            manager.RetirerOeuvre(bibliothèque2[0].Nom); //Car bibliothèque2 contient 3 oeuvres non supprimées de la liste principale
            manager.RetirerOeuvre(bibliothèque2[1].Nom); //Car bibliothèque2 contient 3 oeuvres non supprimées de la liste principale
            manager.RetirerOeuvre(bibliothèque2[2].Nom); //Car bibliothèque2 contient 3 oeuvres non supprimées de la liste principale

            Livre livre = new Livre("unLivreManager", "CheminImageLivreManager",
                new DateTime(1998, 02, 23), "unAuteur", "unÉditeur", new ObservableDictionary<StringVérifié, StringVérifié>(),
                "Ceci est un synopsis - Livre - Manager",
                "Ceci est un commentaire personnel - Livre - Manager");
            Film film = new Film("unFilmManager", "CheminImageFilmManager",
                new DateTime(1998, 02, 23), "unAuteur", "unÉditeur", new ObservableDictionary<StringVérifié, StringVérifié>(),
                "Ceci est un synopsis - Film - Manager",
                "Ceci est un commentaire personnel - Film - Manager");

            WriteLine("\nOn remet deux oeuvres dans le manager et on suprrime la première via son nom, et la seconde via son Objet :");
            WriteLine($"Ajout de la première : {manager.AjouterOeuvre(livre)}");
            WriteLine($"Ajout de la seconde : {manager.AjouterOeuvre(film)}");
            WriteLine($"Suppression de la première : {manager.RetirerOeuvre("unLivreManager")}");
            WriteLine($"Suppression de la seconde : {manager.RetirerOeuvre(film)}");

            WriteLine("\nVérifions : ");

            WriteLine("\n\nTappez sur entrez pour continuer");
            ReadLine();

            Test_Du_Manager(manager, true);

            manager.RéinitialiserManager();
            WriteLine($"On réinitialise le manager puis on ajoute une oeuvre : {manager.AjouterOeuvre(livre)}");
            WriteLine("\nEt on l'affiche : \n");
            WriteLine(manager.ListePrincipale[0]);

            WriteLine("\n\nTappez sur entrez pour continuer et voir ses oeuvres");
            ReadLine();
            Clear();

            bool modif = manager.ModifierOeuvre("unLivreManager", "unLivreManagerModifié", "CheminImageLivreManagerModifié",
                DateTime.Today, null, "unÉditeurModifié",
                new ObservableDictionary<StringVérifié, StringVérifié>() { { new StringVérifié("UnNomInfoModifié"), new StringVérifié("UneInfoModifiée") },
                    { new StringVérifié("UnAutreNomInfoModifiée"), new StringVérifié("UneAutreInfoModifiée") } },
                "Ceci est un synopsis modifié - Livre - Manager",
                "Ceci est un commentaire personnel modifié - Livre - Manager");

            WriteLine($"On la modifie (sauf l'auteur) : {modif}");
            WriteLine("\nEt on l'affiche : \n");
            WriteLine(manager.ListePrincipale[0]);

            WriteLine("\n\nTappez sur entrez pour continuer");
            ReadLine();

            Bibliothèque uneBibliothèque = new Bibliothèque("uneBibliothèque", "CheminImageuneBiblio", new ObservableCollection<Oeuvre>());

            uneBibliothèque.AjouterOeuvre(new Autre("unAutreUneBibliothèque", "CheminImageAutreUneBibliothèque",
                DateTime.Today, "unCréateur", new ObservableDictionary<StringVérifié, StringVérifié>(), "Ceci est un synopsis - Autre - UneBibliothèque",
                "Ceci est un commentaire personnel - Autre - UneBibliothèque"));

            uneBibliothèque.AjouterOeuvre(new Film("unFilmUneBibliothèque", "CheminImageFilmUneBibliothèque",
                new DateTime(2019, 05, 25), "unRéalisateur", "unStudio", new ObservableDictionary<StringVérifié, StringVérifié>(),
                "Ceci est un synopsis - Film - UneBibliothèque",
                "Ceci est un commentaire personnel - Film - UneBibliothèque"));

            uneBibliothèque.AjouterOeuvre(new Série("uneSérieUneBibliothèque", "CheminImageSérieUneBibliothèque",
                new DateTime(2001, 06, 05), "unRéalisateur", "unStudio", new ObservableDictionary<StringVérifié, StringVérifié>(),
                "Ceci est un synopsis - Série - UneBibliothèque",
                "Ceci est un commentaire personnel - Série - UneBibliothèque"));

            Clear();
            WriteLine("Test de la classe Manager\n");

            manager.RéinitialiserManager();
            WriteLine($"On réinitialise le manager puis on ajoute une bibliothèque : {manager.AjouterBibliothèque(uneBibliothèque)}");
            WriteLine("Et on l'affiche via ObtenirBibliothèque : ");
            WriteLine("\n\nTappez sur entrez pour continuer");
            ReadLine();

            Test_D_Une_Bibliothèque(manager.ObtenirBibliothèque("uneBibliothèque"));

            WriteLine("Test de la classe Manager\n");
            WriteLine("\nOn la modifie (sauf le chemin de l'image) et la réaffiche (via l'indexeur avec le nom) :");
            WriteLine("\n\nTappez sur entrez pour continuer");
            ReadLine();
            Clear();

            ObservableCollection<Oeuvre> desOeuvres = new ObservableCollection<Oeuvre>();
            desOeuvres.Add(new Livre("unLivreBiblioModifiée", "CheminImageLivreBiblioModifiée",
                DateTime.Today, "unAuteur", "unÉditeur", new ObservableDictionary<StringVérifié, StringVérifié>(),
                "Ceci est un synopsis - Livre - BiblioModifiée",
                "Ceci est un commentaire personnel - Livre - BiblioModifiée"));
            desOeuvres.Add(new Animé("unAniméBiblioModifiée", "CheminImageAniméBiblioModifiée",
                new DateTime(2015, 05, 01), "unAuteur", "unStudio", new ObservableDictionary<StringVérifié, StringVérifié>(), 
                "Ceci est un synopsis - Animé - BiblioModifiée",
                "Ceci est un commentaire personnel - Animé - BiblioModifiée"));
            desOeuvres.Add(new Scan("unScanBiblioModifiée", "CheminImageScanBiblioModifiée",
                DateTime.Today, "unAuteur", "unÉditeur", new ObservableDictionary<StringVérifié, StringVérifié>(), 
                "Ceci est un synopsis - Scan - BiblioModifiée",
                "Ceci est un commentaire personnel - Scan - BiblioModifiée"));

            manager.ModifierBibliothèque("uneBibliothèque", "uneBibliothèqueModifiée", null, desOeuvres);

            Test_D_Une_Bibliothèque(manager["uneBibliothèqueModifiée"]);

            WriteLine("On remarque que la Bibliothèque a été modifiée");
            WriteLine("\n\nTappez sur entrez pour continuer");
            ReadLine();
            Clear();


            WriteLine("Test de la classe Manager\n");

            WriteLine("Ajoutons maintenant les bibliothèques 1 et 2 comme précédemment");
            manager.AjouterBibliothèque(new Bibliothèque("laBibliothèque1", "CheminImageBiblio1", new ObservableCollection<Oeuvre>()));
            manager.AjouterBibliothèque(bibliothèque2);
            WriteLine($"Il devrait donc y avoir 3 bibliothèques, comptons : {manager.NombreBibliothèque()}");

            WriteLine("\nCherchons les bibliothèques avec \'1\' dans le nom : ");
            foreach (Bibliothèque bibliothèque in manager.RechercherBibliothèque("1"))
            {
                WriteLine($"Trouvée : {bibliothèque.Nom}");
            }
            WriteLine("\nCherchons les bibliothèques avec \'biblio\' dans le nom : ");
            foreach (Bibliothèque bibliothèque in manager.RechercherBibliothèque("biblio"))
            {
                WriteLine($"Trouvée : {bibliothèque.Nom}");
            }

            WriteLine("\n\nTappez sur entrez pour continuer");
            ReadLine();
            Clear();

            WriteLine("Test de la classe Manager\n");

            WriteLine("Enfin on test l'indexeur du numéro, en affichant le juste le nom des bibliothèques :");


            for(int i=0; i<manager.NombreBibliothèque(); i++)
            {
                WriteLine(manager[i].Nom);
            }
            
            WriteLine("\n\nTappez sur entrez pour continuer");
            ReadLine();
            Clear();
        }

        public static void Test_D_Une_Bibliothèque(Bibliothèque bibliothèque)
        {
            Clear();
            WriteLine("Test de la classe Manager\n");
            WriteLine($"Informations de la Bibliothèque :\n\n\tNom : {bibliothèque.Nom}\n\tImage : {bibliothèque.Image}\n");
            WriteLine("\n\nTappez sur entrez pour continuer et voir ses oeuvres");
            ReadLine();
            Clear();

            foreach (Oeuvre oeuvre in bibliothèque.LesOeuvres)
            {
                WriteLine("Test de la classe Manager\n");
                WriteLine("\n\tSes oeuvres :\n");
                WriteLine(oeuvre);

                WriteLine("\n\nTappez sur entrez pour continuer");
                ReadLine();
                Clear();
            }
        }

        public static void Test_Du_Manager(Manager manager, bool transition)
        {
            Clear();
            WriteLine("Test de la classe Manager\n");
            WriteLine("\nAffichons les informations de la liste principale, contenant toutes les oeuvres de l'application");
            WriteLine("\n\nTappez sur entrez pour continuer");
            ReadLine();
            Clear();
            Test_D_Une_Bibliothèque(manager.ListePrincipale);

            if (transition)
            {
                WriteLine("Test de la classe Manager\n");
                WriteLine("Transition : Rien n'a dû s'afficher pour ses oeuvres");
                WriteLine("\n\nTappez sur entrez pour continuer");
                ReadLine();
                Clear();
            }
            
            WriteLine("Test de la classe Manager\n");
            WriteLine("Affichons les informations des bibliothèques du manager");
            WriteLine("\n\nTappez sur entrez pour continuer");
            ReadLine();
            Clear();

            foreach (Bibliothèque biblio in manager.LesBibliothèques)
            {

                WriteLine("Test de la classe Manager\n");
                WriteLine("Affichons les informations des bibliothèques du manager");
                WriteLine($"\t\nAffichage des informations de la bibliothèque \'{biblio.Nom}\' du manager");
                WriteLine("\n\nTappez sur entrez pour continuer");
                ReadLine();
                Clear();
                Test_D_Une_Bibliothèque(biblio);
            }

            if (transition)
            {
                WriteLine("Test de la classe Manager\n");
                WriteLine("Transition : Rien n'a dû s'afficher pour ses bibliothèques");
                WriteLine("\n\nTappez sur entrez pour continuer");
                ReadLine();
                Clear();
            }
        }
    }
}
