   M S B A M L   `   `   `  ����B  >TestApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:TestAppTestApp  5   	       TestApp.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:TestApp     5   	   -   5          � Title$  
MainWindow��5   	   $��506.3��6   $��849.6��6+    � 	Resources 5	         
MusicStaff  SixteenthNote  SixteenthNoteReverse  
EighthNote  EighthNoteReverse  QuarterNote  QuarterNoteReverse  HalfNote  HalfNoteReverse 	 	WholeNote 
 TwoExtraBar  OneExtraBar  
PlayButton  
StopButton  PauseButton��%�  &	        &	 2     &	 g     &	 �     &	 �     &	     &	 A    &	 {    &	 �    &		 �    &	
     &	 F    &	 y    &	 �    &	 �    �� 5
   
   $��Resources/MusicStaff.png��6#   �� 5   
   $!��Resources/SixteenthNote.png��6&   �� 5   
   $(��"Resources/SixteenthNoteReverse.png��6-   �� 5   
   $��Resources/EighthNote.png��6#   �� 5   
   $%��Resources/EighthNoteReverse.png��6*   �� 5   
   $��Resources/QuarterNote.png��6$   �� 5   
   $&�� Resources/QuarterNoteReverse.png��6+   �� 5   
   $��Resources/HalfNote.png��6!   �� 5   
   $#��Resources/HalfNoteReverse.png��6(   �� 5   
   $��Resources/WholeNote.png��6"   �� 5   
   $��Resources/TwoExtraBar.png��6$   �� 5   
   $��Resources/OneExtraBar.png��6$   �� 5   
   $#��Resources/Icon/PlayButton.png��6#   �� 5   
   $#��Resources/Icon/StopButton.png��6#   �� 5   
   $$��Resources/Icon/PauseButton.png��6$   5      .��5      � $
��Left=�6   $	��400��6&   $	��Top=�63   $	��843��6K   .+�5   
   o� $
��Left=�6   $��25��6*   $	��Top=�66   $	��843��6N   $��0,25,0,0q�6Z   .@�5      	� -   5         	�Name$ SixteenthToggle��5      
 � Tag$ 0��63   #��[Bd�6;   $��20��6j   $��20��6u   ��5      �� 5       �� ImageSource$! Resources/SixteenthNote.png��6!    j� Stretch$ Uniform=�6K   5!      	� 5"      -   5        $ EighthToggle��5"      $ 1��60   #��[Bd�68   $��20��6g   $��20��6r   ��5#      �� 5$      $ Uniform=�6!   $ Resources/EighthNote.png��63   5&      	� 5'      -   5        $ QuarterToggle��5'      $ 2��61    d� 	IsChecked$
 TrueY�69   #��[Bd�6J   $��20��6y   $��20��6�   ��5(      �� 5)      $ Uniform=�6!   $ Resources/QuarterNote.png��63    �� RelativeTransform 5*      V� 5+      .~�5,   "   ��  �� CenterY$	 0.5Q�61   	 �� CenterX$		 0.5Q�6?   �� 5-   "   
 �� CenterY$	
 0.5Q�60    �� CenterX$	 0.5Q�6>   �� 5.   "    �� CenterY$	 0.5Q�62    �� CenterX$	 0.5Q�6@   T� 5/   "    T� X$	 0.1Q�65   50      52      54      	� 55      -   5        $ 
HalfToggle��55      $ 3��6.   #��[Bd�66   $��20��6e   $��20��6p   ��56      �� 57      $ Uniform=�6!   $ Resources/HalfNote.png��63    58      V� 59      .~�5:   "   �� $	 0.5Q�61   $		 0.5Q�6?   �� 5;   "   $	
 0.5Q�60   $	 0.5Q�6>   �� 5<   "   $	 0.5Q�62   $	 0.5Q�6@   T� 5=   "   $	 0.1Q�65   5>      5@      5B      	� 5C      -   5        $ WholeToggle��5C      $ 4��6/   #��[Bd�67   $��20��6f   $��20��6q   ��5D      �� 5E      $ Uniform=�6!   $ Resources/WholeNote.png��63    5F      V� 5G      .~�5H   "   �� $	 0.5Q�61   $		 0.5Q�6?    �� ScaleX$	 1.5Q�6M    �� ScaleY$	 1.5Q�6Z   �� 5I   "   $	
 0.5Q�60   $	 0.5Q�6>   �� 5J   "   $	 0.5Q�62   $	 0.5Q�6@   T� 5K   "    T� Y$ -0.525Q�65   $ 0.175Q�6@   5L      5N      5P      5Q      �� 5R   
   -   5         ��Name$ 
MainCanvas��5R      $
��Left=�6%   $	��100��6@   $	��Top=�6M   $	��800��6e   $��	10,58,0,0q�6q   .+�5S      � $��40��6   $	��800��6   $��Center=�6+   $��Center=�6H   
 �� Top$ 30��6c   ��5T      �� 5U      $ Resources/MusicStaff.png��6!   5W      5X      �� 5Y   
   -   5        $ MainCanvas_Copy��5Y      $
��Left=�6*   $	��100��6E   $	��Top=�6R   $	��800��6j   $��
10,158,0,0q�6v   .+�5Z      � $��40��6   $	��800��6   $��Center=�6+   $��Center=�6H   $ 30��6c   ��5[      �� 5\      $ Resources/MusicStaff.png��6!   5^      5_      �� 5`   
   -	   5        $ MainCanvas_Copy1��5`      $
��Left=�6+   $	��100��6F   $	��Top=�6S   $	��800��6k   $��
10,258,0,0q�6w   .+�5a      � $��40��6   $	��800��6   $��Center=�6+   $��Center=�6H   $ 30��6c   ��5b      �� 5c      $ Resources/MusicStaff.png��6!   5e      5f      �� 5g   
   -
   5        $ MainCanvas_Copy2��5g      $
��Left=�6+   $	��100��6F   $	��Top=�6S   $	��800��6k   $��10,358,0,-58q�6w   .+�5h      � $��40��6   $	��800��6   $��Center=�6+   $��Center=�6H   $ 30��6c   ��5i      �� 5j      $ Resources/MusicStaff.png��6!   5l      5m      o� 5n   
   $
��Left=�6   $��25��6*   $	��Top=�66   $	��843��6N   .@�5o      �� -   5         ��Name$ 
PlayButton��5o      $�� ��6)   $
��Left=�64   $	��Top=�6O   $��20��6g   $��20��6r    J� RenderTransformOrigin$ 	0.89,0.67&�6�   ��5p      �� 5q      $# Resources/Icon/PlayButton.png��6!   $ Uniform=�6M    5r      V� 5s      .~�5t   "   �� $	 0.5Q�61   $		 0.5Q�6?   $	 1.5Q�6M   $	 1.5Q�6Z   �� 5u   "   $	
 0.5Q�60   $	 0.5Q�6>   �� 5v   "   $	 0.5Q�62   $	 0.5Q�6@   T� 5w   "   5x      5z      5|      5}      5~      5      