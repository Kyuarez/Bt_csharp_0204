namespace bt_csharp_0204
{
    internal class Program
    {
        //1-> 13 : heart (1 : A / 11 : J, 12 : Q, 13 : K)
        //14 -> 26 : diamond
        //27 - 39 : clover
        //40 - 52 : spade
        static void Main(string[] args)
        {
            int[] deck = CreateArrayD1(52);

            //Shuffle
            //Random rnd = new Random();

            //for (int i = 0; i < deck.Length * 10; i++) 
            //{
            //    int firstCardIndex = rnd.Next(0, deck.Length);
            //    int secondCardIndex = rnd.Next(0, deck.Length);

            //    int temp = deck[firstCardIndex];
            //    deck[firstCardIndex] = deck[secondCardIndex];
            //    deck[secondCardIndex] = temp;
            //}

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
                int data = array[i] % 13;
                string p_data = "";
                switch (data)
                {
                    case 1:
                        p_data = "A";
                        break;
                    case 11:
                        p_data = "J";
                        break;
                    case 12:
                        p_data = "Q";
                        break;
                    case 13:
                        p_data = "K";
                        break;
                    default:
                        p_data = array[i].ToString();
                        break;
                }
                Console.Write(p_data + "\n");
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

        
    }
}
