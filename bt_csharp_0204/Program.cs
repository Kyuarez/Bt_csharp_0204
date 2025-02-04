using static System.Formats.Asn1.AsnWriter;

namespace bt_csharp_0204
{
    internal class Program
    {
        //1-> 13 : heart (1 : A / 11 : J, 12 : Q, 13 : K)
        //14 -> 26 : diamond
        //27 - 39 : clover
        //40 - 52 : spade

        /* 블랙잭 룰
         * 각각 카드 두 장 씩 받음. 
         * 두 개의 카드 값 합이 21이면 블랙잭!
         * 원하면 계속 한 장씩 뽑음.
         * -> 최종적으로 21에 가장 가까운 사람이 승리
         * -> 뽑다가 21을 넘어가면 Burst! 플레이어 패배
         * -------------------------------------------
         * K,Q,J는 10이고 A는 1또는 10이다.
         */

        public enum PlayerType
        {
            Player,
            Computer,
        }

        static char S_HEART = '♡';
        static char S_DIAMOND = '◇';
        static char S_CLOVER = '♣';
        static char S_SPADE = '♠';
        static char V_ACE = 'A';
        static char V_JACK = 'J';
        static char V_QUEEN = 'Q';
        static char V_KING = 'K';

        static void Main(string[] args)
        {
            //card deck set
            int[] deck = CreateArrayD1(52);
            Shuffle(ref deck);

            //set computer v player one turn
            int[] playerCards = SetPlayerCards(deck, PlayerType.Player);
            int[] computerCards = SetPlayerCards(deck, PlayerType.Computer);

            PrintSingleGameOneTurn(computerCards, playerCards);
        }

        static int[] CreateArrayD1(int length)
        {
            int[] result = new int[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = i + 1;
            }
            return result;
        }


        static void Shuffle(ref int[] array)
        {
            Random rnd = new Random();
            for (int i = array.Length - 1; i > 0; i--) 
            {
                int j = rnd.Next(i + 1);
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }

        static int[] SetPlayerCards(int[] deck, PlayerType type)
        {
            int[] playerCards = new int[3];
            if(type == PlayerType.Player)
            {
                for (int i = 0; i < 3; i++)
                {
                    playerCards[i] = deck[i];
                }
            }
            else if(type == PlayerType.Computer)
            {
                for (int i = 0; i < 3; i++)
                {
                    playerCards[i] = deck[i + 3];
                }
            }
            return playerCards;
        }

        static int[] CalcBlackjackScoreArr(int[] playerCards)
        {
            //arr length : ace count
            int aceCount = CalcAceCount(playerCards);
            int[] scoreArr = new int[(aceCount) == 0 ? 1 : (int)Math.Pow(2, aceCount)];

            //ace count = 0
            for (int i = 0; i < scoreArr.Length; i++)
            {
                int score = 0;
                int aceIndex = 0;
                for (int j = 0; j < playerCards.Length; j++)
                {
                    int factor = playerCards[j] % 13;
                    switch (factor)
                    {
                        case 1: //A
                            int aceValue = ((i & (1 << aceIndex)) == 0) ? 1 : 11;
                            score += aceValue;
                            aceIndex++;
                            break;
                        case 11://J, Q, K
                        case 12:
                        case 0:
                            score += 10;
                            break;
                        default:
                            score += factor;
                            break;
                    }
                }
                scoreArr[i] = score;
            }
            return scoreArr;
        }

        static int CalcAceCount(int[] playerCards)
        {
            int aceCount = 0;
            for (int i = 0; i < playerCards.Length; i++)
            {
                if (playerCards[i] % 13 == 1)
                {
                    aceCount++;
                }
            }
            return aceCount;
        }

        static void PrintSingleGameOneTurn(int[] computerCardArr, int[] playerCardArr)
        {

            int[] computerScoreArr = CalcBlackjackScoreArr(computerCardArr);
            int[] playerScoreArr = CalcBlackjackScoreArr(playerCardArr);
            bool isBlackjack = false;

            Console.WriteLine("컴퓨터 카드");
            PrintTrumphCard(computerCardArr);
            Console.WriteLine("컴퓨터 점수 가능성");
            for (int i = 0; i < computerScoreArr.Length; i++)
            {
                if (computerScoreArr[i] > 21)
                {
                    Console.Write("(Bust)");
                }
                Console.Write(computerScoreArr[i] + "\t");
            }

            Console.WriteLine();
            Console.WriteLine("-------------------------------------");

            Console.WriteLine("플레이어 카드");
            PrintTrumphCard(playerCardArr);
            Console.WriteLine("플레이어 점수 가능성");
            for (int i = 0; i < playerScoreArr.Length; i++)
            {
                if (playerScoreArr[i] > 21)
                {
                    Console.Write("(Bust)");
                }
                Console.Write(playerScoreArr[i] + "\t");
            }

            Console.WriteLine();
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("[결과]");
            if(true == IsPlayerWinSingle(computerScoreArr, playerScoreArr, ref isBlackjack))
            {
                Console.Write("플레이어 승리");
            }
            else
            {
                Console.Write("컴퓨터 승리");
            }

            if (isBlackjack == true)
            {
                Console.Write("(블랙잭)");
            }

        }

        static bool IsPlayerWinSingle(int[] computerArr, int[] playerArr, ref bool isBlackjack)
        {
            int playerMinScore = playerArr[0];
            int computerMaxScore = 0;
            int playerMaxScore = 0;

            for (int i = 0; i < computerArr.Length; i++)
            {
                if (computerArr[i] > 21)
                {
                    continue;
                }

                if(computerMaxScore < computerArr[i])
                {
                    computerMaxScore = computerArr[i];
                }
            }
            for (int i = 0; i < playerArr.Length; i++)
            {
                if (playerArr[i] > 21)
                {
                    continue;
                }

                if (playerMaxScore < playerArr[i])
                {
                    playerMaxScore = playerArr[i];
                }
            }

            //check player Burst
            if(playerMinScore > 21)
            {
                return false;
            }

            //check blackjack
            if(playerMaxScore == 21 || computerMaxScore == 21)
            {
                isBlackjack = true;
            }

            return playerMaxScore >= computerMaxScore; 
        }

        static void PrintTrumphCard(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                string p_data = "";
                int factorShape = array[i] % 4;
                switch (factorShape)
                {
                    case 0:
                        p_data += S_HEART;
                        break;
                    case 1:
                        p_data += S_DIAMOND;
                        break;
                    case 2:
                        p_data += S_CLOVER;
                        break;
                    case 3:
                        p_data += S_SPADE;
                        break;
                    default:
                        break;
                }
                int factor = array[i] % 13;
                switch (factor)
                {
                    case 1:
                        p_data += ("_" + V_ACE);
                        break;
                    case 11:
                        p_data += ("_" + V_JACK);
                        break;
                    case 12:
                        p_data += ("_" + V_QUEEN);
                        break;
                    case 0:
                        p_data += ("_" + V_KING);
                        break;
                    default:
                        p_data += "_" + factor.ToString();
                        break;
                }
                Console.Write(p_data + "\t");
            }
            Console.WriteLine();
        }

        #region REST
        static void ShuffleTenTime(ref int[] array)
        {
            Random rnd = new Random();

            for (int i = 0; i < array.Length * 10; i++)
            {
                int firstCardIndex = rnd.Next(0, array.Length);
                int secondCardIndex = rnd.Next(0, array.Length);

                int temp = array[firstCardIndex];
                array[firstCardIndex] = array[secondCardIndex];
                array[secondCardIndex] = temp;
            }
        }

        
        static void ArrRnd01()
        {
            int tryCount = 8;
            int[] tempArr = new int[52];
            int[] rndArr = new int[tryCount];
            for (int i = 0; i < tempArr.Length; i++)
            {
                tempArr[i] = i + 1;
            }


            Random rnd = new Random();
            int index = 0;
            for (int i = 0; i < tryCount; i++)
            {
                bool dupCheck = false;
                int rndNum = tempArr[rnd.Next(tempArr.Length)];

                //check
                for (int j = 0; j < index; j++)
                {
                    if (rndArr[j] == rndNum)
                    {
                        dupCheck = true;
                        break;
                    }
                }

                if (dupCheck == true)
                {
                    i--;
                    continue;
                }
                else
                {
                    rndArr[index] = rndNum;
                    index++;
                }
            }


            for (int i = 0; i < rndArr.Length; i++)
            {
                Console.Write(rndArr[i] + "\n");
            }
        }
        #endregion
    }
}
