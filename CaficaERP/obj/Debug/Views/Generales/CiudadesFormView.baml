   M S B A M L   `   `   `  ����E  ACaficaERP, Version=1.0.0.37, Culture=neutral, PublicKeyToken=nullE'clr-namespace:CaficaERP.Views.GeneralesCaficaERP.Views.Generales  5      0    *CaficaERP.Views.Generales.CiudadesFormView   5      a ]DevExpress.Xpf.Core.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:CaficaERP.Views.Generales     5      e aDevExpress.Xpf.Controls.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aCdxwui7http://schemas.devexpress.com/winfx/2008/xaml/windowsui  5      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5      $	��200��5	      $	��420��6/   .��5      �� .@�5   
   �� $��Datos de la ciudad��6   .��5      �   � RowDefinitions  5   
   �� 5      $��10 �6   �� 5      $��35 �6   �� 5      $��35 �6   �� 5      $��35 �6   �� 5      $��35 �6   �� 5      $��10 �6    � ColumnDefinitions 5   
   �� 5      $	��100 �6   �� 5      $
��300* �6   .+�5   
   �� -   5         ��Name$ label��5      $��Nombre:��6   $��1��62   �� 5   
   -   5        $ label1��5      $��Pais:��6    $��2��61   �� 5   
   -   5        $ label2��5      $��Estado:��6    $��3��63   �� 5   
   -   5        $ label3��5      $��
Municipio:��6    $��4��66   %  DevExpress.Xpf.Editors.TextEdit  5    
   $��1��6   $��1��6'   )  #DevExpress.Xpf.Editors.TextEditBase   	MaxLength$ 50��6�      Mask$/ )[A-ZÑÁÉÍÓÚ][A-ZÑÁÉÍÓÚ ]{0,44}��6�      Text 64   �� *Item.Nombre+ �� UpdateSourceTrigger$ PropertyChanged=� �� ValidatesOnDataErrors . 6�   )  #DevExpress.Xpf.Editors.ComboBoxEdit  5!   
   $��1��6   $��2��6+   +  %DevExpress.Xpf.Editors.LookUpEditBase   AutoComplete . '  !DevExpress.Xpf.Editors.ButtonEdit	   IsTextEditable$
	 TrueX�6M   
   DisplayMember$
 Nombre��6�      ValueMember$ Id��6�      ItemsSource 6c   �� *	LstPaises+%  DevExpress.Xpf.Editors.BaseEdit   	EditValue 6�   �� *Item.PaisId+$ PropertyChanged=� �� Mode$ TwoWay=� .    SelectedItem 6  �� *PaisSeleccionado+  5"   
   $��1��6   $��3��6+    . $
	 TrueX�6M   $
 Nombre��6�   $ Id��6�    6c   �� *
LstEstados+ 6�   �� *Item.EstadoId+$ PropertyChanged=� .  6  �� *EstadoSeleccionado+  5#   
   $��1��6   $��4��6+    . $
	 TrueX�6M   $
 Nombre��6�   $ Id��6�    6c   �� *LstMunicipios+ 6�   �� *Item.MunicipioId+$ PropertyChanged=� .  6  �� *MunicipioSeleccionado+5$      5%      5&      5'      