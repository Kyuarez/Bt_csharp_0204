using System;
using System.ComponentModel;

namespace bt_csharp_0211
{
    internal class Program
    {
        public class InGame
        {
            Player player;
            Monster[] monsters;
            Monster currentTarget;
            public bool isWin;
            
            public InGame()
            {
                player = new Player(100, 25, MoveType.Walk);
                monsters = new Monster[] {
                    new Goblin(50, 20, 10),
                    new Slime(25, 5, 5),
                    new WildBoar(100, 50, 20),
                };

                currentTarget = monsters[0];
                isWin = false;
            }

            public void PlayGame()
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("=================================");
                    Console.WriteLine("M : 움직이기, A : 공격하기");
                    Console.WriteLine("=================================");
                    Console.WriteLine($"현재 플레이어 체력 : {player.hp}");
                    Console.WriteLine($"현재 플레이어 골드 : {player.gold}G");
                    Console.WriteLine("=================================");

                    bool isMove = false;

                    currentTarget = SetCurrentMonster();

                    //PlayerTurn
                    ConsoleKeyInfo input = Console.ReadKey();
                    if(input.Key == ConsoleKey.M)
                    {
                        player.Move();
                        isMove = true;
                    }
                    else if (input.Key == ConsoleKey.A)
                    {
                        player.Attack(currentTarget);              
                    }

                    //Enemy Turn
                    if(isMove == true)
                    {
                        if (true == player.GetIsAvoid())
                        {
                            Console.WriteLine($"{player.codeName}가 {currentTarget.codeName}의 공격을 회피했습니다.");
                        }
                        else
                        {
                            if (currentTarget.isDie == false)
                            {
                                currentTarget.Attack(player);
                            }
                        }
                    }
                    else
                    {
                        if (currentTarget.isDie == false)
                        {
                            currentTarget.Attack(player);
                        }
                    }

                    //check
                    bool isAllKill = true;
                    for (int i = 0; i < monsters.Length; i++) 
                    {
                        if (monsters[i].isDie == false)
                        {
                            isAllKill = false;
                        }
                    }

                    Console.WriteLine("=====================");
                    Console.WriteLine("Enter를 눌러주세요!");
                    Console.ReadKey();


                    if (player.isDie == true)
                    {
                        isWin = false;
                        break;
                    }
                    if(isAllKill == true)
                    {
                        isWin = true;
                        break;
                    }
                }

                Console.Clear();
                if(isWin == true)
                {
                    Console.WriteLine("=================================");
                    Console.WriteLine($"현재 플레이어 체력 : {player.hp}");
                    Console.WriteLine($"현재 플레이어 골드 : {player.gold}G");
                    Console.WriteLine("=================================");
                    Console.WriteLine("와! 모든 몬스터가 다 죽었어요!");
                }
                else
                {
                    Console.WriteLine("=================================");
                    Console.WriteLine($"현재 플레이어 체력 : {player.hp}");
                    Console.WriteLine($"현재 플레이어 골드 : 0(-{player.gold})G");
                    Console.WriteLine("=================================");
                    Console.WriteLine("플레이어가 마을에 리스폰 될 것입니다.");
                }
                Console.WriteLine("게임 종료!");
            }

            public Monster SetCurrentMonster()
            {
                int[] indexArr = new int[monsters.Length];
                Random rnd = new Random();
                for (int i = 0; i < indexArr.Length; i++)
                {
                    indexArr[i] = i;
                }

                for (int i = 0; i < indexArr.Length; i++)
                {
                    int temp = indexArr[i];
                    int ran = rnd.Next(0, indexArr.Length);
                    indexArr[i] = indexArr[ran];
                    indexArr[ran] = temp;
                }

                for (int i = 0; i < indexArr.Length; i++)
                {
                    if (monsters[indexArr[i]].isDie == false)
                    {
                        return monsters[indexArr[i]];
                    }
                }

                return null;
            }
        }

        public enum MoveType
        {
            Walk,
            Slide,
            Run,
        }

        public static string GetMoveType(MoveType moveType)
        {
            switch (moveType)
            {
                case MoveType.Walk:
                    return "걸어서";
                case MoveType.Slide:
                    return "미끄러지며";
                case MoveType.Run:
                    return "뛰며";
                default:
                    return "그냥";
            }
        }

        public class Player
        {
            public string codeName;
            public int hp;
            public int damage;
            public int gold;
            public bool isDie;
            public MoveType moveType;


            public Player(int _hp, int _damage, MoveType _moveType)
            {
                codeName = this.GetType().Name;
                hp = _hp;
                damage = _damage;
                gold = 0;
                moveType = _moveType;
                isDie = false;

            }

            public void Attack(Monster monster)
            {
                Console.WriteLine($"{codeName}가 {monster.codeName}을 {damage} 데미지 공격했다.");
                monster.Damage(damage);
                if (monster.isDie == true)
                {
                    Console.WriteLine($"{codeName}가 {monster.reward} 골드를 얻었다.");
                    gold += monster.reward;
                }
            }

            public void Damage(int damage)
            {
                hp = (hp - damage) > 0 ? (hp - damage) : 0;
                CheckDie();
            }

            public void Move()
            {
                Console.WriteLine($"{codeName}가 {GetMoveType(moveType)} 움직였다.");
            }

            public void CheckDie()
            {
                if (hp <= 0)
                {
                    isDie = true;
                    Console.WriteLine($"{codeName}가 죽었다..");
                    return;
                }
                isDie = false;
            }

            //Random으로 처리 (80% 확률)
            public bool GetIsAvoid()
            {
                Random rnd = new Random();
                int rndNum = rnd.Next(0, 10);

                if(rndNum > 7) //80%
                {
                    return false;
                }
                
                return true;
            } 
        }


        public class Monster
        {
            public string codeName;
            public int hp;
            public int damage;
            public int reward;
            public bool isDie;
            public MoveType moveType;

            public void Attack(Player player)
            {
                Console.WriteLine($"{codeName}이 {player.codeName}을 {damage} 데미지 공격했다.");
                player.Damage(damage);
            }
            public void Damage(int damage)
            {
                hp = (hp - damage) > 0 ? (hp - damage) : 0;
                CheckDie();
            }

            public void Move()
            {
                Console.WriteLine($"{codeName}이 {GetMoveType(moveType)} 움직였다.");
            }

            public void CheckDie()
            {
                if (hp <= 0)
                {
                    isDie = true;
                    Console.WriteLine($"{codeName}이 죽었다..");
                    return;
                }
                isDie = false;
            }
        }

        public class Goblin : Monster
        {
            public Goblin(int _hp, int _reward, int _damage)
            {
                codeName = this.GetType().Name;
                hp= _hp;
                reward= _reward;
                damage= _damage;
                moveType = MoveType.Walk;
                isDie = false;
            }

        }

        public class Slime : Monster
        {
            public Slime(int _hp, int _reward, int _damage)
            {
                codeName = this.GetType().Name;
                hp = _hp;
                reward = _reward;
                damage = _damage;
                moveType = MoveType.Walk;
                isDie = false;
            }
        }
        
        public class WildBoar : Monster
        {
            public WildBoar(int _hp, int _reward, int _damage)
            {
                codeName = this.GetType().Name;
                hp = _hp;
                reward = _reward;
                damage = _damage;
                moveType = MoveType.Walk;
                isDie = false;
            }
        }


        static void Main(string[] args)
        {
            InGame game = new InGame();
            game.PlayGame();    
        }
    }
}
