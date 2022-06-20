using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace newPacman
{
    public class Ghost
    {
        public class DirectionInfo
        {
            public Direction direction_ { get; set; }
            public bool IsPlayerVisible { get; set; }
            public bool IsAvailable { get; set; }
        }

        //public static Ghost1 ghost = new Ghost1(17, 15, Ghost1.direction.left); 
        public Ghost() { }

        public Ghost(int initialX, int initialY, Direction direction, ConsoleColor GhostColor)
        {
            X = initialX;
            Y = initialY;
            GhostMarker = '@';
            this.GhostColor = GhostColor;
            ghostDirection = direction;
        }

        public static Player player = new Player(14, 15);
        public static Ghost ghost = new Ghost();
        public Random randomize = new Random();

        private char GhostMarker;
        private ConsoleColor GhostColor;
        public enum Direction { left, up, right, down }
        public Direction ghostDirection;

        public int x, y;
        public int X
        {
            set
            {
                x = value;
            }
            get
            {
                return x;
            }
        }
        public int Y
        {
            set
            {
                y = value;
            }
            get
            {
                return y;
            }
        }

        public void Draw()
        {
            ForegroundColor = GhostColor;
            BackgroundColor = GhostColor;
            SetCursorPosition(X, Y);
            Write(GhostMarker);
            ResetColor();
        }

        public bool IsPositionWalkableGhost(int x, int y)
        {
            if (x < 0 || y < 0 || x >= 28 || y >= 28)
            {
                return false;
            }
            return Map.mas[y, x] == '2' || Map.mas[y, x] == '·';
        }

        public void GhostMove()
        {
            int randNumber;
            Random rand = new Random();

            randNumber = rand.Next(4);

            switch (randNumber)
            {
                case 0:
                    if (ghost.IsPositionWalkableGhost(X, Y - 1))
                    {
                        Y--;
                    }
                    break;
                case 1:
                    if (ghost.IsPositionWalkableGhost(X, Y + 1))
                    {
                        Y++;
                    }
                    break;
                case 2:
                    if (ghost.IsPositionWalkableGhost(X - 1, Y))
                    {
                        X--;
                    }
                    break;
                case 3:
                    if (ghost.IsPositionWalkableGhost(X + 1, Y))
                    {
                        X++;
                    }
                    break;
                default:
                    break;
            }
        }
            public void DetectDirection()
            {
                switch (ghostDirection)
                {
                    case Direction.up:
                        if (ghost.IsPositionWalkableGhost(X, Y - 1))
                        {
                            Y--;
                        }
                        break;
                    case Direction.down:
                        if (ghost.IsPositionWalkableGhost(X, Y + 1))
                        {
                            Y++;
                        }
                        break;
                    case Direction.left:
                        if (ghost.IsPositionWalkableGhost(X - 1, Y))
                        {
                            X--;
                        }
                        break;
                    case Direction.right:
                        if (ghost.IsPositionWalkableGhost(X + 1, Y))
                        {
                            X++;
                        }
                        break;
                    default:
                        break;
                }
            }

            public void KillPacman()
            {
                if (X == player.X && Y == player.Y)
                {
                    GOScene.Run();
                }
            }
    }
}