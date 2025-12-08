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
            // Валидация
            if (string.IsNullOrWhiteSpace(NameBox.Text))
            {
                System.Windows.MessageBox.Show("Пожалуйста, введите ваше имя.", "Ошибка", MessageBoxButton.OK);
                return;
            }

            if (string.IsNullOrWhiteSpace(ContactBox.Text))
            {
                System.Windows.MessageBox.Show("Пожалуйста, введите ваш номер телефона или email.", "Ошибка", MessageBoxButton.OK);
                return;
            }

            if (BirthDatePicker.SelectedDate == null)
            {
                System.Windows.MessageBox.Show("Пожалуйста, выберите дату рождения.", "Ошибка", MessageBoxButton.OK);
                return;
            }

            if (string.IsNullOrWhiteSpace(PasswordBox.Password))
            {
                System.Windows.MessageBox.Show("Пожалуйста, введите пароль.", "Ошибка", MessageBoxButton.OK);
                return;
            }

            try
            {
                // Определяем email или телефон
                string contact = ContactBox.Text.Trim();
                string email = contact.Contains("@") ? contact : "";
                string phone = contact.Contains("@") ? null : contact;

                // Хешируем пароль (минимальная защита)
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(PasswordBox.Password);

                // Создаём пользователя
                var newUser = new Practika.Models.users
                {
                    name = NameBox.Text.Trim(),
                    surname = "",           // можно оставить пустым или добавить поле в форму
                    patronymic = "",
                    username = NameBox.Text.Trim(), // или оставить пустым
                    email = email,
                    phone = phone,
                    Date_of_birth = BirthDatePicker.SelectedDate.Value,
                    password_hash = passwordHash,
                    role_id = 1,            // 1 = клиент
                    created_at = DateTime.Now
                };

                // Сохраняем в базу
                using (var context = new Practika.Models.AppDbContext())
                {
                    context.users.Add(newUser);
                    context.SaveChanges();
                }

                // Успешно — переходим дальше

                Window7 window7 = new Window7();
                window7.Show();
                this.Close();
                // После context.SaveChanges() вы получаете newUser.id
            
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Ошибка при регистрации: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}