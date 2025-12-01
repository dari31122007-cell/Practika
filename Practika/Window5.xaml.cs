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
    public partial class Window5 : Window
    {
        public Window5()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameBox.Text.Trim();
            string contact = ContactBox.Text.Trim();
            DateTime? birthDate = BirthDatePicker.SelectedDate;
            string password = PasswordBox.Password;

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Пожалуйста, введите имя.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrEmpty(contact))
            {
                MessageBox.Show("Пожалуйста, введите номер или почту.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!birthDate.HasValue)
            {
                MessageBox.Show("Пожалуйста, выберите дату рождения.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Пожалуйста, придумайте пароль.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // ✅ Все данные получены — можно регистрировать
            MessageBox.Show($"Регистрация успешна!\nИмя: {name}\nКонтакт: {contact}",
                "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Например, перейти на окно входа
            MessageBox.Show("Переход на страницу входа...");
            // var loginWindow = new Window6();
            // loginWindow.Show();
            // this.Close();
        }
    }
}