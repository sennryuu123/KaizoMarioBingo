   M S B A M L   `   `   `  ���� D  @BINGOgame, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:BINGOgame	BINGOgame      BINGOgame.bingoWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:BINGOgame       � Title$(  "改造マリオ ビンゴカード��$	��525��$	��400��.��� ���#b6ffff � RowDefinitions �� $��1* ��� $��5* ��� $
��0.5* ��� $
��0.5* � � ColumnDefinitions �� $��1* ��� $	��30* ��� $��1* �.+�� $��0��$��1��.+�(� .���� $��Center=� �� TextAlignment$ Center=�$��90(�$	��150��$��0,0,0,0q�$
��Wrap=�$��B  I  N  G  O !��$	��910��� -    �Name$ Grid_Bingo_Card��$��1��$��1�����#FFFFFF�� 
���   �$��-1,-1,-1,-1q�$��2q�$��1��$��1��� $��2��$��1��.+�(� .����  �� Orientation$  Horizontal=�$
��1360��.+��� -   $��Center=�$��0,0,0,30q�$��50(�$��シード値��$��70��$
��Auto���� $
��Left=�$
 Left=�$��50(�$	��100��$��0,0,0,0q�$
��Wrap=�$	��：��$
��Auto���� -    ��Name$ TextBlock_Seed��$
��Left=�$
 Left=�$��50(�$	��100��$��0,0,0,0q�$
��Wrap=�$�� ��$
��Auto���� -   $��Right=�$��
400,0,0,30q�$��50(�$
��Time��$��70��$
��Auto���� $��Right=�$ Right=�$��50(�$	��100��$��0,0,0,0q�$
��Wrap=�$	��：��$
��Auto���� -   $ TextBlock_Timer��$��Right=�$
 Left=�$��50(�$	��100��$��0,0,0,0q�$
��Wrap=�$��00:00:00��$
��Auto��� $��3��$��1��.+�(� .���� $  Horizontal=�.+��� -   $��Center=�$��	150,0,0,0q�$��25(�$��スタート��$��40��$	��180���� -   $��Center=�$��30,0,0,0q�$��25(�$��終了��$��40��$	��180���� -   $��Center=�$��	80,10,0,0q�$��15(�$��ルール設定��$��30��$��70��