﻿using System;
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

    }
}
