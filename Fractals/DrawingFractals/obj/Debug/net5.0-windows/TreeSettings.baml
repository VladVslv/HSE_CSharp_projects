   M S B A M L   `   `   `  ����J  FDrawingFractals, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:DrawingFractalsDrawingFractals  5   	   "    DrawingFractals.TreeSettings   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:DrawingFractals     5   	     � Title$>  8Параметры фрактального дерева��5   	   $	��210��6/   $	��420��6<   $	��210��6H   $	��420��6X   .��5	      � .+�5
   
   �� -   5         ��Name$ KoefTextBox��5
      $
��Left=�6)   $��	10,10,0,0q�6D   $L��FКоэффицент отношения длин отрезков: 0.5��6W   $
��Wrap=�6�   $	��Top=�6�   $	��290��6�   �� 5   
   -   5        $ FirstAngleTextBox��5      $
��Left=�6/   $��	10,56,0,0q�6J   $T��NУгол наклона первого отрезка(в градусах): 15��6]   $
��Wrap=�6�   $	��Top=�6�   $	��290��6�   �� 5   
   -   5        $ SecondAngleTextBox��5      $
��Left=�60   $��
10,102,0,0q�6K   $T��NУгол наклона второго отрезка (в градусах):15��6_   $
��Wrap=�6�   $	��Top=�6�   $	��290��6�   �� 5   
   -   5         ��Name$ 
KoefSlider��5      $��
10,33,10,0q�6%   $	��Top=�69    � Minimum$	 0.5Q�6Q    � Maximum$
 0.75Q�6_    �� IsSnapToTickEnabled$
 True��6n    �� TickFrequency$
 0.01Q�6�   6�   �� 5   
   -   5        $ FirstAngleSlider��5      $��
10,79,10,0q�6+   $	��Top=�6?   $ 15Q�6W   $ 45Q�6d   $
 True��6q   $ 1Q�6�   6�   �� 5   
   -   5        $ SecondAngleSlider��5      $��10,125,10,0q�6,   $	��Top=�6A   $ 15Q�6Y   $ 45Q�6f   $
 True��6s   $ 1Q�6�   6�   �� 5   
   -   5        $)��#Отменить изменения��5      $
��Left=�6.   $��
10,148,0,0q�6I   $	��Top=�6]   6u   �� 5   
   -   5        $+��%Применить изменения��5      $��Right=�6/   $��
0,148,10,0q�6K   $	��Top=�6_   6w   5      5      