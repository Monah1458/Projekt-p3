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
        public static FunObject[,] FileMap(string filePath) 
        {
            String[] lines = File.ReadAllLines(filePath);
            string firstLine = lines[0];
            int rows=lines.Length;
            int cols= firstLine.Length;

            FunObject[,] map = new FunObject[rows, cols];
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
                            break;
                        case 'E':
                            map[i, j]=new Enemy(i, j);
                            break;
                        case 'c':
                            map[i, j]=new FunObject(i, j);
                            break;
                        default:
                            map[i, j]=new FunObject(i, j);
                            break;
                    }
                }
            }
           
            return map;
        }
    }
}
