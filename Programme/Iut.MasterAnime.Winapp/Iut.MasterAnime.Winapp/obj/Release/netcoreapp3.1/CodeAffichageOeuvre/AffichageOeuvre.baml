   M S B A M L   `   `   `  ���� Q  MIut.MasterAnime.Winapp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullg8clr-namespace:Iut.MasterAnime.Winapp.CodeAffichageOeuvre*Iut.MasterAnime.Winapp.CodeAffichageOeuvre  e7clr-namespace:Iut.MasterAnime.Winapp.CodePagePrincipale)Iut.MasterAnime.Winapp.CodePagePrincipale  W SIut.MasterAnime.ClassLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullqPclr-namespace:Iut.MasterAnime.ClassLibrary;assembly=Iut.MasterAnime.ClassLibraryIut.MasterAnime.ClassLibrary @    :Iut.MasterAnime.Winapp.CodeAffichageOeuvre.AffichageOeuvre   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Jlocal8clr-namespace:Iut.MasterAnime.Winapp.CodeAffichageOeuvre     RpagePrincipale7clr-namespace:Iut.MasterAnime.Winapp.CodePagePrincipale     iclassLibraryPclr-namespace:Iut.MasterAnime.ClassLibrary;assembly=Iut.MasterAnime.ClassLibrary     V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -     >�Name$  AfficheOeuvre�� � 	Resources  �� 
TargetType �� Property   CouleurTexte �� Value�� %+   '��       �� " ��.���  � ��# �   .��]� .+�C   =Iut.MasterAnime.Winapp.CodePagePrincipale.ListeBibliothèques  -     Name$ LaListeBibliothèque��$
��Left=��� $��Visible=�.��]�  � DataContext �� *Manager.OeuvreSélectionnée+.+�� $	��Top=�$��20, 10, 25, 5q� � ColumnDefinitions �� $
��auto ��� $	��145���� $
��auto �.+�� .+��� -   $��Paramètres��$��18, 1, 5, 0q�$��Right=�$��25��$��85��$��
0, 2, 6, 6q�$��13(�
���   �$��2q��� -    & "MaterialDesignFloatingActionButton#��[ $
��Left=�$��28��$��28��
���   �.��'  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 Gear=��� 	 �� TextAlignment$	 Center=�$��1��$��24(����#2B78E4���� *Nom+�� 
 �� Orientation$
 
Horizontal=�$��2��.+��� -    ��Name$ textBox_Recherche��  PlaceHolder#��[ $��
0, 0, 4, 0q�$��3,0,3,0q�$��Stretch=�
 � Tag$ Rechercher une oeuvre��$	��135��$��28���� -     DefaultButtons#���  $��26��$��28��$	��Top=�$��
0, 2, 0, 0q�.��  $ Search=�� $	��Top=�$��Stretch=�$	��400��.+�� $	��Top=�$��20,5,0,0q�$
��Left=�.+��� -   $��Retour��$��18, 1, 30, 0q�$��Right=�$��25��
��� ���
���   �$��62��$��
0, 2, 6, 6q�$��13(�
���   �$��2q��� -   #��[ $
��Left=�$��28��$��28��
���   �
��� ���
���   �.��  $ 	ArrowBack=��� $	��140��$	��140��$��Center=�$��	0,10,55,0q����� *Image+  StringToImageConverter �� 	Converter# [ �� $	��Top=�����   �� DataType(  "Iut.MasterAnime.ClassLibrary.Autre �� StringFormat'  !Iut.MasterAnime.ClassLibrary.Film ��Name)  #Iut.MasterAnime.ClassLibrary.Série(  "Iut.MasterAnime.ClassLibrary.Livre'  !Iut.MasterAnime.ClassLibrary.Scan)  #Iut.MasterAnime.ClassLibrary.Animé��%�  (��       *, +)(�� �    *, +)(�� �    *, +)(�� �    *, +)(�� %    *, +)(�� N
    *, +)�� "  .R�� $	��Top=�$��Center=�$��	0,10,55,0q�.+�� $��Center=�.+��� $��Type : Autre��$��11(�$��5q�#���   �� $
 
Horizontal=�$��5q�.+��� $��Créateur : ��$��11(�#���   �� $��11(�#���   ���� *	Créateur+� $��Center=�.+��� $
 
Horizontal=�$��5q�.+��� $��Date de sortie : ��$��11(�#���   �� $��11(�#���   ���� *Sortie+$ {0:dd/MM/yyyy}���� "  .R�� $	��Top=�$��Center=�$��	0,10,55,0q�.+�� $��Center=�.+��� $��Type : Film��$��11(�$��5q�#���   �� $
 
Horizontal=�$��5q�.+��� $��Réalisateur : ��$��11(�#���   �� $��11(�#���   ���� *Réalisateur+� $��Center=�.+��� $
 
Horizontal=�$��5q�.+��� $��Date de sortie : ��$��11(�#���   �� $��11(�#���   ���� *Sortie+$ {0:dd/MM/yyyy}���� $
 
Horizontal=�$��5q�.+��� $ SecondeInfo��$��	Studio : ��$��11(�#���   �� $ LaSecondeInfo��$��11(�#���   ���� *Studio+�� "  .R�� $	��Top=�$��Center=�$��	0,10,55,0q�.+�� $��Center=�.+��� $��Type : Série��$��11(�$��5q�#���   �� $
 
Horizontal=�$��5q�.+��� $��Réalisateur : ��$��11(�#���   �� $��11(�#���   ���� *Réalisateur+� $��Center=�.+��� $
 
Horizontal=�$��5q�.+��� $��Date de sortie : ��$��11(�#���   �� $��11(�#���   ���� *Sortie+$ {0:dd/MM/yyyy}���� $
 
Horizontal=�$��5q�.+��� $ SecondeInfo��$��	Studio : ��$��11(�#���   �� $ LaSecondeInfo��$��11(�#���   ���� *Studio+�� "  .R�� $	��Top=�$��Center=�$��	0,10,55,0q�.+�� $��Center=�.+��� $��Type : Livre��$��11(�$��5q�#���   �� $
 
Horizontal=�$��5q�.+��� $��	Auteur : ��$��11(�#���   �� $��11(�#���   ���� *Auteur+� $��Center=�.+��� $
 
Horizontal=�$��5q�.+��� $��Date de sortie : ��$��11(�#���   �� $��11(�#���   ���� *Sortie+$ {0:dd/MM/yyyy}���� $
 
Horizontal=�$��5q�.+��� $ SecondeInfo��$��Éditeur : ��$��11(�#���   �� $ LaSecondeInfo��$��11(�#���   ���� *
Éditeur+�� "  .R�� $	��Top=�$��Center=�$��	0,10,55,0q�.+�� $��Center=�.+��� $��Type : Scan��$��11(�$��5q�#���   �� $
 
Horizontal=�$��5q�.+��� $��	Auteur : ��$��11(�#���   �� $��11(�#���   ���� *Auteur+� $��Center=�.+��� $
 
Horizontal=�$��5q�.+��� $��Date de sortie : ��$��11(�#���   �� $��11(�#���   ���� *Sortie+$ {0:dd/MM/yyyy}���� $
 
Horizontal=�$��5q�.+��� $ SecondeInfo��$��Éditeur : ��$��11(�#���   �� $ LaSecondeInfo��$��11(�#���   ���� *
Éditeur+�� "  .R�� $	��Top=�$��Center=�$��	0,10,55,0q�.+�� $��Center=�.+��� $��Type : Animé��$��11(�$��5q�#���   �� $
 
Horizontal=�$��5q�.+��� $��	Auteur : ��$��11(�#���   �� $��11(�#���   ���� *Auteur+� $��Center=�.+��� $
 
Horizontal=�$��5q�.+��� $��Date de sortie : ��$��11(�#���   �� $��11(�#���   ���� *Sortie+$ {0:dd/MM/yyyy}���� $
 
Horizontal=�$��5q�.+��� $ SecondeInfo��$��	Studio : ��$��11(�#���   �� $ LaSecondeInfo��$��11(�#���   ���� *Studio+�� $��	10,0,55,0q�$��Center=�$	��Top=����� *InformationsComplémentaires+���� .R��� $
 
Horizontal=�$��Center=�$��Center=�$��5q�.+���  �� Padding$ 3,0,3,0q�$��11(�#���   ���� *Key.LeString+�� $	�� : ��$��Center=�$ 0,0,0,1q�$��11(�#���   �� $ 3,0,3,0q�$��11(�#���   ���� *Value.LeString+���� .R�� �� $	��Top=�$��	14,10,5,0q�$��Stretch=�.+��� $��0,0,0,0q�.+��� $��Synopsis��$��25,0,0,5q�$��14(�$��DemiBold"�  CouleurTexteGros#���  �� $ 3,1,3,2q�$��10,0,5,0q�$��12(�$
��Wrap=�$��Stretch=����� *
Synopsis+�� $��0,5,0,0q�.+��� $��Commentaire��$��25,0,0,5q�$��14(�$��DemiBold"�#���  �� $ 3,1,3,2q�$��10,0,5,0q�$��12(�$
��Wrap=�$��Stretch=����� *Commentaire+� $	��Top=�$��Right=�$��
10,10,5,15q�$	��Top=�.+��� -	   $��Modifier l'oeuvre��$��18, 1, 5, 0q�$��Right=�$��25�����#20124D$	��125��$��
0, 2, 6, 6q�$��13(�
���   �$��2q��� -
   #��[ $
��Left=�$��28��$��28��
���   ����#20124D.��  $
 Gear=�