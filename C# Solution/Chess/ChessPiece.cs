using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public abstract class ChessPiece
    {
        public Square Square { get; set; }
        public bool HasMoved { get; set; }
        public bool IsWhite { get; set; }
        public abstract ICollection<Square> ValidMoves { get; }
    }
}
