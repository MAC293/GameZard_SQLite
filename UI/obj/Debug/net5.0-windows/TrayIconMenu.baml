   M S B A M L   `   `   `  ����=  9UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:UIUI  5   	   > :BLL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null&clr-namespace:BLL;assembly=BLLBLL 5   <       UI.TrayIconMenu   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   "localclr-namespace:UI     5   	   S OHandyControl, Version=3.2.0.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  5   	   +local1clr-namespace:BLL;assembly=BLL  6<   $	��695��5	   	   $	��357��6     � WindowStartupLocation$  CenterScreen=�6"    � DataContext 5        BLL.WorkerHelper  5   
   .��5      � -   5         �Name$ gridMenu��5      .+�5   
   �� -   5         ��Name$ image��5      $
��Left=�6   $��37��6:   $��	150,5,0,0q�6F   $	��Top=�6Y   $��32��6q   $��/PC_Black.ico��6|    J� RenderTransformOrigin$ 
1.641,0.65&�6�   �� 5   
   -   5         ��Name$ cmbGames��5      $
��Left=�6%   $��	28,42,0,0q�6@   $	��Top=�6S   $	��275��6k   �� 5   
   -   5         ��Name$ btnPCBU��5      $
��Left=�6"   $��
308,42,0,0q�6=   $	��Top=�6Q   $��0q�6i   $��30��6}   $��26��6�   ��5      �� 5       �� ImageSource$ /Back-Up.ico��6   5       � 5"   
   -   5        $
��pbPC��5"      
���   �$y�Visible=�6M    � Minimum$ 0Q�6b   	 � Maximum$		 100Q�6n   $
��Left=�6|   $��16��6�   $��	28,77,0,0q�6�   $	��Top=�6�   $	��276��6�   
 � Value
 6"   �� *PCBar+6�   �� 5(   
   -   5        $ 
image_Copy��5(      $
��Left=�6$   $��36��6?   $��150,108,0,0q�6K   $	��Top=�6`   $��32��6x   $��/VisualBoyAdvance.ico��6�   $ 
1.641,0.65&�6�   �� 5)   
   -   5        $ btnVBABU��5)      $
��Left=�6#   $��308,139,0,0q�6>   $	��Top=�6S   $��0q�6k   $��30��6   $��26��6�   ��5*      �� 5+      $ /Back-Up.ico��6   5-      � 5.   
   -   5        $��pbVBA��5.      
���� ��$
��Left=�6P   $��16��6k   $��
28,146,0,0q�6w   $	��Top=�6�   $	��275��6�   
 6#   �� *VBABar+6�   �� 50   
   -	   5        $ image_Copy1��50      $
��Left=�6%   $��36��6@   $��150,179,0,0q�6L   $	��Top=�6a   $��32��6y   $��/SNES9x.ico��6�   $ 
1.641,0.65&�6�   �� 51   
   -
   5        $ 	btnSNESBU��51      $
��Left=�6$   $��308,210,0,0q�6?   $	��Top=�6T   $��0q�6l   $��30��6�   $��26��6�   ��52      �� 53      $ /Back-Up.ico��6   55      � 56   
   -   5        $��pbSNES��56      $
��Left=�6$   $��16��6?   $��
26,217,0,0q�6K   $	��Top=�6_   $	��277��6w   �� 58   
   -   5        $ image_Copy2��58      $
��Left=�6%   $��36��6@   $��150,252,0,0q�6L   $	��Top=�6a   $��32��6y   $��	/Cemu.ico��6�   $ 
1.641,0.65&�6�   �� 59   
   -   5        $ 	btnCemuBU��59      $
��Left=�6$   $��308,275,0,0q�6?   $��0q�6T   $��30��6h   $��26��6t   $	��Top=�6   ��5:      �� 5;      $ /Back-Up.ico��6   5=      � 5>   
   -   5        $��pbCemu��5>      $
��Left=�6$   $��16��6?   $��
26,289,0,0q�6K   $	��Top=�6_   $	��277��6w   �� 5@   
   -   5        $ image_Copy3��5@      $
��Left=�6%   $��36��6@   $��150,320,0,0q�6L   $	��Top=�6a   $��32��6y   $��
/Citra.ico��6�   $ 
1.641,0.65&�6�   �� 5A   
   -   5        $ 
btnCitraBU��5A      $
��Left=�6%   $��308,351,0,0q�6@   $��0q�6U   $��30��6i   $��26��6u   $	��Top=�6�   ��5B      �� 5C      $ /Back-Up.ico��6   5E      � 5F   
   -   5        $��pbCitra��5F      $
��Left=�6%   $��16��6@   $��
26,358,0,0q�6L   $	��Top=�6`   $	��277��6x   �� 5H   
   -   5        $ image_Copy4��5H      $
��Left=�6%   $��36��6@   $��150,385,0,0q�6L   $	��Top=�6a   $��32��6y   $��/Dolphin.ico��6�   $ 
1.641,0.65&�6�   �� 5I   
   -   5        $ btnWiiBU��5I      $
��Left=�6#   $��308,416,0,0q�6>   $��0q�6S   $��30��6g   $��26��6s   $	��Top=�6~   ��5J      �� 5K      $ /Back-Up.ico��6   5M      � 5N   
   -   5        $��pbWii��5N      $
��Left=�6#   $��16��6>   $��
26,423,0,0q�6J   $	��Top=�6^   $	��277��6v   �� 5P   
   -   5         ��Name$ label��5P      $��0q�6   $	��Wii��63   $
��Left=�6A   $��187,388,0,0q�6\   $	��Top=�6q   �� 5Q   
   -   5        $ image_Copy5��5Q      $
��Left=�6%   $��36��6@   $��150,453,0,0q�6L   $	��Top=�6a   $��32��6y   $��/Dolphin.ico��6�   $ 
1.641,0.65&�6�   �� 5R   
   -   5        $ btnGCBU��5R      $
��Left=�6"   $��308,484,0,0q�6=   $��0q�6R   $��30��6f   $��26��6r   $	��Top=�6}   ��5S      �� 5T      $ /Back-Up.ico��6   5V      � 5W   
   -   5        $
��pbGC��5W      $
��Left=�6"   $��16��6=   $��
26,491,0,0q�6I   $	��Top=�6]   $	��277��6u   �� 5Y   
   -   5        $ 
label_Copy��5Y      $��0q�6$   $��GameCube��68   $
��Left=�6K   $��187,455,0,0q�6f   $	��Top=�6{   �� 5Z   
   -   5        $ image_Copy6��5Z      $
��Left=�6%   $��36��6@   $��150,519,0,0q�6L   $	��Top=�6a   $��32��6y   $��
/ePSXe.ico��6�   $ 
1.641,0.65&�6�   �� 5[   
   -   5        $ btnPSXBU��5[      $
��Left=�6#   $��308,550,0,0q�6>   $��0q�6S   $��30��6g   $��26��6s   $	��Top=�6~   ��5\      �� 5]      $ /Back-Up.ico��6   5_      � 5`   
   -   5        $��pbPSX��5`      $
��Left=�6#   $��16��6>   $��
26,557,0,0q�6J   $	��Top=�6^   $	��277��6v   �� 5b   
   -   5        $ image_Copy7��5b      $
��Left=�6%   $��36��6@   $��150,584,0,0q�6L   $	��Top=�6a   $��32��6y   $��
/PCSX2.ico��6�   $ 
1.641,0.65&�6�   �� 5c   
   -   5        $ btnPS2BU��5c      $
��Left=�6#   $��308,615,0,0q�6>   $��0q�6S   $��30��6g   $��26��6s   $	��Top=�6~   ��5d      �� 5e      $ /Back-Up.ico��6   5g      � 5h   
   -   5        $��pbPS2��5h      $
��Left=�6#   $��16��6>   $��
26,622,0,0q�6J   $	��Top=�6^   $	��277��6v   5j      5k      