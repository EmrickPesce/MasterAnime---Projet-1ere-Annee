# Application MasterAnime de MONTEIL Romain et PESCE Emrick du groupe 6. #

***Le ReadMe était destiné à notre professeur. Vous pouvez vous diriger vers le fichier Contexte.md ou la vidéo de présentation pour plus de détail sur l'application.***

Pour lancer l'application il est préférable que ce soit en mode Administrateur pour récupérer des images dans l'ordinateur, ou écrire et lire des fichiers.

Il n'y à rien à ajouter, des données sont déjà fournis.

On n'a pas de préférence, vous pouvez utiliser le .exe ou encore passer par visual studio. Comme cela vous arrange.

Lors de la sélection d'une nouvelle image, on ne voit pas les images en .png et .gif directement, il faut sélectionner le type d'image précisément pour les voires. Il n'y a pas d'autres problèmes connus à ce jour.

Dans UML Persistance, il y a deux 'Working Diagrams'. Il faut sélectionner le Main pour celui avec la persistance.

## Dans les ajouts personnels nous pouvons citer : ##

- Les différentes sélections d'oeuvres pour les supprimer ou les ajouter à une Bibliothèque
- Le mode nuit, qui permet de rendre l'application plus sombre
- L'exportation et l'importation de fichiers de persistance pour partager et ajouter des données
- La recherche d'une oeuvre via la page de recherche
- La recherche d'une Bibliothèque via la combobox en haut à gauche de la page principale
- La vérification des données du fichier de persistance, si jamais elles ont été modifiées
- On peut ajouter ou retirer une oeuvre d'une liste via la combobox dans la création et la modification de l'oeuvre
- On peut trier l'affichage des oeuvres dans la page principale. Ceci est de même pour sélectionner un certain type d'oeuvre
- On a deux affichages d'oeuvres dans la page principale, un par icône, l'autre en ligne



## Les sketchs ne sont pas à jour, on n'a plus accés à la version d'essaie, mais nous pouvons citer les modifications apportées : ##

- Pour la sélection d'ajout des oeuvres à une Bibliothèque, on ne peut plus chercher l'oeuvre, la page n'est plus similaire à la page de recherche. Elle se rapproche plutôt de la sélection pour la suppression.
- La recherche d'une Bibliothèque n'est plus la même, elle se fait via une combobox, et non plus par une TextBox.
- Lors de la modification d'une oeuvre, on ne peut plus modifier le type de l'oeuvre. Le bouton 'Annuler les modifications' devient 'Annuler'. De plus, sa position est inversée avec le bouton 'Supprimer'.
- Les fenêtres de dialog quand il y a une erreur, tel que l'oeuvre ne possède pas de nom ou pour la réinitialisation de l'oeuvre, ne sont plus les mêmes, elle deviennent de simple MessageBox, et non des fenêtres avec un fond de couleur différent. De plus, il y en maintenant aussi pour la suppression des oeuvres.
- Dans les différentes sélections pour l'ajout ou la suppressions d'oeuvres, l'affichage des listes sur la gauche disparait.
- Dans la recherche, il est maintenant possible de mettre 'Non Utilisé' pour la date de sortie. Ainsi, le fait que si on met les dates avec des 00 celles-ci ne sont pas prises en compte dans la recherche, n'est plus valable.
- On ne peut finalement pas modifier l'emplacement du fichier de sauvegarde. Ceci disparait donc avec le bouton 'Sauvegarder'dans la page de paramètres.


## Pour ce qui est de la répartition des tâches :  ##

Romain a fait : 

- Le diagramme de cas d'utilisation
- Les diagrammes de séquence et leur descriptif
- Le montage de la vidéo.


Emrick a fait tout le reste, c'est à dire :

- Le contexte
- La description de l'architecture
- Les diagrammes de classes (avec et sans la persistance) et leur descriptif
- Les diagrammes de paquetages (avec et sans la persistance) et leur descriptif
- Le diagramme de classes des parties ajoutées et son desciptif
- Les personas
- Le ReadMe
- Les sketchs
- Le StoryBoard
- Tout le code (Les classes dans ClassLibrary, dans Management, dans Persistance, les tests, la partie WPF avec tous les users controls et les classes liées, la partie SetUp)
