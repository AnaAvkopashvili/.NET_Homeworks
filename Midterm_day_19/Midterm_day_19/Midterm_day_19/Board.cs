using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Chess.Pawn;

namespace Chess
{
    public static class Board
    {
        public static List<Piece> alivePieces = new List<Piece> ();
        static Board()
        {
            // There should be Valid posittions here (ver movaswari)
            for (int i = 0; i < 8; i++)
            {
                alivePieces.Add(new Pawn("White","Pawn", "A1"));
                alivePieces.Add(new Pawn("Black","Pawn", "A1"));
            }
            for (int i = 0;i < 2; i++)
            {
                alivePieces.Add(new Rook("white", "Rook", "A1"));
                alivePieces.Add(new Knight("White","Knight", "A1"));
                alivePieces.Add(new Rook("Black", "Rook", "A1"));
                alivePieces.Add(new Knight("Black", "Knight", "A1"));

            }
            alivePieces.Add(new King("White", "King", "A1"));
            alivePieces.Add(new King("Black", "King", "A1"));
   

        }
        public static void Move(Piece piece, String newPosition)
        {
            if (piece.ValidMoves(newPosition))
            {
                piece.Position = newPosition;
            }
        }
        public static void Kill(Piece toBeKilled, Piece piece)
        {
            if (toBeKilled.name != "King")
            {
                if (piece.name == "Knight" || piece.name == "Rook" || piece.name == "King" ||
                    piece.ValidMoves(toBeKilled.Position))
                {
                    alivePieces.Remove(toBeKilled);
                    piece.Position = toBeKilled.Position;
                }
                else if (piece.name == "Pawn")
                {
                    int asciiValueP = piece.Position[0];
                    int asciiValueK = toBeKilled.Position[0];
                    if ((asciiValueP - asciiValueK == 1 || asciiValueP - asciiValueK == -1)
                        && toBeKilled.Position[1] == piece.Position[1])
                    {
                        alivePieces.Remove(toBeKilled);
                        piece.Position = toBeKilled.Position;
                    }
                }
            }
        }
    }
}
