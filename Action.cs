using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektp3
{
    static class MapAction
    {
        static int[] Dist=new int[2];
        static int i=0;
        public static void Mol(Map map ,Player P,char T )
        {
            if ( T =='R') {
                map.DelObject(P.x+1,P.y);
                map.DelObject(P.x+2, P.y);
            }
            else if (T =='W') {
                map.DelObject(P.x, P.y-1);
                map.DelObject(P.x, P.y-2);
            }
            else if (T =='D') {
                map.DelObject(P.x, P.y+1);
                map.DelObject(P.x, P.y+2);
            }
            else if (T =='L') {
                map.DelObject(P.x-1, P.y);
                map.DelObject(P.x-2, P.y);
            }
        }
        public static void SetDistr(Map map, Player P)
        {
            map.AddToMap(new Trap(P.x+1,P.y,'D'));
            Dist[0]=P.x+1; Dist[1]=P.y;
            
        }
        public static List<FunObject> PathToDistr(Map map) 
        {
            int[] arr = FindEnemy(map);
            Pathfinder pf=new Pathfinder(map);
            List<FunObject> list = 
                pf.SearchPath(new FunObject(Dist[0], Dist[1]), 
                              new Enemy(arr[0], arr[1]));
            list.Add(new FunObject(Dist[0], Dist[1]));
            list.Insert(0, new FunObject(arr[0], arr[1]));
            return list;
        }
        public static void MovePathEnemy(Map map, List<FunObject> list,int k) {

            map.MoveTo(list[k-1].x, list[k-1].y, list[k]);
        }
        public static int[] FindEnemy(Map map) {
            int [] arr = new int[2];
            for (int i = 0; i <  map.x; i++)
            {

                for (int j = 0; j < map.y; j++)
                {
                    if (map.GetID(i,j)=='E')
                    {
                        arr[0] = i;
                        arr[1] = j;
                        return arr;
                    }
                }
            }
            return arr;
        }





    }



}
        
