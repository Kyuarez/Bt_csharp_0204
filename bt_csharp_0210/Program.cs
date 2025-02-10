using System;
using System.Reflection;

namespace bt_csharp_0210
{
    /* 02.10 클래스와 객체지향
     */

    #region Pixel
    public struct PixelVertex
    {
        public int x;
        public int y;

        public PixelVertex(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public struct PixelColor
    {
        public int r;
        public int g;
        public int b;

        public PixelColor(int r, int g, int b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }
    }

    public class TKPixel
    {
        public PixelVertex vertex;
        public PixelColor color;

        //생성자
        public TKPixel(PixelVertex vertex, PixelColor color)
        {
            this.vertex = vertex;
            this.color = color;
        }

        //소멸자
        ~TKPixel()
        {
            Console.WriteLine($"{GetType()} is destroy!");
        }
    }
    #endregion

    #region Assignment
    public class World
    {
        public Tile[,] tiles = new Tile[10,10];
        public Player player;
        public Monster[] monsters;
        public Destination destination;

        public World() 
        {
            CreateWorld();
            player = new Player(1,1);
            SetMonsterOnTile(2);
            destination = new Destination(9, 9);
        }

        public void CreateWorld()
        {
            for (int i = 0; i < tiles.GetLength(0); i++) 
            {
                for (int j = 0; j < tiles.GetLength(1); j++)
                {
                    if(i == 0 || i == (tiles.GetLength(0) - 1))
                    {
                        tiles[i, j] = new Wall(i, j);
                        continue;
                    }

                    if(j == 0 || j == (tiles.GetLength(1) - 1))
                    {
                        tiles[i, j] = new Wall(i, j);
                        continue;
                    }

                    tiles[i, j] = new Floor(i, j);
                }
            }
        }

        public void SetMonsterOnTile(int monsterCount)
        {
            
        }

        public void Update()
        {
            while (true)
            {
                
                if(destination.CheckFinish(player) == true)
                {
                    break;
                }
            }
        }
    }

    public class Tile
    {
        public Vector2D position;
        public bool isMove;

        public Tile(int x, int y)
        {
            position.x = x;
            position.y = y;
        }
    }

    public class Wall : Tile
    {
        public Wall(int x, int y) : base(x, y)
        {
            isMove = false;
        }
    }

    public class Floor : Tile
    {
        public Floor(int x, int y) : base(x, y)
        {
            isMove = true;
        }
    }

    public class Player
    {
        public Vector2D position;

        public Player(int x, int y)
        {
            position.x = x;
            position.y = y;
        }

        public void Move(MoveType moveType)
        {

            switch (moveType)
            {
                case MoveType.Up:
                    position.y += 1;
                    break;
                case MoveType.Down:
                    position.y -= 1;
                    break;
                case MoveType.Left:
                    position.x -= 1;
                    break;
                case MoveType.Right:
                    position.y += 1;
                    break;
                default:
                    break;
            }
        }
    }

    public class Monster
    {
        public Vector2D position;

        public Monster(int x, int y)
        {
            position.x = x;
            position.y = y;
        }

        public void Move(MoveType moveType)
        {
            switch (moveType)
            {
                case MoveType.Up:
                    position.y += 1;
                    break;
                case MoveType.Down:
                    position.y -= 1;
                    break;
                case MoveType.Left:
                    position.x -= 1;
                    break;
                case MoveType.Right:
                    position.y += 1;
                    break;
                default:
                    break;
            }
        }
    }

    public class Destination
    {
        public Vector2D position;

        public Destination(int x, int y)
        {
            position.x = x; 
            position.y = y;
        }

        public bool CheckFinish(Player player)
        {
            if(this.position.x == player.position.x && this.position.y == player.position.y)
            {
                return true;
            }

            return false;
        }
    }

    public enum MoveType
    {
        Up,
        Down,
        Left,
        Right,
    }

    public struct Vector2D
    {
        public int x;
        public int y;
        public Vector2D(int x, int y) 
        {
            this.x = x;
            this.y = y;
        }
    }


    #endregion


    #region FSM
    /*
     ID, 상태이름
     */

    public class State
    {
        public int codeID;
        public string stateName;
    
        public State(int codeID, string stateName)
        {
            this.codeID = codeID;
            this.stateName = stateName;
        }
    }


    /*
     현상태, 조건, 다음상태 
     */
    public class Transition
    {
        public State currentState;
        public Condition condition;
        public State nextState;
            
        //?
        public Transition(State currentState, Condition condition, State nextState) 
        {
            this.currentState = currentState;
            this.condition = condition;
            this.nextState = nextState;
        }
    }

    public enum Condition
    {
        EnemySpotted, // 적 발견
        EnemyLost,    // 적 놓침
        Approaching,  // 사정거리 접근
        Retreating,   // 사정거리 이탈
        NoHealth      // HP 없음
    }

    #endregion

    internal class Program
    {
        static void Main(string[] args)
        {
            Type type = (typeof(Int32));

            Console.WriteLine(type.Name);
            Console.WriteLine(type.BaseType.ToString());
            Console.WriteLine(type.BaseType.BaseType.ToString());

            //TKPixel[] carImg = new TKPixel[3];
            //carImg[0] = new TKPixel(new PixelVertex(0, 0), new PixelColor(165, 55, 128));
            //carImg[1] = new TKPixel(new PixelVertex(0, 1), new PixelColor(133, 28, 182));
            //carImg[2] = new TKPixel(new PixelVertex(0, 2), new PixelColor(115, 136, 63));
        }
    }
}   
