   M S B A M L   `   `   `  ����Q  MIut.MasterAnime.Winapp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullu?clr-namespace:Iut.MasterAnime.Winapp.CodeCréationBibliothèque1Iut.MasterAnime.Winapp.CodeCréationBibliothèque  5   	   N    HIut.MasterAnime.Winapp.CodeCréationBibliothèque.CréationBibliothèque   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Qlocal?clr-namespace:Iut.MasterAnime.Winapp.CodeCréationBibliothèque     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          �Name$  CréationBiblio��5   ?    � WindowStartupLocation$ CenterScreen=�6    � Title$ Création d'une liste��5	   	   $	��230��6&   $	��485��63   .��5      �� $
��Auto=�6   $
��auto=�66   $	��485��6[   .��5   
   � $��0,10,0,0q�6   $��Center=�6N   $��Center=�6k    � DataContext 6!   �� *NouvelleBibliothèque+ � ColumnDefinitions 5      �� 5      $��1* �6#   �� 5      $
��1.2* �6#   .+�5      �� .+�5      �� $	��160��6d   $	��100��6s   $��0,5,0,10q�6�   ��6   �� *Image+   StringToImageConverter �� 	Converter# [  6�   �� 5      $��Importer une image :��6    �� TextAlignment$ Center=�68   ���#2B78E4$��14(�6d   $��	10,0,50,0q�6r   �� 5       �� Orientation$ 
Horizontal=�6   $��Center=�66   $��5,5,5,0q�6S   .+�5      �� $	��140��6   $��2,3,3,3q�6*   $��28��6R   ��6;   �� *Image+6R   �� 5      -   5        $��Explorer��5        DefaultButtons#��[ 60   $��3,0,3,2q�6X   
�������
���   �
���   �$��2q�5   S   $��28��6g   $��0,3,3,3q�6s   5      5      �� 5      $��1��6   .+�5      �� $��Donner un nom :��6   ���#2B78E4$��14(�6H   $��20,3,0,0q�6V   �� 5       
 � Tag$ Entrez un nom��6p   $��0,5,20,5q�6�   $	��200��6�     PlaceHolder#��[ 5!      $��28��6?   ��5       �� *Nom+	 �� ValidatesOnDataErrors$
	 True��
 �� UpdateSourceTrigger$
 PropertyChanged=�5!   ?   � 5#      $��5q�6    � RowDefinitions 5$      �� 5%      �� 5&      �� 5'      .+�5*      � $��	13,10,0,0q�6   $
��Left=�6.   .+�5+      �� -   5        $%��Ajouter des oeuvres à la liste��5+   !   $��15, 0, 0, 0q�6J   $��Right=�6_   $��14(�6�   $
��Left=�6�   $��25��5,      $	��205��6!   $��0,0,6,3q�6-   
��� ���
���   �
���   �6z   �� 5-      -   5         & "MaterialDesignFloatingActionButton#��[ 5-   !   $
��Left=�6]   $��28��5.      $��28��6!   
��� ���
���   �
���   �.��5/      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	PlusThick=�66   50      51      �� 53      $��1��54       $��Right=�6-   $��0,5,15,0q�6I     CouleurTexte#���  6[   ��53       �� *AAjouter.Count+ �� ElementName$ CréationBiblio�� �� StringFormat$/ )’{0} oeuvre(s) ont été ajoutée(s)’��54   [   � 56      $��	15,15,0,0q�6   $��2��6.   .+�57      �� -   5        $��Annuler��57   !   $��15, 1, 0, 0q�63   $��Right=�6H   $��14(�6k   $
��Left=�6y   $��25��58      $��75��6!   $��0,0,6,3q�6,   
���� ��
���   �6j   �� 59      -   5        #��[ 59   !   $
��Left=�6]   $��28��5:      $��28��6!   
���� ��
���   �.��5;        $ 
CloseThick=�66   5<      5=      � 5?      $��2��6   $��115,15,15,0q�6(   .+�5@      �� -   5        $��Sauvegarder��5@   !   $��
0,1, 14, 0q�67   $
��Left=�6K   $��14(�6m   $��Right=�6{   $��25��5A      $	��105��6!   $��6,0,0,4q�6-   
��� � �
���   �6f   �� 5B      -   5        #��[ 5B   !   $��Right=�6]   $��28��5C      $��28��6!   
��� � �
���   �.��5D        $ ContentSave=�66   5E      5F      5G      5I      5J      5K      5L      