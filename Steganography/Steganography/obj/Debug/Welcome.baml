   M S B A M L   `   `   `  ����H  DSteganography, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:SteganographySteganography  5   	       Steganography.Welcome   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Steganography     5   	     � Title$  Welcome��5   	    � WindowStartupLocation$ CenterScreen=�5	   	   $	��400��5
   	   $	��730��5   	   $	��400��5   	   $	��730��6   ��5      �� 5   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5      �  � Color$ White��6    � Offset$	 0.5Q�6)   � 5      $ 	#FF88EDFD��6   $ 1Q�6-   � 5      $ 	#FF80EEFF��6   5      .��5      �  � RowDefinitions 5   
   �� 5      $��60 �6   �� 5      $	��150 �6   .+�5   
   �� $��Welcome��6   $��35(�5      $��59,10,361,0q�5      $��Medium"�5      $��Trebuchet MS)�6$   5      �� 5   
   -   5        $��lb��5      $H��BThis program is developed for enciphering of the text in the image��5       $��1��5!      $��15(�6   $��	0,0,0,120q�6+   5"      �� 5#   
   -   5        $��lbCrypt��5#      $��Encrypt��5$      $��20(�5%      $��32,31,338,79q�6   $��1��64   6C   �� 5&   
   -   5        $��	lbEncrypt��5&      $Y��STo cipher the text in the image, it is necessary to load the picture (File -> Load)��5'      $��15(�5(      $��19,57,-19,62q�6   $��1��64   6C   �� 5)   
   -   5        $��
lbEncrypt1��5)      $!��To enter the desirable text��5*      $��15(�5+      $��19,77,-19,42q�6   $��1��64   6C   �� 5,   
   -   5        $��
lbEncrypt3��5,      $\��VTo press the Encrypt button. Near the loaded picture there will be a ciphered picture.��5-      $��15(�5.      $��19,97,-19,25q�6   $��1��64   6C   �� 5/   
   -   5        $��
lbEncrypt4��5/      $F��@The ciphered image will be automatically kept in the same folder��50      $��15(�51      $��45,117,-45,0q�6   $��1��64   6C   �� 53   
   $��578,20,31,74q�6   $��1��6&    J� Opacity$	 0.8Q�63   $
��Fill=�6A   ��54      �� 55       �� 	UriSource$3 -pack://application:,,,/Resources/Untitled.jpg?�6   57      �� 59   
   $��616,109,10,22q�6   $��1��6'   $
��Fill=�64   ��5:      �� 5;      $/ )pack://application:,,,/Resources/Text.jpg?�6   5=      �� 5?   
   $��578,151,0,-20q�6   $��1��6'   $
��Fill=�64   ��5@      �� 5A      $8 2pack://application:,,,/Resources/BtnEncryotjpg.jpg?�6   5C      �� 5E   
   $��578,215,0,-84q�6   $��1��6'   $
��Fill=�64   ��5F      �� 5G      $8 2pack://application:,,,/Resources/BtnDecryotjpg.jpg?�6   5I      �� 5K   
   -   5        $��	lbDecrypt��5K      $��Decrypt��5L      $��20(�5M      $��32,138,338,-28q�6   $��1��66   6E   �� 5N   
   -   5        $��lbDencrypt1��5N      $S��MTo decrypt the text from the image, you need to load the image (File -> Load)��5O      $��15(�5P      $��19,164,-19,-42q�6   $��1��66   6E   �� 5Q   
   -	   5        $��lbDencrypt2��5Q      $^��XTo press the Decrypt button. Near the loaded picture there will be a deciphered picture.��5R      $��15(�5S      $��19,184,-19,-68q�6   $��1��66   6E   �� 5T   
   -
   5        $��
lbDecrypt3��5T      $C��=The ciphered text to appear in a window for input of the text��5U      $��15(�5V      $��19,204,0,-84q�6   $��1��64   6C   �� 5W   
   -   5        $��
lbDecrypt4��5W      $H��BThe deciphered image will be automatically kept in the same folder��5X      $��15(�5Y      $��45,224,0,-104q�6   $��1��65   6D   �� 5[   
   -   5        $��btnOK��5[      $��OK��5\      $��15(�5]      $��Trebuchet MS)�5^      $
��Bold"�5_      $��309,274,293,-147q�5a      $��1��6+   ��5b      
� 5c      .��5d      � $ 	#FF9D61F3��6   $ 1Q�61   � 5e      $ White��6   5f      5h      5j      5k      