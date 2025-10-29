using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektp3
{
    class Map
    {
        private FunObject[][] map;
        public void SetMap()
        {
            this.map=new FunObject[10][];
            for (int x = 0; x < map.Length; x++)
            {
                this.map[x]= new FunObject[10];
                for (int y = 0; y < map[x].Length; y++)
                {
                    this.map[x][y]= new FunObject(x, y);
                }
            }

        }
        public void PrintMap()
        {

            for (int x = 0; x < map.Length; x++)
            {
                for (int y = 0; y < map[x].Length; y++)
                {
                    Console.Write(map[x][y].GetChar()+ " ");
                }
                Console.WriteLine();
            }
        }
        public void AddToMap<T>(T t) where T : FunObject
        {
            int g = t.GetX();
            int b = t.GetY();
            map[g][b]=t;
        }
        public void MoveLeft<T>(T t) where T : FunObject
        {
            map[t.GetX()][t.GetY()]=new FunObject(t.GetX(), t.GetY());
            map[t.GetX()][t.GetY()-1]=t;
            t.MoveLeft();
        }

        public void MoveRight<T>(T t) where T : FunObject
        {
            map[t.GetX()][t.GetY()]=new FunObject(t.GetX(), t.GetY());
            map[t.GetX()][t.GetY()+1]=t;
            t.MoveRight();
        }
        public void MoveUp<T>(T t) where T : FunObject
        {
            map[t.GetX()][t.GetY()]=new FunObject(t.GetX(), t.GetY());
            map[t.GetX()-1][t.GetY()]=t;
            t.MoveUp();
        }
        public void MoveDown<T>(T t) where T : FunObject
        {
            
            map[t.GetX()][t.GetY()]=new FunObject(t.GetX(),t.GetY());
            map[t.GetX()+1][t.GetY()]=t;
            t.MoveDown();
        }

        public void DelObject<T>(T t) where T : FunObject
        {
            map[t.GetX()][t.GetY()]=new FunObject(t.GetX(), t.GetY());
        }

        public char GetChar(int x,int y) 
        {
            return this.map[x][y].GetChar();
        }




    }
}