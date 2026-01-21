using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektp3
{
    class Trap : FunObject{
        public Trap(int x, int y) : base(x, y)
        {
            this.ID='T';
            this.Setchar('T');
        }
        public Trap(int x,int y,char T):base(x,y) 
        {
            this.Setchar(T);
            this.ID=T;
        }
        
    }
}
