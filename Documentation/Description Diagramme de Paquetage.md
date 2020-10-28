# Description des diagrammes de Paquetage de l’application MasterAnime (Cette description contient aussi celle pour la persistance dans la mesure où le reste des deux diagrammes de paquetage ne diffère pas) : #



Pour fonctionner, l’application possède différents composants. On peut commencer par parler de ce que l’utilisateur va voir en premier, c’est-à-dire la partie WPF. Celle-ci se nomme Iut.MasterAnime.Winapp, et possède différents contrôles utilisateurs et fenêtres. On citera notamment la fenêtre principale MainWindow, qui va contenir tous les contrôles utilisateurs. De même, le Navigateur va permettre de changer l’affichage de la MainWindow. En plus, la partie WPF va dépendre de MaterialDesign, qui possède beaucoup de ressources et de styles dont l’application se sert, de Iut.MasterAnime.ClassLibrary, en utilisant les différentes classes à l’intérieur de cette librairie, et de Iut.MasterAnime.Management pour sa classe Manager.

Iut.MasterAnime.ClassLibrary est une librairie de classe qui va contenir la plupart des classes dont l’application va nécessiter. On peut citer la classe Oeuvre qui contiendra différentes informations sur une œuvre que l’utilisateur aura choisi de mettre dans l’application. Il y a également la classe Bibliothèque qui contiendra différentes Oeuvre. Cette librairie de classe ne possède pas de dépendance.

Iut.MasterAnime.Management est également une librairie de classe, cependant elle n’en possède qu’une seule. Le classe Manager va être celle principalement utilisée par l’application. En effet, c’est celle-ci qui va contenir toutes les informations, tel que la ListePrincipale, ou encore la collection de Bibliothèque. Elle dépend alors de Iut.MasterAnime.ClassLibrary, mais aussi de Iut.MasterAnime.Persistance dans la mesure où elle va enregistrer et récupérer ses données dans un fichier de persistance.

Iut.MasterAnime.Persistance permet de gérer la persistance, c’est-à-dire qu’elle va pouvoir récupérer des données dans un fichier, ou encore en écrire dedans. Ainsi, elle va dépendre de Iut.MasterAnime.ClassLibrary car elle utilise certaines de ses classes. L’application ne peut qu’utiliser un fichier en Json, mais la classe Manager utilise un attribut de l’interface IBibliothèqueDataManager, afin de pouvoir évoluer vers une autre forme de persistance tel que XML. 

Enfin, nous avons Iut.MasterAnime.Tests qui va tester les différentes classes et méthodes de Iut.MasterAnime.Management et Iut.MasterAnime.ClassLibrary, et donc dépend de ces librairies de classes.


