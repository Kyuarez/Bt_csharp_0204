using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bt_csharp_0217
{
    public class World
    {
        //@TK : 10 X 10이라서 임시로 
        public GameObject[] gameObjects = new GameObject[100];
        int useGameObjectCount = 0;

        public void Instantiate(GameObject gameObject)
        {
            gameObjects[useGameObjectCount] = gameObject;
            useGameObjectCount++;
        }

        public void Update()
        {
            for (int i = 0; i < gameObjects.Length; i++)
            {
                gameObjects[i].Update();
            }
        }

        public void Render()
        {
            for (int i = 0; i < gameObjects.Length; i++)
            {
                gameObjects[i].Render();
            }
        }

    }
}
