   M S B A M L   `   `   `  ���� Q  MIut.MasterAnime.Winapp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Iut.MasterAnime.WinappIut.MasterAnime.Winapp  L    FIut.MasterAnime.Winapp.CodeModifierBibliothèque.ModifierBibliothèque   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  0local$clr-namespace:Iut.MasterAnime.Winapp  -     �Name$  ModificationBibliothèque�� � WindowStartupLocation$ CenterScreen=� � Title$ Modifier la liste��$	��270��$	��473��.���� $
��Auto=�$
��Auto=�.��� $��0,10,0,0q�$	��230��$	��473��$��Center=� � ColumnDefinitions �� $��1* ��� $��1* � � RowDefinitions �� �� $
��auto �.+��� .+��� $	��160��$	��100��$��0,5,0,10q����� *Image+   StringToImageConverter �� 	Converter# [   �� Mode$ OneWay=��� $#��Importer une nouvelle image :�� �� TextAlignment$ Center=����#2B78E4$��14(���  �� Orientation$ 
Horizontal=�$��Center=�$��5,10,0,0q�.+��� $	��140��$��3q�$��28������ *Image+$ TwoWay=��� -   $��Explorer��  DefaultButtons#��[ $��3,0,3,2q�
�������
���   �
���   �$��2q�$��28���� $��1��.+��� $��Changer le nom :�����#2B78E4$��14(�$��5,3,0,0q��� $��	0,5,20,10q�$	��200������ *Nom+	 �� ValidatesOnDataErrors$
	 True��
 �� UpdateSourceTrigger$
 PropertyChanged=�� $��5q� �� �� �� .+�� $��0,5,0,0q�.+��� -   $��Annuler��$��15, 1, 0, 0q�$��Right=�$��14(�$
��Left=�$��26��$��75��$��0,0,6,3q�
���� ��
���   ��� -    & "MaterialDesignFloatingActionButton#��[ $
��Left=�$��27��$��27��
���� ��
���   �.��'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Close=�� $��1��$��0,7,22,0q�.+��� -   $��Sauvegarder��$��
0,1, 14, 0q�$
��Left=�$��14(�$��Right=�$��26��$	��105��$��6,0,0,4q�
��� � �
���   ��� -   #��[ $��Right=�$��27��$��27��
��� � �
���   �.��  $ ContentSave=�� $��2��$��0,7,0,0q�.+��� -   $��Supprimer des oeuvres��$��15, 1, 0, 0q�$��Right=�$��14(�$
��Left=�$��26��$	��170��$��0,0,6,3q�
��� ���
���   �
���   ��� -   #��[ $
��Left=�$��27��$��27��
��� ���
���   �
���   �.��  $ 
TrashEmpty=�� $��Center=�$��1��$��2��$��4q�.+��� -	   $��Supprimer la liste��$��20, 1, 0, 0q�$��Right=�$��14(�$��27��$	��135��$��0,0,6,3q�
���  ��
���   ��� -
   #��[ $
��Left=�$��30��$��30��
���  ��
���   �.��  $ TrashCan=�