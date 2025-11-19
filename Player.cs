using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektp3
{
    class Player : FunObject
    {
        public Player(int x, int y) : base(x, y)
        {
            this.ID='P';
            this.Setchar('P');
        }
        public Player(int x, int y, char P) : base(x, y)
        {
            this.ID='P';
            this.Setchar(P);
        }


    }
}
