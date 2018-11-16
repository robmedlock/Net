using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Square
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsWhite { get; set; }
        public ICollection<Square> Diagonals (bool isKing = false)
        {
            throw new NotImplementedException();
        }

        public ICollection<Square> Straights(bool isKing = false)
        {
            throw new NotImplementedException();
        }
    }
}
