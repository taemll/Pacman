using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newPacman
{
    public class GOScene
    {
        public static void Run()
        {
            Console.Clear();
            Console.WriteLine(@"







                ██████████████████
                █──█──██────██─█─█
                ██───███─██─██─█─█
                ███─████─██─██─█─█
                ███─████─██─██─█─█
                ███─████────██───█
                ███─██████████████
                ████████████████████████
                █────███───██───██────██
                █─██──███─███─████─██──█
                █─██──███─███───██─██──█
                █─██──███─███─████─██──█
                █────███───██───██────██
                ████████████████████████

                       Game over
                
");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}