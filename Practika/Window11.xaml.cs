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
        private List<users> users = new List<users>();
        private List<cars> cars = new List<cars>();
        private List<brands> brands = new List<brands>();
        private List<models> models = new List<models>();
        private List<Models.color> color = new List<Models.color>(); 
        private List<body_type> body_type = new List<body_type>();
        private List<engine_type> engine_type = new List<engine_type>();
        private List<transmission> transmissions = new List<transmission>();
        private List<status> status = new List<status>();

        private string currentSection = "Clients";

        public Window11()
        {
            InitializeComponent();
            LoadSampleData();
            LoadCarSampleData();
            LoadMessagesData(); 
            SwitchToClients();
        }

        private void LoadSampleData()
        {
            // Заполняем всех пользователей (включая клиентов, сотрудников, админов)
            users = new List<users>
            {
                new users { id = 1, role_id = 1, surname = "Иванов", name = "Иван", patronymic = "Иванович", email = "ivan@example.com", phone = "+79991112233", Date_of_birth = new DateTime(1990, 1, 1), created_at = DateTime.Now },
                new users { id = 2, role_id = 2, surname = "Петров", name = "Пётр", patronymic = "Петрович", email = "petr@example.com", phone = "+79994445566", Date_of_birth = new DateTime(1985, 5, 10), created_at = DateTime.Now },
                new users { id = 3, role_id = 3, surname = "Сидорова", name = "Анна", patronymic = "Сергеевна", email = "anna@example.com", phone = "+79997778899", Date_of_birth = new DateTime(1995, 3, 22), created_at = DateTime.Now },
                new users { id = 4, role_id = 1, surname = "Козлов", name = "Алексей", patronymic = "Владимирович", email = "alex@example.com", phone = "+79110001122", Date_of_birth = new DateTime(1988, 7, 15), created_at = DateTime.Now }
            };
        }

        private void LoadCarSampleData()
        {
            brands = new List<brands>
            {
                new brands { id = 1, name = "BMW" },
                new brands { id = 2, name = "Mini" }
            };

            models = new List<models>
            {
                new models { id = 1, brand_id = 1, model_name = "E32" },
                new models { id = 2, brand_id = 1, model_name = "X6" },
                new models { id = 6, brand_id = 1, model_name = "X5" },
                new models { id = 10, brand_id = 2, model_name = "Countryman" }
            };

            color = new List<Models.color>
            {
                new Models.color { id = 1, color_name = "Белый" },
                new Models.color { id = 2, color_name = "Черный" },
                new Models.color { id = 4, color_name = "Зеленый" }
            };

            body_type = new List<body_type>
            {
                new body_type { id = 1, body = "седан" },
                new body_type { id = 2, body = "купе" },
                new body_type { id = 4, body = "хетчбэк" },
                new body_type { id = 6, body = "Полноразмерный" }
            };

            engine_type = new List<engine_type>
            {
                new engine_type { id = 1, type = "Бензин" },
                new engine_type { id = 2, type = "Дизель" }
            };

            transmissions = new List<transmission>
            {
                new transmission { id = 1, transmission_name = "Ручной" },
                new transmission { id = 2, transmission_name = "Автомат" }
            };

            status = new List<status>
            {
                new status { id = 1, status_name = "Активно" }
            };

            cars = new List<cars>
            {
                new cars {
                    id = 15, seller_id = 3, category_id = 1, brand_id = 1, model_id = 1,
                    year = 1991, mileage = 250000, engine_type = 1, transmission_id = 2,
                    body_type_id = 1, color_id = 2, price = 1200000.00m,
                    description = "Флагман BMW 1980–90-х...",
                    created_at = DateTime.Now, status_id = 1
                },
                new cars {
                    id = 20, seller_id = 3, category_id = 2, brand_id = 1, model_id = 2,
                    year = 2021, mileage = 45000, engine_type = 1, transmission_id = 1,
                    body_type_id = 2, color_id = 4, price = 6150000.00m,
                    description = "Премиум-«купе-SUV»...",
                    created_at = DateTime.Now, status_id = 1
                },
                new cars {
                    id = 27, seller_id = 3, category_id = 3, brand_id = 2, model_id = 10,
                    year = 2022, mileage = 27000, engine_type = 2, transmission_id = 2,
                    body_type_id = 4, color_id = 1, price = 3465000.00m,
                    description = "Самый практичный MINI...",
                    created_at = DateTime.Now, status_id = 1
                }
            };
        }

        private void SwitchToClients()
        {
            SetupUserColumns();
            MainDataGrid.ItemsSource = users.Where(u => u.role_id == 1).ToList();
            MainDataGrid.IsReadOnly = false; // ← ДОБАВЛЕНО: разрешить редактирование
            SectionTitle.Text = "Клиенты";
            currentSection = "Clients";
            HighlightButton(BtnClients);
        }

        private void SwitchToEmployees()
        {
            SetupUserColumns();
            MainDataGrid.ItemsSource = users.Where(u => u.role_id == 2 || u.role_id == 3).ToList();
            MainDataGrid.IsReadOnly = false; // ← ДОБАВЛЕНО: разрешить редактирование
            SectionTitle.Text = "Сотрудники";
            currentSection = "Employees";
            HighlightButton(BtnEmployees);
        }

        private void SetupUserColumns()
        {
            MainDataGrid.Columns.Clear();
            MainDataGrid.AutoGenerateColumns = false;
            MainDataGrid.IsReadOnly = true;

            MainDataGrid.Columns.Add(new DataGridTextColumn { Header = "ID", Binding = new System.Windows.Data.Binding("Id") });
            MainDataGrid.Columns.Add(new DataGridTextColumn { Header = "Фамилия", Binding = new System.Windows.Data.Binding("Surname") });
            MainDataGrid.Columns.Add(new DataGridTextColumn { Header = "Имя", Binding = new System.Windows.Data.Binding("Name") });
            MainDataGrid.Columns.Add(new DataGridTextColumn { Header = "Отчество", Binding = new System.Windows.Data.Binding("Patronymic") });
            MainDataGrid.Columns.Add(new DataGridTextColumn { Header = "Email", Binding = new System.Windows.Data.Binding("Email") });
            MainDataGrid.Columns.Add(new DataGridTextColumn { Header = "Телефон", Binding = new System.Windows.Data.Binding("Phone") });
            MainDataGrid.Columns.Add(new DataGridTextColumn { Header = "Роль", Binding = new System.Windows.Data.Binding("RoleId") });
        }

        private void SwitchToCars()
        {
            MainDataGrid.Columns.Clear();
            MainDataGrid.AutoGenerateColumns = false;
            MainDataGrid.IsReadOnly = false; // ← разрешено редактирование

            // ID — только для чтения
            MainDataGrid.Columns.Add(new DataGridTextColumn { Header = "ID", Binding = new System.Windows.Data.Binding("Id"), IsReadOnly = true });

            // Бренд — редактируемый (по ID, отображается как выпадающий список в идеале, но пока TextBox)
            MainDataGrid.Columns.Add(new DataGridTextColumn { Header = "Бренд ID", Binding = new System.Windows.Data.Binding("BrandId") });

            // Модель — по ID
            MainDataGrid.Columns.Add(new DataGridTextColumn { Header = "Модель ID", Binding = new System.Windows.Data.Binding("ModelId") });

            MainDataGrid.Columns.Add(new DataGridTextColumn { Header = "Год", Binding = new System.Windows.Data.Binding("Year") });
            MainDataGrid.Columns.Add(new DataGridTextColumn { Header = "Пробег", Binding = new System.Windows.Data.Binding("Mileage") });
            MainDataGrid.Columns.Add(new DataGridTextColumn { Header = "Двигатель ID", Binding = new System.Windows.Data.Binding("EngineTypeId") });
            MainDataGrid.Columns.Add(new DataGridTextColumn { Header = "КПП ID", Binding = new System.Windows.Data.Binding("TransmissionId") });
            MainDataGrid.Columns.Add(new DataGridTextColumn { Header = "Кузов ID", Binding = new System.Windows.Data.Binding("BodyTypeId") });
            MainDataGrid.Columns.Add(new DataGridTextColumn { Header = "Цвет ID", Binding = new System.Windows.Data.Binding("ColorId") });
            MainDataGrid.Columns.Add(new DataGridTextColumn { Header = "Цена", Binding = new System.Windows.Data.Binding("Price") });

            MainDataGrid.ItemsSource = cars; // ← привязка к реальным объектам
            SectionTitle.Text = "Авто в наличии";
            currentSection = "Cars";
            HighlightButton(BtnCars);
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

            MainDataGrid.Columns.Add(new DataGridTextColumn { Header = "ID", Binding = new System.Windows.Data.Binding("Id") });
            MainDataGrid.Columns.Add(new DataGridTextColumn { Header = "От кого", Binding = new System.Windows.Data.Binding("Sender") });
            MainDataGrid.Columns.Add(new DataGridTextColumn { Header = "Кому", Binding = new System.Windows.Data.Binding("Receiver") });
            MainDataGrid.Columns.Add(new DataGridTextColumn { Header = "Авто", Binding = new System.Windows.Data.Binding("Car") });
            MainDataGrid.Columns.Add(new DataGridTextColumn { Header = "Сообщение", Binding = new System.Windows.Data.Binding("MessageText") });
            MainDataGrid.Columns.Add(new DataGridTextColumn { Header = "Время", Binding = new System.Windows.Data.Binding("SentAt") });

            MainDataGrid.ItemsSource = displayMessages;
            SectionTitle.Text = "Сообщения";
            currentSection = "Messages";
            HighlightButton(BtnMessages);
        }

        private void HighlightButton(System.Windows.Controls.Button activeButton)
        {
            var buttons = new[] { BtnClients, BtnCars, BtnEmployees, BtnMessages };
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
                    case "BtnClients": SwitchToClients(); break;
                    case "BtnEmployees": SwitchToEmployees(); break;
                    case "BtnCars": SwitchToCars(); break;
                    case "BtnMessages": SwitchToMessages(); break;
                }
            }
        }

        // ✅ ДОБАВЛЕНО: редактирование пользователей
        // ✅ ДОБАВЛЕНО: редактирование пользователей И АВТО
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentSection == "Clients" || currentSection == "Employees")
            {
                if (MainDataGrid.SelectedItem is user selectedUser)
                {
                    System.Windows.MessageBox.Show(this, $"Данные пользователя {selectedUser.Name} обновлены.", "Успех");
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            this.Close();
        }

        private List<Practika.Models.messages> messages = new List<Practika.Models.messages>();
        private void LoadMessagesData()
        {
            // Словарь пользователей: ID → "Имя Фамилия"
            var userDict = users.ToDictionary(u => u.id, u => $"{u.name} {u.surname}");

            // Словарь авто: ID → "Бренд Модель (Год)"
            var carDict = cars.ToDictionary(c => c.id, c =>
                brands.FirstOrDefault(b => b.id == c.brand_id)?.name +
                " " + models.FirstOrDefault(m => m.id == c.model_id)?.model_name +
                $" ({c.year})"
            );

            messages = new List<Practika.Models.messages>
    {
        new Practika.Models.messages {
            id = 1,
            sender_id = 3,
            receiver_id = 2,
            car_id = 20,
            message = "Какой пробег у авто?",
            sent_at = new DateTime(2025, 11, 18, 9, 13, 50)
        },
        new Practika.Models.messages {
            id = 2,
            sender_id = 4,
            receiver_id = 3,
            car_id = 15,
            message = "Есть ли скидка для постоянных клиентов?",
            sent_at = new DateTime(2025, 11, 19, 14, 22, 10)
        },
        new Practika.Models.messages {
            id = 3,
            sender_id = 1,
            receiver_id = 3,
            car_id = null,
            message = "Спасибо за помощь!",
            sent_at = new DateTime(2025, 11, 20, 10, 5, 30)
        }
    };
        }

    }
}