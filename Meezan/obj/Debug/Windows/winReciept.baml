   M S B A M L   `   `   `  ����A  =Meezan, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Meezan.HelperClassesMeezan.HelperClasses  5   �       Meezan.Windows.winReciept   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6F   <HelperClasses"clr-namespace:Meezan.HelperClasses     6�   -   5          � Title$  Receipt��5   	   $	��620��6   $
��1020��6&   #��� ��63    � 
ResizeMode$ CanMinimize=�6x    � WindowStartupLocation$ CenterOwner=�6�    � 	Resources 5       -  )receiptDataGridDataSourceHelperViewSource  textboxStyle �� 
TargetType �� Property �� Value  buttonStyle��%y  &	        &	      &	 �     �� 5   
   6   �� 5	   
   " ��6%   .�5
      ��  � ��$ Center=�62   6C   �� 5       � ��$	 250��6&   64   �� 5       � ��$ 30��6'   64   5      �� 5   
   " ��6$   .�5      ��  � ��$ Center=�62   6C   �� 5       � ��$	 150��6&   64   �� 5       � ��$ 40��6'   64   5      5      .��5#      �  � DataContext# [  6    � RowDefinitions 5$   
   �� 5%      $	��75* �6   �� 5&      $	��84* �6   �� 5'      $
��368* �6   �� 5(      $	��65* �6   	 � ColumnDefinitions	 5*   
   �� 5+      $
��136* �6   �� 5,      $
��246* �6   �� 5-      $	��114 �6   �� 5.      $	��130 �6   �� 5/      $��98 �6   �� 50      $
��161* �6   �� 51      $
��129* �6   .+�54   
   �� -   5        $��cmbReceiptCode��54      $��	0,0,66,53q�6)   6s   �� 55   
   -   5        $��tbitems��55   "   $��Item :��6   $��Right=�61   $��20(�6M   $��Center=�6[   $��30��6v   $��50��6�   $��	0,22,0,23q�6�   �� 56   
   -   5        
 ��Name$
 txtitem��56   "   $��1��6   #��[ 63   �� 57   
   -   5        $��tbprice��57   #   $��Price :��6   $��Right=�62   $��20(�6N   $��Center=�6\   $��2��6w   $��30��6�   $��53��6�   $��	0,22,0,23q�6�   �� 58   
   -   5        $��txtPrice��58   "   $��3��6   #��[ 62   $
��Auto��6X   �� 59   
   -   5        $��
tbquantity��59   6   $��4��6   $��
Quantity :��6$   $��20(�6H   $��Center=�6V   $��30��6q   �� 5:   
   -   5        $��txtQuantity��5:   "   $��5��6   #��[ 65   $
��Auto��6[   �� 5;   
   -	   5        $��cmbUnit��5;   #   $��6��6   $��Center=�62   $��30��6M   6]   �� 5<   
   -
   5        $��	tbdetails��5<   %   $��	Details :��6   $��0��66   $��1��6F   $��Center=�6S   $��Right=�6n   $��20(�6�   $��30��6�   $��69��6�   $
��0,27q�6�   �� 5=   
   -   5        $
 
txtdetails��5=   /   $��1��6   $��1��6"   #��[ 6C   �� 5>   
   $��Date :��6   $��2��6"   $��1��62   $��Center=�6?   $��Right=�6Z   $��20(�6v   $��30��6�   $��69��6�   $
��0,27q�6�   (  "System.Windows.Controls.DatePicker  5?   
   -   5        $��dpReceiptDate��5?   2   $��3��6   $��1��6%   $��Center=�6G   $��30��6b   $��Center=�6n   $	��152��6�   $��2��6�   �� 5@   
   -   5        $��cmbReceiptType��5@   0   $��5��6   $��1��6#   $��Center=�6F   $��30��6a   $��Center=�6m   $	��141��6�   $
��0,27q�6�   �� 5A   
   -   5         ��Name$ btnAdd��5A   W   $��6��6   $��1��6!   $��Center=�6.   $	��Add��6I   $��30��6g   $��Center=�6s   $��95��6�    �� 	IsDefault . 6�   &   System.Windows.Controls.DataGrid  5G   
   -   5          Name$- 'receiptDataGridDataSourceHelperDataGrid��5G         AutoGenerateColumns .  $��7��6`      EnableRowVirtualization . $��2��6�      RowDetailsVisibilityMode$ VisibleWhenSelected=�6�      SelectionMode$ Single=�6�      AreRowDetailsFrozen .    AlternatingRowBackground
 �����   GridLinesVisibility$
 None=�6�     	RowHeight$ 30Q�6�  $��18(�6�  ��6�   ��    Columns 5H      0  *System.Windows.Controls.DataGridTextColumn  5J      -   5        
itemColumn��,  &System.Windows.Controls.DataGridColumn   Header$ Item / Name��5J   R      Width5  /System.Windows.Controls.DataGridLengthConverter$	 110 6g   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *Item+6g     5K      -   5        detailColumn��$ Detail��5K   V   $	 200 6f    6;   �� *Detail+6f     5L      -   5        priceColumn��$ Price/Amount��5L   T   $	 120 6j    6:   �� *Price+6j     5M      -   5        quantityColumn��$ Quantity��5M   Z   $ 80 6l    6=   �� *
Quantity+6l     5N      -   5        
UnitColumn��$
 Unit��5N   R   $ 80 6`    69   �� *Unit+6`     5O      -   5        ReceiptDateColumn��$
 Date��5O   y   $	 120 6�    6@   �� *receiptDate+ �� StringFormat$ 
dd/MM/yyyy��6�     5P      -   5        SubTotalColumn��$ 	Sub Total��5P   Z   $ 90 6m    6=   �� *
SubTotal+6m     5Q      -   5        receptTypeColumn��$
 Type��5Q   ^   $
 auto 6l    6?   �� *
ReceptType+6l     5R      -   5        receptCodeColumn��$ Category��5R   c   $
 auto 6u    6?   �� *ReceiptCatagory+6u   5V      ]� 5\   
   
�������$��30��6+   $��Center=�67   $��3��6R   $��5��6_   ��.  $��Right=�6�   .+�5]      �� -   5        $��btnPrint��5]   -   $��30��6   $��35��6"    J� RenderTransformOrigin$ 0.714,0.433&�6V    � ToolTip$ Print��6z   ��5^      �� 5_      $.��(/Meezan;component/Images/Search_icon.png��6   6Q   5a      �� 5b      -   5        $��btnReset��5b      $ 	Reset All��6?   ��5c      �� 5d      $-��'/Meezan;component/Images/reset_icon.ico��6   $��30��6M   6[   5f      �� 5g      -   5        $��btnSaveReceipt��5g      $��30��6L   $ Save Changes��6X   ��5h      �� 5i      $,��&/Meezan;component/Images/save_icon.png��6   $��30��6L   6[   5k      �� 5l      -   5        $��	btncancel��5l      $��30��6A   $ Close��6M   ��5m      �� 5n      $.��(/Meezan;component/Images/Cancel_icon.png��6   6P   5p      5r      5u      5v      