using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bt_csharp_0217
{
    public class Player : GameObject
    {
        public Player(int x, int y, char shape)
        {
            this.x = x;
            this.y = y;
            this.shape = shape;
        }

        public override void Update() 
        {
            if (true == Input.GetKeyDown(ConsoleKey.DownArrow) || true == Input.GetKeyDown(ConsoleKey.S))
            {
                y++;
            }
            else if(true == Input.GetKeyDown(ConsoleKey.UpArrow) || true == Input.GetKeyDown(ConsoleKey.W))
            {
                y--;
            }
            else if (true == Input.GetKeyDown(ConsoleKey.LeftArrow) || true == Input.GetKeyDown(ConsoleKey.A))
            {
                x--;
            }
            else if (true == Input.GetKeyDown(ConsoleKey.RightArrow) || true == Input.GetKeyDown(ConsoleKey.D))
            {
                x++;
            }

        }

    }
}
