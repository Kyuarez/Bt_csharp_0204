using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bt_csharp_0217
{
    public class Monster : GameObject
    {
        public Monster(int x, int y, char shape)
        {
            this.x = x;
            this.y = y;
            this.shape = shape;
        }

        public override void Update()
        {
            Random random = new Random();
            int rndNum = random.Next(0, 4);
            
            if(rndNum == 0)
            {
                y--;
            }
            else if(rndNum == 1)
            {
                y++;
            }
            else if(rndNum == 2)
            {
                x--;
            }
            else if(rndNum == 3)
            {
                x++;
            }
        }
    }
}
