using Practika.Models;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Practika
{
    public partial class Window7 : Window
    {
        private int _userId;

        // Основной конструктор с ID пользователя
        public Window7(int userId)
        {
            InitializeComponent();
            _userId = userId;
            LoadUserData();
        }

        // Конструктор по умолчанию — для теста (лучше не использовать)
        public Window7()
        {
            InitializeComponent();
            _userId = 1; // временный ID
            LoadUserData();
        }

        private void LoadUserData()
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var user = context.users.Find(_userId);
                    if (user != null)
                    {
                        // Обновляем ФИО
                        var fullNameText = FindName("FullNameTextBlock") as TextBlock;
                        if (fullNameText != null)
                            fullNameText.Text = $"{user.surname} {user.name} {user.patronymic}";

                        // Обновляем дату рождения (др/мр/гр → дд.мм.гггг)
                        var birthText = FindName("BirthDateTextBlock") as TextBlock;
                        if (birthText != null)
                            birthText.Text = user.Date_of_birth.ToString("dd.MM.yyyy");
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    

        // Остальные обработчики
        private void CarButton_Click(object sender, RoutedEventArgs e)
        {
            new Window3().Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new Window8().Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            new Window9().Show();
            this.Close();
        }

        private void LogoButton_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }
    }
}