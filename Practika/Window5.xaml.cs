using Practika.Data;
using Practika.Models;
using System;
using System.Linq;
using System.Windows;

namespace Practika
{
    public partial class Window5 : Window
    {
        public Window5()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Клик по логотипу — возврат на главную
            new MainWindow().Show();
            this.Close();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Переход на форму входа (предположим, что это Window6)
            new Window6().Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            // 1. Проверка заполненности полей
            if (string.IsNullOrWhiteSpace(NameBox.Text))
            {
                MessageBox.Show("Введите имя", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(ContactBox.Text))
            {
                MessageBox.Show("Введите email или номер телефона", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (BirthDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Выберите дату рождения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string password = PasswordBox.Password;
            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Придумайте пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning); // ✅
                return;
            }

            // 2. Определяем, является ли контакт email или телефон
            string email = "";
            string phone = "";

            string contact = ContactBox.Text.Trim();
            if (contact.Contains("@") && contact.Contains("."))
            {
                email = contact;
                phone = null;
            }
            else
            {
                // Можно добавить валидацию номера, но для простоты — просто сохраняем
                phone = contact;
                email = ""; // или оставить null
            }



            // 4. Создаём нового пользователя
            // Предполагается, что роль "Клиент" = 1 (уточните по вашей таблице roles)
            var newUser = new users
            {
                role_id = 2, // ← клиент
                name = NameBox.Text.Trim(),
                surname = "", // вы не просите фамилию — можно оставить пустой или добавить поле
                patronymic = "",
                email = email,
                phone = phone,
                Date_of_birth = BirthDatePicker.SelectedDate.Value,
                password_hash = password,
                created_at = DateTime.Now,
                username = email // или ContactBox.Text — уникальное имя пользователя
            };

            // 5. Сохраняем в БД
            try
            {
                using (var context = new DbService())
                {
                    // Проверка: не существует ли уже пользователь с таким email/телефоном
                    bool exists = context.users.Any(u =>
                        (!string.IsNullOrEmpty(email) && u.email == email) ||
                        (!string.IsNullOrEmpty(phone) && u.phone == phone)
                    );

                    if (exists)
                    {
                        MessageBox.Show("Пользователь с таким email или телефоном уже существует.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    context.users.Add(newUser);
                    context.SaveChanges();
                }

                MessageBox.Show("Регистрация успешно завершена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                // Переход на форму входа
                new Window6().Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}