using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Chess
{
    public class Piece
    {
        public string color { get; }
        public string name { get; }
        public Piece(string color, string position, string name)
        {
            this.color = color;
            Position = position;
            this.name = name;
        }

        public string Position { get; set; }
        public virtual bool ValidMoves(string newPosition)
        {
            return true; ;
        }
    }
    public class Pawn : Piece
    {
        static string _color;
        static string _position;
        static string _name;
        public Pawn(string color, string name, string position) : base(color, name, position)
        {
            _color = color;
            _position = position;
            _name = name;

        }
        Pawn pawn = new Pawn(_color, _position, _name);

        public override bool ValidMoves(string newPosition)
        {
            if (newPosition[0].Equals(pawn.Position) && (newPosition[1] == (pawn.Position[1] + 2)
                || newPosition[1] == (pawn.Position[1] + 1)))
            {
                return true;
            }
            return false;
        }
        public class Knight : Piece
        {

            static string _color;
            static string _position;
            static string _name;
            public Knight(string color, string name, string position) : base(color, name, position)
            {
                _color = color;
                _position = position;
                _name = name;
            }
            Knight knight = new Knight(_color, _position, _name);
            public override bool ValidMoves(string newPosition)
            {
                int asciiValueOld = knight.Position[0];
                int asciivalueNew = newPosition[0];
                int sxvaobaLetters = asciivalueNew - asciiValueOld;
                int sxvaobaInts = knight.Position[1] - newPosition[1];
                if ((Math.Abs(sxvaobaLetters) == 1 && Math.Abs(sxvaobaInts) == 2) ||
                    (Math.Abs(sxvaobaLetters) == 2 && Math.Abs(sxvaobaInts) == 1))
                {
                    return true;
                }
                return false;
            }
        }
        public class Rook : Piece
        {
            public static string _position;
            public static string _color;
            public static string _name;
            public Rook(string color, string name, string position) : base(color, name, position)
            {
                _color = color;
                _position = position;
                _name = name;
            }
            Rook rook = new Rook(_color, _name, _position);
            public override bool ValidMoves(string newPosition)
            {
                if (newPosition[0].Equals(rook.Position[0]) || newPosition[1] == rook.Position[1])
                {
                    return true;
                }
                return false;
            }
        }
        public class King : Piece
        {
            public static string _position;
            public static string _color;
            public static string _name;
            public King(string color, string name, string position) : base(color, name, position)
            {
                _color = color;
                _position = position;
                _name = name;
            }
            King king = new King(_color, _name, _position);
            public override bool ValidMoves(string newPosition)
            {
                int asciiValueOld = king.Position[0];
                int asciiValueNew = newPosition[0];
                if ((asciiValueOld - asciiValueNew == 1 || asciiValueOld - asciiValueNew == -1)
                    && (king.Position[1] - newPosition[1] == 1) || (king.Position[1] - newPosition[1] == -1))
                {
                    return true;
                }
                return false;
            }
        }


    }
}
