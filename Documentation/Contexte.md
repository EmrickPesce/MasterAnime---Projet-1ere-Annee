##Contexte : ##

Nous allons créer une application regroupant des œuvres. Celle-ci se destine à n’importe qui voulant répertorier des films, séries, livres, animés, scans ou autres. Son but est de permettre de créer des listes afin de les répertorier. Ainsi, on aurait une liste principale regroupant toutes les œuvres que l’on a incorporé à l’application, et certaines œuvres déjà présentes de base. Evidemment, on peut ajouter, supprimer ou modifier les œuvres présentes dans cette liste, et donc dans l’application. L’application se voudra esthétique avec un mode d’affichage normal, ainsi qu’un mode sombre pour la nuit.

On peut créer des listes possédant le nom et l’image que l’on souhaite afin d’y incorporer n’importe quelle œuvre que l’on veut. Ceci permettrait par exemple d’avoir une liste de celles que l’on a à regarder. A sa création, on pourra présélectionner les œuvres que l’on veut mettre à l’intérieur. Dans une liste créée, on pourra ajouter ou retirer des animés. Dans l’affichage des listes, les œuvres pourraient être triées en fonction de leur type, de leur nom, de leur date de sortie, etc. Il y aura différents types d’affichages, tels qu’en ligne où apparaitra diverses informations sur l’œuvre, ou encore en icônes où l’on verrait uniquement le nom et une image. Une barre de recherche sera présente afin de trouver l’œuvre que l’on souhaite. Celle-ci sera présente dans toutes les listes. Un filtre sera également présent afin de préciser notre recherche par type, date de sortie, éditeur/studio, etc. 

Chaque œuvre présente aura différentes caractéristiques. Elle aura bien évidemment son nom, mais aussi si l’utilisateur le souhaite : une image, un synopsis, un commentaire personnel, sa date de sortie, son ou ses auteurs, son studio (pour les films, séries et animés), son éditeur (pour les livres), ainsi de suite. A la création d’une œuvre dans l’application, l’utilisateur devra choisir de quel type d’œuvre il s’agit parmi ‘film’, ‘série’, ‘livre’, ‘animé’, ‘scan’ ou ‘autre’. Il pourra ensuite incorporer les différentes informations qu’il souhaite. De plus, il lui sera proposé d’ajouter l’œuvre aux différentes listes existantes pour lui éviter de le faire manuellement. Evidemment, l’utilisateur pourra également ajouter une œuvre à une liste en restant sur sa page, sans se rendre dans celle de la liste.

Notre application se démarquera des autres par ses graphismes, elle sera plus chaleureuse à utiliser. Elle sera facile à prendre en main même pour les personnes les moins qualifiées informatiquement.



## User Story : ##

**En tant que Kirito Kazuto, je veux chercher une œuvre sur l’application afin de savoir si je l'ai déjà regardé :**

***Scénario 1 :*** L’œuvre n’est pas présente dans l’application

ETANT DONNÉ que l’œuvre n’est pas présente dans l’application

LORSQUE Kirito la recherchera via la barre de recherche des œuvres

ALORS un message lui indiquera qu’elle n’est pas présente

ET il comprendra qu'il ne l'a pas regardé car il ne l'a pas entrée dans l'application

ET il lui sera demandé s’il veut ajouter une œuvre à l’application


***Scénario 2 :*** L’œuvre est présente dans l’application

ETANT DONNÉ que l’œuvre est présente dans l’application

LORSQUE l’utilisateur la recherche via la barre de recherche des œuvres

ALORS elle apparaitra

ET il pourra la sélectionner pour l'afficher

**En tant que Joe Goldberg, je veux afficher une liste afin de montrer les œuvres présentes à des amis en IRL :**

***Scénario 1 :*** La liste n’est pas présente

ETANT DONNÉ que la liste n’est pas présente dans l’application

LORSQUE Joe la recherchera via la barre de recherche  des listes

ALORS un message lui indiquera qu’elle n’est pas présente

ET il se remémorera qu'il ne l'a pas encore créée

ET il lui sera demandé s’il veut ajouter une liste à l’application

***Scénario 2 :*** La liste est présente, je la trouve

ETANT DONNÉ que la liste est présente dans l’application

LORSQUE Joe la recherchera dans le menu des listes

ALORS il pourra la voir

ET il pourra la sélectionner afin d'afficher les oeuvres et les montrer à ses amis autour de lui

***Scénario 3 :*** La liste est présente, j’utilise la barre de recherche

ETANT DONNÉ que la liste pas présente dans l’application

LORSQUE Joe la recherchera via la barre de recherche des listes

ALORS elle apparaitra

ET il pourra la sélectionner afin d'afficher les oeuvres et les montrer à ses amis autour de lui

**En tant que Kirito Kazuto, je veux ajouter une œuvre à une liste afin de me rappeler que je l'ai vue :**

***Scénario 1 :*** La liste n’est pas présente

ETANT DONNÉ que la liste n’est pas présente dans l’application

LORSQUE Kirito la recherchera via la barre de recherche des listes

ALORS un message lui indiquera qu’elle n’est pas présente

ET il devra la créer pour répertorié ses oeuvres vues

***Scénario 2 :*** L’œuvre n’est pas présente dans l’application

ETANT DONNÉ que l’œuvre n’est pas présente dans l’application

LORSQUE Kirito la recherchera via la barre de recherche des œuvres

ALORS un message lui indiquera qu’elle n’est pas présente

ET il devra la créer pour la déplacer dans la bonne liste

***Scénario 3 :*** L’œuvre et la liste sont présentes dans l’application, ajout via la page de l’œuvre

ETANT DONNÉ que l’œuvre et la liste sont présentes dans l’application

LORSQUE Kirito ira sur la page de l’œuvre

ALORS il aura le choix d’ajouter l’œuvre à une liste existante

ET il pourra sélectionner la bonne liste pour lui rappeler qu'il l'a vu

**En tant qu’utilisateur de l’application, je veux mettre le mode nuit afin d’être moins ébloui :**

***Scénario 1 :*** Je suis dans les paramètres

ETANT DONNÉ que je suis dans les paramètres

LORSQUE je cliquerai sur le bouton pour mettre le mode nuit

ALORS l’affichage changera

ET j’aurais des couleurs plus sombres

***Scénario 2 :*** Je ne suis pas dans les paramètres

ETANT DONNÉ que je ne suis pas dans les paramètres

LORSQUE j’irais dans les paramètres en cliquant sur le bouton paramètres

ALORS j’aurai le bouton du mode nuit

ET je pourrai cliquer dessus

**En tant que Joe Goldberg, je veux exporter mon fichier des œuvres afin de le donner à un ami :**

***Scénario 1 :*** Je suis dans les paramètres

ETANT DONNÉ que je suis dans les paramètres

LORSQUE je cliquerai sur le bouton exporter

ALORS je pourrai sélectionner l’emplacement où le déposer

ET je pourrai ensuite le donner à un ami pour qu’il les importe dans son application

***Scénario 2 :*** Je ne suis pas dans les paramètres

ETANT DONNÉ que je ne suis pas dans les paramètres

LORSQUE j’irai dans les paramètres en cliquant sur le bouton paramètres

ALORS j’aurai le bouton exporter

ET je pourrai cliquer dessus pour choisir un emplacement d’enregistrement et le donner à un ami

**En tant que Joe Goldberg, je veux importer des œuvres afin de compléter mon application :**

***Scénario 1 :*** Je possède le dossier contenant les œuvres à importer

ETANT DONNÉ que je possède le dossier contenant les œuvres à importer

LORSQUE je cliquerai sur le bouton explorer à côté d’importer

ALORS je pourrai sélectionner l’emplacement où récupérer les œuvres

ET j’aurai les œuvres dans mon application

***Scénario 2 :*** Je ne possède pas le dossier contenant les œuvres à importer

ETANT DONNÉ que je ne possède pas le dossier contenant les œuvres à importer

LORSQUE je demanderai à un ami d’exporter ses œuvres

ALORS je pourrai importer son fichier

ET j’aurai ses œuvres dans mon application
