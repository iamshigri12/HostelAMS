   M S B A M L   `   `   `  ����
  Meezan&     Meezan.Windows.winPasswordChange   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Password Change��5   	   $	��300��6!   $	��500��6.    � 
ResizeMode$ NoResize=�6:   #��� ��6P    � WindowStartupLocation$ CenterScreen=�6�    � 	Resources 5         textboxStyle �� 
TargetType �� Property �� Value  buttonStyle��%\  &	        &	 �     �� 5      " G�6!   .�5   
   ��  � ��$ Center=�6.   6?   �� 5   
    � ��$	 250��6"   60   �� 5	   
    � ��$ 40��6#   60   5
      �� 5   
   " ��6$   .�5      ��  � ��$ Center=�62   6C   �� 5       � ��$	 150��6&   64   �� 5       � ��$ 40��6'   64   5      5      .��5      �  � RowDefinitions 5   
   �� 5      6    �� 5      6   �� 5      6    �� 5      6    � ColumnDefinitions 5   
   �� 5       $
��163* �6   6.   �� 5!      $
��337* �6   6.   .+�5$   
   ]� $��0��6   $��1��6!   $��Center=�61   ��.  $��Right=�6c   .+�5%      �� -   5        $��btnReset��5%      	 � ToolTip$	 	Reset All��6?   ��5&      �� 5'      $-��'/Meezan;component/Images/reset_icon.ico��6   $��30��6M   6[   5)      �� 5*      -   5        $��btnSave��5*      $	 Save Changes��6>   ��5+      �� 5,      $,��&/Meezan;component/Images/save_icon.png��6   $��23��6L   6[   5.      �� 5/      -   5        $��	btncancel��5/      $��36��6>   $	 Close��6J   ��50      �� 51      $.��(/Meezan;component/Images/Cancel_icon.png��6   6P   53      55      �� 58   
   -   5        $��tbOldpassword��58      $�� Old Password :��6)   $��20(�6@   $��1��6O   $��Right=�6]   $��Center=�6y   $��30��6�   $
��0,24q�6�   $	��136��6�   6�   G� 59   
   -   5        $��	txtOldpwd��59   &   $��1��6   $��1��67   #��[  6D   �� 5:   
   -   5        $��tbnewpassword��5:   !   $��2��6   $�� New Password :��66   $��20(�6M   $��Right=�6\   $��Center=�6x   $��30��6�   $
��0,24q�6�   $	��144��6�   6�   G� 5;   
   -   5        $��	txtnewpwd��5;   3   $��2��6   $��1��6#   #��[  6F   �� 5<   
   -   5        $��tbcnfmpassword��5<   !   $��3��6   $��	Confirm :��67   $��20(�6H   $��Right=�6X   $��Center=�6t   $��30��6�   $
��0,24q�6�   $��81��6�   G� 5=   
   -	   5        $��
txtcnfmpwd��5=   3   $��3��6   $��1��6#   #��[  6G   5B      5C      