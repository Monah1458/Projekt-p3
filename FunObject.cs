using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektp3
{
    class FunObject
    {
        private int x, y;
        private char def = 'c';
        
        public FunObject(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public void SetXY(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int GetX() 
        { 
            return this.x;
        }
        public int GetY()
        {
            return this.y;
        }
        public char GetChar() {
            return this.def;
        }
        public void Setchar(char x)
        {
            this.def = x;
        }
        public void MoveRight() {
            this.y++;
        }
        public void MoveLeft()
        {
            this.y--;
        }
        public void MoveUp()
        {
            this.x--;
        }
        public void MoveDown()
        {
            this.x++;
        }

    }



}
