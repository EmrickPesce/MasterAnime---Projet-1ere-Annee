# Description des diagrammes de classes de l’application MasterAnime (Cette description contient aussi celle pour la persistance dans la mesure où le reste des deux diagrammes ne diffère pas) : #


La classe ObservableObject est une classe implémentant INotifyPropertyChange et donc permettant à ses classes filles de notifier la vue d’un changement dans les données.

La classe ObservableDictionary est un Dictionary qui notifie la vue lorsque des changements lui sont apportés. Elle possède les mêmes méthodes que Dictionary.

La classe StringVérifié possède un attribut LeString, qui possède une longueur maximale de 16 caractères. Ainsi, cette classe implémente IDataErrorInfo. Ceci permet que la vue sache lorsque le string possède une erreur, même dans un Dictionary.

La classe Validateur va permettre de vérifier différentes informations d’une Oeuvre ou d’une Bibliothèque afin de la valider suivant certains critères. Elle est surtout utilisée par la partie WPF de l’application.

L’énumération TypeOeuvre permet de connaitre le type de l’œuvre dans différentes situations, comme pour une recherche. Ainsi, il y a à l’intérieur Tout, Autre, Film, Série, Livre, Scan, Animé.

L’énumération DateQuand permet de définir un référentiel par rapport à une date, pour par exemple la recherche d’une œuvre. Les possibilités sont NonUtilisé, Avant, Pendant, Après.

L’énumération OrdreTri Permet de connaitre l’ordre de tri souhaité. Celui-ci est surtout utilisé la partie WPF. On peut choisir Croissant, Décroissant, Date_de_sortie, Type.

Les classes Film et Série héritent de Cinématographique car elles possèdent les mêmes attributs et méthodes. Ceci en est de même pour Scan et Livre avec Littéraire. Les classes Cinématographique, Littéraire, Animé et Autre héritent de Oeuvre. La classe Oeuvre est, comme son l’indique, faite pour contenir différentes informations d’une œuvre de l’utilisateur. Ainsi, ses quatre classes filles précisent ces informations en en ajoutant. La classe Oeuvre dépend de StringVérifié, dans la mesure où elle possède un ObservableDictionary de StringVérifié. Ainsi, elle dépend aussi de ObservableDictionary. Pour pouvoir notifier à la vue les différents changements apportés aux données de l’œuvre, la classe hérite de ObservableObject.

La classe Bibliothèque va contenir une collection d’Oeuvre, en plus d’un nom et d’une image. Celle-ci est donc, pour l’utilisateur, une liste d’œuvres. Les méthodes sur cette classe son principalement pour gérer les œuvres en CRUD (Create Update Delete). La collection d’œuvre est soit en composition, soit en agrégation. Ceci va différer suivant le fait que la Bibliothèque est la liste principale du Manager, ou si c’est une des Bibliothèque dans sa collection. En effet, la ListePrincipale va contenir toutes les œuvres de l’application, ainsi, si on la supprime de cette Bibliothèque, elle sera également supprimée des autres Bibliothèque et donc on est sur une composition. Au contraire, si ce n’est qu’une Bibliothèque dans la collection, lorsqu’on supprimera l’œuvre de celle-ci, elle sera toujours présente dans la ListePrincipale, et on est ainsi sur une agrégation. La méthode de recherche d’une œuvre utilise TypeOeuvre et DateQuand, donc la classe Bibliothèque est dépendante de ces énumérations. De plus, elle hérite de ObservableObject pour notifier la vue de la modification de ses données.

La classe static Tri possède différentes méthodes pour trier une collection d’Oeuvre passée en paramètre. La seule méthode ne faisant pas cela est OeuvresDuType qui va renvoyer une collection d’œuvre avec uniquement les œuvres du type passé en paramètre via l’énumération TypeOeuvre.

L’interface IDataManager <T> est présente pour définir différentes méthodes utiles à la persistance. Celles-ci sont générales, et donc non précise à l’application.

L’interface IPersistanceManager est basée sur le même principe que IDataManager, mais avec des méthodes centrées sur l’utilisation d’un fichier de persistance pour l’application.

L’interface IBibliothèqueDataManager est également basée sur le même principe que les deux précédentes, mais avec la particularité que ses méthodes sont axées sur l’application. Ceci fait qu’elle rajoute la gestion d’une Bibliothèque, étant la ListePrincipale du point de vue de l’application. Elle hérite de IDataManager et IPersistanceManager.  Elle dépend de Bibliothèque et Œuvre.

VérifierDonnées permet de modifier les données passées en paramètres directement sur les références. Ses méthodes les modifieront suivant si des données ne concordent pas, ou que des Oeuvre ou Bibliothèque possèdent le même nom.

DonnéesPrêtes permet de rendre des données déjà construites pour que l’application ne soit pas vide lors du téléchargement.

La classe convertisseurJson permet de convertir différentes classes de l’application en Json, et inversement. Ainsi, elle dépend de Bibliothèque et Oeuvre.

La classe PersistanceJson hérite de IBibliothèqueDataManager et donc implémente toutes ses méthodes. Elle permet principalement d’enregistrer et récupérer des données, basée sur le Manager avec une ListePrincipale et une collection de Bibliothèque, sur et à partir d’un fichier Json. Pour cela, elle dépend de ConvertisseurJson afin, comme le nom l’indique, de convertir ses données en Json, ou un fichier Json en données.

Enfin, la classe Manager va être la plus utilisée par l’application dans la mesure où elle contiendra toutes les données et la plupart des méthodes pour les gérer. Ainsi, elle dépend de Bibliothèque, Oeuvre, Autre, Animé, Cinématographique et Littéraire, étant donné qu’elle va aussi utiliser leurs méthodes. Elle va posséder une Bibliothèque ListePrincipale qui contiendra toutes les œuvres de l’application. Elle aura également une collection de Bibliothèque, qui seront les listes d’œuvres de l’utilisateur. De plus, pour faciliter la partie WPF, elle contient une Bibliothèque BibliothèqueSélectionnée et une Oeuvre OeuvreSélectionnée qui pourront être récupérées ou mises à jour suivant ce que fait l’utilisateur. Est également présent pour une question de faciliter une collection de Bibliothèque VuDesBibliothèques contenant en premier la ListePrincipale puis les différentes Bibliothèque du Manager, et donc de l’application. De plus, son constructeur va prendre en paramètre l’interface IBibliothèqueDataManager afin de pouvoir récupérer, gérer et enregistrer les données de la persistance.
