   M S B A M L   `   `   `  ���� K  GEmail404.Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  I)clr-namespace:Email404.Desktop.ViewModelsEmail404.Desktop.ViewModels  !    Email404.Desktop.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     'localclr-namespace:WpfApp1     8vm)clr-namespace:Email404.Desktop.ViewModels       � Title$  Email404 配置��$	��600��$
��1000�� � DataContext 5   /Email404.Desktop.ViewModels.MainWindowViewModel  .��� $��10q� � RowDefinitions �� $��* ��� $
��Auto �.+��� $��0��.@��� $��	接收者��.��� $��10q� � ColumnDefinitions �� $��* ��� $
��Auto �.+��� $��0������ *	Receivers+ �� SelectedItem �� *SelectedReceiver+���� .R���  �� Orientation$ 
Horizontal=�.+���  d� 	IsChecked �� *	Enabled+�� ���� *Mail+�� $��1��$��10,0,0,0q�.+��� $��添加��$��0,0,0,5q�$
��20,5q����� *AddReceiverCommand+�� $��编辑��$��0,0,0,5q�$
��20,5q����� *EditReceiverCommand+�� $��删除��$
��20,5q����� *DeleteReceiverCommand+�� $	��组��.��� $��10q� �� $��* ��� $
��Auto �.+��� $��0������ *Groups+ �� *SelectedGroup+���� .R��� ���� *Name+�� $��1��$��10,0,0,0q�.+��� $��添加��$��0,0,0,5q�$
��20,5q����� *AddGroupCommand+�� $��编辑��$��0,0,0,5q�$
��20,5q����� *EditGroupCommand+�� $��删除��$
��20,5q����� *DeleteGroupCommand+�� $��邮件配置��.��� $��10q�.+��� .+��� $��SMTP 设置��$��10q�.���  �� $
��Auto ��� $��* � �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��
服务器:��$��0��$��0���� $��0��$��1��$��5q����� *
SmtpServer+�� $��发送者邮箱��$��1��$��0���� $��1��$��1��$��5q����� *
SenderMail+�� $��
用户名:��$��2��$��0���� $��2��$��1��$��5q����� *
Username+�� $��密码:��$��3��$��0���� $��3��$��1��$��5q����� *
Password+�� $��启用每日发送��$��0,10,0,0q� �� *	IsDaily+�� $��1��$ 
Horizontal=�$��Right=�$��0,10,0,0q�.+��� $��保存配置��$
��20,5q�$��0,0,10,0q����� *SaveConfigurationCommand+�� $��取消��$
��20,5q����� *CancelCommand+