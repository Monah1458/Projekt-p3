using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektp3
{
    public class Walls : FunObject
    {
        public Walls(int x, int y) : base(x, y)
        {
            this.ID='W';
            this.Setchar('W');
        }
        public Walls(int x, int y,char T) : base(x, y)
        {
            this.Setchar(T);
            this.ID='W';
        }
    }
}
