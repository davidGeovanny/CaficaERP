   M S B A M L   `   `   `  ����E  ACaficaERP, Version=1.0.0.37, Culture=neutral, PublicKeyToken=nullA%clr-namespace:CaficaERP.Views.ComprasCaficaERP.Views.Compras  5      1    +CaficaERP.Views.Compras.ProveedoresFormView   5      a ]DevExpress.Xpf.Core.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:CaficaERP.Views.Compras     5      a ]DevExpress.Xpf.Grid.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.Xpf.Grid.v16.1.Core, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   5      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5      j fDevExpress.Xpf.LayoutControl.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol  5	      ]	 YDevExpress.Mvvm.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aAdxmvvm2http://schemas.devexpress.com/winfx/2008/xaml/mvvm  	 5
      ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5      $	��550��5      $	��700��6   .��5      � .+�5   
   �� -   5          ��Name$  
tabControl��5      .@�5      �� $��Información General��6   .��5      �  � RowDefinitions 5      �� 5      $
��550* �6(    � ColumnDefinitions 5      �� 5      $
��600* �6+   �� 5      $��10 �6+   .+�5      � $��0��6    5      �� 5      $	��200 �6,   �� 5      $��10 �6,   �� 5      $	��125 �6,   �� 5      $��10 �6,   �� 5       $
��100* �6,    5"      �� 5#      $
��475* �6/   .+�5%      +  %DevExpress.Xpf.LayoutControl.GroupBox  4  .DevExpress.Xpf.Core.HeaderedContentControlBase   Header$ Datos Generales��6)   $��0��6B   ,  &DevExpress.Xpf.Core.ContentControlBase   Content. 5&      �  5(   "   �� 5)   &   $��36 �64   �� 5*   &   $��36 �64   �� 5+   &   $��36 �64   �� 5,   &   $��36 �64    50   "   �� 51   &   $
��450* �67   .+�54   "   � $��0��6'    55   &   �� 56   *    58   &   �� 59   *   $��56 �6;   �� 5:   *   $	��100 �6;   �� 5;   *   $��9 �6;   �� 5<   *   $��30 �6;   �� 5=   *   $
��200* �6;   �� 5>   *   $��9 �6;   �� 5?   *   $��45 �6;   �� 5@   *   $��80 �6;   .+�5B   &   �� $��0��6,   $��0��69   $��Clave:��6I   %  DevExpress.Xpf.Editors.TextEdit  5C   &   $��0��63   $��1��6@   %  DevExpress.Xpf.Editors.BaseEdit   
IsReadOnly .  J� Opacity$	 0.7Q�6�   )  #DevExpress.Xpf.Editors.TextEditBase   Text 6P   �� *	Item.Id+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5D   &   $��0��6,   $��3��69   $
��RFC:��6K     5E   &   $��0��65   $��4��6B   	   Mask$Z	 T([A-Z]{3,4})([0-9]{2})([0][1-9]|[1][0-2])([0][1-9]|[1-2][0-9]|[3][0-1])([A-Z0-9]{3})��6�    6R   �� *
Item.RFC+$ PropertyChanged=�
 �� ValidatesOnDataErrors
 . 6�   �� 5F   &   $��6��6-   $��Activo:��6>   )  #DevExpress.Xpf.Editors.ComboBoxEdit  5G   &   +  %DevExpress.Xpf.Editors.LookUpEditBase   AutoComplete . '	  !DevExpress.Xpf.Editors.ButtonEdit 	  IsTextEditable$
 TrueX�6K       ClearSelectionOnBackspace . $��7��6�      DisplayMember$ nombre��6�      ValueMember$ nombre��6�      ItemsSource 6�   �� *	LstSiNo+   	EditValue 6�   �� *Item.Activo+$ PropertyChanged=�
 . 5I   #   � 5K   "   $��1��6'    5L   &   �� 5M   *    5O   &   �� 5P   *   $��56 �6;   �� 5Q   *   $
��394* �6;   .+�5S   &   �� -   5         ��Name$ 	lblNombre��5S   L   $��0��6-   $��0��6;   $��Nombre:��6_     5T   &   $��0��63   $��1��6A      	MaxLength$ 45��6�   $E	 ?[A-ZÑÁÉÍÓÚ0-9]([A-ZÑÁÉÍÓÚ0-9 ]|[^A-Za-z0-9]){0,199}��6�    6R   �� *Item.Nombre+$ PropertyChanged=�
 . 6�   5U   #   � 5W   "   $��2��6'    5X   &   �� 5Y   *    5[   &   �� 5\   *   $��56 �6;   �� 5]   *   $
��394* �6;   .+�5_   &   �� $
��Wrap=�60   Nombre Comercial:5a   '     5b   &   $��0��63   $��1��6A   $ 45��6�   $E	 ?[A-ZÑÁÉÍÓÚ0-9]([A-ZÑÁÉÍÓÚ0-9 ]|[^A-Za-z0-9]){0,199}��6�    6R   �� *Item.NombreComercial+$ PropertyChanged=�
 . 6�   5c   #   � 5e   "   $��3��6'    5f   &   �� 5g   *    5j   &   �� 5k   *   $��56 �6;   �� 5l   *   $
��150* �6;   �� 5m   *   $��10 �6;   �� 5n   *   $��30 �6;   �� 5o   *   $
��150* �6;   .+�5q   &   �� $��0��6.   $��Grupo:��6?     5r   &    . $
 TrueX�6K    . $��1��6�   $ Nombre��6�   $ Id��6�    6�   �� *LstGruposProveedores+ 6�   �� *Item.GruposProveedoresId+ �� Mode$ TwoWay=�$ PropertyChanged=�
 . �� 5s   &   $��3��6-   $��Giro:��6>     5t   &    . $
 TrueX�6K    .    ImmediatePopup . $��4��6�   $ Nombre��6�   $ Id��6�    6�   �� *
LstGiros+ 6�   �� *Item.GiroId+$ TwoWay=�$ PropertyChanged=�
 . 5v   #   5{      5|        5}      $ Vías de comunicación��6)   $��2��6G   . 5~      �  5�   "   �� 5�   &   $��36 �64   �� 5�   &   $��36 �64    5�   "   �� 5�   &   $
��450* �67   .+�5�   "   � $��0��6'    5�   &   �� 5�   *    5�   &   �� 5�   *   $��65 �6;   �� 5�   *   $
��394* �6;   .+�5�   &   �� $
��Wrap=�60   Correo Electronico:5�   '     5�   &   $��0��63   $��1��6A   $ 45��6�   $4	 .[A-Za-z0-9._%-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}��6�    6R   �� *
Item.Email+$ PropertyChanged=�
 . 6�   5�   #   � 5�   "   $��1��6'    5�   &   �� 5�   *    5�   &   �� 5�   *   $��65 �6;   �� 5�   *   $
��150* �6;   �� 5�   *   $��10 �6;   �� 5�   *   $��60 �6;   �� 5�   *   $
��150* �6;   �� 5�   *   $��10 �6;   �� 5�   *   $��50 �6;   �� 5�   *   $
��150* �6;   .+�5�   &   �� $��0��6.   $��Teléfono 1:��6?     5�   &   $��0��63   $��1��6A   $ 45��6�   $&	  \(\d{3}\)[0-9A-Z]{3} [0-9A-Z]{4}��6�    6R   �� *Item.Telefono1+$ PropertyChanged=�
 . 6�   �� 5�   &   $��3��6-   $��Teléfono 2:��6>     5�   &   $��0��63   $��4��6A   $ 45��6�   $&	  \(\d{3}\)[0-9A-Z]{3} [0-9A-Z]{4}��6�    6R   �� *Item.Telefono2+$ PropertyChanged=�
 . 6�   �� 5�   &   $��6��6-   $��Celular:��6>     5�   &   $��0��63   $��7��6A   $ 45��6�   $&	  \(\d{3}\)[0-9A-Z]{3} [0-9A-Z]{4}��6�    6R   �� *Item.Celular+$ PropertyChanged=�
 . 6�   5�   #   5�      5�        5�      $ Datos financieros��6)   $��4��6D   . 5�      �  5�   "   �� 5�   &   $��36 �64   �� 5�   &   $��36 �64    5�   "   �� 5�   &   $
��450* �67   .+�5�   "   � $��0��6'    5�   &   �� 5�   *    5�   &   �� 5�   *   $��65 �6;   �� 5�   *   $
��150* �6;   �� 5�   *   $��10 �6;   �� 5�   *   $	��100 �6;   �� 5�   *   $
��150* �6;   .+�5�   &   �� $��0��6.   $��Moneda:��6?     5�   &    . $
 TrueX�6K    . $��1��6�   $ Nombre��6�   $ Id��6�    6�   �� *
LstMonedas+ 6�   �� *Item.MonedaId+$ TwoWay=�$ PropertyChanged=�
 . �� 5�   &   $��3��6-   $��Limite de Credito:��6>     5�   &   $��0��63   $��4��6A   $ 45��6�   $E	 ?[A-ZÑÁÉÍÓÚ0-9]([A-ZÑÁÉÍÓÚ0-9 ]|[^A-Za-z0-9]){0,199}��6�    6R   �� *Item.LimiteCredito+$ PropertyChanged=�
 . 6�   5�   #   � 5�   "   $��1��6'    5�   &   �� 5�   *    5�   &   �� 5�   *   $��65 �6;   �� 5�   *   $
��150* �6;   .+�5�   &   �� $
��Wrap=�60   Condiciones de pago:5�   '     5�   &    . $
 TrueX�6K    . $��1��6�   $ Nombre��6�   $ Id��6�    6�   �� *LstCondicionesPago+ 6�   �� *Item.CondicionesPagoId+$ TwoWay=�$ PropertyChanged=�
 . 5�   !   5�      5�      5�      5�      5�      �� 5�      $��Direcciones��6   .��5�      � $	��460��6   $	��775��6'    5�      �� 5�      $
��150* �6(    5�      �� 5�      $
��680* �6+   .+�5�        $ Lista de direcciones��6%   $��0��6C   . 5�      %
  DevExpress.Xpf.Grid.GridControl
  )  #DevExpress.Xpf.Grid.DataControlBase   SelectionMode$	 Row=�6*      ItemsSource 6>   �� *Item.ProveedoresDirecciones+$ PropertyChanged=�$ TwoWay=�   SelectedItem 6�   �� *DireccionSeleccionado+ 
  View 5�      #  DevExpress.Xpf.Grid.TableView  5�   "      AllowPerPixelScrolling . &   DevExpress.Xpf.Grid.DataViewBase   AllowEditing . &   DevExpress.Xpf.Grid.GridViewBase   ShowGroupPanel .     NewItemRowPosition$ Bottom=�6y      AllowSorting .     AllowFilterEditor .      AllowColumnFiltering  .  2  ,DevExpress.Mvvm.UI.Interactivity.Interaction!   Triggers! 5�   &   '  !DevExpress.Mvvm.UI.EventToCommand  5�   *   �  �DevExpress.Mvvm.UI.Interactivity.EventTriggerBase`1[[System.Windows.DependencyObject, WindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35]]"   	EventName$" CellValueChanged��6u   #   PassEventArgsToCommand$
# TrueX�6�   +  %DevExpress.Mvvm.UI.EventToCommandBase$   Command$ 6@   �� *" ValorCeldaCambioDireccionCommand+%   EventArgsConverter% 5�   .   6  0DevExpress.Xpf.Core.EventArgsToDataCellConverter  5�   2   5�   +   &   	Behaviors& 5�   &   %  DevExpress.Mvvm.UI.KeyToCommand  5�   *   '   
KeyGesture$	' F12��6>   $ 6O   �� *EliminaFilaDireccionCommand+5  #   ( 
  Columns( 5     $  DevExpress.Xpf.Grid.GridColumn  5  "   $  DevExpress.Xpf.Grid.BaseColumn)   Header)  #DevExpress.Xpf.Core.ObjectConverter$) Calle 61   $  DevExpress.Xpf.Grid.ColumnBase*   	FieldName$* Calle��6@   +   Width2  ,DevExpress.Xpf.Grid.GridColumnWidthConverter$	+ 150 6R   6`     5  "   $) No. Exterior 61   $+ 75 6G   $* 
NoExterior��6R   5  #     5	  "   $) No. Interior 61   $+ 75 6G   $* 
NoInterior��6R   6k     5
  "   $) 
Referencia 61   $+ 75 6F   $* 
Referencia��6Q   6k     5  "   $) Colonia 61   $* 	ColoniaId��6B   ,   EditSettings, 5  &   3  -DevExpress.Xpf.Grid.LookUp.LookUpEditSettings  5  *   <  6DevExpress.Xpf.Editors.Settings.LookUpEditSettingsBase-   DisplayMember$- Nombre��6i   .   ValueMember$. Id��6�   /   AutoPopulateColumns/ .  0   FilterCondition$0 ContainsX�6�   1   IsPopupAutoWidth1 .  2   AutoComplete2 . 6  0DevExpress.Xpf.Editors.Settings.BaseEditSettings3   NullText$3 Seleccione un componente��6�   4   ImmediatePopup4 . 5   IncrementalFiltering$
5 TrueX�62  6   ItemsSource6 6B   �� *LstDirecciones+;  5DevExpress.Xpf.Editors.Settings.PopupBaseEditSettings7   PopupContentTemplate7 5  .   �� 5  2   .R�5  6   
  $��PART_GridControl��6F   ( 5  :     5  >   $) Colonia 6M   $* Nombre��6^     5  >   $
) Pais 6M   $* Paises.Nombre��6[     5  >   $) Estado 6M   $* Estados.Nombre��6]     5  >   $) 	Municipio 6M   $* Municipios.Nombre��6`     5  >   $) Ciudad 6M   $* Ciudades.Nombre��6]     5  >   $) CP 6M   $* CodigosPostales.Codigo��6Y    5  :     5  >   8   	AutoWidth8 . 9   ShowAutoFilterRow9 . 6]   5  7   5  3   5  +   5!  #     5"  "   $) Codigo Postal 61   $+ 75 6I   $* CodigosPostales.Codigo��6T   :   ReadOnly: . 3  -DevExpress.Xpf.Core.DXFrameworkContentElement;   	IsEnabled; .  6�     5$  "   $) Ciudad 61   $* Ciudades.Nombre��6A   : . 6]     5'  "   $) 	Municipio 61   $* Municipios.Nombre��6D   : . 6b     5*  "   $) Estado 61   $* Estados.Nombre��6A   : . 6\     5-  "   $
) Pais 61   $* Paises.Nombre��6?   : . 6Y   51     53     55     57     �� 58     $��	Contactos��6   .��59     �  5:     �� 5;     $
��460* �6(    5=     �� 5>     $
��485* �6+   .+�5@     � $��0��6    5A     �� 5B     $
��195* �6,    5E     �� 5F     $
��475* �6/   .+�5I       $ Directorio de contactos ��6)   $��0��6K   . 5J     �  5K  "   �� 5L  &    5O  "   �� 5P  &   $
��445* �67   .+�5S  "   
  $	 Row=�6�    62   �� *Item.ProveedoresContactos+$ PropertyChanged=� 6�   �� *ContactoSeleccionado+& 5T  &     5U  *   $	' F12��6>   <   CommandParameter$< 4��6q   $ 6O   �� *DcEliminaFila+6q    5W  &     5X  *    .  .  .  $ Bottom=�6�    .   .    .  ! 5Y  .     5Z  2   $" CellValueChanged��6|   $
# TrueX�6�   $ 6H   �� *!ValorCeldaCambioContactoCommand+% 5[  6     5\  :   5^  3   & 5`  .     5a  2   $	' F12��6F   $ 6W   �� *EliminaFilaContactoCommand+5d  +   ( 5f  &     5g  *   $) Identificador 69   $* Identificador��6P   6m     5h  *   $) Nombre Completo 69   $* NombreCompleto��6R   6p     5i  *   $) Puesto 69   $* Puesto��6I   6_     5k  *   $) Calle 69   $* Calle��6H   $	+ 150 6Z   6h     5l  *   $) No. Exterior 69   $+ 75 6O   $* 
NoExterior��6Z   6s     5m  *   $) No. Interior 69   $+ 75 6O   $* 
NoInterior��6Z   6s     5n  *   $) 
Referencia 69   $+ 75 6N   $* 
Referencia��6Y   6s     5o  *   $) Colonia 69   $* 	ColoniaId��6J   , 5p  .     5q  2   $- Nombre��6q   $. Id��6�   / .  $0 ContainsX�6�   1 .  2 . $3 Seleccione un componente��6   4 . $
5 TrueX�6:  6 6J   �� *LstDirecciones+7 5r  6   �� 5s  :   .R�5t  >   
  $��PART_GridControl��6N   ( 5u  B     5v  F   $) Colonia 6U   $* Nombre��6f     5w  F   $
) Pais 6U   $* Paises.Nombre��6c     5x  F   $) Estado 6U   $* Estados.Nombre��6e     5y  F   $) 	Municipio 6U   $* Municipios.Nombre��6h     5z  F   $) Ciudad 6U   $* Ciudades.Nombre��6e     5{  F   $) CP 6U   $* CodigosPostales.Codigo��6a    5}  B     5~  F   8 . 9 . 6e   5�  ?   5�  ;   5�  3   5�  +     5�  *   $) Codigo Postal 69   $+ 75 6Q   $* CodigosPostales.Codigo��6\   : . ; .  6�     5�  *   $) Ciudad 69   $* Ciudades.Nombre��6I   : . 6e     5�  *   $) 	Municipio 69   $* Municipios.Nombre��6L   : . 6j     5�  *   $) Estado 69   $* Estados.Nombre��6I   : . 6d     5�  *   $
) Pais 69   $* Paises.Nombre��6G   : . 6a     5�  *   $) 
Telefono 1 69   $* 	Telefono1��6M   , 5�  .   6  0DevExpress.Xpf.Editors.Settings.TextEditSettings  5�  2   =   MaskType$= RegEx=�6G   >   MaskUseAsDisplayFormat> . ?   Mask$&?  \(\d{3}\)[0-9A-Z]{3} [0-9A-Z]{4}��6w   5�  +     5�  *   $) 
Telefono 2 69   $* 	Telefono2��6M   , 5�  *     5�  .   $= RegEx=�6C   > . $&?  \(\d{3}\)[0-9A-Z]{3} [0-9A-Z]{4}��6s   5�  +     5�  *   $) Celular 69   $* Celular��6J   , 5�  .     5�  2   $= RegEx=�6G   > . $&?  \(\d{3}\)[0-9A-Z]{3} [0-9A-Z]{4}��6w   5�  +     5�  *   $) Correo 69   $* Email��6I   , 5�  .     5�  2   $= RegEx=�6G   > . $4? .[A-Za-z0-9._%-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}��6w   5�  +   5�  #   5�     5�     5�     5�     5�     5�     5�     5�     