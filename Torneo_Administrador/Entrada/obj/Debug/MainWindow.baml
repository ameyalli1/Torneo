   M S B A M L   `   `   `  ����B  >Entrada, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:EntradaEntrada  5   	       Entrada.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Entrada     5   	     � Title$  
MainWindow��5   	   $	��320��6   $	��510��6)   ��5	      �� 5
   
    �� ImageSource$* $Imagenes/Logo-Torneo-Corporativo.png��6   .��5      � ��5   
   �� 5      $ Imagenes/colores.jpg��6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   � $��1��6    � Orientation$ Vertical=�6!   $��20q�68   $��Center=�6D   .+�5      �� $��70��6   ���	#FF080202$
��Bold"�6<   $��18(�6N   $��Segoe UI Black)�6\   �� 6y   $�INICIO��6}   6�   5      � 5   
   $��2��6   $ Vertical=�6!   $��20q�68   $��Center=�6D   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5       �� $	��100��6   ���	#FF080202$
��Bold"�6@   $��17(�6R   
Ussuario6j   �� 5!      -   5         ��Name$ cmbUsuarioInicio��5!   (   $	��190��6   6(   5"      5#      � 5$   
   $��3��6   $ Vertical=�6!   $��15q�68   $��Center=�6D   .+�5%      �� $ 
Horizontal=�6   .+�5&      �� $	��100��6   ���	#FF080202$
��Bold"�6?   $��17(�6Q   Contraceña6k   G� 5'      -   5         G�Name$ txtContraceñaInicio��5'   +   $	��190��6   6+   5(      5)      �� 5,   
   -   5         ��Name$ 	btnEntrar��5,      $��70��6   $��169,12,263,8q�6I   $��4��6_   .��5-      �� $ 
Horizontal=�6   .+�5.      �� .��6   Entrar6    �� 5/      $��16��6   $��/Imagenes/door_in.png��6#   6E   50      51      �� 53   
   -   5        $ btnSalir��53      $��70��6   $��280,12,152,8q�6F   $��4��6\   .��54      �� $ 
Horizontal=�6   .+�55      �� .��6   Salir6   �� 56      $��16��6   $��/Imagenes/cross.png��6#   6C   57      58      5A      5B      