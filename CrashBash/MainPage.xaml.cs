using Microsoft.Maui.Controls;

namespace CrashBash
{
    public partial class MainPage : ContentPage
    {
        private const int GridSize = 8; 
        private Button[,] _buttons; 
        private int _score = 0; 
        private Random _random = new Random();

        public MainPage()
        {
            
            InitializeGameGrid();
            InitializeComponent();
        }

        private void InitializeGameGrid()
        {
            GameGrid.Children.Clear();
            GameGrid.RowDefinitions.Clear();
            GameGrid.ColumnDefinitions.Clear();

            _buttons = new Button[GridSize, GridSize];

            for (int i = 0; i < GridSize; i++)
            {
                GameGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
                GameGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            }

            for (int row = 0; row < GridSize; row++)
            {
                for (int col = 0; col < GridSize; col++)
                {
                    var button = new Button
                    {
                        BackgroundColor = GetRandomColor(),
                        CornerRadius = 5,
                        BorderWidth = 1,
                        BorderColor = Colors.Black
                    };

                    button.Clicked += OnCandyClicked;
                    _buttons[row, col] = button;

                    GameGrid.Children.Add(button);
                    

                }
            }
        }

        private Color GetRandomColor()
        {
            Color[] candyColors = { Colors.Red, Colors.Blue, Colors.Green, Colors.Yellow, Colors.Purple };
            return candyColors[_random.Next(candyColors.Length)];
        }

        private void OnCandyClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                int row = Grid.GetRow(button);
                int column = Grid.GetColumn(button);

                if (_buttons[row, column] == button)
                {

                    button.BackgroundColor = Colors.Grey;
                    _score += 10;
                    ScoreLabel.Text = $"Score: {_score}";
                }
            }
        }

        
        private void OnRestartClicked(object sender, EventArgs e)
        {
            _score = 0;
            ScoreLabel.Text = "Score: 0";
            InitializeGameGrid();
        }
    }
}
