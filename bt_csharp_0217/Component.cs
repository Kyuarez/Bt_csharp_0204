using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bt_csharp_0217
{
    public abstract class Component
    {
        public Component()
        {

        }

        public abstract void OnEnable();

        public abstract void OnDisable();
    }
}
