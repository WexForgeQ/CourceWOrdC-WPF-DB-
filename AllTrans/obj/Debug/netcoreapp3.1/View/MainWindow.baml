   M S B A M L   `   `   `  ����C  ?AllTrans, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:AllTrans.ViewAllTrans.View  5   	       AllTrans.View.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:AllTrans.View     5   	     � Title$  AllTrans��5   	   $	��600��6   $	��900��6'    � 
ResizeMode$ CanMinimize=�63    � Icon$7 1D:\LAB4 sem\Курсач\AllTrans\Images\Logo.png��6L   .��5	      �  � RowDefinitions 5
   
   �� 5      $��70 �6   6*   �� 5      $��* �6   6)   �� 5      $��20 �6   6*   .+�5   
   �� 
���   �$��2��6!   60   � 5   
   -   5         �Name$ NavPanel��5      $��0��6!   ���#F9F4F4 � ColumnDefinitions 5      �� 5      $	��100 �6#   61   �� 5      $��75 �6$   �� 5      $��75 �6#   60   �� 5      $��75 �6#   60   �� 5      $��* �6#   6/   �� 5      $	��100 �6#   61   .+�5      A� -   5         A�Name$ 
UserAvatar��5   &   $��0��6   $��60��6:   $��60��6E   ��5      �� 5      -   5        AvatarImage�� j� Stretch$
 Fill=�5   6    �� ImageSource$ \Images\Terence.png��6E   6i   5      � 5      -   5        $ HomeGrid��5      $��3��6%   	 � Cursor$
	 Hand��6L   .+�5      �� -   5        
 ��Name$

 Home��5      $��3��6'   $��40��67   $��\Images\Home.png��6C   6_   5       �� 5!      -   5        $
 
CoverImage��5!      $��1��6(   $��40��68   $��\Images\ArrowBack.png��6D   6z   �� 5"      -   5        $
 
Favourites��5"      $��2��6(   $��40��68   $��\Images\Star.png��6D   6y   �� 5$      -   5         ��Name$ 
Войти��5$      $��5��6'   $��
Выйти��67      NavigationText#���   6D   $��25(�6m   6�   5%       � 5&   
   -	   5          �Name$ ContentContainer��5&      $��1��6*   
�������  � NavigationUIVisibility$ Hidden=�6N   5(      5)      5*      