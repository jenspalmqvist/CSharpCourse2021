using System;
using System.Collections.Generic;
using System.Text;

namespace RollSpelGrupp6.Structures
{
    public class Coordinate
    {
        public int Row { get; set; }
        public int Col { get; set; }

        public Coordinate()
        {
        }

        public Coordinate(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public void SetCoordinate(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public override bool Equals(object obj)
        {
            return obj is Coordinate coordinate &&
                   Row == coordinate.Row &&
                   Col == coordinate.Col;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Row, Col);
        }
    }
}