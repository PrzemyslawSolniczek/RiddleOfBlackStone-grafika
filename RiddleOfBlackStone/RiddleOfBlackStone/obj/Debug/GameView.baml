   M S B A M L   `   `   `  ����M  IRiddleOfBlackStone, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:RiddleOfBlackStoneRiddleOfBlackStone  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      !    RiddleOfBlackStone.GamePage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      2local clr-namespace:RiddleOfBlackStone     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      0sys&clr-namespace:System;assembly=mscorlib  5        N� Title$  GamePage��5      $	��613��6    � 	Resources 5         PageBackgroundColor �� Color  PageBorderColor  YourImageBrushKey �� ImageSource  PageBackgroundBrush j� Stretch��%�   &	        &	 !     &	 B     &	 p     �� 5   
   $ #2c1b01��66   �� 5   
   $ #FFCC00��62   �� 5   
   $ pictures/kolumny.png��6/   �� 5   
   $ pictures/hieroglify.jpg��61   $ UniformToFill=�6W   5       N� 
Background 5      �� 5   
    �� ResourceKey$ PageBackgroundBrush��6"   .��5      � $	��497��6    � RowDefinitions 5   
   �� 5      $	��400 �6   �� 5       $
��Auto �6   �� 5!      $��* �6   .+�5$   
    � -   5          �Name$ 	mainFrame��5$      $��0,0,0,66q�6$   $��3��66   �� 5%   
   -   5        	 ��Name$	 	gameImage��5%      $��0��6$   $��90,10,87,72q�61   ��6F   �� *Source+�� 5'   
   $��
0,328,0,49q�6   $��3��6%   #���  66   ._�5(      �� -   5        
 ��Name$
 TextDescription��5(      $��
0,29,156,0q�6R   
�������$��12(�6y   $��3��6�   $��Right=�6�   $	��291��6�   ��61   �� *TextDescription+ � Triggers 5)      :� 5*       :� RoutedEvent$ FrameworkElement.Loaded��6#   .[�5+      �� .��5,      �� .��5-   "   W�  �� TargetProperty$ Opacity�5.       W� From$ 0X�5/      	 W� To$ 1X�50       g� Duration$ 0:0:2D�51      52      53      54      56      57      �� 58   
   -   5        $��choiceListBox��58      $��1��6P   ���#FFCC00���#2c1b01$��0,48,0,0q�6�   $��2��6�   $��Center=�6  ��6'   �� *DisplayedChoices+��59      �� 5:      .R�5;      �� ��6    �� 5<      *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5>      +  %Microsoft.Xaml.Behaviors.EventTrigger  5?         	EventName$ SelectionChanged��6!   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5@      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6,   �� *ChoiceSelectedCommand+   CommandParameter 5A   ,   �� *SelectedIndex+ �� ElementName$ choiceListBox��5B      5D      �� 5E   
   $'��!pictures/statua22_transparent.png��6   $
��Left=�6;   $	��318��6V   $��0,10,0,0q�6c   $	��Top=�6u   $	��103��6�   $��UniformToFill=�6�   �� 5F   
   $&�� pictures/statua2_transparent.png��6   $
��Left=�6:   $	��317��6U   $��
518,11,0,0q�6b   $	��Top=�6v   $��94��6�   $��UniformToFill=�6�   5G      5H      