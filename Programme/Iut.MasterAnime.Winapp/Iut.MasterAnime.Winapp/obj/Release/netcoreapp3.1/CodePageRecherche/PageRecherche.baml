   M S B A M L   `   `   `  ���� Q  MIut.MasterAnime.Winapp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:Iut.MasterAnime.Winapp.CodePageRecherche(Iut.MasterAnime.Winapp.CodePageRecherche  <    6Iut.MasterAnime.Winapp.CodePageRecherche.PageRecherche   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  Blocal6clr-namespace:Iut.MasterAnime.Winapp.CodePageRecherche  -     >�Name$  	Recherche��.��]� .+��� $	��Top=�$
��Auto=�$��Disabled=�.���  � ColumnDefinitions �� $
��auto ��� $
��auto ��� �� $
��auto �.+�� $��20,0,0,0q�.+��� -   $��Retour��$��18, 0, 0, 0q�$��Right=�$��25��$��60��$��
0, 2, 6, 6q�$��13(�
��� ���
���   �
���   �$��2q��� -    &  "MaterialDesignFloatingActionButton#��[  $
��Left=�$��27��$��27��
��� ���
���   �
���   �.��'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	ArrowBack=�$��20��$��20��� $��15,0,0,0q�$��1��.+��� -   $��Paramètres��$��15, 0, 0, 0q�$��Right=�
���   �$��25��$��88��$��
0, 2, 6, 6q�$��13(�$��2q��� -   #��[  $
��Left=�$��27��$��27��
���   �.��  $
 Gear=���  �� Orientation$ 
Horizontal=�$��2��$��20,12,16,15q�$��Center=�.+��� -    ��Name$ TextBoxLaRecherche��$��
0, 0, 4, 0q�$	��330��$��5,0,0,0q�  PlaceHolder#��[ 
 � Tag$ Rechercher une oeuvre������ *	CharNom+ �� UpdateSourceTrigger$ PropertyChanged=��� -     DefaultButtons#���  $��26��$��28��$	��Top=�.��  $ Search=�� $��3��.+��� -   $��Ajouter une oeuvre��$��14, 0, 20, 0q�$��Right=�$��25��$	��136��$��
0, 2, 6, 6q�$��13(�
��� ���
���   �
���   �$��2q��� -	   #��[  $
��Left=�$��27��$��27��
��� ���
���   �
���   �.��  $ 	PlusThick=�$��20��$��20���� 
���   �$��4��$	��Top=�$��3���� $
��Left=�$
��Auto=�$
��Auto=�.���  � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� $��Ordre��$��Center=�$��	15,12,0,0q�$
��Bold"�$��11(�  CouleurTexte#���  �� -
   $��Center=�$��Right=� �� SelectedIndex$ 0��$	��110��$��	0,12,15,0q�-  'MaterialDesignThemes.Wpf.ComboBoxAssist	   ShowSelectedItem$
	 True��.@��� .��	Croissant�� .��Décroissant�� .��Type�� .��Date de sortie�� $
��Type��$��Center=�$��1��$��15,4,0,0q�$
��Bold"�$��11(�#���  �� -   
 ��Name$
 LeType��$��Center=�$��Right=�$ 0��$	��110��$��1��$��0,4,15,0q�$
	 True��.@��� .��Tout�� .��Film�� .��Série�� .��Livre�� .��Scan�� .��Animé�� .��Autre�� $��2��$ 
Horizontal=�$��	15,4,15,0q�.+��� $��	Affichage��$��Center=�$��0,0,15,0q�$
��Bold"�$��11(�#���  �� -   $
 typeAffichage��$��Center=�$ 0��$	��110��$
	 True��.@��� .��Icône�� .��Ligne�� $��Liste��$��Center=�$��3��$��15,4,0,0q�$
��Bold"�$��11(�#���  �� -   $��Center=�$��Right=�$	��110��$��3��$��0,4,15,0q�$
	 True�� �� SelectedItem �� *%#Manager.BibliothèqueSélectionnée+���� *Manager.VuDesBibliothèques+���� .R���  ��Name$ leTextBlock������ *Nom+�� $��Sortie��$��Center=�$��4��$��2��$��15,2,0,0q�$
��Bold"�$��11(�#���  ��   CouleurDeFond#���  $��2q�  CouleurBordures#���  $��0,4,16,0q�$��Right=�$��26��$	��109��$��4��$��Center=�._�(  "System.Windows.Controls.DatePicker  -     Name$ LaSortie��#���  $	��3,0q�   SelectedDate �� *DateTimeDeLOeuvre+$ PropertyChanged=��� -   $
 RéférentielDate��$��Center=�$��Right=�$ 0��$	��110��$��5��$��0,2,15,0q�$
	 True��.@��� .��Non utilisé�� .��Avant�� .��	Pendant�� .��Après�� $��Auteur/Réalisateur :��$	��Top=�$��6��$��2��$��15,4,0,0q�$
��Bold"�$��11(�#���  �� -   $ 
AuteurRéa��$ Auteur/Réalisateur��$��6��$��Bottom=�$
��Left=�$	��174��$��	15,24,0,0q�$��26��#��[ ���� *AuteurRéalisateur+$ PropertyChanged=��� $��Studio/Éditeur :��$	��Top=�$��7��$��2��$��15,4,0,0q�$
��Bold"�$��11(�#���  �� -   $ StudioÉdit��$ Studio/Éditeur��$��7��$��Bottom=�$
��Left=�$	��174��$��	15,24,0,5q�$��26��#��[ ���� *StudioÉditeur+$ PropertyChanged=��� -   $
 Mot1��$ 
Mot clé 1��$��8��$��Bottom=�$
��Left=�$	��150��$��15,6,0,0q�$��26��#��[ ���� *
MotClé1+$ PropertyChanged=��� -   $
 Mot2��$ 
Mot clé 2��$��9��$��Bottom=�$
��Left=�$	��150��$��15,6,0,0q�$��26��#��[ ���� *
MotClé2+$ PropertyChanged=��� -   $
 Mot3��$ 
Mot clé 3��$��10��$��Bottom=�$
��Left=�$	��150��$��15,6,0,0q�$��26��#��[ ���� *
MotClé3+$ PropertyChanged=��� 
���   �$��11��$
��Left=�$��3���� .���� -    ��Name$ AffichageOeuvres��