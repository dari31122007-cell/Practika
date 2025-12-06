using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Practika
{
    public partial class Window11 : Window
    {
        private System.Windows.Controls.Button _currentActiveButton;

        public Window11()
        {
            InitializeComponent();
            _currentActiveButton = BtnClients;
            LoadData("clients");
        }

        private void NavigationButton_Click(object sender, RoutedEventArgs e)
        {
            var clickedButton = sender as System.Windows.Controls.Button;

            if (_currentActiveButton != null)
            {
                _currentActiveButton.Background = new SolidColorBrush(Colors.WhiteSmoke);
            }

            clickedButton.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0xBF, 0xBF, 0xBF));
            _currentActiveButton = clickedButton;

            string section = "";
            string tableType = "";

            if (clickedButton == BtnClients)
            {
                section = "Клиенты";
                tableType = "clients";
            }
            else if (clickedButton == BtnCars)
            {
                section = "Авто в наличии";
                tableType = "cars";
            }
            else if (clickedButton == BtnGifts)
            {
                section = "Подарки";
                tableType = "gifts";
            }
            else if (clickedButton == BtnEmployees)
            {
                section = "Сотрудники";
                tableType = "employees";
            }
            else if (clickedButton == BtnMessages)
            {
                section = "Сообщения";
                tableType = "messages";
            }

            SectionTitle.Text = section;
            LoadData(tableType);
            MainDataGrid.IsReadOnly = true;
            EditButton.Content = "Редактировать";
        }

        private void LoadData(string tableType)
        {
            switch (tableType)
            {
                case "clients":
                    MainDataGrid.ItemsSource = new List<dynamic>
                    {
                        new { ID = 1, ФИО = "Иванов И.И.", Телефон = "+79991234567", Email = "ivanov example.com" },
                        new { ID = 2, ФИО = "Петров П.П.", Телефон = "+79997654321", Email = "petrov example.com" }
                    };
                    break;

                case "cars":
                    MainDataGrid.ItemsSource = new List<dynamic>
                    {
                        new { ID = 101, Модель = "BMW X5", Год = 2023, Цена = "6 500 000 ₽" },
                        new { ID = 102, Модель = "BMW 3 Series", Год = 2024, Цена = "4 200 000 ₽" }
                    };
                    break;

                case "gifts":
                    MainDataGrid.ItemsSource = new List<dynamic>
                    {
                        new { ID = 201, Подарок = "Коврики", Колво = 15 },
                        new { ID = 202, Подарок = "Чехлы", Колво = 8 }
                    };
                    break;

                case "employees":
                    MainDataGrid.ItemsSource = new List<dynamic>
                    {
                        new { ID = 301, ФИО = "Сидоров С.С.", Должность = "Менеджер" },
                        new { ID = 302, ФИО = "Кузнецов К.К.", Должность = "Техник" }
                    };
                    break;

                case "messages":
                    MainDataGrid.ItemsSource = new List<dynamic>
                    {
                        new { ID = 401, Отправитель = "Клиент 1", Тема = "Уточнение по авто", Дата = "01.12.2025" },
                        new { ID = 402, Отправитель = "Клиент 2", Тема = "Запись на ТО", Дата = "02.12.2025" }
                    };
                    break;

                default:
                    MainDataGrid.ItemsSource = null;
                    break;
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (MainDataGrid.IsReadOnly)
            {
                MainDataGrid.IsReadOnly = false;
                EditButton.Content = "Сохранить";
            }
            else
            {
                MainDataGrid.IsReadOnly = true;
                EditButton.Content = "Редактировать";
                System.Windows.MessageBox.Show("Изменения сохранены.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void LogoButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var settingsWindow = new Admin();
            settingsWindow.Owner = this; 
            bool? result = settingsWindow.ShowDialog(); 

            if (result == true)
            {
            }
        }
    }
}