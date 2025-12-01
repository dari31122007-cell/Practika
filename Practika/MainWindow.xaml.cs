using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Practika
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Кнопка "Профиль" → открывает регистрацию (Window5)
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var registrationWindow = new Window5();
            registrationWindow.Show();
        }

        // Кнопка "Отправить" → отправка заявки (оставляем как есть)
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Спасибо! Ваша заявка на консультацию отправлена.",
                "Заявка принята",
                MessageBoxButton.OK,
                MessageBoxImage.Information
            );
        }

        // Кнопка "Меню" (бургер) → открывает каталог (Window1)
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var catalogWindow = new Window1();
            catalogWindow.Show();
        }

        // Логотип BMW → ничего не делает (можно оставить пустым)
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            // Опционально: можно добавить переход на главную или каталог
        }
    
    }
}