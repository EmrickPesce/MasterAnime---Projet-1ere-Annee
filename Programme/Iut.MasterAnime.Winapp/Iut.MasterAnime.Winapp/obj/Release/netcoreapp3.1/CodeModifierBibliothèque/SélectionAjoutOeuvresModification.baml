   M S B A M L   `   `   `  ���� Q  MIut.MasterAnime.Winapp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulle7clr-namespace:Iut.MasterAnime.Winapp.CodePagePrincipale)Iut.MasterAnime.Winapp.CodePagePrincipale  s>clr-namespace:Iut.MasterAnime.Winapp.CodeModifierBibliothèque0Iut.MasterAnime.Winapp.CodeModifierBibliothèque  Y    SIut.MasterAnime.Winapp.CodeModifierBibliothèque.SélectionAjoutOeuvresModification   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  LpagePrincipale7clr-namespace:Iut.MasterAnime.Winapp.CodePagePrincipale  Jlocal>clr-namespace:Iut.MasterAnime.Winapp.CodeModifierBibliothèque  -     >�Name$  SélectionAjout��.��]� .+��� .��]� .+��� $	��Top=�$
��Auto=�$��Disabled=�.��]� .+�� $	��Top=�$��25, 10, 25, 5q� � ColumnDefinitions �� $
��auto ��� $	��145���� $
��auto �.+�� $
��10,0q�.+��� -   $��Annuler l'ajout��$��18, 1, 5, 0q�$��Right=�$��25��$	��110��$��
0, 2, 6, 6q�$��13(�
���   �$��2q�
���  ���� -    &  "MaterialDesignFloatingActionButton#��[  $
��Left=�$��28��$��28��
���   �
���  ��.��'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Close=���  �� TextAlignment$ Center=�$��1��$��Center=�$��20(����#2B78E4���� *)'Manager.BibliothèqueSélectionnée.Nom+� $��2��$
��10,0q�.+��� -   $��Ajouter les oeuvres��$��18, 1, 5, 0q�$��Right=�$��25��$	��135��$��
0, 2, 6, 6q�$��13(�
���   �$��2q�
��� � ��� -   #��[  $
��Left=�$��28��$��28��
���   �
��� � �.��  $ Trash=�� $	��Top=�$��0, 5, 0, 15q�$��Center=� �� $
��auto ��� $��1* �$	��120���� $��1* �$	��120���� $
��auto ��� $
��auto �.+�� $��	20,0,20,0q�.+��� -   $��Tout décocher��$��
16 1, 5, 0q�$��Right=�$��25��$	��105��$��
0, 2, 6, 6q�$��13(�
���   �$��2q�
��� ���
���   ��� -   #��[  $
��Left=�$��28��$��28��
���   �
��� ���
���   �.��  $ CircleOutline=��� -    ��Name$ ordreTri��$��Center=�$��Center=� �� SelectedIndex$ 0��$	��110��$��13(�$��0,0,20,0q�$��1��-  'MaterialDesignThemes.Wpf.ComboBoxAssist   ShowSelectedItem$
 True��.@��� .��	Croissant�� .��Décroissant�� .��Type�� .��Date de sortie�� -	   $ duType��$��Center=�$��Center=�$ 0��$��2��$	��110��$��13(�$��0,0,20,0q�$
 True��.@��� .��Tout�� .��Film�� .��Série�� .��Livre�� .��Animé�� .��Scan�� .��Autre� $��3��.+��� -
   $��Tout cocher��$��18, 1, 5, 0q�$��Right=�$��25��$��90��$��
0, 2, 6, 6q�$��13(�
���   �$��2q�
��� ���
���   ��� -   #��[  $
��Left=�$��28��$��28��
���   �
��� ���
���   �.��  $ TickCircleOutline=��� -    ��Name$ lItemsControl��$��20, 0, 10, 0q����� *Bibliothèque.LesOeuvres+���� .R���  ��Name$ leBoutonOeuvre��-     DefaultButtons#��[ $
��5, 2q�
�������$��3q�  CouleurDeFond#���  .��� .+��� $��0,0,25,0q�.+��� 	 ��Name$	 lImage��$��90��$��90������ *Image+  StringToImageConverter
 �� 	Converter#
 [ ��  ��Name$ leTextBlock��$ Center=�$��0,2,0,2q�  CouleurTexte#���  ���� *Nom+    Name$ lIcone��$ CircleOutline=�
�������$��Right=�$��Bottom=�$��24��$��24������ .R�� 