   M S B A M L   `   `   `  ����C  ?AllTrans, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:AllTrans.ViewAllTrans.View  5          AllTrans.View.NumberPick   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:AllTrans.View     5        N� Title$  
NumberPick��5	      .��5      � $��1��6   ���#F9F4F4 � ColumnDefinitions 5   
   �� 5      $
��0.3* �6   6/   �� 5      $��4 �6   6+   �� 5      $��* �6   6+   .+�5   
   � -   5         �Name$ TransSearch��5      $��0��6$   .+�5      �� $��/Images/Logo.png��6   $	��180��6.   6<   5      �� 5   
   
���   �$��1��6!   63   � 5   
   $��2��6    � RowDefinitions 5      �� 5      $��50 �6    6.   �� 5      $��* �6    6-   .+�5      �� $2��,Выберите номер маршрута��6      NavigationText#���   67   6b   � 5      -   5        $ ListNumberGrid��5      $��1��6+    5      �� 5      $��* �6'   63   �� 5       $��0 �6'   63   �� 5!      $��0 �6'   63   .+�5#      �� -   5         ��Name$ BusNumberList��5#   +   $��0��6   ��6e   �� *
Transports+��5$      �� 5%      .R�5&      �  � Orientation$ 
Horizontal=�6(    K� IsItemsHost$
 True��6A   $	��400��6T   $	��900��6c   5'      ��5)      �� 5*      .R�5+      ��  �� Orientation$ Vertical=�6)   .+�5,   "   �� $��50��6B   $��50��6M   ��6(   �� *Avatar+6M   5-      5.      50      �� 51      -   5        $ TrollNumberList��51   +   $��1��6   ��6g   �� *
Transports+��52      �� 53      .R�54      � $ 
Horizontal=�6(   $
 True��6A   $	��400��6T   $	��900��6c   55      ��57      �� 58      .R�59      �� $ Vertical=�6)   .+�5:   "   �� $��50��6B   $��50��6M   ��6(   �� *Avatar+6M   5;      5<      5>      �� 5?      -   5        $ TramNumberList��5?   +   $��2��6   ��6f   �� *
Transports+��5@      �� 5A      .R�5B      � $ 
Horizontal=�6(   $
 True��6A   $	��400��6T   $	��900��6c   5C      ��5E      �� 5F      .R�5G      �� $ Vertical=�6)   .+�5H   "   �� $��50��6B   $��50��6M   ��6(   �� *Avatar+6M   5I      5J      5L      5M      5O      5P      5Q      