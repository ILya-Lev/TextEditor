   M S B A M L   `   `   `  ����  
TextEditor    TextEditor.SaveDialog   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  
SaveDialog��5   	   $	��190��6   $	��300��6)   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   .+�5   
   �� -   5         ��Name$ m_label��5   !   $��0��6   $��Enter file name: ��62      
LabelStyle#��[  6K   �� 5   
   -   5         ��Name$ m_textBoxFileName��5      $��1��6   $�� ��6:   $��20q�6B   6N   � 5   
   $��2��6    � ColumnDefinitions 5      �� 5      $��2* �6#   �� 5      $��* �6#   �� 5      $��10 �6#   �� 5      $��* �6#   �� 5      $��10 �6#   .+�5      �� -   5         ��Name$ m_btnOk��5   %   $��1��6   $	��_Ok��66   $��60��6D    �� 	IsDefault .   ButtonStyle#��[ 6|   �� 5      -   5        $��3��5      $��_Cancel��6%   $��60��67    �� IsCancel . #��[ 6r   5      5      5      