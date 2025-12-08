using Practika.Data;
using Practika.Models;
using System;
using System.Windows;

namespace Practika
{
    public partial class Window7 : Window
    {
        private readonly int _currentUserId;

        public Window7(int currentUserId)
        {
            InitializeComponent();
            _currentUserId = currentUserId;
            LoadUserProfile();
        }

        private void LoadUserProfile()
        {
            try
            {
                using (var context = new DbService())
                {
                    var user = context.users.FirstOrDefault(u => u.id == _currentUserId);
                    if (user != null)
                    {
                        // Формат: Фамилия Имя Отчество
                        FullNameText.Text = $"{user.surname} {user.name} {user.patronymic}".Trim();

                        // Дата рождения: ДД.ММ.ГГГГ
                        BirthDateText.Text = user.Date_of_birth.ToString("dd.MM.yyyy");
                    }
                    else
                    {
                        FullNameText.Text = "Пользователь не найден";
                        BirthDateText.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки профиля: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EditProfileButton_Click(object sender, RoutedEventArgs e)
        {
            // Открываем окно редактирования профиля (создадим его далее)
            var editWindow = new EditProfileWindow(_currentUserId);
            editWindow.ShowDialog(); // Modal window

            // После закрытия — перезагружаем данные
            LoadUserProfile();
        }

        private void LogoButton_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Избранное
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            // Корзина
        }

        private void CarButton_Click(object sender, RoutedEventArgs e)
        {
            Window3 window = new Window3();
            window.Show();
            this.Close();
        }
    }
}