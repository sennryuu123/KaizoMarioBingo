   M S B A M L   `   `   `  ���� D  @BINGOgame, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:BINGOgame	BINGOgame      BINGOgame.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:BINGOgame     -     � Title$.  (改造マリオビンゴ ルール設定��$	��600��$
��1000�� � 
ResizeMode$ NoResize=�.���  � RowDefinitions ��  � ColumnDefinitions �� $��2* ��� $��2* ��� $��1* ��� $��1* �.+��� .+���  �� Orientation$  Horizontal=�.+��� -   $��all_chk_normal��$��	10,10,0,0q� d� 	IsChecked$
 TrueY��� $
��Left=�$��20��$��0,10,0,0q�$
��Wrap=�$��ノーマルスター��$��70���� -   $��listbox_normal��$	��520�� �� SelectionMode$ Multiple=�$��	10,0,10,0q����� ���� .R���  ��  �� Path$	 chk����� $
 name��� $��1��.+��� $  Horizontal=�.+��� -   $��all_chk_reds��$��	10,10,0,0q�$
 TrueY��� $
��Left=�$��20��$��0,10,0,0q�$
��Wrap=�$
��Reds��$��70���� -   $��listbox_reds��$	��520��$ Multiple=�$��	10,0,10,0q����� ���� .R���  �� $	 chk����� $
 name��� $��2��.+��� $  Horizontal=�.+��� -   $��all_chk_coins��$��	10,10,0,0q�$
 TrueY��� $
��Left=�$��20��$��0,10,0,0q�$
��Wrap=�$��	100 Coins��$��70���� -   $��listbox_coins��$	��520��$ Multiple=�$��	10,0,10,0q����� ���� .R���  �� $	 chk����� $
 name��� $��3��.+��� $
��Left=�$��20��$��	10,10,0,0q�$
��Wrap=�$��ビンゴサイズ��$	��100���� -    ��Name$ ComboBox_BingoSize��$
��Left=�$��20��$��10,0,0,0q�	 �� Text$	 5��$	��100���� $
��Left=�$��20��$��	10,10,0,0q�$
��Wrap=�$��シード値(最大9桁)��$	��100���� -	   
 ��Name$
 TextBox_Seed��$
��Left=�$��20��$��10,0,0,0q� �� TextWrapping$
 Wrap=�$�� ��$	��100���� -
   $��Center=�$��40��$��	0,050,0,0q�$(��"スターリスト
再読み込み��$	��100���� -   $��Center=�$��40��$��0,20,0,0q�$��OK��$	��100��