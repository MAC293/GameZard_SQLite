   M S B A M L   `   `   `  ����=  9UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:UIUI  5   	   U QSystem.Runtime, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a7,clr-namespace:System;assembly=System.RuntimeSystem 5
          UI.PC   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   "localclr-namespace:UI     5   	   S OHandyControl, Version=3.2.0.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  5   	   9System,clr-namespace:System;assembly=System.Runtime  5
      $	��812��5	   	   $
��1079��6     � SizeToContent$  Manual=�6#    � WindowState$ Normal=�6:    � WindowStartupLocation$ CenterScreen=�6O    � 
ResizeMode$ NoResize=�6t    � ShowInTaskbar$ False��6�    � 	Resources 5         
BackUpMode��%,   &	        ��5   
   
BackUpMode��67   5      .��5      � $��0,0,0,-6q�6    � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $	��280 �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6%   
��� ���.+�5      � .+�5      �� -   5         ��Name$ label��5      $��PC��6'   $��0,10,0,0q�64   
������ $	��Top=�6_   �� 5      -   5        	 ��Name$	 btnSelector��5      $��0q�6.   $
��Left=�6B   $��	10,10,0,0q�6]   $��Stretch=�6p   $��32��6�   ��5       �� 5!      
 �� ImageSource$
 /GameZard.ico��6%   5#      5$      5%      �� 5+   
   $��0��6   $��1��6%   
����ح�.+�5,      � $	��244��6   .+�5-      #  HandyControl.Controls.TextBox  -   5          Name$ txtAddRemoveGame��5-       �� TextWrapping$
 Wrap=�67   $��30��6K   $��
10,10,46,0q�6W   $	��Top=�6k   �� 5.      -   5        $��
btnAddGame��5.      $
��Left=�6+   $��
234,10,0,0q�6F   $	��Top=�6Z   $��0q�6r   $��29��6�   ��5/      �� 50      $
 /Add Game.png��6%   52      �� 53      -   5        $��btnRemoveGame��53      $
��Left=�6.   $��
252,10,0,0q�6I   $	��Top=�6]   $��0q�6u   $��28��6�   ��54      �� 55      $
 /Delete Game.png��6%   57      �� 58      -   5         ��Name$ lbGames��58      $	��199��6+   $��
10,45,46,0q�68   $	��Top=�6L   6d   59      5;      �� 5A   
   $��1��6   $��0��6%   
��� ���.+�5B      � .+�5C      �� -   5        $	 btnRemoveData��5C      $��- Delete Savedata��60   $
��Left=�6L   $��	10,10,0,0q�6g   $	��Top=�6z   5D      5E      � 5N   
   $��1��6   $��1��6   
���  ��.+�5O      �� -   5         ��Name$ imgGameCover��5O      $
��Fill=�6*   $��/Default Image.png��69   $��20,20,547,376q�6U   $	��356��6l   �� 5P      -	   5        $	 btnChangeCover��5P      $
��Left=�6-   $��	32,26,0,0q�6H   $	��Top=�6[   $��0q�6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   $��24��6�   $��30��6�   z�5Q      V� 5R      .~�5S      ��  �� ScaleX$ -1Q�6)   �� 5T      �� 5U      T� 5V      5W      ��5Z      �� 5[      $
 	/Edit.ico��6!   5]      �� 5^      -
   5        $ lblGameName��5^      $��Label��6)   $��0q�69   
������ $
��Left=�6f   $��
293,26,0,0q�6�   $	��Top=�6�   $��15(�6�   �� 5_      -   5        $ label1_Copy��5_      $��Back-Up��6)   $��0q�6;   
������ $
��Left=�6h   $��
293,70,0,0q�6�   $	��Top=�6�   $��15(�6�   	� 5a      -   5         	�Name$ 
rbManually��5a      $��Manually��6.   $
��Left=�6A   $��
390,77,0,0q�6\   $	��Top=�6p   6�   	� 5c      -   5        $ rbAutomatically��5c      $��Automatically��63   $
��Left=�6K   $��
498,78,0,0q�6f   $	��Top=�6z   6�   �� 5d      -   5        $ label1_Copy1��5d      $
��From��6*   $��0q�69   
������ $
��Left=�6f   $��293,118,0,0q�6�   $	��Top=�6�   $��15(�6�   �� 5e      -   5         ��Name$ txtFrom��5e      $��301,150,110,523q�6'   $
 Wrap=�6@   �� 5f      -   5        $	 btnFromPath��5f      $��Browse Path��6*   $
��Left=�6@   $��694,150,0,0q�6[   $	��Top=�6p   $��40��6�   6�   �� 5g      -   5        $ label1_Copy2��5g      $��To��6*   $��0q�67   
������ $
��Left=�6d   $��293,229,0,0q�6   $	��Top=�6�   $��15(�6�   �� 5h      -   5        $ txtTo��5h      $��301,261,110,411q�6%   $
 Wrap=�6>   �� 5i      -   5        $	 	btnToPath��5i      $��Browse Path��6(   $
��Left=�6>   $��694,261,0,0q�6Y   $	��Top=�6n   $��41��6�   6�   �� 5j      -   5        $ label1_Copy3��5j      $��Last Saved:��6*   $��0q�6@   
������ $
��Left=�6m   $��303,354,0,0q�6�   $	��Top=�6�   $��15(�6�   �� 5k      -   5        $ lblSavedDate��5k      $��
Saved Date��6*   $��0q�6?   
������ $
��Left=�6l   $��390,354,0,0q�6�   $	��Top=�6�   $��15(�6�   5m      5v      5w      