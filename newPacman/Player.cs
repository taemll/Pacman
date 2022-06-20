using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace newPacman
{
    public class Player
    {
        public static Player player = new Player(14,15);
        public int X { get; set; }
        public int Y { get; set; }
        private char PlayerMarker;
        private ConsoleColor PlayerColor;
        public Player(int initialX,int initialY)
        {
            X = initialX;
            Y = initialY;
            PlayerMarker = 'P';
            PlayerColor = ConsoleColor.DarkYellow;
        }
        static ConsoleKey key = ConsoleKey.RightArrow;
        static ConsoleKey tmpKey = ConsoleKey.Enter;
        public void PlayerInput()
        {
            if (Console.KeyAvailable)
            {
                tmpKey = Console.ReadKey(true).Key;
            }
            if (tmpKey == ConsoleKey.LeftArrow || tmpKey == ConsoleKey.RightArrow || tmpKey == ConsoleKey.UpArrow || tmpKey == ConsoleKey.DownArrow)
            {
                key = tmpKey;
            }

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (Walk.IsPositionWalkable(X, Y - 1))
                    {
                        Y--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (Walk.IsPositionWalkable(X, Y + 1))
                    {
                        Y++;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (Walk.IsPositionWalkable(X - 1, Y))
                    {
                        X--;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (Walk.IsPositionWalkable(X + 1, Y))
                    {
                        X++;
                    }
                    break;
                default:
                    break;
            }
        }
        public void Draw()
        {
            ForegroundColor = PlayerColor;
            BackgroundColor = ConsoleColor.DarkYellow;
            SetCursorPosition(X, Y);
            Write(PlayerMarker);
        }
        
        public void CalcScore()
        {
            if (Map.mas[Y, X] == '·')
            {
                SetCursorPosition(X, Y);
                Map.mas[Y, X] = '2';
                Map.score += 10;
            }
        }
        public void ShowScore()
        {
            SetCursorPosition(33, 1);
            Console.Write("Score: {0}", Map.score);
        }
        public void KillPacman(Ghost ghost)
        {
            if (X == ghost.X && Y == ghost.Y)
            {
                GOScene.Run();
            }
        }
        public void ShowWinnScene()
        {
            if (Map.score == 2360)
            {
                WinnScene.Run();
            }
        }
    }
}
