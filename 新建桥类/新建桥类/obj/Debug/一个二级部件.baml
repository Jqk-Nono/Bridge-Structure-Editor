   M S B A M L   `   `   `  ����G  C新建桥类, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:新建桥类新建桥类  5      %    新建桥类.一个二级部件   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1
myControlsclr-namespace:新建桥类     5        � 	Resources  5	       �� Source�� 5
   	   $ 
style.xaml?�6   %    .��5      � $��Stretch=�6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   � $��0��6   $��Center=�6    5      �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   .+�5      $   新建桥类.AddOrDeleteButton  -   5          Name$ 
AddNewItem��5   ;   $��0��6+   6;     5      -   5        $ InsertNewItem��5   ;   $��1��6+   $y�	Collapsed=�6R   5      9� 51   
   -   5         9�Name$ 检查指标��51   #   $��2��6   $��Center=�61   $
��10,2q�6L      UIForeground#��[  6Z   ��52      �� 53       �� Orientation$ 
Horizontal=�6   .+�54      ��   UITextBlock#��[ 6    $��检查指标��6E   �� 55      #��[ 6    $��二级部件名称��6E   �� 56        InputTextBox#��[ 6@   ��6   �� *部件名称+ �� Mode$ TwoWay=�6@   �� 58      $y�	Collapsed=�6    #��[ 67   $��权重��6\   �� 59      $y�	Collapsed=�6   #��[ 6W   ��65   �� *部件权重+$ TwoWay=�6W   �� 5;      #��[ 6    $��	构件数��6E   �� 5<      #��[ 6?   ��6   �� *	构件数+$ TwoWay=�6?   �� 5>      $y�	Collapsed=�6   $��是否主要部件��6S   #��[  6d   $��Center=�6�   $��Center=�6�   $
��Left=�6�   $	��8,2q�6�    d� 	IsChecked 66   �� *是否主要部件+6�   �� 5@      $y�	Collapsed=�6   $��是否存在��6T   #��[  6c   $��Center=�6�   $��Center=�6�   $
��Left=�6�   $	��8,2q�6�    66   �� *	IsExist+6�   5B      .��5D      �� -   5         ��Name$ 指标集合ListView��5D        UIBackground#��[ 6-   #��[  6X   $��Disabled=�6�   $��Disabled=�6�   ��.  ��6  �� *指标集合+5E      5F      5G      5H      