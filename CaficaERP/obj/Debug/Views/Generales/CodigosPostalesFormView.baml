   M S B A M L   `   `   `  ����E  ACaficaERP, Version=1.0.0.37, Culture=neutral, PublicKeyToken=nullE'clr-namespace:CaficaERP.Views.GeneralesCaficaERP.Views.Generales  5      7    1CaficaERP.Views.Generales.CodigosPostalesFormView   5      a ]DevExpress.Xpf.Core.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:CaficaERP.Views.Generales     5      e aDevExpress.Xpf.Controls.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aCdxwui7http://schemas.devexpress.com/winfx/2008/xaml/windowsui  5      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5      $	��240��5
      $	��420��6   .��5      �� .@�5   
   �� $��Datos del código��6   .��5      �   � RowDefinitions  5   
   �� 5      $��10 �6   �� 5      $��35 �6   �� 5      $��35 �6   �� 5      $��35 �6   �� 5      $��35 �6   �� 5      $��35 �6   �� 5      $��10 �6    � ColumnDefinitions 5   
   �� 5      $	��100 �6   �� 5      $
��300* �6   .+�5   
   �� -   5         ��Name$ label��5      $��Código:��6   $
��Left=�61   $��10,1,0,0q�6L   $��1��6^   $	��Top=�6k   �� 5   
   -   5        $ label1��5      $��Pais:��6    $
��Left=�60   $��10,1,0,0q�6K   $��2��6]   $	��Top=�6j   �� 5    
   -   5        $ label2��5       $��Estado:��6    $
��Left=�62   $��10,1,0,0q�6M   $��3��6_   $	��Top=�6l   �� 5!   
   -   5        $ label3��5!      $��
Municipio:��6    $
��Left=�65   $��10,1,0,0q�6P   $��4��6b   $	��Top=�6o   �� 5"   
   -   5        $ label4��5"      $��Ciudad:��6    $
��Left=�62   $��10,1,0,0q�6M   $��5��6_   $	��Top=�6l   %  DevExpress.Xpf.Editors.TextEdit  5#   
   $��1��6   $��1��6'   )  #DevExpress.Xpf.Editors.TextEditBase   	MaxLength$ 50��6�      Mask$ [0-9]{0,44}��6�      Text 64   �� *Item.Codigo+ �� UpdateSourceTrigger$ PropertyChanged=� �� ValidatesOnDataErrors . 6�   )  #DevExpress.Xpf.Editors.ComboBoxEdit  5$   
   $��1��6   $��2��6+   +  %DevExpress.Xpf.Editors.LookUpEditBase   AutoComplete . '  !DevExpress.Xpf.Editors.ButtonEdit	   IsTextEditable$
	 TrueX�6M   
   DisplayMember$
 Nombre��6�      ValueMember$ Id��6�      ItemsSource 6c   �� *	LstPaises+%  DevExpress.Xpf.Editors.BaseEdit   	EditValue 6�   �� *Item.PaisId+$ PropertyChanged=� �� Mode$ TwoWay=� .    SelectedItem 6  �� *PaisSeleccionado+  5%   
   $��1��6   $��3��6+    . $
	 TrueX�6M   $
 Nombre��6�   $ Id��6�    6c   �� *
LstEstados+ 6�   �� *Item.EstadoId+$ PropertyChanged=� .  6  �� *EstadoSeleccionado+  5&   
   $��1��6   $��4��6+    . $
	 TrueX�6M   $
 Nombre��6�   $ Id��6�    6c   �� *LstMunicipios+ 6�   �� *Item.MunicipioId+$ PropertyChanged=� .  6  �� *MunicipioSeleccionado+  5'   
   $��1��6   $��5��6+    . $
	 TrueX�6M   $
 Nombre��6�   $ Id��6�    6c   �� *LstCiudades+ 6�   �� *Item.CiudadId+$ PropertyChanged=� .  6  �� *CiudadSeleccionada+5(      5)      5*      5+      