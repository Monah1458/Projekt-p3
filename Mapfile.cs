using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektp3
{
    static class Mapfile
    {
        public static List<Enemy> enemies = new List<Enemy>();
        public static List<MovingWalls> movingWalls = new List<MovingWalls>();
        public static Player player;
        public static FunObject[,] FileMap(string filePath) 
        {
            String[] lines = File.ReadAllLines(filePath);
            string firstLine = lines[0];
            int rows=lines.Length;
            int cols= firstLine.Length;
            var toP=new List<int>();
            

            FunObject[,] map = new FunObject[rows, cols];
            List<FunObject> List = new List<FunObject>();
            for (int i = 0; i < rows; i++)
            {
                string line= lines[i];
                for (int j = 0; j < cols; j++)
                {
                    
                    char c = line[j]; 
                    switch (c)
                    {
                        case '-':
                            map[i, j]=new Walls(i, j, '-');
                            break;
                        case '|':
                            map[i, j]=new Walls(i, j, '|');
                            break;
                        case '"':
                            map[i, j]=new Walls(i, j, '"');
                            break;
                        case '.':
                            map[i, j]=new Walls(i, j, '.');
                            break;
                        case ':':
                            map[i, j]=new Walls(i, j, ':');
                            break;
                        case 'T':
                            map[i, j]=new Trap(i, j);
                            break;
                        case 'P':
                            map[i, j]=new Player(i, j);
                            player=new Player(i, j);
                            break;
                        case 'E':                                                         
                            map[i, j]=new Enemy(i,j);
                            enemies.Add(new Enemy(i, j));
                            break;
                        case 'c':
                            map[i, j]=new FunObject(i, j);
                            break;
                        case '1':
                            toP.Add(i);
                            toP.Add(j);
                            map[i, j]=new FunObject(i, j);                            
                            break;
                        case '2':
                            toP.Add(i);
                            toP.Add(j);
                            map[i, j]=new FunObject(i, j);
                            break;
                        case 'B':
                            map[i, j]=new MovingWalls(i, j);
                            break;
                        default:
                            map[i, j]=new FunObject(i, j);
                            break;
                    }
                }
            }
            for (int i = 0; i < enemies.Count; i++)
            {
                int k = 0;
                enemies[i].pd=toP[k];
                enemies[i].kd=toP[k+1];
                toP.RemoveAt(k);
                toP.RemoveAt(k);
            }
            return map;
        }
        public static List<Enemy> EnemiesList()
        {
             return enemies;
        }
        public static Player Player()
        {
            return player;
        }
    }
   
}
