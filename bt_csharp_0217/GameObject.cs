using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bt_csharp_0217
{
    public class GameObject
    {
        public int x;
        public int y;
        public char shape;

        public virtual void Update()
        {

        }

        public virtual void Render()
        {
            //x,y 위치에 shape 출력
            Console.SetCursorPosition(x, y);
            Console.Write(shape);
        }
    }
}
