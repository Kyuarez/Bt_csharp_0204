using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bt_csharp_0217
{
    public class GameObject
    {
        public string Name { get; set; }
        public int x;
        public int y;
        public char shape;

        protected bool active;
        public bool ActiveSelf { get { return active; } }


        private List<Component> components = new List<Component>();

        public virtual void Update()
        {

        }

        public virtual void Render()
        {
            if(false == active)
            {
                return;
            }

            //x,y 위치에 shape 출력
            Console.SetCursorPosition(x, y);
            Console.Write(shape);
        }

        public void SetActive(bool active)
        {
            this.active = active;
        }

        public void AddComponent<T>(T component) where T : Component
        {
            if(component == null)
            {
                return;
            }

            components.Add(component);
        }

        public T GetComponent<T>() where T : Component
        {
            foreach (var component in components)
            {
                if(component is T)
                {
                    return (T)component;
                }
            }

            return default(T);
        }
    }
}
