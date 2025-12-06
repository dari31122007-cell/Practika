using System;
using System.Windows;
using System.Windows.Controls;

namespace Practika
{
    public partial class Window5 : Window
    {
        public Window5()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            Window6 window6 = new Window6();
            window6.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            // Проверка имени
            if (string.IsNullOrWhiteSpace(NameBox.Text))
            {
                System.Windows.MessageBox.Show("Пожалуйста, введите ваше имя.", "Ошибка", MessageBoxButton.OK);
                return;
            }

            // Проверка контакта (номер/почта)
            if (string.IsNullOrWhiteSpace(ContactBox.Text))
            {
                System.Windows.MessageBox.Show("Пожалуйста, введите ваш номер телефона или email.", "Ошибка", MessageBoxButton.OK);
                return;
            }

            // Проверка даты рождения
            if (BirthDatePicker.SelectedDate == null)
            {
                System.Windows.MessageBox.Show("Пожалуйста, выберите дату рождения.", "Ошибка", MessageBoxButton.OK);
                return;
            }

            // Проверка пароля
            if (string.IsNullOrWhiteSpace(PasswordBox.Password))
            {
                System.Windows.MessageBox.Show("Пожалуйста, введите пароль.", "Ошибка", MessageBoxButton.OK);
                return;
            }

            Window7 Window7 = new Window7();
            Window7.Show();
            this.Close();
        }
    }
}