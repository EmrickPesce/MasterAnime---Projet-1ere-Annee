   M S B A M L   `   `   `  ����Q  MIut.MasterAnime.Winapp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Iut.MasterAnime.WinappIut.MasterAnime.Winapp  5   	   L    FIut.MasterAnime.Winapp.CodeModifierBibliothèque.ModifierBibliothèque   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   0local$clr-namespace:Iut.MasterAnime.Winapp  5   	   -   5          �Name$  ModificationBibliothèque��5       � WindowStartupLocation$ CenterScreen=�6<    � Title$ Modifier la liste��5	   	   $	��270��6#   $	��473��60   .��5      �� $
��Auto=�6   $
��Auto=�68   .��5   
   � $��0,10,0,0q�6   $	��230��6!   $	��473��61   $��Center=�6@    � ColumnDefinitions 5      �� 5      $��1* �6#   �� 5      $��1* �6#    � RowDefinitions 5      �� 5      �� 5      $
��auto �6    .+�5      �� .+�5      �� $	��160��6q   $	��100��6�   $��0,5,0,10q�5      ��5      �� *Image+   StringToImageConverter �� 	Converter# [   �� Mode$ OneWay=�5      �� 5      $#��Importer une nouvelle image :��6    �� TextAlignment$ Center=�6A   ���#2B78E4$��14(�6m   �� 5       �� Orientation$ 
Horizontal=�6   $��Center=�66   $��5,10,0,0q�6S   .+�5      �� $	��140��6   $��3q�6*   $��28��6Y   ��65   �� *Image+$ TwoWay=�6Y   �� 5      -   5        $��Explorer��5        DefaultButtons#��[ 60   $��3,0,3,2q�6X   
�������
���   �
���   �$��2q�5   S   $��28��6g   5      5      �� 5!      $��1��6   .+�5#      �� $��Changer le nom :��6   ���#2B78E4$��14(�6I   $��5,3,0,0q�6W   �� 5$      $��	0,5,20,10q�6p   $	��200��6�   ��6   �� *Nom+	 �� ValidatesOnDataErrors$
	 True��
 �� UpdateSourceTrigger$
 PropertyChanged=�6�   � 5&      $��5q�6    5'      �� 5(      �� 5)      �� 5*      .+�5-      � $��0,5,0,0q�6   .+�5.      �� -   5        $��Annuler��5.   !   $��15, 1, 0, 0q�63   $��Right=�6H   $��14(�6k   $
��Left=�6y   $��26��5/      $��75��6!   $��0,0,6,3q�6,   
���� ��
���   �6j   �� 50      -   5         & "MaterialDesignFloatingActionButton#��[ 50   !   $
��Left=�6]   $��27��51      $��27��6!   
���� ��
���   �.��52      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Close=�66   53      54      � 56      $��1��6   $��0,7,22,0q�6(   .+�57      �� -   5        $��Sauvegarder��57   !   $��
0,1, 14, 0q�67   $
��Left=�6K   $��14(�6m   $��Right=�6{   $��26��58      $	��105��6!   $��6,0,0,4q�6-   
��� � �
���   �6f   �� 59      -   5        #��[ 59   !   $��Right=�6]   $��27��5:      $��27��6!   
��� � �
���   �.��5;        $ ContentSave=�66   5<      5=      � 5?      $��2��6   $��0,7,0,0q�6(   .+�5@      �� -   5        $��Supprimer des oeuvres��5@   !   $��15, 1, 0, 0q�6A   $��Right=�6V   $��14(�6y   $
��Left=�6�   $��26��5A      $	��170��6!   $��0,0,6,3q�6-   
��� ���
���   �
���   �6z   �� 5B      -   5        #��[ 5B   !   $
��Left=�6]   $��27��5C      $��27��6!   
��� ���
���   �
���   �.��5D        $ 
TrashEmpty=�66   5E      5F      5G      5I      � 5K      $��Center=�6   $��1��60   $��2��6=   $��4q�6Q   .+�5L      �� -	   5        $��Supprimer la liste��5L      $��20, 1, 0, 0q�66   $��Right=�6K   $��14(�6n   $��27��5M      $	��135��6!   $��0,0,6,3q�6-   
���  ��
���   �6d   �� 5N      -
   5        #��[ 5N      $
��Left=�6U   $��30��5O      $��30��6!   
���  ��
���   �.��5P        $ TrashCan=�6.   5Q      5R      5S      5T      5V      