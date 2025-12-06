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
        private List<User> allUsers = new List<User>();
        private List<Car> allCars = new List<Car>();
        private List<Brand> brands = new List<Brand>();
        private List<CarModel> models = new List<CarModel>();
        private List<Models.Color> colors = new List<Models.Color>(); 
        private List<BodyType> bodyTypes = new List<BodyType>();
        private List<EngineType> engineTypes = new List<EngineType>();
        private List<Transmission> transmissions = new List<Transmission>();
        private List<Status> statuses = new List<Status>();

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
            allUsers = new List<User>
            {
                new User { Id = 1, RoleId = 1, Surname = "Иванов", Name = "Иван", Patronymic = "Иванович", Email = "ivan@example.com", Phone = "+79991112233", DateOfBirth = new DateTime(1990, 1, 1), CreatedAt = DateTime.Now },
                new User { Id = 2, RoleId = 2, Surname = "Петров", Name = "Пётр", Patronymic = "Петрович", Email = "petr@example.com", Phone = "+79994445566", DateOfBirth = new DateTime(1985, 5, 10), CreatedAt = DateTime.Now },
                new User { Id = 3, RoleId = 3, Surname = "Сидорова", Name = "Анна", Patronymic = "Сергеевна", Email = "anna@example.com", Phone = "+79997778899", DateOfBirth = new DateTime(1995, 3, 22), CreatedAt = DateTime.Now },
                new User { Id = 4, RoleId = 1, Surname = "Козлов", Name = "Алексей", Patronymic = "Владимирович", Email = "alex@example.com", Phone = "+79110001122", DateOfBirth = new DateTime(1988, 7, 15), CreatedAt = DateTime.Now }
            };
        }

        private void LoadCarSampleData()
        {
            brands = new List<Brand>
            {
                new Brand { Id = 1, Name = "BMW" },
                new Brand { Id = 2, Name = "Mini" }
            };

            models = new List<CarModel>
            {
                new CarModel { Id = 1, BrandId = 1, ModelName = "E32" },
                new CarModel { Id = 2, BrandId = 1, ModelName = "X6" },
                new CarModel { Id = 6, BrandId = 1, ModelName = "X5" },
                new CarModel { Id = 10, BrandId = 2, ModelName = "Countryman" }
            };

            colors = new List<Models.Color>
            {
                new Models.Color { Id = 1, ColorName = "Белый" },
                new Models.Color { Id = 2, ColorName = "Черный" },
                new Models.Color { Id = 4, ColorName = "Зеленый" }
            };

            bodyTypes = new List<BodyType>
            {
                new BodyType { Id = 1, TypeName = "седан" },
                new BodyType { Id = 2, TypeName = "купе" },
                new BodyType { Id = 4, TypeName = "хетчбэк" },
                new BodyType { Id = 6, TypeName = "Полноразмерный" }
            };

            engineTypes = new List<EngineType>
            {
                new EngineType { Id = 1, Type = "Бензин" },
                new EngineType { Id = 2, Type = "Дизель" }
            };

            transmissions = new List<Transmission>
            {
                new Transmission { Id = 1, TransmissionName = "Ручной" },
                new Transmission { Id = 2, TransmissionName = "Автомат" }
            };

            statuses = new List<Status>
            {
                new Status { Id = 1, StatusName = "Активно" }
            };

            allCars = new List<Car>
            {
                new Car {
                    Id = 15, SellerId = 3, CategoryId = 1, BrandId = 1, ModelId = 1,
                    Year = 1991, Mileage = 250000, EngineTypeId = 1, TransmissionId = 2,
                    BodyTypeId = 1, ColorId = 2, Price = 1200000.00m,
                    Description = "Флагман BMW 1980–90-х...",
                    CreatedAt = DateTime.Now, StatusId = 1
                },
                new Car {
                    Id = 20, SellerId = 3, CategoryId = 2, BrandId = 1, ModelId = 2,
                    Year = 2021, Mileage = 45000, EngineTypeId = 1, TransmissionId = 1,
                    BodyTypeId = 2, ColorId = 4, Price = 6150000.00m,
                    Description = "Премиум-«купе-SUV»...",
                    CreatedAt = DateTime.Now, StatusId = 1
                },
                new Car {
                    Id = 27, SellerId = 3, CategoryId = 3, BrandId = 2, ModelId = 10,
                    Year = 2022, Mileage = 27000, EngineTypeId = 2, TransmissionId = 2,
                    BodyTypeId = 4, ColorId = 1, Price = 3465000.00m,
                    Description = "Самый практичный MINI...",
                    CreatedAt = DateTime.Now, StatusId = 1
                }
            };
        }

        private void SwitchToClients()
        {
            SetupUserColumns();
            MainDataGrid.ItemsSource = allUsers.Where(u => u.RoleId == 1).ToList();
            MainDataGrid.IsReadOnly = false; // ← ДОБАВЛЕНО: разрешить редактирование
            SectionTitle.Text = "Клиенты";
            currentSection = "Clients";
            HighlightButton(BtnClients);
        }

        private void SwitchToEmployees()
        {
            SetupUserColumns();
            MainDataGrid.ItemsSource = allUsers.Where(u => u.RoleId == 2 || u.RoleId == 3).ToList();
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

            MainDataGrid.ItemsSource = allCars; // ← привязка к реальным объектам
            SectionTitle.Text = "Авто в наличии";
            currentSection = "Cars";
            HighlightButton(BtnCars);
        }

        private void SwitchToMessages()
        {
            // Подготавливаем данные с развёрнутыми именами
            var displayMessages = allMessages.Select(m => new
            {
                m.Id,
                Sender = allUsers.FirstOrDefault(u => u.Id == m.SenderId)?.Name + " " + allUsers.FirstOrDefault(u => u.Id == m.SenderId)?.Surname ?? "—",
                Receiver = allUsers.FirstOrDefault(u => u.Id == m.ReceiverId)?.Name + " " + allUsers.FirstOrDefault(u => u.Id == m.ReceiverId)?.Surname ?? "—",
                Car = m.CarId.HasValue
                    ? (brands.FirstOrDefault(b => b.Id == allCars.FirstOrDefault(c => c.Id == m.CarId)?.BrandId)?.Name ?? "") +
                      " " + (models.FirstOrDefault(md => md.Id == allCars.FirstOrDefault(c => c.Id == m.CarId)?.ModelId)?.ModelName ?? "") +
                      $" ({allCars.FirstOrDefault(c => c.Id == m.CarId)?.Year ?? 0})"
                    : "—",
                MessageText = m.MessageText,
                SentAt = m.SentAt.ToString("dd.MM.yyyy HH:mm")
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
                if (MainDataGrid.SelectedItem is User selectedUser)
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
                if (MainDataGrid.SelectedItem is Car selectedCar)
                {
                    System.Windows.MessageBox.Show(this, $"Данные авто ID={selectedCar.Id} обновлены.", "Успех");
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

        private List<Practika.Models.Message> allMessages = new List<Practika.Models.Message>();
        private void LoadMessagesData()
        {
            // Словарь пользователей: ID → "Имя Фамилия"
            var userDict = allUsers.ToDictionary(u => u.Id, u => $"{u.Name} {u.Surname}");

            // Словарь авто: ID → "Бренд Модель (Год)"
            var carDict = allCars.ToDictionary(c => c.Id, c =>
                brands.FirstOrDefault(b => b.Id == c.BrandId)?.Name +
                " " + models.FirstOrDefault(m => m.Id == c.ModelId)?.ModelName +
                $" ({c.Year})"
            );

            allMessages = new List<Practika.Models.Message>
    {
        new Practika.Models.Message {
            Id = 1,
            SenderId = 3,
            ReceiverId = 2,
            CarId = 20,
            MessageText = "Какой пробег у авто?",
            SentAt = new DateTime(2025, 11, 18, 9, 13, 50)
        },
        new Practika.Models.Message {
            Id = 2,
            SenderId = 4,
            ReceiverId = 3,
            CarId = 15,
            MessageText = "Есть ли скидка для постоянных клиентов?",
            SentAt = new DateTime(2025, 11, 19, 14, 22, 10)
        },
        new Practika.Models.Message {
            Id = 3,
            SenderId = 1,
            ReceiverId = 3,
            CarId = null,
            MessageText = "Спасибо за помощь!",
            SentAt = new DateTime(2025, 11, 20, 10, 5, 30)
        }
    };
        }

    }
}