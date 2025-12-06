using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Practika
{
    /// <summary>
    /// Логика взаимодействия для Window6.xaml
    /// </summary>
    public partial class Window6 : Window
    {
        public Window6()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window5 window5 = new Window5();
            window5.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string login = LoginBox.Text.Trim();
            string password = PasswordBox.Password;

            if (login == "Admin" && password == "admin")
            {
                Window11 window11 = new Window11();
                window11.Show();
                this.Close();
            }
            else
            {
                Window7 Window7 = new Window7();
                Window7.Show();
                this.Close();
            }
        }
        

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
