   M S B A M L   `   `   `  ����=  9UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:UIUI  5   	       UI.Emulator   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   "localclr-namespace:UI     5   	   S OHandyControl, Version=3.2.0.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  5   	   M IFontAwesome.Sharp, Version=5.15.3.0, Culture=neutral, PublicKeyToken=nullFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5   	   $	��525��5
   	   $	��857��6     � SizeToContent$  Manual=�6"    � WindowState$ Normal=�69    � WindowStartupLocation$ CenterScreen=�6N    � 
ResizeMode$ NoResize=�6s   .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $	��210 �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6%   
��� ���.+�5      � .+�5      �� -   5         ��Name$ label��5      $��Emulator��6'   $��0,10,0,0q�6:   
������ $	��Top=�6e   �� 5      -   5         ��Name$ btnSelector��5      $��0q�6.   $
��Left=�6B   $��	10,10,0,0q�6]   $	��Top=�6p   $��32��6�   ��5      �� 5       �� ImageSource$ /GameZard.ico��6%   5      5       5"      �� 5(   
   $��0��6   $��1��6%   
����ح�.+�5)      � .+�5*      !  FontAwesome.Sharp.IconImage  -   5        	  Name$	 	iconImage��5*      $��30��62   $��30��6>   $��	/Cemu.ico��6I   $��10,10,170,315q�6\     5+      -   5        $	 
iconImage1��5+      $��30��63   $��30��6?   $��/PPSSPP.ico��6J   
 J� RenderTransformOrigin$
 -0.29,0.931&�6_   $��10,45,170,280q�6�     5,      -   5        $	 
iconImage2��5,      $��30��63   $��30��6?   $��13,80,167,245q�6K   $��
/PCSX2.ico��6b     5-      -   5        $	 
iconImage3��5-      $��30��63   $��30��6?   $��13,110,167,215q�6J   $��
/ePSXe.ico��6b     5.      -   5        $	 
iconImage4��5.      $��30��63   $��30��6?   $��13,145,167,180q�6J   $��/Dolphin.ico��6b     5/      -   5        $	 
iconImage5��5/      $��30��63   $��30��6?   $��13,180,167,145q�6J   $��/Dolphin.ico��6b     50      -	   5        $	 
iconImage6��50      $��30��63   $��30��6?   $��13,215,167,110q�6J   $��
/Citra.ico��6b     51      -
   5        $	 
iconImage7��51      $��30��63   $��30��6?   $��13,250,167,75q�6J   $��/VisualBoyAdvance.ico��6a     52      -   5        $	 
iconImage8��52      $��30��63   $��30��6?   $��13,285,167,40q�6J   $��/SNES9x.ico��6a     53      -   5        $	 
iconImage9��53      $��30��63   $��30��6?   $��13,320,167,5q�6J   $��	/YUZU.ico��6`   �� 54      -   5        $ btnWiiU��54      $
��Cemu��6*   $
��Left=�69   $��	48,10,0,0q�6T   $	��Top=�6g   6�   �� 55      -   5        $ btnPSP��55      $��PPSSPP��6)   $
��Left=�6:   $��	48,45,0,0q�6U   $	��Top=�6h   6�   �� 56      -   5        $ btnPS2��56      $��PCSX2��6)   $
��Left=�69   $��	47,80,0,0q�6T   $	��Top=�6g   6�   �� 57      -   5        $ btnPSX��57      $��ePSXe��6)   $
��Left=�69   $��
47,115,0,0q�6T   $	��Top=�6h   6�   �� 58      -   5        $ btnWii��58      $��Dolphin (Wii)��6)   $
��Left=�6A   $��
47,150,0,0q�6\   $	��Top=�6p   6�   �� 5:      -   5        $ btnGameCube��5:      $��Dolphin (GameCube)��6.   $
��Left=�6K   $��
48,185,0,0q�6f   $	��Top=�6z   6�   �� 5;      -   5        $ btn3DS��5;      $��Citra��6)   $
��Left=�69   $��
48,220,0,0q�6T   $	��Top=�6h   6�   �� 5<      -   5        $ btnGBA��5<      $��Visual Boy Advance��6)   $
��Left=�6F   $��
48,255,0,0q�6a   $	��Top=�6u   6�   �� 5=      -   5        $ btnSNES��5=      $��SNES9x��6*   $
��Left=�6;   $��48,290,0,35q�6V   $��Stretch=�6k   6�   �� 5>      -   5        $ 	btnSwitch��5>      $
��YUZU��6,   $
��Left=�6;   $��
48,325,0,0q�6V   $	��Top=�6j   6�   5?      5@      �� 5E   
   
���  ��$��1��6&   $��0��66   5G      �� 5L   
   $��1��6   $��1��6%   
�������.+�5M      � .+�5O      �� -   5         ��Name$ imgEmulator��5O      $	��100��6-   $��15,19,515,292q�6:   �� 5P      -   5        $ lblEmulator��5P      $��0q�6-   
������ $
��Left=�6Z   $��
149,53,0,0q�6u   $	��Top=�6�   $��15(�6�   �� 5Q      -   5        $ label2��5Q      $��0q�6(   
������ $��Back-Up��6U   $
��Left=�6g   $��
35,139,0,0q�6�   $	��Top=�6�   	� 5R      -   5         	�Name$ 
rbManually��5R      $��Manually��62   $
��Left=�6E   $��132,145,0,0q�6`   $	��Top=�6u   6�   	� 5S      -   5        $ rbAutomatically��5S      $��Automatically��67   $
��Left=�6O   $��257,145,0,0q�6j   $	��Top=�6   6�   �� 5T      -   5        $ label3��5T      $��0q�6(   
������ $
��From��6U   $
��Left=�6d   $��
35,211,0,0q�6   $	��Top=�6�   �� 5U      -   5         ��Name$ txtFrom��5U       �� TextWrapping$
 Wrap=�6+   $��30��6?   $��35,246,396,0q�6K   $	��Top=�6a   �� 5V      -   5        $ btnFromPath��5V      $��Browse Path��6.   $
��Left=�6D   $��266,247,0,0q�6_   $	��Top=�6t   6�   �� 5W      -   5        $ label3_Copy��5W      $��0q�6-   
������ $��To��6Z   $
��Left=�6g   $��
35,293,0,0q�6�   $	��Top=�6�   �� 5X      -    5        $ txtTo��5X      $
 Wrap=�6)   $��30��6=   $��35,328,396,0q�6I   $	��Top=�6_   �� 5Y      -!   5        $ 	btnToPath��5Y      $��Browse Path��6,   $
��Left=�6B   $��266,329,0,0q�6]   $	��Top=�6r   6�   �� 5Z      -"   5        $ label2_Copy��5Z      $��0q�6-   
������ $��Last Saved:��6Z   $
��Left=�6p   $��
35,381,0,0q�6�   $	��Top=�6�   �� 5[      -#   5        $ lblSavedDate��5[      $��0q�6.   
������ $��
Date Saved��6[   $
��Left=�6p   $��118,381,0,0q�6�   $	��Top=�6�   5\      5]      5b      5q      