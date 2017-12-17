using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Cinny.Data;
using Cinny.Data.Models;

namespace CinnyDemo
{
    /// <summary>
    /// Логика взаимодействия для MovieswatchedPage.xaml
    /// </summary>
    public partial class MovieswatchedPage : Page
    {
        public MovieswatchedPage()
        {
            InitializeComponent();

            foreach (Movie m in context.Movies)
            {
                listBoxList.Items.Add(string.Format("* {0}, my rate: {1}", m.Name, m.Rate));
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

        private void buttonMoviesPlans_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.MoviesplannedPage);
        }

        private void buttonMoviesSearch_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.MoviessearchPage);
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Movie movie = new Movie();

                movie.Name = textBoxShowname.Text;
                movie.Rate = Convert.ToInt16(textBoxRate.Text);

                _repository.AddMovie(movie);

                listBoxList.Items.Clear();

                foreach (Movie m in context.Movies)
                {
                    listBoxList.Items.Add(string.Format("* {0}, my rate: {1}", m.Name, m.Rate));
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
            foreach (Movie m in context.Movies)
            {
                string line = string.Format("* {0}, my rate: {1}", m.Name, m.Rate);
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
                _repository.DeleteMovies();
            }
        }
    }
}
