   M S B A M L   `   `   `  ����Q  MIut.MasterAnime.Winapp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulle7clr-namespace:Iut.MasterAnime.Winapp.CodePagePrincipale)Iut.MasterAnime.Winapp.CodePagePrincipale  5      >    8Iut.MasterAnime.Winapp.CodePagePrincipale.PagePrincipale   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Ilocal7clr-namespace:Iut.MasterAnime.Winapp.CodePagePrincipale     5      V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5
      ]� .+�5   
   C   =Iut.MasterAnime.Winapp.CodePagePrincipale.ListeBibliothèques  -   5           Name$  LaListeBibliothèque��5   9   $
��Left=�6#   69   �� 5   
   .��5      ]� .+�5      �� $	��Top=�6   $
��Auto=�64   $��Disabled=�6Y   .��5      ]� .+�5      � $	��Top=�6   $��20, 10, 25, 5q�64    � ColumnDefinitions 5      �� 5   "   $
��auto �63   �� 5   "   $	��145��63   �� 5   "   $
��auto �63   .+�5      � .+�5   "   �� -   5        $��Paramètres��5   )   $��18, 1, 5, 0q�6>   $��Right=�6S   $��25��6v   $��85��5   )   $��
0, 2, 6, 6q�64   $��13(�6I   
���   �$��2q�6k   �� 5   "   -   5         &  "MaterialDesignFloatingActionButton#��[  5   )   $
��Left=�6f   $��28��5   )   $��28��65   
���   �.��5   &   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 Gear=�6>   5   #   5       �� 5"       �� TextAlignment$ Center=�6^   $��1��6u   $��20(�5#       ���#2B78E4��5"   (   �� *)'Manager.BibliothèqueSélectionnée.Nom+5#   .   �� 5%       �� Orientation$ 
Horizontal=�6)   $��2��6B   .+�5&   "   �� -   5         ��Name$ textBox_Recherche��5'   R     PlaceHolder#��[ 5&   *   $��
0, 0, 4, 0q�6O   $��3,0,3,0q�6c   $��Stretch=�6u   
 � Tag$ Rechercher une oeuvre��5'   *   $	��135��6F   6R   �� 5(   "   -   5          DefaultButtons#���  5(   )   $��26��6R   $��28��6]   $	��Top=�6i   .��5)   &     $ Search=�6>   5*   #   5+      5,      � 5.      $	��Top=�6   $��0, 5, 25, 15q�64   $	��700��6J    5/      �� 50   "   $��1* �63   $	��120��6>   �� 51   "   $��1* �63   $	��120��6>   �� 52   "   $��1* �63   $	��120��6>   �� 53   "   $
��auto �63   �� 54   "   $
��auto �63   .+�57      �� -   5         ��Name$ ordreTri��59   '   $��Center=�57   '   $��Center=�6B    �� SelectedIndex$ 0��6_   $	��110��6q   $��13(�6}   $��10,0,0,0q�58      -  'MaterialDesignThemes.Wpf.ComboBoxAssist	   ShowSelectedItem$
	 True��6`   .@�5:   "   �� .��6/   	Croissant6:   �� 5;   "   .��6/   Décroissant6<   �� 5<   "   .��6/   Type65   �� 5=   "   .��6/   Date de sortie6?   5>      �� 5@      -   5        $ duType��5B   '   $��Center=�5@   '   $��Center=�6B   $ 0��6_   $��1��6q   $	��110��6�   $��13(�6�   $��10,0,0,0q�5A      $
	 True��61   .@�5C   "   �� .��6/   Tout65   �� 5D   "   .��6/   Film65   �� 5E   "   .��6/   Série66   �� 5F   "   .��6/   Livre66   �� 5G   "   .��6/   Scan65   �� 5H   "   .��6/   Animé66   �� 5I   "   .��6/   Autre66   5J      �� 5L      -   5        $��Center=�5L   '   $��Center=�6B   $ 0��6_   $��2��6q   $	��110��6�   $��13(�5M   M   $��10,0,0,0q�6[   $
	 True��6m   .@�5N   "   �� .��6/   Icône66   �� 5O   "   .��6/   Ligne66   5P      � 5S      $��3��6#   $��	10,0,10,0q�63   .+�5T   "   �� -	   5        $��Ajouter une oeuvre��5T   )   $��16, 0, 0, 0q�6F   $��Right=�6[   $��22��6~   $	��115��6�   $��
0, 0, 6, 2q�5U      $��11(�62   
���   �
��� ���
���   �$��2q�6{   5V   )   �� 5W   "   -
   5        #��[  5W   )   $
��Left=�6e   $��25��5X      $��25��6)   
���   �
��� ���
���   �.��5Y   &     $ 	PlusThick=�6>   5Z   #   5[      � 5]      $��4��6#   $��0,0,0,0q�63   .+�5^   "   �� -   5        $��Modifier la liste��5^   )   $��Right=�6E   $��17,0,0,0q�6h   $��22��6z   $��95��6�   $��
0, 0, 6, 2q�5_      $��11(�62   
���   �
��� ���
���   �$��2q�6{   5`   )   �� 5a   "   -   5        #��[  5a   )   $
��Left=�6e   $��25��5b      $��25��6)   
���   �
��� ���
���   �.��5c   &     $
 Gear=�6>   5d   #   5e      5f      5g      5h      �� 5k      -   5        
 ��Name$
 AffichageOeuvres��5k   !   $��Stretch=�6;   5n      5o      5q      5s      