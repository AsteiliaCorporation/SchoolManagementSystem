   M S B A M L   `   `   `  ���� Q  MSchoolManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:SchoolManagementSystem.MVVM.View SchoolManagementSystem.MVVM.View  2    ,SchoolManagementSystem.MVVM.View.LogbookView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     @local.clr-namespace:SchoolManagementSystem.MVVM.View        B500#���   
�������.����   ScrollViewer#��[ .��� .+�&   System.Windows.Controls.DataGrid      AutoGenerateColumns  .    CanUserAddRows .     CanUserDeleteRows .     
IsReadOnly .    SelectionMode$ Single=�   EnableRowVirtualization . $��	Open Sans)�$��16(�   	RowHeight$ 36Q�   HeadersVisibility$ Column=�$��16q�  DataGrid#��[    Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn	   Width5  /System.Windows.Controls.DataGridLengthConverter$
	 1.5* 
   Header$
 HeaderWithDataGrid��   
IsReadOnly .     CellTemplate �� .R�� .+�  $��InsertedDataGrid��-     .     RowHeaderWidth$ 0Q� 0  *System.Windows.Controls.DataGridTextColumn  $
 InsertedHeader1��$
	 1.5*  .  1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Number+  $
 InsertedHeader2��$
	 1.5*  .   �� *Name+  $
 InsertedHeader3��$
	 1.5*  .   �� *Grades+�� $��SimpleValue��$y�Hidden=����� *Age+ �� Triggers ��  �� Value$ Hidden�� �� Binding �� *ShowInsertedGrid+.a���  �� 
TargetName$ InsertedDataGrid�� �� Property � y� �� Value$ 	Collapsed=��� $ SimpleValue�� � y�$ Visible=�  $
	 1.5* $
 HeaderWithDataGrid�� .   �� .R�� .+�  $��InsertedDataGrid2��-     . $ 0Q�   $
 InsertedHeader1��$
	 1.5*  .   �� *Name+  $
 InsertedHeader2��$
	 1.5*  .   �� *Age+  $
 InsertedHeader3��$
	 1.5*  .   �� *Name+�� $��SimpleValue��$y�Hidden=����� *Age+ �� $ Hidden�� �� *ShowInsertedGrid+.a��� $ InsertedDataGrid2�� � y�$ 	Collapsed=��� $ SimpleValue�� � y�$ Visible=�