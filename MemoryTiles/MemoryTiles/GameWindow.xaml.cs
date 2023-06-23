using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace MemoryTiles
{
    public partial class GameWindow : Window
    {
        private List<List<int>> Board;
        private int Rows;
        private int Columns;
        public GameWindow(int rows, int columns)
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            this.Rows = rows;
            this.Columns = columns;
            InitializeBoard();
            InitializeGrid();
        }

        private void InitializeBoard()
        {
            List<int> tempTiles = new List<int>();
            Random random = new Random();
            List<int> generatedIndices = new List<int>();
            for (int i = 0; i < Rows * Columns / 2; i++)
            {
                int randomIndex = random.Next(0, MainWindow.ImagePaths.Length);
                if (!generatedIndices.Contains(randomIndex))
                {
                    tempTiles.Add(randomIndex);
                    tempTiles.Add(randomIndex);
                    generatedIndices.Add(randomIndex);
                }
                else
                {
                    i--;
                }
                if (generatedIndices.Count == MainWindow.ImagePaths.Length)
                {
                    generatedIndices.Clear();
                }
            }
            tempTiles = tempTiles.OrderBy(x => Guid.NewGuid()).ToList();
            int tilesAdded = 0;
            Board = new List<List<int>>();
            for (int i = 0; i < Rows; i++)
            {
                Board.Add(new List<int>());
                for (int j = 0; j < Columns; j++)
                {
                    Board[i].Add(tempTiles[tilesAdded]);
                    tilesAdded++;
                }
            }
        }


        private void InitializeGrid()
        {
            Grid grid = new Grid();
            for (int i = 0; i < Rows; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }
            for (int j = 0; j < Columns; j++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    int index = Board[i][j];
                    Image image = new Image();
                    image.Source = new BitmapImage(new Uri(MainWindow.ImagePaths[index]));
                    image.Margin = new Thickness(5);
                    grid.Children.Add(image);
                    Grid.SetRow(image, i);
                    Grid.SetColumn(image, j);
                }
            }
            MyGrid.Children.Add(grid);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to exit the game?", "Corfirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                
                this.Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}