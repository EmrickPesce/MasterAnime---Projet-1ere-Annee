using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using Iut.MasterAnime.Winapp.CodePagePrincipale;
using Iut.MasterAnime.Winapp.CodeAffichageOeuvre;
using Iut.MasterAnime.Winapp.CodeParametres;
using Iut.MasterAnime.Winapp.CodePageRecherche;
using Iut.MasterAnime.Winapp.CodeModificationOeuvre;
using Iut.MasterAnime.Winapp.CodeModifierBibliothèque;
using Iut.MasterAnime.Winapp.CodeCréationBibliothèque;
using System.Windows;
using Iut.MasterAnime.Winapp.CodeCréationOeuvre;
using System.Windows.Media;

namespace Iut.MasterAnime.Winapp
{
    /// <summary>
    /// Une classe Navigateur permettant à la vue de naviguer entre les différents user control
    /// </summary>
    public class Navigateur : INotifyPropertyChanged
    {
        /// <summary>
        /// La seul instance du Navigateur
        /// </summary>
        private static Navigateur instanceUnique;

        /// <summary>
        /// Le string permettant de faire référence à la page principale
        /// </summary>
        public const String PagePrincipale_UC = "pagePrincipale";

        /// <summary>
        /// Le string permettant de faire référence à l'affichage des oeuvres
        /// </summary>
        public const String AffichageOeuvre_UC = "affichageOeuvre";

        /// <summary>
        /// Le string permettant de faire référence à la page des paramètres
        /// </summary>
        public const String Paramètres_UC = "paramètres";

        /// <summary>
        /// Le string permettant de faire référence à la page de recherche
        /// </summary>
        public const String Recherche_UC = "recherche";

        /// <summary>
        /// Le string permettant de faire référence à la page de modification d'oeuvre
        /// </summary>
        public const String ModificationOeuvre_UC = "modificationOeuvre";

        /// <summary>
        /// Le string permettant de faire référence à la page de création d'une oeuvre
        /// </summary>
        public const String CréationOeuvre_UC = "créationOeuvre";

        /// <summary>
        /// Le string permettant de faire référence à la page de sélection d'oeuvres pour les supprimer d'une bibliothèque
        /// </summary>
        public const String SélectionSuppressionOeuvres_UC = "sélectionSuppressionOeuvres";

        /// <summary>
        /// Le string permettant de faire référence à la page de sélection d'oeuvres pour les ajouter à une nouvelle bibliothèque
        /// </summary>
        public const String SélectionAjoutOeuvresCréation_UC = "sélectionAjoutOeuvresCréation";

        /// <summary>
        /// Le string permettant de faire référence à la page de sélection d'oeuvres pour les ajouter à une bibliothèque existante
        /// </summary>
        public const String SélectionAjoutOeuvresModification_UC = "sélectionAjoutOeuvresModification";

        /// <summary>
        /// Le dictionary contenant les instances de certains users controls utilisés dans l'application
        /// </summary>
        Dictionary<string, UserControl> userControls = new Dictionary<string, UserControl>()
        {
            [PagePrincipale_UC] = new PagePrincipale(),
            [AffichageOeuvre_UC] = new AffichageOeuvre(),
            [Paramètres_UC] = new Paramètres(),
            [Recherche_UC] = new PageRecherche(),
            [ModificationOeuvre_UC] = new ModificationOeuvre(),
            [CréationOeuvre_UC] = new CréationOeuvre(),
            [SélectionSuppressionOeuvres_UC] = new SélectionSuppressionOeuvres(),
            [SélectionAjoutOeuvresCréation_UC] = new SélectionAjoutOeuvresCréation(),
            [SélectionAjoutOeuvresModification_UC] = new SélectionAjoutOeuvresModification(),
        };

        /// <summary>
        /// Le user control sélectionné, et donc étant affiché
        /// </summary>
        public UserControl UserControlSélectionné
        {
            get => userControlSélectionné;
            private set
            {
                //Si l'ancien user control possède au moins 3 instances : null (lors de la création du premier user control sélectionné), et deux autres user control
                if (anciensUserControls.Count > 2)
                {
                    //Si l'ancien user control n'est pas le même que le nouveau
                    if (anciensUserControls.Peek() == null ? false : !anciensUserControls.Peek().Equals(value))
                    {
                        AncienUserControl = userControlSélectionné;
                    }
                    //Si l'ancien user control est le même que le nouveau, afin d'éviter les boucles de retour
                    else
                    {
                        anciensUserControls.Pop();
                    }
                }
                else
                {
                    AncienUserControl = userControlSélectionné;
                }

                userControlSélectionné = value;
                OnPropertyChanged();
            }
        }
        private UserControl userControlSélectionné;

        /// <summary>
        /// Le user control étant précédemment sélectionné. Il permet un retour en arrière pour l'utilisateur
        /// </summary>
        public UserControl AncienUserControl
        {
            get
            {
                return anciensUserControls.Peek();
            }
            set
            {
                anciensUserControls.Push(value);
            }
        }
        private Stack<UserControl> anciensUserControls = new Stack<UserControl>();

        /// <summary>
        /// Le constructeur de la classe du Navigateur
        /// </summary>
        private Navigateur()
        {
            InitUserControls();
        }

        /// <summary>
        /// Événement indiquant que l'utilisateur a sélectionné une bibliothèque
        /// </summary>
        public event EventHandler ChangementBibliothèque;


        /// <summary>
        /// Un événement notifiant qu'une propriété a été changée
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Permet d'appeler l'événement pour notifier qu'une propriété a été modifiée
        /// </summary>
        /// <param name="propertyName">Le nom de la propriété modifiée</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(sender: this, e: new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Méthode permettant de lever l'événement ChangementBibliothèque
        /// </summary>
        private void OnChangementBibliothèque() => ChangementBibliothèque?.Invoke(this, null);

        /// <summary>
        /// Méthode permettant d'initialiser les différents user control utilisés
        /// </summary>
        private void InitUserControls()
        {
            AffichageOeuvreUC();
            ModificationOeuvreUC();
            PagePrincipalUC();
            ParamètresUC();
            RechercheUC();
            CréationOeuvreUC();
            SélectionSuppressionOeuvresUC();
            SélectionAjoutOeuvresCréationUC();
            SélectionAjoutOeuvresModificationUC();

            UserControlSélectionné = userControls[PagePrincipale_UC];

            ChangementBibliothèque += (sender, arg) => ChangementDeBibliothèque();
        }

        /// <summary>
        /// Méthode permettant de récupérer l'instance unique du Navigateur ou de l'instancier si ce n'est pas déjà fait
        /// </summary>
        /// <returns>Retourne l'instance unique du Navigateur</returns>
        public static Navigateur GetInstance()
        {
            if (instanceUnique == null) instanceUnique = new Navigateur();
            return instanceUnique;
        }

        /// <summary>
        /// Méthode permettant de récupérer un user control à partir du string qui lui est associé
        /// </summary>
        /// <param name="userControl">Le string qui est associé au user control voulu. Ceux-ci sont présents dans les constantes se terminants par _UC </param>
        /// <returns></returns>
        public UserControl ObtenirUserControl(string userControl)
        {
            return userControls[userControl];
        }

        /// <summary>
        /// Méthode permmettant d'initialiser les informations et ressources du user control de la page principale
        /// </summary>
        private void PagePrincipalUC()
        {
            (userControls[PagePrincipale_UC] as PagePrincipale).LaListeBibliothèque.ModeSombreActivé = false;
            (userControls[PagePrincipale_UC] as PagePrincipale).LaListeBibliothèque.Resources["CouleurTexte"] = Brushes.Black;

            ((userControls[PagePrincipale_UC] as PagePrincipale).LesAffichages["Icône"] as AfficheIcone).Resources["CouleurDeFond"] = Brushes.White;
            ((userControls[PagePrincipale_UC] as PagePrincipale).LesAffichages["Icône"] as AfficheIcone).Resources["CouleurTexte"] = Brushes.Black;

            ((userControls[PagePrincipale_UC] as PagePrincipale).LesAffichages["Ligne"] as AfficheLigne).Resources["CouleurDeFond"] = Brushes.White;
            ((userControls[PagePrincipale_UC] as PagePrincipale).LesAffichages["Ligne"] as AfficheLigne).Resources["CouleurTexte"] = Brushes.Black;

            (userControls[PagePrincipale_UC] as PagePrincipale).ModeSombreActivé = false;
        }

        /// <summary>
        /// Méthode permmettant d'initialiser les informations et ressources du user control de la page de paramètres
        /// </summary>
        private void ParamètresUC()
        {
            (userControls[Paramètres_UC] as Paramètres).LaListeBibliothèque.ChangementBibliothèque += (sender, args) => OnChangementBibliothèque();
            (userControls[Paramètres_UC] as Paramètres).LaListeBibliothèque.ModeSombreActivé = false;
            (userControls[Paramètres_UC] as Paramètres).LaListeBibliothèque.Resources["CouleurTexte"] = Brushes.Black;
        }

        /// <summary>
        /// Méthode permmettant d'initialiser les informations et ressources due user control de la page de recherche
        /// </summary>
        private void RechercheUC()
        {
            (userControls[Recherche_UC] as PageRecherche).Resources["CouleurTexte"] = Brushes.Black;
            (userControls[Recherche_UC] as PageRecherche).Resources["CouleurDeFond"] = Brushes.White;
            (userControls[Recherche_UC] as PageRecherche).Resources["CouleurBordures"] = Brushes.Black;
            (userControls[Recherche_UC] as PageRecherche).DésactivationModeSombre();
        }

        /// <summary>
        /// Méthode permmettant d'initialiser les informations et ressources du user control de la page d'affichage d'oeuvres
        /// </summary>
        private void AffichageOeuvreUC()
        {
            (userControls[AffichageOeuvre_UC] as AffichageOeuvre).Resources["CouleurTexte"] = Brushes.Black;
            (userControls[AffichageOeuvre_UC] as AffichageOeuvre).Resources["CouleurTexteGros"] = Brushes.Black;
            (userControls[AffichageOeuvre_UC] as AffichageOeuvre).LaListeBibliothèque.ChangementBibliothèque += (sender, args) => OnChangementBibliothèque();
            (userControls[AffichageOeuvre_UC] as AffichageOeuvre).LaListeBibliothèque.ModeSombreActivé = false;
            (userControls[AffichageOeuvre_UC] as AffichageOeuvre).LaListeBibliothèque.Resources["CouleurTexte"] = Brushes.Black;
        }

        /// <summary>
        /// Méthode permmettant d'initialiser les informations et ressources du user control de la page de modification d'oeuvre
        /// </summary>
        private void ModificationOeuvreUC()
        {
            (userControls[ModificationOeuvre_UC] as ModificationOeuvre).Resources["CouleurTexte"] = Brushes.Black;
            (userControls[ModificationOeuvre_UC] as ModificationOeuvre).Resources["CouleurTexteGros"] = Brushes.Black;
            (userControls[ModificationOeuvre_UC] as ModificationOeuvre).Resources["CouleurDeFond"] = Brushes.White;
            (userControls[ModificationOeuvre_UC] as ModificationOeuvre).Resources["CouleurBordures"] = Brushes.Black;
            (userControls[ModificationOeuvre_UC] as ModificationOeuvre).LaListeBibliothèque.ChangementBibliothèque += (sender, args) => OnChangementBibliothèque();
            (userControls[ModificationOeuvre_UC] as ModificationOeuvre).LaListeBibliothèque.ModeSombreActivé = false;
            (userControls[ModificationOeuvre_UC] as ModificationOeuvre).LaListeBibliothèque.Resources["CouleurTexte"] = Brushes.Black;
        }

        /// <summary>
        /// Méthode permmettant d'initialiser les informations et ressources du user control de la page de création d'un oeuvre
        /// </summary>
        private void CréationOeuvreUC()
        {
            (userControls[CréationOeuvre_UC] as CréationOeuvre).Resources["CouleurTexte"] = Brushes.Black;
            (userControls[CréationOeuvre_UC] as CréationOeuvre).Resources["CouleurTexteGros"] = Brushes.Black;
            (userControls[CréationOeuvre_UC] as CréationOeuvre).Resources["CouleurDeFond"] = Brushes.White;
            (userControls[CréationOeuvre_UC] as CréationOeuvre).Resources["CouleurBordures"] = Brushes.Black;
            (userControls[CréationOeuvre_UC] as CréationOeuvre).LaListeBibliothèque.ChangementBibliothèque += (sender, args) => OnChangementBibliothèque();
            (userControls[CréationOeuvre_UC] as CréationOeuvre).LaListeBibliothèque.ModeSombreActivé = false;
            (userControls[CréationOeuvre_UC] as CréationOeuvre).LaListeBibliothèque.Resources["CouleurTexte"] = Brushes.Black;
        }

        /// <summary>
        /// Méthode permmettant d'initialiser les informations et ressources du user control de la page de sélection d'oeuvres à supprimer dans une bibliothèque
        /// </summary>
        public void SélectionSuppressionOeuvresUC()
        {
            (userControls[SélectionSuppressionOeuvres_UC] as SélectionSuppressionOeuvres).Resources["CouleurTexte"] = Brushes.Black;
            (userControls[SélectionSuppressionOeuvres_UC] as SélectionSuppressionOeuvres).Resources["CouleurDeFond"] = Brushes.White;
        }

        /// <summary>
        /// Méthode permmettant d'initialiser les informations et ressources du user control de la page de sélection d'oeuvres à ajouter à une nouvelle bibliothèque
        /// </summary>
        public void SélectionAjoutOeuvresCréationUC()
        {
            (userControls[SélectionAjoutOeuvresCréation_UC] as SélectionAjoutOeuvresCréation).Resources["CouleurTexte"] = Brushes.Black;
            (userControls[SélectionAjoutOeuvresCréation_UC] as SélectionAjoutOeuvresCréation).Resources["CouleurDeFond"] = Brushes.White;
        }

        /// <summary>
        /// Méthode permmettant d'initialiser les informations et ressources du user control de la page de sélection d'oeuvres à ajouter à une bilbiothèque existante
        /// </summary>
        public void SélectionAjoutOeuvresModificationUC()
        {
            (userControls[SélectionAjoutOeuvresModification_UC] as SélectionAjoutOeuvresModification).Resources["CouleurTexte"] = Brushes.Black;
            (userControls[SélectionAjoutOeuvresModification_UC] as SélectionAjoutOeuvresModification).Resources["CouleurDeFond"] = Brushes.White;
        }

        /// <summary>
        /// Méthode permettant de sélectionner un nouveau user control à partir du string qui lui est associé.
        /// Il lance aussi les méthodes permettant de réinitialiser leurs vues suivant les nouvelles valeurs
        /// </summary>
        /// <param name="nomUC"></param>
        public void NaviguerVers(String nomUC)
        {
            switch(nomUC)
            {
                case PagePrincipale_UC:
                    (userControls[PagePrincipale_UC] as PagePrincipale).TrierOeuvres();
                    break;
                case ModificationOeuvre_UC:
                    (userControls[ModificationOeuvre_UC] as ModificationOeuvre).ChargerOeuvre();
                    break;
                case CréationOeuvre_UC:
                    (userControls[CréationOeuvre_UC] as CréationOeuvre).CréerNouvelleOeuvre();
                    break;
                case SélectionAjoutOeuvresModification_UC:
                    (userControls[SélectionAjoutOeuvresModification_UC] as SélectionAjoutOeuvresModification).ToutDécocher();
                    (userControls[SélectionAjoutOeuvresModification_UC] as SélectionAjoutOeuvresModification).SetOeuvres();
                    break;
                case SélectionAjoutOeuvresCréation_UC:
                    (userControls[SélectionAjoutOeuvresCréation_UC] as SélectionAjoutOeuvresCréation).ToutDécocher();
                    (userControls[SélectionAjoutOeuvresCréation_UC] as SélectionAjoutOeuvresCréation).TrierOeuvres();
                    break;
                case SélectionSuppressionOeuvres_UC:
                    (userControls[SélectionSuppressionOeuvres_UC] as SélectionSuppressionOeuvres).TrierOeuvres();
                    break;
                case Recherche_UC:
                    string recherche = null;
                    if (UserControlSélectionné is PagePrincipale) recherche = (UserControlSélectionné as PagePrincipale).textBox_Recherche.Text;
                    if (UserControlSélectionné is AffichageOeuvre) recherche = (UserControlSélectionné as AffichageOeuvre).textBox_Recherche.Text;
                    (userControls[Recherche_UC] as PageRecherche).TextBoxLaRecherche.Text = recherche;
                    (userControls[Recherche_UC] as PageRecherche).NaviguerVers(null);
                    break;
                default:
                    break;
            }
            UserControlSélectionné = userControls[nomUC];
        }

        /// <summary>
        /// Méthode permettant de naviguer vers l'ancien user control
        /// </summary>
        public void NavigerVersAncien()
        {
            foreach(string key in userControls.Keys)
            {
                //Utilise la méthode NaviguerVers pour réinitialiser leurs vues suivant les nouvelles valeurs
                if (userControls[key].GetType().Name.Equals(AncienUserControl.GetType().Name))
                {
                    NaviguerVers(key);
                    return;
                }
            }
        }

        /// <summary>
        /// Permet d'activer le mode sombre sur les différents user control de la vue
        /// </summary>
        public void ActivationModeSombre()
        {
            //Active le mode sombre sur la fenêtre principale
            (Application.Current as App).MainWindow.Background = new SolidColorBrush(Color.FromRgb(51, 51, 51));

            //Active le mode sombre sur les style de l'App
            App.Current.Resources["CouleurTexte"] = Brushes.White;
            App.Current.Resources["CouleurBordures"] = new SolidColorBrush(Color.FromRgb(43, 120, 228));

            //Active le mode sombre sur PagePrincipale
            (userControls[PagePrincipale_UC] as PagePrincipale).LaListeBibliothèque.Resources["CouleurTexte"] = Brushes.White;
            (userControls[PagePrincipale_UC] as PagePrincipale).LaListeBibliothèque.ModeSombreActivé = true;
            ((userControls[PagePrincipale_UC] as PagePrincipale).LesAffichages["Icône"] as AfficheIcone).Resources["CouleurDeFond"]
                = new SolidColorBrush(Color.FromRgb(51, 51, 51));
            ((userControls[PagePrincipale_UC] as PagePrincipale).LesAffichages["Icône"] as AfficheIcone).Resources["CouleurTexte"] = Brushes.White;
            ((userControls[PagePrincipale_UC] as PagePrincipale).LesAffichages["Ligne"] as AfficheLigne).Resources["CouleurDeFond"]
                = new SolidColorBrush(Color.FromRgb(51, 51, 51));
            ((userControls[PagePrincipale_UC] as PagePrincipale).LesAffichages["Ligne"] as AfficheLigne).Resources["CouleurTexte"] = Brushes.White;
            (userControls[PagePrincipale_UC] as PagePrincipale).ModeSombreActivé = true;

            //Active le mode sombre sur AffichageOeuvre
            (userControls[AffichageOeuvre_UC] as AffichageOeuvre).Resources["CouleurTexte"] = Brushes.White;
            (userControls[AffichageOeuvre_UC] as AffichageOeuvre).Resources["CouleurTexteGros"] = new SolidColorBrush(Color.FromRgb(43, 120, 228));
            (userControls[AffichageOeuvre_UC] as AffichageOeuvre).LaListeBibliothèque.Resources["CouleurTexte"] = Brushes.White;
            (userControls[AffichageOeuvre_UC] as AffichageOeuvre).LaListeBibliothèque.ModeSombreActivé = true;

            //Active le mode sombre sur ModificationOeuvre
            (userControls[ModificationOeuvre_UC] as ModificationOeuvre).Resources["CouleurTexte"] = Brushes.White;
            (userControls[ModificationOeuvre_UC] as ModificationOeuvre).Resources["CouleurTexteGros"] = new SolidColorBrush(Color.FromRgb(43, 120, 228));
            (userControls[ModificationOeuvre_UC] as ModificationOeuvre).LaListeBibliothèque.Resources["CouleurTexte"] = Brushes.White;
            (userControls[ModificationOeuvre_UC] as ModificationOeuvre).LaListeBibliothèque.ModeSombreActivé = true;
            (userControls[ModificationOeuvre_UC] as ModificationOeuvre).Resources["CouleurDeFond"] = new SolidColorBrush(Color.FromRgb(51, 51, 51));
            (userControls[ModificationOeuvre_UC] as ModificationOeuvre).Resources["CouleurBordures"] = new SolidColorBrush(Color.FromRgb(43, 120, 228));

            //Active le mode sombre sur CréationOeuvre
            (userControls[CréationOeuvre_UC] as CréationOeuvre).Resources["CouleurTexte"] = Brushes.White;
            (userControls[CréationOeuvre_UC] as CréationOeuvre).Resources["CouleurTexteGros"] = new SolidColorBrush(Color.FromRgb(43, 120, 228));
            (userControls[CréationOeuvre_UC] as CréationOeuvre).LaListeBibliothèque.Resources["CouleurTexte"] = Brushes.White;
            (userControls[CréationOeuvre_UC] as CréationOeuvre).LaListeBibliothèque.ModeSombreActivé = true;
            (userControls[CréationOeuvre_UC] as CréationOeuvre).Resources["CouleurDeFond"] = new SolidColorBrush(Color.FromRgb(51, 51, 51));
            (userControls[CréationOeuvre_UC] as CréationOeuvre).Resources["CouleurBordures"] = new SolidColorBrush(Color.FromRgb(43, 120, 228));

            //Active le mode sombre sur Paramètres
            (userControls[Paramètres_UC] as Paramètres).LaListeBibliothèque.Resources["CouleurTexte"] = Brushes.White;
            (userControls[Paramètres_UC] as Paramètres).LaListeBibliothèque.ModeSombreActivé = true;

            //Active le mode sombre sur PageRecherche
            (userControls[Recherche_UC] as PageRecherche).Resources["CouleurTexte"] = Brushes.White;
            (userControls[Recherche_UC] as PageRecherche).Resources["CouleurDeFond"] = new SolidColorBrush(Color.FromRgb(51, 51, 51));
            (userControls[Recherche_UC] as PageRecherche).Resources["CouleurBordures"] = new SolidColorBrush(Color.FromRgb(43, 120, 228));
            (userControls[Recherche_UC] as PageRecherche).ActivationModeSombre();

            //Active le mode sombre sur SélectionSuppressionOeuvres
            (userControls[SélectionSuppressionOeuvres_UC] as SélectionSuppressionOeuvres).Resources["CouleurTexte"] = Brushes.White;
            (userControls[SélectionSuppressionOeuvres_UC] as SélectionSuppressionOeuvres).Resources["CouleurDeFond"] = new SolidColorBrush(Color.FromRgb(51, 51, 51));

            //Active le mode sombre sur SélectionAjoutOeuvresCréation
            (userControls[SélectionAjoutOeuvresCréation_UC] as SélectionAjoutOeuvresCréation).Resources["CouleurTexte"] = Brushes.White;
            (userControls[SélectionAjoutOeuvresCréation_UC] as SélectionAjoutOeuvresCréation).Resources["CouleurDeFond"] = new SolidColorBrush(Color.FromRgb(51, 51, 51));

            //Active le mode sombre sur SélectionAjoutOeuvresModification
            (userControls[SélectionAjoutOeuvresModification_UC] as SélectionAjoutOeuvresModification).Resources["CouleurTexte"] = Brushes.White;
            (userControls[SélectionAjoutOeuvresModification_UC] as SélectionAjoutOeuvresModification).Resources["CouleurDeFond"] = new SolidColorBrush(Color.FromRgb(51, 51, 51));
        }

        /// <summary>
        /// Permet de désactiver le mode sombre sur les différents user control de la vue
        /// </summary>
        public void DésactivationModeSombre()
        {
            (Application.Current as App).MainWindow.Background = Brushes.White;

            App.Current.Resources["CouleurTexte"] = Brushes.Black;
            App.Current.Resources["CouleurBordures"] = Brushes.Black;

            //Appelle les méthodes des users controls permettant de désactiver leurs mode sombre
            PagePrincipalUC();
            ModificationOeuvreUC();
            RechercheUC();
            SélectionSuppressionOeuvresUC();
            SélectionAjoutOeuvresModificationUC();
            SélectionAjoutOeuvresCréationUC();
            ParamètresUC();
            CréationOeuvreUC();
            AffichageOeuvreUC();
        }
        
        /// <summary>
        /// Méthode permettant de revenir sur la page principale lorsque l'utilisateur a cliqué sur une bibliothèque
        /// </summary>
        private void ChangementDeBibliothèque()
        {
            //Si l'utilisateur ne se trouve pas la page de recherche ou dans les différentes page de sélection d'oeuvres
            if (!UserControlSélectionné.Equals(userControls[Recherche_UC])
                && !UserControlSélectionné.Equals(userControls[SélectionAjoutOeuvresCréation_UC])
                && !UserControlSélectionné.Equals(userControls[SélectionAjoutOeuvresModification_UC])
                && !UserControlSélectionné.Equals(userControls[SélectionSuppressionOeuvres_UC]))
            {
                NaviguerVers(PagePrincipale_UC);
            }
        }
    }
}
