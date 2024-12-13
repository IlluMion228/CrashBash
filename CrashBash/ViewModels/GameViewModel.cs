using System.Collections.ObjectModel;
using System.Windows.Input;
using CrashBash.Models;
using Cell = CrashBash.Models.Cell;

namespace CrashBash.ViewModels;

public class GameViewModel
{
    public ObservableCollection<Cell> Cells { get; set; }
    public ICommand SelectCommand { get; }

    private Cell _selectedCell;

    public GameViewModel()
    {
        // Инициализация игрового поля
        var gameBoard = new Gameboard(8, 8);
        Cells = new ObservableCollection<Cell>(gameBoard.Cells);

        // Инициализация команды
        SelectCommand = new Command<Cell>(OnCellSelected);
    }

    private void OnCellSelected(Cell selectedCell)
    {
        if (_selectedCell == null)
        {
            _selectedCell = selectedCell;
            selectedCell.IsSelected = true; // Выделяем клетку
        }
        else
        {
            // Обрабатываем выбор второй клетки
            SwapCandies(_selectedCell, selectedCell);
            _selectedCell.IsSelected = false;
            _selectedCell = null;
        }
    }

    private void SwapCandies(Cell firstCell, Cell secondCell)
    {
        // Меняем местами типы конфет
        var tempType = firstCell.CandyType;
        firstCell.CandyType = secondCell.CandyType;
        secondCell.CandyType = tempType;

        // Проверяем матчи после перемещения
        CheckForMatches();
    }

    private void CheckForMatches()
    {
        var matchedCells = new List<Cell>();

        for (int row = 0; row < 8; row++)
        {
            for (int col = 0; col < 6; col++) 
            {
                var cell1 = Cells.First(c => c.Row == row && c.Column == col);
                var cell2 = Cells.First(c => c.Row == row && c.Column == col + 1);
                var cell3 = Cells.First(c => c.Row == row && c.Column == col + 2);

                if (cell1.CandyType == cell2.CandyType && cell2.CandyType == cell3.CandyType)
                {
                    matchedCells.Add(cell1);
                    matchedCells.Add(cell2);
                    matchedCells.Add(cell3);
                }
            }
        }

        for (int col = 0; col < 8; col++)
        {
            for (int row = 0; row < 6; row++) 
            {
                var cell1 = Cells.First(c => c.Row == row && c.Column == col);
                var cell2 = Cells.First(c => c.Row == row + 1 && c.Column == col);
                var cell3 = Cells.First(c => c.Row == row + 2 && c.Column == col);

                if (cell1.CandyType == cell2.CandyType && cell2.CandyType == cell3.CandyType)
                {
                    matchedCells.Add(cell1);
                    matchedCells.Add(cell2);
                    matchedCells.Add(cell3);
                }
            }
        }

        foreach (var cell in matchedCells)
        {
            cell.CandyType = null; 
        }

        GenerateNewCandies();
    }
    private void GenerateNewCandies()
    {
        var random = new Random();
        var candyTypes = new[] { "Red", "Blue", "Green", "Yellow", "Purple" };

        foreach (var cell in Cells)
        {
            if (string.IsNullOrEmpty(cell.CandyType))
            {
                cell.CandyType = candyTypes[random.Next(candyTypes.Length)];
            }
        }
    }


}
