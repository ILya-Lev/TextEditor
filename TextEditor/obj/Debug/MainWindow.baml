   M S B A M L   `   `   `  ����  
TextEditor    TextEditor.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  
TextEditor��5   	   $	��350��6   $	��525��6)   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $��* �6   .+�5   
   � $��0��6   $��10,10,10,10q�6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��10 �6#   �� 5      $��* �6#   .+�5      �� -   5         ��Name$ 	m_btnSave��5      $��_Save��6(   $��0��6S   $��Stretch=�6c      ButtonStyle#��[  6�   �� 5      -   5        $ 	m_btnOpen��5      $��_Open��6(   $��2��6S   $��Stretch=�6c   #��[  6�   5      �� 5   
   -   5         ��Name$ m_text��5      $��1��6"    �� AcceptsReturn .  �� 
AcceptsTab .  �� TextWrapping$
 Wrap=�6�   " �� VerticalScrollBarVisibility$
 Auto=�6�   ��6/   �� 	 �� Path$	 Content�
 �� UpdateSourceTrigger$
 PropertyChanged=� �� Mode$ TwoWay=�6�   5      5      