using System.Windows;

namespace Practika
{
    public partial class Window7 : Window
    {
        public Window7()
        {
            InitializeComponent();
        }

        private void CarButton_Click(object sender, RoutedEventArgs e)
        {
            Window3 window3 = new Window3();
            window3.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window8 window8 = new Window8();
            window8.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
         
            // Текущие данные пользователя (можно брать из БД или глобальных переменных)
            string currentFullName = "Иван Иванов"; // или из TextBlock'а
            string currentEmail = "ivan@example.com";
            string currentPhone = "+79991234567";
            DateTime? currentBirthDate = new DateTime(1990, 5, 15);

            var settings = new user(currentFullName, currentEmail, currentPhone, currentBirthDate);
            settings.Owner = this;
            bool? result = settings.ShowDialog();

            if (result == true)
            {
                // Обновляем ФИО в интерфейсе (если нужно)
                // Например: найти TextBlock с именем и обновить
            }
        }

        

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window9 window9 = new Window9();
            window9.Show();
            this.Close();
        }

        private void LogoButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
      
    }
}