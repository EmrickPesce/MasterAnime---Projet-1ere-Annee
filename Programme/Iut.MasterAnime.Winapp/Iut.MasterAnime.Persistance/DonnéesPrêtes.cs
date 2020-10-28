using Iut.MasterAnime.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Iut.MasterAnime.Persistance
{
    /// <summary>
    /// Class donnant des données pour une application
    /// </summary>
    public static class DonnéesPrêtes
    {
        /// <summary>
        /// Des oeuvres déjà crées
        /// </summary>
        /// <returns>Les oeuvres crées</returns>
        public static List<Oeuvre> DonnéesDOeuvres()
        {
            return new List<Oeuvre>()
            {
                new Série("13 Reasons Why", "13-reasons-why.jpg", new DateTime(2017, 03, 31), "Biran Yorkey", "Netflix", new ObservableDictionary<StringVérifié, StringVérifié>()
                { { new StringVérifié("Âge minimum"), new StringVérifié("16 ans")}, { new StringVérifié("Public ciblé"), new StringVérifié("Ados")} },
                "Adapté du roman Treize raisons de Jay Asher, 13 Reasons Why suit Clay Jensen, un adolescent en deuil depuis le suicide de sa camarade de classe, Hannah Baker. " +
                "Quelques temps après sa mort, il reçoit une boîte contenant sept cassettes enregistrée par la jeune femme. " +
                "Ces cassettes comportent 13 raisons qui ont poussé la jeune femme à mettre fin à ses jours, et 13 personnes qu'elle tient pour responsables.",
                "Commentaire du développeur de l'application - La première saison etait vraiment bien. " +
                "Je suis en train de regarder la dernière saison à ce jour, la 4ème, et je la trouve un peu lente à se lancer."),

                new Série("Riverdale", "riverdale.jpg", new DateTime(2017, 01, 26), "Aguirre-Sacasa", "Netflix", new ObservableDictionary<StringVérifié, StringVérifié>()
                { { new StringVérifié("Âge minimum"), new StringVérifié("13 ans")}, { new StringVérifié("Public ciblé"), new StringVérifié("Ados")} },
                "Sous ses airs de petite ville tranquille, Riverdale cache en réalité de sombres secrets. Alors qu'une nouvelle année scolaire débute, le jeune Archie Andrews et ses amis " +
                "Betty, Jughead, et Kevin voient leur quotidien bouleversé par la mort mystérieuse de Jason Blossom, un de leurs camarades de lycée.",
                "Commentaire du développeur de l'application - Malgré que ce soit un peu plus orientée pour fille d'après certaines personnes, elle se laisse regarder pour passer le temps."),

                new Série("Lucifer", "Lucifer.jpg", new DateTime(2016, 01, 25), "Tom Kapinos", "Netflix", new ObservableDictionary<StringVérifié, StringVérifié>()
                { { new StringVérifié("Pays d'origine"), new StringVérifié("États-Unis")}, { new StringVérifié("Chaîne d'origine"), new StringVérifié("Fox")},
                { new StringVérifié("Saisons"), new StringVérifié("4")}},
                "Lassé et fatigué d'être le « Seigneur des Enfers », Lucifer Morningstar abandonne son royaume et s'en va à Los Angeles où il est propriétaire d'une boîte de nuit appelée « Lux ». " +
                "Lucifer a reçu le don de contraindre les gens à révéler leurs désirs les plus profonds.",
                "Commentaire du développeur de l'application - J'estime que cette série est la meilleure que j'ai vu, j'ai vraiment bien aimé."),

                new Animé("Rick et Morty", "ricketmorty.jpg", new DateTime(2013, 12, 2), "Dan Harmon", "VSI/Chinkel", new ObservableDictionary<StringVérifié, StringVérifié>()
                { { new StringVérifié("Pays d'origine"), new StringVérifié("États-Unis")}, { new StringVérifié("Chaîne d'origine"), new StringVérifié("Adult Swim")},
                { new StringVérifié("Saisons"), new StringVérifié("4")}, { new StringVérifié("Épisodes"), new StringVérifié("36")}},
                "Rick est un scientifique âgé et déséquilibré qui a récemment renoué avec sa famille. Il passe le plus clair de son temps à entraîner son petit-fils Morty dans des " +
                "aventures extraordinaires et dangereuses, à travers l'espace et dans des univers parallèles.",
                "Commentaire du développeur de l'application - Un animé plutôt axé sur l'humour. Il est plutôt bien pour passer le temps, même si il peut y avoir mieux."),

                new Animé("Death Note Animé", "death_note.jpg", new DateTime(2006, 10, 03), "Tsugumi Ōba", "Madhouse", new ObservableDictionary<StringVérifié, StringVérifié>()
                { { new StringVérifié("Pays d'origine"), new StringVérifié("Japon")}, { new StringVérifié("Statut"), new StringVérifié("Terminé")}},
                "Light Yagami est un lycéen surdoué qui juge le monde actuel criminel, pourri et corrompu. Sa vie change du tout au tout le jour où il ramasse par hasard un mystérieux " +
                "cahier intitulé « Death Note ». Son mode d'emploi indique que « la personne dont le nom est écrit dans ce cahier meurt ».",
                "Commentaire du développeur de l'application - C'est un super animé qui nous fait réfléchir sur l'intelligence des différentes ruses utilisées."),

                new Scan("Death Note Scan", "DeathNoteScan.jpg", new DateTime(2003, 01, 01), "Tsugumi Ōba", "VIZ Media", new ObservableDictionary<StringVérifié, StringVérifié>()
                { { new StringVérifié("Pays d'origine"), new StringVérifié("Japon")}, { new StringVérifié("Dessinateur"), new StringVérifié("Takeshi Obata")}},
                "Light Yagami est un lycéen surdoué qui juge le monde actuel criminel, pourri et corrompu. Sa vie change du tout au tout le jour où il ramasse par hasard un mystérieux " +
                "cahier intitulé « Death Note ». Son mode d'emploi indique que « la personne dont le nom est écrit dans ce cahier meurt ».",
                "Commentaire du développeur de l'application - Un très bon manga. Si on ne le lit pas, il faut au moins voir son adaption en animé."),

                new Scan("solo leveling", "solo-leveling.png", new DateTime(2016, 07, 25), "Chu-Gong", "Kakao, D&C Media", new ObservableDictionary<StringVérifié, StringVérifié>()
                { { new StringVérifié("Volumes"), new StringVérifié("2")}, { new StringVérifié("Dessinateur"), new StringVérifié("Hyoen-Gun")}},
                "Depuis qu'un portail connectant notre monde à un monde peuplé de monstres et de créatures en tout genre est apparu, des personnes \"ordinaires\" ont acquis la capacité de " +
                "chasser ces derniers. On les appelle les chasseurs. Vous pensez qu'ils sont tous balaises ?",
                "Commentaire du développeur de l'application - C'est un scan pas très connu, mais qui est vraiment bien."),

                new Autre("Loup Garou", "LoupGarou.png", new DateTime(2001, 01, 01), "Hervé Marly", new ObservableDictionary<StringVérifié, StringVérifié>()
                { { new StringVérifié("Type"), new StringVérifié("Jeu de société")}, { new StringVérifié("Illustrateur"), new StringVérifié("Alexios Tjoyas")},
                { new StringVérifié("Distributeurs"), new StringVérifié("Hodin")}},
                "Chaque Villageois tente de démasquer un Loup-Garou et de faire voter contre lui. - Les Loups-Garous doivent se faire passer pour des villageois. - La Voyante " +
                "ainsi que la Petite Fille doivent aider les autres Villageois, mais sans mettre trop tôt leur vie en danger en exposant leur identité.",
                "Commentaire du développeur de l'application - C'est un très bon jeu de société pouvant réunir beaucoup de joueurs de tout âge. Il amène à la réflexion, la méfiance et au mensonge..."),

                new Film("Harry Potter", "HarryPotter.jpg", new DateTime(2001,12,05), "Chris Columbus", "Warner Bros", new ObservableDictionary<StringVérifié, StringVérifié>()
                { { new StringVérifié("Auteur d'origine"), new StringVérifié("J.K. Rowling")}, { new StringVérifié("Films"), new StringVérifié("8")},
                { new StringVérifié("Genre"), new StringVérifié("Fanstastique")}},
                "Orphelin, le jeune Harry Potter peut enfin quitter ses tyranniques oncle et tante Dursley lorsqu'un curieux messager lui révèle qu'il est un sorcier. À 11 ans, Harry va " +
                "enfin pouvoir intégrer la légendaire école de sorcellerie de Poudlard, y trouver une famille digne de ce nom et des amis, développer ses dons, et préparer son glorieux avenir.",
                "Commentaire du développeur de l'application - Cet oeurve est très connue, bien que certaines personnes ne l'aient pas encore vue. Personnellement, je la trouve bien."),

                new Livre("Les Misérables", "LesMisérables.jpg", new DateTime(1862, 01, 01), "Victore Hugo", "Albert Lacroix", new ObservableDictionary<StringVérifié, StringVérifié>()
                { { new StringVérifié("Tomes"), new StringVérifié("5")}, { new StringVérifié("Genre"), new StringVérifié("Roman")}},
                "Au début, Jean Valjean est un innocent qui a volé un pain et qui ne rencontre pas un président Magnaud pour le sauver du bagne. Forçat, il devient un bandit. ... " +
                "C'est lui qui fait luire l'espoir aux yeux des désespérés, qui ramène la bonté au cœur meurtri et desséché des misérables.",
                "Commentaire du développeur de l'application - Une oeuvre de la culture française.")
            };
        }

        /// <summary>
        /// Une Bibliothèque et une collection de bibliothèques déjà crées
        /// </summary>
        /// <returns>La Bibliothèque et la collection de bibliothèques crées</returns>
        public static (Bibliothèque, List<Bibliothèque>) DonnéesDeBibliothèques()
        {
            List<Oeuvre> desOeuvres = DonnéesDOeuvres();

            Bibliothèque listePrincipale = new Bibliothèque("Liste Principale", "Luffy.jpg", new ObservableCollection<Oeuvre>(desOeuvres));

            List<Bibliothèque> lesBibliothèques = new List<Bibliothèque>()
            {
                new Bibliothèque("Liste de Films", "Soinc.jpg", new ObservableCollection<Oeuvre>(desOeuvres.Where (oeuvre => oeuvre is Film))),

                new Bibliothèque("Liste de Séries", "LuciferBiblio.jpg", new ObservableCollection<Oeuvre>(desOeuvres.Where (oeuvre => oeuvre is Série))),

                new Bibliothèque("Liste de Livres", "livre-illustration-lire.jpg", new ObservableCollection<Oeuvre>(desOeuvres.Where (oeuvre => oeuvre is Livre))),

                new Bibliothèque("Liste de Scan", "Scan.jpg", new ObservableCollection<Oeuvre>(desOeuvres.Where (oeuvre => oeuvre is Scan))),

                new Bibliothèque("Liste d'Animés", "Animé.png", new ObservableCollection<Oeuvre>(desOeuvres.Where (oeuvre => oeuvre is Animé))),

                new Bibliothèque("Liste d'Autres", "Autre.jpg", new ObservableCollection<Oeuvre>(desOeuvres.Where (oeuvre => oeuvre is Autre))),
            };

            return (listePrincipale, lesBibliothèques);
        }
    }
}
