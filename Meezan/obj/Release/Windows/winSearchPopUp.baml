   M S B A M L   `   `   `  ���� A  =Meezan, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Meezan.HelperClassesMeezan.HelperClasses  #    Meezan.Windows.winSearchPopUp   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     <HelperClasses"clr-namespace:Meezan.HelperClasses     -     � Title$  winSearchPopUp��$	��500��$	��800��#��� �� � 	Resources    textboxStyle �� 
TargetType �� Property �� Value  textblockStyle ! searchedStudentInfoViewSource��%�   &	        &	 T     &	 �     �� " ��.���  � ��$ Center=���  � ��$	 250����  � ��$ 30���� " ��.���  � ��$ Center=���  � ��$ 30����  � ��$ 20(���  � ��$
 Left=���  � ��$ 20,0,0,0q��� .���  � DataContext# [  � RowDefinitions �� $	��71* ��� $
��399* � � ColumnDefinitions �� �� �� .+��� $��Name :��#��[ �� -    ��Name$ txtSearchbox��$��1��#��[  $��2��$��7,20,183,21q�$
��Auto���� -   $��	btnSearch��$��2��$��60��$��45��	 �� 	IsDefault	 . .���� $.��(/Meezan;component/Images/Search_icon.png��&   System.Windows.Controls.DataGrid  -   
  Name$!
 searchedStudentInfoDataGrid��   AutoGenerateColumns .  $��3��   GridLinesVisibility$ 
Horizontal=�   EnableRowVirtualization . $��1��   SelectionMode$ Single=�   
IsReadOnly .    RowDetailsVisibilityMode$ VisibleWhenSelected=�����    Columns 0  *System.Windows.Controls.DataGridTextColumn  -   
nameColumn��,  &System.Windows.Controls.DataGridColumn   Header$
 Name��   Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *name+  -   fatherNameColumn��$ Father Name��$
 auto  �� *
fatherName+  -   admissionNoColumn��$ Admission No��$
 auto  �� *admissionNo+  -   domicleColumn��$ Domicle��$
 auto  �� *	domicle+