   M S B A M L   `   `   `  ����  f1management$    f1management.View.MiembrosView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5         
BrushFondo#���   5      .��5      � $��20q�6     � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5
      $��* �6   .+�5   
   �� -   5        $��
← Volver��5        AccentButtonStyle#��[ 5      $
��Left=�5      $	��Top=�5      $��0��5      $��0,0,0,10q�5      � 5   
   $��1��6    � ColumnDefinitions 5      �� 5      $	��300 �6#   �� 5      $��* �6#   .+�5      �� -   5         ��Name$ ListaMiembros��5       �� DisplayMemberPath$ Nombre��5!      $��0��5"      $��0,0,10,0q�5#        RoundedListViewStyle#��[ 5%        RoundedListBoxItemStyle#��[ 5&      ��5       �� *
Miembros+ �� View 5'      �� 5(      .P�5)      �� $��MIEMBROS��6)    �� Width$	 220��6;    �� DisplayMemberBinding 6G   �� *Nombre+5*      5,      �� 5/      $��1��6   $��10,0,0,0q�6)   $	��Top=�6;   .+�51      �� $��Nombre��6   $
��Bold"�6*   �� 52      -   5         ��Name$ 	TxtNombre��52      �� 54      $��Usuario asignado��6   $
��Bold"�64   �� 55      -   5         ��Name$ 
CmbUsuario��55      $ Nombre��56      	 �� SelectedValuePath$	 Id��57      �� 59      $	��Rol��6   $
��Bold"�6'   �� 5:      -   5        $ CmbRol��5:      $ Nombre��5;      $	 Id��5<      �� 5>      $��Monoplaza asignado��6   $
��Bold"�66   �� 5?      -   5        $ TxtMonoplaza��5?      $��0,0,0,10q�60   �� 5A      
 �� Orientation$
 
Horizontal=�6   $
��Left=�66   $��	0,10,0,10q�6Q   .+�5B      �� -   5        $��Guardar cambios��5B      #��[ 5D      �� 5E      -   5        $��Eliminar��5E      #��[ 5G      $��10,0,0,0q�5H      5I      �� 5K      -	   5        $��Añadir nuevo miembro��5K        MenuButtonStyle#��[ 5M      $	��180��5N      5O      5P      5Q      5R      