using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace CinnyDemo
{
    /// <summary>
    /// Логика взаимодействия для MoviessearchPage.xaml
    /// </summary>
    public partial class MoviessearchPage : Page
    {
        public MoviessearchPage()
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

        private void buttonShowsSearch_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.ShowssearchPage);
        }
    }
}
