using Practika.Data;
using Practika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Practika
{
    public partial class Window11 : Window
    {
        private readonly int _currentUserRoleId; // роль текущего пользователя (того, кто вошёл)

        private List<users> users = new List<users>();
        private List<cars> cars = new List<cars>();
        private List<brands> brands = new List<brands>();
        private List<models> models = new List<models>();
        private List<Models.color> color = new List<Models.color>();
        private List<body_type> body_type = new List<body_type>();
        private List<engine_type> engine_type = new List<engine_type>();
        private List<transmission> transmissions = new List<transmission>();
        private List<status> status = new List<status>();
        private List<messages> messages = new List<messages>();

        private string currentSection = "Clients";

        // Основной конструктор — с ролью
        public Window11(int currentUserRoleId)
        {
            InitializeComponent();
            _currentUserRoleId = currentUserRoleId;
            LoadAllDataFromDb();
            SwitchToClients();
            ApplyPermissions(); // ← применяем права сразу после загрузки
        }

        private void LoadAllDataFromDb()
        {
            using var context = new DbService();
            users = context.users.ToList();
            cars = context.cars.ToList();
            brands = context.brands.ToList();
            models = context.models.ToList();
            color = context.color.ToList();
            body_type = context.body_type.ToList();
            engine_type = context.engine_type.ToList();
            transmissions = context.transmissions.ToList();
            status = context.status.ToList();
            messages = context.messages.ToList();
        }

        private void ApplyPermissions()
        {
            // Если текущий пользователь — НЕ админ (role_id != 1), скрываем раздел "Сотрудники"
            if (_currentUserRoleId != 1)
            {
                Employees.Visibility = Visibility.Collapsed;
            }
        }

        private void SwitchToClients()
        {
            SetupUserColumns();
            // Клиенты = role_id == 2
            MainDataGrid.ItemsSource = users.Where(u => u.role_id == 2).ToList();
            MainDataGrid.IsReadOnly = false;
            SectionTitle.Text = "Клиенты";
            currentSection = "Clients";
            HighlightButton(Clients);
        }

        private void SwitchToEmployees()
        {
            // Только админ (role_id == 1) может заходить в этот раздел
            if (_currentUserRoleId != 1)
            {
                MessageBox.Show("У вас нет прав для просмотра сотрудников.", "Доступ запрещён", MessageBoxButton.OK, MessageBoxImage.Warning);
                SwitchToClients();
                return;
            }

            SetupUserColumns();
            // Сотрудники = role_id == 3
            MainDataGrid.ItemsSource = users.Where(u => u.role_id == 3).ToList();
            MainDataGrid.IsReadOnly = false;
            SectionTitle.Text = "Сотрудники";
            currentSection = "Employees";
            HighlightButton(Employees);
        }

        private void SetupUserColumns()
        {
            MainDataGrid.Columns.Clear();
            MainDataGrid.AutoGenerateColumns = false;
            MainDataGrid.IsReadOnly = true;

            MainDataGrid.Columns.Add(new DataGridTextColumn { Header = "id", Binding = new System.Windows.Data.Binding("id") });
            MainDataGrid.Columns.Add(new DataGridTextColumn { Header = "Фамилия", Binding = new System.Windows.Data.Binding("surname") });
            MainDataGrid.Columns.Add(new DataGridTextColumn { Header = "Имя", Binding = new System.Windows.Data.Binding("name") });
            MainDataGrid.Columns.Add(new DataGridTextColumn { Header = "Отчество", Binding = new System.Windows.Data.Binding("patronymic") });
            MainDataGrid.Columns.Add(new DataGridTextColumn { Header = "Email", Binding = new System.Windows.Data.Binding("email") });
            MainDataGrid.Columns.Add(new DataGridTextColumn { Header = "Телефон", Binding = new System.Windows.Data.Binding("phone") });
        }

        private void SwitchToCars()
        {
            MainDataGrid.Columns.Clear();
            MainDataGrid.AutoGenerateColumns = false;
            MainDataGrid.IsReadOnly = false;

            MainDataGrid.Columns.Add(new DataGridTextColumn { Header = "ID", Binding = new System.Windows.Data.Binding("id"), IsReadOnly = true });
            MainDataGrid.Columns.Add(new DataGridTextColumn { Header = "Бренд ID", Binding = new System.Windows.Data.Binding("brand_id") });
            MainDataGrid.Columns.Add(new DataGridTextColumn { Header = "Модель ID", Binding = new System.Windows.Data.Binding("model_id") });
            MainDataGrid.Columns.Add(new DataGridTextColumn { Header = "Год", Binding = new System.Windows.Data.Binding("year") });
            MainDataGrid.Columns.Add(new DataGridTextColumn { Header = "Пробег", Binding = new System.Windows.Data.Binding("mileage") });
            MainDataGrid.Columns.Add(new DataGridTextColumn { Header = "Двигатель ID", Binding = new System.Windows.Data.Binding("engine_type") });
            MainDataGrid.Columns.Add(new DataGridTextColumn { Header = "КПП ID", Binding = new System.Windows.Data.Binding("transmission_id") });
            MainDataGrid.Columns.Add(new DataGridTextColumn { Header = "Кузов ID", Binding = new System.Windows.Data.Binding("body_type_id") });
            MainDataGrid.Columns.Add(new DataGridTextColumn { Header = "Цвет ID", Binding = new System.Windows.Data.Binding("color_id") });
            MainDataGrid.Columns.Add(new DataGridTextColumn { Header = "Цена", Binding = new System.Windows.Data.Binding("price") });

            MainDataGrid.ItemsSource = cars;
            SectionTitle.Text = "Авто в наличии";
            currentSection = "Cars";
            HighlightButton(Cars);
        }

        private void SwitchToMessages()
        {
            var displayMessages = messages.Select(m => new
            {
                m.id,
                Sender = users.FirstOrDefault(u => u.id == m.sender_id)?.name + " " +
                          users.FirstOrDefault(u => u.id == m.sender_id)?.surname ?? "—",
                Receiver = users.FirstOrDefault(u => u.id == m.receiver_id)?.name + " " +
                           users.FirstOrDefault(u => u.id == m.receiver_id)?.surname ?? "—",
                Car = m.car_id.HasValue
                    ? (brands.FirstOrDefault(b => b.id == cars.FirstOrDefault(c => c.id == m.car_id)?.brand_id)?.name ?? "") +
                      " " + (models.FirstOrDefault(md => md.id == cars.FirstOrDefault(c => c.id == m.car_id)?.model_id)?.model_name ?? "") +
                      $" ({cars.FirstOrDefault(c => c.id == m.car_id)?.year ?? 0})"
                    : "—",
                MessageText = m.message,
                SentAt = m.sent_at.ToString("dd.MM.yyyy HH:mm")
            }).ToList();

            MainDataGrid.Columns.Clear();
            MainDataGrid.AutoGenerateColumns = false;
            MainDataGrid.IsReadOnly = true;

            MainDataGrid.Columns.Add(new DataGridTextColumn { Header = "ID", Binding = new System.Windows.Data.Binding("id") });
            MainDataGrid.Columns.Add(new DataGridTextColumn { Header = "От кого", Binding = new System.Windows.Data.Binding("Sender") });
            MainDataGrid.Columns.Add(new DataGridTextColumn { Header = "Кому", Binding = new System.Windows.Data.Binding("Receiver") });
            MainDataGrid.Columns.Add(new DataGridTextColumn { Header = "Авто", Binding = new System.Windows.Data.Binding("Car") });
            MainDataGrid.Columns.Add(new DataGridTextColumn { Header = "Сообщение", Binding = new System.Windows.Data.Binding("MessageText") });
            MainDataGrid.Columns.Add(new DataGridTextColumn { Header = "Время", Binding = new System.Windows.Data.Binding("SentAt") });

            MainDataGrid.ItemsSource = displayMessages;
            SectionTitle.Text = "Сообщения";
            currentSection = "Messages";
            HighlightButton(Messages);
        }

        private void HighlightButton(Button activeButton)
        {
            var buttons = new[] { Clients, Cars, Employees, Messages };
            foreach (var btn in buttons)
                btn.Background = Brushes.WhiteSmoke;
            activeButton.Background = new SolidColorBrush(Colors.LightGray);
        }

        private void NavigationButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                switch (btn.Name)
                {
                    case "Clients": SwitchToClients(); break;
                    case "Employees": SwitchToEmployees(); break;
                    case "Cars": SwitchToCars(); break;
                    case "Messages": SwitchToMessages(); break;
                }
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentSection == "Clients")
            {
                if (MainDataGrid.SelectedItem is users selectedUser)
                {
                    MessageBox.Show(this, $"Данные клиента {selectedUser.name} обновлены.", "Успех");
                    return;
                }
                else
                {
                    MessageBox.Show(this, "Выберите клиента для редактирования.", "Внимание");
                    return;
                }
            }
            else if (currentSection == "Employees")
            {
                // Только админ (role_id == 1) может редактировать сотрудников
                if (_currentUserRoleId != 1)
                {
                    MessageBox.Show(this, "Только администратор может редактировать сотрудников.", "Доступ запрещён");
                    return;
                }

                if (MainDataGrid.SelectedItem is users selectedUser)
                {
                    MessageBox.Show(this, $"Данные сотрудника {selectedUser.name} обновлены.", "Успех");
                    return;
                }
                else
                {
                    MessageBox.Show(this, "Выберите сотрудника для редактирования.", "Внимание");
                    return;
                }
            }
            else if (currentSection == "Cars")
            {
                if (MainDataGrid.SelectedItem is cars selectedCar)
                {
                    MessageBox.Show(this, $"Данные авто ID={selectedCar.id} обновлены.", "Успех");
                    return;
                }
                else
                {
                    MessageBox.Show(this, "Выберите авто для редактирования.", "Внимание");
                    return;
                }
            }
            else
            {
                MessageBox.Show(this, "Редактирование недоступно в этом разделе.", "Информация");
            }
        }

        private void LogoButton_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            new Window6().Show();
            this.Close();
        }
    }
}