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
    /// Логика взаимодействия для user.xaml
    /// </summary>
    public partial class user : Window
    {
        private string currentEmail;
        private string currentPhone;
        private DateTime? currentBirthDate;

        public user(string currentFullName)
        {
            InitializeComponent();
        }

        public user(string currentFullName, string currentEmail, string currentPhone, DateTime? currentBirthDate) : this(currentFullName)
        {
            this.currentEmail=currentEmail;
            this.currentPhone=currentPhone;
            this.currentBirthDate=currentBirthDate;
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {

        }
    }
}
