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

        private void InputBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null &&
                (textBox.Text == "Введите имя" || textBox.Text == "Введите номер"))
            {
                textBox.Text = "";
            }
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text.Trim();
            string phone = PhoneTextBox.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(phone) ||
                name == "Введите имя" || phone == "Введите номер")
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }


            MessageBox.Show("Заявка принята!", "Успех",
                MessageBoxButton.OK, MessageBoxImage.Information);


            NameTextBox.Text = "Введите имя";
            PhoneTextBox.Text = "Введите номер";
        }


        private void BurgerButton_Click(object sender, RoutedEventArgs e)
        {
            var window1 = new Window1();
            window1.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) { 
            var window5 = new Window5();
            window5.Show();
            this.Close();
        }
    }

}