using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace bt_csharp_0217
{
    public class Engine
    {
        protected bool isRunning = true;
        protected ConsoleKeyInfo keyInfo;

        public void Load()
        {
            //@tk : 나중에 file로 로딩
            string[] scene =
            {
                "**********",
                "*P       *",
                "*        *",
                "*        *",
                "*        *",
                "*     M  *",
                "*        *",
                "*        *",
                "*       G*",
                "**********",
            };
            world = new World();

            for (int y = 0; y < scene.Length; y++) 
            {
                for (int x = 0; x < scene[y].Length; x++)
                {
                    if( scene[y][x] == '*')
                    {
                        Wall wall = new Wall(x, y, scene[x][y]);
                        world.Instantiate(wall);
                    }
                    else if (scene[y][x] == ' ')
                    {
                        Floor floor = new Floor(x, y, scene[x][y]);
                        world.Instantiate(floor);
                    }
                    else if (scene[y][x] == 'P')
                    {
                        Player player = new Player(x, y, scene[x][y]);
                        world.Instantiate(player);
                    }
                    else if (scene[y][x] == 'M')
                    {
                        Monster monster = new Monster(x, y, scene[x][y]);
                        world.Instantiate(monster);
                    }
                    else if (scene[y][x] == 'G')
                    {
                        Goal goal = new Goal(x, y, scene[x][y]);
                        world.Instantiate(goal);
                    }
                }
            }
        }

        public void Input()
        {
            keyInfo = Console.ReadKey();
        }

        protected void Update()
        {
            world.Update();
        }

        protected void Render()
        {
            world.Render();
        }

        public void Run()
        {
            while (isRunning)
            {
                Input();

            }
        }

        public World world;
    }
}
