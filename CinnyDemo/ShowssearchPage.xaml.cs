using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace CinnyDemo
{
    /// <summary>
    /// Логика взаимодействия для ShowssearchPage.xaml
    /// </summary>
    public partial class ShowssearchPage : Page
    {
        public ShowssearchPage()
        {
            InitializeComponent();
        }

        private void buttonShowsWatched_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.ShowswatchedPage);
        }

        private void buttonShowsPlans_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.ShowsplannedPage);
        }

        private void buttonMoviesWatched_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.MovieswatchedPage);
        }

        private void buttonMoviesPlans_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.MoviesplannedPage);
        }

        private void buttonMoviesSearch_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.MoviessearchPage);
        }

        private void Application_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            if (e.Exception is System.Net.WebException)
            {
                MessageBox.Show("Сайт " + e.Uri.ToString() + " не доступен :(");
                e.Handled = true;
            }
        }
    }
}
