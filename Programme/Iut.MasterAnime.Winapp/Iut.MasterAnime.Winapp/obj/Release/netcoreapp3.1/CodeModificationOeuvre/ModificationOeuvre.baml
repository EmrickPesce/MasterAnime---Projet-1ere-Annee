   M S B A M L   `   `   `  ���� Q  MIut.MasterAnime.Winapp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullm;clr-namespace:Iut.MasterAnime.Winapp.CodeModificationOeuvre-Iut.MasterAnime.Winapp.CodeModificationOeuvre  e7clr-namespace:Iut.MasterAnime.Winapp.CodePagePrincipale)Iut.MasterAnime.Winapp.CodePagePrincipale  W SIut.MasterAnime.ClassLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullqPclr-namespace:Iut.MasterAnime.ClassLibrary;assembly=Iut.MasterAnime.ClassLibraryIut.MasterAnime.ClassLibrary F    @Iut.MasterAnime.Winapp.CodeModificationOeuvre.ModificationOeuvre   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Mlocal;clr-namespace:Iut.MasterAnime.Winapp.CodeModificationOeuvre     RpagePrincipale7clr-namespace:Iut.MasterAnime.Winapp.CodePagePrincipale     iclassLibraryPclr-namespace:Iut.MasterAnime.ClassLibrary;assembly=Iut.MasterAnime.ClassLibrary     V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -     >�Name$  ModificationDOeuvre��.��]� .+�C   =Iut.MasterAnime.Winapp.CodePagePrincipale.ListeBibliothèques  -     Name$ LaListeBibliothèque��$
��Left=��� $��Visible=�.���� $��Stretch=�.+��� $
��Auto=�$��Disabled=�.��� $��75�� � ColumnDefinitions �� $
��auto ��� $	��210���� $
��auto �.+�� $	��110��$��
20,15,5,10q�.+��� -   $��Paramètres��$��
9, 1, 0, 0q�$��Right=�$��25��$��88��$��
0, 2, 6, 6q�$��13(�
���   �$��2q��� -    &  "MaterialDesignFloatingActionButton#��[  $
��Left=�$��28��$��28��
���   �.��'  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 Gear=��� $��1��$��30�� �� TextAlignment$ Center=�$��14(�$��5,10,5,0q�$	��200�����#2B78E4���� *
Oeuvre.Nom+ �� ValidatesOnDataErrors$
 True�� �� UpdateSourceTrigger$ PropertyChanged=� �� ElementName$ ModificationDOeuvre��� $��
5,15,15,10q�$��Center=�$��2��.+��� -   $��Annuler��$��15, 1, 0, 0q�$��Right=�$��25�����#A64D79$��70��$��
0, 2, 6, 6q�$��13(�
���   �$��2q��� -   #��[  $
��Left=�$��28��$��28��
���   ����#A64D79.��  $ 
CloseThick=�� $��Center=�.+�� $��Center=�$y�Hidden=�.+��� $��Importer une image :�� �� TextAlignment$
 Left=�$��14(�$��	10,0,0,25q�$��Center=��� 	 �� Orientation$	 
Horizontal=�$
��Left=�$��5,30,5,0q�$��Center=�.+��� $	��140��$��2,0,3,3q��� $��Explorer��  DefaultButtons#��[ $��3,0,3,2q�$��0,0,0,3q�$��2q�� .+��� $	��200��$	��150��$��Center=�$��15,5,0,0q����� *Oeuvre.Image+  StringToImageConverter
 �� 	Converter#
 [ $ ModificationDOeuvre��� $��Center=�$��10,0,0,0q�.+��� $��Importer une image :��$
 Left=����#2B78E4$��14(�$��	10,0,0,25q�$��Center=��� $	 
Horizontal=�$
��Left=�$��5,30,5,0q�$��Center=�.+��� $	��140��$��2,0,3,3q����� *Oeuvre.Image+$ ModificationDOeuvre���� -   $��Explorer��#��[ $��3,0,3,2q�$��0,0,0,3q�
�������
���   �
���   �$��2q��� $	��Top=����� *Oeuvre+$ ModificationDOeuvre�� � 	Resources  �� DataType(  "Iut.MasterAnime.ClassLibrary.Autre  CouleurTexte  CouleurDeFond  CouleurBordures(  "System.Windows.Controls.DatePicker   SelectedDate �� StringFormat'  !Iut.MasterAnime.ClassLibrary.Film)  #Iut.MasterAnime.ClassLibrary.Série(  "Iut.MasterAnime.ClassLibrary.Livre'  !Iut.MasterAnime.ClassLibrary.Scan)	  #Iut.MasterAnime.ClassLibrary.Animé��%  (��       *, +)(��     *, +)(�� �    *, +)(�� o	    *, +)(�� �    *, +)(�� N    *,	 +)�� "  .R�� $	��Top=�$��Center=�$��	0,10,55,0q�.+�� $��Center=�.+��� $��Type : Autre��$��11(�$��5,5,5,15q�$��Center=�#���  �� $	 
Horizontal=�$��5,5,5,15q�.+��� $��Créateur : ��$��11(�$��Center=�#���  �� $��11(�$	��100��$	��150��#���  ���� *Oeuvre.Créateur+$
 True��$ PropertyChanged=�$ ModificationDOeuvre��� $��Center=�.+��� $	 
Horizontal=�$��5,5,5,15q�.+��� $��Date de sortie : ��$��11(�$��Center=�#���  �� #���  $��2q�#���  ._�  $��11(�$��Center=�#���  $	��3,0q� �� *Oeuvre.Sortie+$ {0:dd/MM/yyyy}��$ ModificationDOeuvre���� "  .R�� $	��Top=�$��Center=�$��	0,10,55,0q�.+�� $��Center=�.+��� $��Type : Film��$��11(�$��5,5,5,15q�$��Center=�#���  �� $	 
Horizontal=�$��5,5,5,15q�.+��� $��Réalisateur : ��$��11(�$��Center=�#���  �� $��11(�$	��100��$	��150��$��Center=�#���  ���� *Oeuvre.Réalisateur+$
 True��$ PropertyChanged=�$ ModificationDOeuvre��� $��Center=�.+��� $	 
Horizontal=�$��5,5,5,15q�.+��� $��Date de sortie : ��$��11(�$��Center=�#���  �� #���  $��2q�#���  ._�  $��11(�$��Center=�#���  $	��3,0q� �� *SOeuvre.ortie+$ {0:dd/MM/yyyy}��$ ModificationDOeuvre���� $	 
Horizontal=�$��5,5,5,15q�.+��� $��	Studio : ��$��11(�$��Center=�#���  �� $��11(�$	��100��$	��150��$��Center=�#���  ���� *Oeuvre.Studio+$
 True��$ PropertyChanged=�$ ModificationDOeuvre���� "  .R�� $	��Top=�$��Center=�$��	0,10,55,0q�.+�� $��Center=�.+��� $��Type : Série��$��11(�$��5,5,5,15q�$��Center=�#���  �� $	 
Horizontal=�$��5,5,5,15q�.+��� $��Réalisateur : ��$��11(�$��Center=�#���  �� $��11(�$	��100��$	��150��$��Center=�#���  ���� *Oeuvre.Réalisateur+$
 True��$ PropertyChanged=�$ ModificationDOeuvre��� $��Center=�.+��� $	 
Horizontal=�$��5,5,5,15q�.+��� $��Date de sortie : ��$��11(�$��Center=�#���  �� #���  $��2q�#���  ._�  $��11(�$��Center=�#���  $	��3,0q� �� *Oeuvre.Sortie+$ {0:dd/MM/yyyy}��$ ModificationDOeuvre���� $	 
Horizontal=�$��5,5,5,15q�.+��� $��	Studio : ��$��11(�$��Center=�#���  �� $��11(�$	��100��$	��150��$��Center=�#���  ���� *Oeuvre.Studio+$
 True��$ PropertyChanged=�$ ModificationDOeuvre���� "  .R�� $	��Top=�$��Center=�$��	0,10,55,0q�.+�� $��Center=�.+��� $��Type : Livre��$��11(�$��5,5,5,15q�$��Center=�#���  �� $	 
Horizontal=�$��5,5,5,15q�.+��� $��	Auteur : ��$��11(�$��Center=�#���  �� $��11(�$	��100��$	��150��$��Center=�#���  ���� *Oeuvre.Auteur+$
 True��$ PropertyChanged=�$ ModificationDOeuvre��� $��Center=�.+��� $	 
Horizontal=�$��5,5,5,15q�.+��� $��Date de sortie : ��$��11(�$��Center=�#���  �� #���  $��2q�#���  ._�  $��11(�$��Center=�#���  $	��3,0q� �� *Oeuvre.Sortie+$ {0:dd/MM/yyyy}��$ ModificationDOeuvre���� $	 
Horizontal=�$��5,5,5,15q�.+��� $��Éditeur : ��$��11(�$��Center=�#���  �� $��11(�$	��100��$	��150��$��Center=�#���  ���� *Oeuvre.Éditeur+$
 True��$ PropertyChanged=�$ ModificationDOeuvre���� "  .R�� $	��Top=�$��Center=�$��	0,10,55,0q�.+�� $��Center=�.+��� $��Type : Scan��$��11(�$��5,5,5,15q�$��Center=�#���  �� $	 
Horizontal=�$��5,5,5,15q�.+��� $��	Auteur : ��$��11(�$��Center=�#���  �� $��11(�$	��100��$	��150��$��Center=�#���  ���� *Oeuvre.Auteur+$
 True��$ PropertyChanged=�$ ModificationDOeuvre��� $��Center=�.+��� $	 
Horizontal=�$��5,5,5,15q�.+��� $��Date de sortie : ��$��11(�$��Center=�#���  �� #���  $��2q�#���  ._�  $��11(�$��Center=�#���  $	��3,0q� �� *Oeuvre.Sortie+$ {0:dd/MM/yyyy}��$ ModificationDOeuvre���� $	 
Horizontal=�$��5,5,5,15q�.+��� $��Éditeur : ��$��11(�$��Center=�#���  �� $��11(�$	��100��$	��150��$��Center=�#���  ���� *Oeuvre.Éditeur+$
 True��$ PropertyChanged=�$ ModificationDOeuvre���� " 	 .R�� $	��Top=�$��Center=�$��	0,10,55,0q�.+�� $��Center=�.+��� $��Type : Animé��$��11(�$��5,5,5,15q�$��Center=�#���  �� $	 
Horizontal=�$��5,5,5,15q�.+��� $��	Auteur : ��$��11(�$��Center=�#���  �� $��11(�$	��100��$	��150��$��Center=�#���  ���� *Oeuvre.Auteur+$
 True��$ PropertyChanged=�$ ModificationDOeuvre��� $��Center=�.+��� $	 
Horizontal=�$��5,5,5,15q�.+��� $��Date de sortie : ��$��11(�$��Center=�#���  �� #���  $��2q�#���  ._�  $��11(�$��Center=�#���  $	��3,0q� �� *Oeuvre.Sortie+$ {0:dd/MM/yyyy}��$ ModificationDOeuvre���� $	 
Horizontal=�$��5,5,5,15q�.+��� $��	Studio : ��$��11(�$��Center=�#���  �� $��11(�$	��100��$	��150��$��Center=�#���  ���� *Oeuvre.Studio+$
 True��$ PropertyChanged=�$ ModificationDOeuvre���� $��10,0,0,0q�$��Center=����� *%#Oeuvre.InformationsComplémentaires+$ ModificationDOeuvre������ .R��� $	 
Horizontal=�$��Center=�$��Center=�$��
10,10,10,0q�.+��� $��3,0,3,0q�$	��100��$	��150��$��11(�#���  ���� *Key.LeString+ �� Mode$ TwoWay=�$
 True��$ PropertyChanged=��� $	�� : ��$��Center=� �� Padding$ 0,0,0,1q�$��11(�#���  �� $��3,0,3,0q�$	��100��$	��150��$��11(�#���  ���� *Value.LeString+$ TwoWay=�$
 True��$ PropertyChanged=����� .R�� � $��0,3,0,0q�.+��� $��Synopsis��$��
33,15,10,4q�$��14(�$
��Left=�$��Bottom=�  CouleurTexteGros#���  � $	��170��$��	10,5,10,0q�$��Right=�$	��Top=�.+��� -   $��Ajouter des informations��$��10, 1, 5, 0q�$��Right=�$��25��$	��145��$��
0, 2, 6, 6q�$��11(�
���   �$��2q��� -	   #��[  $
��Left=�$��26��$��26��
���   �.��  $ 	PlusThick=��� $��50��$
��auto��$��3,1,3,2q�$��	25,0,20,0q�$��12(� �� TextWrapping$
 Wrap=�$��Stretch=����� *Oeuvre.Synopsis+$ ModificationDOeuvre���� $��14,5,5,0q�.+��� $��Commentaire��$��15,0,0,4q�$��14(�#���  �� $
��auto��$��40��$��3,1,3,2q�$��	11,0,15,0q�$��12(�$
 Wrap=�$��Stretch=����� *Oeuvre.Commentaire+$ ModificationDOeuvre��� $��Center=�.+�� $��2��$	��105��$��15,10,15,10q�.+��� -
   $��	Supprimer��$��18, 1, 0, 0q�$��Right=�$��25��
���  ��$��85��$��
0, 2, 6, 6q�$��13(�
���   �$��2q��� -   #��[  $
��Left=�$��28��$��28��
���   �
���  ��.��  $ Trash=�� .+��� -    ��Name$ AjoutABibliothèques��$��Center=�$	��140��$��10q�$��28��$��8,5,0,0q�$��1��-
  'MaterialDesignThemes.Wpf.ComboBoxAssist 
  ShowSelectedItem$
 True��)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Ajouter à������ *Manager.LesBibliothèques+$ ModificationDOeuvre������ .R���  ��Name$ leStackCombobox��$	 
Horizontal=�.+�    Name$ lIcon��  
LePackIcon# �  ���#2B78E4��  ��Name$ leTextBlock��$��6,0,0,0q����� *Nom+� $��2��$	��120��$��10,10,15,10q�$��Center=�.+��� -   $��Sauvegarder��$��18, 1, 5, 0q�$��Right=�$��25��
��� � �$��95��$��
0, 2, 6, 6q�$��13(�
���   �$��2q��� -   #��[  $
��Left=�$��28��$��28��
���   �
��� � �.��  $ ContentSave=�