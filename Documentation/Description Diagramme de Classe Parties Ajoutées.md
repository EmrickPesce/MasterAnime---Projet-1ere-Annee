# Description du diagramme de classe des parties ajoutées : #

IPersistanceManager, PersistanceJson et Manager possèdent tous trois 2 méthodes similaires. En effet, bien que ce ne soit pas le même code derrière, elles font la même chose. ExporterPersistance permet de faire une copie du fichier de persistance dans un autre dossier que celui de l’application. ImporterPersistance permet de récupérer des données présentes dans un fichier que l’utilisateur a sélectionné. Ainsi, ces deux méthodes permettent à l’utilisateur de partager ses données et d’en recevoir.

RechercherBibliothèque dans Manager était de base pour chercher une Bibliothèque pour la partie WPF. Finalement on a utilisé un TextBox modifiable pour la recherche, et donc cette méthode ne nous est pas utile. Cependant, on la laisse pour une future évolutivité.

RéinitialiserManager dans Manager est utile pour les utilisateurs voulant une application remise à zéro. Elle retire toutes les Bibliothèque et Oeuvre de l’application.

L’énumération TypeOeuvre permet de définir un type d'œuvre précis.

L’énumération DateQuand permet de choisir où se placer par rapport à une date.

L’énumération OrdreTri permet de définir l'ordre d'un tri.

Les deux premières énumérations sont surtout utiles pour une recherche. La troisième est pour la partie WPF.

Validateur permet de valider une Bibliothèque, suivant le des critères sur le nom, ou une Oeuvre, suivant des critères sur le nom, et les différentes informations de celle-ci. Elle est utilisée dans la partie WPF.

Pour la classe Tri, les quatre fonctions de tri renvoient la même collection mais triée dans l'ordre voulue, par tri croissant/décroissant, par date de la plus récente a la plus ancienne, et par type (ordre : Film, Série, Livre, Anime, Scan, Autre). OeuvresDuType prend une Collection d'oeuvre et retourne toutes les oeuvres du type souhaité.

ObservableDictionary est un Dictionary possédant la particularité de notifier la vue lorsque celui-ci, ou ses données, sont modifiées. Toutes les méthodes du Dictionary sont présentes sur ObservableDictionary.

StringVérifié contient un attribut string possédant un contrôle permettant de notifier la vue lorsque celui-ci fait plus de 16 caractères. Ainsi, il est possible de modifier la vue en conséquence même si on l'utilise à travers un Dictionary.

Pour la classe Oeuvre, RechercheInfomation retournera l'information si elle existe, ou la valeur null. On n’utilise pas cette méthode pour le moment, mais elle pourrait être utile dans une future évolutivité. ContientMotClé renverra le nombre de fois où la chaine de caractère 'mot' est présente dans le synopsis, le commentaire et les informations complémentaires de l'oeuvre. Cette méthode est surtout utile dans la recherche d’œuvres de la classe Bibliothèque.



