   M S B A M L   `   `   `  ����D  @BINGOgame, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:BINGOgame	BINGOgame  5   	       BINGOgame.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:BINGOgame     5   	   -   5          � Title$.  (改造マリオビンゴ ルール設定��5   	   $	��600��6    $
��1000��6-    � 
ResizeMode$ CanMinimize=�6Q   .��5
      �  � RowDefinitions 5   
   �� 5       � ColumnDefinitions 5   
   �� 5      $��2* �6   �� 5      $��2* �6   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   �� .+�5      ��  �� Orientation$  Horizontal=�6   .+�5      �� -   5        $��all_chk_normal��5      $��	10,10,0,0q�61    d� 	IsChecked$
 TrueY�6�   �� 5      $
��Left=�6   $��20��67   $��0,10,0,0q�6C   $
��Wrap=�6U   $��ノーマルスター��6i   $��70��6x   5      �� 5      -   5        $��listbox_normal��5      $	��520��6D    �� SelectionMode$ Multiple=�6Q   $��	10,0,10,0q�6j   ��6,   �� ��5      �� 5      .R�5      ��  6#   ��  �� Path$	 chk���6B   �� $
 name�5      5       5!      �� 5#   
   $��1��6   .+�5$      �� $  Horizontal=�6   .+�5%      �� -   5        $��all_chk_reds��5%      $��	10,10,0,0q�6/   $
 TrueY�6�   �� 5&      $
��Left=�6   $��20��67   $��0,10,0,0q�6C   $
��Wrap=�6U   $
��Reds��6i   $��70��6u   5'      �� 5)      -   5        $��listbox_reds��5)      $	��520��6B   $ Multiple=�6O   $��	10,0,10,0q�6h   ��6*   �� ��5*      �� 5+      .R�5,      ��  6#   �� $	 chk���6B   �� $
 name�5-      5/      50      �� 52   
   $��2��6   .+�53      �� $  Horizontal=�6   .+�54      �� -   5        $��all_chk_coins��54      $��	10,10,0,0q�60   $
 TrueY�6�   �� 55      $
��Left=�6   $��20��67   $��0,10,0,0q�6C   $
��Wrap=�6U   $��	100 Coins��6i   $��70��6z   56      �� 58      -   5        $��listbox_coins��58      $	��520��6C   $ Multiple=�6P   $��	10,0,10,0q�6i   ��6+   �� ��59      �� 5:      .R�5;      ��  6#   �� $	 chk���6B   �� $
 name�5<      5>      5?      �� 5A   
   $��3��6   .+�5B      �� $
��Left=�6   $��20��63   $��	10,10,0,0q�6?   $
��Wrap=�6R   $��ビンゴサイズ��6f   $	��100��6t   �� 5D      -   5         ��Name$ ComboBox_BingoSize��5D      $
��Left=�63   $��20��6N   $��10,0,0,0q�6Z   	 �� Text$	 5��6l   $	��100��6u   �� 5F      $
��Left=�6   $��20��63   $��	10,10,0,0q�6?   $
��Wrap=�6R   $��シード値(最大9桁)��6f   $	��100��6x   �� 5G      -	   5        
 ��Name$
 TextBox_Seed��5G      $
��Left=�6.   $��20��6I   $��10,0,0,0q�6U    �� TextWrapping$
 Wrap=�6h   $�� ��6|   $	��100��6�   �� 5I      $
��Left=�6   $��20��63   $��	10,10,0,0q�6?   $
��Wrap=�6R   $(��"ウィンドウ拡大率 (0.5~1.5)��6f   $	��160��6�   �� 5J      -
   5        $
 TextBox_Window_Rate��5J      $
��Left=�65   $��20��6P   $��10,0,0,0q�6\   $
 Wrap=�6o   $��1��6�   $	��100��6�   �� 5K      $
��Left=�6   $��40��63   $��	10,10,0,0q�6?   $
��Wrap=�6R   $4��.※標準ウィンドウサイズ
　640×840 ��6f   $	��110��6�   �� 5M      -   5        $��Center=�5M      $��40��62   $��	0,050,0,0q�6>   $(��"スターリスト
再読み込み��6Q   $	��100��6l   6x   �� 5N      -   5        $��Center=�5N      $��40��62   $��0,20,0,0q�6>   $��OK��6P   $	��100��6e   6q   5R      5S      5V      