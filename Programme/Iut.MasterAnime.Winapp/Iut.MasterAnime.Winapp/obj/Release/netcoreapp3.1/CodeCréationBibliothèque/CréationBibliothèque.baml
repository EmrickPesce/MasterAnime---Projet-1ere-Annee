   M S B A M L   `   `   `  ���� Q  MIut.MasterAnime.Winapp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullu?clr-namespace:Iut.MasterAnime.Winapp.CodeCréationBibliothèque1Iut.MasterAnime.Winapp.CodeCréationBibliothèque  N    HIut.MasterAnime.Winapp.CodeCréationBibliothèque.CréationBibliothèque   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Qlocal?clr-namespace:Iut.MasterAnime.Winapp.CodeCréationBibliothèque     V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -     �Name$  CréationBiblio�� � WindowStartupLocation$ CenterScreen=� � Title$ Création d'une liste��$	��230��$	��485��.���� $
��Auto=�$
��auto=�$	��485��.��� $��0,10,0,0q�$��Center=�$��Center=� � DataContext �� *NouvelleBibliothèque+ � ColumnDefinitions �� $��1* ��� $
��1.2* �.+��� .+��� $	��160��$	��100��$��0,5,0,10q����� *Image+   StringToImageConverter �� 	Converter# [  �� $��Importer une image :�� �� TextAlignment$ Center=����#2B78E4$��14(�$��	10,0,50,0q���  �� Orientation$ 
Horizontal=�$��Center=�$��5,5,5,0q�.+��� $	��140��$��2,3,3,3q�$��28������ *Image+�� -   $��Explorer��  DefaultButtons#��[ $��3,0,3,2q�
�������
���   �
���   �$��2q�$��28��$��0,3,3,3q��� $��1��.+��� $��Donner un nom :�����#2B78E4$��14(�$��20,3,0,0q��� 
 � Tag$ Entrez un nom��$��0,5,20,5q�$	��200��  PlaceHolder#��[ $��28������ *Nom+	 �� ValidatesOnDataErrors$
	 True��
 �� UpdateSourceTrigger$
 PropertyChanged=�� $��5q� � RowDefinitions �� �� �� .+�� $��	13,10,0,0q�$
��Left=�.+��� -   $%��Ajouter des oeuvres à la liste��$��15, 0, 0, 0q�$��Right=�$��14(�$
��Left=�$��25��$	��205��$��0,0,6,3q�
��� ���
���   �
���   ��� -    & "MaterialDesignFloatingActionButton#��[ $
��Left=�$��28��$��28��
��� ���
���   �
���   �.��'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	PlusThick=��� $��1��$��Right=�$��0,5,15,0q�  CouleurTexte#���  ���� *AAjouter.Count+ �� ElementName$ CréationBiblio�� �� StringFormat$/ )’{0} oeuvre(s) ont été ajoutée(s)’��� $��	15,15,0,0q�$��2��.+��� -   $��Annuler��$��15, 1, 0, 0q�$��Right=�$��14(�$
��Left=�$��25��$��75��$��0,0,6,3q�
���� ��
���   ��� -   #��[ $
��Left=�$��28��$��28��
���� ��
���   �.��  $ 
CloseThick=�� $��2��$��115,15,15,0q�.+��� -   $��Sauvegarder��$��
0,1, 14, 0q�$
��Left=�$��14(�$��Right=�$��25��$	��105��$��6,0,0,4q�
��� � �
���   ��� -   #��[ $��Right=�$��28��$��28��
��� � �
���   �.��  $ ContentSave=�