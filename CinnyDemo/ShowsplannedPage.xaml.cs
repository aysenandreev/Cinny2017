using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Cinny.Data;
using Cinny.Data.Models;

namespace CinnyDemo
{
    /// <summary>
    /// Логика взаимодействия для ShowsplannedPage.xaml
    /// </summary>
    public partial class ShowsplannedPage : Page
    {
        public ShowsplannedPage()
        {
            InitializeComponent();

            foreach (ShowPlanned s in context.ShowsPlanned)
            {
                listBoxList.Items.Add(string.Format("* {0}, season {1}", s.Name, s.Season));
            }
        }

        Repository _repository = new Repository();
        private Context context = new Context();

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ShowPlanned showplanned = new ShowPlanned();

                showplanned.Name = textBoxShowname.Text;
                showplanned.Season = Convert.ToInt16(textBoxSeason.Text);

                _repository.AddShowPlanned(showplanned);

                listBoxList.Items.Clear();

                foreach (ShowPlanned s in context.ShowsPlanned)
                {
                    listBoxList.Items.Add(string.Format("* {0}, season {1}", s.Name, s.Season));
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
            foreach (ShowPlanned s in context.ShowsPlanned)
            {
                string line = string.Format("* {0}, season {1}", s.Name, s.Season);
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
                _repository.DeleteShowsPlanned();
            }
        }

        private void buttonShowsWatched_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.ShowswatchedPage);
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
