   M S B A M L   `   `   `  ����D  @BINGOgame, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:BINGOgame	BINGOgame  5   	       BINGOgame.bingoWindow8   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:BINGOgame     5   	     � Title$(  "改造マリオ ビンゴカード��5   	   $	��800��6   $	��800��6+   .��5	      � ���#b6ffff � RowDefinitions 5
   
   �� 5      $��1* �6   �� 5      $��5* �6   �� 5      $
��0.5* �6   �� 5      $
��0.5* �6    � ColumnDefinitions 5   
   �� 5      $��1* �6    �� 5      $	��30* �6    �� 5      $��1* �6    .+�5   
   � $��0��6   $��1��6   .+�5      �� $��Center=�6    �� TextAlignment$ Center=�65   $��90(�6L   $	��150��6Z   $��0,0,0,0q�6g   $
��Wrap=�6x   $��B  I  N  G  O !��6�   $	��910��6�   5      � 5   
   $��1��6   $��1��6   ���#FFFFFF 5      �� 5      $��1* �6    �� 5      $��1* �6    �� 5      $��1* �6    �� 5       $��1* �6    �� 5!      $��1* �6    �� 5"      $��1* �6    �� 5#      $��1* �6    �� 5$      $��1* �6     5&      �� 5'      $��1* �6$   �� 5(      $��1* �6$   �� 5)      $��1* �6$   �� 5*      $��1* �6$   �� 5+      $��1* �6$   �� 5,      $��1* �6$   �� 5-      $��1* �6$   �� 5.      $��1* �6$   .+�50      �� -   5         ��Name$ TextBlock_0_0��50      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��0��6�   $��0��6�   ���#FFFFFF6  �� 51      -   5        $ TextBlock_0_1��51      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��0��6�   $��1��6�   ���#FFFFFF6  �� 52      -   5        $ TextBlock_0_2��52      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��0��6�   $��2��6�   ���#FFFFFF6  �� 53      -   5        $ TextBlock_0_3��53      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��0��6�   $��3��6�   ���#FFFFFF6  �� 54      -   5        $ TextBlock_0_4��54      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��0��6�   $��4��6�   ���#FFFFFF6  �� 55      -   5        $ TextBlock_0_5��55      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��0��6�   $��5��6�   ���#FFFFFF6  �� 56      -   5        $ TextBlock_0_6��56      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��0��6�   $��6��6�   ���#FFFFFF6  �� 57      -   5        $ TextBlock_0_7��57      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��0��6�   $��7��6�   ���#FFFFFF6  �� 59      -	   5        $ TextBlock_1_0��59      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��1��6�   $��0��6�   ���#FFFFFF6  �� 5:      -
   5        $ TextBlock_1_1��5:      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��1��6�   $��1��6�   ���#FFFFFF6  �� 5;      -   5        $ TextBlock_1_2��5;      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��1��6�   $��2��6�   ���#FFFFFF6  �� 5<      -   5        $ TextBlock_1_3��5<      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��1��6�   $��3��6�   ���#FFFFFF6  �� 5=      -   5        $ TextBlock_1_4��5=      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��1��6�   $��4��6�   ���#FFFFFF6  �� 5>      -   5        $ TextBlock_1_5��5>      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��1��6�   $��5��6�   ���#FFFFFF6  �� 5?      -   5        $ TextBlock_1_6��5?      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��1��6�   $��6��6�   ���#FFFFFF6  �� 5@      -   5        $ TextBlock_1_7��5@      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��1��6�   $��7��6�   ���#FFFFFF6  �� 5B      -   5        $ TextBlock_2_0��5B      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��2��6�   $��0��6�   ���#FFFFFF6  �� 5C      -   5        $ TextBlock_2_1��5C      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��2��6�   $��1��6�   ���#FFFFFF6  �� 5D      -   5        $ TextBlock_2_2��5D      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��2��6�   $��2��6�   ���#FFFFFF6  �� 5E      -   5        $ TextBlock_2_3��5E      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��2��6�   $��3��6�   ���#FFFFFF6  �� 5F      -   5        $ TextBlock_2_4��5F      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��2��6�   $��4��6�   ���#FFFFFF6  �� 5G      -   5        $ TextBlock_2_5��5G      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��2��6�   $��5��6�   ���#FFFFFF6  �� 5H      -   5        $ TextBlock_2_6��5H      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��2��6�   $��6��6�   ���#FFFFFF6  �� 5I      -   5        $ TextBlock_2_7��5I      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��2��6�   $��7��6�   ���#FFFFFF6  �� 5K      -   5        $ TextBlock_3_0��5K      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��3��6�   $��0��6�   ���#FFFFFF6  �� 5L      -   5        $ TextBlock_3_1��5L      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��3��6�   $��1��6�   ���#FFFFFF6  �� 5M      -   5        $ TextBlock_3_2��5M      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��3��6�   $��2��6�   ���#FFFFFF6  �� 5N      -   5        $ TextBlock_3_3��5N      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��3��6�   $��3��6�   ���#FFFFFF6  �� 5O      -   5        $ TextBlock_3_4��5O      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��3��6�   $��4��6�   ���#FFFFFF6  �� 5P      -   5        $ TextBlock_3_5��5P      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��3��6�   $��5��6�   ���#FFFFFF6  �� 5Q      -   5        $ TextBlock_3_6��5Q      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��3��6�   $��6��6�   ���#FFFFFF6  �� 5R      -    5        $ TextBlock_3_7��5R      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��3��6�   $��7��6�   ���#FFFFFF6  �� 5T      -!   5        $ TextBlock_4_0��5T      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��4��6�   $��0��6�   ���#FFFFFF6  �� 5U      -"   5        $ TextBlock_4_1��5U      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��4��6�   $��1��6�   ���#FFFFFF6  �� 5V      -#   5        $ TextBlock_4_2��5V      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��4��6�   $��2��6�   ���#FFFFFF6  �� 5W      -$   5        $ TextBlock_4_3��5W      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��4��6�   $��3��6�   ���#FFFFFF6  �� 5X      -%   5        $ TextBlock_4_4��5X      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��4��6�   $��4��6�   ���#FFFFFF6  �� 5Y      -&   5        $ TextBlock_4_5��5Y      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��4��6�   $��5��6�   ���#FFFFFF6  �� 5Z      -'   5        $ TextBlock_4_6��5Z      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��4��6�   $��6��6�   ���#FFFFFF6  �� 5[      -(   5        $ TextBlock_4_7��5[      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��4��6�   $��7��6�   ���#FFFFFF6  �� 5]      -)   5        $ TextBlock_5_0��5]      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��5��6�   $��0��6�   ���#FFFFFF6  �� 5^      -*   5        $ TextBlock_5_1��5^      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��5��6�   $��1��6�   ���#FFFFFF6  �� 5_      -+   5        $ TextBlock_5_2��5_      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��5��6�   $��2��6�   ���#FFFFFF6  �� 5`      -,   5        $ TextBlock_5_3��5`      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��5��6�   $��3��6�   ���#FFFFFF6  �� 5a      --   5        $ TextBlock_5_4��5a      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��5��6�   $��4��6�   ���#FFFFFF6  �� 5b      -.   5        $ TextBlock_5_5��5b      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��5��6�   $��5��6�   ���#FFFFFF6  �� 5c      -/   5        $ TextBlock_5_6��5c      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��5��6�   $��6��6�   ���#FFFFFF6  �� 5d      -0   5        $ TextBlock_5_7��5d      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��5��6�   $��7��6�   ���#FFFFFF6  �� 5f      -1   5        $ TextBlock_6_0��5f      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��6��6�   $��0��6�   ���#FFFFFF6  �� 5g      -2   5        $ TextBlock_6_1��5g      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��6��6�   $��1��6�   ���#FFFFFF6  �� 5h      -3   5        $ TextBlock_6_2��5h      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��6��6�   $��2��6�   ���#FFFFFF6  �� 5i      -4   5        $ TextBlock_6_3��5i      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��6��6�   $��3��6�   ���#FFFFFF6  �� 5j      -5   5        $ TextBlock_6_4��5j      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��6��6�   $��4��6�   ���#FFFFFF6  �� 5k      -6   5        $ TextBlock_6_5��5k      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��6��6�   $��5��6�   ���#FFFFFF6  �� 5l      -7   5        $ TextBlock_6_6��5l      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��6��6�   $��6��6�   ���#FFFFFF6  �� 5m      -8   5        $ TextBlock_6_7��5m      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��6��6�   $��7��6�   ���#FFFFFF6  �� 5o      -9   5        $ TextBlock_7_1��5o      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��7��6�   $��1��6�   ���#FFFFFF6  �� 5p      -:   5        $ TextBlock_7_0��5p      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��7��6�   $��0��6�   ���#FFFFFF6  �� 5q      -;   5        $ TextBlock_7_2��5q      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��7��6�   $��2��6�   ���#FFFFFF6  �� 5r      -<   5        $ TextBlock_7_3��5r      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��7��6�   $��3��6�   ���#FFFFFF6  �� 5s      -=   5        $ TextBlock_7_4��5s      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��7��6�   $��4��6�   ���#FFFFFF6  �� 5t      ->   5        $ TextBlock_7_5��5t      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��7��6�   $��5��6�   ���#FFFFFF6  �� 5u      -?   5        $ TextBlock_7_6��5u      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��7��6�   $��6��6�   ���#FFFFFF6  �� 5v      -@   5        $ TextBlock_7_7��5v      $��Stretch=�6/   $ Center=�6M   $��Stretch=�6d   $��12(�6�   $��1,0,1,0q�6�   $
��Wrap=�6�   $�� ��6�   $
��Auto��6�   $
��Auto��6�   $��7��6�   $��7��6�   ���#FFFFFF6  �� 5x      
���   �$��1q�6)   $��0��6=   $��0��6J   �� 5y      
���   �$��1q�6)   $��0��6=   $��1��6J   �� 5z      
���   �$��1q�6)   $��0��6=   $��2��6J   �� 5{      
���   �$��1q�6)   $��0��6=   $��3��6J   �� 5|      
���   �$��1q�6)   $��0��6=   $��4��6J   �� 5}      
���   �$��1q�6)   $��0��6=   $��5��6J   �� 5~      
���   �$��1q�6)   $��0��6=   $��6��6J   �� 5      
���   �$��1q�6)   $��0��6=   $��7��6J   �� 5�      
���   �$��1q�6)   $��1��6=   $��0��6J   �� 5�      
���   �$��1q�6)   $��1��6=   $��1��6J   �� 5�      
���   �$��1q�6)   $��1��6=   $��2��6J   �� 5�      
���   �$��1q�6)   $��1��6=   $��3��6J   �� 5�      
���   �$��1q�6)   $��1��6=   $��4��6J   �� 5�      
���   �$��1q�6)   $��1��6=   $��5��6J   �� 5�      
���   �$��1q�6)   $��1��6=   $��6��6J   �� 5�      
���   �$��1q�6)   $��1��6=   $��7��6J   �� 5�      
���   �$��1q�6)   $��2��6=   $��0��6J   �� 5�      
���   �$��1q�6)   $��2��6=   $��1��6J   �� 5�      
���   �$��1q�6)   $��2��6=   $��2��6J   �� 5�      
���   �$��1q�6)   $��2��6=   $��3��6J   �� 5�      
���   �$��1q�6)   $��2��6=   $��4��6J   �� 5�      
���   �$��1q�6)   $��2��6=   $��5��6J   �� 5�      
���   �$��1q�6)   $��2��6=   $��6��6J   �� 5�      
���   �$��1q�6)   $��2��6=   $��7��6J   �� 5�      
���   �$��1q�6)   $��3��6=   $��0��6J   �� 5�      
���   �$��1q�6)   $��3��6=   $��1��6J   �� 5�      
���   �$��1q�6)   $��3��6=   $��2��6J   �� 5�      
���   �$��1q�6)   $��3��6=   $��3��6J   �� 5�      
���   �$��1q�6)   $��3��6=   $��4��6J   �� 5�      
���   �$��1q�6)   $��3��6=   $��5��6J   �� 5�      
���   �$��1q�6)   $��3��6=   $��6��6J   �� 5�      
���   �$��1q�6)   $��3��6=   $��7��6J   �� 5�      
���   �$��1q�6)   $��4��6=   $��0��6J   �� 5�      
���   �$��1q�6)   $��4��6=   $��1��6J   �� 5�      
���   �$��1q�6)   $��4��6=   $��2��6J   �� 5�      
���   �$��1q�6)   $��4��6=   $��3��6J   �� 5�      
���   �$��1q�6)   $��4��6=   $��4��6J   �� 5�      
���   �$��1q�6)   $��4��6=   $��5��6J   �� 5�      
���   �$��1q�6)   $��4��6=   $��6��6J   �� 5�      
���   �$��1q�6)   $��4��6=   $��7��6J   �� 5�      
���   �$��1q�6)   $��5��6=   $��0��6J   �� 5�      
���   �$��1q�6)   $��5��6=   $��1��6J   �� 5�      
���   �$��1q�6)   $��5��6=   $��2��6J   �� 5�      
���   �$��1q�6)   $��5��6=   $��3��6J   �� 5�      
���   �$��1q�6)   $��5��6=   $��4��6J   �� 5�      
���   �$��1q�6)   $��5��6=   $��5��6J   �� 5�      
���   �$��1q�6)   $��5��6=   $��6��6J   �� 5�      
���   �$��1q�6)   $��5��6=   $��7��6J   �� 5�      
���   �$��1q�6)   $��6��6=   $��0��6J   �� 5�      
���   �$��1q�6)   $��6��6=   $��1��6J   �� 5�      
���   �$��1q�6)   $��6��6=   $��2��6J   �� 5�      
���   �$��1q�6)   $��6��6=   $��3��6J   �� 5�      
���   �$��1q�6)   $��6��6=   $��4��6J   �� 5�      
���   �$��1q�6)   $��6��6=   $��5��6J   �� 5�      
���   �$��1q�6)   $��6��6=   $��6��6J   �� 5�      
���   �$��1q�6)   $��6��6=   $��7��6J   �� 5�      
���   �$��1q�6)   $��7��6=   $��0��6J   �� 5�      
���   �$��1q�6)   $��7��6=   $��1��6J   �� 5�      
���   �$��1q�6)   $��7��6=   $��2��6J   �� 5�      
���   �$��1q�6)   $��7��6=   $��3��6J   �� 5�      
���   �$��1q�6)   $��7��6=   $��4��6J   �� 5�      
���   �$��1q�6)   $��7��6=   $��5��6J   �� 5�      
���   �$��1q�6)   $��7��6=   $��6��6J   �� 5�      
���   �$��1q�6)   $��7��6=   $��7��6J   5�      �� 5�   
   
���   �$��2q�6%   $��1��69   $��1��6F   � 5�   
   $��2��6   $��1��6   .+�5�      ��  �� Orientation$  Horizontal=�6   .+�5�      �� $
��Left=�6   $
 Left=�67   $��30(�6L   $	��100��6Z   $��0,0,0,0q�6g   $
��Wrap=�6x   $��シード値：��6�   $
��Auto��6�   �� 5�      -A   5        $ TextBlock_Seed��5�      $
��Left=�64   $
 Left=�6O   $��30(�6d   $	��100��6r   $��0,0,0,0q�6   $
��Wrap=�6�   $�� ��6�   $	��200��6�   �� 5�      $��Right=�6   $ Right=�68   $��30(�6N   $	��100��6\   $��0,0,0,0q�6i   $
��Wrap=�6z   $��Time：��6�   $	��200��6�   �� 5�      -B   5        $ TextBlock_Timer��5�      $��Right=�65   $
 Left=�6Q   $��30(�6g   $	��100��6u   $��0,0,0,0q�6�   $
��Wrap=�6�   $�� ��6�   $	��200��6�   5�      5�      � 5�   
   $��3��6   $��1��6   .+�5�      �� $  Horizontal=�6   .+�5�      �� -C   5        $��Center=�5�      $��	150,0,0,0q�66   $��スタート��6I   $��40��6X   $	��200��6d   6p   �� 5�      -D   5        $��Center=�5�      $��30,0,0,0q�66   $��終了��6H   $��40��6X   $	��200��6d   6p   �� 5�      -E   5        $��Center=�5�      $��	80,10,0,0q�66   $��ルール設定��6I   $��30��6\   $��70��6h   6s   5�      5�      5�      5�      