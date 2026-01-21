using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Projektp3
{
    
    static class MapAction
    {   
        
        static int[] Dist=new int[2];        

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
        public static void SetDistr(Map map)
        {
            map.AddToMap(new Trap(map.player.y+1, map.player.x,'D'));
            Dist[1]=map.player.x; 
            Dist[0]=map.player.y+1;

            
        }
        public static void TriggerDistr(Map map)
        {
            for (int i = 0; i < map.listEnemies.Count; i++) 
            map.listEnemies[i].DistractionPathList=PathToDistr(map,i);

            int sh=FindShorter(map);
            map.listEnemies[sh].toD=true;
            map.listEnemies[sh].pd=map.listEnemies[sh].p;
            map.listEnemies[sh].kd=map.listEnemies[sh].k;
            map.listEnemies[sh].p=0;
            map.listEnemies[sh].k=0;
        }

        public static int FindShorter(Map map)
        {
            int s = map.listEnemies[0].DistractionPathList.Count;
            int ind=0;
            for (int i = 1; i < map.listEnemies.Count; i++)
            {
                if (map.listEnemies[i].DistractionPathList.Count<s) { 
                    s=map.listEnemies[i].DistractionPathList.Count;
                    ind=i;
                    }
            }
            return ind;
        }


       public static List<FunObject> PathToDistr(Map map, int i) 
       {
            
            Pathfinder pf=new Pathfinder(map);
            List<FunObject> list = 
                pf.SearchPath(new FunObject(Dist[1], Dist[0]),
                              map.listEnemies[i]);
            list.Add(new FunObject(Dist[1], Dist[0]));            
            list.Insert(0, new FunObject(map.listEnemies[i].x, map.listEnemies[i].y));
            return list;
        }            

        

        public static void EnemyStartPath(Map map)
        {
            for (int i = 0; i < map.listEnemies.Count; i++)
            {
                Pathfinder pf=new Pathfinder(map);
                map.listEnemies[i].PathList=              
                    pf.SearchPath(new FunObject(map.listEnemies[i].pd, map.listEnemies[i].kd),
                                  map.listEnemies[i]);
                map.listEnemies[i].PathList.Add(new FunObject(map.listEnemies[i].pd, map.listEnemies[i].kd));               
                map.listEnemies[i].PathList.Insert(0, new Enemy(map.listEnemies[i].x, map.listEnemies[i].y));                
                map.listEnemies[i].k=0;
                map.listEnemies[i].p=0;
            }
           
        }
        public static void MoveEnemes(Map map)
        {            
            for(int i = 0; i<map.listEnemies.Count; i++)
            {

                if (map.listEnemies[i].k==2&&map.listEnemies[i].toD)
                {//////
                    map.listEnemies[i].toD=false;
                    map.listEnemies[i].p=map.listEnemies[i].pd+1;
                    map.listEnemies[i].k=map.listEnemies[i].kd;
                    map.listEnemies[i].pd=0;
                    map.listEnemies[i].kd=0;
                }

                if (map.listEnemies[i].toD)                                            
                EnemyAlongPath(map, map.listEnemies[i].DistractionPathList,i);

                else EnemyAlongPath(map, map.listEnemies[i].PathList,i);
                
            }
        }
        
        public static void EnemyAlongPath(Map map, List<FunObject> list,int i)
        {

            switch (NextId(list))
            {
                case 'M':
                    break;
                case 'E':
                    break;

                default:
                    if (map.listEnemies[i].k%2==1)
                        map.listEnemies[i].p--;
                    else
                        map.listEnemies[i].p++;
                    if (map.listEnemies[i].p==list.Count) 
                    {
                        map.listEnemies[i].k++;
                        map.listEnemies[i].p--;
                        MovePathEnemy(map, list, map.listEnemies[i].p,i);                   
                    } 
                    else if (map.listEnemies[i].p==0&&map.listEnemies[i].k!=0)
                    {
                        map.listEnemies[i].k++;
                        map.listEnemies[i].p++;
                        MovePathEnemy(map, list, map.listEnemies[i].p,i);
                    }
                    else MovePathEnemy(map, list, map.listEnemies[i].p,i);
                    break;

            }
        }
        public static void MovePathEnemy(Map map, List<FunObject> list, int p,int i)
        {
                
            map.MoveTo(list[p-1].x, list[p-1].y, list[p].x, list[p].y);
            if(map.listEnemies[i].k%2==0)
            {
                map.listEnemies[i].x=list[p].x;
                map.listEnemies[i].y= list[p].y;
            }
            else
            {
                map.listEnemies[i].x=list[p-1].x;
                map.listEnemies[i].y= list[p-1].y;
            }

        }

        public static char NextId(List<FunObject> list) 
        {
            if (list[0].p+1>=list.Count) return 'C';

            else return list[list[0].p+1].ID;
        }
        
        public static void MovingWalls(Map map)
        {
            for (int i = 0; i < map.listMovingWalls.Count; i++)
            {
                MoveWall(map.listMovingWalls[i],map);
            }
            
        }
        public static void MoveWall(MovingWalls wall,Map map)
        {            
            map.MoveTo(wall.x, wall.y, wall.sx, wall.sy);
            wall.sx = wall.x;
            wall.sy = wall.y;
        }

        public static bool PushByPlayer(Map map,string d)
        {
            switch (d) 
            {                
                case "Down":
                    if (map.GetID(map.player.y, map.player.x+2)=='C')
                    {
                        map.MoveTo(map.player.x+1, map.player.y,
                                    map.player.x+2, map.player.y);
                    }
                    else return false;
                    break;
                case "Up":
                    if (map.GetID(map.player.y, map.player.x-2)=='C')
                    {
                        map.MoveTo(map.player.x-1, map.player.y,
                                    map.player.x-2, map.player.y);
                    }
                    else return false;
                    break;
                case "Left":
                    if (map.GetID(map.player.y-2, map.player.x)=='C')
                    {
                        map.MoveTo(map.player.x, map.player.y-1,
                                    map.player.x, map.player.y-2);
                    }
                    else return false;
                    break;
                case "Right":
                    if (map.GetID(map.player.y+2, map.player.x)=='C')
                    {
                        map.MoveTo(map.player.x, map.player.y+1,
                                    map.player.x, map.player.y+2);
                    }
                    else return false;
                    break;
                default:
                    break;
            }
            return true;
        }

        public static void PlayerMove(Map map,int x,int y,string d)
        {
            switch (map.GetID(y, x)) {
                case 'W':
                    break;
                case 'E':

                    break;
                case 'T':
                    
                    break ;
                case 'B':
                    if (MapAction.PushByPlayer(map, d)) 
                    { 
                    map.MoveTo( x,y, map.player.x, map.player.y);
                    map.player.x=x; map.player.y=y;
                    }
                    break;
                default:                    
                    map.MoveTo( map.player.x, map.player.y,x,y);
                    map.player.x=x; map.player.y=y;
                    break;

            }

        }

        public static void PlantBomb(Map map)
        {
            map.AddToMap(new Trap(map.player.y+1, map.player.x, 'O'));
            map.listABombs.Add(new Trap(map.player.y+1, map.player.x));
        }
        public static void TrigerBomb(Map map,int i)
        {
            if (map.GetID(map.listABombs[i].y, map.listABombs[i].x)=='W')
            {

            }
        }


    }

}
        
