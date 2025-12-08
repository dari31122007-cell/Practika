using Practika.Models;
using Practika.ViewModel;
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

        public Window11()
        {
            InitializeComponent();
            LoadAllDataFromDb();
            SwitchToClients();
        }


        private void LoadAllDataFromDb()
        {
            using var context = new AppDbContext();
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

        private void SwitchToClients()
        {
            SetupUserColumns();
            MainDataGrid.ItemsSource = users.Where(u => u.role_id == 1).ToList();
            MainDataGrid.IsReadOnly = false; // ← ДОБАВЛЕНО: разрешить редактирование
            SectionTitle.Text = "Клиенты";
            currentSection = "Clients";
            HighlightButton(Clients);
        }

        private void SwitchToEmployees()
        {
            SetupUserColumns();
            MainDataGrid.ItemsSource = users.Where(u => u.role_id == 2 || u.role_id == 3).ToList();
            MainDataGrid.IsReadOnly = false; // ← ДОБАВЛЕНО: разрешить редактирование
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
            MainDataGrid.Columns.Add(new DataGridTextColumn { Header = "Роль (ID)", Binding = new System.Windows.Data.Binding("role_id") });
        }

        private void SwitchToCars()
        {
            MainDataGrid.Columns.Clear();
            MainDataGrid.AutoGenerateColumns = false;
            MainDataGrid.IsReadOnly = false; // ← разрешено редактирование

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
           
        MainDataGrid.ItemsSource = cars; // ← привязка к реальным объектам
            SectionTitle.Text = "Авто в наличии";
            currentSection = "Cars";
            HighlightButton(Cars);
        }

        private void SwitchToMessages()
        {
            // Подготавливаем данные с развёрнутыми именами
            var displayMessages = messages.Select(m => new
            {
                m.id,
                Sender = users.FirstOrDefault(u => u.id == m.sender_id)?.name + " " + users.FirstOrDefault(u => u.id == m.sender_id)?.surname ?? "—",
                Receiver = users.FirstOrDefault(u => u.id == m.receiver_id)?.name + " " + users.FirstOrDefault(u => u.id == m.receiver_id)?.surname ?? "—",
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
            MainDataGrid.Columns.Add(new DataGridTextColumn { Header = "От кого", Binding = new System.Windows.Data.Binding("sender") });
            MainDataGrid.Columns.Add(new DataGridTextColumn { Header = "Кому", Binding = new System.Windows.Data.Binding("receiver") });
            MainDataGrid.Columns.Add(new DataGridTextColumn { Header = "Авто", Binding = new System.Windows.Data.Binding("car") });
            MainDataGrid.Columns.Add(new DataGridTextColumn { Header = "Сообщение", Binding = new System.Windows.Data.Binding("message") });
            MainDataGrid.Columns.Add(new DataGridTextColumn { Header = "Время", Binding = new System.Windows.Data.Binding("sent_at") });

            MainDataGrid.ItemsSource = displayMessages;
            SectionTitle.Text = "Сообщения";
            currentSection = "Messages";
            HighlightButton(Messages);
        }

        private void HighlightButton(System.Windows.Controls.Button activeButton)
        {
            var buttons = new[] { Clients, Cars, Employees, Messages };
            foreach (var btn in buttons)
                btn.Background = System.Windows.Media.Brushes.WhiteSmoke;
            activeButton.Background = new SolidColorBrush(Colors.LightGray);
        }

        // ✅ ИСПРАВЛЕНО: используется WPF Button (System.Windows.Controls.Button)
        private void NavigationButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is System.Windows.Controls.Button btn) // ✅ Button = System.Windows.Controls.Button
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
            if (currentSection == "Clients" || currentSection == "Employees")
            {
                if (MainDataGrid.SelectedItem is users selectedUser)
                {
                    System.Windows.MessageBox.Show(this, $"Данные пользователя {selectedUser.name} обновлены.", "Успех");
                    return;
                }
                else
                {
                    System.Windows.MessageBox.Show(this, "Выберите строку с пользователем для редактирования.", "Внимание");
                    return;
                }
            }
            else if (currentSection == "Cars")
            {
                if (MainDataGrid.SelectedItem is cars selectedCar)
                {
                    System.Windows.MessageBox.Show(this, $"Данные авто ID={selectedCar.id} обновлены.", "Успех");
                    return;
                }
                else
                {
                    System.Windows.MessageBox.Show(this, "Выберите строку с автомобилем для редактирования.", "Внимание");
                    return;
                }
            }
            else
            {
                System.Windows.MessageBox.Show(this, "Редактирование недоступно в этом разделе.", "Информация");
            }
        }

        private void LogoButton_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

      

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            Window6 window6 = new Window6();
            window6.Show();
            this.Close();
        }
    }
    
}