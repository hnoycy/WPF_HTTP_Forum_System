   M S B A M L   `   `   `  ����F  BForumClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ForumClientForumClient  5   	       ForumClient.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:ForumClient     5   	     � Title$  论坛主页��5   	   $	��450��6   $	��800��6#   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   � $��0��6   ���#EFEFEF � ColumnDefinitions 5      �� 5      �� 5      $
��Auto �6#   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��10q�62   .+�5      �� $��img/系统图标.png��6   $��45��6.   �� 5      $��论坛管理信息系统��6   �� 5      -   5         ��Name$ UsernameText��5      $��5q�62   $	��115��6=   $
��test��6I   �� 5      -   5        $ PasswordText��5      $��5q�61   $	��115��6<   $	��123��6H   �� 5      -   5         ��Name$ LoginButton��5      $��登录��6.   $��5q�6;   6F   5      5      � 5!   
   $��1��6    5"      �� 5#      $
��Auto �6#   �� 5$      .+�5'      �� $��1��6   $
��Auto=�6+   .��5(      �� -   5         ��Name$ postStackPanel��5(   )   $��10q�6   5*      5+      5,      � 5.   
   $��2��6   ���#EFEFEF 5/      �� 50      $
��Auto �6#   �� 51      �� 52      $
��Auto �6#   .+�55      �� -   5        $ NewPostTitleTextBox��55      $��0��63   $��10q�6C   $	��200��6O   $��输入帖子标题��6[   �� 56      -   5        $ NewPostContentTextBox��56      $��1��65   $��10q�6E   $	��400��6Q   $��输入帖子内容��6]   �� 57      -   5        $ PublishButton��57      $��2��6,   $��发布��6<   $��10q�6I   6U   58      59      5:      