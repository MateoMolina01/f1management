   M S B A M L   `   `   `  ����  f1management-    'f1management.View.RegistroUsuarioWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Registro de Usuario��5   	   $	��465��5   	   $	��350��5   	    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	      
BrushFondo#���   5	   	   .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��Crear nuevo usuario��6   $��20(�5      $
��Bold"�5        BrushPrincipal#���  5      $��Center=�5      $��0,0,0,20q�5      �� 5   
   $��1��6   $	��Top=�6"   .+�5      �� $��Nombre de usuario:��6   �� 5      -   5         ��Name$ 
txtUsuario��5      �� 5      $��Correo electrónico:��6   �� 5       -   5        $ txtEmail��5       �� 5"      $��Contraseña:��6   G� 5#      -   5         G�Name$ txtPassword��5#      �� 5%      $��Confirmar contraseña:��6   G� 5&      -   5        $ txtPasswordConfirm��5&      5'      �� 5*   
   $��2��6    �� Orientation$ 
Horizontal=�5+      $��Right=�5,      $��0,20,0,0q�5-      .+�5.      �� -   5        $��Cancelar��5.      $��90��5/        AccentButtonStyle#��[ 50      51      �� 52      -   5        $��	Registrar��52      $	��100��53        MenuButtonStyle#��[ 54      $��10,0,0,0q�55      56      57      58      59      