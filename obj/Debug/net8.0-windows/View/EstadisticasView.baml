   M S B A M L   `   `   `  ����U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf  5       f1management(   "f1management.View.EstadisticasView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5         
BrushFondo#���   5      .��5      � $��20q�6     � RowDefinitions  5   
   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� -   5        $��
← Volver��5      $
��Left=�5      $	��Top=�5      $	��6,2q�5      $��12(�5      
������   BrushPrincipal#���  5      
������  � Cursor$
 Hand��5      5      �� 5   
   $��1��6   $(��"📊 Estadísticas de la Temporada��5      $��24(�5      $
��Bold"�5      #���  5      $��0,0,0,20q�5       � 5#   
   $��2��6    � ColumnDefinitions 5$      �� 5%      $��* �6#   �� 5&      $��* �6#   .+�5*      #   LiveCharts.Wpf.CartesianChart  $��0��6!   &    LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$ Right=�5+   !   $��10q�68      Series 5*   1   �� *SeriesPuntos+   AxisX 5-         LiveCharts.Wpf.Axis     Title$ Pilotos��6      Labels 6/   �� *LabelsPilotos+   AxisY 50        $ Puntos��6   	   LabelFormatter	 6.   �� *	Formatter+52        55      $��1��6!   $ Right=�56   !   $��10q�68    55   1   �� *SeriesCarreras+ 58        $ Pilotos��6    6/   �� *LabelsPilotos+ 5;        $ Carreras disputadas��6   5=      5>      5?      5@      