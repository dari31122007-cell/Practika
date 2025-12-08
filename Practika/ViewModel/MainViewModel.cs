using Practika.Models;
using Practika.Data;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Practika.ViewModel
{
    internal class MainViewModel
    {
        public ObservableCollection<action_logs> action_Logs { get; set; }
        public ObservableCollection<body_type> body_type { get; set; }
        public ObservableCollection<brands> brands { get; set; }
        public ObservableCollection<cars> cars { get; set; }
        public ObservableCollection<car_images> car_images { get; set; }
        public ObservableCollection<categories> categories { get; set; }
        public ObservableCollection<color> color { get; set; }
        public ObservableCollection<engine_type> engine_type { get; set; }
        public ObservableCollection<favorites> favorites { get; set; }
        public ObservableCollection<messages> messages { get; set; }
        public ObservableCollection<models> models { get; set; }
        public ObservableCollection<orders> orders { get; set; }
        public ObservableCollection<reviews> reviews { get; set; }
        public ObservableCollection<roles> roles { get; set; }
        public ObservableCollection<status> status { get; set; }
        public ObservableCollection<transmission> transmission { get; set; }
        public ObservableCollection<users> users { get; set; }

        public MainViewModel()
        {
            // Инициализация всех коллекций
            action_Logs = new ObservableCollection<action_logs>();
            body_type = new ObservableCollection<body_type>();
            brands = new ObservableCollection<brands>();
            cars = new ObservableCollection<cars>();
            car_images = new ObservableCollection<car_images>();
            categories = new ObservableCollection<categories>();
            color = new ObservableCollection<color>();
            engine_type = new ObservableCollection<engine_type>();
            favorites = new ObservableCollection<favorites>();
            messages = new ObservableCollection<messages>();
            models = new ObservableCollection<models>();
            orders = new ObservableCollection<orders>();
            reviews = new ObservableCollection<reviews>();
            roles = new ObservableCollection<roles>();
            status = new ObservableCollection<status>();
            transmission = new ObservableCollection<transmission>();
            users = new ObservableCollection<users>();

            LoadData(); // Загрузка данных
        }

        private void LoadData()
        {
            using (var context = new DbService())
            {
                // Очищаем коллекции (на случай повторной загрузки)
                action_Logs.Clear();
                body_type.Clear();
                brands.Clear();
                cars.Clear();
                car_images.Clear();
                categories.Clear();
                color.Clear();
                engine_type.Clear();
                favorites.Clear();
                messages.Clear();
                models.Clear();
                orders.Clear();
                reviews.Clear();
                roles.Clear();
                status.Clear();
                transmission.Clear();
                users.Clear();

                // Загружаем данные из базы
                foreach (var item in context.action_logs) action_Logs.Add(item);
                foreach (var item in context.body_type) body_type.Add(item);
                foreach (var item in context.brands) brands.Add(item);
                foreach (var item in context.cars) cars.Add(item);
                foreach (var item in context.car_images) car_images.Add(item);
                foreach (var item in context.categories) categories.Add(item);
                foreach (var item in context.color) color.Add(item);
                foreach (var item in context.engine_type) engine_type.Add(item);
                foreach (var item in context.favorites) favorites.Add(item);
                foreach (var item in context.messages) messages.Add(item);
                foreach (var item in context.models) models.Add(item);
                foreach (var item in context.orders) orders.Add(item);
                foreach (var item in context.reviews) reviews.Add(item);
                foreach (var item in context.roles) roles.Add(item);
                foreach (var item in context.status) status.Add(item);
                foreach (var item in context.transmissions) transmission.Add(item); // ✅ DbSet называется "transmissions"
                foreach (var item in context.users) users.Add(item);
            }
        }
    }
}