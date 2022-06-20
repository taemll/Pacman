using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newPacman
{
    class Walk
    {
        public static bool IsPositionWalkable(int x, int y)
        {
            if (x < 0 || y < 0 || x >= 28 || y >= 28)
            {
                return false;
            }
            return Map.mas[y, x] == '2' || Map.mas[y, x] == '·';
        }
    }
}
