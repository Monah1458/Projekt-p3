// See https://aka.ms/new-console-template for more information
using Projektp3;


class Program
{

    static void Main(string[] args)
    {


        //MapAction.SetDistr(map, p1);
        ////map.AddToMap(new Trap(p1.x+1, p1.y, 'D'));
        //map.PrintMap();
        //List<FunObject> list = MapAction.PathToDistr(map);
        //Pathfinder pf = new Pathfinder(map);
        //List<FunObject> list1 = pf.SearchPath(new FunObject(p1.x+1,p1.y), p4);
        //list1.Add(new FunObject(p1.x+1, p1.y));
        //Console.WriteLine(list1.Last().x+" "+list1.Last().y);
        //Console.WriteLine(p1.x+1+" "+p1.y);
        //do
        //{
        //    Console.Clear();
        //    //Console.WriteLine(list1[k].x+" "+list[k].y);
        //    //MapAction.MovePathEnemy(map, list1, k);
        //    map.MoveTo(p4, list1[k]);
        //    map.PrintMap() ;
        //    if (list1[k].Equals(list1.Last())) break;
        //    Thread.Sleep(1000);
        //    k++;
        //} while (true);

        //do
        //{

        //    PlayerInput.KeyPlayerInput(map, p1);
        //    Console.Clear();
        //    map.PrintMap();
        //    Console.WriteLine(p1.x+"y= "+p1.y);
        //    Thread.Sleep(100);
        //} while (true);


        //Map map = new Map(10, 10);
        //Enemy E1 = new Enemy(1, 1);
        //Player p2 = new Player(7, 8);
        //Player p1 = new Player(0, 0);
        //map.AddToMap(p1);
        //Pathfinder pf = new Pathfinder(map);
        //map.AddToMap(E1);
        //map.AddToMap(new FunObject(9, 9));      
        //MapAction.SetDistr(map, p2);
        //List<FunObject> list1 = MapAction.PathToDistr(map);
        //    map.AddToMap(new Player(3, 5));
        //list1.Add(new FunObject(8, 8));
        //map.PrintMap();
        //Thread.Sleep(1000);
        Map map = new Map();
        //Player p1 = new Player(1,1);
        //}

        //do
        //{

        //    Console.Clear();
        //    //map.MoveTo(list1[i-1].x, list1[i-1].y, list1[i]);
        //    MapAction.EnemyAlongPath(map, list1);
        //    map.PrintMap();

        //    Thread.Sleep(1000);
        //} while (true);  
        MapAction.EnemyStartPath(map);
        
        do
        {


            //PlayerInput.KeyPlayerInput(map);
            MapAction.MoveEnemes(map);
            Console.Clear();
            map.PrintMap();
            Console.WriteLine(map.listEnemies[0].x);
            Console.WriteLine(map.listEnemies[0].y);
            Console.WriteLine(map.GetID(13, 1));
            Console.WriteLine(map.GetID(13, 3));
            Thread.Sleep(2000);

        } while (true);




    }
}