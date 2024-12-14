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
        }

        private void InitializeGameGrid()
        {
            GameGrid.Children.Clear();
            GameGrid.RowDefinitions.Clear();
            GameGrid.ColumnDefinitions.Clear();

            _buttons = new Button[GridSize, GridSize];

            // Добавляем строки и столбцы
            for (int i = 0; i < GridSize; i++)
            {
                GameGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
                GameGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            }

            // Заполняем сетку кнопками
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

                    button.Clicked += OnCandyClicked; // Добавляем обработчик события клика
                    _buttons[row, col] = button;

                    // Добавляем кнопку в сетку
                    GameGrid.Children.Add(button);
                    

                }
            }
        }

        // Метод для получения случайного цвета (конфеты)
        private Color GetRandomColor()
        {
            Color[] candyColors = { Colors.Red, Colors.Blue, Colors.Green, Colors.Yellow, Colors.Purple };
            return candyColors[_random.Next(candyColors.Length)];
        }

        // Обработчик клика по конфете
        private void OnCandyClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackgroundColor = Colors.Gray; // Убираем цвет конфеты
                _score += 10; // Добавляем очки
                ScoreLabel.Text = $"Score: {_score}"; // Обновляем счет
            }
        }

        // Обработчик кнопки Restart
        private void OnRestartClicked(object sender, EventArgs e)
        {
            _score = 0;
            ScoreLabel.Text = "Score: 0";
            InitializeGameGrid();
        }
    }
}
