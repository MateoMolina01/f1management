   M S B A M L   `   `   `  ����  f1management'    !f1management.View.RendimientoView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5         
BrushFondo#���   5        � 	Resources  5        PosicionTemplate  BrushPrincipal �� CornerRadius��%M  &	       �� 5   
   .R�5      �� $��32��6   $��32��6    #���  5	      $ 16��5
      $��Center=�5      $��Center=�5      $��4q�5      ._�5      �� 
�������$
��Bold"�5      $��14(�5      $��Center=�5      $��Center=�5      ��5      �� *	Posición+5      5      5      5      .��5      � -   5         �Name$ MainGrid��5       � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��0 �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5       $
��Auto �6   �� 5!      $��* �6   .+�5%   
   �� -   5        $��
← Volver��5%        AccentButtonStyle#��[ 5&      $��10q�5'      5(      �� 5+   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $��
20,10,0,10q�6V   .+�5,      �� $��Clasificación:��6   $��18(�5-      $
��Bold"�5.      $��Center=�5/        
BrushTexto#���  50      �� 51      -   5         ��Name$ TipoClasificacionComboBox��51      $	��160��53      $��10,0,0,0q�54      .@�55      �� $��Pilotos��6    �� 
IsSelected$
 True��61   �� 56      $��Equipos��6   57      58      �� 5;   
   $��2��6   $��0��6   $��20q�6.   $ 10��5<        
BrushClaro#���  5=        
DropShadow J� Effect# [ 5>      ._�5?      &   System.Windows.Controls.DataGrid  -   5        	  Name$	 dataGridDrivers��5?      
   AutoGenerateColumns$
 False��5@         
IsReadOnly$
 True��5A         HeadersVisibility$ Column=�5B      
�������#���  5E         RowBackground
 �����   AlternatingRowBackground �#F4F4F4$��0q�5H      $��14(�5I         GridLinesVisibility$
 None=�5J      $��0q�5K      5M      �� 5P   
   -   5         ��Name$ PanelDetalle��5P      $��0��5Q      $��3��6   $��1��5R      $	��300��5S      #���  5T       �� Padding$ 20q�5U      $y�	Collapsed=�5V      $��Right=�5W      #���  5X      $��1q�5Y      $ 10��5Z      # [ 5[      ._�5]      �� .+�5^      �� -   5         ��Name$ DetalleNombre��5^      $��18(�5_      $
��Bold"�5`      #���  5a      $��0,0,0,10q�5b      �� 5c      -   5        $ DetalleEquipo��5c      #���  5d      $��0,0,0,5q�5e      �� 5f      -   5        $ DetalleNacionalidad��5f      #���  5g      $��0,0,0,5q�5h      �� 5i      -	   5        $ DetallePuntos��5i      #���  5j      $��0,0,0,5q�5k      �� 5l      -
   5        $ DetalleVictorias��5l      #���  5m      $��0,0,0,15q�5n      �� 5p      -   5        $��Cerrar��5p      #��[ 5q      $��90��5r      5s      5t      5u      5v      5w      