   M S B A M L   `   `   `  ����Q  MIut.MasterAnime.Winapp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulle7clr-namespace:Iut.MasterAnime.Winapp.CodePagePrincipale)Iut.MasterAnime.Winapp.CodePagePrincipale  5      s>clr-namespace:Iut.MasterAnime.Winapp.CodeModifierBibliothèque0Iut.MasterAnime.Winapp.CodeModifierBibliothèque  5      Y    SIut.MasterAnime.Winapp.CodeModifierBibliothèque.SélectionAjoutOeuvresModification   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      LpagePrincipale7clr-namespace:Iut.MasterAnime.Winapp.CodePagePrincipale  5      Jlocal>clr-namespace:Iut.MasterAnime.Winapp.CodeModifierBibliothèque  5      -   5          >�Name$  SélectionAjout��5	      .��5      ]� .+�5   
   �� .��5      ]� .+�5      �� $	��Top=�6   $
��Auto=�64   $��Disabled=�6Y   .��5      ]� .+�5      � $	��Top=�6   $��25, 10, 25, 5q�64    � ColumnDefinitions 5      �� 5   "   $
��auto �63   �� 5   "   $	��145��63   �� 5   "   $
��auto �63   .+�5      � $
��10,0q�6#   .+�5   "   �� -   5        $��Annuler l'ajout��5   )   $��18, 1, 5, 0q�6C   $��Right=�6X   $��25��6{   $	��110��5   )   $��
0, 2, 6, 6q�65   $��13(�6J   
���   �$��2q�6l   
���  ��5   :   �� 5   "   -   5         &  "MaterialDesignFloatingActionButton#��[  5   )   $
��Left=�6f   $��28��5   )   $��28��65   
���   �
���  ��.��5   &   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Close=�6>   5   #   5       �� 5"       �� TextAlignment$ Center=�6^   $��1��6u   $��Center=�6�   $��20(�5#       ���#2B78E4��5"   (   �� *)'Manager.BibliothèqueSélectionnée.Nom+5#   .   � 5%      $��2��6#   $
��10,0q�63   .+�5&   "   �� -   5        $��Ajouter les oeuvres��5&   )   $��18, 1, 5, 0q�6G   $��Right=�6\   $��25��6   $	��135��5'   )   $��
0, 2, 6, 6q�65   $��13(�6J   
���   �$��2q�6l   
��� � �5(   <   �� 5)   "   -   5        #��[  5)   )   $
��Left=�6f   $��28��5*   )   $��28��65   
���   �
��� � �.��5+   &     $ Trash=�6>   5,   #   5-      5.      � 50      $	��Top=�6   $��0, 5, 0, 15q�64   $��Center=�6I    51      �� 52   "   $
��auto �63   �� 53   "   $��1* �63   $	��120��6>   �� 54   "   $��1* �63   $	��120��6>   �� 55   "   $
��auto �63   �� 56   "   $
��auto �63   .+�59      � $��	20,0,20,0q�6#   .+�5:   "   �� -   5        $��Tout décocher��5:   )   $��
16 1, 5, 0q�6A   $��Right=�6U   $��25��6x   $	��105��5;   )   $��
0, 2, 6, 6q�65   $��13(�6J   
���   �$��2q�6l   
��� ���
���   �5<   P   �� 5=   "   -   5        #��[  5=   )   $
��Left=�6f   $��28��5>   )   $��28��65   
���   �
��� ���
���   �.��5?   &     $ CircleOutline=�6>   5@   #   5A      �� 5C      -   5         ��Name$ ordreTri��5D   w   $��Center=�5C   '   $��Center=�6B    �� SelectedIndex$ 0��6_   $	��110��6q   $��13(�6}   $��0,0,20,0q�5D      $��1��61   -  'MaterialDesignThemes.Wpf.ComboBoxAssist   ShowSelectedItem$
 True��6A   .@�5F   "   �� .��6/   	Croissant6:   �� 5G   "   .��6/   Décroissant6<   �� 5H   "   .��6/   Type65   �� 5I   "   .��6/   Date de sortie6?   5J      �� 5L      -	   5        $ duType��5M   g   $��Center=�5L   '   $��Center=�6B   $ 0��6_   $��2��6q   $	��110��6�   $��13(�6�   $��0,0,20,0q�5M      $
 True��61   .@�5N   "   �� .��6/   Tout65   �� 5O   "   .��6/   Film65   �� 5P   "   .��6/   Série66   �� 5Q   "   .��6/   Livre66   �� 5R   "   .��6/   Animé66   �� 5S   "   .��6/   Scan65   �� 5T   "   .��6/   Autre66   5U      � 5W      $��3��6#   .+�5X   "   �� -
   5        $��Tout cocher��5X   )   $��18, 1, 5, 0q�6?   $��Right=�6T   $��25��6w   $��90��5Y   )   $��
0, 2, 6, 6q�64   $��13(�6I   
���   �$��2q�6k   
��� ���
���   �5Z   P   �� 5[   "   -   5        #��[  5[   )   $
��Left=�6f   $��28��5\   )   $��28��65   
���   �
��� ���
���   �.��5]   &     $ TickCircleOutline=�6>   5^   #   5_      5`      5a      5b      �� 5d      -   5         ��Name$ lItemsControl��5d   e   $��20, 0, 10, 0q�6   ��65   �� *Bibliothèque.LesOeuvres+��5e      �� 5f      .R�5g      ��  ��Name$ leBoutonOeuvre��5h   J   -   5          DefaultButtons#��[ 5g   %   $
��5, 2q�6M   
�������$��3q�5h   !     CouleurDeFond#���  6b   .��5i   "   � .+�5j   &   �� $��0,0,25,0q�61   .+�5k   *   �� 	 ��Name$	 lImage��60   $��90��6�   $��90��6�   ��6@   �� *Image+  StringToImageConverter
 �� 	Converter#
 [ 6�   �� 5l   *    ��Name$ leTextBlock��64   $ Center=�6^   $��0,2,0,2q�6u     CouleurTexte#���  6�   ��6I   �� *Nom+6�   5m   '     5n   &     Name$ lIcone��6>   $ CircleOutline=�6N   
�������$��Right=�6z   $��Bottom=�6�   $��24��5o   &   $��24��62   5p   #   5q      5r      ��5t      �� 5u      .R�5v      � 5w      5y      5{      5}      5~      5      