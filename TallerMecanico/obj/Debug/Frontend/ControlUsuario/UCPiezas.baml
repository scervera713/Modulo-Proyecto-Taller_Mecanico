   M S B A M L   `   `   `  ����I  ETallerMecanico, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:TallerMecanico.Frontend.ControlUsuario&TallerMecanico.Frontend.ControlUsuario  5      5    /TallerMecanico.Frontend.ControlUsuario.UCPiezas   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962ac _MaterialDesignThemes.MahApps, Version=0.3.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a=mat1http://materialdesigninxaml.net/winfx/xaml/themes   5      Blocal4clr-namespace:TallerMecanico.Frontend.ControlUsuario   5      .��5
      � ���#333333  � RowDefinitions  5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �  � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $
��auto �6#   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� -   5         ��Name$ FiltroId��5   A   
�������$��1q�6-   ��5      �� *ActualWidth+ �� ElementName$
 dgId����6J   �� *
FiltroId+ �� UpdateSourceTrigger$ PropertyChanged=�5   S   �� 5      -   5        $ FiltroNombre��5   A   
�������$��1q�6-   ��5      �� *ActualWidth+$ dgNombre����6N   �� *FiltroNombre+$ PropertyChanged=�5   W   �� 5      -   5        $ 
FiltroTipo��5   A   
�������$��1q�6-   ��5      �� *ActualWidth+$ dgTipo����6L   �� *
FiltroTipo+$ PropertyChanged=�5   U   �� 5      -   5        $ FiltroPrecio��5   A   
�������$��1q�6-   ��5      �� *ActualWidth+$ dgPrecio����6N   �� *FiltroPrecio+$ PropertyChanged=�5   W   �� 5      -   5        $ FiltroCantidad��5    A   
�������$��1q�6-   ��5      �� *ActualWidth+$ 
dgCantidad����6P   �� *FiltroCantidad+$ PropertyChanged=�5    Y   5!      �� 5"      -   5         ��Name$ BtnQuitarFiltros��5"   %   $��1��6   .��5#      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ FilterRemove=�6   5$      5%      &   System.Windows.Controls.DataGrid  5'   
   -   5          Name$ dgListaPiezas��5'      $��1��6*   	   CanUserAddRows	 .  
   AutoGenerateColumns
 .  $��Visible=�5(      ��5'   7   �� *ListaPiezas+ �� SelectedItem 5(   F   �� *PiezaSeleccionada+ � ContextMenu 5)      �� 5*      .@�5,      m� -   5        $��nItemEditar��5,   /   $��Editar��6    m� Icon 5-        5.      $
 Edit=�6+   50      �� 51      m� 52      -	   5        $��nItemBorrar��52   /   $��Borrar��6    53        54      $ Delete=�6+   56      57         Columns 5:      0  *System.Windows.Controls.DataGridTextColumn  5;      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   -
   5        dgId��   Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 5;   [      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *	idPieza+6h     5<      $ Nombre��6%   -   5        dgNombre��$ 3* 5<   g    .  6G   �� *descripcion+6r     5=      $
 Tipo��6%   -   5        
dgTipo��$ 2* 5=   \    .  6C   �� *tipo+6g   4  .System.Windows.Controls.DataGridTemplateColumn  5>      $ Precio��6)   -   5        dgPrecio��$ * 5>   K      CellTemplate 5?      �� 5@      .R�5A      �� $ 
Horizontal=�6)   .+�5B   "   �� ��6,   �� *precio+�� 5C   "   $
�� €��6,   5D      5E      5G        5H      $ Cantidad��6%   -   5        
dgCantidad��$ * 5H   h    .  6K   �� *
cantidad+6r   5J      5K      5L      