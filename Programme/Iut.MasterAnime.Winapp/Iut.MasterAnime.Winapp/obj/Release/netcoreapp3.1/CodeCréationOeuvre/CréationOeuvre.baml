   M S B A M L   `   `   `  ���� Q  MIut.MasterAnime.Winapp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullg8clr-namespace:Iut.MasterAnime.Winapp.CodeCréationOeuvre*Iut.MasterAnime.Winapp.CodeCréationOeuvre  W SIut.MasterAnime.ClassLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullqPclr-namespace:Iut.MasterAnime.ClassLibrary;assembly=Iut.MasterAnime.ClassLibraryIut.MasterAnime.ClassLibrary e7clr-namespace:Iut.MasterAnime.Winapp.CodePagePrincipale)Iut.MasterAnime.Winapp.CodePagePrincipale  @    :Iut.MasterAnime.Winapp.CodeCréationOeuvre.CréationOeuvre   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Jlocal8clr-namespace:Iut.MasterAnime.Winapp.CodeCréationOeuvre     iclassLibraryPclr-namespace:Iut.MasterAnime.ClassLibrary;assembly=Iut.MasterAnime.ClassLibrary     RpagePrincipale7clr-namespace:Iut.MasterAnime.Winapp.CodePagePrincipale     V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -     >�Name$  CréationDOeuvre�� � 	Resources  �� 
TargetType �� Property   CouleurTexte �� Value�� %+   '��       �� " ��.���  � ��# �   .��]� .+�C   =Iut.MasterAnime.Winapp.CodePagePrincipale.ListeBibliothèques  -     Name$ LaListeBibliothèque��$
��Left=��� $��Visible=�.���� .+��� $��Disabled=�.��� $��75�� � ColumnDefinitions �� $
��auto ��� $	��210���� $
��auto �.+�� $	��110��$��20,15,10,10q�.+��� -   $��Paramètres��$��16, 1, 5, 0q�$��Right=�$��25��$��85��$��
0, 2, 6, 6q�$��13(�
���   �$��2q��� -    & "MaterialDesignFloatingActionButton#��[ $
��Left=�$��28��$��28��
���   �.��'  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 Gear=��� $��1��$��30�� �� TextAlignment$ Center=�$��14(�$��0,10,0,0q�$	��200������ *
Oeuvre.Nom+	 �� ElementName$	 CréationDOeuvre��
 �� ValidatesOnDataErrors$

 True�� �� UpdateSourceTrigger$ PropertyChanged=�� $��2��$	��105��$��10,15,15,10q�.+��� -   $��	Supprimer��$��15, 1, 5, 0q�$��Right=�$��25��
���  ��$��85��$��
0, 2, 6, 6q�$��13(�
���   �$��2q��� -   #��[ $
��Left=�$��28��$��28��
���   �
���  ��.��  $ Trash=�� $��Center=�.+�� $��Center=�$y�Hidden=�.+��� $��Importer une image :�� �� TextAlignment$
 Left=�$��14(�$��	10,0,0,25q�$��Center=���  �� Orientation$ 
Horizontal=�$
��Left=�$��5,30,5,0q�$��Center=�.+��� $	��140��$��2,0,3,3q��� $��Explorer��  DefaultButtons#��[ $��3,0,3,2q�$��0,0,0,3q�$��2q�� .+��� $	��200��$	��150��$��Center=�$��15,5,0,0q����� *Oeuvre.Image+$	 CréationDOeuvre��  StringToImageConverter �� 	Converter# [ � $��Center=�$��10,0,0,0q�.+��� $��Importer une image :��$
 Left=����#2B78E4$��14(�$��	10,0,0,25q�$��Center=��� $ 
Horizontal=�$
��Left=�$��5,30,5,0q�$��Center=�.+��� $	��140��$��2,0,3,3q����� *Oeuvre.Image+$	 CréationDOeuvre���� -   $��Explorer��#��[ $��3,0,3,2q�$��0,0,0,3q�
�������
���   �
���   �$��2q��� $	��Top=����� *Oeuvre+$	 CréationDOeuvre��  �� DataType(  "Iut.MasterAnime.ClassLibrary.Autre ��Name �� SelectedIndex-  'MaterialDesignThemes.Wpf.ComboBoxAssist   ShowSelectedItem  CouleurDeFond  CouleurBordures(  "System.Windows.Controls.DatePicker   SelectedDate �� StringFormat'  !Iut.MasterAnime.ClassLibrary.Film)  #Iut.MasterAnime.ClassLibrary.Série(  "Iut.MasterAnime.ClassLibrary.Livre'	  !Iut.MasterAnime.ClassLibrary.Scan)
  #Iut.MasterAnime.ClassLibrary.Animé��%�  (��       *, +)(��     *, +)(�� �    *, +)(�� �
    *, +)(�� �    *,	 +)(�� �    *,
 +)�� "  .R�� $	��Top=�$��Center=�$��	0,10,55,0q�.+�� $��Center=�.+��� $ 
Horizontal=�.+��� $��Type : ��$��11(�$��5,5,5,15q�$��Center=�#���   �� $
 Type��-   $��Center=�$��Center=�$ 0��$��75��$��0,0,5,10q�$
 True��.@��� .��Autre�� .��Film�� .��Série�� .��Livre�� .��Scan�� .��Animé�� $ 
Horizontal=�$��5,5,5,15q�.+��� $��Créateur : ��$��11(�$��Center=�#���   �� $��11(�$	��100��$	��150��#���   ���� *	Créateur+$

 True��$ PropertyChanged=�� $��Center=�.+��� $ 
Horizontal=�$��5q�.+��� $��Date de sortie : ��$��11(�$��Center=�#���   �� #���  $��2q�#���  ._�  $��11(�$��Center=�#���   $	��3,0q� �� *Sortie+$ {0:dd/MM/yyyy}���� "  .R�� $	��Top=�$��Center=�$��	0,10,55,0q�.+�� $��Center=�.+��� $ 
Horizontal=�.+��� $��Type : ��$��11(�$��5,5,5,15q�$��Center=�#���   �� $
 Type��-	   $��Center=�$��Center=�$ 1��$��75��$��0,0,5,10q�$
 True��.@��� .��Autre�� .��Film�� .��Série�� .��Livre�� .��Scan�� .��Animé�� $ 
Horizontal=�$��5,5,5,15q�.+��� $��Réalisateur : ��$��11(�$��Center=�#���   �� $��11(�$	��100��$	��150��$��Center=�#���   ���� *Réalisateur+$

 True��$ PropertyChanged=�� $��Center=�.+��� $ 
Horizontal=�$��5,5,5,15q�.+��� $��Date de sortie : ��$��11(�$��Center=�#���   �� #���  $��2q�#���  ._�  $��11(�$��Center=�#���   $	��3,0q� �� *Sortie+$ {0:dd/MM/yyyy}���� $ 
Horizontal=�$��5,5,5,15q�.+��� $��	Studio : ��$��11(�$��Center=�#���   �� $��11(�$	��100��$	��150��$��Center=�#���   ���� *Studio+$

 True��$ PropertyChanged=��� "  .R�� $	��Top=�$��Center=�$��	0,10,55,0q�.+�� $��Center=�.+��� $ 
Horizontal=�.+��� $��Type : ��$��11(�$��5,5,5,15q�$��Center=�#���   �� $
 Type��-
   $��Center=�$��Center=�$ 2��$��75��$��0,0,5,10q�$
 True��.@��� .��Autre�� .��Film�� .��Série�� .��Livre�� .��Scan�� .��Animé�� $ 
Horizontal=�$��5,5,5,15q�.+��� $��Réalisateur : ��$��11(�$��Center=�#���   �� $��11(�$	��100��$	��150��$��Center=�#���   ���� *Réalisateur+$

 True��$ PropertyChanged=�� $��Center=�.+��� $ 
Horizontal=�$��5,5,5,15q�.+��� $��Date de sortie : ��$��11(�$��Center=�#���   �� #���  $��2q�#���  ._�  $��11(�$��Center=�#���   $	��3,0q� �� *Sortie+$ {0:dd/MM/yyyy}���� $ 
Horizontal=�$��5,5,5,15q�.+��� $��	Studio : ��$��11(�$��Center=�#���   �� $��11(�$	��100��$	��150��$��Center=�#���   ���� *Studio+$

 True��$ PropertyChanged=��� "  .R�� $	��Top=�$��Center=�$��	0,10,55,0q�.+�� $��Center=�.+��� $ 
Horizontal=�.+��� $��Type : ��$��11(�$��5,5,5,15q�$��Center=�#���   �� $
 Type��-   $��Center=�$��Center=�$ 3��$��75��$��0,0,5,10q�$
 True��.@��� .��Autre�� .��Film�� .��Série�� .��Livre�� .��Scan�� .��Animé�� $ 
Horizontal=�$��5,5,5,15q�.+��� $��	Auteur : ��$��11(�$��Center=�#���   �� $��11(�$	��100��$	��150��$��Center=�#���   ���� *Auteur+$

 True��$ PropertyChanged=�� $��Center=�.+��� $ 
Horizontal=�$��5,5,5,15q�.+��� $��Date de sortie : ��$��11(�$��Center=�#���   �� #���  $��2q�#���  ._�  $��11(�$��Center=�#���   $	��3,0q� �� *Sortie+$ {0:dd/MM/yyyy}���� $ 
Horizontal=�$��5,5,5,15q�.+��� $��Éditeur : ��$��11(�$��Center=�#���   �� $��11(�$	��100��$	��150��$��Center=�#���   ���� *
Éditeur+$

 True��$ PropertyChanged=��� " 	 .R�� $	��Top=�$��Center=�$��	0,10,55,0q�.+�� $��Center=�.+��� $ 
Horizontal=�.+��� $��Type : ��$��11(�$��5,5,5,15q�$��Center=�#���   �� $
 Type��-   $��Center=�$��Center=�$ 4��$��75��$��0,0,5,10q�$
 True��.@��� .��Autre�� .��Film�� .��Série�� .��Livre�� .��Scan�� .��Animé�� $ 
Horizontal=�$��5,5,5,15q�.+��� $��	Auteur : ��$��11(�$��Center=�#���   �� $��11(�$	��100��$	��150��$��Center=�#���   ���� *Auteur+$

 True��$ PropertyChanged=�� $��Center=�.+��� $ 
Horizontal=�$��5,5,5,15q�.+��� $��Date de sortie : ��$��11(�$��Center=�#���   �� #���  $��2q�#���  ._�  $��11(�$��Center=�#���   $	��3,0q� �� *Sortie+$ {0:dd/MM/yyyy}���� $ 
Horizontal=�$��5,5,5,15q�.+��� $��Éditeur : ��$��11(�$��Center=�#���   �� $��11(�$	��100��$	��150��$��Center=�#���   ���� *
Éditeur+$

 True��$ PropertyChanged=��� " 
 .R�� $	��Top=�$��Center=�$��	0,10,55,0q�.+�� $��Center=�.+��� $ 
Horizontal=�.+��� $��Type : ��$��11(�$��5,5,5,15q�$��Center=�#���   �� $
 Type��-   $��Center=�$��Center=�$ 5��$��75��$��0,0,5,10q�$
 True��.@��� .��Autre�� .��Film�� .��Série�� .��Livre�� .��Scan�� .��Animé�� $ 
Horizontal=�$��5,5,5,15q�.+��� $��	Auteur : ��$��11(�$��Center=��� $��11(�$	��100��$	��150��$��Center=����� *Auteur+$

 True��$ PropertyChanged=�� $��Center=�.+��� $ 
Horizontal=�$��5,5,5,15q�.+��� $��Date de sortie : ��$��11(�$��Center=��� #���  $��2q�#���  ._�  $��11(�$��Center=�#���   $	��3,0q� �� *Sortie+$ {0:dd/MM/yyyy}���� $ 
Horizontal=�$��5,5,5,15q�.+��� $��	Studio : ��$��11(�$��Center=��� $��11(�$	��100��$	��150��$��Center=����� *Studio+$

 True��$ PropertyChanged=��� $��10,0,0,0q�$��Center=����� *%#Oeuvre.InformationsComplémentaires+$	 CréationDOeuvre������ .R��� $ 
Horizontal=�$��Center=�$��Center=�$��
10,10,10,0q�.+��� $��3,0,3,0q�$	��100��$	��150��$��11(����� *Key.LeString+$

 True��$ PropertyChanged=��� $	�� : ��$��Center=� �� Padding$ 0,0,0,1q�$��11(��� $��3,0,3,0q�$	��100��$	��150��$��11(����� *Value.LeString+$

 True��$ PropertyChanged=����� .R�� � $��0,3,0,0q�.+��� $��Synopsis��$��
33,15,10,4q�$��14(�$
��Left=�$��Bottom=�� $	��170��$��	10,5,10,0q�$��Right=�$	��Top=�.+��� -   $��Ajouter des informations��$��10, 1, 5, 0q�$��Right=�$��25��$	��145��$��
0, 2, 6, 6q�$��11(�
���   �$��2q��� -   #��[ $
��Left=�$��26��$��26��
���   �.��  $ 	PlusThick=��� 
 � Tag$ Synopsis��$��50��$
��auto��$��3,1,3,2q�$��	25,0,20,0q�$��12(� �� TextWrapping$
 Wrap=�  PlaceHolderOeuvre#��[ $��Stretch=����� *Oeuvre.Synopsis+$	 CréationDOeuvre���� $��14,5,5,0q�.+��� $��Commentaire��$��15,0,0,4q�$��14(��� $ Commentaire personnel��$
��auto��$��40��$��3,1,3,2q�$��	11,0,15,0q�$��12(�$
 Wrap=�#��[ $��Stretch=����� *Oeuvre.Commentaire+$	 CréationDOeuvre��� $��Center=�.+��� -   $ AjoutABibliothèques��$��Center=�$	��140��$��10q�$��28��$��8,5,0,0q�$��1��$
 True��)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Ajouter à������ *Manager.LesBibliothèques+$	 CréationDOeuvre������ .R���  ��Name$ leStackCombobox��$ 
Horizontal=�.+�    Name$ lIcon��  
LePackIcon# �  ���#2B78E4��  ��Name$ leTextBlock��$��6,0,0,0q����� *Nom+� $��2��$	��120��$��30,10,15,10q�$
��Left=�.+��� -   $��Sauvegarder��$��18, 1, 5, 0q�$��Right=�$��25��
��� � �$��95��$��
0, 2, 6, 6q�$��13(�
���   �$��2q��� -   #��[ $
��Left=�$��28��$��28��
���   �
��� � �.��  $ ContentSave=�