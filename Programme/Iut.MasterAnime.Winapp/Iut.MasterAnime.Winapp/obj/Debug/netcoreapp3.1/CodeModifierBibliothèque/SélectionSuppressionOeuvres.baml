   M S B A M L   `   `   `  ����Q  MIut.MasterAnime.Winapp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulle7clr-namespace:Iut.MasterAnime.Winapp.CodePagePrincipale)Iut.MasterAnime.Winapp.CodePagePrincipale  5      s>clr-namespace:Iut.MasterAnime.Winapp.CodeModifierBibliothèque0Iut.MasterAnime.Winapp.CodeModifierBibliothèque  5      S    MIut.MasterAnime.Winapp.CodeModifierBibliothèque.SélectionSuppressionOeuvres   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      LpagePrincipale7clr-namespace:Iut.MasterAnime.Winapp.CodePagePrincipale  5      Jlocal>clr-namespace:Iut.MasterAnime.Winapp.CodeModifierBibliothèque  5      -   5          >�Name$  SélectionSuppression��5	       � 	Resources 5         Suppression ��Name  DefaultButtons
 � Tag ��Name  StringToImageConverter �� 	Converter ��Name �� TextAlignment'  !MaterialDesignThemes.Wpf.PackIcon  Name	   Kind��%Z  &	        7  7  �� 5   
   .R�5      �� $ leBoutonOeuvre��5   J   -   5        8��  $
��5, 2q�5   =   
�������
����  �$��3q�5   !    6b   �� *Nom+.��5      � .+�5      �� $��0,0,25,0q�6!   .+�5      �� $ lImage��6    $��90��6|   $��90��6�   ��60   �� *Image+8  6�   �� 5      $ leTextBlock��6$   $ Center=�6N   $��0,2,0,2q�6e   ��69   �� *Nom+6e   5        5      $ lIcone��6.   $	 CircleOutline=�6>   
����  �$��Right=�6e   $��Bottom=�6�   $��24��5   &   $��24��62   5      5      5      5      .��5      ]� 
 � DataContext
 6   �� *%#Manager.BibliothèqueSélectionnée+ �� ElementName$ SélectionSuppression��.+�5   
   �� .��5      ]� .+�5      �� $	��Top=�6   $
��Auto=�64   $��Disabled=�6Y   .��5       ]� .+�5!      � $	��Top=�6   $��25, 10, 25, 5q�64    � ColumnDefinitions 5"      �� 5#   "   $
��auto �63   �� 5$   "   $	��145��63   �� 5%   "   $
��auto �63   .+�5(      � $
��10,0q�6#   .+�5)   "   �� -   5        $��Annuler la suppression��5)   )   $��18, 1, 5, 0q�6J   $��Right=�6_   $��25��6�   $	��155��5*   )   $��
0, 2, 6, 6q�65   $��13(�6J   
���   �$��2q�6l   
��� � �5+   <   �� 5,   "   -   5         & "MaterialDesignFloatingActionButton#��[ 5,   )   $
��Left=�6f   $��28��5-   )   $��28��65   
���   �
��� � �.��5.   &     $	 Close=�6>   5/   #   50      �� 52      $ Center=�6=   $��1��6T   $��Center=�6d   $��20(�53       ���#2B78E4��52   (   �� *Nom+53   .   � 55      $��2��6#   $
��10,0q�63   .+�56   "   �� -   5        $ 
Supprimer1��58   :   $��Supprimer les oeuvres��56   )   $��18, 1, 5, 0q�6I   $��Right=�6^   $��25��6�   $	��150��57   )   $��
0, 2, 6, 6q�65   $��13(�6J   
���   �$��2q�6l   
���  ��58   N   �� 59   "   -   5        $ 
Supprimer2��5:   e   #��[ 59   )   $
��Left=�6f   $��28��5:   )   $��28��65   
���   �
���  ��.��5;   &     $	 Trash=�6>   5<   #   5=      5>      � 5@      $	��Top=�6   $��0, 5, 0, 15q�64   $��Center=�6I    5A      �� 5B   "   $
��auto �63   �� 5C   "   $��1* �63   $	��120��6>   �� 5D   "   $��1* �63   $	��120��6>   �� 5E   "   $
��auto �63   �� 5F   "   $
��auto �63   .+�5I      � $��	20,0,20,0q�6#   .+�5J   "   �� -   5        $��Tout décocher��5J   )   $��
16 1, 5, 0q�6A   $��Right=�6U   $��25��6x   $	��105��5K   )   $��
0, 2, 6, 6q�65   $��13(�6J   
���   �$��2q�6l   
��� ���
���   �5L   P   �� 5M   "   -   5        #��[ 5M   )   $
��Left=�6f   $��28��5N   )   $��28��65   
���   �
��� ���
���   �.��5O   &     $	 CircleOutline=�6>   5P   #   5Q      �� 5S      -	   5         ��Name$ ordreTri��5T   w   $��Center=�5S   '   $��Center=�6B    �� SelectedIndex$ 0��6_   $	��110��6q   $��13(�6}   $��0,0,20,0q�5T      $��1��61   -  'MaterialDesignThemes.Wpf.ComboBoxAssist   ShowSelectedItem$
 True��6A   .@�5V   "   �� .��6/   	Croissant6:   �� 5W   "   .��6/   Décroissant6<   �� 5X   "   .��6/   Type65   �� 5Y   "   .��6/   Date de sortie6?   5Z      �� 5\      -
   5        $ duType��5]   g   $��Center=�5\   '   $��Center=�6B   $ 0��6_   $��2��6q   $	��110��6�   $��13(�6�   $��0,0,20,0q�5]      $
 True��61   .@�5^   "   �� .��6/   Tout65   �� 5_   "   .��6/   Film65   �� 5`   "   .��6/   Série66   �� 5a   "   .��6/   Livre66   �� 5b   "   .��6/   Animé66   �� 5c   "   .��6/   Scan65   �� 5d   "   .��6/   Autre66   5e      � 5g      $��3��6#   .+�5h   "   �� -   5        $��Tout cocher��5h   )   $��18, 1, 5, 0q�6?   $��Right=�6T   $��25��6w   $��90��5i   )   $��
0, 2, 6, 6q�64   $��13(�6I   
���   �$��2q�6k   
��� ���
���   �5j   P   �� 5k   "   -   5        #��[ 5k   )   $
��Left=�6f   $��28��5l   )   $��28��65   
���   �
��� ���
���   �.��5m   &     $	 TickCircleOutline=�6>   5n   #   5o      5p      5q      5r      �� 5t      -   5         ��Name$ lItemsControl��5t   �   $��20, 0, 10, 0q�6   ��65   �� *Bibliothèque.LesOeuvres+$ SélectionSuppression����5u      �� 5v      .R�5w      �� $ leBoutonOeuvre��5x   J   -   5        #��[ 5w   %   $
��5, 2q�6M   
�������$��3q�5x   !     CouleurDeFond#���  6v    6b   �� *Nom+.��5y   "   � .+�5z   &   �� $��0,0,25,0q�61   .+�5{   *   �� $ lImage��60   $��90��6�   $��90��6�   ��6@   �� *Image+# [ 6�   �� 5|   *   $ leTextBlock��64   $ Center=�6^   $��0,2,0,2q�6u     CouleurTexte#���  6�   ��6I   �� *Nom+6�   5}   '     5~   &   $ lIcone��6>   $	 CircleOutline=�6N   
�������$��Right=�6z   $��Bottom=�6�   $��24��5   &   $��24��62   5�   #   5�      5�      ��5�      �� 5�      .R�5�      � 5�      5�      5�      5�      5�      5�      