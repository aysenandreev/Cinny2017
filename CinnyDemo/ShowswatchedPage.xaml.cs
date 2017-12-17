using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Cinny.Data;
using Cinny.Data.Models;

namespace CinnyDemo
{
    /// <summary>
    /// Логика взаимодействия для ShowswatchedPage.xaml
    /// </summary>
    public partial class ShowswatchedPage : Page
    {
        Repository _repository = new Repository();
        private Context context = new Context();
        public ShowswatchedPage()
        {
            InitializeComponent();

            foreach (Show s in context.Shows)
            {
                listBoxList.Items.Add(string.Format("* {0}, season {1}, episode {2}, {3}", s.Name, s.Season, s.Episode, s.Time));
            }
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Show show = new Show();

                show.Name = textBoxShowname.Text;
                show.Season = Convert.ToInt16(textBoxSeason.Text);
                show.Episode = Convert.ToInt16(textBoxEpisode.Text);
                show.Time = textBoxTime.Text;

                _repository.AddShow(show);

                listBoxList.Items.Clear();

                foreach (Show s in context.Shows)
                {
                    listBoxList.Items.Add(string.Format("* {0}, season {1}, episode {2}, {3}", s.Name, s.Season, s.Episode, s.Time));
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
            foreach (Show s in context.Shows)
            {
                string line = string.Format("* {0}, season {1}, episode {2}, {3}", s.Name, s.Season, s.Episode, s.Time);
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
                _repository.DeleteShows();
            }
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

        private void buttonMoviesPlans_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.MoviesplannedPage);
        }

        private void buttonMoviesSearch_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.MoviessearchPage);
        }
    }
}
