﻿

namespace CrashBash.Models
{
    public class Cell
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public required string CandyType { get; set; }
        public bool IsSelected { get; set; }
    }
}
