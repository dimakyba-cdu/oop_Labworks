   M S B A M L   `   `   `  ����A  =Block1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Block1Block1  5   	       Block1.MainWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Block1     5   	     � Title$  Horse Racing��5   	    � WindowState$ 	Maximized=�5	   	    � 
ResizeMode$ NoResize=�5
   	    � Topmost$
 True��5   	    � 	Resources 5         dataGridStyle �� 
TargetType&   System.Windows.Controls.DataGrid �� Property �� Value��%	  &	        �� 5   
   "  6&   .�5      ��  � ��
 �����6+   �� 5       �@ RowBackground
 �����6.   �� 5        �@ AlternatingRowBackground
 ��ح�69   �� 5        �@ HorizontalGridLinesBrush
 �����69   �� 5       �@ VerticalGridLinesBrush
 �����67   �� 5       � ��$ 14(�6)   �� 5       �@ CanUserAddRows$ False��6/   �� 5       �@ CanUserResizeColumns$
 True��65   �� 5       �@ 
IsReadOnly$
 True��6+   5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��6* �6   	 � RowDefinitions	 5   
   �� 5       $��4* �6   �� 5!      $��2* �6   .+�5#   
   �� -   5        $��canvas��5#      $��1��6   $��0��6/   
�������.+�5$      �� 
 �� Left$
 0��5'      
 �� Top$ 0��6    $
��Fill=�5(      $"��/Images/Background/Track.png��5)      ��5%      �� *ActualWidth+ �� ElementName$ canvas����5&      �� *ActualHeight+$ canvas��5)      5*        5,   
   -   5        $��dataGrid��5,      $��1��6#   $��1��63   #��[  5-         AutoGenerateColumns$ False��5/         
IsReadOnly$
 True��50      ��5.      �� *Horses+   Columns 51      4  .System.Windows.Controls.DataGridTemplateColumn  52      ,  &System.Windows.Controls.DataGridColumn   Header$ Color��6)      CellTemplate 53      �� 54      .R�55      ��  �� Orientation$ 
Horizontal=�6)   .+�56   "   A� $��20��6A   $��20��6L   $��0,0,5,0q�6X   ��6*   �� *Color+6X   57      58      5:      0  *System.Windows.Controls.DataGridTextColumn  5;      $
 Name��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *Name+  5<      $ Position��6%    67   �� *
Position+  5=      $
 Time��6%    63   �� *Timer+  5>      $ Coefficient��6%    6:   �� *Coefficient+  5?      $ Money��6%    64   �� *Money+5A      �� 5B   
   $ Vertical=�6   $��20q�6,   $	��200��68   
�������$��Center=�6W   .+�5D      �� $��Horse Racing��6   $��20(�5E      
���\\��$
��Bold"�5G       �� TextAlignment$ Center=�5H      $��0,10,0,5q�5I      �� 5K      �� 5N      $��14(�5O      $��0,10,0,5q�5P      $��Center=�5Q      ��5N      �� *BalanceText+5S      �� 5U      $ 
Horizontal=�6   $��Center=�62   $	��0,5q�6O   .+�5V      �� -   5        $��<��5V      $��30��6(   $��25��63   6?   �� 5W      
���\\��$��14(�5Y      $
��Bold"�5Z      $
��10,0q�5[      ��5W      �� *BetAmountText+5[      �� 5\      -   5        $��>��5\      $��30��6(   $��25��63   6?   5]      �� 5_      $��Choose the the horce��6   $��12(�5`      
�������$��Center=�5b      $	��0,5q�5c      �� 5e      $ 
Horizontal=�6   $��Center=�62   .+�5f      �� -   5        $��<��5f      $��30��6(   $��25��63   6?   �� 5g      
���\\��$
��Bold"�5i      $
��10,0q�5j      ��5g      �� *SelectedHorseText+5j      �� 5k      -   5        $��>��5k      $��30��6(   $��25��63   6?   5l      �� 5n      -   5        $��Bet and play��5n      $��0,10,0,0q�5o      $��30��5p      $	��100��5q      $��Center=�5r      
�������
���   �5u      5v      5x      5y      