   M S B A M L   `   `   `  ����H  DUserInterface, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:UserInterface.ViewsUserInterface.Views  5      A%clr-namespace:UserInterface.UtilitiesUserInterface.Utilities  5      C&clr-namespace:UserInterface.ViewModelsUserInterface.ViewModels  5      O,clr-namespace:UserInterface.DialogViewModelsUserInterface.DialogViewModels  5      E'clr-namespace:UserInterface.DialogViewsUserInterface.DialogViews  5      O,clr-namespace:UserInterface.DetailViewModelsUserInterface.DetailViewModels  5	      E'clr-namespace:UserInterface.DetailViewsUserInterface.DetailViews  5
      -clr-namespace:UserInterfaceUserInterface  5          UserInterface.App   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      3views!clr-namespace:UserInterface.Views     5      ;	utilities%clr-namespace:UserInterface.Utilities     5      =
viewModels&clr-namespace:UserInterface.ViewModels     5      IdialogViewModels,clr-namespace:UserInterface.DialogViewModels     5      >
dialogView'clr-namespace:UserInterface.DialogViews     5      IdetailViewModels,clr-namespace:UserInterface.DetailViewModels     5	      ?detailViews'clr-namespace:UserInterface.DetailViews     5
      -localclr-namespace:UserInterface     5        �� 	Resources  5      ,   &UserInterface.Utilities.ServiceLocator   ServiceLocator  BorderColor  	TextColor  DarkBackgroundBrush  LightBackgroundBrush  BorderBrush �� Color  	TextBrush  SearchX2 �� 	UriSource  SearchX1 	 CreateX2 
 CreateX1 	 AddX2  RemoveX2  
SettingsX2  	StorageX2 �� DataType;   5UserInterface.DetailViewModels.CompanyDetailViewModel1   +UserInterface.DetailViews.CompanyDetailView>   8UserInterface.DialogViewModels.AddCompanyDialogViewModel4   .UserInterface.DialogViews.AddCompanyDialogView �� 
TargetType  BasicTextBox �� Property �� Value �� 	Resources  BasicTextBlock  BasicButton �� Triggers	 P� Property
 P� Value �� BasedOn  ImageButton  BasicListBox��%+  &	        &	      &	 2     &	 Q     &	 p     &	 �     7  &	 �     7  &	 �     &	     &		 e    &	
 �    &	     &	 Z    &	 �    &	     (�� Z    5%      *, +)(�� �    5+      *, +)&	 �    7  &	 �    7  &	 v    7  &	 <    7  &	 �    7    5   
   6#   ��5   
   #bdc3c7��6-   ��5   
   #ecf0f1��6+   ��5   
   #2c3e50��6?   ��5   
   #34495e��6@   �� 5   
   8   6.   �� 5   
   8   6,   �� 5   
   $? 9/Icons/search-white-24dp/2x/outline_search_white_24dp.png?�6(   �� 5   
   $? 9/Icons/search-white-24dp/1x/outline_search_white_24dp.png?�6(   �� 5   
   $@ :/Icons/create-white-24dp/2x/baseline_create_white_24dp.png?�6(   �� 5   
   $@ :/Icons/create-white-24dp/1x/baseline_create_white_24dp.png?�6(   �� 5   
   $9 3/Icons/add-white-24dp/2x/outline_add_white_24dp.png?�6%   �� 5    
   $@ :/Icons/remove-white-24dp/2x/baseline_remove_white_24dp.png?�6(   �� 5!   
   $C =/Icons/settings-white-24dp/2x/outline_settings_white_24dp.png?�6*   �� 5"   
   $A ;/Icons/storage-white-24dp/2x/outline_storage_white_24dp.png?�6)   �� 5%   
   "  6   .R�5&        5'      �� 5+   
   "  6   .R�5,        5-      �� 51   
   " ��6   .�52      ��  � ��
 ���� 6+   �� 53       � ��8   6+   �� 54       � ��$	 100��6)   �� 55       � ��$ 2q�6'    56      ���� 57      '��       " ��6   .�58      ��  �@��CornerRadius$ 2��65   59      5:      5;      �� 5>   
   " ��6   .�5?      ��  � ��
 ���� 6+   �� 5@       � ��8   6+   �� 5A       � ��$ 2q�6'   5B      �� 5E   
   " ��6   .�5F      ��  � ��
 ���� 6+   �� 5G       � ��8   6+    5H      P� 5I      	 � {�
 .  . �5J      ��  � ��
 � � �63   5K      5M      �� 5O   
   " ��6   8   .�5P      ��  � ��$ 0q�60   5Q      �� 5T   
   " ��6   .�5U      ��  � ��
 ���� 6+   �� 5V       � ��8   6+   �� 5W       � ��$ 0q�60   5X      5Z      5[      