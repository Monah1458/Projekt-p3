using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektp3
{
    public class FunObject
    {
        public int k=0;
        public int p=0;
        public int x { get; set; }
        public int y { get; set; }
        public char ID { get; set; }
        public char def { get; private set; } = ' ';
        public int cost = 0;
        public int heuristic = 0;
        public int total = 0;
        public FunObject(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.ID='C';
        }
        public void SetXY(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public char GetChar()
        {
            return this.def;
        }
        public void Setchar(char x)
        {
            this.def = x;
        }
        public void MoveRight()
        {
            this.x++;
        }
        public void MoveLeft()
        {
            this.x--;
        }
        public void MoveUp()
        {
            this.y--;
        }
        public void MoveDown()
        {
            this.y++;
        }
        public override bool Equals(object obj)
        {
            if (obj is FunObject f)
                return f.x == this.x && f.y == this.y;

            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }


}
