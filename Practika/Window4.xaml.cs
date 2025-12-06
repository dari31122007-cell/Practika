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
    /// Логика взаимодействия для Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        private const string placeholder = "Задайте ваш вопрос";

        public Window4()
        {
            InitializeComponent();

            QuestionBox.Text = placeholder;
            QuestionBox.Foreground = new SolidColorBrush(Colors.Gray);
        }

        private void QuestionBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (QuestionBox.Text == placeholder)
            {
                QuestionBox.Text = "";
                QuestionBox.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void QuestionBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(QuestionBox.Text))
            {
                QuestionBox.Text = placeholder;
                QuestionBox.Foreground = new SolidColorBrush(Colors.Gray); ;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            Window4 window4 = new Window4();
            window4.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window3 window3 = new Window3();
            window3.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window5 window5 = new Window5();
            window5.Show();
            this.Close();
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            this.Close();
        }
        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            QuestionBox.Text = "";

            if (string.IsNullOrWhiteSpace(QuestionBox.Text))
            {
                QuestionBox.Text = placeholder;
                QuestionBox.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }
    }
}