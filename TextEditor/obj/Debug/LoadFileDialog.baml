   M S B A M L   `   `   `  ����  
TextEditor    TextEditor.LoadFileDialog   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  LoadFileDialog��5   	   $	��300��6    $	��500��6-   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ m_filesGrid��5
   !   $��0��6      AutoGenerateColumns .     EnableRowVirtualization .    
IsReadOnly .    SelectionMode$ Single=�6�      SelectionUnit$ FullRow=�6�      CanUserResizeColumns .  ��6�   �� 	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Id��6<      Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToHeader 6H      
Visibility$ Hidden=�6]      SortDirection$ 	AscendingX�6q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Id+6q     5      $

 Name��6>   $ * 6L    6%   �� *Name+6L     5      -   5        m_createdClmn��$
 Created��5   X   $ SizeToCells 6i    6<   �� *	Created+6i     5      -   5        m_modifiedClmn��$
 Modified��5   Z   $ SizeToCells 6l    6=   �� *
Modified+6l   5      � 5   
   $��1��6   $��10q�6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $
��Auto �6#   �� 5      $��10 �6#   �� 5      $
��Auto �6#   .+�5      �� -   5        $��1��5      $��_Select��6%    �� 	IsDefault .    ButtonStyle#��[  6e   �� 5      -   5        $��3��5      $��_Cancel��6%    �� IsCancel . #��[  6d   5      5      5      