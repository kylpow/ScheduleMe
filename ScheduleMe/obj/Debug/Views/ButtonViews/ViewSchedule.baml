   M S B A M L   `   `   `  ����E  AScheduleMe, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:ScheduleMe.ViewsScheduleMe.Views  5      #    ScheduleMe.Views.ViewSchedule   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:ScheduleMe.Views     5      U QMahApps.Metro, Version=1.5.0.23, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f6mah,http://metro.mahapps.com/winfx/xaml/controls  5      $	��550��5	      $	��380��5
      .��5      � 
�������  � ColumnDefinitions  5   
   �� 5      $��2* �6   �� 5      $��9* �6    � RowDefinitions 5   
   �� 5      $
��121* �6   �� 5      $	��69* �6   .+�5   
   &   System.Windows.Controls.Calendar  $��Center=�6   $	��200��5      $��Center=�5      $	��184��5       J� IsManipulationEnabled .    SelectionMode$ MultipleRange=�5      $��107,32,159,0q�5      $��1��6)   &   System.Windows.Controls.DataGrid  5G   
   -   5          Name$ 
dgSchedule��5H      $��Center=�5I      $	��125��5J      $	��530��5K      $��2��5L      $��1��5M      $��1��5N      $
��12px(�5O         
IsReadOnly . ��5G      �� *Shifts+   Columns 5R      0  *System.Windows.Controls.DataGridTextColumn  5S      ,  &System.Windows.Controls.DataGridColumn   Header$ Sunday��6%      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 5U   %   �� *
smShifts+  5V      $ Monday��6%    . 	 5X   %   �� *
smShifts+  5Y      $ Tuesday��6%    . 	 5[   %   �� *
smShifts+  5\      $ 	Wednesday��6%    . 	 5^   %   �� *
smShifts+  5_      $ Thursday��6%    . 	 5a   %   �� *
smShifts+  5b      $ Friday��6%    . 	 5d   %   �� *
smShifts+  5e      $ Saturday��6%    . 	 5g   %   �� *
smShifts+5i      �� 5k   
   -   5        $��lblTodaysDate��5k      $��[Today's Date]��5l      $
��Left=�5m      $��0��5n      $	��Top=�5o      $��16(�5p      $��31��6<   $��1,0,0,0q�6H   $��0��6Y   $��2��6i   5q      5r      