using CrashBash.Models;
using System.Collections.ObjectModel;

namespace CrashBash.ViewModels;


    public class GameViewModel
    {
        public ObservableCollection<Models.Cell> Cells { get; set; }
        public GameViewModel()
        {
            var gameBoard = new Gameboard(8, 8);
            Cells = new ObservableCollection<Models.Cell>(gameBoard.Cells);
        }
    };

