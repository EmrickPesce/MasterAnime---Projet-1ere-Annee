using Iut.MasterAnime.ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace UnitTest_Tri
{
    [TestClass]
    public class UnitTest1
    {
        public static ObservableCollection<Oeuvre> CréationOeurves()
        {
            var desOeuvres = new ObservableCollection<Oeuvre>();

            desOeuvres.Add(new Animé("unAnimé1", "CheminImageAnimé",
                new DateTime(1978, 07, 25), "unAuteur", "unStudio", new ObservableDictionary<StringVérifié, StringVérifié>(),
                "Ceci est un synopsis - Animé", "Ceci est un commentaire personnel - Animé"));

            desOeuvres.Add(new Série("uneSérie1", "CheminImageSérie",
                new DateTime(1958, 06, 30), "unRéalisateur", "unStudio", new ObservableDictionary<StringVérifié, StringVérifié>(),
                "Ceci est un synopsis - Série", "Ceci est un commentaire personnel - Série"));

            desOeuvres.Add(new Autre("unAutre1", "CheminImageAutre",
                DateTime.Today, "unCréateur", new ObservableDictionary<StringVérifié, StringVérifié>(), "Ceci est un synopsis - Autre",
                "Ceci est un commentaire personnel - Autre"));

            desOeuvres.Add(new Scan("unScan1", "CheminImageScan",
                new DateTime(2015, 12, 15), "unAuteur", "unÉditeur", new ObservableDictionary<StringVérifié, StringVérifié>(),
                "Ceci est un synopsis - Scan", "Ceci est un commentaire personnel - Scan"));

            desOeuvres.Add(new Film("unFilm1", "CheminImageFilm",
                new DateTime(2008, 05, 06), "unRéalisateur", "unStudio", new ObservableDictionary<StringVérifié, StringVérifié>(),
                "Ceci est un synopsis - Film", "Ceci est un commentaire personnel - Film"));

            desOeuvres.Add(new Livre("unLivre1", "CheminImageLivre",
                new DateTime(2020, 02, 02), "unAuteur", "unÉditeur", new ObservableDictionary<StringVérifié, StringVérifié>(), 
                "Ceci est un synopsis - Livre", "Ceci est un commentaire personnel - Livre"));




            desOeuvres.Add(new Animé("unAnimé3", "CheminImageAnimé",
                DateTime.Today, "unAuteur", "unStudio", new ObservableDictionary<StringVérifié, StringVérifié>(), 
                "Ceci est un synopsis - Animé", "Ceci est un commentaire personnel - Animé"));

            desOeuvres.Add(new Série("uneSérie3", "CheminImageSérie",
                new DateTime(1965, 05, 16), "unRéalisateur", "unStudio", new ObservableDictionary<StringVérifié, StringVérifié>(), 
                "Ceci est un synopsis - Série", "Ceci est un commentaire personnel - Série"));

            desOeuvres.Add(new Autre("unAutre3", "CheminImageAutre",
                new DateTime(1784, 11, 23), "unCréateur", new ObservableDictionary<StringVérifié, StringVérifié>(), 
                "Ceci est un synopsis - Autre", "Ceci est un commentaire personnel - Autre"));

            desOeuvres.Add(new Scan("unScan3", "CheminImageScan",
                new DateTime(2018, 05, 07), "unAuteur", "unÉditeur", new ObservableDictionary<StringVérifié, StringVérifié>(),
                "Ceci est un synopsis - Scan", "Ceci est un commentaire personnel - Scan"));

            desOeuvres.Add(new Film("unFilm3", "CheminImageFilm",
                new DateTime(2020, 05, 04), "unRéalisateur", "unStudio", new ObservableDictionary<StringVérifié, StringVérifié>(), 
                "Ceci est un synopsis - Film", "Ceci est un commentaire personnel - Film"));

            desOeuvres.Add(new Livre("unLivre3", "CheminImageLivre",
                new DateTime(1879, 10, 07), "unAuteur", "unÉditeur", new ObservableDictionary<StringVérifié, StringVérifié>(),
                "Ceci est un synopsis - Livre", "Ceci est un commentaire personnel - Livre"));




            desOeuvres.Add(new Animé("unAnimé2", "CheminImageAnimé",
                new DateTime(1987, 06, 24), "unAuteur", "unStudio", new ObservableDictionary<StringVérifié, StringVérifié>(),
                "Ceci est un synopsis - Animé", "Ceci est un commentaire personnel - Animé"));

            desOeuvres.Add(new Série("uneSérie2", "CheminImageSérie",
                new DateTime(2012, 05, 07), "unRéalisateur", "unStudio", new ObservableDictionary<StringVérifié, StringVérifié>(), 
                "Ceci est un synopsis - Série", "Ceci est un commentaire personnel - Série"));

            desOeuvres.Add(new Autre("unAutre2", "CheminImageAutre",
                new DateTime(1458, 01, 08), "unCréateur", new ObservableDictionary<StringVérifié, StringVérifié>(), 
                "Ceci est un synopsis - Autre", "Ceci est un commentaire personnel - Autre"));

            desOeuvres.Add(new Scan("unScan2", "CheminImageScan",
                new DateTime(2020, 04, 01), "unAuteur", "unÉditeur", new ObservableDictionary<StringVérifié, StringVérifié>(), 
                "Ceci est un synopsis - Scan", "Ceci est un commentaire personnel - Scan"));

            desOeuvres.Add(new Film("unFilm2", "CheminImageFilm",
                DateTime.Today, "unRéalisateur", "unStudio", new ObservableDictionary<StringVérifié, StringVérifié>(), 
                "Ceci est un synopsis - Film", "Ceci est un commentaire personnel - Film"));

            desOeuvres.Add(new Livre("unLivre2", "CheminImageLivre",
                new DateTime(1965, 05, 02), "unAuteur", "unÉditeur", new ObservableDictionary<StringVérifié, StringVérifié>(), 
                "Ceci est un synopsis - Livre", "Ceci est un commentaire personnel - Livre"));

            return desOeuvres;
        }

        [TestMethod]
        public void TestTriCroissant()
        {
            ObservableCollection<Oeuvre> triées = Tri.TriCroissant(CréationOeurves());

            for(int i=0; i < triées.Count-1; i++)
            {
                Assert.IsTrue(triées[i].Nom.CompareTo(triées[i + 1].Nom) <= 0);
            }
        }

        [TestMethod]
        public void TestTriDécroissant()
        {
            ObservableCollection<Oeuvre> triées = Tri.TriDécroissant(CréationOeurves());

            for (int i = 0; i < triées.Count - 1; i++)
            {
                Assert.IsTrue(triées[i].Nom.CompareTo(triées[i + 1].Nom) >= 0);
            }
        }

        [TestMethod]
        public void TestTriType()
        {
            ObservableCollection<Oeuvre> triées = Tri.TriType(CréationOeurves());

            var compte = triées.Count - 1;
            int nb = 0;
            for (int i = nb; i < compte; i++)
            {
                if(triées[i] is Film)
                {
                    nb++;
                    if (triées[i + 1] is Film)
                    {
                        Assert.IsTrue(triées[i].Nom.CompareTo(triées[i+1].Nom) <= 0);
                    }
                } else
                {
                    break;
                }
            }

            for (int i = nb; i < compte; i++)
            {
                if (triées[i] is Série)
                {
                    nb++;
                    if (triées[i + 1] is Série)
                    {
                        Assert.IsTrue(triées[i].Nom.CompareTo(triées[i + 1].Nom) <= 0);
                    }
                }
                else
                {
                    break;
                }
            }

            for (int i = nb; i < compte; i++)
            {
                if (triées[i] is Livre)
                {
                    nb++;
                    if (triées[i + 1] is Livre)
                    {
                        Assert.IsTrue(triées[i].Nom.CompareTo(triées[i + 1].Nom) <= 0);
                    }
                }
                else
                {
                    break;
                }
            }

            for (int i = nb; i < compte; i++)
            {
                if (triées[i] is Animé)
                {
                    nb++;
                    if (triées[i + 1] is Animé)
                    {
                        Assert.IsTrue(triées[i].Nom.CompareTo(triées[i + 1].Nom) <= 0);
                    }
                }
                else
                {
                    break;
                }
            }

            for (int i = nb; i < compte; i++)
            {
                if (triées[i] is Scan)
                {
                    nb++;
                    if (triées[i + 1] is Scan)
                    {
                        Assert.IsTrue(triées[i].Nom.CompareTo(triées[i + 1].Nom) <= 0);
                    }
                }
                else
                {
                    break;
                }
            }

            for (int i = nb; i < compte; i++)
            {
                if (triées[i] is Autre)
                {
                    nb++;
                    if (triées[i + 1] is Autre)
                    {
                        Assert.IsTrue(triées[i].Nom.CompareTo(triées[i + 1].Nom) <= 0);
                    }
                }
            }

            Assert.IsTrue(triées[compte] is Autre);

            Assert.AreEqual(expected: nb, actual: compte);
        }

        [TestMethod]
        public void TestTriDate()
        {
            ObservableCollection<Oeuvre> triées = Tri.TriDate(CréationOeurves());

            for (int i = 0; i < triées.Count - 1; i++)
            {
                Assert.IsTrue(triées[i].Sortie.CompareTo(triées[i + 1].Sortie) <= 0);
            }
        }
    }
}
