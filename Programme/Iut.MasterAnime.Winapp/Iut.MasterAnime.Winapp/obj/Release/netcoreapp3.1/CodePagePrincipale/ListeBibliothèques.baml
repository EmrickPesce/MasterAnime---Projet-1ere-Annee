   M S B A M L   `   `   `  ���� Q  MIut.MasterAnime.Winapp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulle7clr-namespace:Iut.MasterAnime.Winapp.CodePagePrincipale)Iut.MasterAnime.Winapp.CodePagePrincipale  C    =Iut.MasterAnime.Winapp.CodePagePrincipale.ListeBibliothèques   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Ilocal7clr-namespace:Iut.MasterAnime.Winapp.CodePagePrincipale     V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -     >�Name$  ListeBibliothèque��.��� $��
8, 8, 0, 8q�$	��130�� � RowDefinitions �� $
��auto ��� �� $
��auto �.+��� -   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Search��$��0,5,0,10q�   HintOpacity$	 .26Q�$	��110�� �� 
IsEditable$
 True�� �� SelectedItem �� *%#Manager.BibliothèqueSélectionnée+ �� ElementName$ ListeBibliothèque������ *Manager.VuDesBibliothèques+$ ListeBibliothèque������ .R��� ���� *Nom+�� -    ��Name$ LesBibliothèques��$��1��$
��auto��$��0, 0, 0, 10q�
���   �$��1q�$��Center=� �� *%#Manager.BibliothèqueSélectionnée+$ ListeBibliothèque������ *Manager.VuDesBibliothèques+$ ListeBibliothèque������ .R��  �� �� $
��auto �.+��� $��75��$��75������ *Image+   StringToImageConverter �� 	Converter# [  �� $��1��	 �� TextAlignment$	 Center=�  CouleurTexte#���  ���� *Nom+� $��2��$��10,0,0,3q�$	��115��.+��� -   $��Nouvelle liste��$��
0, 1, 0, 0q�$��Right=�$��11(�$��25��$��95��$��0,0,6,2q�
���   �$��2q��� -    & "MaterialDesignFloatingActionButton#��[ $
��Left=�$��28��$��28��
���   �.��'  !MaterialDesignThemes.Wpf.PackIcon  
   Kind$
 	PlusThick=�