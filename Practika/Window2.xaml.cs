using Practika.Models;
using Practika.Data; // ← ОБЯЗАТЕЛЬНО: чтобы видеть DbService
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Practika
{
    public partial class Window2 : Window
    {
        private List<brands> _brands = new();
        private List<models> _allModels = new();
        private List<color> _colors = new();
        private List<cars> _allCars = new();
        private List<car_images> _carImages = new();

        public Window2()
        {
            InitializeComponent();
            LoadFiltersFromDatabase();
            LoadAllCars();
        }

        private void LoadFiltersFromDatabase()
        {
            try
            {
                using (var context = new DbService())
                {
                    _brands = context.brands.ToList();
                    _allModels = context.models.ToList();
                    _colors = context.color.ToList();
                }

                BrandComboBox.ItemsSource = _brands;
                ColorComboBox.ItemsSource = _colors;
                ModelComboBox.ItemsSource = _allModels;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки фильтров: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadAllCars()
        {
            try
            {
                using (var context = new DbService()) // ← ИСПРАВЛЕНО
                {
                    _allCars = context.cars.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки автомобилей: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BrandComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BrandComboBox.SelectedItem is brands selectedBrand)
            {
                var filteredModels = _allModels
                    .Where(m => m.brand_id == selectedBrand.id)
                    .ToList();
                ModelComboBox.ItemsSource = filteredModels;
                ModelComboBox.SelectedIndex = -1;
            }
            else
            {
                ModelComboBox.ItemsSource = _allModels;
            }
        }

        private void ApplyFilterButton_Click(object sender, RoutedEventArgs e)
        {
            var filtered = _allCars.AsQueryable();

            // 1. Бренд
            if (BrandComboBox.SelectedItem is brands selectedBrand)
                filtered = filtered.Where(c => c.brand_id == selectedBrand.id);

            // 2. Модель
            if (ModelComboBox.SelectedItem is models selectedModel)
                filtered = filtered.Where(c => c.model_id == selectedModel.id);

            // 3. Цена
            if (PriceRangeComboBox.SelectedItem is ComboBoxItem priceItem &&
                priceItem.Content is string priceRange && priceRange != "Любая")
            {
                (decimal min, decimal max) = ParsePriceRange(priceRange);
                filtered = filtered.Where(c => c.price >= min && c.price <= max);
            }

            // 4. Цвет
            if (ColorComboBox.SelectedItem is color selectedColor)
                filtered = filtered.Where(c => c.color_id == selectedColor.id);

            // 5. Пробег
            if (MileageComboBox.SelectedItem is ComboBoxItem mileageItem &&
                mileageItem.Content is string mileageOption && mileageOption != "Любой")
            {
                int maxMileage = mileageOption switch
                {
                    "До 50 000" => 50_000,
                    "До 100 000" => 100_000,
                    "До 200 000" => 200_000,
                    "Более 200 000" => int.MaxValue,
                    _ => int.MaxValue
                };
                int minMileage = mileageOption == "Более 200 000" ? 200_000 : 0;
                filtered = filtered.Where(c => c.mileage >= minMileage && c.mileage <= maxMileage);
            }

            var filteredCars = filtered.ToList();
            UpdateCarDisplay(filteredCars);
        }

        private (decimal min, decimal max) ParsePriceRange(string range)
        {
            return range switch
            {
                "До 1 000 000" => (0, 1_000_000),
                "1 000 000 – 3 000 000" => (1_000_000, 3_000_000),
                "3 000 000 – 5 000 000" => (3_000_000, 5_000_000),
                "5 000 000 – 10 000 000" => (5_000_000, 10_000_000),
                "Более 10 000 000" => (10_000_000, decimal.MaxValue),
                _ => (0, decimal.MaxValue)
            };
        }

        private void UpdateCarDisplay(List<cars> cars)
        {
            MessageBox.Show($"Найдено {cars.Count} автомобилей, соответствующих фильтру.",
                            "Результат фильтрации",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
        }

        private string GetBrandModel(cars car)
        {
            var brand = _brands.FirstOrDefault(b => b.id == car.brand_id)?.name ?? "—";
            var model = _allModels.FirstOrDefault(m => m.id == car.model_id)?.model_name ?? "—";
            return $"{brand} {model}";
        }

        // Эта функция объявлена, но не используется — можно удалить или использовать
        private void LoadAllData()
        {
            using (var context = new DbService()) // ← ИСПРАВЛЕНО
            {
                _brands = context.brands.ToList();
                _allModels = context.models.ToList();
                _carImages = context.car_images.ToList();
                _allCars = context.cars.ToList();
            }
        }

        // Кнопки навигации
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window3 window3 = new Window3();
            window3.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new Window5().Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }
    }
}