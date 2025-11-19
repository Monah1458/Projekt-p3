using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Projektp3
{
    static class PlayerInput
    {

        static public void KeyPlayerInput(Map map,Player p1) 
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            ConsoleKey key = keyInfo.Key;
            switch (key)
            {
                case ConsoleKey.W:
                    if (map.GetID(p1.x,p1.y-1)!='W')
                    {
                        map.MoveUp(p1);
                    }
                    break;
                case ConsoleKey.A:
                    if (map.GetID(p1.x-1, p1.y)!='W')
                    {
                        map.MoveLeft(p1);
                    }
                    break;
                case ConsoleKey.S:
                    if (map.GetID(p1.x, p1.y+1)!='W')
                    {
                        map.MoveDown(p1);
                    }
                    break;
                case ConsoleKey.D:
                    if (map.GetID(p1.x+1, p1.y)!='W')
                    {
                        map.MoveRight(p1);
                    }
                    break;
                default:
                    break;
            }

        }

    }
}
