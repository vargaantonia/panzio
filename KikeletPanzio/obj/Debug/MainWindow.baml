   M S B A M L   `   `   `  ����H  DKikeletPanzio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:KikeletPanzioKikeletPanzio  5          KikeletPanzio.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      -localclr-namespace:KikeletPanzio     5        � Title$  Kikelet Panzió��5      $	��800��6$   $	��800��61   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��450 �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��10q�6%   .+�5      �� $��5q�6   $
��Bold"�6#   $��Ügyfél Regisztráció��65   $��16(�6P   �� 5      $��5q�6   .+�5      �� $ ��Ügyfelek regisztrációja��6   $��16(�6;   $
��Bold"�6I   $
��Wrap=�6[   �� 5       �� Orientation$ 
Horizontal=�6   $��5q�66   .+�5      �� $��Center=�6    $��Név:��6;   $	��100��6G   $
��Wrap=�6S   �� 5      -   5         ��Name$ tbxUgyfelNev��5      $	��200��64   5      �� 5      $ 
Horizontal=�6   $��5q�66   .+�5      �� $��Center=�6    $��Születési dátum: ��6;   $	��100��6T   $
��Wrap=�6`   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ 	dpSzulIdo��5   !   $	��200��64   5      �� 5      $ 
Horizontal=�6   $��5q�66   .+�5      �� $��Center=�6    $��E-mail: ��6;   $	��100��6K   $
��Wrap=�6W   �� 5       -   5        $ tbxEmail��5       $	��200��60   5!      �� 5"      -   5        $��Regisztráció��5"      $	��100��60   $��5q�6<   6G   5#      �� 5&      $��5q�6   .+�5'      �� $��Regisztált ügyfelek��6   $
��Bold"�67   $��16(�6I   $
��Wrap=�6W   �� 5(      -   5         ��Name$ lbRegisztraltUgyfel��5(      $	��150��67   5)      �� 5,      $��0��6   $��10q�6)   .+�5-      �� $��5q�6   $
��Bold"�6'   $��Statisztikák��69   $��16(�6M   $
��Wrap=�6[   �� 5/      $��5q�6   $
��Bold"�6'   $��Összes bevétel��69   $
��Wrap=�6O   �� 50      -   5         ��Name$ txtOsszesBevetel��50   L   $��5q�6   $��
Bevétel: ��6'   $
��Wrap=�68   6L   �� 52      $��5q�6   $
��Bold"�6'   $��Legtöbbet kiadott szoba��69   $
��Wrap=�6X   �� 53      -   5        $ txtLegtobbetKiadottSzoba��53   P   $��5q�6   $��Szoba száma: ��6'   $
��Wrap=�6<   6P   �� 55      $��5q�6   $
��Bold"�6'   $1��+Fizetett összeg szerint csökkenő sorrend��69   $
��Wrap=�6i   �� 56      -   5        $ lbFizetettOsszegSzerint��56      $	��150��6;   57      58      �� 5;   
   $��1��6   $��10q�6%   .+�5<      �� $��5q�6   $
��Bold"�6#   $��Szállásfoglalás��65   $��16(�6L   �� 5=      $��5q�6   .+�5>      �� $��16(�6   $��Szállásfoglalás��6*   $
��Bold"�6A   $
��Wrap=�6S   �� 5?      $��5q�6   $��Ügyfél��6'   $
��Wrap=�65   �� 5@      -	   5         ��Name$ cbxUgyfelek��5@      $	��200��60   $��5q�6<    �� DisplayMemberPath$
 Name��6G   �� 5A      $��5q�6   $��Szobák��6'   $
��Wrap=�65   �� 5B      -
   5        $ 	lbxSzobak��5B      $	��200��6.   $��5q�6:   �� 5C      $��5q�6   $��Érkezés dátuma:��6'   $
��Wrap=�6>     5D      -   5        $ dpErkezesDatum��5D      $��5q�65   6@   �� 5E      $��5q�6   $��Távozás dátuma:��6'   $
��Wrap=�6>     5F      -   5        $ dpTavozasDatum��5F      $��5q�65   6@   �� 5G      $��5q�6   $��	Főszám:��6'   $
��Wrap=�66   �� 5H      -   5        $ 	tbxFoszam��5H      $��5q�6-   �� 5I      $��5q�6   $��Éjszaka száma:��6'   $
��Wrap=�6=   �� 5J      -   5        $ tbxEjszakakSzama��5J      $��5q�66   5K      �� 5L      -   5        $��	btnFoglal��5L   ?   $��	Foglalás��6   $	��100��6(   $��5q�64   6P   �� 5O      $��5q�6   .+�5P      �� $��Foglalt szobák��6   $
��Bold"�62   $��16(�6D   $
��Wrap=�6R   �� 5Q      -   5        $ lbFoglaltSzobak��5Q      $	��150��63   5R      5S      5T      5U      