   M S B A M L   `   `   `  ����M  IRiddleOfBlackStone, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:RiddleOfBlackStone.ViewModelRiddleOfBlackStone.ViewModel  5   P       YourNamespace.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @	viewmodel*clr-namespace:RiddleOfBlackStone.ViewModel     6P     � Title$  Riddle of Black Stone��5   	   $
��1000��6'   $	��600��64   .��5
      � ��5   
   �� 5       �� ImageSource$ pictures/tlo.png��6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   r� -   5         r�Name$ mediaElement��5       � 5   
   -   5          �Name$ 	mainFrame��5        � NavigationUIVisibility$ Hidden=�6#   �� 5   
   $��Riddle of Black Stone��6   $��Comic Sans MS)�61   ���#d2691e$��26(�6a   $
��Bold"�6o   $��Center=�6�   $��
0,65,0,434q�6�   $��1��6�   $	��280��6�   �� 5   
   -   5        $��menuListBox��5      $��1��6   ���#FFCC00���#2c1b01$��20(�6\   $��Center=�6j   $��
0,271,0,81q�6�    J� RenderTransformOrigin$ 0.487,0.539&�6�   $	��280��6�   ���#FF9900$��4q�5   (   $��Comic Sans MS)�6<   .@�5      �� .��6   Menu6    �� 5       .��6   Rozpocznij nową grę6/   �� 5!      .��6   Odczytaj grę6(   �� 5"      .��6   
O autorach6&   �� 5#      .��6   Opcje6!   �� 5$      .��6   Wyjdź z gry6'   ��5'      �� 5(       �� 
TargetType" ��6   .�5)      ��  �� Property � ��	 �� Value$	 Center=�6C   �� 5*       � ��$	 Center=�6A   5+      5-      5.      5/      