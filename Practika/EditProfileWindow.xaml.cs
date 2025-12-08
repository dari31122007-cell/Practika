using Practika.Data;
using Practika.Models;
using System;
using System.Windows;

namespace Practika
{
    public partial class EditProfileWindow : Window
    {
        private readonly int _userId;

        public EditProfileWindow(int userId)
        {
            InitializeComponent();
            _userId = userId;
            LoadUserData();
        }

        private void LoadUserData()
        {
            using (var context = new DbService())
            {
                var user = context.users.Find(_userId);
                if (user != null)
                {
                    SurnameBox.Text = user.surname;
                    NameBox.Text = user.name;
                    PatronymicBox.Text = user.patronymic;
                    BirthDatePicker.SelectedDate = user.Date_of_birth;
                }
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var context = new DbService())
                {
                    var user = context.users.Find(_userId);
                    if (user != null)
                    {
                        user.surname = SurnameBox.Text.Trim();
                        user.name = NameBox.Text.Trim();
                        user.patronymic = PatronymicBox.Text.Trim();
                        user.Date_of_birth = BirthDatePicker.SelectedDate ?? DateTime.Now;

                        context.SaveChanges();
                        MessageBox.Show("Профиль обновлён!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.DialogResult = true;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}