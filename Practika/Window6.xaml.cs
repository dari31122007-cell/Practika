using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Practika
{
    /// <summary>
    /// Логика взаимодействия для Window6.xaml
    /// </summary>
    public partial class Window6 : Window
    {
        public Window6()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window5 window5 = new Window5();
            window5.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string login = LoginBox.Text.Trim();
            string password = PasswordBox.Password;
            if (login == "Admin" && password == "Admin")
            {
                Window11 window11 = new Window11();
                window11.Show();
                this.Close();
            }
            if (login == "User" && password == "User")
            {
                Window7 window7 = new Window7();
                window7.Show();
                this.Close();
            }

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                System.Windows.MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                using (var context = new Practika.Models.AppDbContext())
                {
                    // Ищем пользователя по email ИЛИ телефону
                    var user = context.users
                        .FirstOrDefault(u => u.email == login || u.phone == login);

                    if (user != null && BCrypt.Net.BCrypt.Verify(password, user.password_hash))
                    {
                        // Успешная аутентификация
                        if (user.role_id == 3) // Например, 3 = администратор
                        {
                            var adminWindow = new Window11();
                            adminWindow.Show();
                        }
                        else
                        {
                            // Обычный пользователь — передаём ID в Window7 (если нужно)
                            var userWindow = new Window7();
                            userWindow.Show();
                        }
                        this.Close();
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Неверный логин или пароль.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Ошибка подключения к базе данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
