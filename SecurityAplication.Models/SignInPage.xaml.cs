using SecurityAplication.DataAccess;
using SecurityAplication.Services;
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

namespace SecurityAplication.Models
{
    /// <summary>
    /// Логика взаимодействия для SignInPage.xaml
    /// </summary>
    public partial class SignInPage : Page
    {
        public SignInPage()
        {
            InitializeComponent();
        }

        private void SignInButtonClick(object sender, RoutedEventArgs e)
        {
            var login = loginTextBox.Text;
            var password = passwordBox.Password;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            using (var context = new SecurityContext())
            {
                var user = context.Users.SingleOrDefault(searchingUser => searchingUser.Login == login);

                if (user == null || !SecurityHasher.VerifyPassword(password, user.Password))
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
                else
                {
                    MessageBox.Show("Успешный вход");
                }

            }
        }
    }
}

