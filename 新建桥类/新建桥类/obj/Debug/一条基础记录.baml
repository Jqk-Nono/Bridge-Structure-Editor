   M S B A M L   `   `   `  ����G  C新建桥类, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:新建桥类新建桥类  5      %    新建桥类.一条基础记录   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1
myControlsclr-namespace:新建桥类     5        � 	Resources  5	       �� Source�� 5
   	   $ 
style.xaml?�6   %    .��5      � $��Stretch=�6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   � $��0��6   $��Center=�6    5      �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   .+�5      $   新建桥类.AddOrDeleteButton  -   5          Name$ 
AddNewItem��5   ;   $��0��6+   6;     5      -   5        $ InsertNewItem��5   ;   $��1��6+   $y�	Collapsed=�6R   5      �� 5   
   $��1��6      UITextBlock#��[  6$   $��描述名称��6I   �� 5   
   $��2��6     InputTextBox#��[ 68   ��6"   �� *描述名称+68   �� 5   
   $��3��6   #��[  6$   $��最大长度��6I   �� 5   
   $��4��6   #��[ 68   ��6"   �� *最大长度+68   5       5!      