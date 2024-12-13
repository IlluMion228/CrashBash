

namespace CrashBash.Models
{

    public class Gameboard
    {
        public int Rows { get; }
        public int Columns { get; }
        public List<Cell> Cells { get; private set; }

        public Gameboard(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Cells = new List<Cell>();
            InitializeBoard();
        }
        private void InitializeBoard()
        {
            var candyTypes = new[] { "Red", "Blue", "Green", "Yellow", "Purple" };
            var random = new Random();

            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    Cells.Add(new Cell
                    {
                        Row = row,
                        Column = col,
                        CandyType = candyTypes[random.Next(candyTypes.Length)]
                    });
                }
            }

        }
    }

}