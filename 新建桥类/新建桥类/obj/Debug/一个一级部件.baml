   M S B A M L   `   `   `  ����G  C新建桥类, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:新建桥类新建桥类  5      %    新建桥类.一个一级部件   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1
myControlsclr-namespace:新建桥类     5        � 	Resources  5	       �� Source�� 5
   
   $ 
style.xaml?�6   %    63   .��5      � $��Stretch=�6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   � $��0��6   $��Center=�6    5      �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   .+�5      $   新建桥类.AddOrDeleteButton  -   5          Name$ 
AddNewItem��5   ;   $��0��6+   6;     5      -   5        $ InsertNewItem��5   ;   $��1��6+   $y�	Collapsed=�6R   5      9� 5,   
   -   5         9�Name$ 二级部件��5,   #   $��2��6   $��Center=�61   $��Center=�6L   $
��10,2q�6n      UIForeground#��[  6|   ��5-      �� 5.       �� Orientation$ 
Horizontal=�6   .+�5/      ��   UITextBlock#��[ 6    $��二级部件集合��6E   �� 50      #��[ 6    $��一级部件名称��6E   �� 51        InputTextBox#��[ 6@   ��6   �� *部件名称+ �� Mode$ TwoWay=�6@   �� 52      #��[ 6    $��权重��6E   �� 53      #��[ 6@   ��6   �� *部件权重+$ TwoWay=�6@   �� 54      $��是否主要部件��6<   #��[  6M   $��Center=�6x   $��Center=�6�   $
��Left=�6�   $	��8,2q�6�    d� 	IsChecked 6   �� *是否主要部件+6�   �� 55      $y�	Collapsed=�6   $��是否存在��6T   #��[  6c   $��Center=�6�   $��Center=�6�   $
��Left=�6�   $	��8,2q�6�    66   �� *	IsExist+6�   56      .��58      �� -   5         ��Name$  二级部件集合ListView��58        UIBackground#��[ 6/   #��[  6Z   $��Disabled=�6�   $��Disabled=�6�   ��.  ��6  �� *二级部件集合+59      5:      5;      5<      