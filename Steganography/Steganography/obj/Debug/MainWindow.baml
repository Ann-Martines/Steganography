   M S B A M L   `   `   `  ����H  DSteganography, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:SteganographySteganography  5   	       Steganography.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Steganography     5   	   -   5          � Title$  Steganography��5   	    � WindowStartupLocation$ CenterScreen=�5	   	   $	��400��5
   	   $	��630��6   ��5      �� 5   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5      �  � Color$ White��6    � Offset$	 0.5Q�6)   � 5      $ 	#FF88EDFD��6   $ 1Q�6-   � 5      $ 	#FF80EEFF��6   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��50* �6   �� 5      $��50 �6   �� 5      $
��215* �6   �� 5      $
��310* �6    � RowDefinitions 5   
   �� 5      $��25 �6   �� 5      $
��200* �6   �� 5       $
��100* �6   �� 5!      $��50 �6   .+�5$   
   �� -   5        $	��Im1��5$      $
��Fill=�5%      $��5q�5&      $��1��5'      $��3��5(      5)      �� 5+   
   -   5        $	��Im2��5+      $
��Fill=�5,      $��5q�5-      $��1��5.      $��3��5/      6"   �� 51   
   -   5         ��Name$ lbAfter��51      $��After��52      $��3��53      $��1��54      $��48(�55      $��98,18,69,96q�56      $
��Bold"�57      	 J� Opacity$		 0.4Q�58      
 J� RenderTransformOrigin$
 0.5,0.5&�59      ��5:      �� 5;       �� Color$ 	#FF9B9B9B��6"    �� Opacity$	 0.8Q�64   5=      �� 5?   
   -   5        $ lbBefore��5?      $��Before��5@      $��1��5A      $��1��5B      $��2��5C      $��48(�5D      $��20,18,55,112q�5E      $
��Bold"�5F      $		 0.4Q�5G      $
 0.5,0.5&�5H      ��5I      �� 5J      $ 	#FF9B9B9B��6"   $	 0.8Q�64   5L      �� 5N   
   $��1q�6   $��5q�5O      $��0��5P      $��1��5Q      $��3��5R      ��5S      �� 5T      $
 Gray��6"   $	 0.8Q�6/   5V      �� 5X   
   $��1q�6   ���	#FF747171$��5q�5Z      $��3��5[      $��1��5\      �� 5]   
   -   5        $	��Txt��5]      $��0��5^      $��2��5_      $��4��5`      $��5,5,5,20q�5b       �� TextWrapping$
 Wrap=�5c      $��Visible=�5d      6G   �� 5f   
   -   5        $ lbTxt��5f      $��25��5g      $��2��5h      $��3��5i      $��Bottom=�5j      $
��Left=�5k      $	��314��5l      �� 5n   
   -   5        $ lbSimbol��5n      $��2��5o      $��3��5p      $��0,0,77,0q�5q      $��25��5r      $��Bottom=�5s      �� 5u   
   -	   5        $��
BtnEncrypt��5u      $��Encrypt��5v      $��3��5w      $��3��5x      $��10q�5y      $��20(�5{      $��Trebuchet MS)�5|      $
��Bold"�5}      ��5~      
� 5      .��5�      � $ 	#FF6161F3��6#   $ 1Q�65   � 5�      $ White��6#   5�      5�      �� 5�   
   -
   5        $��
BtnDecrypt��5�      $��Decrypt��5�      $��3��5�      $��3��5�      $��10q�5�      $��20(�5�      $��Trebuchet MS)�5�      $
��Bold"�5�      ��5�      
� 5�      .��5�      � $ 	#FF6161F3��6#   $ 1Q�65   � 5�      $ White��6#   5�      5�      o� 5�   
   ���	#FF6E6EFF$��1q�6'   .@�5�      m� $�� File��6   $
��Thin"�5�      $��Trebuchet MS)�5�      $��14(�5�      
�������$��01q�5�      $��25��5�      $��50��5�      ��5�      
� 5�      .��5�      � $ 	#FFC7BAFF��6'   $ 1Q�69   � 5�      $ White��6'   5�      .@�5�      m� -   5        $
��Load��5�      5�      m� 5�      -   5        $
��Exit��5�      6)   5�      �� 5�      $��1��6   $	��122��6%   5�      o� 5�   
   $��1��6   ���	#FF6E6EFF$��1q�5�      .@�5�      m� -   5        $
��Help��5�      $
��Thin"�5�      $��Trebuchet MS)�5�      $��14(�5�      
�������$��01q�5�      $��25��5�      $��50��5�      ��5�      
� 5�      .��5�      � $ 	#FFC7BAFF��6'   $ 1Q�69   � 5�      $ White��6'   5�      5�      5�      o� 5�   
   $��2��6   ���	#FF6E6EFF$��1q�5�      $��0,0,79,0q�5�      .@�5�      m� -   5        $��About the program��5�      $
��Thin"�5�      $��Trebuchet MS)�5�      $��14(�5�      
�������$��01q�5�      $��25��5�      $	��133��5�      ��5�      
� 5�      .��5�      � $ 	#FFC7BAFF��6'   $ 1Q�69   � 5�      $ White��6'   5�      5�      5�      5�      5�      