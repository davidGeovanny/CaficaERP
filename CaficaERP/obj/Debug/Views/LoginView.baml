   M S B A M L   `   `   `  ����E  ACaficaERP, Version=1.0.0.37, Culture=neutral, PublicKeyToken=null1clr-namespace:CaficaERP.ViewsCaficaERP.Views  5      9!clr-namespace:CaficaERP.ViewModelCaficaERP.ViewModel  5      %clr-namespace:CaficaERP	CaficaERP  5	          CaficaERP.Views.LoginView   5   	   a ]DevExpress.Xpf.Grid.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.Xpf.Grid.v16.1.Core, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   a ]DevExpress.Xpf.Core.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      ] YDevExpress.Mvvm.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aAdxmvvm2http://schemas.devexpress.com/winfx/2008/xaml/mvvm   5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:CaficaERP.Views     5      7	ViewModel!clr-namespace:CaficaERP.ViewModel     5      &myclr-namespace:CaficaERP     5	      ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5      -   5          �Name$  FrmLogin��5
      $��312.712��5      $	��400��60    � WindowStartupLocation$ CenterScreen=�6<   ���#5D93DA � 
ResizeMode$ NoResize=�5   #    � WindowStyle$
 None=�69   &   DevExpress.Xpf.Core.ThemeManager   	ThemeName0  *DevExpress.Xpf.Core.ThemeNameTypeConverter$
 None 6L    � Icon$/ )/CaficaERP;component/Imagenes/IconERP.png��5       � DataContext 5      (   "CaficaERP.ViewModel.LoginViewModel  5   
   2  ,DevExpress.Mvvm.UI.Interactivity.Interaction   	Behaviors 5      '  !DevExpress.Mvvm.UI.EventToCommand  5   
   �  �DevExpress.Mvvm.UI.Interactivity.EventTriggerBase`1[[System.Windows.DependencyObject, WindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35]]   	EventName$ Initialized��6    +  %DevExpress.Mvvm.UI.EventToCommandBase	   Command	 68   �� *InitCommand+/  )DevExpress.Xpf.Core.DXSplashScreenService  5   
   "
   SplashScreenStartupLocation$
 CenterScreen=�6#       ShowSplashScreenOnLoading . (	  "DevExpress.Mvvm.UI.ViewServiceBase 	  ViewTemplate 5      �� 5      .R�5       
   CaficaERP.SplashScreenView
  5      5      .��5"      � 
������ .+�5#   
   �� ���	#FF1B293E$
��Left=�6%   $��60��6@   
���   �$	��Top=�6[   $	��400��6s   $��0��6   �� 5$   
   -   5         ��Name$ label��5$      $��Login��6   $
��Left=�6/   $��38��6J   $��
169,10,0,0q�6V   $	��Top=�6j   $��70��6�   $��22(�6�   $
��Bold"�6�   
�������6�   �� 5%   
   ���	#FF1B293E$
��Left=�6%   $��40��6@   $��	44,97,0,0q�6L   
���   �$��0��6n   $	��Top=�6�   $��40��6�   �� 5&   
   ���	#FF1B293E$
��Left=�6%   $��39��6@   $��
44,152,0,0q�6L   
���   �$��0��6o   $	��Top=�6�   $��41��6�   %  DevExpress.Xpf.Editors.TextEdit  5(   
   $
��Left=�6   $��40��62   $��	84,97,0,0q�6>   $	��Top=�6Q   $	��282��6i   %  DevExpress.Xpf.Editors.BaseEdit   NullText$ Usuario��6u      
ShowBorder . $��1��6�   !   CaficaERP.EnterKeyTraversal   	IsEnabled . $ VS2010 6  )  #DevExpress.Xpf.Editors.TextEditBase   Text 6�   �� *Login.Usuario+ �� UpdateSourceTrigger$ PropertyChanged=� 5)      &   DevExpress.Mvvm.UI.FocusBehavior  5*         
FocusDelay$ 0:0:0.0X�6'   5.      �� 5/   
   -   5         ��Name$ image��5/      $
��Left=�6   $��35��6:   $��
46,100,0,0q�6F   $	��Top=�6Z   $��35��6r   $K��Epack://application:,,,/CaficaERP;component/Imagenes/login/usuario.png��6}   $
��Fill=�6�    �� StretchDirection$
 Both=�6�   �� 50   
   -   5        $ image1��50      $
��Left=�6    $��35��6;   $��
47,155,0,0q�6G   $	��Top=�6[   $��35��6s   $K��Epack://application:,,,/CaficaERP;component/Imagenes/login/candado.png��6~   $
��Fill=�6�   �� 51   
   -   5         ��Name$ button��51      $��Entrar��6!   $
��Left=�62   $��44��6M   $��
44,222,0,0q�6Y   $	��Top=�6m   $	��322��6�   ���	#FF19407C���	#FF19407C$��3��6�   $ Office2013DarkGray 6�   $��14(�6  $��Segoe UI Semibold)�6(  $
��Bold"�6G  ��6�   �� *
DCEntrar+6G  ,  &DevExpress.Xpf.Editors.PasswordBoxEdit  52   
   $
��Left=�6   $��40��69   $��
85,152,0,0q�6E   $	��Top=�6Y   $	��282��6q   $ Contraseña��6~   $��2��6�    J� SnapsToDevicePixels .   J� IsHitTestVisible . $ VS2010 6   6�   �� *Login.Contrasena+$ PropertyChanged=� J� InputBindings 53      �� 54      
 �� Key$ Return��6:    �� Command 6   �� *
DCEntrar+6:   56      �� 57   
   -   5        $ button1��57      $
��Left=�6#   $��20��6>   $��	378,0,0,0q�6J   $	��Top=�6]   $��22��6u   $
 None 6�   ��6�   Z� ��6�   �� *CloseCommand+��58      �� 59       �� ImageSource$4 ./CaficaERP;component/Imagenes/login/cerrar.png��6    j� Stretch$ UniformToFill=�6Z   5;      5=      5>      