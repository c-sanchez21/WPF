   M S B A M L   `   `   `  ����I  EWPF Checkboxes, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WPF_CheckboxesWPF_Checkboxes  5   	       WPF_Checkboxes.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:WPF_Checkboxes     5   	     � Title$  
MainWindow��5   	   $	��300��6   $	��200��6)   
���   �
������� � 	Resources 5	       �� 
TargetType �� Property �� Value!   WPF_Checkboxes.DowConverter   dowConverter��%q   '��       &	  J     �� 5
   
   " ��6   .�5      ��  � ��
 �����6+   5        5   
   6   5      .��5      � .+�5   
   �� .+�5      �� -   5         ��Name$ btnAll��5      $��5q�6%   $��	Check All��60   $	��100��6Y   �� 5      $��Day of the Week��6   .��5      �� 
������ .@�5      ��  d� 	IsChecked 6   ��  �� Path$ Data.Dow� �� 	Converter# [     WPF_Checkboxes.DayOfWeek
	   Sun
 �� ConverterParameter#
 Z	 .��5   M   Sunday6U   �� 5       6   �� $ Data.Dow�# [  
   Mon#
 Z .��5   M   Monday6U   �� 5       6   �� $ Data.Dow�# [  
   Tue#
 Z .��5   M   	Tuesday6V   �� 5       6   �� $ Data.Dow�# [  
   Wed#
 Z .��5    M   	Wednesday6X   �� 5!       6   �� $ Data.Dow�# [  
   Thu#
 Z .��5#   M   
Thursday6W   �� 5$       6   �� $ Data.Dow�# [  
   Fri#
 Z .��5&   M   Friday6U   �� 5'       6   �� $ Data.Dow�# [  
   Sat#
 Z .��5)   M   
Saturday6W   5*      5+      �� 5-      -   5        $	��100��5-      $��5q�6!   .��6B   
Show Value6N   5.      50      51      