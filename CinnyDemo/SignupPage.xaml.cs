using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Security.Cryptography;
using Cinny.Data;
using Cinny.Data.Models;

namespace CinnyDemo
{
    /// <summary>
    /// Логика взаимодействия для SignupPage.xaml
    /// </summary>
    public partial class SignupPage : Page
    {
        public SignupPage()
        {
            InitializeComponent();
        }

        Repository _repository = new Repository();

        Color color = (Color)ColorConverter.ConvertFromString("#FFCBC2C2");

        bool _emailEntered = false;

        private void textBoxEmail_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!_emailEntered)
            {
                textBoxEmail.Text = "";
                textBoxEmail.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void textBoxEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxEmail.Text))
                _emailEntered = true;
            else
            {
                textBoxEmail.Text = "Email address";
                _emailEntered = false;
                textBoxEmail.Foreground = new SolidColorBrush(color);
            }
        }

        bool _passwordEntered = false;

        private void textBoxPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!_passwordEntered)
            {
                textBoxPassword.Text = "";
                textBoxPassword.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void textBoxPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxPassword.Text))
                _passwordEntered = true;
            else
            {
                textBoxPassword.Text = "Password";
                _passwordEntered = false;
                textBoxPassword.Foreground = new SolidColorBrush(color);
            }
        }

        private void buttonLogin1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.StartPage);
        }

        private string CalculateHash(string password)
        {
            MD5 md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.ASCII.GetBytes(password));
            return Convert.ToBase64String(hash);
        }

        private Context context = new Context();

        private void buttonSignup1_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();

            user.Email = textBoxEmail.Text;
            user.Password = CalculateHash(textBoxPassword.Text);

            if (context.Users.ToList().Find(u => (u.Email == user.Email)) == null)
            {
                _repository.AddUser(user);
                MessageBox.Show("Congratulations! You've signed up!", "Yaay!", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("Seems like you forgot you've already signed up.", "Oops...", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
