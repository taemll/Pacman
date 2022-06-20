using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace newPacman
{
    class Program
    {
        public static Map map = new Map();//sozdanie karty 
        public static Player player = new Player(14, 15);//sozdanie igroka 
        public static List<Ghost> ghosts = new List<Ghost>();

        public static Ghost ghost1 = new Ghost(1, 1, Ghost.Direction.up, ConsoleColor.Red); 
        public static Ghost ghost2 = new Ghost(26,23 , Ghost.Direction.left, ConsoleColor.Cyan);
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.Title = "Pacman";
            StartScene.Run();
            Console.Clear();
            while (true)
            {
                map.ShowMap();
                player.Draw();
                ghost1.Draw();
                ghost2.Draw();
                player.PlayerInput();
                ghost1.GhostMove();
                ghost2.GhostMove();
                player.CalcScore();
                player.ShowScore();
                player.KillPacman(ghost1);
                player.KillPacman(ghost2);
                player.ShowWinnScene();
                Thread.Sleep(150);
            }
        }
    }
}
