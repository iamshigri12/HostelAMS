   M S B A M L   `   `   `  ����A  =Meezan, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Meezan.HelperClassesMeezan.HelperClasses  5   �   #    Meezan.Windows.winSearchPopUp   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6F   <HelperClasses"clr-namespace:Meezan.HelperClasses     6�   -   5          � Title$  winSearchPopUp��5   	   $	��500��6    $	��800��6-   #��� ��6S    � 	Resources 5         textboxStyle �� 
TargetType �� Property �� Value  textblockStyle ! searchedStudentInfoViewSource��%�  &	        &	 �     &	 y    �� 5   
   " ��6%   .�5      ��  � ��$ Center=�62   �� 5	       � ��$	 250��6&   �� 5
       � ��$ 30��6'   5      �� 5   
   " ��6'   .�5      ��  � ��$ Center=�62   �� 5       � ��$ 30��6'   �� 5       � ��$ 20(�6)   �� 5       � ��$
 Left=�64   �� 5       � ��$ 20,0,0,0q�6'   5      �� 5   
   6   5      .��5$      �  � DataContext# [ 6    � RowDefinitions 5&   
   �� 5'      $	��71* �6   �� 5(      $
��399* �6    � ColumnDefinitions 5+   
   �� 5,      �� 5-      �� 5.      .+�51   
   �� $��Name :��6   #��[ 6"   �� 52   
   -   5         ��Name$ txtSearchbox��52      $��1��6(   #��[  68   $��2��6^   $��7,20,183,21q�6r   $
��Auto��6�   �� 53   
   -   5        $��	btnSearch��53   I   $��2��6   $��60��6!   $��45��6,   	 �� 	IsDefault	 . .��54      �� $.��(/Meezan;component/Images/Search_icon.png��6   55      &   System.Windows.Controls.DataGrid  56   
   -   5        
  Name$!
 searchedStudentInfoDataGrid��56         AutoGenerateColumns .  $��3��6T      GridLinesVisibility$ 
Horizontal=�6h      EnableRowVirtualization . $��1��6�      SelectionMode$ Single=�6�      
IsReadOnly .    RowDetailsVisibilityMode$ VisibleWhenSelected=�6:  ��6�   ��    Columns 57      0  *System.Windows.Controls.DataGridTextColumn  58      -   5        
nameColumn��,  &System.Windows.Controls.DataGridColumn   Header$
 Name��58   R      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6`   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *name+6`     59      -   5        fatherNameColumn��$ Father Name��59   ^   $
 auto 6s    6?   �� *
fatherName+6s     5:      -   5        admissionNoColumn��$ Admission No��5:   `   $
 auto 6v    6@   �� *admissionNo+6v     5;      -   5        domicleColumn��$ Domicle��5;   X   $
 auto 6i    6<   �� *	domicle+6i   5?      5@      5A      