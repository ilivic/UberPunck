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
using System.Windows.Navigation;
using System.Windows.Shapes;
using KP.ADOApp;
using KP.ClassApp;

namespace KP.PagesApp
{
    /// <summary>
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((TxtName.Text != "") && (TxtLogin.Text != "") && (TxtPassword.Password != ""))
            {
                Users NewUser = new Users()
                {
                    Name = TxtName.Text,
                    Roles_id = 1
                };
                balances balances = new balances()
                {
                    Summ = 1000
                };
                DataAddBalance NewDAB = new DataAddBalance()
                {
                    DateIn = DateTime.Now,
                    AddBall = 1
                };
                Logins NewLogins = new Logins()
                {
                    Login = TxtLogin.Text,
                    Password = TxtPassword.Password
                };
                NewUser.Logins.Add(NewLogins);
                NewUser.balances.Add(balances);
                NewUser.DataAddBalance.Add(NewDAB);
                DBConnection.Connection.Users.Add(NewUser);
                DBConnection.Connection.SaveChanges();
                MessageBox.Show("All AXYENnO");

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void TxtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            var SelectElement = sender as TextBox;
            if (SelectElement.Text.Length <= 4)
            {
                SelectElement.Background = Brushes.Red;
            }
            else if (SelectElement.Text.Length >= 4)
            {
                SelectElement.Background = Brushes.Green;
            }
            else if (SelectElement.Text.Length == 0)
            {
                SelectElement.Background = Brushes.White;
            }
        }
    }
}
