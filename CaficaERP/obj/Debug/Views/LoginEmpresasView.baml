   M S B A M L   `   `   `  ����E  ACaficaERP, Version=1.0.0.37, Culture=neutral, PublicKeyToken=null9!clr-namespace:CaficaERP.ViewModelCaficaERP.ViewModel  5   	   1clr-namespace:CaficaERP.ViewsCaficaERP.Views  5	   	   %clr-namespace:CaficaERP	CaficaERP  5
   	   '    !CaficaERP.Views.LoginEmpresasView   5   	   a ]DevExpress.Xpf.Core.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5   	   ] YDevExpress.Mvvm.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aAdxmvvm2http://schemas.devexpress.com/winfx/2008/xaml/mvvm   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   7	ViewModel!clr-namespace:CaficaERP.ViewModel     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:CaficaERP.Views     5	   	   &myclr-namespace:CaficaERP     5
   	   a ]DevExpress.Xpf.Grid.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.Xpf.Grid.v16.1.Core, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   5   	   -   5          �Name$  FrmEmpresasLogin��5   H    � Icon$/ )/CaficaERP;component/Imagenes/IconERP.png��6�    � Title$ LoginEmpresasView��5   	   $��324.839��6#   $��509.402��64   ���#5D93DA � 
ResizeMode$ NoResize=�6Z    � WindowStyle$
 None=�6q   &   DevExpress.Xpf.Core.ThemeManager   	ThemeName0  *DevExpress.Xpf.Core.ThemeNameTypeConverter$
 None 6�    � WindowStartupLocation$ CenterScreen=�6�   .��5      � $��0,0,0,39q�6    � RowDefinitions 5   
   �� 5      $	��41* �6   �� 5      $
��244* �6   .+�5   
   �� ���	#FF1B293E$��Center=�6%   $��60��6B   
���   �$	��Top=�6]   $	��509��6u   $��0��6�   $��2��6�   �� 5   
   -   5         ��Name$ label��5      $��Empresas��6   $
��Left=�62   $��40��6M   $��
197,10,0,0q�6Y   $	��Top=�6m   $	��109��6�   
�������$
��Bold"�6�   $��22(�6�   !   CaficaERP.EnterKeyTraversal	   	IsEnabled	 . $��2��6�   �� 5   
   -   5        $��ListaEmpresas��5      $	��173��6'   $��10,28,10,44q�64   $	��489��6I   $��1��6U   
 �� DisplayMemberPath$
 RazonSocial��6�   $ VS2010 6�   $��1��6�   ��6b   �� *LstEmpresas+ �� SelectedItem 6�   �� *BdEmpresaSeleccionado+2  ,DevExpress.Mvvm.UI.Interactivity.Interaction   	Behaviors 5      &   DevExpress.Mvvm.UI.FocusBehavior  5         
FocusDelay$ 0:0:0.1X�6'      Triggers 5      '  !DevExpress.Mvvm.UI.EventToCommand  5      �  �DevExpress.Mvvm.UI.Interactivity.EventTriggerBase`1[[System.Windows.DependencyObject, WindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35]]   	EventName$ MouseDoubleClick��6E   +  %DevExpress.Mvvm.UI.EventToCommandBase   Command 6(   �� *
DcEntrar+   EventArgsConverter 5       5	  /DevExpress.Xpf.Core.EventArgsToDataRowConverter	  5!      5#       J� InputBindings 5&      �� 5'      
 �� Key$ Enter��6    �� Command 6)   �� *DataContext.DcEntrar+ �� ElementName$ ListaEmpresas��5*      �� 5+   
   -   5         ��Name$ button��5+      $��Seleccionar��6!   $��Center=�67   $��44��6T   $��	0,216,0,0q�6`   $	��Top=�6s   $	��489��6�   ���	#FF19407C$��2��6�   $ Office2013DarkGray 6�   $��14(�6  $��Segoe UI Semibold)�6  $
��Bold"�64  $��1��6F  ��6�   �� *
DcEntrar+6F  �� 5,   
   -   5        $ button1��5,      $
��Left=�6#   $��20��6>   $��	487,0,0,0q�6J   $	��Top=�6]   $��22��6u   $
 None 6�   ��6�   Z� ��6�   �� *CloseCommand+��5-      �� 5.       �� ImageSource$4 ./CaficaERP;component/Imagenes/login/cerrar.png��6    j� Stretch$ UniformToFill=�6Z   50      52      53      