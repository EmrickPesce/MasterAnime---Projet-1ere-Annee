   M S B A M L   `   `   `  ����Q  MIut.MasterAnime.Winapp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulle7clr-namespace:Iut.MasterAnime.Winapp.CodePagePrincipale)Iut.MasterAnime.Winapp.CodePagePrincipale  5      C    =Iut.MasterAnime.Winapp.CodePagePrincipale.ListeBibliothèques   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Ilocal7clr-namespace:Iut.MasterAnime.Winapp.CodePagePrincipale     5      V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5          >�Name$  ListeBibliothèque��5      .��5      � $��
8, 8, 0, 8q�6   $	��130��6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      �� 5      $
��auto �6   .+�5   
   �� )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Search��6   $��0,5,0,10q�6;      HintOpacity$	 .26Q�5      $	��110��6?    �� 
IsEditable$
 True��5       �� SelectedItem 5      �� *%#Manager.BibliothèqueSélectionnée+ �� ElementName$ ListeBibliothèque����5   %   �� *Manager.VuDesBibliothèques+$ ListeBibliothèque����5      �� 5      .R�5      �� ��6    �� *Nom+5      5      �� 5   
   -   5         ��Name$ LesBibliothèques��5       $��1��5      $
��auto��6   $��0, 0, 0, 10q�6-   
���   �$��1q�6V   $��Center=�5    ~    5      �� *%#Manager.BibliothèqueSélectionnée+$ ListeBibliothèque����5    ,   �� *Manager.VuDesBibliothèques+$ ListeBibliothèque����5!      �� 5"      .R�5#      �  5$      �� 5%      �� 5&      $
��auto �6,   .+�5(      �� $��75��6    $��75��6/   ��6=   �� *Image+   StringToImageConverter �� 	Converter# [  �� 5)      $��1��6$   	 �� TextAlignment$	 Center=�61     CouleurTexte#���  6]   ��6H   �� *Nom+6]   5*      5+      5-      � 5/   
   $��2��6   $��10,0,0,3q�6   $	��115��6.   .+�50      �� -   5        $��Nouvelle liste��50      $��
0, 1, 0, 0q�6.   $��Right=�6B   $��11(�6e   $��25��51      $��95��6!   $��0,0,6,2q�6,   
���   �$��2q�6R   6f   �� 52      -   5         & "MaterialDesignFloatingActionButton#��[ 52      $
��Left=�6Q   $��28��53      $��28��6!   
���   �.��54      '  !MaterialDesignThemes.Wpf.PackIcon  
   Kind$
 	PlusThick=�6*   55      56      57      58      