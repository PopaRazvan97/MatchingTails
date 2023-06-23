using System.Windows;

namespace MemoryTiles
{
    public partial class PlayWindow : Window
    {
        public PlayWindow()
        {
            InitializeComponent();
        }

        private void StatisticsButton_Click(object sender, RoutedEventArgs e)
        {
            StatisticsWindow statisticsWindow = new StatisticsWindow();
            statisticsWindow.Owner = this;
            statisticsWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            statisticsWindow.ShowDialog();
            this.Show();
        }

        private void CreditsButton_Click(object sender, RoutedEventArgs e)
        {
            CreditsWindow creditsWindow = new CreditsWindow();
            creditsWindow.Owner = this;
            creditsWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            creditsWindow.ShowDialog();
            this.Show();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            NewGameWindow newGameWindow = new NewGameWindow();
            newGameWindow.Owner = this;
            newGameWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            newGameWindow.ShowDialog();
            this.Show();
        }
    }
}