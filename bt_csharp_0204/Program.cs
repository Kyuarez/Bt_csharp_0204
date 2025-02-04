namespace bt_csharp_0204
{
    internal class Program
    {
        //1-> 13 : heart (1 : A / 11 : J, 12 : Q, 13 : K)
        //14 -> 26 : diamond
        //27 - 39 : clover
        //40 - 52 : spade
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
            int[] deck = CreateArrayD1(52);
            Shuffle(ref deck);
            PrintTrumphCard(deck);
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

        static void PrintTrumphCard(int[] array) 
        {
            for (int i = 0; i < 8; i++)
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
                Console.Write(p_data + "\n");
            }
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
