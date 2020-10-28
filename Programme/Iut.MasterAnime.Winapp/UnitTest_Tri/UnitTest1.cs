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
        public static ObservableCollection<Oeuvre> Cr�ationOeurves()
        {
            var desOeuvres = new ObservableCollection<Oeuvre>();

            desOeuvres.Add(new Anim�("unAnim�1", "CheminImageAnim�",
                new DateTime(1978, 07, 25), "unAuteur", "unStudio", new ObservableDictionary<StringV�rifi�, StringV�rifi�>(),
                "Ceci est un synopsis - Anim�", "Ceci est un commentaire personnel - Anim�"));

            desOeuvres.Add(new S�rie("uneS�rie1", "CheminImageS�rie",
                new DateTime(1958, 06, 30), "unR�alisateur", "unStudio", new ObservableDictionary<StringV�rifi�, StringV�rifi�>(),
                "Ceci est un synopsis - S�rie", "Ceci est un commentaire personnel - S�rie"));

            desOeuvres.Add(new Autre("unAutre1", "CheminImageAutre",
                DateTime.Today, "unCr�ateur", new ObservableDictionary<StringV�rifi�, StringV�rifi�>(), "Ceci est un synopsis - Autre",
                "Ceci est un commentaire personnel - Autre"));

            desOeuvres.Add(new Scan("unScan1", "CheminImageScan",
                new DateTime(2015, 12, 15), "unAuteur", "un�diteur", new ObservableDictionary<StringV�rifi�, StringV�rifi�>(),
                "Ceci est un synopsis - Scan", "Ceci est un commentaire personnel - Scan"));

            desOeuvres.Add(new Film("unFilm1", "CheminImageFilm",
                new DateTime(2008, 05, 06), "unR�alisateur", "unStudio", new ObservableDictionary<StringV�rifi�, StringV�rifi�>(),
                "Ceci est un synopsis - Film", "Ceci est un commentaire personnel - Film"));

            desOeuvres.Add(new Livre("unLivre1", "CheminImageLivre",
                new DateTime(2020, 02, 02), "unAuteur", "un�diteur", new ObservableDictionary<StringV�rifi�, StringV�rifi�>(), 
                "Ceci est un synopsis - Livre", "Ceci est un commentaire personnel - Livre"));




            desOeuvres.Add(new Anim�("unAnim�3", "CheminImageAnim�",
                DateTime.Today, "unAuteur", "unStudio", new ObservableDictionary<StringV�rifi�, StringV�rifi�>(), 
                "Ceci est un synopsis - Anim�", "Ceci est un commentaire personnel - Anim�"));

            desOeuvres.Add(new S�rie("uneS�rie3", "CheminImageS�rie",
                new DateTime(1965, 05, 16), "unR�alisateur", "unStudio", new ObservableDictionary<StringV�rifi�, StringV�rifi�>(), 
                "Ceci est un synopsis - S�rie", "Ceci est un commentaire personnel - S�rie"));

            desOeuvres.Add(new Autre("unAutre3", "CheminImageAutre",
                new DateTime(1784, 11, 23), "unCr�ateur", new ObservableDictionary<StringV�rifi�, StringV�rifi�>(), 
                "Ceci est un synopsis - Autre", "Ceci est un commentaire personnel - Autre"));

            desOeuvres.Add(new Scan("unScan3", "CheminImageScan",
                new DateTime(2018, 05, 07), "unAuteur", "un�diteur", new ObservableDictionary<StringV�rifi�, StringV�rifi�>(),
                "Ceci est un synopsis - Scan", "Ceci est un commentaire personnel - Scan"));

            desOeuvres.Add(new Film("unFilm3", "CheminImageFilm",
                new DateTime(2020, 05, 04), "unR�alisateur", "unStudio", new ObservableDictionary<StringV�rifi�, StringV�rifi�>(), 
                "Ceci est un synopsis - Film", "Ceci est un commentaire personnel - Film"));

            desOeuvres.Add(new Livre("unLivre3", "CheminImageLivre",
                new DateTime(1879, 10, 07), "unAuteur", "un�diteur", new ObservableDictionary<StringV�rifi�, StringV�rifi�>(),
                "Ceci est un synopsis - Livre", "Ceci est un commentaire personnel - Livre"));




            desOeuvres.Add(new Anim�("unAnim�2", "CheminImageAnim�",
                new DateTime(1987, 06, 24), "unAuteur", "unStudio", new ObservableDictionary<StringV�rifi�, StringV�rifi�>(),
                "Ceci est un synopsis - Anim�", "Ceci est un commentaire personnel - Anim�"));

            desOeuvres.Add(new S�rie("uneS�rie2", "CheminImageS�rie",
                new DateTime(2012, 05, 07), "unR�alisateur", "unStudio", new ObservableDictionary<StringV�rifi�, StringV�rifi�>(), 
                "Ceci est un synopsis - S�rie", "Ceci est un commentaire personnel - S�rie"));

            desOeuvres.Add(new Autre("unAutre2", "CheminImageAutre",
                new DateTime(1458, 01, 08), "unCr�ateur", new ObservableDictionary<StringV�rifi�, StringV�rifi�>(), 
                "Ceci est un synopsis - Autre", "Ceci est un commentaire personnel - Autre"));

            desOeuvres.Add(new Scan("unScan2", "CheminImageScan",
                new DateTime(2020, 04, 01), "unAuteur", "un�diteur", new ObservableDictionary<StringV�rifi�, StringV�rifi�>(), 
                "Ceci est un synopsis - Scan", "Ceci est un commentaire personnel - Scan"));

            desOeuvres.Add(new Film("unFilm2", "CheminImageFilm",
                DateTime.Today, "unR�alisateur", "unStudio", new ObservableDictionary<StringV�rifi�, StringV�rifi�>(), 
                "Ceci est un synopsis - Film", "Ceci est un commentaire personnel - Film"));

            desOeuvres.Add(new Livre("unLivre2", "CheminImageLivre",
                new DateTime(1965, 05, 02), "unAuteur", "un�diteur", new ObservableDictionary<StringV�rifi�, StringV�rifi�>(), 
                "Ceci est un synopsis - Livre", "Ceci est un commentaire personnel - Livre"));

            return desOeuvres;
        }

        [TestMethod]
        public void TestTriCroissant()
        {
            ObservableCollection<Oeuvre> tri�es = Tri.TriCroissant(Cr�ationOeurves());

            for(int i=0; i < tri�es.Count-1; i++)
            {
                Assert.IsTrue(tri�es[i].Nom.CompareTo(tri�es[i + 1].Nom) <= 0);
            }
        }

        [TestMethod]
        public void TestTriD�croissant()
        {
            ObservableCollection<Oeuvre> tri�es = Tri.TriD�croissant(Cr�ationOeurves());

            for (int i = 0; i < tri�es.Count - 1; i++)
            {
                Assert.IsTrue(tri�es[i].Nom.CompareTo(tri�es[i + 1].Nom) >= 0);
            }
        }

        [TestMethod]
        public void TestTriType()
        {
            ObservableCollection<Oeuvre> tri�es = Tri.TriType(Cr�ationOeurves());

            var compte = tri�es.Count - 1;
            int nb = 0;
            for (int i = nb; i < compte; i++)
            {
                if(tri�es[i] is Film)
                {
                    nb++;
                    if (tri�es[i + 1] is Film)
                    {
                        Assert.IsTrue(tri�es[i].Nom.CompareTo(tri�es[i+1].Nom) <= 0);
                    }
                } else
                {
                    break;
                }
            }

            for (int i = nb; i < compte; i++)
            {
                if (tri�es[i] is S�rie)
                {
                    nb++;
                    if (tri�es[i + 1] is S�rie)
                    {
                        Assert.IsTrue(tri�es[i].Nom.CompareTo(tri�es[i + 1].Nom) <= 0);
                    }
                }
                else
                {
                    break;
                }
            }

            for (int i = nb; i < compte; i++)
            {
                if (tri�es[i] is Livre)
                {
                    nb++;
                    if (tri�es[i + 1] is Livre)
                    {
                        Assert.IsTrue(tri�es[i].Nom.CompareTo(tri�es[i + 1].Nom) <= 0);
                    }
                }
                else
                {
                    break;
                }
            }

            for (int i = nb; i < compte; i++)
            {
                if (tri�es[i] is Anim�)
                {
                    nb++;
                    if (tri�es[i + 1] is Anim�)
                    {
                        Assert.IsTrue(tri�es[i].Nom.CompareTo(tri�es[i + 1].Nom) <= 0);
                    }
                }
                else
                {
                    break;
                }
            }

            for (int i = nb; i < compte; i++)
            {
                if (tri�es[i] is Scan)
                {
                    nb++;
                    if (tri�es[i + 1] is Scan)
                    {
                        Assert.IsTrue(tri�es[i].Nom.CompareTo(tri�es[i + 1].Nom) <= 0);
                    }
                }
                else
                {
                    break;
                }
            }

            for (int i = nb; i < compte; i++)
            {
                if (tri�es[i] is Autre)
                {
                    nb++;
                    if (tri�es[i + 1] is Autre)
                    {
                        Assert.IsTrue(tri�es[i].Nom.CompareTo(tri�es[i + 1].Nom) <= 0);
                    }
                }
            }

            Assert.IsTrue(tri�es[compte] is Autre);

            Assert.AreEqual(expected: nb, actual: compte);
        }

        [TestMethod]
        public void TestTriDate()
        {
            ObservableCollection<Oeuvre> tri�es = Tri.TriDate(Cr�ationOeurves());

            for (int i = 0; i < tri�es.Count - 1; i++)
            {
                Assert.IsTrue(tri�es[i].Sortie.CompareTo(tri�es[i + 1].Sortie) <= 0);
            }
        }
    }
}
