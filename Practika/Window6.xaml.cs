using Practika.Data;
using Practika.Models;
using System;
using System.Linq;
using System.Windows;

namespace Practika
{
    public partial class Window6 : Window
    {
        public Window6()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Регистрация
            new Window5().Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string login = LoginBox.Text.Trim();
            string password = PasswordBox.Password;

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                using (var context = new DbService())
                {
                    // Ищем пользователя по email ИЛИ телефону + точному совпадению пароля (без хеша!)
                    var user = context.users
                        .FirstOrDefault(u =>
                            (u.email == login || u.phone == login) &&
                            u.password_hash == password // ← сравниваем напрямую!
                        );

                    if (user != null)
                    {
                        MessageBox.Show($"Добро пожаловать, {user.name}!", "Успешный вход", MessageBoxButton.OK, MessageBoxImage.Information);

                        // Открываем окно в зависимости от роли
                        // После успешной авторизации:
                        if (user.role_id == 1) // админ
                        {
                            new Window11(1).Show();
                        }
                        else if (user.role_id == 3) // сотрудник
                        {
                            new Window11(3).Show();
                        }
                        // Клиенты (role_id == 2) идут в другое окно:
                        // После успешной авторизации:
                        if (user.role_id == 2) // клиент
                        {
                            new Window7(user.id).Show(); // ← передаём ID
                        }

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения к базе данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            // Можно оставить пустым
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }
    }
}