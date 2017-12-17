using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Cinny.Data;
using Cinny.Data.Models;

namespace CinnyDemo
{
    /// <summary>
    /// Логика взаимодействия для MoviesplannedPage.xaml
    /// </summary>
    public partial class MoviesplannedPage : Page
    {
        public MoviesplannedPage()
        {
            InitializeComponent();

            foreach (MoviePlanned m in context.MoviesPlanned)
            {
                listBoxList.Items.Add(string.Format("* {0}", m.Name));
            }
        }

        Repository _repository = new Repository();
        private Context context = new Context();

        private void buttonShowsWatched_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.ShowswatchedPage);
        }

        private void buttonShowsPlans_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.ShowsplannedPage);
        }

        private void buttonShowsSearch_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.ShowssearchPage);
        }

        private void buttonMoviesWatched_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.MovieswatchedPage);
        }

        private void buttonMoviesSearch_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.MoviessearchPage);
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MoviePlanned movieplanned = new MoviePlanned();

                movieplanned.Name = textBoxShowname.Text;

                _repository.AddMoviePlanned(movieplanned);

                listBoxList.Items.Clear();

                foreach (MoviePlanned m in context.MoviesPlanned)
                {
                    listBoxList.Items.Add(string.Format("* {0}", m.Name));
                }
            }
            catch
            {
                MessageBox.Show("Check your data again", "Something gone wrong", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            listBoxList.Items.Clear();
            foreach (MoviePlanned m in context.MoviesPlanned)
            {
                string line = string.Format("* {0}", m.Name);
                if (line.Contains(textBoxSearch.Text) == true)
                {
                    listBoxList.Items.Add(line);
                }
            }
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure you want to delete the whole list?", "Delete Confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                listBoxList.Items.Clear();
                _repository.DeleteMoviesPlanned();
            }
        }
    }
}
